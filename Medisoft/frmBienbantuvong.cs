using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmBienbantuvong : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtmabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttuoi;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtngay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox chandoan;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbonguyennhan;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string user,m_mabn,m_hoten,m_tuoivao,m_ngay,s_msg,m_loaituoi,s_maicd,s_mabs="",s_ngaynhan,s_ngaymo;
        private string s_diachi = "",s_makp="";
		private int m_userid,songay,i_chinhanh=0,i_phai=0;
		private decimal m_maql;
        private System.Windows.Forms.TextBox txtdiachi;
		private LibList.List listICD;
        private DataTable dticd = new DataTable();
        private DataTable dtbs = new DataTable();
        private TextBox txtgioitinh;
        private Label label12;
        private TextBox txthotennguoidua;
        private Label label13;
        private Label label14;
        private TextBox txttuoinguoidua;
        private Label label15;
        private ComboBox cbogioitinh;
        private TextBox txtdiachinguoidua;
        private Label label16;
        private TextBox txtcmnd;
        private Label label17;
        private Label label18;
        private TextBox txtquanhe;
        private TextBox txtphuongtien;
        private Label label19;
        private TextBox txtsoxe;
        private Label label20;
        private TextBox txttinhtrang;
        private Label label21;
        private TextBox txtdaxuly;
        private Label label22;
        private TextBox txtykien;
        private Label label23;
        private Label label24;
        private TextBox txttien;
        private CheckBox chktien;
        private CheckBox chktutrang;
        private TextBox txttutrang;
        private TextBox txtcongan;
        private Label label25;
        private TextBox txttenbs;
        private MaskedTextBox.MaskedTextBox txtmabs;
        private Label label8;
        private TextBox txttendd;
        private MaskedTextBox.MaskedTextBox txtmadd;
        private Label label9;
        private Button butin;
        private LibList.List listBS;
        private TextBox txtnguoithan;
        private Label label10;
        private CheckBox chkxml;
		private System.ComponentModel.Container components = null;
        #endregion

        public frmBienbantuvong(AccessData acc,string mabn,string hoten,string tuoivao,string ngay,string diachi,decimal maql,int userid,int _chinhanh,string _makp,int _phai)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;m_mabn=mabn;m_hoten=hoten;m_tuoivao=tuoivao;
			m_ngay=ngay;s_diachi=diachi;m_userid=userid;m_maql=maql;
            s_makp = _makp; i_chinhanh = _chinhanh; i_phai = _phai;
            if (m.bBogo) tv.GanBogo(this, textBox111);
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBienbantuvong));
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtmabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txttuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtngay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbonguyennhan = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listICD = new LibList.List();
            this.txtgioitinh = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txthotennguoidua = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txttuoinguoidua = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbogioitinh = new System.Windows.Forms.ComboBox();
            this.txtdiachinguoidua = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtcmnd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtquanhe = new System.Windows.Forms.TextBox();
            this.txtphuongtien = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtsoxe = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txttinhtrang = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtdaxuly = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtykien = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txttien = new System.Windows.Forms.TextBox();
            this.chktien = new System.Windows.Forms.CheckBox();
            this.chktutrang = new System.Windows.Forms.CheckBox();
            this.txttutrang = new System.Windows.Forms.TextBox();
            this.txtcongan = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txttenbs = new System.Windows.Forms.TextBox();
            this.txtmabs = new MaskedTextBox.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttendd = new System.Windows.Forms.TextBox();
            this.txtmadd = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butin = new System.Windows.Forms.Button();
            this.listBS = new LibList.List();
            this.txtnguoithan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txthoten
            // 
            this.txthoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txthoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txthoten.Enabled = false;
            this.txthoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(281, 6);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(152, 21);
            this.txthoten.TabIndex = 1;
            this.txthoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // txtmabn
            // 
            this.txtmabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabn.Enabled = false;
            this.txtmabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabn.Location = new System.Drawing.Point(136, 6);
            this.txtmabn.MaxLength = 10;
            this.txtmabn.Name = "txtmabn";
            this.txtmabn.Size = new System.Drawing.Size(73, 21);
            this.txtmabn.TabIndex = 0;
            this.txtmabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(227, 6);
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
            // txttuoi
            // 
            this.txttuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttuoi.Enabled = false;
            this.txttuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttuoi.Location = new System.Drawing.Point(486, 6);
            this.txttuoi.Name = "txttuoi";
            this.txttuoi.Size = new System.Drawing.Size(47, 21);
            this.txttuoi.TabIndex = 2;
            this.txttuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(437, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtngay
            // 
            this.txtngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtngay.Enabled = false;
            this.txtngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtngay.Location = new System.Drawing.Point(136, 29);
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(96, 21);
            this.txtngay.TabIndex = 4;
            this.txtngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
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
            // txtdiachi
            // 
            this.txtdiachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdiachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdiachi.Enabled = false;
            this.txtdiachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachi.Location = new System.Drawing.Point(281, 29);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(388, 21);
            this.txtdiachi.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(237, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(195, 213);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(474, 21);
            this.chandoan.TabIndex = 18;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.Validated += new System.EventHandler(this.chandoan_Validated);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(136, 213);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(56, 21);
            this.maicd.TabIndex = 17;
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            this.maicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Chẩn đoán :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(56, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nguyên nhân :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbonguyennhan
            // 
            this.cbonguyennhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbonguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbonguyennhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbonguyennhan.Enabled = false;
            this.cbonguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbonguyennhan.Location = new System.Drawing.Point(136, 52);
            this.cbonguyennhan.Name = "cbonguyennhan";
            this.cbonguyennhan.Size = new System.Drawing.Size(533, 21);
            this.cbonguyennhan.TabIndex = 6;
            this.cbonguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbonguyennhan_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(321, 510);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 30;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(391, 510);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 28;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(461, 510);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 29;
            this.butBoqua.Text = " &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(601, 510);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 32;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(40, 518);
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
            // txtgioitinh
            // 
            this.txtgioitinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgioitinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtgioitinh.Enabled = false;
            this.txtgioitinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgioitinh.Location = new System.Drawing.Point(588, 6);
            this.txtgioitinh.Name = "txtgioitinh";
            this.txtgioitinh.Size = new System.Drawing.Size(81, 21);
            this.txtgioitinh.TabIndex = 3;
            this.txtgioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(536, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 23);
            this.label12.TabIndex = 223;
            this.label12.Text = "Giới tính :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txthotennguoidua
            // 
            this.txthotennguoidua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txthotennguoidua.Enabled = false;
            this.txthotennguoidua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthotennguoidua.Location = new System.Drawing.Point(136, 98);
            this.txthotennguoidua.Name = "txthotennguoidua";
            this.txthotennguoidua.Size = new System.Drawing.Size(297, 21);
            this.txthotennguoidua.TabIndex = 8;
            this.txthotennguoidua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(10, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 19);
            this.label13.TabIndex = 225;
            this.label13.Text = "Họ tên người đưa đến :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(536, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 23);
            this.label14.TabIndex = 229;
            this.label14.Text = "Giới tính :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttuoinguoidua
            // 
            this.txttuoinguoidua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttuoinguoidua.Enabled = false;
            this.txttuoinguoidua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttuoinguoidua.Location = new System.Drawing.Point(486, 98);
            this.txttuoinguoidua.Name = "txttuoinguoidua";
            this.txttuoinguoidua.Size = new System.Drawing.Size(47, 21);
            this.txttuoinguoidua.TabIndex = 9;
            this.txttuoinguoidua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttuoinguoidua_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(435, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 23);
            this.label15.TabIndex = 227;
            this.label15.Text = "Tuổi :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbogioitinh
            // 
            this.cbogioitinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbogioitinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbogioitinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbogioitinh.Enabled = false;
            this.cbogioitinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbogioitinh.Items.AddRange(new object[] {
            "Nữ",
            "Nam"});
            this.cbogioitinh.Location = new System.Drawing.Point(588, 98);
            this.cbogioitinh.Name = "cbogioitinh";
            this.cbogioitinh.Size = new System.Drawing.Size(81, 21);
            this.cbogioitinh.TabIndex = 10;
            this.cbogioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // txtdiachinguoidua
            // 
            this.txtdiachinguoidua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdiachinguoidua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdiachinguoidua.Enabled = false;
            this.txtdiachinguoidua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachinguoidua.Location = new System.Drawing.Point(136, 121);
            this.txtdiachinguoidua.Name = "txtdiachinguoidua";
            this.txtdiachinguoidua.Size = new System.Drawing.Size(533, 21);
            this.txtdiachinguoidua.TabIndex = 11;
            this.txtdiachinguoidua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(11, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 19);
            this.label16.TabIndex = 231;
            this.label16.Text = "Địa chỉ người đưa đến :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcmnd
            // 
            this.txtcmnd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtcmnd.Enabled = false;
            this.txtcmnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcmnd.Location = new System.Drawing.Point(136, 144);
            this.txtcmnd.Name = "txtcmnd";
            this.txtcmnd.Size = new System.Drawing.Size(297, 21);
            this.txtcmnd.TabIndex = 12;
            this.txtcmnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(11, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 19);
            this.label17.TabIndex = 233;
            this.label17.Text = "Số CMND :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(434, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 23);
            this.label18.TabIndex = 235;
            this.label18.Text = "Quan hệ :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtquanhe
            // 
            this.txtquanhe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtquanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtquanhe.Enabled = false;
            this.txtquanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquanhe.Location = new System.Drawing.Point(486, 144);
            this.txtquanhe.Name = "txtquanhe";
            this.txtquanhe.Size = new System.Drawing.Size(183, 21);
            this.txtquanhe.TabIndex = 13;
            this.txtquanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // txtphuongtien
            // 
            this.txtphuongtien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtphuongtien.Enabled = false;
            this.txtphuongtien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphuongtien.Location = new System.Drawing.Point(136, 167);
            this.txtphuongtien.Name = "txtphuongtien";
            this.txtphuongtien.Size = new System.Drawing.Size(297, 21);
            this.txtphuongtien.TabIndex = 14;
            this.txtphuongtien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(11, 167);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 19);
            this.label19.TabIndex = 237;
            this.label19.Text = "Phương tiện đưa đến :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtsoxe
            // 
            this.txtsoxe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsoxe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsoxe.Enabled = false;
            this.txtsoxe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoxe.Location = new System.Drawing.Point(486, 167);
            this.txtsoxe.Name = "txtsoxe";
            this.txtsoxe.Size = new System.Drawing.Size(183, 21);
            this.txtsoxe.TabIndex = 15;
            this.txtsoxe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(433, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 23);
            this.label20.TabIndex = 239;
            this.label20.Text = "Số xe :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttinhtrang
            // 
            this.txttinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttinhtrang.Enabled = false;
            this.txttinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttinhtrang.Location = new System.Drawing.Point(136, 190);
            this.txttinhtrang.Name = "txttinhtrang";
            this.txttinhtrang.Size = new System.Drawing.Size(533, 21);
            this.txttinhtrang.TabIndex = 16;
            this.txttinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(11, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 19);
            this.label21.TabIndex = 241;
            this.label21.Text = "Tình trạng lúc vào viện :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdaxuly
            // 
            this.txtdaxuly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdaxuly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdaxuly.Enabled = false;
            this.txtdaxuly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdaxuly.Location = new System.Drawing.Point(136, 236);
            this.txtdaxuly.Name = "txtdaxuly";
            this.txtdaxuly.Size = new System.Drawing.Size(533, 21);
            this.txtdaxuly.TabIndex = 19;
            this.txtdaxuly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(11, 236);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 19);
            this.label22.TabIndex = 243;
            this.label22.Text = "Đã xử lý cấp cứu :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtykien
            // 
            this.txtykien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtykien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtykien.Enabled = false;
            this.txtykien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtykien.Location = new System.Drawing.Point(136, 259);
            this.txtykien.Multiline = true;
            this.txtykien.Name = "txtykien";
            this.txtykien.Size = new System.Drawing.Size(533, 56);
            this.txtykien.TabIndex = 20;
            this.txtykien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(11, 259);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 19);
            this.label23.TabIndex = 245;
            this.label23.Text = "Ý kiến của thân nhân :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(11, 317);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(126, 19);
            this.label24.TabIndex = 247;
            this.label24.Text = "Tài sản của bệnh nhân :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttien
            // 
            this.txttien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttien.Enabled = false;
            this.txttien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttien.Location = new System.Drawing.Point(220, 317);
            this.txttien.Name = "txttien";
            this.txttien.Size = new System.Drawing.Size(449, 21);
            this.txttien.TabIndex = 21;
            this.txttien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // chktien
            // 
            this.chktien.AutoSize = true;
            this.chktien.Location = new System.Drawing.Point(147, 319);
            this.chktien.Name = "chktien";
            this.chktien.Size = new System.Drawing.Size(53, 17);
            this.chktien.TabIndex = 249;
            this.chktien.Text = "Tiền :";
            this.chktien.UseVisualStyleBackColor = true;
            this.chktien.CheckedChanged += new System.EventHandler(this.chktien_CheckedChanged);
            // 
            // chktutrang
            // 
            this.chktutrang.AutoSize = true;
            this.chktutrang.Location = new System.Drawing.Point(147, 342);
            this.chktutrang.Name = "chktutrang";
            this.chktutrang.Size = new System.Drawing.Size(72, 17);
            this.chktutrang.TabIndex = 251;
            this.chktutrang.Text = "Tư trang :";
            this.chktutrang.UseVisualStyleBackColor = true;
            this.chktutrang.CheckedChanged += new System.EventHandler(this.chktutrang_CheckedChanged);
            // 
            // txttutrang
            // 
            this.txttutrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttutrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttutrang.Enabled = false;
            this.txttutrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttutrang.Location = new System.Drawing.Point(220, 340);
            this.txttutrang.Name = "txttutrang";
            this.txttutrang.Size = new System.Drawing.Size(449, 21);
            this.txttutrang.TabIndex = 22;
            this.txttutrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // txtcongan
            // 
            this.txtcongan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcongan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtcongan.Enabled = false;
            this.txtcongan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcongan.Location = new System.Drawing.Point(136, 363);
            this.txtcongan.Multiline = true;
            this.txtcongan.Name = "txtcongan";
            this.txtcongan.Size = new System.Drawing.Size(533, 76);
            this.txtcongan.TabIndex = 23;
            this.txtcongan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(11, 362);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(126, 19);
            this.label25.TabIndex = 252;
            this.label25.Text = "Giải quyết của công an :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttenbs
            // 
            this.txttenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttenbs.Enabled = false;
            this.txttenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenbs.Location = new System.Drawing.Point(195, 441);
            this.txttenbs.Name = "txttenbs";
            this.txttenbs.Size = new System.Drawing.Size(474, 21);
            this.txttenbs.TabIndex = 25;
            this.txttenbs.TextChanged += new System.EventHandler(this.txttenbs_TextChanged);
            this.txttenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttenbs_KeyDown);
            // 
            // txtmabs
            // 
            this.txtmabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmabs.Enabled = false;
            this.txtmabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmabs.Location = new System.Drawing.Point(136, 441);
            this.txtmabs.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.txtmabs.MaxLength = 9;
            this.txtmabs.Name = "txtmabs";
            this.txtmabs.Size = new System.Drawing.Size(56, 21);
            this.txtmabs.TabIndex = 24;
            this.txtmabs.Validated += new System.EventHandler(this.txtmabs_Validated);
            this.txtmabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 254;
            this.label8.Text = "Bác sĩ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttendd
            // 
            this.txttendd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttendd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttendd.Enabled = false;
            this.txttendd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendd.Location = new System.Drawing.Point(195, 464);
            this.txttendd.Name = "txttendd";
            this.txttendd.Size = new System.Drawing.Size(474, 21);
            this.txttendd.TabIndex = 27;
            this.txttendd.TextChanged += new System.EventHandler(this.txttendd_TextChanged);
            this.txttendd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttendd_KeyDown);
            // 
            // txtmadd
            // 
            this.txtmadd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmadd.Enabled = false;
            this.txtmadd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmadd.Location = new System.Drawing.Point(136, 464);
            this.txtmadd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.txtmadd.MaxLength = 9;
            this.txtmadd.Name = "txtmadd";
            this.txtmadd.Size = new System.Drawing.Size(56, 21);
            this.txtmadd.TabIndex = 26;
            this.txtmadd.Validated += new System.EventHandler(this.txtmadd_Validated);
            this.txtmadd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmabn_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 257;
            this.label9.Text = "Điều dưỡng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butin
            // 
            this.butin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(531, 510);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(70, 25);
            this.butin.TabIndex = 31;
            this.butin.Text = "      &In";
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(144, 518);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 258;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // txtnguoithan
            // 
            this.txtnguoithan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnguoithan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtnguoithan.Enabled = false;
            this.txtnguoithan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguoithan.Location = new System.Drawing.Point(136, 75);
            this.txtnguoithan.Name = "txtnguoithan";
            this.txtnguoithan.Size = new System.Drawing.Size(533, 21);
            this.txtnguoithan.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 19);
            this.label10.TabIndex = 260;
            this.label10.Text = "Người thân :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.Location = new System.Drawing.Point(11, 510);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(85, 17);
            this.chkxml.TabIndex = 261;
            this.chkxml.Text = "Xuất ra XML";
            this.chkxml.UseVisualStyleBackColor = true;
            // 
            // frmBienbantuvong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(677, 547);
            this.Controls.Add(this.chkxml);
            this.Controls.Add(this.txtnguoithan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.txttendd);
            this.Controls.Add(this.txtmadd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txttenbs);
            this.Controls.Add(this.txtmabs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcongan);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.chktutrang);
            this.Controls.Add(this.txttutrang);
            this.Controls.Add(this.chktien);
            this.Controls.Add(this.txttien);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtykien);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtdaxuly);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txttinhtrang);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtsoxe);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtphuongtien);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtquanhe);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtcmnd);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtdiachinguoidua);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbogioitinh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txttuoinguoidua);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txthotennguoidua);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtgioitinh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.cbonguyennhan);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.txtngay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttuoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtmabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBienbantuvong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tử vong";
            this.Load += new System.EventHandler(this.frmBienbantuvong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBienbantuvong_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBienbantuvong_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dticd=m.get_data("select cicd10,vviet from "+user+".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

            dtbs = m.get_data("select ma,hoten from " + user + ".dmbs order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

			cbonguyennhan.DisplayMember="TEN";
            cbonguyennhan.ValueMember = "MA";
            cbonguyennhan.DataSource = m.get_data("select * from " + user + ".chetdo order by ma").Tables[0];
			
			txtmabn.Text=m_mabn;
			txthoten.Text=m_hoten;
			
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

				txttuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
			}
			catch{}
			txtngay.Text=m_ngay;
			txtdiachi.Text=s_diachi;
            txttuoi.Text = m_tuoivao;
            txtgioitinh.Text = (i_phai == 0) ? "Nam" : "Nữ";
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
            foreach (DataRow r in m.get_data("select * from " + user + ".bienbantuvong where maql=" + m_maql).Tables[0].Rows)
            {
                cbonguyennhan.SelectedValue = r["nguyennhan"].ToString();
                chandoan.Text = r["chandoan"].ToString();
                DataRow r1 = m.getrowbyid(dticd, "vviet='" + chandoan.Text.Trim() + "'");
                maicd.Text = r1["cicd10"].ToString();
                txthotennguoidua.Text = r["hotennguoidua"].ToString();
                cbogioitinh.SelectedIndex = int.Parse(r["phai"].ToString());
                txtnguoithan.Text = r["nguoithan"].ToString();
                txtdiachinguoidua.Text = r["diachi"].ToString();
                txttuoinguoidua.Text = r["namsinh"].ToString();
                txtcmnd.Text = r["cmnd"].ToString();
                txtquanhe.Text = r["quanhe"].ToString();
                txtphuongtien.Text = r["phuongtien"].ToString();
                txtsoxe.Text = r["soxe"].ToString();
                txttinhtrang.Text = r["tinhtrang"].ToString();
                txtdaxuly.Text = r["daxuly"].ToString();
                txtykien.Text = r["ykien"].ToString();
                int pos = r["taisan"].ToString().IndexOf(",");
                txttien.Text = r["taisan"].ToString().Substring(0,pos);
                txttutrang.Text = r["taisan"].ToString().Substring(pos);
                txtcongan.Text = r["congan"].ToString();
                txtmabs.Text = r["mabs"].ToString();
                DataRow r2 = m.getrowbyid(dtbs, "ma='" + txtmabs.Text.Trim() + "'");
                txttenbs.Text = r2["hoten"].ToString();
                txtmadd.Text = r["manv"].ToString();
                DataRow r3 = m.getrowbyid(dtbs, "ma='" + txtmadd.Text.Trim() + "'");
                txttendd.Text = r3["hoten"].ToString();
                break;
            }
		}

		private void cbonguyennhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (cbonguyennhan.SelectedIndex==-1) cbonguyennhan.SelectedIndex=0;
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

		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (ena) chandoan.Enabled=m.bChandoan;
			maicd.Enabled=ena;
            cbonguyennhan.Enabled = txthotennguoidua.Enabled = txttuoinguoidua.Enabled = cbogioitinh.Enabled = ena;
            txtdiachinguoidua.Enabled = txtcmnd.Enabled = txtquanhe.Enabled = txtphuongtien.Enabled = ena;
            txtsoxe.Enabled = txttinhtrang.Enabled = txtdaxuly.Enabled = ena;
            txtykien.Enabled = txtcongan.Enabled = txtnguoithan.Enabled = ena;
            txtmabs.Enabled = txttenbs.Enabled = txtmadd.Enabled = txttendd.Enabled = ena;
		}

        private void emp_text()
        {
 
        }

		private bool kiemtra()
		{
			if (cbonguyennhan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nguyên nhân tử vong !"),s_msg);
				cbonguyennhan.Focus();
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
			return true;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			cbonguyennhan.Focus();
			SendKeys.Send("{F4}");
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            if (!m.upd_bienbantuvong(txtmabn.Text,m_maql,s_makp,i_chinhanh,txtmabs.Text,txtmadd.Text,txtnguoithan.Text,txthotennguoidua.Text,
                txttuoinguoidua.Text, cbogioitinh.SelectedIndex, txtdiachinguoidua.Text, txtcmnd.Text,
                txtquanhe.Text, txtphuongtien.Text, txtsoxe.Text, txttinhtrang.Text, chandoan.Text,txtdaxuly.Text,
                txtngay.Text,cbonguyennhan.SelectedValue.ToString(),txtykien.Text,txttien.Text+","+txttutrang.Text,txtcongan.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tử vong !"), s_msg);
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

		private void frmBienbantuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
				listICD.BrowseToICD10(chandoan,maicd,txtdaxuly,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
			}		
		}

        private void txtmabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butin_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "select a.*,b.hoten,c.hoten as tenbs,d.hoten as tendd,e.tenkp from " + user + ".bienbantuvong a,";
            sql += "" + user + ".btdbn b," + user + ".dmbs c," + user + ".dmbs d,"+user+".btdkp_bv e ";
            sql += "where a.mabn=b.mabn and a.mabs=c.ma and a.manv=d.ma and a.makp=e.makp and a.mabn='" + m_mabn + "'";
            DataSet ds_in=m.get_data(sql);
            if (chkxml.Checked) ds_in.WriteXml("..//..//dataxml//bienbantuvong.xml");
            if (ds_in.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds_in, "rptbienbantuvong.rpt", txtgioitinh.Text, txttuoi.Text, txtdiachi.Text, "", "", "");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu"));
        }

        private void chktien_CheckedChanged(object sender, EventArgs e)
        {
            if (chktien.Checked) txttien.Enabled = true;
            else if (!chktien.Checked) txttien.Enabled = false;
        }

        private void chktutrang_CheckedChanged(object sender, EventArgs e)
        {
            if (chktutrang.Checked) txttutrang.Enabled = true;
            else if (!chktutrang.Checked) txttutrang.Enabled = false;
        }

        private void txttuoinguoidua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}{F4}");
        }

        private void Filt_DMBS(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txttenbs_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttenbs)
            {
                Filt_DMBS(txttenbs.Text);
                //listBS.BrowseToDanhmuc(txttenbs, txtmabs, txtmadd, txtmabs.Location.X, txtmabs.Location.Y + txtmabs.Height, txtmabs.Width + txttenbs.Width + 2);
                listBS.BrowseToDanhmuc(txttenbs, txtmabs, txtmadd);
            }		
        }

        private void txtmabs_Validated(object sender, EventArgs e)
        {
            if (txtmabs.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtmabs.Text + "'");
                if (r != null) txttenbs.Text = r["hoten"].ToString();
                else txttenbs.Text = "";
            }
        }

        private void txttenbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void txtmadd_Validated(object sender, EventArgs e)
        {
            if (txtmadd.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtmadd.Text + "'");
                if (r != null) txttendd.Text = r["hoten"].ToString();
                else txttendd.Text = "";
            }
        }

        private void txttendd_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txttendd)
            {
                Filt_DMBS(txttendd.Text);
                //listBS.BrowseToDanhmuc(txttenbs, txtmabs, txtmadd, txtmabs.Location.X, txtmabs.Location.Y + txtmabs.Height, txtmabs.Width + txttenbs.Width + 2);
                listBS.BrowseToDanhmuc(txttendd, txtmadd, butLuu);
            }		
        }

        private void txttendd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }
	}
}
