using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	public class frmTktiemchung : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private MaskedTextBox.MaskedTextBox mabn;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox sonha;
		private MaskedTextBox.MaskedTextBox thon;
		private System.Windows.Forms.ComboBox dentu;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.ComboBox nhantu;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private MaskedTextBox.MaskedTextBox maicd;
		private DataSet dst=new DataSet();
		private DataSet ds=new DataSet();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private AccessData m;
        private string user;
		private bool bClear=true;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.ComboBox xutri;
		private System.Windows.Forms.Label label21;
		private MaskedBox.MaskedBox tu;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox ngaysinh;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkmaicd;
		private System.Windows.Forms.Label label22;
		private MaskedTextBox.MaskedTextBox soluutru;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.ComboBox nguoidung;
		private System.Windows.Forms.Label label12;
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.CheckBox time;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox mabs;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox bnmoi;
        private System.Windows.Forms.Label l_bnmoi;
        private System.Windows.Forms.ComboBox loaidt;
        private Button butTuongtac;
        private int i_nhom;
        private MaskedTextBox.MaskedTextBox sothe;
        private Label label24;
        private ComboBox cbtraituyen;
        private CheckBox chkXML;
		private System.ComponentModel.IContainer components;
        #endregion

        public frmTktiemchung(AccessData acc)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTktiemchung));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.dentu = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.xutri = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tu = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkmaicd = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.nguoidung = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.ComboBox();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.loaidt = new System.Windows.Forms.ComboBox();
            this.butTuongtac = new System.Windows.Forms.Button();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cbtraituyen = new System.Windows.Forms.ComboBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(114, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(210, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(314, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(522, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(-9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(111, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số nhà :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(224, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thôn, phố :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(154, 52);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(64, 21);
            this.madantoc.TabIndex = 10;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(282, 52);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(112, 21);
            this.mann.TabIndex = 11;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(226, 74);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(138, 21);
            this.maqu.TabIndex = 15;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(52, 74);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(102, 21);
            this.matt.TabIndex = 14;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(434, 74);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(96, 21);
            this.maphuongxa.TabIndex = 16;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(360, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Ph/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(148, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(-1, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(211, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 49;
            this.label10.Text = "Nghề nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(99, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(515, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 59;
            this.label13.Text = "Số khám :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(-2, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 60;
            this.label14.Text = "Mã ICD :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(140, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Nơi giới thiệu :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(-35, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 23);
            this.label19.TabIndex = 62;
            this.label19.Text = "Nhận từ :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(165, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 63;
            this.label20.Text = "Đối tượng :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Visible = false;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(256, 8);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(361, 8);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(168, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(52, 30);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(64, 21);
            this.phai.TabIndex = 5;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(154, 30);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(64, 21);
            this.sonha.TabIndex = 6;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(282, 30);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(175, 21);
            this.thon.TabIndex = 7;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(586, 74);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 17;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(52, 96);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(59, 21);
            this.maicd.TabIndex = 18;
            this.maicd.Visible = false;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(226, 118);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(195, 21);
            this.dentu.TabIndex = 23;
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownWidth = 170;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(226, 96);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(77, 21);
            this.madoituong.TabIndex = 19;
            this.madoituong.Visible = false;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(52, 119);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(102, 21);
            this.nhantu.TabIndex = 22;
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
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
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 146);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(780, 375);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(294, 529);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 27;
            this.butTim.Text = "     &Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(368, 529);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 28;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(442, 529);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 29;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(8, 529);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(256, 23);
            this.lbl.TabIndex = 65;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xutri
            // 
            this.xutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(434, 52);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(96, 21);
            this.xutri.TabIndex = 12;
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(378, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 67;
            this.label21.Text = "Xử trí :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(52, 8);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(146, 8);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // ngaysinh
            // 
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(586, 8);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // dotuoi
            // 
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(52, 52);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(54, 21);
            this.dotuoi.TabIndex = 9;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "Tuổi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmaicd
            // 
            this.chkmaicd.Location = new System.Drawing.Point(114, 99);
            this.chkmaicd.Name = "chkmaicd";
            this.chkmaicd.Size = new System.Drawing.Size(16, 16);
            this.chkmaicd.TabIndex = 69;
            this.chkmaicd.Visible = false;
            this.chkmaicd.CheckStateChanged += new System.EventHandler(this.chkmaicd_CheckStateChanged);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(515, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 23);
            this.label22.TabIndex = 70;
            this.label22.Text = "Số lưu trữ :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(586, 52);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(64, 21);
            this.soluutru.TabIndex = 13;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.HorizontalScrollbar = true;
            this.makp.Location = new System.Drawing.Point(656, 22);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(132, 116);
            this.makp.TabIndex = 71;
            // 
            // nguoidung
            // 
            this.nguoidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidung.Location = new System.Drawing.Point(514, 30);
            this.nguoidung.Name = "nguoidung";
            this.nguoidung.Size = new System.Drawing.Size(136, 21);
            this.nguoidung.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(426, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 23);
            this.label12.TabIndex = 75;
            this.label12.Text = "Ng nhập :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.time.Location = new System.Drawing.Point(656, 1);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(132, 16);
            this.time.TabIndex = 76;
            this.time.Text = "checkBox1";
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(172, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 23);
            this.label23.TabIndex = 77;
            this.label23.Text = "Bác sĩ :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(226, 141);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(276, 21);
            this.mabs.TabIndex = 26;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(52, 141);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(134, 21);
            this.loai.TabIndex = 25;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(-15, 141);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 23);
            this.label34.TabIndex = 256;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.bnmoi.Location = new System.Drawing.Point(491, 118);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(159, 21);
            this.bnmoi.TabIndex = 24;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_bnmoi.Location = new System.Drawing.Point(412, 120);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(80, 23);
            this.l_bnmoi.TabIndex = 255;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaidt
            // 
            this.loaidt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaidt.DropDownWidth = 170;
            this.loaidt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaidt.Items.AddRange(new object[] {
            "Bắt buộc",
            "Tự nguyện"});
            this.loaidt.Location = new System.Drawing.Point(381, 96);
            this.loaidt.Name = "loaidt";
            this.loaidt.Size = new System.Drawing.Size(62, 21);
            this.loaidt.TabIndex = 20;
            this.loaidt.Visible = false;
            this.loaidt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // butTuongtac
            // 
            this.butTuongtac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTuongtac.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtac.Image")));
            this.butTuongtac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtac.Location = new System.Drawing.Point(709, 527);
            this.butTuongtac.Name = "butTuongtac";
            this.butTuongtac.Size = new System.Drawing.Size(79, 25);
            this.butTuongtac.TabIndex = 270;
            this.butTuongtac.Text = "Tương tác";
            this.butTuongtac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtac.Visible = false;
            this.butTuongtac.Click += new System.EventHandler(this.butTuongtac_Click);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(491, 96);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(159, 21);
            this.sothe.TabIndex = 21;
            this.sothe.Visible = false;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(443, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 23);
            this.label24.TabIndex = 272;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label24.Visible = false;
            // 
            // cbtraituyen
            // 
            this.cbtraituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbtraituyen.DropDownWidth = 170;
            this.cbtraituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtraituyen.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.cbtraituyen.Location = new System.Drawing.Point(305, 96);
            this.cbtraituyen.Name = "cbtraituyen";
            this.cbtraituyen.Size = new System.Drawing.Size(75, 21);
            this.cbtraituyen.TabIndex = 274;
            this.cbtraituyen.Visible = false;
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkXML.Location = new System.Drawing.Point(571, 532);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(132, 16);
            this.chkXML.TabIndex = 275;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // frmTktiemchung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.cbtraituyen);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.butTuongtac);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.dentu);
            this.Controls.Add(this.chkmaicd);
            this.Controls.Add(this.loaidt);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.bnmoi);
            this.Controls.Add(this.l_bnmoi);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.time);
            this.Controls.Add(this.nguoidung);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.nhantu);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTktiemchung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người đi tiêm chủng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTktiemchung_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTktiemchung_KeyDown);
            this.Load += new System.EventHandler(this.frmTktiemchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTktiemchung_Load(object sender, System.EventArgs e)
		{
            user = m.user; i_nhom = m.nhom_duoc;
			dst.ReadXml("..//..//..//xml//d_toathuocct.xml");
			time.Text=lan.Change_language_MessageText("Giờ báo cáo ")+" "+m.sGiobaocao;
			nguoidung.DisplayMember="HOTEN";
			nguoidung.ValueMember="ID";
            nguoidung.DataSource = m.get_data("select * from " + user + ".dlogin").Tables[0];

			dsloai.ReadXml("..//..//..//xml//m_loai.xml");
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dsloai.Tables[0];
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];

			DataSet dsd=new DataSet();
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dsd.ReadXml("..//..//..//xml//dotuoi.xml");
			dotuoi.DataSource=dsd.Tables[0];

			xutri.DisplayMember="TEN";
			xutri.ValueMember="MA";
            xutri.DataSource = m.get_data("select * from " + user + ".xutrikb").Tables[0];

            dtkp = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
			makp.DataSource=dtkp;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";

			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
            mann.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];

			mabs.DisplayMember="HOTEN";
			mabs.ValueMember="MA";
            mabs.DataSource = m.get_data("select * from " + user + ".dmbs order by ma").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];

			nhantu.DisplayMember="TEN";
			nhantu.ValueMember="MA";
            nhantu.DataSource = m.get_data("select * from " + user + ".nhantu order by ma").Tables[0];

			dentu.DisplayMember="TEN";
			dentu.ValueMember="MA";
            dentu.DataSource = m.get_data("select * from " + user + ".dentu order by ma").Tables[0];

            ds = m.get_data("select * from " + user + ".capid where ma=0");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			//
			tu.Text=m.Ngayhienhanh;
			den.Text=tu.Text;
			loaidt.SelectedIndex=-1;
		}

		private void emp_text()
		{
			makp.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			madantoc.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			maphuongxa.SelectedIndex=-1;
			madoituong.SelectedIndex=-1;
			nhantu.SelectedIndex=-1;
			dentu.SelectedIndex=-1;
			xutri.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
			nguoidung.SelectedIndex=-1;
			mabs.SelectedIndex=-1;
			loai.SelectedIndex=-1;
			bnmoi.SelectedIndex=-1;
			loaidt.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
				maqu.DataSource=m.get_data("select * from "+user+".btdquan where matt='"+matt.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
			}
			catch{}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maqu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maphuongxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="") 
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
            if (tu.Text.Length == 6) tu.Text = tu.Text + DateTime.Now.Year.ToString();
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tu.Focus();
				return;
			}
			tu.Text=m.Ktngaygio(tu.Text,10);
			if (den.Text=="") den.Text=tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="") 
			{
				tu.Text="";
				return;
			}
			den.Text=den.Text.Trim();
            if (den.Text.Length == 6) den.Text = den.Text + DateTime.Now.Year.ToString();
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,10);
			if (tu.Text=="")
			{
				tu.Focus();
				return;
			}
			if (!m.bNgay(den.Text,tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
				den.Focus();
				return;
			}
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
            if (tu.Text.Length != 10 || den.Text.Length != 10)
            {
                tu.Focus();
                return;
            }
			string s_makp="'";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString()+"','";
			if (s_makp.Length>1) s_makp="("+s_makp.Substring(0,s_makp.Length-2)+")";
            else s_makp = "";
			int i_userid=(nguoidung.SelectedIndex==-1)?-1:int.Parse(nguoidung.SelectedValue.ToString());
            int i_traituyen = cbtraituyen.SelectedIndex;
            ds = get_Tiemchung(tu.Text, den.Text, mabn.Text, hoten.Text.Replace("'", "''"), ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text.Replace("'", "''"),
				(mann.SelectedIndex==-1)?"":mann.SelectedValue.ToString(),(madantoc.SelectedIndex==-1)?"":madantoc.SelectedValue.ToString(),
				(matt.SelectedIndex==-1)?"":matt.SelectedValue.ToString(),(maqu.SelectedIndex==-1)?"":maqu.SelectedValue.ToString(),
				(maphuongxa.SelectedIndex==-1)?"":maphuongxa.SelectedValue.ToString(),s_makp,sovaovien.Text,maicd.Text,(madoituong.SelectedIndex==-1)?"":madoituong.SelectedValue.ToString(),(dentu.SelectedIndex==-1)?"":dentu.SelectedValue.ToString(),
				(nhantu.SelectedIndex==-1)?"":nhantu.SelectedValue.ToString(),(xutri.SelectedIndex==-1)?"":xutri.SelectedValue.ToString(),
				(dotuoi.SelectedIndex==-1)?"":dotuoi.SelectedValue.ToString(),chkmaicd.Checked,soluutru.Text,i_userid,time.Checked,(mabs.SelectedIndex!=-1)?mabs.SelectedValue.ToString():"",loai.SelectedIndex,bnmoi.SelectedIndex,(loaidt.SelectedIndex!=-1)?loaidt.Text.Substring(0,1):"",sothe.Text, false,i_traituyen);
            dataGrid1.DataSource=ds.Tables[0];
			lbl.Text=lan.Change_language_MessageText("TỔNG SỐ : ")+ds.Tables[0].Rows.Count.ToString();
		}
        public DataSet get_Tiemchung(string tu, string den, string mabn, string hoten, string ngaysinh,
            int phai, string sonha, string thon, string mann, string madantoc, string matt, string maqu,
            string maphuongxa, string makp, string sovaovien, string maicd, string madoituong, string dentu,
            string nhantu, string xutri, string dotuoi, bool icd, string soluutru, int userid, bool time,
            string mabs, int loai, int bnmoi, string loaidt, string sothe, bool bngoaitru, int traituyen)
        {
            string sql = "";
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            int v1 = 5, v2 = 2, i_nhom = m.nhom_duoc;
            string s_tunguyen = "", s_thetunguyen = d.thetunguyen(i_nhom);
            if (s_thetunguyen != "") s_tunguyen = s_thetunguyen.Replace(",", "','");
            string vitri = d.thetunguyen_vitri_ora(i_nhom);
            if (vitri.Length == 3)
            {
                v1 = int.Parse(vitri.Substring(0, 1)); v2 = int.Parse(vitri.Substring(2, 1));
            }
            string stime = (time) ? "'" + m.f_ngaygio + "'" : "'" + m.f_ngay + "'";
            if (time)
            {
                tu = tu + " " + m.sGiobaocao;
                den = den + " " + m.sGiobaocao;
            }
            hoten = m.Hoten_khongdau(hoten);
            sql = "SELECT a.MABN,f.maql,a.HOTEN,to_char(a.ngaysinh,'dd/mm/yyyy') ngaysinh, a.NAMSINH,case when a.phai =0 then 'Nam' else 'Nữ' end gioitinh ,coalesce(a.SONHA,'') as sonha,";
            sql += "coalesce(a.THON,' ') as thon, b.TENPXA, c.TENQUAN, d.TENTT, g.TENNN, to_char(f.ngay,'dd/mm/yyyy hh24:mi') AS ngay,a.cholam";
            sql += "coalesce(y.tenkp,' ') as khoanhap,coalesce(to_char(z.ngaysanh,'dd/mm/yyyy'),' ') as ngaysanh,coalesce(u.hoten,' ') as tenuser,coalesce(l.sothe,' ') as sothe,v.tenbv ";
            sql += ", l.traituyen ";
            sql += " FROM " + user + ".btdbn a inner join "+user+".benhantc f on a.mabn=f.mabn";
            sql += " inner join " + user + ".btdpxa b on a.maphuongxa=b.maphuongxa ";
            sql += " inner join " + user + ".btdquan c on a.maqu=c.maqu ";
            sql += " inner join " + user + ".btdtt d on a.matt=d.matt ";
            sql += " inner join " + user + ".btdnn_bv g on a.mann=g.mann ";
            sql += " left join xxx.xutrikbct x on f.maql=x.maql ";
            sql += " left join " + user + ".btdkp_bv y on x.makp=y.makp ";
            sql += " left join xxx.ttkhamthai z on f.maql=z.maql ";
            sql += " left join " + user + ".dlogin u on f.userid=u.id ";
            sql += " left join xxx.bhyt l on f.maql=l.maql ";
            sql += " left join " + user + ".chuyenvien t on f.maql=t.maql ";
            sql += " left join " + user + ".tenvien v on t.mabv=v.mabv ";
            sql += " where f.maql>0";
            if (makp != "") sql += " and f.makp in " + makp;
            if (loaidt != "")
            {
                if (loaidt == "B") sql += " and substr(l.sothe," + v1 + "," + v2 + ") not in ('" + s_tunguyen.Substring(0, s_tunguyen.Length) + "')";
                else sql += " and substr(l.sothe," + v1 + "," + v2 + ") in ('" + s_tunguyen.Substring(0, s_tunguyen.Length) + "')";
            }
            if (icd) sql += " and f.maicd in (select ma from " + user + ".bctheoicd)";
            if (tu != "")
                sql += " and " + m.for_ngay("f.ngay", stime) + " between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")";
            if (mabn != "") sql += " and a.mabn='" + mabn + "'";
            if (hoten != "") sql += " and a.hotenkdau like '%" + hoten + "%'";
            if (ngaysinh.Trim().Length == 10) sql += " and to_char(a.ngaysinh,'dd/mm/yyyy')='" + ngaysinh + "'";
            if (phai != -1) sql += " and a.phai=" + phai;
            if (sonha != "") sql += " and lower(trim(a.sonha))='" + sonha + "'";
            if (thon != "") sql += " and lower(trim(a.thon))='" + thon + "'";
            if (mann != "") sql += " and a.mann='" + mann + "'";
            if (madantoc != "") sql += " and a.madantoc='" + madantoc + "'";
            if (matt != "") sql += " and a.matt='" + matt + "'";
            if (maqu != "") sql += " and a.maqu='" + maqu + "'";
            if (maphuongxa != "") sql += " and a.maphuongxa='" + maphuongxa + "'";
            if (userid != -1) sql += " and f.userid=" + userid;
            if (sothe != "") sql += " and l.sothe like '%" + sothe + "%'";
            if (xutri != "") sql += " and x.xutri like '%" + xutri + ",%'";
            if (soluutru == "*") sql += " and m.soluutru is not null";
            else if (soluutru != "") sql += " and m.soluutru='" + soluutru + "'";
            if (userid != -1) sql += " and f.userid=" + userid;
            if (traituyen >= 0) sql += " and l.traituyen=" + (traituyen > 1 ? 1 : traituyen);
            if (dotuoi != "")
            {
                if (dotuoi.Trim() == "<1TH")
                {
                    sql += " and a.ngaysinh is not null and extract(day from(to_date(to_char(f.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')-to_date(to_char(a.ngaysinh,'dd/mm/yyyy'),'dd/mm/yyyy'))) < 31 ";//DUOI 1 THANG
                }
                else if (dotuoi.Trim() == "<1T")
                {
                    sql += " and a.ngaysinh is not null and extract(day from(to_date(to_char(f.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')-to_date(to_char(a.ngaysinh,'dd/mm/yyyy'),'dd/mm/yyyy'))) between 31 and 365 ";//DUOI 1 TUOI
                }
                else if (dotuoi.IndexOf(">") != -1)
                {
                    sql += " and to_number(to_char(f.ngay,'yyyy'),'0000')-to_number(a.namsinh,'0000')>" + int.Parse(dotuoi.Substring(1));
                }
                else
                {
                    int i1 = int.Parse(dotuoi.Substring(0, dotuoi.IndexOf("-")));
                    int i2 = int.Parse(dotuoi.Substring(dotuoi.IndexOf("-") + 1));
                    sql += " and to_number(to_char(f.ngay,'yyyy'),'0000')-to_number(a.namsinh,'0000') between " + i1 + " and " + i2; //sql += " and to_number(to_char(now(),'yyyy'),'0000')-to_number(a.namsinh,'0000') between " + i1 + " and " + i2;
                }
            }
            sql += " order by f.ngay";
            return m.get_data_mmyy(sql, tu.Substring(0, 10), den.Substring(0, 10), false);
        }
		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						

			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();						
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Phòng khám";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
            
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gioitinh";
            TextCol.HeaderText = "Giới tính";
            TextCol.Width = 40;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tuoi";
			TextCol.HeaderText = "Tuổi";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sonha";
			TextCol.HeaderText = "Số nhà";
			TextCol.Width = 50;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thon";
			TextCol.HeaderText = "Thôn đường";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpxa";
			TextCol.HeaderText = "Phường/Xã";
			TextCol.Width = 120;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenquan";
			TextCol.HeaderText = "Quận/Huyện";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tentt";
			TextCol.HeaderText = "Tỉnh/Thành phố";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennn";
			TextCol.HeaderText = "Nghề nghiệp";
			TextCol.Width = 150;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày giờ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sĩ khám";
			TextCol.Width = 150;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "traituyen";
            TextCol.HeaderText = "Trái tuyến";
            TextCol.Width = 50;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 250;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "ICD";
			TextCol.Width = 50;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhantu";
			TextCol.HeaderText = "Trực tiếp vào";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dentu";
			TextCol.HeaderText = "Nơi giới thiệu";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "xutri";
			TextCol.HeaderText = "Xử trí";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenbv";
            TextCol.HeaderText = "Bệnh viện";
            TextCol.Width = 150;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluutru";
			TextCol.HeaderText = "Số lưu trữ";
            TextCol.Width = 80; 
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "khoanhap";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngaysanh";
			TextCol.HeaderText = "Ngày sanh dự đoán";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenuser";
			TextCol.HeaderText = "Người nhập";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
					return;
				}
                string _ngay = "";
                if (chkXML.Checked) ds.WriteXml("tiemchung.xml", XmlWriteMode.WriteSchema);
                if (tu.Text != "")
                    _ngay = (tu.Text == den.Text) ? " Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,this.Text.ToUpper()+" "+_ngay.ToUpper(),"rptTkTiemchung.rpt");
				f.ShowDialog();
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_quan();
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_pxa();
		}

		private void frmTktiemchung_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTktiemchung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dotuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chkmaicd_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (chkmaicd.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmbcicd f=new frmDmbcicd(m);
					f.ShowDialog();
				}
			}		
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			string s_mabn="",s_ngay="";
            decimal l_maql = 0;
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				s_mabn=dataGrid1[i,1].ToString();
				s_ngay=dataGrid1[i,10].ToString().Substring(0,10);
                l_maql=decimal.Parse(dataGrid1[i,24].ToString());
			}
            catch { }
		}

        private void butTuongtac_Click(object sender, EventArgs e)
        {
            testc.clsTuongtac t = new testc.clsTuongtac();
            bool b_tuongtac = t.kiemtra_tuongtac(dst.Tables[0], i_nhom);
        }

        private void madoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
	}
}
