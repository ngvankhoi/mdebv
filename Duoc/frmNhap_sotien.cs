using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmNhap.
	/// </summary>
	public class frmNhap_sotien : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private MaskedBox.MaskedBox ngaysp;
		private MaskedBox.MaskedBox ngayhd;
		private MaskedBox.MaskedBox ngaykiem;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox chuathue;
		private System.Windows.Forms.TextBox cothue;
		private System.Windows.Forms.ComboBox cmbSophieu;
        private string xxx, user, s_mmyy, s_ngay, sql, s_loai, s_ngaysp, s_ngayhd, s_ngaykiem, s_makho, format_sotien, format_dongia, format_soluong, format_giaban, stkgiamgia;
        private int i_nhom, i_userid, i_madv, i_mabd, i_nhomcc, i_old, i_songay, manguon_old, makho_old, i_sole_giaban, i_sole_dongia, i_row, i_thanhtien_le, itable, i_khudt=0;
		private decimal l_id;
        private decimal d_dongia, d_sotien, d_sotienvat, d_chuathue, d_cothue;
        private bool bKhoaso, bGiaban, bGiamgia, bNew, bAdmin, bQuidoi, bGiaban_nguon, bNhom_nx, bKinhphi, bBienban, bNguoigiao, bDinhkhoan, bSophieu, bDongia, bChietkhau, bGiaban_danhmuc, bGiaban_noi_ngtru, bNhapkho_sotien_nhapVAT_1lan = true, bDmtyleban;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtold=new DataTable();
		private DataTable dtnguon=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtds=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataRow r;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox sohd;
		private MaskedTextBox.MaskedTextBox bbkiem;
		private MaskedTextBox.MaskedTextBox nguoigiao;
		private MaskedTextBox.MaskedTextBox no;
		private MaskedTextBox.MaskedTextBox co;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.CheckBox chkIn;
		private System.Windows.Forms.Button butIndenghi;
		private System.Windows.Forms.Label lsokhoan;
		private System.Windows.Forms.ComboBox cmbTimkiem;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel Danhsach;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox lsophieu;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
        private MaskedTextBox.MaskedTextBox chietkhau;
        private Label label34;
        private Label label33;
        private MaskedTextBox.MaskedTextBox txtVAT;
        private Label label14;
        private Label label15;
        private Button butPrint;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNhap_sotien(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool ban,bool admin,int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
			i_userid=userid;
			s_mmyy=mmyy;
			s_ngay=ngay;
			s_loai=loai;
			bGiaban=ban;
			bAdmin=admin;
			this.Text=title;
            i_khudt = _khudt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhap_sotien));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.ngayhd = new MaskedBox.MaskedBox();
            this.ngaykiem = new MaskedBox.MaskedBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.tendv = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chuathue = new System.Windows.Forms.TextBox();
            this.cothue = new System.Windows.Forms.TextBox();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.sohd = new MaskedTextBox.MaskedTextBox();
            this.bbkiem = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new MaskedTextBox.MaskedTextBox();
            this.no = new MaskedTextBox.MaskedTextBox();
            this.co = new MaskedTextBox.MaskedTextBox();
            this.find = new System.Windows.Forms.TextBox();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.butIndenghi = new System.Windows.Forms.Button();
            this.lsokhoan = new System.Windows.Forms.Label();
            this.cmbTimkiem = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.Danhsach = new System.Windows.Forms.Panel();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.lsophieu = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chietkhau = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtVAT = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.butPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.Danhsach.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(158, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Hóa đơn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(429, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-21, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nhà cung cấp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(530, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "BB kiểm số :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(675, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(538, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Người giao :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(27, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 45;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(156, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Kho :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(294, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 23);
            this.label11.TabIndex = 47;
            this.label11.Text = "Nợ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(443, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 48;
            this.label12.Text = "Có :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(202, 6);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // ngayhd
            // 
            this.ngayhd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayhd.Enabled = false;
            this.ngayhd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayhd.Location = new System.Drawing.Point(473, 6);
            this.ngayhd.Mask = "##/##/####";
            this.ngayhd.MaxLength = 10;
            this.ngayhd.Name = "ngayhd";
            this.ngayhd.Size = new System.Drawing.Size(64, 21);
            this.ngayhd.TabIndex = 4;
            this.ngayhd.Text = "  /  /    ";
            this.ngayhd.Validated += new System.EventHandler(this.ngayhd_Validated);
            // 
            // ngaykiem
            // 
            this.ngaykiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaykiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykiem.Enabled = false;
            this.ngaykiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykiem.Location = new System.Drawing.Point(720, 6);
            this.ngaykiem.Mask = "##/##/####";
            this.ngaykiem.Name = "ngaykiem";
            this.ngaykiem.Size = new System.Drawing.Size(64, 21);
            this.ngaykiem.TabIndex = 6;
            this.ngaykiem.Text = "  /  /    ";
            this.ngaykiem.Validated += new System.EventHandler(this.ngaykiem_Validated);
            // 
            // madv
            // 
            this.madv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Enabled = false;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(72, 29);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(64, 21);
            this.madv.TabIndex = 7;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // tendv
            // 
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(138, 29);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(237, 21);
            this.tendv.TabIndex = 8;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(72, 52);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(93, 21);
            this.manguon.TabIndex = 12;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(202, 52);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(99, 21);
            this.makho.TabIndex = 13;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(43, 519);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 32;
            this.butMoi.Tag = "";
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(198, 519);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 33;
            this.butSua.Tag = "";
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(268, 519);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 30;
            this.butLuu.Tag = "";
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(338, 519);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 31;
            this.butBoqua.Tag = "";
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(408, 519);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 34;
            this.butHuy.Tag = "";
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Export;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(478, 519);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(84, 25);
            this.butIn.TabIndex = 35;
            this.butIn.Tag = "";
            this.butIn.Text = "&Phiếu nhập";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(679, 519);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 36;
            this.butKetthuc.Tag = "";
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Location = new System.Drawing.Point(320, 490);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 23);
            this.label21.TabIndex = 55;
            this.label21.Text = "Tổng cộng chưa thuế :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Location = new System.Drawing.Point(554, 489);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 23);
            this.label22.TabIndex = 56;
            this.label22.Text = "Tổng cộng có thuế :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chuathue
            // 
            this.chuathue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chuathue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chuathue.Enabled = false;
            this.chuathue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuathue.Location = new System.Drawing.Point(440, 491);
            this.chuathue.Name = "chuathue";
            this.chuathue.Size = new System.Drawing.Size(128, 21);
            this.chuathue.TabIndex = 57;
            this.chuathue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cothue
            // 
            this.cothue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cothue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cothue.Enabled = false;
            this.cothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cothue.Location = new System.Drawing.Point(672, 491);
            this.cothue.Name = "cothue";
            this.cothue.Size = new System.Drawing.Size(112, 21);
            this.cothue.TabIndex = 58;
            this.cothue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(72, 6);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(94, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(72, 6);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(93, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // sohd
            // 
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(323, 6);
            this.sohd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sohd.MaxLength = 50;
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(120, 21);
            this.sohd.TabIndex = 3;
            this.sohd.Validated += new System.EventHandler(this.sohd_Validated);
            // 
            // bbkiem
            // 
            this.bbkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bbkiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bbkiem.Enabled = false;
            this.bbkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbkiem.Location = new System.Drawing.Point(599, 6);
            this.bbkiem.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bbkiem.MaxLength = 15;
            this.bbkiem.Name = "bbkiem";
            this.bbkiem.Size = new System.Drawing.Size(87, 21);
            this.bbkiem.TabIndex = 5;
            // 
            // nguoigiao
            // 
            this.nguoigiao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(599, 29);
            this.nguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(186, 21);
            this.nguoigiao.TabIndex = 11;
            this.nguoigiao.Validated += new System.EventHandler(this.nguoigiao_Validated);
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.SystemColors.HighlightText;
            this.no.Enabled = false;
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(323, 52);
            this.no.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(120, 21);
            this.no.TabIndex = 14;
            // 
            // co
            // 
            this.co.BackColor = System.Drawing.SystemColors.HighlightText;
            this.co.Enabled = false;
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(473, 52);
            this.co.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.co.MaxLength = 10;
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(124, 21);
            this.co.TabIndex = 15;
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(599, 52);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(113, 21);
            this.find.TabIndex = 104;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // chkIn
            // 
            this.chkIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIn.Location = new System.Drawing.Point(200, 492);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(112, 16);
            this.chkIn.TabIndex = 105;
            this.chkIn.Text = "Xem trước khi in";
            // 
            // butIndenghi
            // 
            this.butIndenghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIndenghi.Image = global::Duoc.Properties.Resources.VIENPHI;
            this.butIndenghi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIndenghi.Location = new System.Drawing.Point(562, 519);
            this.butIndenghi.Name = "butIndenghi";
            this.butIndenghi.Size = new System.Drawing.Size(117, 25);
            this.butIndenghi.TabIndex = 106;
            this.butIndenghi.Tag = "";
            this.butIndenghi.Text = "Đề nghị thanh toán";
            this.butIndenghi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIndenghi.Click += new System.EventHandler(this.butIndenghi_Click);
            // 
            // lsokhoan
            // 
            this.lsokhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsokhoan.Location = new System.Drawing.Point(8, 487);
            this.lsokhoan.Name = "lsokhoan";
            this.lsokhoan.Size = new System.Drawing.Size(184, 24);
            this.lsokhoan.TabIndex = 109;
            this.lsokhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTimkiem
            // 
            this.cmbTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTimkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimkiem.Items.AddRange(new object[] {
            "Số phiếu",
            "Số hóa đơn",
            "Số phiếu/hoá đơn"});
            this.cmbTimkiem.Location = new System.Drawing.Point(713, 52);
            this.cmbTimkiem.Name = "cmbTimkiem";
            this.cmbTimkiem.Size = new System.Drawing.Size(72, 21);
            this.cmbTimkiem.TabIndex = 103;
            this.cmbTimkiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimkiem_SelectedIndexChanged);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 58);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 428);
            this.dataGrid1.TabIndex = 1007;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // Danhsach
            // 
            this.Danhsach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Danhsach.Controls.Add(this.butCancel);
            this.Danhsach.Controls.Add(this.butOk);
            this.Danhsach.Controls.Add(this.lsophieu);
            this.Danhsach.Controls.Add(this.label13);
            this.Danhsach.Location = new System.Drawing.Point(0, 436);
            this.Danhsach.Name = "Danhsach";
            this.Danhsach.Size = new System.Drawing.Size(192, 80);
            this.Danhsach.TabIndex = 1008;
            this.Danhsach.Visible = false;
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Duoc.Properties.Resources.close_r;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(97, 39);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(28, 39);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // lsophieu
            // 
            this.lsophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lsophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsophieu.Location = new System.Drawing.Point(64, 8);
            this.lsophieu.Name = "lsophieu";
            this.lsophieu.Size = new System.Drawing.Size(120, 21);
            this.lsophieu.TabIndex = 1;
            this.lsophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsophieu_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Số phiếu :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chietkhau
            // 
            this.chietkhau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chietkhau.Enabled = false;
            this.chietkhau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chietkhau.Location = new System.Drawing.Point(504, 29);
            this.chietkhau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chietkhau.MaxLength = 3;
            this.chietkhau.Name = "chietkhau";
            this.chietkhau.Size = new System.Drawing.Size(26, 21);
            this.chietkhau.TabIndex = 10;
            this.chietkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(531, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(8, 23);
            this.label34.TabIndex = 1013;
            this.label34.Text = "%";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(441, 30);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 19);
            this.label33.TabIndex = 1012;
            this.label33.Text = "Chiết khấu :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVAT
            // 
            this.txtVAT.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtVAT.Enabled = false;
            this.txtVAT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.Location = new System.Drawing.Point(410, 29);
            this.txtVAT.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.txtVAT.MaxLength = 3;
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(26, 21);
            this.txtVAT.TabIndex = 9;
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVAT.Validated += new System.EventHandler(this.txtVAT_Validated);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(372, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 19);
            this.label14.TabIndex = 1015;
            this.label14.Text = "VAT:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(438, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(8, 23);
            this.label15.TabIndex = 1016;
            this.label15.Text = "%";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butPrint
            // 
            this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPrint.Image = ((System.Drawing.Image)(resources.GetObject("butPrint.Image")));
            this.butPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPrint.Location = new System.Drawing.Point(113, 519);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(85, 25);
            this.butPrint.TabIndex = 1017;
            this.butPrint.Text = "    &In mã vạch";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // frmNhap_sotien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.chietkhau);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.Danhsach);
            this.Controls.Add(this.cmbTimkiem);
            this.Controls.Add(this.find);
            this.Controls.Add(this.co);
            this.Controls.Add(this.no);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.lsokhoan);
            this.Controls.Add(this.butIndenghi);
            this.Controls.Add(this.chkIn);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.bbkiem);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.cothue);
            this.Controls.Add(this.chuathue);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.ngaykiem);
            this.Controls.Add(this.ngayhd);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhap_sotien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhap_sotien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.Danhsach.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhap_sotien_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            bDmtyleban = d.bDmtyleban(i_nhom);
            bGiamgia = d.bGiamgia(i_nhom);
            stkgiamgia = d.Stkgiamgia(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			cmbTimkiem.SelectedIndex=0;
			chkIn.Checked=d.bPreview;
			bDongia=d.bDongia(i_nhom);
			bSophieu=d.bSophieunhap_tudong(i_nhom);
            bNhapkho_sotien_nhapVAT_1lan=d.bNhapkho_sotien_nhapVAT_1lan(i_nhom);
			bKinhphi=d.bKinhphi(i_nhom);
            bChietkhau = d.bChietkhau(i_nhom);
            bGiaban_noi_ngtru = d.bGiaban_noi_ngtru(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_giaban=d.format_giaban(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bGiaban_nguon=d.bGiaban_nguon(i_nhom);
			bNhom_nx=d.bNhom_nhapxuat(i_nhom);
			i_sole_giaban=d.d_giaban_le(i_nhom);
			i_sole_dongia=d.d_dongia_le(i_nhom);
			bBienban=d.bBbankiemso;
			bNguoigiao=d.bNguoigiao;
			bDinhkhoan=d.bDinhkhoan;
			bQuidoi=d.bQuidoi(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				dtnguon=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			manguon.DataSource=dtnguon;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (s_loai == "M") sql += " and khott=1";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			makho.SelectedIndex=0;

			lsophieu.DisplayMember="SOPHIEU";
			lsophieu.ValueMember="ID";
            dtdmnx = d.get_data("select ma,ten,id,nhomcc,diachi,masothue from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,a.dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,nullif(d.ma,' ') as sotk from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join " + user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom + " order by a.ten").Tables[0];

            sql = "select a.id,a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy') as ngaysp,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd,a.bbkiem,to_char(a.ngaykiem,'dd/mm/yyyy') as ngaykiem,a.nguoigiao,a.madv,a.makho,a.manguon,a.nhomcc,a.no,a.co,a.lydo,a.chietkhau from " + xxx + ".d_nhapll a," + xxx + ".d_nhapslll b ";
			sql+="where a.id=b.id and a.loai='"+s_loai+"'";
			if (!bAdmin) sql+=" and a.userid="+i_userid;
			sql+=" and a.nhom="+i_nhom;
			if (d.bPhieunhap_sophieu(i_nhom)) sql+=" order by a.sophieu";
			else sql+=" order by a.manguon,a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_nhapct.xml");
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,";
            sql+="a.losx,a.soluong,a.dongia,a.vat,a.sotien,round(a.sotien+a.sotien*a.vat/100,"+i_thanhtien_le+") as sotienvat,";
            sql+="a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql+="a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,a.st_ggia,";
            sql += "a.soluong*a.giamua as tongtien";
            sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
			tongcong();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = dtct.TableName;
			ts.AllowSorting=false;
			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bGiaban)?200:230;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 60;
			TextCol.Format=format_soluong;
			TextCol.ReadOnly=true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 100;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bDongia)?false:true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bDongia)?true:false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "vat";
			TextCol.HeaderText = "Thuế";
			TextCol.Width = 30;
			TextCol.Format="##0";
            //TextCol.ReadOnly = (bNhapkho_sotien_nhapVAT_1lan ? true : false);
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "sotienvat";
			TextCol.HeaderText = "Số tiền+Thuế";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.ReadOnly=true;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "tyle";
            TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "% nội trú" : (bGiaban) ? "Tỷ lệ" : "";
			TextCol.Width = (bGiaban)?60:0;
			TextCol.Format="##0.00";
            TextCol.ReadOnly = (bGiaban && !bGiaban_danhmuc) ? false : true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "Giá bán nội trú" : (bGiaban) ? "Giá bán" : "";
			TextCol.Width = (bGiaban)?100:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
            TextCol.ReadOnly = (bGiaban && !bGiaban_danhmuc) ? false : true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 15);
			TextCol.MappingName = "tennuoc";
			TextCol.HeaderText = "Nước";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 16);
			TextCol.MappingName = "sl1";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 17);
			TextCol.MappingName = "sl2";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 18);
			TextCol.MappingName = "giabancu";
			TextCol.HeaderText = (bGiaban)?"Giá bán củ":"";
			TextCol.Width = (bGiaban)?100:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 19);
            TextCol.MappingName = "tyle2";
            TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "% ngoại trú" : "";
            TextCol.Width = (bGiaban) ? 60 : 0;
            TextCol.Format = "##0.00";
            TextCol.ReadOnly = (bGiaban && !bGiaban_danhmuc) ? false : true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 20);
            TextCol.MappingName = "giaban2";
            TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "Giá bán ngoại trú" : "";
            TextCol.Width = (bGiaban) ? 100 : 0;
            TextCol.Format = "###,###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = (bGiaban && !bGiaban_danhmuc) ? false : true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (dataGrid1[row,9].ToString()=="0")?Color.Red:Color.Black;
		}
		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
				}			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
            //if (l_id!=0) return;
			try
			{
                r = d.getrowbyid(dtll, "sophieu='" + sophieu.Text + "'  and id<>" + l_id);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu)
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngaysp"].ToString();
					sohd.Text=r["sohd"].ToString();
					ngayhd.Text=r["ngayhd"].ToString();
					bbkiem.Text=r["bbkiem"].ToString();
					ngaykiem.Text=r["ngaykiem"].ToString();
					nguoigiao.Text=r["nguoigiao"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
                    chietkhau.Text = r["chietkhau"].ToString();
					DataRow r1=d.getrowbyid(dtdmnx,"id="+int.Parse(r["madv"].ToString()));
					if (r1!=null)
					{
						madv.Text=r1["ma"].ToString();
						tendv.Text=r1["ten"].ToString();
					}
					no.Text=r["no"].ToString();
					co.Text=r["co"].ToString();
					s_ngaysp=ngaysp.Text;
					s_ngayhd=ngayhd.Text;
					s_ngaykiem=ngaykiem.Text;
				}
			}
			catch{}
			load_grid();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			cmbTimkiem.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			//if (!bSophieu) sophieu.Enabled=ena;
            if (bChietkhau) chietkhau.Enabled = ena;
			sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			sohd.Enabled=ena;
			ngayhd.Enabled=ena;
			if (bBienban) bbkiem.Enabled=ena;
			ngaykiem.Enabled=bbkiem.Enabled;
			if (bNguoigiao) nguoigiao.Enabled=ena;
			if (d.bQuanlynguon(i_nhom)) manguon.Enabled=ena;
			else manguon.SelectedValue="0";
			if (bDinhkhoan) no.Enabled=ena;
			co.Enabled=no.Enabled;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butIndenghi.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
            if(bNhapkho_sotien_nhapVAT_1lan)txtVAT.Enabled=ena;
            else txtVAT.Enabled=false;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
			}
			dataGrid1.ReadOnly=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List;
            find.Text = "";
            CurrencyManager cm1 = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv1 = (DataView)cm1.List;
            dv1.RowFilter = "";
        }

		private void emp_head()
		{
			l_id=0;
			if (bSophieu) sophieu.Text=d.get_sophieu(s_mmyy,"d_nhapll","sophieu"," where nhom="+i_nhom+" and loai='"+s_loai+"'");
			else sophieu.Text="";
			ngaysp.Text=s_ngay;
			sohd.Text="";
			ngayhd.Text=s_ngay;
			bbkiem.Text="";
			ngaykiem.Text="";
			madv.Text="";
			tendv.Text="";
			nguoigiao.Text="";            
			makho.SelectedIndex=0;
			no.Text="";
			co.Text="";
            chietkhau.Text = "0";
			s_ngaysp=ngaysp.Text;
			s_ngayhd=ngayhd.Text;
			s_ngaykiem=ngaykiem.Text;
			dsxoa.Clear();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}
		
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			emp_head();
			dtct.Clear();
			dtold.Clear();
			if (sophieu.Text!="")
			{
				emp_head();
				dtct.Clear();
			}
			bNew=true;
			manguon_old=0;makho_old=0;
			Danhsach.Visible=true;
			sql="select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,nguoigiao,madv,makho";
            sql += " from " + xxx + ".d_nhapslll where nhom=" + i_nhom + " and loai='" + s_loai + "' and done=0 order by sophieu";
			dtds=d.get_data(sql).Tables[0];
			lsophieu.DataSource=dtds;
			lsophieu.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
            if (d.get_paid("d_nhapll", s_mmyy, l_id))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
				return;
			}
			ena_object(true);
			bNew=false;
			manguon_old=int.Parse(manguon.SelectedValue.ToString());
			makho_old=int.Parse(makho.SelectedValue.ToString());
			dtold=dtct.Copy();
			dsxoa.Clear();
			sophieu.Focus();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (sohd.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số hóa đơn !"),d.Msg);
				sohd.Focus();
				return false;
			}
			if (ngayhd.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày hóa đơn !"),d.Msg);
				ngayhd.Focus();
				return false;
			}
			if (bBienban)
			{
				if ((bbkiem.Text=="" && ngaykiem.Text!="") || (bbkiem.Text!="" && ngaykiem.Text==""))
				{
					if (bbkiem.Text=="")
					{
						MessageBox.Show(
lan.Change_language_MessageText("Nhập biên bản kiểm số !"),d.Msg);
						bbkiem.Focus();
						return false;
					}
					else if (ngaykiem.Text=="")
					{
						MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày biên bản kiểm !"),d.Msg);
						ngaykiem.Focus();
						return false;
					}
				}
			}
			if (d.bQuanlynguon(i_nhom))
			{
				if (manguon.SelectedIndex==-1 || manguon.SelectedValue.ToString()=="0")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nguồn không hợp lệ !"),d.Msg);
					manguon.Focus();
					return false;
				}
			}
			else manguon.SelectedValue="0";

			if (makho.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				makho.Focus();
				return false;
			}
			if (madv.Text=="" && tendv.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
				madv.Focus();
				return false;
			}
			if ((madv.Text!="" && tendv.Text=="") || (madv.Text=="" && tendv.Text!=""))
			{
				if (madv.Text=="")
				{
					madv.Focus();
					return false;
				}
				else if (tendv.Text=="")
				{
					tendv.Focus();
					return false;
				}
			}
			i_madv=0;
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
				madv.Focus();
				return false;
			}
			i_madv=int.Parse(r["id"].ToString());
            if (d.bQuanlynhomcc(i_nhom)) i_nhomcc = i_madv;//i_nhomcc=int.Parse(r["nhomcc"].ToString());
            else i_nhomcc=0;
            if (bDinhkhoan)
			{
				if ((no.Text=="" && co.Text!="") || (no.Text!="" && co.Text==""))
				{
					if (no.Text=="")
					{
						no.Focus();
						return false;
					}
					else if (co.Text=="")
					{
						co.Focus();
						return false;
					}
				}
			}
			if (!bNew)
			{
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtct.Rows)
					{
						i_mabd=d.get_iXuat(s_mmyy,makho_old,l_id,int.Parse(r1["stt"].ToString()));
						if (i_mabd!=0)
						{
							r=d.getrowbyid(dtdmbd,"id="+i_mabd);
							if (r!=null)
							{
								MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép chỉnh sửa !",d.Msg);
								return false;
							}
						}
					}
				}
			}
			return true;
		}

        private void upd_dtct()
        {
            dtct.AcceptChanges();
            decimal vat, tl, sl, dg, st, d_giamua, gb,tl2,gb2;
            foreach (DataRow r in dtct.Rows)
            {
                dg = decimal.Parse(r["dongia"].ToString()); st = decimal.Parse(r["sotien"].ToString());
                vat = decimal.Parse(r["vat"].ToString());
                sl = decimal.Parse(r["soluong"].ToString());
                d_sotien = st; d_dongia = dg; tl = 0; gb = 0;
                if (bDongia || s_loai == "T") d_sotien = d.Round(sl * dg, i_thanhtien_le);
                else d_dongia = d.Round(st / sl, 10);
                d_sotienvat = d.Round(d_sotien + d_sotien * vat / 100, i_thanhtien_le);
                d_giamua = d.Round((d_sotien + d_sotien * vat / 100) / sl, 10);
                if (!bGiaban_danhmuc)
                {
                    if (bGiaban)
                    {
                        tl = (r["tyle"].ToString() == "") ? 0 : decimal.Parse(r["tyle"].ToString());
                        gb = decimal.Parse(r["giaban"].ToString());
                        if (tl > 0) gb = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl / 100, i_sole_giaban);
                        else if (d_sotienvat > 0) tl = (gb / (d_sotienvat / sl) - 1) * 100;
                        tl2 = (r["tyle2"].ToString() == "") ? 0 : decimal.Parse(r["tyle2"].ToString());
                        gb2 = decimal.Parse(r["giaban2"].ToString());
                        if (tl2 > 0) gb2 = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl2 / 100, i_sole_giaban);
                        else if (d_sotienvat > 0) tl2 = (gb2 / (d_sotienvat / sl) - 1) * 100;
                        if (tl2 == 0) tl2 = tl;
                        if (gb2 == 0) gb2 = gb;
                    }
                    else
                    {
                        gb = d_giamua;
                        gb2 = gb;
                        if (d_sotienvat != 0) tl2 = (gb2 / (d_sotienvat / sl) - 1) * 100;
                        else tl2 = 0;
                    }
                }
                else
                {
                    gb = decimal.Parse(r["giaban"].ToString());
                    if (d_sotienvat > 0) tl = (gb / (d_sotienvat / sl) - 1) * 100;
                    gb2 = gb;
                    tl2 = tl;
                }
                r["dongia"] = d_dongia;
                r["sotien"] = d_sotien;
                r["vat"] = vat;
                r["sotienvat"] = d_sotienvat;
                r["tyle"] = tl;
                r["giaban"] = gb;
                r["tyle2"] = tl2;
                r["giaban2"] = gb2;
                r["giamua"] = d_giamua;
            }
            tongcong();
        }

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            upd_dtct();
			dtct.AcceptChanges();
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
			//l_id=(bNew)?d.get_id_nhap:l_id;
            itable = d.tableid(s_mmyy, "d_nhapll");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + sohd.Text + "^" + ngayhd.Text + "^" + bbkiem.Text + "^" + ngaykiem.Text + "^" + s_loai + "^" + nguoigiao.Text + "^" + i_madv.ToString() + "^" + makho.SelectedValue.ToString() + "^" + manguon.SelectedValue.ToString() + "^" + i_nhomcc.ToString() + "^" + no.Text + "^" + co.Text + "^" + i_userid.ToString() + "^" + "0");
            }
			if (!d.upd_nhapll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,s_loai,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),i_nhomcc,no.Text,co.Text,i_userid,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "d_nhapct");
			if (!bNew)
			{
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtold.Rows)
					{
                        d.execute_data("delete from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                            if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100, i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
						}
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), makho_old, manguon_old, i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
					}
					dtold.Clear();
				}
                foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                }
				foreach(DataRow r1 in dtold.Rows)
				{
					if (s_loai=="M" && bKinhphi)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                        if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100, i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
					}
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
				}
			}
            else d.execute_data("update " + xxx + ".d_nhapslll set done=1 where id=" + l_id);
			foreach(DataRow r1 in dtct.Rows)
			{
                if (d.get_data("select * from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["handung"].ToString() + "^" + r1["losx"].ToString() + "^" + r1["vat"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["dongia"].ToString() + "^" + r1["sotien"].ToString() + "^" + r1["giaban"].ToString() + "^" + r1["giamua"].ToString() + "^" + r1["sl1"].ToString() + "^" + r1["sl2"].ToString() + "^" + r1["tyle"].ToString() + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + r1["giabancu"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                d.upd_nhapct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString().Trim().PadLeft(4, '0'), r1["losx"].ToString(), int.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, "", "", 0, 0, 0, "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()),"");
				if (s_loai=="M" && bKinhphi)
				{
					r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
					if (r!=null) d.upd_kinhphi_sd(i_nhom,s_mmyy.Substring(2,2),int.Parse(r["manhom"].ToString()),d.Round(decimal.Parse(r1["sotien"].ToString())+decimal.Parse(r1["sotien"].ToString())*decimal.Parse(r1["vat"].ToString())/100,i_thanhtien_le));
				}
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
			}
            d.updrec_nhapll(dtll, l_id, sophieu.Text, ngaysp.Text, sohd.Text, ngayhd.Text, bbkiem.Text, ngaykiem.Text, nguoigiao.Text, i_madv, int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), no.Text, co.Text, 0, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
                if (!bNew)
                {
                    cmbSophieu.SelectedValue = l_id.ToString();
                    load_head();
                }
			}
			catch{}
			tongcong();
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			cmbSophieu.SelectedIndex=i_old;
			try
			{
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
            if (ngaysp.Text.Length == 6) ngaysp.Text = ngaysp.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
		}

		private void ngayhd_Validated(object sender, System.EventArgs e)
		{
			if (ngayhd.Text=="") return;
			ngayhd.Text=ngayhd.Text.Trim();
            if (ngayhd.Text.Length == 6) ngayhd.Text = ngayhd.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngayhd.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngayhd.Focus();
				return;
			}
			ngayhd.Text=d.Ktngaygio(ngayhd.Text,10);
			if (ngayhd.Text!=s_ngayhd)
			{
				if (!d.ngay(d.StringToDate(ngayhd.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngayhd.Focus();
					return;
				}
			}
		}

		private void ngaykiem_Validated(object sender, System.EventArgs e)
		{
			if (ngaykiem.Text=="") return;
			ngaykiem.Text=ngaykiem.Text.Trim();
            if (ngaykiem.Text.Length == 6) ngaykiem.Text = ngaykiem.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaykiem.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaykiem.Focus();
				return;
			}
			ngaykiem.Text=d.Ktngaygio(ngaykiem.Text,10);
			if (ngaykiem.Text!=s_ngaykiem)
			{
				if (!d.ngay(d.StringToDate(ngaykiem.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaykiem.Focus();
					return;
				}
			}
		}

		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (manguon.SelectedIndex==-1) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
			}
		}


		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (((dataGrid1.CurrentCell.ColumnNumber>7 && dataGrid1.CurrentCell.ColumnNumber<14) || dataGrid1.CurrentCell.ColumnNumber==19 || dataGrid1.CurrentCell.ColumnNumber==20) && i_row<dtct.Rows.Count)
                    upd_rec(int.Parse(dataGrid1[i_row, 0].ToString()), decimal.Parse(dataGrid1[i_row, 7].ToString()), decimal.Parse(dataGrid1[i_row, 8].ToString()), decimal.Parse(dataGrid1[i_row, 9].ToString()), decimal.Parse(dataGrid1[i_row, 10].ToString()), decimal.Parse(dataGrid1[i_row, 12].ToString()), decimal.Parse(dataGrid1[i_row, 13].ToString()), dataGrid1.CurrentCell.ColumnNumber, decimal.Parse(dataGrid1[i_row, 19].ToString()), decimal.Parse(dataGrid1[i_row, 20].ToString()));
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch{}
		}

		private void upd_rec(int stt,decimal sl,decimal dg,decimal st,decimal at,decimal tl,decimal gb,int pos,decimal tl2,decimal gb2)
		{
			DataRow [] dr=dtct.Select("stt="+stt);
			if (dr.Length>0)
			{
				d_dongia=dg;d_sotien=st;
				if (bDongia || s_loai=="T") d_sotien=d.Round(sl*dg,i_thanhtien_le);
				else d_dongia=d.Round(st/sl,10);
				d_sotienvat=d.Round(d_sotien+d_sotien*at/100,i_thanhtien_le);
                if (!bGiaban_danhmuc && !bDmtyleban)
                {
                    if (pos == 12) gb = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl / 100, i_sole_giaban);
                    else if (pos == 13) tl = (gb / (d_sotienvat / sl) - 1) * 100;
                    else if (pos == 19) gb2 = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl2 / 100, i_sole_giaban);
                    else if (pos == 20) tl2 = (gb2 / (d_sotienvat / sl) - 1) * 100;
                }
                if (bDmtyleban)
                {
                    if (pos == 8)
                    {
                        tl = d.get_tyleban(d_sotien / sl,i_nhom);
                        gb = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl / 100, i_sole_giaban);
                    }
                }
				decimal d_giamua=d.Round((d_sotien+d_sotien*at/100)/sl,10);
				dr[0]["dongia"]=d_dongia;
				dr[0]["sotien"]=d_sotien;
				dr[0]["vat"]=at;
				dr[0]["sotienvat"]=d_sotienvat;
				dr[0]["tyle"]=tl;
				dr[0]["giaban"]=gb;
                dr[0]["tyle2"] = tl2;
                dr[0]["giaban2"] = gb2;
				dr[0]["giamua"]=d_giamua;
			}
			tongcong();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                if (d.get_paid("d_nhapll", s_mmyy, l_id))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
					return;
				}
				foreach(DataRow r1 in dtct.Rows)
				{
					i_mabd=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(r1["stt"].ToString()));
					if (i_mabd!=0)
					{
						r=d.getrowbyid(dtdmbd,"id="+i_mabd);
						if (r!=null)
						{
							MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép hủy !",d.Msg);
							return;
						}
					}
				}
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "d_nhapct");
					foreach(DataRow r1 in dtct.Rows)
					{
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
							if (r!=null) d.execute_data("update "+user+".d_kinhphi set dasudung=dasudung-"+d.Round(decimal.Parse(r1["sotien"].ToString())+decimal.Parse(r1["sotien"].ToString())*decimal.Parse(r1["vat"].ToString())/100,i_thanhtien_le)+" where nhom="+i_nhom+" and yy='"+s_mmyy.Substring(2,2)+"' and id_nhom="+int.Parse(r["manhom"].ToString()));
						}
					}
                    itable = d.tableid(s_mmyy, "d_nhapll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapll", "id=" + l_id));
					d.execute_data("update " + xxx + ".d_nhapslll set done=0 where id="+l_id);
                    d.execute_data("delete " + xxx + ".from d_nhapct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_thanhtoan where id=" + l_id);
                    d.execute_data("delete " + xxx + ".from d_nhapll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void nguoigiao_Validated(object sender, System.EventArgs e)
		{
			SendKeys.Send("{F4}");
		}

		private void tongcong()
		{
			try
			{
				d_chuathue=0;
				d_cothue=0;
				foreach(DataRow r1 in dtct.Rows)
				{
					d_sotien=decimal.Parse(r1["sotien"].ToString());
					d_chuathue+=d_sotien;
					d_cothue+=d.Round(d_sotien+d_sotien*int.Parse(r1["vat"].ToString())/100,i_thanhtien_le);
				}
				chuathue.Text=d_chuathue.ToString(format_sotien);
				cothue.Text=d_cothue.ToString(format_sotien);
			}
			catch{}
		}

		private void sohd_Validated(object sender, System.EventArgs e)
		{
            //if (l_id!=0) return;
			try
			{
                r = d.getrowbyid(dtll, "sohd='" + sohd.Text + "'  and id<>" + l_id);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số hóa đơn đã nhập !"),d.Msg);
					sohd.Focus();
				}
			}
			catch{}		
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{	
			if (dtct.Rows.Count==0) return;
			DataTable dttmp=dtct.Copy();
			if (bNhom_nx && d.Mabv_so!=701424)
			{
				sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,round(a.sotien+a.sotien*a.vat/100,"+i_thanhtien_le+") as sotienvat,a.giaban,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,b.manhom,e.ten as tennhom,f.ten as noingoai,f.stt as sttnn ";
                sql+= " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnhom e," + user + ".d_nhomhang f ";
				sql+=" where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and b.manhom=e.id and c.loai=f.id(+) and a.id="+l_id;
				if (d.bInHangNuoc_Nhapxuat(i_nhom)) sql+=" order by f.stt,e.stt,a.stt";
				else sql+=" order by e.stt,a.stt";
				dttmp=d.get_data(sql).Tables[0];
			}
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			string _dc=r["diachi"].ToString().Trim(),_maso=r["masothue"].ToString().Trim();
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
				madv.Focus();
				return;
			}
			string tenfile=(d.Mabv_so==701424)?"d_phieunhap.rpt":(d.bInHangNuoc_Nhapxuat(i_nhom))?"d_phieunhap_ct_nhom.rpt":(bNhom_nx)?"d_phieunhap_nhom.rpt":"d_phieunhap.rpt";
			if (chkIn.Checked)
			{
				frmReport f=new frmReport(d,dttmp,i_userid, tenfile,cmbSophieu.Text,ngaysp.Text,no.Text,co.Text,nguoigiao.Text,sohd.Text,ngayhd.Text,tendv.Text,makho.Text,doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()),_dc,_maso);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+tenfile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dttmp);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+no.Text+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+co.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+nguoigiao.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+sohd.Text+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+ngayhd.Text+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+tendv.Text+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+makho.Text+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString())+"'";
				if (_dc!="") oRpt.DataDefinition.FormulaFields["c11"].Text="'"+_dc+"'";
				if (_maso!="") oRpt.DataDefinition.FormulaFields["c12"].Text="'"+_maso+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				//oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				if (d.bPrintDialog)
				{
					result=Thongso();
					if (result==DialogResult.OK)
					{
						oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
						oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
					}
				}
				else oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==manguon)
				if (bGiaban_nguon && butLuu.Enabled && manguon.SelectedIndex!=-1)
					bGiaban=dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString()=="1";
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				if (cmbTimkiem.SelectedIndex==0)sql="sophieu like '%"+text.Trim()+"%'";
				else if (cmbTimkiem.SelectedIndex==1)sql="sohd like '%"+text+"%'";
				else sql="sophieu like '%"+text.Trim()+"%' or sohd like '%"+text+"%'";
				dv.RowFilter=sql;
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void butIndenghi_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			frmDenghi f1=new frmDenghi();
			f1.ShowDialog(this);
			if (!f1.ok) return;
			DataSet dsxml=new DataSet();
			DataSet dsdn=new DataSet();
			dsxml.ReadXml("..\\..\\..\\xml\\d_denghi.xml");
			dsdn.ReadXml("..\\..\\..\\xml\\d_denghict.xml");
			r=dsdn.Tables[0].NewRow();
			r["sohd"]=sohd.Text;
			r["ngayhd"]=ngayhd.Text;
			r["sophieu"]=sophieu.Text;
			r["ngaysp"]=ngaysp.Text;
			r["sotien"]=d_cothue;
			dsdn.Tables[0].Rows.Add(r);
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			string _dc=r["diachi"].ToString().Trim(),_maso=r["masothue"].ToString().Trim();
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
				madv.Focus();
				return;
			}
			if (chkIn.Checked)
			{
				frmReport f=new frmReport(d,dsdn.Tables[0], i_userid,"d_denghi.rpt",dsxml.Tables[0].Rows[0]["KINHGUI"].ToString(),dsxml.Tables[0].Rows[0]["NGAY"].ToString(),dsxml.Tables[0].Rows[0]["DENGHI"].ToString(),dsxml.Tables[0].Rows[0]["BOPHAN"].ToString(),dsxml.Tables[0].Rows[0]["NOIDUNG"].ToString().Trim()+" "+tendv.Text.ToString().Trim().ToUpper(),dsxml.Tables[0].Rows[0]["KETOAN"].ToString(),dsxml.Tables[0].Rows[0]["GIAMDOC"].ToString(),no.Text,co.Text,doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()),_dc,_maso);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_denghi.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dsdn.Tables[0]);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+dsxml.Tables[0].Rows[0]["KINHGUI"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+dsxml.Tables[0].Rows[0]["NGAY"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+dsxml.Tables[0].Rows[0]["DENGHI"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+dsxml.Tables[0].Rows[0]["BOPHAN"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+dsxml.Tables[0].Rows[0]["NOIDUNG"].ToString().Trim()+" "+tendv.Text.ToString().Trim().ToUpper()+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dsxml.Tables[0].Rows[0]["KETOAN"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+dsxml.Tables[0].Rows[0]["GIAMDOC"].ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+no.Text+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+co.Text+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString())+"'";
				if (_dc!="") oRpt.DataDefinition.FormulaFields["c11"].Text="'"+_dc+"'";
				if (_maso!="") oRpt.DataDefinition.FormulaFields["c12"].Text="'"+_maso+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				if (d.bPrintDialog)
				{
					result=Thongso();
					if (result==DialogResult.OK)
					{
						oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
						oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
					}
				}
				else oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}

		private void cmbTimkiem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbTimkiem && find.Text!="") RefreshChildren(find.Text);
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (lsophieu.SelectedIndex!=-1)
			{
				l_id=decimal.Parse(lsophieu.SelectedValue.ToString());
				r=d.getrowbyid(dtds,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngaysp"].ToString();
					sohd.Text=r["sohd"].ToString();
					ngayhd.Text=r["ngayhd"].ToString();
					nguoigiao.Text=r["nguoigiao"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					DataRow r2=d.getrowbyid(dtdmnx,"id="+int.Parse(r["madv"].ToString()));
					if (r2!=null)
					{
						madv.Text=r2["ma"].ToString();
						tendv.Text=r2["ten"].ToString();
					}
					s_ngaysp=ngaysp.Text;
					s_ngayhd=ngayhd.Text;
				}
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,a.soluong,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,b.giaban as giabancu, b.dongia as giamuacu,b.giaban2,case when b.dongia=0 then 0 else (b.giaban2 / b.dongia - 1) * 100 end as tyle2,b.giaban,case when b.dongia=0 then 0 else (b.giaban / b.dongia - 1) * 100 end as tyle,0 as tyle_ggia,0 as st_ggia ";
                sql += " from " + xxx + ".d_nhapslct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
				foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    d.updrec_nhapct(dtct, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["ma"].ToString(), r1["ten"].ToString(), 
                        r1["tenhc"].ToString(), r1["dang"].ToString(), r1["handung"].ToString().Trim().PadLeft(4, '0'), r1["losx"].ToString(),
                        decimal.Parse(r1["soluong"].ToString()), 0, 0, 0, 0,decimal.Parse(r1["giaban"].ToString()), 0, decimal.Parse(r1["sl1"].ToString()), 
                        decimal.Parse(r1["sl2"].ToString()),decimal.Parse(r1["tyle"].ToString()), 0, 0, 0, "", 0, 0, 0, "",
                        decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()),
                        decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()),0);
			}
			Danhsach.Visible=false;
			dataGrid1.Focus();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			Danhsach.Visible=false;
		}

		private void lsophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void txtVAT_Validated(object sender, EventArgs e)
        {
            if(txtVAT.Text.Trim()!="")
            {
                upd_dtct();
               
            }
            dtct.AcceptChanges();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (dtct.Rows.Count == 0) return;
            DataTable dttmp;
            if (bNhom_nx && d.Mabv_so != 701424)
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,";
                sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ")+a.cuocvc+a.chaythu as sotienvat,";
                sql += " a.giaban,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,b.manhom,e.ten as tennhom,f.ten as noingoai,f.stt as sttnn ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ", a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem, to_char(aa.id) as idnhap, to_char(i.stt) as sttt ";
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnhom e," + user + ".d_nhomhang f," + user + ".d_dmnx g ";
                sql += " ," + xxx + ".d_tonkhoct i, " + xxx + ".d_theodoi j ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and b.manhom=e.id and c.loai=f.id(+) and aa.madv=g.id";
                sql += " and a.id=i.idn and a.stt=i.sttn and i.stt=j.id ";
                sql += "  and a.id=" + l_id;
                if (d.bInHangNuoc_Nhapxuat(i_nhom)) sql += " order by f.stt,e.stt,a.stt";
                else sql += " order by e.stt,a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,";
                sql += " round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,";
                sql += " a.soluong*a.giamua as sotienvat ";
                sql += ", aa.madv, g.ten tennhacc, g.masothue, g.sotk, g.diachi ";
                sql += ",a.dongia as giatruocVAT,a.sotien tongtientruocVAT,a.giamua as dongiasauVAT,round(a.soluong*a.giamua,2) as tongtiensauVAT,aa.no,aa.co,aa.loai ";//gam 21-03-2011
                sql += ", aa.bbkiem, to_char(aa.ngaykiem,'dd/mm/yyyy') as ngaykiem , to_char(aa.id) as idnhap, to_char(i.stt) as sttt ";
                sql += " from " + xxx + ".d_nhapll aa," + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnx g ";
                sql += " ," + xxx + ".d_tonkhoct i, " + xxx + ".d_theodoi j ";
                sql += " where aa.id=a.id and a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and aa.madv=g.id ";
                sql += " and a.id=i.idn and a.stt=i.sttn and i.stt=j.id ";
                sql += " and a.id=" + l_id + " order by a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            string c11 = no.Text, c12 = co.Text, _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string tenfile = "d_phieunhap_mavach.rpt";
            decimal st = 0;
            if (tenfile == "d_phieunhap.rpt")
            {
                if (c11.IndexOf(",") == -1) c11 += ",";
                string s12 = "NỢ :     ";
                sql = "select c.ma,";
                sql += " sum(a.soluong*a.giamua) as sotienvat ";
                //
                sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id;
                if (bGiamgia) sql += " and a.st_ggia=0 ";
                sql += " group by c.ma";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    if (r1["sotienvat"].ToString() != "")
                    {
                        st = decimal.Parse(r1["sotienvat"].ToString());
                        s12 = s12 + r1["ma"].ToString().Trim() + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                    }
                }
                if (bGiamgia)
                {
                    sql = "select sum(a.soluong*a.giamua) as sotienvat ";
                    sql += " from " + xxx + ".d_nhapct a,";
                    sql += user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                    sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id + " and a.st_ggia<>0";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        if (r1["sotienvat"].ToString() != "")
                        {
                            st = decimal.Parse(r1["sotienvat"].ToString());
                            s12 = s12 + stkgiamgia + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                        }
                    }
                }
                c12 = c12 + "," + s12;
            }
            string _ngay = ngaysp.Text;// +((chonin.SelectedIndex == 5) ? "1" : (chonin.SelectedIndex == 6) ? "2" : "");
            decimal d_tontien = decimal.Parse(cothue.Text);
            //if (chkxml.Checked)
            //{
            //    dttmp.WriteXml("../../dataxml/" + tenfile.Replace(".rpt", ".xml"), XmlWriteMode.WriteSchema);
            //}
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid, tenfile, cmbSophieu.Text, _ngay, c11, c12, nguoigiao.Text, sohd.Text, ngayhd.Text, tendv.Text, makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + ";", doiso.Doiso_Unicode(Convert.ToInt64(d_tontien).ToString()), _dc, _maso);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\" + tenfile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + cmbSophieu.Text + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + _ngay + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c11 + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c12 + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + nguoigiao.Text + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + sohd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + tendv.Text + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + makho.Text.Trim() + ";" + manguon.Text.Trim() + ";" + makho.SelectedValue.ToString() + ";" + manguon.SelectedValue.ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()) + "'";
                if (_dc != "") oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                if (_maso != "") oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }
       
	}
}
