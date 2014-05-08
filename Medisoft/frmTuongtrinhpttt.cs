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
	/// Summary description for frmTuongtrinhpttt.
	/// </summary>
	public class frmTuongtrinhpttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTen;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox mapt;
		private System.Windows.Forms.TextBox tenpt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string s_makp,sql,user;
        private string s_nhomvp_pttt = "";
		private int i_userid,i_rec;
		private bool bPttt_vp;
		private decimal st;
		private DataTable dtbs=new DataTable();
		private DataTable dtpt=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtmavp=new DataTable();
		private LibList.List listpttt;
		private LibList.List listBS;
		private System.Windows.Forms.ComboBox loaipt;
		private DataSet dsxml=new DataSet();
		private System.Windows.Forms.ComboBox mavp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox sotien;
		private System.Windows.Forms.ComboBox loaivp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox ptv;
		private System.Windows.Forms.TextBox phu1;
		private System.Windows.Forms.TextBox phu2;
		private System.Windows.Forms.TextBox bsgayme;
		private System.Windows.Forms.TextBox hoisuc;
		private System.Windows.Forms.TextBox dungcu;
		private System.Windows.Forms.Button butThuoc;
		private System.Windows.Forms.TextBox ktvgayme;
		private System.Windows.Forms.TextBox sum;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox mapm;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTuongtrinhpttt(AccessData acc,string makp,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_makp=makp;i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuongtrinhpttt));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTen = new System.Windows.Forms.ComboBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mapt = new System.Windows.Forms.TextBox();
            this.tenpt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.noidung = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listpttt = new LibList.List();
            this.listBS = new LibList.List();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.mavp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sotien = new System.Windows.Forms.TextBox();
            this.loaivp = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.sum = new System.Windows.Forms.TextBox();
            this.dungcu = new System.Windows.Forms.TextBox();
            this.hoisuc = new System.Windows.Forms.TextBox();
            this.ktvgayme = new System.Windows.Forms.TextBox();
            this.bsgayme = new System.Windows.Forms.TextBox();
            this.phu2 = new System.Windows.Forms.TextBox();
            this.phu1 = new System.Windows.Forms.TextBox();
            this.ptv = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butThuoc = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.mapm = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên mẫu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTen
            // 
            this.cmbTen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTen.Location = new System.Drawing.Point(112, 26);
            this.cmbTen.Name = "cmbTen";
            this.cmbTen.Size = new System.Drawing.Size(608, 21);
            this.cmbTen.TabIndex = 2;
            this.cmbTen.SelectedIndexChanged += new System.EventHandler(this.cmbTen_SelectedIndexChanged);
            this.cmbTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTen_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(112, 26);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(608, 21);
            this.ten.TabIndex = 3;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapt_KeyDown);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(720, 26);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(64, 21);
            this.ma.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên phẫu thủ thuật :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Enabled = false;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(112, 4);
            this.mapt.MaxLength = 6;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(48, 21);
            this.mapt.TabIndex = 0;
            this.mapt.Validated += new System.EventHandler(this.mapt_Validated);
            this.mapt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapt_KeyDown);
            // 
            // tenpt
            // 
            this.tenpt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpt.Enabled = false;
            this.tenpt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpt.Location = new System.Drawing.Point(161, 4);
            this.tenpt.Name = "tenpt";
            this.tenpt.Size = new System.Drawing.Size(559, 21);
            this.tenpt.TabIndex = 1;
            this.tenpt.Validated += new System.EventHandler(this.tenpt_Validated);
            this.tenpt.TextChanged += new System.EventHandler(this.tenpt_TextChanged);
            this.tenpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Khoa/phòng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(488, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bác sĩ ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(112, 48);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapt_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(535, 48);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(48, 21);
            this.mabs.TabIndex = 6;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(584, 48);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(200, 21);
            this.tenbs.TabIndex = 7;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nội dung :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Enabled = false;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(112, 94);
            this.noidung.Multiline = true;
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(672, 322);
            this.noidung.TabIndex = 10;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(215, 492);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(285, 492);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(355, 492);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(425, 492);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(495, 492);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 16;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(565, 492);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 17;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(635, 492);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(624, 548);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 40;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(512, 548);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 41;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // loaipt
            // 
            this.loaipt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaipt.Enabled = false;
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(720, 4);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(64, 21);
            this.loaipt.TabIndex = 43;
            // 
            // mavp
            // 
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(307, 71);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(386, 21);
            this.mavp.TabIndex = 9;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 45;
            this.label6.Text = "Viện phí :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotien
            // 
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(696, 71);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(88, 21);
            this.sotien.TabIndex = 46;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // loaivp
            // 
            this.loaivp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaivp.Enabled = false;
            this.loaivp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaivp.Location = new System.Drawing.Point(112, 71);
            this.loaivp.Name = "loaivp";
            this.loaivp.Size = new System.Drawing.Size(192, 21);
            this.loaivp.TabIndex = 8;
            this.loaivp.SelectedIndexChanged += new System.EventHandler(this.loaivp_SelectedIndexChanged);
            this.loaivp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.sum);
            this.groupBox1.Controls.Add(this.dungcu);
            this.groupBox1.Controls.Add(this.hoisuc);
            this.groupBox1.Controls.Add(this.ktvgayme);
            this.groupBox1.Controls.Add(this.bsgayme);
            this.groupBox1.Controls.Add(this.phu2);
            this.groupBox1.Controls.Add(this.phu1);
            this.groupBox1.Controls.Add(this.ptv);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(8, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 64);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân chia";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(592, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Tổng cộng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sum
            // 
            this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sum.Enabled = false;
            this.sum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sum.Location = new System.Drawing.Point(666, 34);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(104, 21);
            this.sum.TabIndex = 14;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dungcu
            // 
            this.dungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dungcu.Enabled = false;
            this.dungcu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dungcu.Location = new System.Drawing.Point(476, 34);
            this.dungcu.Name = "dungcu";
            this.dungcu.Size = new System.Drawing.Size(104, 21);
            this.dungcu.TabIndex = 13;
            this.dungcu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dungcu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.dungcu.Validated += new System.EventHandler(this.dungcu_Validated);
            this.dungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // hoisuc
            // 
            this.hoisuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoisuc.Enabled = false;
            this.hoisuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoisuc.Location = new System.Drawing.Point(295, 34);
            this.hoisuc.Name = "hoisuc";
            this.hoisuc.Size = new System.Drawing.Size(104, 21);
            this.hoisuc.TabIndex = 12;
            this.hoisuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hoisuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.hoisuc.Validated += new System.EventHandler(this.hoisuc_Validated);
            this.hoisuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // ktvgayme
            // 
            this.ktvgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ktvgayme.Enabled = false;
            this.ktvgayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktvgayme.Location = new System.Drawing.Point(103, 34);
            this.ktvgayme.Name = "ktvgayme";
            this.ktvgayme.Size = new System.Drawing.Size(104, 21);
            this.ktvgayme.TabIndex = 11;
            this.ktvgayme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ktvgayme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.ktvgayme.Validated += new System.EventHandler(this.ktvgayme_Validated);
            this.ktvgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // bsgayme
            // 
            this.bsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsgayme.Enabled = false;
            this.bsgayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsgayme.Location = new System.Drawing.Point(666, 11);
            this.bsgayme.Name = "bsgayme";
            this.bsgayme.Size = new System.Drawing.Size(104, 21);
            this.bsgayme.TabIndex = 10;
            this.bsgayme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bsgayme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.bsgayme.Validated += new System.EventHandler(this.bsgayme_Validated);
            this.bsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // phu2
            // 
            this.phu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu2.Enabled = false;
            this.phu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu2.Location = new System.Drawing.Point(476, 11);
            this.phu2.Name = "phu2";
            this.phu2.Size = new System.Drawing.Size(104, 21);
            this.phu2.TabIndex = 9;
            this.phu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.phu2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.phu2.Validated += new System.EventHandler(this.phu2_Validated);
            this.phu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // phu1
            // 
            this.phu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu1.Enabled = false;
            this.phu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu1.Location = new System.Drawing.Point(295, 11);
            this.phu1.Name = "phu1";
            this.phu1.Size = new System.Drawing.Size(104, 21);
            this.phu1.TabIndex = 8;
            this.phu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.phu1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.phu1.Validated += new System.EventHandler(this.phu1_Validated);
            this.phu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // ptv
            // 
            this.ptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptv.Enabled = false;
            this.ptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptv.Location = new System.Drawing.Point(103, 11);
            this.ptv.Name = "ptv";
            this.ptv.Size = new System.Drawing.Size(104, 21);
            this.ptv.TabIndex = 7;
            this.ptv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ptv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptv_KeyPress);
            this.ptv.Validated += new System.EventHandler(this.ptv_Validated);
            this.ptv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(416, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "Dụng cụ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(246, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Hồi sức :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(23, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "KTV Gây mê :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(592, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "BS Gây mê :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(397, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Phụ 2 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(213, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Phụ 1 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(23, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "PTV Chính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butThuoc
            // 
            this.butThuoc.Image = ((System.Drawing.Image)(resources.GetObject("butThuoc.Image")));
            this.butThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuoc.Location = new System.Drawing.Point(115, 492);
            this.butThuoc.Name = "butThuoc";
            this.butThuoc.Size = new System.Drawing.Size(100, 25);
            this.butThuoc.TabIndex = 19;
            this.butThuoc.Text = " &Thuốc+vật tư";
            this.butThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThuoc.Click += new System.EventHandler(this.butThuoc_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(304, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 47;
            this.label15.Text = "Phòng mỗ :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapm
            // 
            this.mapm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapm.Enabled = false;
            this.mapm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapm.Location = new System.Drawing.Point(363, 48);
            this.mapm.Name = "mapm";
            this.mapm.Size = new System.Drawing.Size(128, 21);
            this.mapm.TabIndex = 5;
            this.mapm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapt_KeyDown);
            // 
            // frmTuongtrinhpttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.cmbTen);
            this.Controls.Add(this.mapm);
            this.Controls.Add(this.butThuoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loaivp);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tenpt);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTuongtrinhpttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tường trình phẫu thủ thuật";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTuongtrinhpttt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTuongtrinhpttt_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			bPttt_vp=m.bPttt_vienphi;
            s_nhomvp_pttt = m.iNhompttt;
			dsxml.ReadXml("..//..//..//xml//m_pttt.xml");
			sql="select * from "+user+".btdkp_bv";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by loai,makp";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=m.get_data(sql).Tables[0];
	
			mapm.DisplayMember="TEN";
			mapm.ValueMember="MA";
            mapm.DataSource = m.get_data("select * from " + user + ".btdpmo order by ma").Tables[0];

            sql = "select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " and b.id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";  
            dtmavp = m.get_data(sql).Tables[0];//"select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and b.id_nhom=" + m.iNhompttt).Tables[0];


            sql = "select * from " + user + ".v_loaivp ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " where id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";
            sql += " order by stt";

			loaivp.DisplayMember="TEN";
			loaivp.ValueMember="ID";
            loaivp.DataSource = m.get_data(sql).Tables[0];// m.get_data("select * from " + user + ".v_loaivp where id_nhom=" + m.iNhompttt + " order by stt").Tables[0];

			mavp.DisplayMember="TEN";
			mavp.ValueMember="ID";

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ")  order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

			loaipt.DisplayMember="TEN";
			loaipt.ValueMember="MA";
            loaipt.DataSource = m.get_data("select * from " + user + ".loaipttt order by ma").Tables[0];

            dtpt = m.get_data("select MAPT,NOI_DUNG,DACBIET,LOAI1,LOAI2,LOAI3 from " + user + ".dmpttt").Tables[0];
			listpttt.DisplayMember="NOI_DUNG";
			listpttt.ValueMember="NOI_DUNG";
			listpttt.DataSource=dtpt;

            dt = m.get_data("select * from " + user + ".pttt_mau order by substr(ma,1,1),ten").Tables[0];
			cmbTen.DisplayMember="TEN";
			cmbTen.ValueMember="MA";
			cmbTen.DataSource=dt;
			if (dt.Rows.Count>0) load_head(0);
		}

		private void load_head(int i)
		{
			try
			{
				mapt.Text=dt.Rows[i]["mapt"].ToString();
				string s=m.get_tenpt(mapt.Text).Trim();
				if (s!="")
				{
					tenpt.Text=s.Substring(1);
					loaipt.SelectedValue=s.Substring(0,1);
				}
				else tenpt.Text="";
				mabs.Text=dt.Rows[i]["mabs"].ToString();
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r["hoten"].ToString();
				else tenbs.Text="";
				ten.Text=dt.Rows[i]["ten"].ToString();
				ma.Text=dt.Rows[i]["ma"].ToString();
				noidung.Text=dt.Rows[i]["noidung"].ToString();
				makp.SelectedValue=dt.Rows[i]["makp"].ToString();
				if (dt.Rows[i]["mapm"].ToString()!="") mapm.SelectedValue=dt.Rows[i]["mapm"].ToString();
				else mapm.SelectedIndex=-1;
				st=(dt.Rows[i]["ptv"].ToString()!="")?decimal.Parse(dt.Rows[i]["ptv"].ToString()):0;
				ptv.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["phu1"].ToString()!="")?decimal.Parse(dt.Rows[i]["phu1"].ToString()):0;
				phu1.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["phu2"].ToString()!="")?decimal.Parse(dt.Rows[i]["phu2"].ToString()):0;
				phu2.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["bsgayme"].ToString()!="")?decimal.Parse(dt.Rows[i]["bsgayme"].ToString()):0;
				bsgayme.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["ktvgayme"].ToString()!="")?decimal.Parse(dt.Rows[i]["ktvgayme"].ToString()):0;
				ktvgayme.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["hoisuc"].ToString()!="")?decimal.Parse(dt.Rows[i]["hoisuc"].ToString()):0;
				hoisuc.Text=st.ToString("###,###,###,###");
				st=(dt.Rows[i]["dungcu"].ToString()!="")?decimal.Parse(dt.Rows[i]["dungcu"].ToString()):0;
				dungcu.Text=st.ToString("###,###,###,###");
				tinhtong();
				r=m.getrowbyid(dtmavp,"id="+int.Parse(dt.Rows[i]["mavp"].ToString()));
				if (r!=null)
				{
					loaivp.SelectedValue=r["id_loai"].ToString();
					mavp.SelectedValue=dt.Rows[i]["mavp"].ToString();
				}
				else
				{
					loaivp.SelectedIndex=-1;
					mavp.SelectedIndex=-1;
				}
			}
			catch{}
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
				listBS.BrowseToICD10(tenbs,mabs,loaivp,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
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
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_tenpt(mapt.Text).Trim();
			if (s!="")
			{
				tenpt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			else tenpt.Text="";
			if ((tenpt.Text=="" || mapt.Text=="") && !m.bPttt)
			{
                dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, mapt.Text, tenpt.Text, true);
				f.ShowDialog();
				if (f.m_mapt!="")
				{
					tenpt.Text=f.m_tenpt;
					mapt.Text=f.m_mapt;
					loaipt.SelectedValue=f.m_loaipt;
				}
			}		
			ten.Text=tenpt.Text;
		}

		private void mapt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenpt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_mapt(tenpt.Text);
			if (s!="")
			{
				mapt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			if(!listpttt.Focused)listpttt.Hide();
		}

		private void tenpt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenpt_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenpt)
			{
				Filt_pttt(tenpt.Text);
				listpttt.BrowseToText(tenpt,mapt,ten);
			}
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="NOI_DUNG LIKE '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			cmbTen.Visible=!ena;
			mapt.Enabled=ena;
			tenpt.Enabled=ena;
			ten.Enabled=ena;
			makp.Enabled=ena;
			if (m.bPttt_phongmo) mapm.Enabled=ena;
			loaivp.Enabled=ena;
			mavp.Enabled=ena;
			noidung.Enabled=ena;
			ptv.Enabled=ena;
			phu1.Enabled=ena;
			phu2.Enabled=ena;
			bsgayme.Enabled=ena;
			ktvgayme.Enabled=ena;
			hoisuc.Enabled=ena;
			dungcu.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void emp_text()
		{
			mapt.Text="";tenpt.Text="";	ma.Text="";ten.Text="";	noidung.Text="";
			loaivp.SelectedIndex=-1;mavp.SelectedIndex=-1;
			ptv.Text="";phu1.Text="";phu2.Text="";
			bsgayme.Text="";ktvgayme.Text="";hoisuc.Text="";dungcu.Text="";
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			i_rec=cmbTen.SelectedIndex;
			emp_text();
			ena_object(true);
			mapt.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			i_rec=cmbTen.SelectedIndex;
			ena_object(true);
			mapt.Enabled=false;
			tenpt.Enabled=false;
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (!m.Kiemtra_mapt(dtpt,mapt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				mapt.Focus();
				return false;
			}
			if (!m.Kiemtra_tenpt(dtpt,tenpt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				tenpt.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên mẫu !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return false;
			}
			if (bPttt_vp)
			{
				if (mavp.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn giá viện phí !"),LibMedi.AccessData.Msg);
					mavp.Focus();
					return false;
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (ma.Text=="")
			{
				int stt=1;
                DataTable dtma = m.get_data("select max(substr(ma,8,3)) as stt from " + user + ".pttt_mau where mapt='" + mapt.Text + "'").Tables[0];
				if (dtma.Rows[0]["stt"].ToString()!="") stt=int.Parse(dtma.Rows[0]["stt"].ToString())+1;
				ma.Text=mapt.Text.ToString().Trim()+"."+stt.ToString().PadLeft(3,'0');
				ma.Refresh();
			}
			if (!m.upd_pttt_mau(ma.Text,mapt.Text,ten.Text,mabs.Text,(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"",noidung.Text,i_userid,(mavp.SelectedIndex==-1)?0:int.Parse(mavp.SelectedValue.ToString()),(ptv.Text!="")?decimal.Parse(ptv.Text):0,(phu1.Text!="")?decimal.Parse(phu1.Text):0,(phu2.Text!="")?decimal.Parse(phu2.Text):0,(bsgayme.Text!="")?decimal.Parse(bsgayme.Text):0,(ktvgayme.Text!="")?decimal.Parse(ktvgayme.Text):0,(hoisuc.Text!="")?decimal.Parse(hoisuc.Text):0,(dungcu.Text!="")?decimal.Parse(dungcu.Text):0,(mapm.SelectedIndex==-1)?"":mapm.SelectedValue.ToString()))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin mẫu phẫu thủ thuật !"),LibMedi.AccessData.Msg);
				return;
			}
			m.updrec_pttt_mau(dt,ma.Text,mapt.Text,ten.Text,mabs.Text,(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"",noidung.Text,(mavp.SelectedIndex==-1)?0:int.Parse(mavp.SelectedValue.ToString()),(ptv.Text!="")?decimal.Parse(ptv.Text):0,(phu1.Text!="")?decimal.Parse(phu1.Text):0,(phu2.Text!="")?decimal.Parse(phu2.Text):0,(bsgayme.Text!="")?decimal.Parse(bsgayme.Text):0,(ktvgayme.Text!="")?decimal.Parse(ktvgayme.Text):0,(hoisuc.Text!="")?decimal.Parse(hoisuc.Text):0,(dungcu.Text!="")?decimal.Parse(dungcu.Text):0,(mapm.SelectedIndex==-1)?"":mapm.SelectedValue.ToString());
			dt.AcceptChanges();
			load_head(i_rec);
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			load_head(i_rec);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="") return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                if (m.bMmyy(m.mmyy(m.Ngayhienhanh)))
                {
                    if (m.get_data("select id from "+user+m.mmyy(m.Ngayhienhanh)+".pttt where mamau='" + ma.Text + "'").Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tên mẫu đã sử dụng không cho phép hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }
                m.execute_data("delete from " + user + ".pttt_mau where ma='" + ma.Text + "'");
				m.delrec(dt,"ma='"+ma.Text+"'");
				dt.AcceptChanges();
				emp_text();
				load_head(0);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (ten.Text=="") return;
			dsxml.Clear();
			DataRow r;
			r=dsxml.Tables[0].NewRow();
			r["tenpt"]=ten.Text;
			r["loaipt"]=loaipt.Text;
			r["noidung"]=noidung.Text;
			dsxml.Tables[0].Rows.Add(r);
			dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","rptTuongtrinh.rpt");
			f.ShowDialog();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void cmbTen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbTen) load_head(cmbTen.SelectedIndex);
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			ten.Text=tenpt.Text;
            string s = m.get_mapt(tenpt.Text);
            if (s != "")
            {
                mapt.Text = s.Substring(1);
                loaipt.SelectedValue = s.Substring(0, 1);
            }
		}

		private void cmbTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mavp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (mavp.SelectedIndex!=-1) 
			{
				decimal st=decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["gia_th"].ToString())+decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["vattu_th"].ToString());
				sotien.Text=st.ToString("###,###,###,###");
			}
		}

		private void loaivp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (loaivp.SelectedIndex!=-1) load_mavp();
		}
		
		private void load_mavp()
		{
            dtvp = m.get_data("select * from " + user + ".v_giavp where id_loai=" + int.Parse(loaivp.SelectedValue.ToString()) + " order by stt").Tables[0];
			mavp.DataSource=dtvp;
		}

		private void ptv_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void ptv_Validated(object sender, System.EventArgs e)
		{
			if (ptv.Text!="")
			{
				st=decimal.Parse(ptv.Text.ToString());
				ptv.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void phu1_Validated(object sender, System.EventArgs e)
		{
			if (phu1.Text!="")
			{
				st=decimal.Parse(phu1.Text.ToString());
				phu1.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void phu2_Validated(object sender, System.EventArgs e)
		{
			if (phu2.Text!="")
			{
				st=decimal.Parse(phu2.Text.ToString());
				phu2.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void bsgayme_Validated(object sender, System.EventArgs e)
		{
			if (bsgayme.Text!="")
			{
				st=decimal.Parse(bsgayme.Text.ToString());
				bsgayme.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void ktvgayme_Validated(object sender, System.EventArgs e)
		{
			if (ktvgayme.Text!="")
			{
				st=decimal.Parse(ktvgayme.Text.ToString());
				ktvgayme.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void hoisuc_Validated(object sender, System.EventArgs e)
		{
			if (hoisuc.Text!="")
			{
				st=decimal.Parse(hoisuc.Text.ToString());
				hoisuc.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void dungcu_Validated(object sender, System.EventArgs e)
		{
			if (dungcu.Text!="")
			{
				st=decimal.Parse(dungcu.Text.ToString());
				dungcu.Text=st.ToString("###,###,###,###");
				tinhtong();
			}
		}

		private void tinhtong()
		{
			st=(ptv.Text!="")?decimal.Parse(ptv.Text.ToString()):0;
			st+=(phu1.Text!="")?decimal.Parse(phu1.Text.ToString()):0;
			st+=(phu2.Text!="")?decimal.Parse(phu2.Text.ToString()):0;
			st+=(bsgayme.Text!="")?decimal.Parse(bsgayme.Text.ToString()):0;
			st+=(ktvgayme.Text!="")?decimal.Parse(ktvgayme.Text.ToString()):0;
			st+=(hoisuc.Text!="")?decimal.Parse(hoisuc.Text.ToString()):0;
			st+=(dungcu.Text!="")?decimal.Parse(dungcu.Text.ToString()):0;
			sum.Text=st.ToString("###,###,###,###");
		}

		private void butThuoc_Click(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				frmTT_pttt_thuoc f=new frmTT_pttt_thuoc(m.nhom_duoc,ma.Text,(butLuu.Enabled)?cmbTen.Text:ten.Text);
				f.ShowDialog(this);
			}
		}
	}
}

