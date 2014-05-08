using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmNhap.
	/// </summary>
	public class frmSuaNhap : System.Windows.Forms.Form
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
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox chuathue;
		private System.Windows.Forms.TextBox cothue;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string user,s_mmyy,xxx,s_ngay,sql,s_loai,s_makho,format_sotien,format_dongia,format_soluong,format_giaban;
		private int i_nhom,i_userid,i_madv,i_nhomcc,i_old,i_sole_giaban,i_sole_dongia,i_row,i_thanhtien_le;
		private decimal l_id,sttt;
		private decimal d_dongia,d_sotien,d_sotienvat,d_chuathue,d_cothue,d_giamua;
        private bool bKhoaso, bGiaban, bNew, bAdmin, bKinhphi, bDongia, bGiaban_danhmuc, bDmtyleban;
		private AccessData d;
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtnguon=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtds=new DataTable();
		private DataTable dtold=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataRow r;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox sohd;
		private MaskedTextBox.MaskedTextBox bbkiem;
		private MaskedTextBox.MaskedTextBox nguoigiao;
		private MaskedTextBox.MaskedTextBox no;
		private MaskedTextBox.MaskedTextBox co;
		private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.Label lsokhoan;
		private System.Windows.Forms.ComboBox cmbTimkiem;
		private System.Windows.Forms.DataGrid dataGrid1;
        private MaskedTextBox.MaskedTextBox chietkhau;
        private Label label34;
        private Label label33;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSuaNhap(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool ban,bool admin)
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
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaNhap));
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
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
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
            this.lsokhoan = new System.Windows.Forms.Label();
            this.cmbTimkiem = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.chietkhau = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(140, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(244, 6);
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
            this.label5.Location = new System.Drawing.Point(-29, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nhà cung cấp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(526, 6);
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
            this.label8.Location = new System.Drawing.Point(534, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Người giao :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(20, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 45;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Kho :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(320, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 23);
            this.label11.TabIndex = 47;
            this.label11.Text = "Nợ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(531, 52);
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
            this.ngaysp.Location = new System.Drawing.Point(184, 6);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
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
            // 
            // tendv
            // 
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(138, 29);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(305, 21);
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
            this.manguon.Size = new System.Drawing.Size(96, 21);
            this.manguon.TabIndex = 10;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(200, 52);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(128, 21);
            this.makho.TabIndex = 11;
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(271, 534);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(72, 25);
            this.butSua.TabIndex = 33;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(343, 534);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(72, 25);
            this.butLuu.TabIndex = 30;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(415, 534);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(72, 25);
            this.butBoqua.TabIndex = 31;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(487, 534);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 36;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Location = new System.Drawing.Point(320, 505);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 23);
            this.label21.TabIndex = 55;
            this.label21.Text = "Tổng cộng chưa thuế :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Location = new System.Drawing.Point(554, 504);
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
            this.chuathue.Location = new System.Drawing.Point(440, 506);
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
            this.cothue.Location = new System.Drawing.Point(672, 506);
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
            this.cmbSophieu.Size = new System.Drawing.Size(83, 21);
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
            this.sophieu.Size = new System.Drawing.Size(83, 21);
            this.sophieu.TabIndex = 1;
            // 
            // sohd
            // 
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(295, 6);
            this.sohd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sohd.MaxLength = 50;
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(148, 21);
            this.sohd.TabIndex = 3;
            // 
            // bbkiem
            // 
            this.bbkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bbkiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bbkiem.Enabled = false;
            this.bbkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbkiem.Location = new System.Drawing.Point(594, 6);
            this.bbkiem.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bbkiem.MaxLength = 15;
            this.bbkiem.Name = "bbkiem";
            this.bbkiem.Size = new System.Drawing.Size(96, 21);
            this.bbkiem.TabIndex = 5;
            // 
            // nguoigiao
            // 
            this.nguoigiao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(594, 29);
            this.nguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(191, 21);
            this.nguoigiao.TabIndex = 9;
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.SystemColors.HighlightText;
            this.no.Enabled = false;
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(352, 52);
            this.no.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(184, 21);
            this.no.TabIndex = 12;
            // 
            // co
            // 
            this.co.BackColor = System.Drawing.SystemColors.HighlightText;
            this.co.Enabled = false;
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(564, 52);
            this.co.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.co.MaxLength = 10;
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(58, 21);
            this.co.TabIndex = 13;
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(624, 52);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(88, 21);
            this.find.TabIndex = 104;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // lsokhoan
            // 
            this.lsokhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsokhoan.Location = new System.Drawing.Point(8, 502);
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
            this.dataGrid1.Size = new System.Drawing.Size(776, 444);
            this.dataGrid1.TabIndex = 1007;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // chietkhau
            // 
            this.chietkhau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chietkhau.Enabled = false;
            this.chietkhau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chietkhau.Location = new System.Drawing.Point(501, 29);
            this.chietkhau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chietkhau.MaxLength = 3;
            this.chietkhau.Name = "chietkhau";
            this.chietkhau.Size = new System.Drawing.Size(26, 21);
            this.chietkhau.TabIndex = 1008;
            this.chietkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(528, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(8, 23);
            this.label34.TabIndex = 1010;
            this.label34.Text = "%";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(438, 30);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 19);
            this.label33.TabIndex = 1009;
            this.label33.Text = "Chiết khấu :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSuaNhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.chietkhau);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
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
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.bbkiem);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.cothue);
            this.Controls.Add(this.chuathue);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
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
            this.Name = "frmSuaNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSuaNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSuaNhap_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            bDmtyleban = d.bDmtyleban(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			cmbTimkiem.SelectedIndex=0;
			bDongia=d.bDongia(i_nhom);
			bKinhphi=d.bKinhphi(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_giaban=d.format_giaban(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			i_sole_giaban=d.d_giaban_le(i_nhom);
			i_sole_dongia=d.d_dongia_le(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
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
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			makho.SelectedIndex=0;

            dtdmnx = d.get_data("select ma,ten,id,nhomcc,diachi,masothue from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,a.dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,d.ma as sotk from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join "+ user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom + " order by a.ten").Tables[0];

			sql="select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,bbkiem,to_char(ngaykiem,'dd/mm/yyyy') as ngaykiem,nguoigiao,madv,makho,manguon,nhomcc,no,co,lydo,chietkhau,loai from "+xxx+".d_nhapll";
            sql += " where nhom=" + i_nhom;
			if (!bAdmin) sql+=" and userid="+i_userid;
			if(s_loai.Trim()!="")sql+=" and loai='"+s_loai+"'";
			if (d.bPhieunhap_sophieu(i_nhom)) sql+=" order by sophieu";
			else sql+=" order by manguon,id";
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
			sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,round(a.sotien+a.sotien*a.vat/100,"+i_thanhtien_le+") as sotienvat,a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu as giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,a.st_ggia ";
			sql+=" from "+xxx+".d_nhapct a,"+user+".d_dmbd b,"+user+".d_dmhang c,"+user+".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id="+l_id+" order by a.stt";
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
			TextCol.HeaderText = (bGiaban)?"Tỷ lệ":"";
			TextCol.Width = (bGiaban)?60:0;
			TextCol.Format="##0.00";
			TextCol.ReadOnly=(bGiaban)?false:true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?100:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bGiaban)?false:true;
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

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butSua.Focus();
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
			sophieu.Visible=ena;
			cmbSophieu.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
			dataGrid1.ReadOnly=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
        }

		
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
            if (d.get_paid("d_nhapll", s_mmyy, l_id))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
				return;
			}
            s_loai = get_loai(dtll, l_id);
			ena_object(true);
			bNew=false;
			dtold=dtct.Copy();
			dsxoa.Clear();
			dataGrid1.Focus();
		}
		private bool KiemtraHead()
		{
			i_madv=0;
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
				madv.Focus();
				return false;
			}
			i_madv=int.Parse(r["id"].ToString());
            if (d.bQuanlynhomcc(i_nhom)) i_nhomcc = i_madv;
            else i_nhomcc = 0;
			return true;
		}

        private void upd_items()
        {
            decimal sl, at;
            foreach (DataRow r in dtct.Rows)
            {
                sl = decimal.Parse(r["soluong"].ToString());
                at = decimal.Parse(r["vat"].ToString());
                d_dongia = decimal.Parse(r["dongia"].ToString());
                d_sotien = decimal.Parse(r["sotien"].ToString());
                if (bDongia) d_sotien = d.Round(sl * d_dongia, i_thanhtien_le);
                else d_dongia = d.Round(d_sotien / sl, 7);
                d_sotienvat = d.Round(d_sotien + d_sotien * at / 100, i_thanhtien_le);
                d_giamua = d.Round((d_sotien + d_sotien * at / 100) / sl, 7);
                r["dongia"] = d_dongia;
                r["giamua"] = d_giamua;
                r["sotien"] = d_sotien;
                r["sotienvat"] = d_sotienvat;
            }
            dtct.AcceptChanges();
        }

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            upd_items();
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
			if (!d.upd_nhapll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,s_loai,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),i_nhomcc,no.Text,co.Text,i_userid,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"),d.Msg);
				return;
			}
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
					d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
				foreach(DataRow r1 in dtold.Rows)
				{
					if (s_loai=="M" && bKinhphi)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
						if (r!=null) d.execute_data("update "+user+".d_kinhphi set dasudung=dasudung-"+d.Round(decimal.Parse(r1["sotien"].ToString())+decimal.Parse(r1["sotien"].ToString())*decimal.Parse(r1["vat"].ToString())/100,i_thanhtien_le)+" where nhom="+i_nhom+" and yy='"+s_mmyy.Substring(2,2)+"' and id_nhom="+int.Parse(r["manhom"].ToString()));
					}
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
				}
			}
			else d.execute_data("update "+xxx+".d_nhapslll set done=1 where id="+l_id);
			Cursor=Cursors.WaitCursor;
			foreach(DataRow r1 in dtct.Rows)
			{
                d.upd_nhapct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString().Trim().PadLeft(4, '0'), r1["losx"].ToString(), int.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, "", "", 0, 0, 0, "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()),"");
				if (s_loai=="M" && bKinhphi)
				{
					r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
					if (r!=null) d.upd_kinhphi_sd(i_nhom,s_mmyy.Substring(2,2),int.Parse(r["manhom"].ToString()),d.Round(decimal.Parse(r1["sotien"].ToString())+decimal.Parse(r1["sotien"].ToString())*decimal.Parse(r1["vat"].ToString())/100,i_thanhtien_le));
				}
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
				if (decimal.Parse(r1["giamuacu"].ToString())!=decimal.Parse(r1["giamua"].ToString()))
				{
					sttt=d.get_stt_tonkho(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(r1["stt"].ToString()));
					if (sttt!=0)
					{
						d_giamua=decimal.Parse(r1["giamua"].ToString());
                        foreach (DataRow r2 in d.get_data("select mmyy from " + user + ".table where substr(mmyy,3,2)||substr(mmyy,1,2)>='" + s_mmyy.Substring(2, 2) + s_mmyy.Substring(0, 2) + "'").Tables[0].Rows)
                        {
                            d.execute_data("update " + user + r2["mmyy"].ToString() + ".d_theodoi set giamua=" + d_giamua + " where id=" + sttt);

                            d.execute_data("update " + user + r2["mmyy"].ToString() + ".d_xuatsdct set giaban=" +
                                d_dongia + " where sttt=" + sttt + " and id in (select id from " + user + 
                                r2["mmyy"].ToString() + ".d_tienthuoc where done=0 and idttrv=0) and mabd=" +
                                r1["mabd"].ToString() + " and id in (select id from " + user + r2["mmyy"].ToString() + ".d_xuatsdll where loai=1 )");//gam 29032012

                            d.execute_data("update " + user + r2["mmyy"].ToString() + ".d_tienthuoc set giaban=" +
                                d_dongia + ",giamua="+d_giamua+" where id in (select a.id from " + user +
                                r2["mmyy"].ToString() + ".d_xuatsdct a inner join " + user + r2["mmyy"].ToString() + 
                                ".d_xuatsdll b on a.id=b.id where a.sttt=" + sttt + " and b.loai=1) and mabd=" +
                                r1["mabd"].ToString() + " and  done=0 and idttrv=0");//gam 29032012
                        }
					}
				}
			}
			Cursor=Cursors.Default;
			d.updrec_nhapll(dtll,l_id,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),no.Text,co.Text,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0);
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
			butSua.Focus();
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
			butSua.Focus();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (dataGrid1.CurrentCell.ColumnNumber>7 && dataGrid1.CurrentCell.ColumnNumber<14 && i_row<dtct.Rows.Count)
					upd_rec(int.Parse(dataGrid1[i_row,0].ToString()),decimal.Parse(dataGrid1[i_row,7].ToString()),decimal.Parse(dataGrid1[i_row,8].ToString()),decimal.Parse(dataGrid1[i_row,9].ToString()),decimal.Parse(dataGrid1[i_row,10].ToString()),decimal.Parse(dataGrid1[i_row,12].ToString()),decimal.Parse(dataGrid1[i_row,13].ToString()),dataGrid1.CurrentCell.ColumnNumber);
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch{}
		}

		private void upd_rec(int stt,decimal sl,decimal dg,decimal st,decimal at,decimal tl,decimal gb,int pos)
		{
			DataRow [] dr=dtct.Select("stt="+stt);
			if (dr.Length>0)
			{
				d_dongia=dg;d_sotien=st;
                if (bDongia) d_sotien = d.Round(sl * dg, i_thanhtien_le);// || s_loai=="T")
				else d_dongia=d.Round(st/sl,10);
                d_sotienvat = d.Round(d_sotien + d_sotien * at / 100, i_thanhtien_le);
                if (bDmtyleban)
                {
                    if (pos == 8)
                    {
                        tl = d.get_tyleban(d_sotien / sl, i_nhom);
                        gb = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl / 100, i_sole_giaban);
                    }
                }
                else
                {
                    if (pos == 12) gb = d.Round(d_sotienvat / sl + d_sotienvat / sl * tl / 100, i_sole_giaban);
                    else if (pos == 13) tl = (gb / (d_sotienvat / sl) - 1) * 100;
                }
				d_giamua=d.Round((d_sotien+d_sotien*at/100)/sl,10);
				dr[0]["dongia"]=d_dongia;
				dr[0]["sotien"]=d_sotien;
				dr[0]["vat"]=at;
				dr[0]["sotienvat"]=d_sotienvat;
				dr[0]["tyle"]=tl;
				dr[0]["giaban"]=gb;
				dr[0]["giamua"]=d_giamua;
			}
			tongcong();
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

		private void cmbTimkiem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbTimkiem && find.Text!="") RefreshChildren(find.Text);
		}
        private string get_loai(DataTable ldt, decimal id)
        {
            string sloai = "M";
            DataRow r = d.getrowbyid(ldt, "id=" + id);
            if (r != null)
                sloai = r["loai"].ToString();
            return sloai;
        }
	}
}
