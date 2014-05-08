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
	/// Summary description for frmHoichancc.
	/// </summary>
	public class frmHoichancc : System.Windows.Forms.Form
	{
        
Language lan = new Language();
Bogotiengviet tv = new Bogotiengviet();
private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();	


		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ngayvv;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox lmau;
		private System.Windows.Forms.TextBox tenmau;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.TextBox phuongphap;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox rh;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox rb0;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.CheckBox rb1;
		private System.Windows.Forms.CheckBox rb3;
		private System.Windows.Forms.CheckBox rb2;
		private System.Windows.Forms.CheckBox rb5;
		private System.Windows.Forms.CheckBox rb4;
		private System.Windows.Forms.CheckBox rb7;
		private System.Windows.Forms.CheckBox rb6;
		private System.Windows.Forms.CheckBox rb9;
		private System.Windows.Forms.CheckBox rb8;
		private System.Windows.Forms.CheckBox rb10;
		private MaskedTextBox.MaskedTextBox mau;
		private System.Windows.Forms.ComboBox nhommau;
		private System.Windows.Forms.Label label23;
		private MaskedBox.MaskedBox giomo;
		private MaskedBox.MaskedBox ngaymo;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox xnkhac;
		private System.Windows.Forms.TextBox ykien;
		private System.Windows.Forms.Label label26;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.TextBox tenbstruongk;
		private System.Windows.Forms.TextBox bstruongk;
		private System.Windows.Forms.TextBox tenptv;
		private System.Windows.Forms.TextBox ptv;
		private System.Windows.Forms.TextBox tengayme;
		private System.Windows.Forms.TextBox gayme;
		private System.Windows.Forms.TextBox tuthe;
		private System.Windows.Forms.TextBox tenptphu;
		private System.Windows.Forms.TextBox tenptdutru;
		private System.Windows.Forms.TextBox ptdutru;
		private System.Windows.Forms.TextBox ptphu;
		private System.Windows.Forms.TextBox tenptchinh;
		private System.Windows.Forms.TextBox ptchinh;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.ComboBox mallampati;
		private System.Windows.Forms.ComboBox glodmann;
		private System.Windows.Forms.ComboBox asa;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butBoqua;
		private LibList.List listBS;
		private LibList.List listpttt;
		private MaskedTextBox.MaskedTextBox mamau;
		private DataTable dtbs=new DataTable();
		private DataTable dtmau=new DataTable();
		private DataSet dsmau=new DataSet();
		private DataSet dslmau=new DataSet();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.TextBox chandoan;
		private AccessData m;
		private string sql,s_mabn,s_makp,user,xxx,s_tenkp,s_sovaovien,s_ngayvv;
		private int i_userid;
		private decimal l_maql,l_id=0,l_idkhoa,l_idthuchien,l_duyet;
		private bool bAdmin;
		public bool bUpdate=false;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butKetthuc;
		private AsYetUnnamedColor.MultiColumnListBoxColor list;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox tiensu;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.TextBox phoi;
		private System.Windows.Forms.TextBox khac;
		private System.Windows.Forms.TextBox cotsong;
		private System.Windows.Forms.TextBox tienluong;
		private System.Windows.Forms.TextBox thankinh;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox anlancuoi;
		private System.Windows.Forms.Label label36;
		private System.ComponentModel.IContainer components;

		public frmHoichancc(AccessData acc,DataSet _ds,decimal _id,decimal _idthuchien,string _mabn,string _makp,string _tenkp,int userid,bool _admin,string _ngayvv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;ds=_ds;l_id=_id;s_mabn=_mabn;s_makp=_makp;s_tenkp=_tenkp;i_userid=userid;bAdmin=_admin;
			l_idthuchien=_idthuchien;l_duyet=l_id;s_ngayvv=_ngayvv;
            
lan.Read_Language_to_Xml(this.Name.ToString(),this);
lan.Changelanguage_to_English(this.Name.ToString(),this);

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoichancc));
            this.listBS = new LibList.List();
            this.listpttt = new LibList.List();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.tenbstruongk = new System.Windows.Forms.TextBox();
            this.bstruongk = new System.Windows.Forms.TextBox();
            this.tenptv = new System.Windows.Forms.TextBox();
            this.ptv = new System.Windows.Forms.TextBox();
            this.tengayme = new System.Windows.Forms.TextBox();
            this.gayme = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ykien = new System.Windows.Forms.TextBox();
            this.xnkhac = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.nhommau = new System.Windows.Forms.ComboBox();
            this.mau = new MaskedTextBox.MaskedTextBox();
            this.rb10 = new System.Windows.Forms.CheckBox();
            this.rb9 = new System.Windows.Forms.CheckBox();
            this.rb8 = new System.Windows.Forms.CheckBox();
            this.rb7 = new System.Windows.Forms.CheckBox();
            this.rb6 = new System.Windows.Forms.CheckBox();
            this.rb5 = new System.Windows.Forms.CheckBox();
            this.rb4 = new System.Windows.Forms.CheckBox();
            this.rb3 = new System.Windows.Forms.CheckBox();
            this.rb2 = new System.Windows.Forms.CheckBox();
            this.rb1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rb0 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rh = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tuthe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.giomo = new MaskedBox.MaskedBox();
            this.ngaymo = new MaskedBox.MaskedBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tenptphu = new System.Windows.Forms.TextBox();
            this.tenptdutru = new System.Windows.Forms.TextBox();
            this.ptdutru = new System.Windows.Forms.TextBox();
            this.ptphu = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tenptchinh = new System.Windows.Forms.TextBox();
            this.ptchinh = new System.Windows.Forms.TextBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.phuongphap = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.giuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tenmau = new System.Windows.Forms.TextBox();
            this.lmau = new System.Windows.Forms.ComboBox();
            this.mamau = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.mallampati = new System.Windows.Forms.ComboBox();
            this.glodmann = new System.Windows.Forms.ComboBox();
            this.asa = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.list = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tiensu = new System.Windows.Forms.TextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.phoi = new System.Windows.Forms.TextBox();
            this.khac = new System.Windows.Forms.TextBox();
            this.cotsong = new System.Windows.Forms.TextBox();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.thankinh = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.anlancuoi = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(82, 29);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 367;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(82, 53);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 369;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(52, 111);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(62, 21);
            this.chandoan.TabIndex = 7;
            // 
            // tenbstruongk
            // 
            this.tenbstruongk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbstruongk.Enabled = false;
            this.tenbstruongk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbstruongk.Location = new System.Drawing.Point(389, 268);
            this.tenbstruongk.Name = "tenbstruongk";
            this.tenbstruongk.Size = new System.Drawing.Size(216, 21);
            this.tenbstruongk.TabIndex = 38;
            this.tenbstruongk.TextChanged += new System.EventHandler(this.tenbstruongk_TextChanged);
            this.tenbstruongk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // bstruongk
            // 
            this.bstruongk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bstruongk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bstruongk.Enabled = false;
            this.bstruongk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstruongk.Location = new System.Drawing.Point(350, 268);
            this.bstruongk.MaxLength = 4;
            this.bstruongk.Name = "bstruongk";
            this.bstruongk.Size = new System.Drawing.Size(38, 21);
            this.bstruongk.TabIndex = 37;
            this.bstruongk.Validated += new System.EventHandler(this.bstruongk_Validated);
            this.bstruongk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tenptv
            // 
            this.tenptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptv.Enabled = false;
            this.tenptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptv.Location = new System.Drawing.Point(389, 291);
            this.tenptv.Name = "tenptv";
            this.tenptv.Size = new System.Drawing.Size(216, 21);
            this.tenptv.TabIndex = 40;
            this.tenptv.TextChanged += new System.EventHandler(this.tenptv_TextChanged);
            this.tenptv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptv
            // 
            this.ptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptv.Enabled = false;
            this.ptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptv.Location = new System.Drawing.Point(350, 291);
            this.ptv.MaxLength = 4;
            this.ptv.Name = "ptv";
            this.ptv.Size = new System.Drawing.Size(38, 21);
            this.ptv.TabIndex = 39;
            this.ptv.Validated += new System.EventHandler(this.ptv_Validated);
            this.ptv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tengayme
            // 
            this.tengayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tengayme.Enabled = false;
            this.tengayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tengayme.Location = new System.Drawing.Point(389, 528);
            this.tengayme.Name = "tengayme";
            this.tengayme.Size = new System.Drawing.Size(216, 21);
            this.tengayme.TabIndex = 54;
            this.tengayme.TextChanged += new System.EventHandler(this.tengayme_TextChanged);
            this.tengayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // gayme
            // 
            this.gayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gayme.Enabled = false;
            this.gayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gayme.Location = new System.Drawing.Point(350, 528);
            this.gayme.MaxLength = 4;
            this.gayme.Name = "gayme";
            this.gayme.Size = new System.Drawing.Size(38, 21);
            this.gayme.TabIndex = 53;
            this.gayme.Validated += new System.EventHandler(this.gayme_Validated);
            this.gayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(239, 295);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(112, 16);
            this.label33.TabIndex = 355;
            this.label33.Text = "BS Phẫu thuật viên :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(190, 272);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(160, 16);
            this.label32.TabIndex = 354;
            this.label32.Text = "BS Trưởng kíp trực ngoại :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(233, 529);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(120, 16);
            this.label31.TabIndex = 353;
            this.label31.Text = "Bác sĩ gây mê :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(754, 506);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 52;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(715, 506);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 16);
            this.label26.TabIndex = 349;
            this.label26.Text = "Ngày :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ykien
            // 
            this.ykien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ykien.Enabled = false;
            this.ykien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ykien.Location = new System.Drawing.Point(350, 236);
            this.ykien.Multiline = true;
            this.ykien.Name = "ykien";
            this.ykien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ykien.Size = new System.Drawing.Size(476, 31);
            this.ykien.TabIndex = 36;
            // 
            // xnkhac
            // 
            this.xnkhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xnkhac.Enabled = false;
            this.xnkhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xnkhac.Location = new System.Drawing.Point(350, 78);
            this.xnkhac.Multiline = true;
            this.xnkhac.Name = "xnkhac";
            this.xnkhac.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xnkhac.Size = new System.Drawing.Size(476, 42);
            this.xnkhac.TabIndex = 22;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(188, 242);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(216, 16);
            this.label25.TabIndex = 343;
            this.label25.Text = "Ý kiến hội chẩn về bệnh kết hợp :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(198, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(144, 16);
            this.label23.TabIndex = 341;
            this.label23.Text = "Các xét nghiệm khác :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhommau
            // 
            this.nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhommau.Enabled = false;
            this.nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhommau.Location = new System.Drawing.Point(413, 2);
            this.nhommau.Name = "nhommau";
            this.nhommau.Size = new System.Drawing.Size(65, 21);
            this.nhommau.TabIndex = 8;
            this.nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhommau_KeyDown);
            // 
            // mau
            // 
            this.mau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mau.Enabled = false;
            this.mau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mau.Location = new System.Drawing.Point(698, 2);
            this.mau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mau.MaxLength = 5;
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(40, 21);
            this.mau.TabIndex = 10;
            this.mau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rb10
            // 
            this.rb10.BackColor = System.Drawing.SystemColors.Control;
            this.rb10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb10.Enabled = false;
            this.rb10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb10.Location = new System.Drawing.Point(729, 41);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(94, 16);
            this.rb10.TabIndex = 21;
            this.rb10.Text = "Siêu âm bụng";
            this.rb10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb10.UseVisualStyleBackColor = false;
            this.rb10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb9
            // 
            this.rb9.BackColor = System.Drawing.SystemColors.Control;
            this.rb9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb9.Enabled = false;
            this.rb9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb9.Location = new System.Drawing.Point(633, 57);
            this.rb9.Name = "rb9";
            this.rb9.Size = new System.Drawing.Size(80, 16);
            this.rb9.TabIndex = 20;
            this.rb9.Text = "XQ phổi";
            this.rb9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb9.UseVisualStyleBackColor = false;
            this.rb9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb8
            // 
            this.rb8.BackColor = System.Drawing.SystemColors.Control;
            this.rb8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb8.Enabled = false;
            this.rb8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb8.Location = new System.Drawing.Point(625, 41);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(88, 16);
            this.rb8.TabIndex = 19;
            this.rb8.Text = "ECG";
            this.rb8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb8.UseVisualStyleBackColor = false;
            this.rb8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb7
            // 
            this.rb7.BackColor = System.Drawing.SystemColors.Control;
            this.rb7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb7.Enabled = false;
            this.rb7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb7.Location = new System.Drawing.Point(525, 57);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(96, 16);
            this.rb7.TabIndex = 18;
            this.rb7.Text = "Đường huyết";
            this.rb7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb7.UseVisualStyleBackColor = false;
            this.rb7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb6
            // 
            this.rb6.BackColor = System.Drawing.SystemColors.Control;
            this.rb6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb6.Enabled = false;
            this.rb6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb6.Location = new System.Drawing.Point(541, 41);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(80, 16);
            this.rb6.TabIndex = 17;
            this.rb6.Text = "Creatinin";
            this.rb6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb6.UseVisualStyleBackColor = false;
            this.rb6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb5
            // 
            this.rb5.BackColor = System.Drawing.SystemColors.Control;
            this.rb5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb5.Enabled = false;
            this.rb5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb5.Location = new System.Drawing.Point(458, 57);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(64, 16);
            this.rb5.TabIndex = 16;
            this.rb5.Text = "Urê";
            this.rb5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb5.UseVisualStyleBackColor = false;
            this.rb5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb4
            // 
            this.rb4.BackColor = System.Drawing.SystemColors.Control;
            this.rb4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb4.Enabled = false;
            this.rb4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb4.Location = new System.Drawing.Point(458, 41);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(64, 16);
            this.rb4.TabIndex = 15;
            this.rb4.Text = "TCK";
            this.rb4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb4.UseVisualStyleBackColor = false;
            this.rb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb3
            // 
            this.rb3.BackColor = System.Drawing.SystemColors.Control;
            this.rb3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb3.Enabled = false;
            this.rb3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb3.Location = new System.Drawing.Point(386, 57);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(64, 16);
            this.rb3.TabIndex = 14;
            this.rb3.Text = "TQ";
            this.rb3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb3.UseVisualStyleBackColor = false;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb2
            // 
            this.rb2.BackColor = System.Drawing.SystemColors.Control;
            this.rb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb2.Enabled = false;
            this.rb2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb2.Location = new System.Drawing.Point(386, 41);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(64, 16);
            this.rb2.TabIndex = 13;
            this.rb2.Text = "TS";
            this.rb2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb2.UseVisualStyleBackColor = false;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb1
            // 
            this.rb1.BackColor = System.Drawing.SystemColors.Control;
            this.rb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb1.Enabled = false;
            this.rb1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb1.Location = new System.Drawing.Point(266, 57);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(96, 16);
            this.rb1.TabIndex = 12;
            this.rb1.Text = "TPT nước tiểu";
            this.rb1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(350, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 16);
            this.label16.TabIndex = 307;
            this.label16.Text = "( Gạch chéo vào ô : Bất thường □ )";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rb0
            // 
            this.rb0.BackColor = System.Drawing.SystemColors.Control;
            this.rb0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb0.Enabled = false;
            this.rb0.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb0.Location = new System.Drawing.Point(266, 41);
            this.rb0.Name = "rb0";
            this.rb0.Size = new System.Drawing.Size(96, 16);
            this.rb0.TabIndex = 11;
            this.rb0.Text = "CTM";
            this.rb0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb0.UseVisualStyleBackColor = false;
            this.rb0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(206, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 16);
            this.label13.TabIndex = 305;
            this.label13.Text = "Xét nghiệm tiền phẩu";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(746, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 304;
            this.label12.Text = "Đơn vị";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(622, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 303;
            this.label11.Text = "Dự trù máu :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rh
            // 
            this.rh.BackColor = System.Drawing.SystemColors.Control;
            this.rh.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rh.Enabled = false;
            this.rh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rh.Location = new System.Drawing.Point(480, 4);
            this.rh.Name = "rh";
            this.rh.Size = new System.Drawing.Size(72, 16);
            this.rh.TabIndex = 9;
            this.rh.Text = "Rh (        )";
            this.rh.UseVisualStyleBackColor = false;
            this.rh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(331, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 301;
            this.label8.Text = "Nhóm máu :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuthe
            // 
            this.tuthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuthe.Enabled = false;
            this.tuthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuthe.Location = new System.Drawing.Point(666, 214);
            this.tuthe.Name = "tuthe";
            this.tuthe.Size = new System.Drawing.Size(160, 21);
            this.tuthe.TabIndex = 35;
            this.tuthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(603, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 295;
            this.label5.Text = "Tư thế mổ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giomo
            // 
            this.giomo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giomo.Enabled = false;
            this.giomo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giomo.Location = new System.Drawing.Point(785, 191);
            this.giomo.Mask = "##:##";
            this.giomo.Name = "giomo";
            this.giomo.Size = new System.Drawing.Size(40, 21);
            this.giomo.TabIndex = 32;
            this.giomo.Text = "  :  ";
            this.giomo.Validated += new System.EventHandler(this.giomo_Validated);
            // 
            // ngaymo
            // 
            this.ngaymo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaymo.Enabled = false;
            this.ngaymo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaymo.Location = new System.Drawing.Point(666, 191);
            this.ngaymo.Mask = "##/##/####";
            this.ngaymo.Name = "ngaymo";
            this.ngaymo.Size = new System.Drawing.Size(72, 21);
            this.ngaymo.TabIndex = 31;
            this.ngaymo.Text = "  /  /    ";
            this.ngaymo.Validated += new System.EventHandler(this.ngaymo_Validated);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label89.Location = new System.Drawing.Point(753, 193);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(32, 16);
            this.label89.TabIndex = 294;
            this.label89.Text = "Giờ :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label70.Location = new System.Drawing.Point(603, 193);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(64, 16);
            this.label70.TabIndex = 293;
            this.label70.Text = "Ngày mổ :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenptphu
            // 
            this.tenptphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptphu.Enabled = false;
            this.tenptphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptphu.Location = new System.Drawing.Point(389, 191);
            this.tenptphu.Name = "tenptphu";
            this.tenptphu.Size = new System.Drawing.Size(216, 21);
            this.tenptphu.TabIndex = 30;
            this.tenptphu.TextChanged += new System.EventHandler(this.tenptphu_TextChanged);
            this.tenptphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // tenptdutru
            // 
            this.tenptdutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptdutru.Enabled = false;
            this.tenptdutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptdutru.Location = new System.Drawing.Point(389, 144);
            this.tenptdutru.Name = "tenptdutru";
            this.tenptdutru.Size = new System.Drawing.Size(216, 21);
            this.tenptdutru.TabIndex = 26;
            this.tenptdutru.TextChanged += new System.EventHandler(this.tenptdutru_TextChanged);
            this.tenptdutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptdutru
            // 
            this.ptdutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptdutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptdutru.Enabled = false;
            this.ptdutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptdutru.Location = new System.Drawing.Point(350, 144);
            this.ptdutru.MaxLength = 4;
            this.ptdutru.Name = "ptdutru";
            this.ptdutru.Size = new System.Drawing.Size(38, 21);
            this.ptdutru.TabIndex = 25;
            this.ptdutru.Validated += new System.EventHandler(this.ptdutru_Validated);
            this.ptdutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // ptphu
            // 
            this.ptphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptphu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptphu.Enabled = false;
            this.ptphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptphu.Location = new System.Drawing.Point(350, 191);
            this.ptphu.MaxLength = 4;
            this.ptphu.Name = "ptphu";
            this.ptphu.Size = new System.Drawing.Size(38, 21);
            this.ptphu.TabIndex = 29;
            this.ptphu.Validated += new System.EventHandler(this.ptphu_Validated);
            this.ptphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(238, 146);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 16);
            this.label30.TabIndex = 68;
            this.label30.Text = "Phẫu thuật dự trù :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(230, 193);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "Phẫu thuật viên phụ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenptchinh
            // 
            this.tenptchinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptchinh.Enabled = false;
            this.tenptchinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptchinh.Location = new System.Drawing.Point(389, 167);
            this.tenptchinh.Name = "tenptchinh";
            this.tenptchinh.Size = new System.Drawing.Size(216, 21);
            this.tenptchinh.TabIndex = 28;
            this.tenptchinh.TextChanged += new System.EventHandler(this.tenptchinh_TextChanged);
            this.tenptchinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptchinh
            // 
            this.ptchinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptchinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptchinh.Enabled = false;
            this.ptchinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptchinh.Location = new System.Drawing.Point(350, 167);
            this.ptchinh.MaxLength = 4;
            this.ptchinh.Name = "ptchinh";
            this.ptchinh.Size = new System.Drawing.Size(38, 21);
            this.ptchinh.TabIndex = 27;
            this.ptchinh.Validated += new System.EventHandler(this.ptchinh_Validated);
            this.ptchinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphuongphap.Enabled = false;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(375, 214);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(231, 21);
            this.tenphuongphap.TabIndex = 34;
            this.tenphuongphap.SelectedIndexChanged += new System.EventHandler(this.tenphuongphap_SelectedIndexChanged);
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // phuongphap
            // 
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(350, 214);
            this.phuongphap.MaxLength = 2;
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(24, 21);
            this.phuongphap.TabIndex = 33;
            this.phuongphap.Validated += new System.EventHandler(this.phuongphap_Validated);
            this.phuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phuongphap_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(207, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 23);
            this.label14.TabIndex = 66;
            this.label14.Text = "Phẫu thuật viên chính :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(190, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 16);
            this.label9.TabIndex = 65;
            this.label9.Text = "Phương pháp vô cảm đề nghị :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(52, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Location = new System.Drawing.Point(52, 111);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(62, 20);
            this.mabn.TabIndex = 0;
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(52, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 55;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(52, 111);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(62, 21);
            this.hoten.TabIndex = 1;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(52, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tuổi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(52, 111);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(62, 21);
            this.tuoi.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(52, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 19);
            this.label15.TabIndex = 57;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(52, 111);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(62, 21);
            this.phai.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(52, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 19);
            this.label17.TabIndex = 58;
            this.label17.Text = "Số thẻ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(52, 111);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(62, 21);
            this.sothe.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(52, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 16);
            this.label18.TabIndex = 59;
            this.label18.Text = "Số giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(52, 111);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(62, 21);
            this.giuong.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(52, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Ngày vào :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(52, 111);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(62, 21);
            this.ngayvv.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(52, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "Chẩn đoán :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(190, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 23);
            this.label10.TabIndex = 67;
            this.label10.Text = "Phương pháp phẫu thủ thuật :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenmau
            // 
            this.tenmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenmau.Enabled = false;
            this.tenmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmau.Location = new System.Drawing.Point(350, 121);
            this.tenmau.Name = "tenmau";
            this.tenmau.Size = new System.Drawing.Size(120, 21);
            this.tenmau.TabIndex = 23;
            this.tenmau.TextChanged += new System.EventHandler(this.tenmau_TextChanged);
            this.tenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenmau_KeyDown);
            // 
            // lmau
            // 
            this.lmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmau.Enabled = false;
            this.lmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmau.Location = new System.Drawing.Point(470, 121);
            this.lmau.Name = "lmau";
            this.lmau.Size = new System.Drawing.Size(356, 21);
            this.lmau.TabIndex = 24;
            this.lmau.SelectedIndexChanged += new System.EventHandler(this.lmau_SelectedIndexChanged);
            this.lmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmau_KeyDown);
            // 
            // mamau
            // 
            this.mamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mamau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mamau.Enabled = false;
            this.mamau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamau.Location = new System.Drawing.Point(112, 40);
            this.mamau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mamau.MaxLength = 10;
            this.mamau.Name = "mamau";
            this.mamau.Size = new System.Drawing.Size(16, 21);
            this.mamau.TabIndex = 370;
            this.mamau.Validated += new System.EventHandler(this.mamau_Validated);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(389, 549);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(216, 21);
            this.tenbs.TabIndex = 56;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(350, 549);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 55;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label82
            // 
            this.label82.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label82.Location = new System.Drawing.Point(208, 554);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(144, 16);
            this.label82.TabIndex = 401;
            this.label82.Text = "BS Trưởng kíp trực GMHS :";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mallampati
            // 
            this.mallampati.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mallampati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mallampati.Enabled = false;
            this.mallampati.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mallampati.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV"});
            this.mallampati.Location = new System.Drawing.Point(565, 506);
            this.mallampati.Name = "mallampati";
            this.mallampati.Size = new System.Drawing.Size(40, 21);
            this.mallampati.TabIndex = 51;
            this.mallampati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallampati_KeyDown);
            // 
            // glodmann
            // 
            this.glodmann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.glodmann.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.glodmann.Enabled = false;
            this.glodmann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glodmann.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV"});
            this.glodmann.Location = new System.Drawing.Point(450, 506);
            this.glodmann.Name = "glodmann";
            this.glodmann.Size = new System.Drawing.Size(40, 21);
            this.glodmann.TabIndex = 50;
            this.glodmann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glodmann_KeyDown);
            // 
            // asa
            // 
            this.asa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.asa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asa.Enabled = false;
            this.asa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V"});
            this.asa.Location = new System.Drawing.Point(350, 506);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(40, 21);
            this.asa.TabIndex = 49;
            this.asa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.asa_KeyDown);
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label79.Location = new System.Drawing.Point(498, 509);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(72, 16);
            this.label79.TabIndex = 93;
            this.label79.Text = "Mallampati :";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label78.Location = new System.Drawing.Point(394, 509);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(64, 16);
            this.label78.TabIndex = 91;
            this.label78.Text = "Goldmann :";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label77.Location = new System.Drawing.Point(306, 509);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(40, 16);
            this.label77.TabIndex = 89;
            this.label77.Text = "ASA :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label74.Location = new System.Drawing.Point(194, 506);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(120, 17);
            this.label74.TabIndex = 382;
            this.label74.Text = "3. Đánh giá gây mê :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(0, 555);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 16);
            this.chkXML.TabIndex = 61;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(0, 445);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(182, 25);
            this.butLuu.TabIndex = 57;
            this.butLuu.Text = "           &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(0, 495);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(182, 25);
            this.butIn.TabIndex = 60;
            this.butIn.Text = "           &In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(0, 470);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(182, 25);
            this.butBoqua.TabIndex = 58;
            this.butBoqua.Text = "           &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 2);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(182, 407);
            this.list.TabIndex = 60;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F7 chọn");
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(0, 520);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(182, 25);
            this.butKetthuc.TabIndex = 61;
            this.butKetthuc.Text = "           &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(0, 420);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(182, 25);
            this.butMoi.TabIndex = 59;
            this.butMoi.Text = "           &Thêm";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(161, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 402;
            this.label6.Text = "KHÁM TIỀN MÊ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(170, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(192, 16);
            this.label19.TabIndex = 403;
            this.label19.Text = "TÌNH TRẠNG BỆNH NHÂN";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(187, 328);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(160, 16);
            this.label20.TabIndex = 404;
            this.label20.Text = "1. Tiền sử :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(186, 342);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(160, 16);
            this.label21.TabIndex = 405;
            this.label21.Text = "2. Khám các cơ quan :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(226, 359);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 406;
            this.label22.Text = "- Tim :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(226, 378);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 407;
            this.label24.Text = "- Phổi :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(226, 443);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 16);
            this.label27.TabIndex = 408;
            this.label27.Text = "- Cơ quan khác :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(226, 424);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 16);
            this.label28.TabIndex = 409;
            this.label28.Text = "- Cột sống :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(226, 488);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(120, 16);
            this.label34.TabIndex = 410;
            this.label34.Text = "- Tiên lượng đặt NKQ :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tiensu
            // 
            this.tiensu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tiensu.Enabled = false;
            this.tiensu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiensu.Location = new System.Drawing.Point(350, 313);
            this.tiensu.Multiline = true;
            this.tiensu.Name = "tiensu";
            this.tiensu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tiensu.Size = new System.Drawing.Size(476, 35);
            this.tiensu.TabIndex = 41;
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Enabled = false;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(350, 351);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(476, 21);
            this.tim.TabIndex = 42;
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // phoi
            // 
            this.phoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phoi.Enabled = false;
            this.phoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoi.Location = new System.Drawing.Point(350, 374);
            this.phoi.Name = "phoi";
            this.phoi.Size = new System.Drawing.Size(476, 21);
            this.phoi.TabIndex = 43;
            this.phoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // khac
            // 
            this.khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(350, 440);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(476, 21);
            this.khac.TabIndex = 46;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // cotsong
            // 
            this.cotsong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cotsong.Enabled = false;
            this.cotsong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cotsong.Location = new System.Drawing.Point(350, 418);
            this.cotsong.Name = "cotsong";
            this.cotsong.Size = new System.Drawing.Size(476, 21);
            this.cotsong.TabIndex = 45;
            this.cotsong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(350, 484);
            this.tienluong.Name = "tienluong";
            this.tienluong.Size = new System.Drawing.Size(476, 21);
            this.tienluong.TabIndex = 48;
            this.tienluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // thankinh
            // 
            this.thankinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thankinh.Enabled = false;
            this.thankinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh.Location = new System.Drawing.Point(350, 396);
            this.thankinh.Name = "thankinh";
            this.thankinh.Size = new System.Drawing.Size(476, 21);
            this.thankinh.TabIndex = 44;
            this.thankinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(226, 401);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(64, 16);
            this.label35.TabIndex = 412;
            this.label35.Text = "- Thần kinh :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // anlancuoi
            // 
            this.anlancuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.anlancuoi.Enabled = false;
            this.anlancuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anlancuoi.Location = new System.Drawing.Point(350, 462);
            this.anlancuoi.Name = "anlancuoi";
            this.anlancuoi.Size = new System.Drawing.Size(476, 21);
            this.anlancuoi.TabIndex = 47;
            this.anlancuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(226, 466);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(120, 16);
            this.label36.TabIndex = 414;
            this.label36.Text = "- Ăn lần cuối :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHoichancc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.tenptphu);
            this.Controls.Add(this.tenptdutru);
            this.Controls.Add(this.anlancuoi);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.thankinh);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.ykien);
            this.Controls.Add(this.tuthe);
            this.Controls.Add(this.ptchinh);
            this.Controls.Add(this.ngaymo);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.ptv);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.glodmann);
            this.Controls.Add(this.mallampati);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.tienluong);
            this.Controls.Add(this.cotsong);
            this.Controls.Add(this.khac);
            this.Controls.Add(this.phoi);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.tiensu);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.list);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.tenphuongphap);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.phuongphap);
            this.Controls.Add(this.tenmau);
            this.Controls.Add(this.giomo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ptphu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tenptchinh);
            this.Controls.Add(this.ptdutru);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.lmau);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nhommau);
            this.Controls.Add(this.rh);
            this.Controls.Add(this.mau);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rb6);
            this.Controls.Add(this.rb5);
            this.Controls.Add(this.rb4);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb10);
            this.Controls.Add(this.rb0);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb8);
            this.Controls.Add(this.rb7);
            this.Controls.Add(this.rb9);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.mamau);
            this.Controls.Add(this.xnkhac);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.bstruongk);
            this.Controls.Add(this.tenbstruongk);
            this.Controls.Add(this.gayme);
            this.Controls.Add(this.tengayme);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.tenptv);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.asa);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHoichancc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hội chẩn mổ cấp cứu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoichancc_KeyDown);
            this.Load += new System.EventHandler(this.frmHoichancc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHoichancc_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;
            dsmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp,image1,image2 from " + user + ".pttt_mau order by ma");
            dsmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' noidung,cast(0 as numeric) as mavp,image1,image2 from " + user + ".dmpttt order by mapt"));
			ngayvv.Text=s_ngayvv;
			xxx=m.user+m.mmyy(s_ngayvv);
			
			list.DisplayMember="NGAY";
			list.ValueMember="ID";
			load_list();
			list.ColumnWidths[0]=80;
			list.ColumnWidths[1]=list.Width-80;

			listpttt.DisplayMember="TEN";
			listpttt.ValueMember="MA";
			listpttt.DataSource=dsmau.Tables[0];

			lmau.DisplayMember="TEN";
			lmau.ValueMember="MA";

			tenphuongphap.DisplayMember="TEN";
			tenphuongphap.ValueMember="MA";
            tenphuongphap.DataSource = m.get_data("select * from " + user + ".dmmete order by ma").Tables[0];

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

			nhommau.DisplayMember="TEN";
			nhommau.ValueMember="MA";
            nhommau.DataSource = m.get_data("select * from " + user + ".dmnhommau order by ma").Tables[0];
			asa.SelectedIndex=0;glodmann.SelectedIndex=0;mallampati.SelectedIndex=0;			
			get_mabn(s_mabn);
		}

		private void load_list()
		{
			sql="select to_char(ngay,'dd/mm/yyyy') as ngay,to_char(ngaymo,'dd/mm/yyyy hh24:mi') as ngaymo,id from "+xxx+".ba_hoichancc ";
			if (l_id!=0) sql+=" where id="+l_id;
			else sql+=" where idthuchien="+l_idthuchien;
			sql+=" order by ngay";
			list.DataSource=m.get_data(sql).Tables[0];
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}

		private void asa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (asa.SelectedIndex==-1) asa.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void glodmann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (glodmann.SelectedIndex==-1) glodmann.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mallampati_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mallampati.SelectedIndex==-1) mallampati.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void gan_text(string s,TextBox ma,TextBox ten)
		{
			if (s!="")
			{
				ma.Text=s;
				DataRow r=m.getrowbyid(dtbs,"ma='"+s+"'");
				if (r!=null) ten.Text=r["hoten"].ToString();
				else ten.Text="";
			}
			else 
			{
				ma.Text="";
				ten.Text="";
			}
		}

		private void ptdutru_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptdutru.Text,ptdutru,tenptdutru);
		}

		private void ptchinh_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptchinh.Text,ptchinh,tenptchinh);
		}

		private void ptphu_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptphu.Text,ptphu,tenptphu);
		}

		private void gayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(gayme.Text,gayme,tengayme);
		}

		private void bstruongk_Validated(object sender, System.EventArgs e)
		{
			gan_text(bstruongk.Text,bstruongk,tenbstruongk);
		}

		private void ptv_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptv.Text,ptv,tenptv);
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			gan_text(mabs.Text,mabs,tenbs);
		}

		private void tenptdutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,butLuu,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
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

		private void tenptdutru_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptdutru)
			{
				Filt_tenbs(tenptdutru.Text);
				listBS.BrowseToICD10(tenptdutru,ptdutru,ptchinh,ptdutru.Location.X,ptdutru.Location.Y+ptdutru.Height,ptdutru.Width+tenptdutru.Width+2,ptdutru.Height);
			}				
		}

		private void tenptchinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptchinh)
			{
				Filt_tenbs(tenptchinh.Text);
				listBS.BrowseToICD10(tenptchinh,ptchinh,ptphu,ptchinh.Location.X,ptchinh.Location.Y+ptchinh.Height,ptchinh.Width+tenptchinh.Width+2,ptchinh.Height);
			}				
		}

		private void tenptphu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptphu)
			{
				Filt_tenbs(tenptphu.Text);
				listBS.BrowseToICD10(tenptphu,ptphu,ngaymo,ptphu.Location.X,ptphu.Location.Y+ptphu.Height,ptphu.Width+tenptphu.Width+2,ptphu.Height);
			}				
		}

		private void tengayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tengayme)
			{
				Filt_tenbs(tengayme.Text);
				listBS.BrowseToICD10(tengayme,gayme,mabs,gayme.Location.X,gayme.Location.Y+gayme.Height,gayme.Width+tengayme.Width+2,gayme.Height);
			}				
		}

		private void tenbstruongk_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbstruongk)
			{
				Filt_tenbs(tenbstruongk.Text);
				listBS.BrowseToICD10(tenbstruongk,bstruongk,ptv,bstruongk.Location.X,bstruongk.Location.Y+bstruongk.Height,bstruongk.Width+tenbstruongk.Width+2,bstruongk.Height);
			}						
		}

		private void tenptv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptv)
			{
				Filt_tenbs(tenptv.Text);
				listBS.BrowseToICD10(tenptv,ptv,tiensu,ptv.Location.X,ptv.Location.Y+ptv.Height,ptv.Width+tenptv.Width+2,ptv.Height);
			}						
		}

		private void tenmau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void load_mau(string ma)
		{
            dslmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp from " + user + ".pttt_mau where ma like '%" + ma.Trim() + "%' order by ma");
            dslmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,cast(0 as numeric) as mavp from " + user + ".dmpttt where mapt like '%" + ma.Trim() + "%' order by mapt"));
			lmau.DataSource=dslmau.Tables[0];
		}

		private void tenmau_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenmau)
			{
				Filt_pttt(tenmau.Text);
				listpttt.BrowseToPTTT(tenmau,mamau,lmau,tenmau.Location.X,tenmau.Location.Y+tenmau.Height,tenmau.Width+lmau.Width,tenmau.Height);
			}
		}

		private void lmau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (lmau.SelectedIndex==-1 && lmau.Items.Count>0) lmau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void lmau_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmau)
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+lmau.SelectedValue.ToString()+"'");
				if (r!=null) tenmau.Text=r["ma"].ToString();
			}
		}

		private void mamau_Validated(object sender, System.EventArgs e)
		{
			if (mamau.Text!="")
			{
				DataRow r=m.getrowbyid(dsmau.Tables[0],"ma='"+mamau.Text+"'");
				if (r!=null)
				{
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
				}
			}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			mamau_Validated(sender,e);
		}

		private void frmHoichancc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if (butMoi.Enabled) butMoi_Click(sender,e);
					break;
				case Keys.F5:
					if (butLuu.Enabled) butLuu_Click(sender,e);
					break;
				case Keys.F7: if (list.Enabled) list_DoubleClick(sender,e);
					break;
				case Keys.F8:
					if (butBoqua.Enabled) butBoqua_Click(sender,e);
					break;
				case Keys.F9:
					if (butIn.Enabled) butIn_Click(sender,e);
					break;
				case Keys.F10:
					if (butKetthuc.Enabled) butKetthuc_Click(sender,e);
					break;
			}		
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten LIKE '%"+ten.Trim()+"%' or ma like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void get_mabn(string _mabn)
		{
			emp_text();
			string m_tuoivao="",m_loaituoi="TU";
			sql=(l_duyet!=0)?"id="+l_id:"mabn='"+_mabn+"'";
			DataRow r=m.getrowbyid(ds.Tables[0],sql);
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				m_tuoivao=r["tuoivao"].ToString();
				if (m_tuoivao.Length==4)
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
				}
				if(m_tuoivao.Length>=3)tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
                else tuoi.Text = m_tuoivao + m_loaituoi;
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
                try { giuong.Text = r["giuong"].ToString(); }
                catch { }
				sothe.Text=r["sothe"].ToString();
				chandoan.Text=r["chandoan"].ToString();
                try { l_idkhoa = decimal.Parse(r["id"].ToString()); }
                catch { l_idkhoa = 0; }
				l_maql=decimal.Parse(r["maql"].ToString());
				s_sovaovien=r["sovaovien"].ToString();
				if (l_duyet!=0)
				{
					tenphuongphap.SelectedValue=r["phuongphap"].ToString();
					mamau.Text=r["mamau"].ToString();
					tenmau.Text=mamau.Text;
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
					string _ngaymo=r["ngaymo"].ToString();
					ngaymo.Text=_ngaymo.Substring(0,10);
					giomo.Text=_ngaymo.Substring(11);
					gan_text(r["ptv"].ToString(),ptchinh,tenptchinh);
					gan_text(r["phu1"].ToString(),ptphu,tenptphu);
					tenmau.Focus();
				}
			}
		}

		private void emp_text()
		{
			string _ngay=m.ngayhienhanh_server;
			l_id=l_duyet;tenmau.Text="";mamau.Text="";lmau.SelectedIndex=-1;ptphu.Text="";tenptdutru.Text="";
			ptchinh.Text="";tenptchinh.Text="";ptphu.Text="";tenptphu.Text="";
			phuongphap.Text="";tenphuongphap.SelectedIndex=-1;ngaymo.Text=_ngay.Substring(0,10);giomo.Text=_ngay.Substring(11);
			tuthe.Text="";nhommau.SelectedIndex=-1;rh.Checked=false;mau.Text="";
			rb0.Checked=false;rb1.Checked=false;rb2.Checked=false;rb3.Checked=false;rb4.Checked=false;rb5.Checked=false;
			rb6.Checked=false;rb7.Checked=false;rb8.Checked=false;rb9.Checked=false;rb10.Checked=false;
			xnkhac.Text="";tiensu.Text="";tim.Text="";phoi.Text="";khac.Text="";tienluong.Text="";cotsong.Text="";
			ykien.Text="";gayme.Text="";tengayme.Text="";thankinh.Text="";anlancuoi.Text="";
			bstruongk.Text="";tenbstruongk.Text="";ptv.Text="";tenptv.Text="";ngay.Text=_ngay.Substring(0,10);
			asa.SelectedIndex=0;glodmann.SelectedIndex=0;mallampati.SelectedIndex=0;
			mabs.Text="";tenbs.Text="";
			ena_object(true);
		}

		private void ena_object(bool ena)
		{
			tenmau.Enabled=!ena;lmau.Enabled=!ena;ptdutru.Enabled=!ena;tenptdutru.Enabled=!ena;
			ptchinh.Enabled=!ena;tenptchinh.Enabled=!ena;ptphu.Enabled=!ena;tenptphu.Enabled=!ena;
			phuongphap.Enabled=!ena;tenphuongphap.Enabled=!ena;ngaymo.Enabled=!ena;giomo.Enabled=!ena;
			tuthe.Enabled=!ena;nhommau.Enabled=!ena;rh.Enabled=!ena;mau.Enabled=!ena;
			rb0.Enabled=!ena;rb1.Enabled=!ena;rb2.Enabled=!ena;rb3.Enabled=!ena;rb4.Enabled=!ena;rb5.Enabled=!ena;
			rb6.Enabled=!ena;rb7.Enabled=!ena;rb8.Enabled=!ena;rb9.Enabled=!ena;rb10.Enabled=!ena;
			xnkhac.Enabled=!ena;tiensu.Enabled=!ena;tim.Enabled=!ena;phoi.Enabled=!ena;khac.Enabled=!ena;tienluong.Enabled=!ena;
			cotsong.Enabled=!ena;ykien.Enabled=!ena;gayme.Enabled=!ena;tengayme.Enabled=!ena;thankinh.Enabled=!ena;anlancuoi.Enabled=!ena;
			bstruongk.Enabled=!ena;tenbstruongk.Enabled=!ena;ptv.Enabled=!ena;tenptv.Enabled=!ena;ngay.Enabled=!ena;
			mabs.Enabled=!ena;tenbs.Enabled=!ena;asa.Enabled=!ena;glodmann.Enabled=!ena;mallampati.Enabled=!ena;
			butKetthuc.Enabled=ena;butLuu.Enabled=!ena;butBoqua.Enabled=!ena;butIn.Enabled=ena;butMoi.Enabled=ena;list.Enabled=ena;
		}

		private void load_data()
		{
			Cursor=Cursors.WaitCursor;
			ena_object(false);
			l_idthuchien=m.get_idthuchien(s_ngayvv,l_idkhoa);
			if (l_idthuchien!=0)
			{
				foreach(DataRow r in m.get_data("select a.*,to_char(a.ngay,'dd/mm/yyyy') as ng,to_char(a.ngaymo,'dd/mm/yyyy hh24:mi') as ngmo from "+xxx+".ba_hoichancc a where a.id="+l_id).Tables[0].Rows)
				{
					ngay.Text=r["ng"].ToString();
					ngaymo.Text=r["ngmo"].ToString().Substring(0,10);
					giomo.Text=r["ngmo"].ToString().Substring(11);
					mamau.Text=r["mamau"].ToString();
					tenmau.Text=mamau.Text;
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
					phuongphap.Text=r["phuongphap"].ToString().PadLeft(2,'0');
					tenphuongphap.SelectedValue=phuongphap.Text;
					gan_text(r["ptdutru"].ToString(),ptdutru,tenptdutru);
					gan_text(r["ptchinh"].ToString(),ptchinh,tenptchinh);
					gan_text(r["ptphu"].ToString(),ptphu,tenptphu);
					nhommau.SelectedValue=r["nhommau"].ToString();
					rh.Checked=r["rh"].ToString()=="1";
					mau.Text=(r["mau"].ToString()!="0")?r["mau"].ToString():"";
					xnkhac.Text=r["xnkhac"].ToString();
					tuthe.Text=r["tuthe"].ToString();
					tiensu.Text=r["tiensu"].ToString();
					tim.Text=r["tim"].ToString();
					phoi.Text=r["phoi"].ToString();
					tienluong.Text=r["tienluong"].ToString();
					cotsong.Text=r["cotsong"].ToString();
					khac.Text=r["khac"].ToString();
					thankinh.Text=r["thankinh"].ToString();
					anlancuoi.Text=r["anlancuoi"].ToString();
					ykien.Text=r["ykien"].ToString();
					gan_text(r["bsgayme"].ToString(),gayme,tengayme);
					gan_text(r["bstruongk"].ToString(),bstruongk,tenbstruongk);
					gan_text(r["ptv"].ToString(),ptv,tenptv);
					gan_text(r["bstruonggmhs"].ToString(),mabs,tenbs);
					asa.Text=r["asa"].ToString();
					glodmann.Text=r["glodmann"].ToString();
					mallampati.Text=r["mallampati"].ToString();
				}
				DataTable tmp=m.get_data("select * from "+xxx+".ba_hoichanccxn where id="+l_id).Tables[0];
				DataRow r1;
				string _name="";int so=0;
				foreach(System.Windows.Forms.Control c in this.Controls)
				{
					try
					{
						_name=c.Name.ToString();
						if (_name.Substring(0,2)=="rb")
						{
							so=int.Parse(_name.Substring(2));
							r1=m.getrowbyid(tmp,"ma="+so);										
							if (r1!=null)
							{
								CheckBox chk=(CheckBox)c;
								chk.Checked=r1["tinhtrang"].ToString()=="1";
							}
						}
					}
					catch{}
				}
			}
			Cursor=Cursors.Default;
		}

		private bool kiemtra()
		{
			if (ngay.Text=="")
			{
				ngay.Focus();return false;
			}
			if (ngaymo.Text=="")
			{
				ngaymo.Focus();return false;
			}
			if (giomo.Text=="")
			{
				giomo.Focus();return false;
			}
			if (tenmau.Text=="")
			{
				tenmau.Focus();return false;
			}
			if (lmau.SelectedIndex==-1)
			{
				lmau.Focus();return false;
			}
			if (tenphuongphap.SelectedIndex==-1)
			{
				tenphuongphap.Focus();return false;
			}
			if (nhommau.SelectedIndex==-1)
			{
				nhommau.Focus();return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Bác sĩ GMHS chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
//				if (!bAdmin)
//				{
//					if (tenbs_pass.Text!=r["password_"].ToString())
//					{
//						MessageBox.Show(lan.Change_language_MessageText("Mật khẩu bác sĩ GMHS chưa hợp lệ !",LibMedi.AccessData.Msg);
//						tenbs_pass.Focus();
//						return false;
//					}
//				}
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,"",giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(6);
            string gio_phut=DateTime.Now.Hour+":"+DateTime.Now.Minute;
			m.upd_ba_hoichancc(ngayvv.Text,mabn.Text,l_id,l_idthuchien,ngay.Text+" "+gio_phut,ngaymo.Text+" "+giomo.Text,tenmau.Text,lmau.Text,int.Parse(nhommau.SelectedValue.ToString()),(rh.Checked)?1:0,(mau.Text!="")?decimal.Parse(mau.Text):0,xnkhac.Text,ptdutru.Text,
				ptchinh.Text,ptphu.Text,int.Parse(tenphuongphap.SelectedValue.ToString()),tuthe.Text,ykien.Text,bstruongk.Text,bstruongk.Text,ptv.Text,tiensu.Text,tim.Text,phoi.Text,tienluong.Text,khac.Text,cotsong.Text,thankinh.Text,anlancuoi.Text,
				asa.Text,glodmann.Text,mallampati.Text,gayme.Text,mabs.Text,i_userid);			
			string _name="";
			int so=0;
			foreach(System.Windows.Forms.Control c in this.Controls)
			{
				try
				{
					_name=c.Name.ToString();
					if (_name.Substring(0,2)=="rb")
					{
						so=int.Parse(_name.Substring(2));
						CheckBox chk=(CheckBox)c;
						m.upd_ba_hoichanccxn(ngayvv.Text,mabn.Text,l_id,so,(chk.Checked)?1:0);
					}
				}
				catch{}
			}
			load_list();
			bUpdate=true;
			ena_object(true);
			butIn.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            DataSet dsxml = new DataSet();
            sql = "select '' as mabn,'' as hoten,'' as sovaovien,'' as chandoan,'' as tuoi,'' phai,";
            sql += "a.ptdutru,a.ptchinh,a.ptphu,a.bsgayme,a.bstruongk,a.ptv,to_char(a.ngaymo,'dd/mm/yyyy hh24:mi') as ngaymo,";
            sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay,a.tuthe,'' as phuongphap,'' as nhommau,a.rh,a.mau,";
            sql += "0 as c0,0 as c1,0 as c2,0 as c3,0 as c4,0 as c5,0 as c6,0 as c7,0 as c8,0 as c9,0 as c10,";
            sql += "a.xnkhac,a.tiensu,a.tim,a.phoi,a.tienluong,a.cotsong,a.thankinh,a.anlancuoi,a.khac,a.ykien,";
            sql += "'' as igmhs,'' as igayme,'' as ibstruongk,'' as iptv";//c.image,d.image,e.image,f.image
            sql += " from " + user + m.mmyy(ngayvv.Text) + ".ba_hoichancc a left join " + user + ".dmbs c on a.bstruonggmhs=c.ma";
            sql += " left join " + user + ".dmbs d on bsgayme=d.ma left join " + user + ".dmbs e on a.bstruongk=e.ma";
            sql += " left join " + user + ".dmbs f on a.ptv=f.ma";
            sql += " where a.id=" + l_id;
            dsxml = m.get_data(sql);
            foreach (DataRow r in dsxml.Tables[0].Rows)
            {
                r["mabn"] = mabn.Text; r["hoten"] = hoten.Text; r["sovaovien"] = s_sovaovien; r["chandoan"] = chandoan.Text; r["tuoi"] = tuoi.Text; r["phai"] = phai.Text;
                r["ptdutru"] = tenptdutru.Text; r["ptchinh"] = tenptchinh.Text; r["ptphu"] = tenptphu.Text; r["phuongphap"] = tenphuongphap.Text; r["nhommau"] = nhommau.Text;
                r["c0"] = (rb0.Checked) ? 1 : 0; r["c1"] = (rb1.Checked) ? 1 : 0; r["c2"] = (rb2.Checked) ? 1 : 0; r["c3"] = (rb3.Checked) ? 1 : 0; r["c4"] = (rb4.Checked) ? 1 : 0;
                r["c5"] = (rb5.Checked) ? 1 : 0; r["c6"] = (rb6.Checked) ? 1 : 0; r["c7"] = (rb7.Checked) ? 1 : 0; r["c8"] = (rb8.Checked) ? 1 : 0;
                r["c9"] = (rb9.Checked) ? 1 : 0; r["c10"] = (rb10.Checked) ? 1 : 0; r["bsgayme"] = tengayme.Text; r["bstruongk"] = tenbstruongk.Text; r["ptv"] = tenbs.Text;
            }

            if (dsxml.Tables[0].Rows.Count > 0)
            {
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    dsxml.WriteXml("..\\xml\\hoichancc.xml", XmlWriteMode.WriteSchema);
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, s_tenkp, "rHoichancc.rpt");
                f.ShowDialog();
            }
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tenphuongphap_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				phuongphap.Text=tenphuongphap.SelectedValue.ToString();
			}
			catch{}
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenphuongphap.SelectedIndex==-1) tenphuongphap.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void phuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void phuongphap_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenphuongphap.SelectedValue=phuongphap.Text;
			}
			catch{}
		}

		private void ngaymo_Validated(object sender, System.EventArgs e)
		{
			ngaymo.Text=ngaymo.Text.Trim();
			if (ngaymo.Text.Length==6) ngaymo.Text=ngaymo.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngaymo.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaymo.Focus();
				return;
			}
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void giomo_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giomo.Text.Trim()=="")?"00:00":giomo.Text.Trim();
			giomo.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giomo.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giomo.Focus();
				return;
			}
		}

		private void nhommau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhommau.SelectedIndex==-1 && nhommau.Items.Count>0) nhommau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				l_id=(list.SelectedIndex!=-1)?decimal.Parse(list.SelectedValue.ToString()):0;
				load_data();
			}
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			l_id=(list.SelectedIndex!=-1)?decimal.Parse(list.SelectedValue.ToString()):0;
			load_data();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			get_mabn(s_mabn);
			ena_object(false);
			nhommau.Focus();
		}
	}
}
