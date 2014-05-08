using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmThongso.
	/// </summary>
	public class frmThongso : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox loaidv;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox benhvien;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox soyte;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox dienthoai;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private DataSet dssys = new DataSet();
		private DataSet ds=new DataSet();
		private DataSet dsnn=new DataSet();
		private DataSet dsts=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dttd=new DataTable();
        private DataTable dtk = new DataTable();
        private DataTable dtlvp = new DataTable();
        private DataTable dtkho = new DataTable();
        private DataSet dsc = new DataSet();
        private DataTable dtkhok = new DataTable();
        private DataTable dtkhotua = new DataTable();
		private bool bKhaibao,bTenvien,bAdmin;
        private int i_userid;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.Label label13;
        private string sql, s_makho, user;
        private string s_137 = "", s_176 = "", s_186 = "", s_191 = "", s_196 = "", sTemp = "", s_300 = "", _id, mabv = "", tenbv = "", s_315 = "", s_316 = "", s_317 = "", s_318 = "", s_319 = "",s_324="",s_356="",s_358="",s_376="",s_390="",s_397="",s_401="",s_402="";
        private DataTable dt397 = new DataTable();
		private System.Windows.Forms.CheckBox c61;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox c115;
        private System.Windows.Forms.Button butThongbao;
		private System.Windows.Forms.CheckBox c116;
		private System.Windows.Forms.CheckBox ngaylv;
		private System.Windows.Forms.CheckBox c102;
		private System.Windows.Forms.CheckBox c100;
		private System.Windows.Forms.CheckBox c54;
		private System.Windows.Forms.NumericUpDown c42;
		private System.Windows.Forms.NumericUpDown c43;
		private System.Windows.Forms.CheckBox c44;
		private System.Windows.Forms.CheckBox c0;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.NumericUpDown songay;
		private System.Windows.Forms.CheckBox c38;
		private System.Windows.Forms.CheckBox c36;
		private System.Windows.Forms.CheckBox saoluu33;
		private System.Windows.Forms.CheckBox chandoan;
		private System.Windows.Forms.CheckBox noichuyen;
		private System.Windows.Forms.CheckBox khambenh;
		private System.Windows.Forms.CheckBox solieu;
		private System.Windows.Forms.CheckBox pttt;
		private System.Windows.Forms.CheckBox soluutru;
		private System.Windows.Forms.CheckBox sovaovien;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox c114;
        private System.Windows.Forms.CheckBox c111;
		private System.Windows.Forms.NumericUpDown c107;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox c106;
		private System.Windows.Forms.NumericUpDown c104;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox c59;
		private System.Windows.Forms.RadioButton c593;
		private System.Windows.Forms.RadioButton c592;
		private System.Windows.Forms.RadioButton c591;
		private System.Windows.Forms.GroupBox c56;
		private System.Windows.Forms.RadioButton c563;
		private System.Windows.Forms.RadioButton c562;
		private System.Windows.Forms.RadioButton c561;
		private System.Windows.Forms.GroupBox c60;
		private System.Windows.Forms.RadioButton c604;
		private System.Windows.Forms.RadioButton c603;
		private System.Windows.Forms.RadioButton c602;
		private System.Windows.Forms.RadioButton c601;
		private System.Windows.Forms.GroupBox c113;
		private System.Windows.Forms.RadioButton c1134;
		private System.Windows.Forms.RadioButton c1133;
		private System.Windows.Forms.RadioButton c1132;
		private System.Windows.Forms.RadioButton c1131;
		private System.Windows.Forms.CheckBox c112;
		private System.Windows.Forms.CheckBox c110;
		private System.Windows.Forms.CheckBox c58;
		private System.Windows.Forms.CheckBox c57;
		private System.Windows.Forms.CheckBox c48;
		private System.Windows.Forms.CheckBox c47;
		private System.Windows.Forms.CheckBox c46;
		private System.Windows.Forms.CheckBox c45;
		private System.Windows.Forms.CheckBox c51;
		private System.Windows.Forms.CheckBox c53;
		private System.Windows.Forms.CheckBox c52;
		private System.Windows.Forms.CheckBox c55;
		private System.Windows.Forms.CheckBox c105;
        private System.Windows.Forms.CheckBox c200;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.NumericUpDown id;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.CheckBox chophep;
		private System.Windows.Forms.CheckBox c118;
		private System.Windows.Forms.CheckBox c125;
		private System.Windows.Forms.CheckBox c126;
		private System.Windows.Forms.CheckBox c127;
		private System.Windows.Forms.CheckBox c128;
		private System.Windows.Forms.CheckBox c129;
		private System.Windows.Forms.CheckBox c131;
		private MaskedTextBox.MaskedTextBox c39;
		private MaskedTextBox.MaskedTextBox c40;
		private MaskedTextBox.MaskedTextBox c41;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox bsPttt;
		private System.Windows.Forms.CheckBox bsXuatvien;
		private System.Windows.Forms.CheckBox bsXuatkhoa;
		private System.Windows.Forms.CheckBox bsNhapkhoa;
		private System.Windows.Forms.CheckBox bsNhanbenh;
		private System.Windows.Forms.CheckBox bsNgoaitru;
        private System.Windows.Forms.CheckBox bsKhambenh;
		private System.Windows.Forms.TextBox c124;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox c123;
		private System.Windows.Forms.ComboBox c122;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox c119;
		private System.Windows.Forms.ComboBox c121;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.NumericUpDown c120;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.CheckBox c132;
		private System.Windows.Forms.CheckBox c130;
		private System.Windows.Forms.CheckBox c133;
		private System.Windows.Forms.CheckBox c134;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.ComboBox ngonngu;
		private System.Windows.Forms.CheckBox c135;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.NumericUpDown hh;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.ComboBox c137;
        private System.Windows.Forms.Label label34;
		private System.Windows.Forms.NumericUpDown c139;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.CheckBox c140;
		private System.Windows.Forms.CheckBox c141;
		private System.Windows.Forms.CheckBox c142;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ComboBox c143;
		private System.Windows.Forms.CheckBox c144;
		private System.Windows.Forms.CheckBox c145;
		private System.Windows.Forms.CheckBox c146;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ComboBox c147;
		private System.Windows.Forms.CheckBox c148;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ComboBox c149;
		private System.Windows.Forms.CheckBox c150;
        private System.Windows.Forms.CheckBox c151;
		private System.Windows.Forms.CheckBox c154;
		private System.Windows.Forms.CheckBox c155;
		private System.Windows.Forms.CheckBox c156;
		private System.Windows.Forms.CheckBox c157;
		private System.Windows.Forms.CheckBox c158;
		private System.Windows.Forms.CheckBox c160;
		private System.Windows.Forms.CheckBox c161;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.ComboBox c165;
		private System.Windows.Forms.ComboBox c166;
		private System.Windows.Forms.CheckBox c170;
		private System.Windows.Forms.TextBox c171;
		private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox c174;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.NumericUpDown hhb;
		private System.Windows.Forms.NumericUpDown mmb;
		private System.Windows.Forms.ComboBox c176;
        private System.Windows.Forms.CheckBox c177;
		private System.Windows.Forms.CheckBox c163;
		private System.Windows.Forms.CheckBox c164;
        private System.Windows.Forms.CheckBox c172;
		private System.Windows.Forms.CheckBox c159;
		private System.Windows.Forms.CheckBox c178;
		private System.Windows.Forms.CheckBox c162;
		private System.Windows.Forms.CheckBox c169;
		private System.Windows.Forms.CheckBox c167;
		private System.Windows.Forms.CheckBox c179;
		private System.Windows.Forms.CheckBox c180;
		private System.Windows.Forms.CheckBox c181;
        private Button but174;
        private ComboBox c186;
        private NumericUpDown mmt;
        private Label label45;
        private Label label46;
        private NumericUpDown hht;
        private Label label47;
        private CheckBox c184;
        private CheckBox c183;
        private CheckBox c182;
        private NumericUpDown mmtn;
        private Label label48;
        private NumericUpDown hhtn;
        private CheckBox c153;
        private CheckBox c188;
        private DataGrid dataGrid2;
        private ComboBox c191;
        private NumericUpDown mml;
        private Label label51;
        private Label label52;
        private NumericUpDown hhl;
        private Label label50;
        private NumericUpDown c189;
        private ComboBox c193;
        private CheckBox c192;
        private ComboBox c196;
        private CheckBox c195;
        private CheckBox c194;
        private CheckBox c197;
        private CheckBox c198;
        private CheckBox c204;
        private CheckBox c203;
        private CheckBox c202;
        private CheckBox c201;
        private CheckBox c109;
        private CheckBox c108;
        private CheckBox c199;
        private CheckBox c205;
        private CheckBox c215;
        private CheckBox c214;
        private CheckBox c213;
        private CheckBox c216;
        private CheckBox c225;
        private CheckBox c227;
        private CheckBox c226;
        private CheckBox c224;
        private CheckBox c223;
        private ComboBox c220;
        private CheckBox c219;
        private CheckBox c218;
        private CheckBox c217;
        private ComboBox c229;
        private CheckBox c228;
        private CheckBox c230;
        private CheckBox c231;
        private CheckBox c232;
        private CheckBox c233;
        private ComboBox c234;
        private Label label54;
        private CheckBox c236;
        private CheckBox c235;
        private CheckBox c237;
        private CheckBox c238;
        private CheckBox c239;
        private CheckBox c240;
        private CheckBox c241;
        private CheckBox c242;
        private CheckBox c243;
        private CheckBox c245;
        private CheckBox c244;
        private CheckBox c246;
        private CheckBox c247;
        private CheckBox c248;
        private CheckBox c249;
        private CheckBox c250;
        private CheckBox c251;
        private CheckBox c252;
        private ComboBox c254;
        private CheckBox c253;
        private NumericUpDown c257;
        private Label label55;
        private CheckBox c256;
        private CheckBox c255;
        private Label label56;
        private CheckBox c258;
        private CheckBox c259;
        private CheckBox c260;
        private CheckBox c261;
        private ComboBox c263;
        private CheckBox c262;
        private CheckBox c264;
        private Button butImage;
        private TextBox c265;
        private Label label57;
        private NumericUpDown c270;
        private NumericUpDown c269;
        private NumericUpDown c268;
        private NumericUpDown c267;
        private Label label58;
        private NumericUpDown c266;
        private CheckBox c271;
        private NumericUpDown c272;
        private NumericUpDown c273;
        private CheckBox c274;
        private ComboBox c275;
        private CheckBox c276;
        private TreeView treeView1;
        private TextBox txtNodeTextSearch;
        private Panel p01;
        private Panel p02;
        private GroupBox groupBox1;
        private Panel p03;
        private Panel p12;
        private Panel p04;
        private Panel p05;
        private Panel p06;
        private Panel p07;
        private Panel p08;
        private Panel p09;
        private Panel p11;
        private Panel p10;
        private Label lTemp;
        private Button butTemp;
        private TextBox tTemp;
        private CheckBox c277;
        private CheckBox c278;
        private ComboBox c280;
        private CheckBox c279;
        private CheckBox c281;
        private CheckBox c282;
        private ComboBox c284;
        private CheckBox c283;
        private Label label59;
        private Label label49;
        private Label label14;
        private ComboBox c286;
        private CheckBox c287;
        private CheckBox c288;
        private CheckBox c289;
        private ComboBox c290;
        private Label label60;
        private DateTimePicker c293;
        private DateTimePicker c292;
        private DateTimePicker c291;
        private Label label63;
        private Label label62;
        private CheckBox c294;
        private NumericUpDown c138h;
        private NumericUpDown c138m;
        private Label label53;
        private CheckBox c295;
        private CheckBox c296;
        private CheckBox c297;
        private ComboBox c299;
        private ComboBox c298;
        private Label label61;
        private CheckedListBox c300;
        private DataSet dsletet = new DataSet();
        private CheckBox c301;
        private CheckBox c302;
        private ComboBox c303;
        private Label label64;
        private CheckBox c304;
        private Label label66;
        private NumericUpDown c305;
        private Label label65;
        private Panel p13;
        private CheckBox c306;
        private ComboBox c307;
        private Label label67;
        private ComboBox c310;
        private ComboBox c309;
        private ComboBox c308;
        private Label label73;
        private Label label72;
        private Label label71;
        private Label label70;
        private Label label69;
        private Label label68;
        private ComboBox c314;
        private ComboBox c313;
        private ComboBox c312;
        private ComboBox c311;
        private Label label74;
        private CheckedListBox c315;
        private CheckedListBox c316;
        private Label label79;
        private Label label78;
        private Label label77;
        private Label label76;
        private Label label75;
        private CheckedListBox c319;
        private CheckedListBox c318;
        private CheckedListBox c317;
        private CheckBox c320;
        private CheckBox c321;
        private CheckBox c322;
        private CheckedListBox c324;
        private CheckBox c323;
        private Label label80;
        private NumericUpDown c325;
        private Label label81;
        private DataTable dtkp = new DataTable();
        private CheckBox c326;
        private CheckBox c327;
        private CheckBox c328;
        private CheckBox c329;
        private CheckBox c330;
        private CheckBox c331;
        private Label label84;
        private NumericUpDown c333;
        private Label label83;
        private TextBox c332;
        private Label label82;
        private CheckBox c334;
        private TextBox c335;
        private Label label85;
        private DataGrid dataGrid3;
        private Button butFile;
        private ToolTip toolTip1;
        private CheckBox c336;
        private CheckBox c338;
        private CheckBox c337;
        private NumericUpDown c339;
        private Label label86;
        private Button but341;
        private TextBox c341;
        private CheckBox c340;
        private CheckBox c342;
        private CheckBox c343;
        private CheckBox c344;
        private CheckBox demo;
        private NumericUpDown songaydemo;
        private CheckBox c345;
        private CheckBox c346;
        private CheckBox c347;
        private Label label91;
        private Label label90;
        private Label label89;
        private Label label88;
        private NumericUpDown c348;
        private Label label87;
        private NumericUpDown c351;
        private NumericUpDown c352;
        private TextBox c350;
        private TextBox c349;
        private Label lbl60;
        private Label label93;
        private Label label94;
        private Label label92;
        private CheckBox c353;
        private CheckBox c354;
        private DataTable dtdt = new DataTable();
        private DataTable dtc = new DataTable();
        private CheckBox c359;
        private CheckBox c360;
        private CheckBox c361;
        private CheckBox c362;
        private ComboBox c364;
        private CheckBox c363;
        private NumericUpDown c365;
        private Label label95;
        private Label label97;
        private Label label96;
        private TextBox c367;
        private NumericUpDown c366;
        private ComboBox c368;
        private Label label98;
        private CheckBox c369;
        private CheckBox c370;
        private CheckBox c371;
        private TextBox c372;
        private Label label99;
        private CheckBox c373;
        private CheckBox c374;
        private CheckedListBox c376;
        private Label label101;
        private ComboBox c375;
        private Label label100;
        private CheckBox c377;
        private CheckBox c378;
        private ComboBox c379;
        private Label label102;
        private CheckBox c381;
        private CheckBox c382;
        private CheckBox c383;
        private CheckBox c384;
        private CheckBox c385;
        private CheckBox c386;
        private CheckBox c387;
        private CheckBox c388;
        private ComboBox c389;
        private Label label103;
        private CheckedListBox c390;
        private CheckBox c391;
        private CheckBox c392;
        private CheckBox c393;
        private CheckBox c394;
        private CheckBox c395;
        private ComboBox c396;
        private CheckedListBox c397;
        private Label label104;
        private CheckBox c398;
        private CheckBox c399;
        private CheckBox c400;
        private ComboBox c402;
        private CheckedListBox c401;
        private CheckBox c403;
        private CheckBox c404;
        private DataTable dtl = new DataTable();
	
		public frmThongso(LibMedi.AccessData acc,int userid,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; bAdmin = admin;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongso));
            this.label1 = new System.Windows.Forms.Label();
            this.loaidv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.benhvien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.soyte = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.c61 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.c115 = new System.Windows.Forms.TextBox();
            this.butThongbao = new System.Windows.Forms.Button();
            this.c241 = new System.Windows.Forms.CheckBox();
            this.c239 = new System.Windows.Forms.CheckBox();
            this.chandoan = new System.Windows.Forms.CheckBox();
            this.c227 = new System.Windows.Forms.CheckBox();
            this.c216 = new System.Windows.Forms.CheckBox();
            this.c226 = new System.Windows.Forms.CheckBox();
            this.c225 = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.c200 = new System.Windows.Forms.CheckBox();
            this.c111 = new System.Windows.Forms.CheckBox();
            this.c104 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c116 = new System.Windows.Forms.CheckBox();
            this.c102 = new System.Windows.Forms.CheckBox();
            this.c42 = new System.Windows.Forms.NumericUpDown();
            this.c43 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.c38 = new System.Windows.Forms.CheckBox();
            this.solieu = new System.Windows.Forms.CheckBox();
            this.pttt = new System.Windows.Forms.CheckBox();
            this.soluutru = new System.Windows.Forms.CheckBox();
            this.sovaovien = new System.Windows.Forms.CheckBox();
            this.c242 = new System.Windows.Forms.CheckBox();
            this.c196 = new System.Windows.Forms.ComboBox();
            this.c191 = new System.Windows.Forms.ComboBox();
            this.mml = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.hhl = new System.Windows.Forms.NumericUpDown();
            this.c186 = new System.Windows.Forms.ComboBox();
            this.mmt = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.hht = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.c179 = new System.Windows.Forms.CheckBox();
            this.c112 = new System.Windows.Forms.CheckBox();
            this.c128 = new System.Windows.Forms.CheckBox();
            this.c129 = new System.Windows.Forms.CheckBox();
            this.c55 = new System.Windows.Forms.CheckBox();
            this.c58 = new System.Windows.Forms.CheckBox();
            this.c177 = new System.Windows.Forms.CheckBox();
            this.c176 = new System.Windows.Forms.ComboBox();
            this.mmb = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.hhb = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.c166 = new System.Windows.Forms.ComboBox();
            this.c165 = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.c161 = new System.Windows.Forms.CheckBox();
            this.c158 = new System.Windows.Forms.CheckBox();
            this.c157 = new System.Windows.Forms.CheckBox();
            this.c156 = new System.Windows.Forms.CheckBox();
            this.c155 = new System.Windows.Forms.CheckBox();
            this.c154 = new System.Windows.Forms.CheckBox();
            this.c151 = new System.Windows.Forms.CheckBox();
            this.c150 = new System.Windows.Forms.CheckBox();
            this.c149 = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.c147 = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.c146 = new System.Windows.Forms.CheckBox();
            this.c145 = new System.Windows.Forms.CheckBox();
            this.c144 = new System.Windows.Forms.CheckBox();
            this.c143 = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.c48 = new System.Windows.Forms.CheckBox();
            this.c135 = new System.Windows.Forms.CheckBox();
            this.c131 = new System.Windows.Forms.CheckBox();
            this.c140 = new System.Windows.Forms.CheckBox();
            this.c132 = new System.Windows.Forms.CheckBox();
            this.c130 = new System.Windows.Forms.CheckBox();
            this.c126 = new System.Windows.Forms.CheckBox();
            this.c125 = new System.Windows.Forms.CheckBox();
            this.c110 = new System.Windows.Forms.CheckBox();
            this.c51 = new System.Windows.Forms.CheckBox();
            this.c141 = new System.Windows.Forms.CheckBox();
            this.c139 = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.c137 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.hh = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.c134 = new System.Windows.Forms.CheckBox();
            this.c57 = new System.Windows.Forms.CheckBox();
            this.c133 = new System.Windows.Forms.CheckBox();
            this.c127 = new System.Windows.Forms.CheckBox();
            this.c47 = new System.Windows.Forms.CheckBox();
            this.c46 = new System.Windows.Forms.CheckBox();
            this.c53 = new System.Windows.Forms.CheckBox();
            this.c52 = new System.Windows.Forms.CheckBox();
            this.c214 = new System.Windows.Forms.CheckBox();
            this.c205 = new System.Windows.Forms.CheckBox();
            this.c204 = new System.Windows.Forms.CheckBox();
            this.c199 = new System.Windows.Forms.CheckBox();
            this.c198 = new System.Windows.Forms.CheckBox();
            this.c197 = new System.Windows.Forms.CheckBox();
            this.c194 = new System.Windows.Forms.CheckBox();
            this.c193 = new System.Windows.Forms.ComboBox();
            this.c192 = new System.Windows.Forms.CheckBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.c188 = new System.Windows.Forms.CheckBox();
            this.mmtn = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.hhtn = new System.Windows.Forms.NumericUpDown();
            this.c153 = new System.Windows.Forms.CheckBox();
            this.c184 = new System.Windows.Forms.CheckBox();
            this.c183 = new System.Windows.Forms.CheckBox();
            this.c182 = new System.Windows.Forms.CheckBox();
            this.c181 = new System.Windows.Forms.CheckBox();
            this.c180 = new System.Windows.Forms.CheckBox();
            this.c169 = new System.Windows.Forms.CheckBox();
            this.c159 = new System.Windows.Forms.CheckBox();
            this.c164 = new System.Windows.Forms.CheckBox();
            this.c163 = new System.Windows.Forms.CheckBox();
            this.c273 = new System.Windows.Forms.NumericUpDown();
            this.c272 = new System.Windows.Forms.NumericUpDown();
            this.c271 = new System.Windows.Forms.CheckBox();
            this.c270 = new System.Windows.Forms.NumericUpDown();
            this.c269 = new System.Windows.Forms.NumericUpDown();
            this.c268 = new System.Windows.Forms.NumericUpDown();
            this.c267 = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.c266 = new System.Windows.Forms.NumericUpDown();
            this.c263 = new System.Windows.Forms.ComboBox();
            this.c262 = new System.Windows.Forms.CheckBox();
            this.c261 = new System.Windows.Forms.CheckBox();
            this.c260 = new System.Windows.Forms.CheckBox();
            this.label56 = new System.Windows.Forms.Label();
            this.c257 = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.c256 = new System.Windows.Forms.CheckBox();
            this.c255 = new System.Windows.Forms.CheckBox();
            this.c254 = new System.Windows.Forms.ComboBox();
            this.c253 = new System.Windows.Forms.CheckBox();
            this.c251 = new System.Windows.Forms.CheckBox();
            this.c249 = new System.Windows.Forms.CheckBox();
            this.c247 = new System.Windows.Forms.CheckBox();
            this.c246 = new System.Windows.Forms.CheckBox();
            this.c244 = new System.Windows.Forms.CheckBox();
            this.c243 = new System.Windows.Forms.CheckBox();
            this.c240 = new System.Windows.Forms.CheckBox();
            this.c238 = new System.Windows.Forms.CheckBox();
            this.c237 = new System.Windows.Forms.CheckBox();
            this.c236 = new System.Windows.Forms.CheckBox();
            this.c235 = new System.Windows.Forms.CheckBox();
            this.c234 = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.c233 = new System.Windows.Forms.CheckBox();
            this.c232 = new System.Windows.Forms.CheckBox();
            this.c231 = new System.Windows.Forms.CheckBox();
            this.c230 = new System.Windows.Forms.CheckBox();
            this.c229 = new System.Windows.Forms.ComboBox();
            this.c228 = new System.Windows.Forms.CheckBox();
            this.c224 = new System.Windows.Forms.CheckBox();
            this.c223 = new System.Windows.Forms.CheckBox();
            this.c220 = new System.Windows.Forms.ComboBox();
            this.c219 = new System.Windows.Forms.CheckBox();
            this.c218 = new System.Windows.Forms.CheckBox();
            this.c217 = new System.Windows.Forms.CheckBox();
            this.c171 = new System.Windows.Forms.TextBox();
            this.c170 = new System.Windows.Forms.CheckBox();
            this.c59 = new System.Windows.Forms.GroupBox();
            this.c593 = new System.Windows.Forms.RadioButton();
            this.c592 = new System.Windows.Forms.RadioButton();
            this.c591 = new System.Windows.Forms.RadioButton();
            this.c56 = new System.Windows.Forms.GroupBox();
            this.c563 = new System.Windows.Forms.RadioButton();
            this.c562 = new System.Windows.Forms.RadioButton();
            this.c561 = new System.Windows.Forms.RadioButton();
            this.c60 = new System.Windows.Forms.GroupBox();
            this.c604 = new System.Windows.Forms.RadioButton();
            this.c603 = new System.Windows.Forms.RadioButton();
            this.c602 = new System.Windows.Forms.RadioButton();
            this.c601 = new System.Windows.Forms.RadioButton();
            this.c113 = new System.Windows.Forms.GroupBox();
            this.c1134 = new System.Windows.Forms.RadioButton();
            this.c1133 = new System.Windows.Forms.RadioButton();
            this.c1132 = new System.Windows.Forms.RadioButton();
            this.c1131 = new System.Windows.Forms.RadioButton();
            this.chophep = new System.Windows.Forms.CheckBox();
            this.ten = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.c178 = new System.Windows.Forms.CheckBox();
            this.c148 = new System.Windows.Forms.CheckBox();
            this.c195 = new System.Windows.Forms.CheckBox();
            this.c108 = new System.Windows.Forms.CheckBox();
            this.c109 = new System.Windows.Forms.CheckBox();
            this.c201 = new System.Windows.Forms.CheckBox();
            this.c203 = new System.Windows.Forms.CheckBox();
            this.c202 = new System.Windows.Forms.CheckBox();
            this.ngonngu = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.c118 = new System.Windows.Forms.CheckBox();
            this.c114 = new System.Windows.Forms.CheckBox();
            this.c107 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.c106 = new System.Windows.Forms.CheckBox();
            this.ngaylv = new System.Windows.Forms.CheckBox();
            this.c100 = new System.Windows.Forms.CheckBox();
            this.c54 = new System.Windows.Forms.CheckBox();
            this.c44 = new System.Windows.Forms.CheckBox();
            this.c0 = new System.Windows.Forms.CheckBox();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.c36 = new System.Windows.Forms.CheckBox();
            this.saoluu33 = new System.Windows.Forms.CheckBox();
            this.noichuyen = new System.Windows.Forms.CheckBox();
            this.khambenh = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.c189 = new System.Windows.Forms.NumericUpDown();
            this.c160 = new System.Windows.Forms.CheckBox();
            this.c45 = new System.Windows.Forms.CheckBox();
            this.c142 = new System.Windows.Forms.CheckBox();
            this.c105 = new System.Windows.Forms.CheckBox();
            this.c215 = new System.Windows.Forms.CheckBox();
            this.c213 = new System.Windows.Forms.CheckBox();
            this.c167 = new System.Windows.Forms.CheckBox();
            this.c162 = new System.Windows.Forms.CheckBox();
            this.c172 = new System.Windows.Forms.CheckBox();
            this.c275 = new System.Windows.Forms.ComboBox();
            this.c264 = new System.Windows.Forms.CheckBox();
            this.butImage = new System.Windows.Forms.Button();
            this.c265 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.c259 = new System.Windows.Forms.CheckBox();
            this.c258 = new System.Windows.Forms.CheckBox();
            this.c252 = new System.Windows.Forms.CheckBox();
            this.c250 = new System.Windows.Forms.CheckBox();
            this.c248 = new System.Windows.Forms.CheckBox();
            this.c245 = new System.Windows.Forms.CheckBox();
            this.c276 = new System.Windows.Forms.CheckBox();
            this.c274 = new System.Windows.Forms.CheckBox();
            this.c121 = new System.Windows.Forms.ComboBox();
            this.but174 = new System.Windows.Forms.Button();
            this.c174 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.c124 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.c123 = new System.Windows.Forms.ComboBox();
            this.c122 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.c119 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.c120 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.c39 = new MaskedTextBox.MaskedTextBox();
            this.c40 = new MaskedTextBox.MaskedTextBox();
            this.c41 = new MaskedTextBox.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.bsPttt = new System.Windows.Forms.CheckBox();
            this.bsXuatvien = new System.Windows.Forms.CheckBox();
            this.bsXuatkhoa = new System.Windows.Forms.CheckBox();
            this.bsNhapkhoa = new System.Windows.Forms.CheckBox();
            this.bsNhanbenh = new System.Windows.Forms.CheckBox();
            this.bsNgoaitru = new System.Windows.Forms.CheckBox();
            this.bsKhambenh = new System.Windows.Forms.CheckBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtNodeTextSearch = new System.Windows.Forms.TextBox();
            this.p01 = new System.Windows.Forms.Panel();
            this.c386 = new System.Windows.Forms.CheckBox();
            this.songaydemo = new System.Windows.Forms.NumericUpDown();
            this.demo = new System.Windows.Forms.CheckBox();
            this.but341 = new System.Windows.Forms.Button();
            this.c341 = new System.Windows.Forms.TextBox();
            this.c340 = new System.Windows.Forms.CheckBox();
            this.c138h = new System.Windows.Forms.NumericUpDown();
            this.c138m = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.c277 = new System.Windows.Forms.CheckBox();
            this.butTemp = new System.Windows.Forms.Button();
            this.tTemp = new System.Windows.Forms.TextBox();
            this.lTemp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p02 = new System.Windows.Forms.Panel();
            this.c343 = new System.Windows.Forms.CheckBox();
            this.p03 = new System.Windows.Forms.Panel();
            this.c393 = new System.Windows.Forms.CheckBox();
            this.c385 = new System.Windows.Forms.CheckBox();
            this.c373 = new System.Windows.Forms.CheckBox();
            this.c361 = new System.Windows.Forms.CheckBox();
            this.c354 = new System.Windows.Forms.CheckBox();
            this.c344 = new System.Windows.Forms.CheckBox();
            this.c330 = new System.Windows.Forms.CheckBox();
            this.c329 = new System.Windows.Forms.CheckBox();
            this.c327 = new System.Windows.Forms.CheckBox();
            this.label80 = new System.Windows.Forms.Label();
            this.c325 = new System.Windows.Forms.NumericUpDown();
            this.label81 = new System.Windows.Forms.Label();
            this.c324 = new System.Windows.Forms.CheckedListBox();
            this.c323 = new System.Windows.Forms.CheckBox();
            this.c322 = new System.Windows.Forms.CheckBox();
            this.c315 = new System.Windows.Forms.CheckedListBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.c305 = new System.Windows.Forms.NumericUpDown();
            this.label65 = new System.Windows.Forms.Label();
            this.c296 = new System.Windows.Forms.CheckBox();
            this.c295 = new System.Windows.Forms.CheckBox();
            this.p12 = new System.Windows.Forms.Panel();
            this.butFile = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.p04 = new System.Windows.Forms.Panel();
            this.c346 = new System.Windows.Forms.CheckBox();
            this.c301 = new System.Windows.Forms.CheckBox();
            this.p05 = new System.Windows.Forms.Panel();
            this.c365 = new System.Windows.Forms.NumericUpDown();
            this.label95 = new System.Windows.Forms.Label();
            this.c362 = new System.Windows.Forms.CheckBox();
            this.c360 = new System.Windows.Forms.CheckBox();
            this.c348 = new System.Windows.Forms.NumericUpDown();
            this.c353 = new System.Windows.Forms.CheckBox();
            this.c351 = new System.Windows.Forms.NumericUpDown();
            this.c352 = new System.Windows.Forms.NumericUpDown();
            this.c350 = new System.Windows.Forms.TextBox();
            this.c349 = new System.Windows.Forms.TextBox();
            this.lbl60 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.c347 = new System.Windows.Forms.CheckBox();
            this.c345 = new System.Windows.Forms.CheckBox();
            this.label84 = new System.Windows.Forms.Label();
            this.c333 = new System.Windows.Forms.NumericUpDown();
            this.label83 = new System.Windows.Forms.Label();
            this.c332 = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.c321 = new System.Windows.Forms.CheckBox();
            this.p06 = new System.Windows.Forms.Panel();
            this.c402 = new System.Windows.Forms.ComboBox();
            this.c401 = new System.Windows.Forms.CheckedListBox();
            this.c400 = new System.Windows.Forms.CheckBox();
            this.c394 = new System.Windows.Forms.CheckBox();
            this.c300 = new System.Windows.Forms.CheckedListBox();
            this.c390 = new System.Windows.Forms.CheckedListBox();
            this.c389 = new System.Windows.Forms.ComboBox();
            this.label103 = new System.Windows.Forms.Label();
            this.c383 = new System.Windows.Forms.CheckBox();
            this.c379 = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.c376 = new System.Windows.Forms.CheckedListBox();
            this.label101 = new System.Windows.Forms.Label();
            this.c375 = new System.Windows.Forms.ComboBox();
            this.label100 = new System.Windows.Forms.Label();
            this.c374 = new System.Windows.Forms.CheckBox();
            this.c364 = new System.Windows.Forms.ComboBox();
            this.c363 = new System.Windows.Forms.CheckBox();
            this.c342 = new System.Windows.Forms.CheckBox();
            this.c334 = new System.Windows.Forms.CheckBox();
            this.c299 = new System.Windows.Forms.ComboBox();
            this.c298 = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.c297 = new System.Windows.Forms.CheckBox();
            this.c294 = new System.Windows.Forms.CheckBox();
            this.c293 = new System.Windows.Forms.DateTimePicker();
            this.c292 = new System.Windows.Forms.DateTimePicker();
            this.c291 = new System.Windows.Forms.DateTimePicker();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.c282 = new System.Windows.Forms.CheckBox();
            this.c281 = new System.Windows.Forms.CheckBox();
            this.p07 = new System.Windows.Forms.Panel();
            this.c403 = new System.Windows.Forms.CheckBox();
            this.c399 = new System.Windows.Forms.CheckBox();
            this.c398 = new System.Windows.Forms.CheckBox();
            this.c397 = new System.Windows.Forms.CheckedListBox();
            this.label104 = new System.Windows.Forms.Label();
            this.c396 = new System.Windows.Forms.ComboBox();
            this.c395 = new System.Windows.Forms.CheckBox();
            this.c392 = new System.Windows.Forms.CheckBox();
            this.c387 = new System.Windows.Forms.CheckBox();
            this.c384 = new System.Windows.Forms.CheckBox();
            this.c382 = new System.Windows.Forms.CheckBox();
            this.c381 = new System.Windows.Forms.CheckBox();
            this.c378 = new System.Windows.Forms.CheckBox();
            this.c372 = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.c290 = new System.Windows.Forms.ComboBox();
            this.c371 = new System.Windows.Forms.CheckBox();
            this.c335 = new System.Windows.Forms.TextBox();
            this.c302 = new System.Windows.Forms.CheckBox();
            this.c370 = new System.Windows.Forms.CheckBox();
            this.c369 = new System.Windows.Forms.CheckBox();
            this.c368 = new System.Windows.Forms.ComboBox();
            this.label98 = new System.Windows.Forms.Label();
            this.c367 = new System.Windows.Forms.TextBox();
            this.c366 = new System.Windows.Forms.NumericUpDown();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.c359 = new System.Windows.Forms.CheckBox();
            this.label85 = new System.Windows.Forms.Label();
            this.c331 = new System.Windows.Forms.CheckBox();
            this.c320 = new System.Windows.Forms.CheckBox();
            this.c304 = new System.Windows.Forms.CheckBox();
            this.c303 = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.c289 = new System.Windows.Forms.CheckBox();
            this.c288 = new System.Windows.Forms.CheckBox();
            this.c287 = new System.Windows.Forms.CheckBox();
            this.c284 = new System.Windows.Forms.ComboBox();
            this.c286 = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.c283 = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.p08 = new System.Windows.Forms.Panel();
            this.c391 = new System.Windows.Forms.CheckBox();
            this.c388 = new System.Windows.Forms.CheckBox();
            this.c339 = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.c338 = new System.Windows.Forms.CheckBox();
            this.c337 = new System.Windows.Forms.CheckBox();
            this.c336 = new System.Windows.Forms.CheckBox();
            this.c328 = new System.Windows.Forms.CheckBox();
            this.c326 = new System.Windows.Forms.CheckBox();
            this.p09 = new System.Windows.Forms.Panel();
            this.p11 = new System.Windows.Forms.Panel();
            this.p10 = new System.Windows.Forms.Panel();
            this.c377 = new System.Windows.Forms.CheckBox();
            this.c280 = new System.Windows.Forms.ComboBox();
            this.c279 = new System.Windows.Forms.CheckBox();
            this.c278 = new System.Windows.Forms.CheckBox();
            this.p13 = new System.Windows.Forms.Panel();
            this.c319 = new System.Windows.Forms.CheckedListBox();
            this.c318 = new System.Windows.Forms.CheckedListBox();
            this.c317 = new System.Windows.Forms.CheckedListBox();
            this.c316 = new System.Windows.Forms.CheckedListBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.c314 = new System.Windows.Forms.ComboBox();
            this.c313 = new System.Windows.Forms.ComboBox();
            this.c312 = new System.Windows.Forms.ComboBox();
            this.c311 = new System.Windows.Forms.ComboBox();
            this.c310 = new System.Windows.Forms.ComboBox();
            this.c309 = new System.Windows.Forms.ComboBox();
            this.c308 = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.c307 = new System.Windows.Forms.ComboBox();
            this.c306 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.c404 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.c104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c139)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c273)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c272)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c270)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c269)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c268)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c267)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c266)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c257)).BeginInit();
            this.c59.SuspendLayout();
            this.c56.SuspendLayout();
            this.c60.SuspendLayout();
            this.c113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c189)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c120)).BeginInit();
            this.p01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songaydemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138m)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.p02.SuspendLayout();
            this.p03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c325)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c305)).BeginInit();
            this.p12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.p04.SuspendLayout();
            this.p05.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c365)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c348)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c351)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c352)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c333)).BeginInit();
            this.p06.SuspendLayout();
            this.p07.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c366)).BeginInit();
            this.p08.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c339)).BeginInit();
            this.p09.SuspendLayout();
            this.p11.SuspendLayout();
            this.p10.SuspendLayout();
            this.p13.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại đơn vị :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaidv
            // 
            this.loaidv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaidv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaidv.Enabled = false;
            this.loaidv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaidv.Items.AddRange(new object[] {
            "Bộ Y Tế",
            "Sở Y Tế",
            "Bệnh Viện"});
            this.loaidv.Location = new System.Drawing.Point(83, 4);
            this.loaidv.Name = "loaidv";
            this.loaidv.Size = new System.Drawing.Size(80, 21);
            this.loaidv.TabIndex = 0;
            this.loaidv.SelectedIndexChanged += new System.EventHandler(this.loaidv_SelectedIndexChanged);
            this.loaidv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaidv_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(162, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tỉnh/thành phố :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(252, 4);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(100, 21);
            this.matt.TabIndex = 1;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chủ quản :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhvien
            // 
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(427, 27);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(182, 21);
            this.benhvien.TabIndex = 4;
            this.benhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhvien_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(356, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bệnh viện :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soyte
            // 
            this.soyte.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soyte.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soyte.Location = new System.Drawing.Point(83, 27);
            this.soyte.Name = "soyte";
            this.soyte.Size = new System.Drawing.Size(270, 21);
            this.soyte.TabIndex = 3;
            this.soyte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soyte_KeyDown);
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(83, 50);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(270, 21);
            this.diachi.TabIndex = 5;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(427, 50);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(183, 21);
            this.dienthoai.TabIndex = 6;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dienthoai_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(356, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điện thoại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(427, 4);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(183, 21);
            this.maqu.TabIndex = 2;
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(340, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Quận/Huyện :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c61
            // 
            this.c61.Location = new System.Drawing.Point(5, 87);
            this.c61.Name = "c61";
            this.c61.Size = new System.Drawing.Size(200, 19);
            this.c61.TabIndex = 12;
            this.c61.Text = "Kiểm tra dị ứng trong đơn thuốc";
            this.c61.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(-3, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 23);
            this.label21.TabIndex = 71;
            this.label21.Text = "File thông báo :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c115
            // 
            this.c115.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c115.Enabled = false;
            this.c115.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c115.Location = new System.Drawing.Point(83, 73);
            this.c115.Name = "c115";
            this.c115.Size = new System.Drawing.Size(498, 21);
            this.c115.TabIndex = 72;
            // 
            // butThongbao
            // 
            this.butThongbao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThongbao.Location = new System.Drawing.Point(585, 72);
            this.butThongbao.Name = "butThongbao";
            this.butThongbao.Size = new System.Drawing.Size(24, 23);
            this.butThongbao.TabIndex = 73;
            this.butThongbao.Text = "...";
            this.butThongbao.Click += new System.EventHandler(this.butPath_Click);
            // 
            // c241
            // 
            this.c241.Location = new System.Drawing.Point(338, 11);
            this.c241.Name = "c241";
            this.c241.Size = new System.Drawing.Size(178, 18);
            this.c241.TabIndex = 203;
            this.c241.Text = "Trong nội trú + Phòng lưu";
            // 
            // c239
            // 
            this.c239.Location = new System.Drawing.Point(338, 29);
            this.c239.Name = "c239";
            this.c239.Size = new System.Drawing.Size(104, 18);
            this.c239.TabIndex = 202;
            this.c239.Text = "Trong xuất viện";
            this.c239.CheckedChanged += new System.EventHandler(this.c239_CheckedChanged);
            // 
            // chandoan
            // 
            this.chandoan.Location = new System.Drawing.Point(360, 259);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(209, 20);
            this.chandoan.TabIndex = 88;
            this.chandoan.Text = "Cho phép nhập theo chẩn đoán bệnh";
            // 
            // c227
            // 
            this.c227.Location = new System.Drawing.Point(338, 64);
            this.c227.Name = "c227";
            this.c227.Size = new System.Drawing.Size(168, 16);
            this.c227.TabIndex = 184;
            this.c227.Text = "Số lưu trữ = Số vào viện";
            this.c227.CheckedChanged += new System.EventHandler(this.c227_CheckedChanged);
            // 
            // c216
            // 
            this.c216.Location = new System.Drawing.Point(5, 47);
            this.c216.Name = "c216";
            this.c216.Size = new System.Drawing.Size(265, 19);
            this.c216.TabIndex = 201;
            this.c216.Text = "Số lưu trữ tăng tự động = 3 ký tự ICD+stt+năm 2 số";
            this.c216.CheckedChanged += new System.EventHandler(this.c216_CheckedChanged);
            // 
            // c226
            // 
            this.c226.Location = new System.Drawing.Point(5, 29);
            this.c226.Name = "c226";
            this.c226.Size = new System.Drawing.Size(168, 18);
            this.c226.TabIndex = 183;
            this.c226.Text = "Số lưu trữ tăng tự động";
            this.c226.CheckedChanged += new System.EventHandler(this.c226_CheckedChanged);
            // 
            // c225
            // 
            this.c225.Location = new System.Drawing.Point(178, 11);
            this.c225.Name = "c225";
            this.c225.Size = new System.Drawing.Size(123, 18);
            this.c225.TabIndex = 117;
            this.c225.Text = "Trong nội trú";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(80, 283);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(72, 16);
            this.label34.TabIndex = 115;
            this.label34.Text = "Giờ báo cáo :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c200
            // 
            this.c200.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c200.Location = new System.Drawing.Point(360, 128);
            this.c200.Name = "c200";
            this.c200.Size = new System.Drawing.Size(160, 24);
            this.c200.TabIndex = 111;
            this.c200.Text = "Số liệu cộng dồn theo kỳ";
            this.c200.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c111
            // 
            this.c111.Location = new System.Drawing.Point(360, 4);
            this.c111.Name = "c111";
            this.c111.Size = new System.Drawing.Size(198, 19);
            this.c111.TabIndex = 109;
            this.c111.Text = "Nhập số lưu trữ trong nhập viện";
            // 
            // c104
            // 
            this.c104.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c104.Location = new System.Drawing.Point(552, 328);
            this.c104.Name = "c104";
            this.c104.Size = new System.Drawing.Size(31, 21);
            this.c104.TabIndex = 100;
            this.c104.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(584, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 17);
            this.label8.TabIndex = 104;
            this.label8.Text = "tuổi";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(443, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "Khám nhi phải dưới";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c116
            // 
            this.c116.Location = new System.Drawing.Point(360, 95);
            this.c116.Name = "c116";
            this.c116.Size = new System.Drawing.Size(147, 19);
            this.c116.TabIndex = 99;
            this.c116.Text = "Thông tin khám thai";
            // 
            // c102
            // 
            this.c102.Location = new System.Drawing.Point(338, 48);
            this.c102.Name = "c102";
            this.c102.Size = new System.Drawing.Size(168, 16);
            this.c102.TabIndex = 78;
            this.c102.Text = "Số lưu trữ = Mã người bệnh";
            this.c102.CheckedChanged += new System.EventHandler(this.c102_CheckedChanged);
            // 
            // c42
            // 
            this.c42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c42.Location = new System.Drawing.Point(128, 328);
            this.c42.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.c42.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c42.Name = "c42";
            this.c42.Size = new System.Drawing.Size(32, 21);
            this.c42.TabIndex = 91;
            this.c42.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // c43
            // 
            this.c43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c43.Location = new System.Drawing.Point(248, 328);
            this.c43.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.c43.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c43.Name = "c43";
            this.c43.Size = new System.Drawing.Size(35, 21);
            this.c43.TabIndex = 93;
            this.c43.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(285, 333);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 14);
            this.label20.TabIndex = 98;
            this.label20.Text = "tuổi không đi học";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(163, 330);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 14);
            this.label18.TabIndex = 96;
            this.label18.Text = "tuổi đi học, dưới ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(80, 330);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 14);
            this.label19.TabIndex = 97;
            this.label19.Text = "Trẻ dưới ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c38
            // 
            this.c38.Location = new System.Drawing.Point(5, 93);
            this.c38.Name = "c38";
            this.c38.Size = new System.Drawing.Size(328, 21);
            this.c38.TabIndex = 81;
            this.c38.Text = "Liệt kê bệnh khác trong BC nhiễm,SXH,lây,viêm phổi,ARI";
            // 
            // solieu
            // 
            this.solieu.Location = new System.Drawing.Point(360, 239);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(221, 26);
            this.solieu.TabIndex = 80;
            this.solieu.Text = "Chỉ xem những mục có số liệu phát sinh";
            // 
            // pttt
            // 
            this.pttt.Location = new System.Drawing.Point(9, 6);
            this.pttt.Name = "pttt";
            this.pttt.Size = new System.Drawing.Size(331, 18);
            this.pttt.TabIndex = 85;
            this.pttt.Text = "Cho phép nhập theo phương pháp phẫu thuật - thủ thuật";
            // 
            // soluutru
            // 
            this.soluutru.Location = new System.Drawing.Point(360, 169);
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(152, 16);
            this.soluutru.TabIndex = 77;
            this.soluutru.Text = "Bắt buộc nhập số lưu trữ";
            // 
            // sovaovien
            // 
            this.sovaovien.Location = new System.Drawing.Point(5, 10);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(152, 18);
            this.sovaovien.TabIndex = 75;
            this.sovaovien.Text = "Số vào viện tự động";
            this.sovaovien.CheckedChanged += new System.EventHandler(this.sovaovien_CheckedChanged);
            // 
            // c242
            // 
            this.c242.Location = new System.Drawing.Point(298, 204);
            this.c242.Name = "c242";
            this.c242.Size = new System.Drawing.Size(155, 19);
            this.c242.TabIndex = 178;
            this.c242.Text = "32. Thanh toán theo khoa";
            this.c242.CheckedChanged += new System.EventHandler(this.c242_CheckedChanged);
            // 
            // c196
            // 
            this.c196.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c196.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c196.Location = new System.Drawing.Point(129, 5);
            this.c196.Name = "c196";
            this.c196.Size = new System.Drawing.Size(144, 21);
            this.c196.TabIndex = 177;
            // 
            // c191
            // 
            this.c191.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c191.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c191.Location = new System.Drawing.Point(43, 28);
            this.c191.Name = "c191";
            this.c191.Size = new System.Drawing.Size(245, 21);
            this.c191.TabIndex = 176;
            // 
            // mml
            // 
            this.mml.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mml.Location = new System.Drawing.Point(247, 6);
            this.mml.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mml.Name = "mml";
            this.mml.Size = new System.Drawing.Size(40, 21);
            this.mml.TabIndex = 173;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(7, 31);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(32, 16);
            this.label51.TabIndex = 175;
            this.label51.Text = "Kho :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(238, 8);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(8, 16);
            this.label52.TabIndex = 174;
            this.label52.Text = ":";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hhl
            // 
            this.hhl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hhl.Location = new System.Drawing.Point(195, 6);
            this.hhl.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hhl.Name = "hhl";
            this.hhl.Size = new System.Drawing.Size(40, 21);
            this.hhl.TabIndex = 172;
            // 
            // c186
            // 
            this.c186.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c186.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c186.Location = new System.Drawing.Point(235, 301);
            this.c186.Name = "c186";
            this.c186.Size = new System.Drawing.Size(127, 21);
            this.c186.TabIndex = 168;
            // 
            // mmt
            // 
            this.mmt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmt.Location = new System.Drawing.Point(144, 301);
            this.mmt.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mmt.Name = "mmt";
            this.mmt.Size = new System.Drawing.Size(40, 21);
            this.mmt.TabIndex = 165;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(206, 304);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(32, 16);
            this.label45.TabIndex = 167;
            this.label45.Text = "Kho :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(133, 302);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(8, 16);
            this.label46.TabIndex = 166;
            this.label46.Text = ":";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hht
            // 
            this.hht.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hht.Location = new System.Drawing.Point(86, 302);
            this.hht.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hht.Name = "hht";
            this.hht.Size = new System.Drawing.Size(40, 21);
            this.hht.TabIndex = 164;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(4, 304);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(114, 16);
            this.label47.TabIndex = 163;
            this.label47.Text = "Sau :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c179
            // 
            this.c179.Location = new System.Drawing.Point(299, 29);
            this.c179.Name = "c179";
            this.c179.Size = new System.Drawing.Size(225, 19);
            this.c179.TabIndex = 162;
            this.c179.Text = "25. Thanh toán chênh lệch giá dịch vụ";
            this.c179.CheckedChanged += new System.EventHandler(this.c179_CheckedChanged);
            // 
            // c112
            // 
            this.c112.Location = new System.Drawing.Point(334, 300);
            this.c112.Name = "c112";
            this.c112.Size = new System.Drawing.Size(233, 19);
            this.c112.TabIndex = 13;
            this.c112.Text = "Nhập thuốc && viện phí theo tên người bệnh";
            this.c112.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c128
            // 
            this.c128.Location = new System.Drawing.Point(605, 63);
            this.c128.Name = "c128";
            this.c128.Size = new System.Drawing.Size(295, 19);
            this.c128.TabIndex = 104;
            this.c128.Text = "46. Thanh toán viện phí (Không lấy số liệu dược)";
            this.c128.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c129
            // 
            this.c129.Location = new System.Drawing.Point(298, 237);
            this.c129.Name = "c129";
            this.c129.Size = new System.Drawing.Size(247, 19);
            this.c129.TabIndex = 105;
            this.c129.Text = "34. In chi tiết thanh toán theo từng khoa";
            this.c129.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c55
            // 
            this.c55.Location = new System.Drawing.Point(360, 293);
            this.c55.Name = "c55";
            this.c55.Size = new System.Drawing.Size(200, 21);
            this.c55.TabIndex = 1;
            this.c55.Text = "Nhập dấu sinh tồn trong y lệnh";
            // 
            // c58
            // 
            this.c58.Location = new System.Drawing.Point(5, 250);
            this.c58.Name = "c58";
            this.c58.Size = new System.Drawing.Size(292, 19);
            this.c58.TabIndex = 8;
            this.c58.Text = "12. Ràng buộc số biên lai trong khoản từ ... đến";
            // 
            // c177
            // 
            this.c177.Location = new System.Drawing.Point(170, 83);
            this.c177.Name = "c177";
            this.c177.Size = new System.Drawing.Size(106, 19);
            this.c177.TabIndex = 161;
            this.c177.Text = "Mã BN tự động";
            // 
            // c176
            // 
            this.c176.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c176.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c176.Location = new System.Drawing.Point(235, 323);
            this.c176.Name = "c176";
            this.c176.Size = new System.Drawing.Size(127, 21);
            this.c176.TabIndex = 160;
            // 
            // mmb
            // 
            this.mmb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmb.Location = new System.Drawing.Point(144, 324);
            this.mmb.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mmb.Name = "mmb";
            this.mmb.Size = new System.Drawing.Size(40, 21);
            this.mmb.TabIndex = 157;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(205, 325);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(32, 16);
            this.label44.TabIndex = 159;
            this.label44.Text = "Kho :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(133, 325);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(8, 16);
            this.label43.TabIndex = 158;
            this.label43.Text = ":";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hhb
            // 
            this.hhb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hhb.Location = new System.Drawing.Point(86, 324);
            this.hhb.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hhb.Name = "hhb";
            this.hhb.Size = new System.Drawing.Size(40, 21);
            this.hhb.TabIndex = 156;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(3, 326);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 16);
            this.label42.TabIndex = 155;
            this.label42.Text = "BHYT Sau :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c166
            // 
            this.c166.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c166.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c166.Location = new System.Drawing.Point(126, 50);
            this.c166.Name = "c166";
            this.c166.Size = new System.Drawing.Size(162, 21);
            this.c166.TabIndex = 150;
            this.c166.SelectedIndexChanged += new System.EventHandler(this.c166_SelectedIndexChanged);
            // 
            // c165
            // 
            this.c165.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c165.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c165.Location = new System.Drawing.Point(236, 234);
            this.c165.Name = "c165";
            this.c165.Size = new System.Drawing.Size(125, 21);
            this.c165.TabIndex = 149;
            this.c165.SelectedIndexChanged += new System.EventHandler(this.c165_SelectedIndexChanged);
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(4, 52);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(120, 17);
            this.label40.TabIndex = 148;
            this.label40.Text = "Nhóm dược bệnh viện :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c161
            // 
            this.c161.Location = new System.Drawing.Point(298, 275);
            this.c161.Name = "c161";
            this.c161.Size = new System.Drawing.Size(256, 19);
            this.c161.TabIndex = 144;
            this.c161.Text = "36. In phiếu thanh toán ra viện khi xuất khoa";
            // 
            // c158
            // 
            this.c158.Location = new System.Drawing.Point(9, 42);
            this.c158.Name = "c158";
            this.c158.Size = new System.Drawing.Size(226, 19);
            this.c158.TabIndex = 141;
            this.c158.Text = "Nhập thông tin hồi sức && dụng cụ";
            this.c158.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c157
            // 
            this.c157.Location = new System.Drawing.Point(5, 337);
            this.c157.Name = "c157";
            this.c157.Size = new System.Drawing.Size(234, 19);
            this.c157.TabIndex = 140;
            this.c157.Text = "17. Lấy thông tin chỉ định vào viện phí";
            this.c157.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c156
            // 
            this.c156.Location = new System.Drawing.Point(5, 70);
            this.c156.Name = "c156";
            this.c156.Size = new System.Drawing.Size(218, 19);
            this.c156.TabIndex = 139;
            this.c156.Text = "In đơn thuốc kèm cách dùng";
            this.c156.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c155
            // 
            this.c155.Location = new System.Drawing.Point(5, 267);
            this.c155.Name = "c155";
            this.c155.Size = new System.Drawing.Size(300, 19);
            this.c155.TabIndex = 138;
            this.c155.Text = "13. Thu tiền trong ngày (Chiều hôm qua && sáng hôm nay)";
            // 
            // c154
            // 
            this.c154.Location = new System.Drawing.Point(4, 119);
            this.c154.Name = "c154";
            this.c154.Size = new System.Drawing.Size(170, 19);
            this.c154.TabIndex = 137;
            this.c154.Text = "Kiểm tra hạn sử dụng số thẻ ";
            this.c154.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c151
            // 
            this.c151.Location = new System.Drawing.Point(5, 82);
            this.c151.Name = "c151";
            this.c151.Size = new System.Drawing.Size(265, 22);
            this.c151.TabIndex = 135;
            this.c151.Text = "5. Sử dụng chung ký hiệu quyển sổ trong đăng ký";
            this.c151.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c150
            // 
            this.c150.Location = new System.Drawing.Point(5, 302);
            this.c150.Name = "c150";
            this.c150.Size = new System.Drawing.Size(241, 19);
            this.c150.TabIndex = 134;
            this.c150.Text = "15. Chuyển chi phí cấp cứu vào nội trú";
            this.c150.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c149
            // 
            this.c149.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c149.Location = new System.Drawing.Point(407, 6);
            this.c149.Name = "c149";
            this.c149.Size = new System.Drawing.Size(188, 21);
            this.c149.TabIndex = 133;
            this.c149.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(285, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(120, 17);
            this.label39.TabIndex = 132;
            this.label39.Text = "24.Đối tượng tự nguyện :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c147
            // 
            this.c147.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c147.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c147.Location = new System.Drawing.Point(86, 279);
            this.c147.Name = "c147";
            this.c147.Size = new System.Drawing.Size(276, 21);
            this.c147.TabIndex = 130;
            this.c147.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(3, 281);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(108, 17);
            this.label38.TabIndex = 129;
            this.label38.Text = "Trẻ em < 6 tuổi :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c146
            // 
            this.c146.Location = new System.Drawing.Point(9, 24);
            this.c146.Name = "c146";
            this.c146.Size = new System.Drawing.Size(241, 19);
            this.c146.TabIndex = 128;
            this.c146.Text = "Sửa chi phí phẫu thủ thuật";
            this.c146.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c145
            // 
            this.c145.Location = new System.Drawing.Point(321, 102);
            this.c145.Name = "c145";
            this.c145.Size = new System.Drawing.Size(242, 19);
            this.c145.TabIndex = 127;
            this.c145.Text = "Chuyển thuốc/vật tư tiêu hao pttt vào dược";
            this.c145.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c144
            // 
            this.c144.Location = new System.Drawing.Point(5, 285);
            this.c144.Name = "c144";
            this.c144.Size = new System.Drawing.Size(241, 19);
            this.c144.TabIndex = 126;
            this.c144.Text = "14. Chuyển chi phí phẫu thủ thuật vào viện phí";
            this.c144.CheckedChanged += new System.EventHandler(this.c144_CheckedChanged);
            this.c144.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c143
            // 
            this.c143.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c143.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c143.Location = new System.Drawing.Point(173, 100);
            this.c143.Name = "c143";
            this.c143.Size = new System.Drawing.Size(274, 21);
            this.c143.TabIndex = 125;
            this.c143.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(5, 100);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(160, 17);
            this.label37.TabIndex = 124;
            this.label37.Text = "Nhóm viện phí phẫu thủ thuật :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c48
            // 
            this.c48.Location = new System.Drawing.Point(5, 217);
            this.c48.Name = "c48";
            this.c48.Size = new System.Drawing.Size(312, 16);
            this.c48.TabIndex = 5;
            this.c48.Text = "Cấp toa thuốc lấy số liệu trong danh mục thuốc bệnh viện";
            this.c48.CheckedChanged += new System.EventHandler(this.c48_CheckedChanged);
            // 
            // c135
            // 
            this.c135.Location = new System.Drawing.Point(5, 236);
            this.c135.Name = "c135";
            this.c135.Size = new System.Drawing.Size(232, 16);
            this.c135.TabIndex = 111;
            this.c135.Text = "Cấp toa thuốc lấy số liệu tồn nhà thuốc";
            this.c135.CheckedChanged += new System.EventHandler(this.c135_CheckedChanged);
            this.c135.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c131
            // 
            this.c131.Location = new System.Drawing.Point(4, 156);
            this.c131.Name = "c131";
            this.c131.Size = new System.Drawing.Size(312, 19);
            this.c131.TabIndex = 107;
            this.c131.Text = "Cho phép chỉnh sửa đối tượng ban đầu trong thuốc,viện phí";
            this.c131.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c140
            // 
            this.c140.Location = new System.Drawing.Point(5, 83);
            this.c140.Name = "c140";
            this.c140.Size = new System.Drawing.Size(106, 19);
            this.c140.TabIndex = 121;
            this.c140.Text = "Quản lý vân tay";
            this.c140.CheckedChanged += new System.EventHandler(this.c140_CheckedChanged);
            this.c140.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saoluu33_KeyDown);
            // 
            // c132
            // 
            this.c132.Location = new System.Drawing.Point(4, 99);
            this.c132.Name = "c132";
            this.c132.Size = new System.Drawing.Size(200, 19);
            this.c132.TabIndex = 108;
            this.c132.Text = "Chỉnh sửa đối tượng dịch vụ chi tiết";
            this.c132.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c130
            // 
            this.c130.Location = new System.Drawing.Point(5, 294);
            this.c130.Name = "c130";
            this.c130.Size = new System.Drawing.Size(200, 19);
            this.c130.TabIndex = 106;
            this.c130.Text = "In y lệnh kèm theo cách dùng";
            // 
            // c126
            // 
            this.c126.Location = new System.Drawing.Point(360, 223);
            this.c126.Name = "c126";
            this.c126.Size = new System.Drawing.Size(200, 19);
            this.c126.TabIndex = 102;
            this.c126.Text = "Dấu sinh tồn trong đăng ký";
            this.c126.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c125
            // 
            this.c125.Location = new System.Drawing.Point(8, 173);
            this.c125.Name = "c125";
            this.c125.Size = new System.Drawing.Size(130, 19);
            this.c125.TabIndex = 101;
            this.c125.Text = "Tình trạng hôn nhân";
            this.c125.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c110
            // 
            this.c110.Location = new System.Drawing.Point(298, 187);
            this.c110.Name = "c110";
            this.c110.Size = new System.Drawing.Size(175, 19);
            this.c110.TabIndex = 11;
            this.c110.Text = "31. Thanh toán nhiều đợt";
            this.c110.CheckedChanged += new System.EventHandler(this.c110_CheckedChanged);
            this.c110.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c51
            // 
            this.c51.Location = new System.Drawing.Point(5, 66);
            this.c51.Name = "c51";
            this.c51.Size = new System.Drawing.Size(106, 16);
            this.c51.TabIndex = 0;
            this.c51.Text = "Quản lý mã vạch";
            // 
            // c141
            // 
            this.c141.Location = new System.Drawing.Point(5, 233);
            this.c141.Name = "c141";
            this.c141.Size = new System.Drawing.Size(241, 19);
            this.c141.TabIndex = 122;
            this.c141.Text = "11. Nhập lý do miễn trong đăng ký";
            this.c141.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c139
            // 
            this.c139.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c139.Location = new System.Drawing.Point(890, 21);
            this.c139.Name = "c139";
            this.c139.Size = new System.Drawing.Size(43, 21);
            this.c139.TabIndex = 118;
            this.c139.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.c139.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(935, 22);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 16);
            this.label35.TabIndex = 119;
            this.label35.Text = "ngày";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(609, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(344, 17);
            this.label36.TabIndex = 120;
            this.label36.Text = "Kết thúc điều trị ngoại trú nếu người bệnh không tái khám ";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c137
            // 
            this.c137.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c137.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c137.Location = new System.Drawing.Point(237, 257);
            this.c137.Name = "c137";
            this.c137.Size = new System.Drawing.Size(125, 21);
            this.c137.TabIndex = 117;
            this.c137.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(207, 261);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 16);
            this.label33.TabIndex = 116;
            this.label33.Text = "Kho :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(129, 258);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(8, 16);
            this.label32.TabIndex = 115;
            this.label32.Text = ":";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(143, 257);
            this.mm.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(40, 21);
            this.mm.TabIndex = 114;
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // hh
            // 
            this.hh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh.Location = new System.Drawing.Point(85, 256);
            this.hh.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hh.Name = "hh";
            this.hh.Size = new System.Drawing.Size(40, 21);
            this.hh.TabIndex = 113;
            this.hh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(4, 261);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(40, 16);
            this.label31.TabIndex = 112;
            this.label31.Text = "Sau :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c134
            // 
            this.c134.Location = new System.Drawing.Point(5, 214);
            this.c134.Name = "c134";
            this.c134.Size = new System.Drawing.Size(241, 21);
            this.c134.TabIndex = 110;
            this.c134.Text = "10. Lựa chọn tiền khám trong đăng ký";
            this.c134.CheckedChanged += new System.EventHandler(this.c134_CheckedChanged);
            this.c134.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c57
            // 
            this.c57.Location = new System.Drawing.Point(5, 199);
            this.c57.Name = "c57";
            this.c57.Size = new System.Drawing.Size(241, 19);
            this.c57.TabIndex = 10;
            this.c57.Text = "9. Chọn ký hiệu biên lai";
            // 
            // c133
            // 
            this.c133.Location = new System.Drawing.Point(5, 62);
            this.c133.Name = "c133";
            this.c133.Size = new System.Drawing.Size(249, 23);
            this.c133.TabIndex = 109;
            this.c133.Text = "4. Chuyển tiền khám vào viện phí (không in)";
            this.c133.CheckedChanged += new System.EventHandler(this.c133_CheckedChanged);
            this.c133.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c127
            // 
            this.c127.Location = new System.Drawing.Point(360, 40);
            this.c127.Name = "c127";
            this.c127.Size = new System.Drawing.Size(168, 19);
            this.c127.TabIndex = 103;
            this.c127.Text = "Lý do khám trong đăng ký";
            this.c127.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c47
            // 
            this.c47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c47.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c47.Location = new System.Drawing.Point(5, 103);
            this.c47.Name = "c47";
            this.c47.Size = new System.Drawing.Size(241, 17);
            this.c47.TabIndex = 9;
            this.c47.Text = "6. Danh sách chờ đóng tiền";
            this.c47.CheckedChanged += new System.EventHandler(this.c47_CheckedChanged);
            // 
            // c46
            // 
            this.c46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c46.Location = new System.Drawing.Point(6, 7);
            this.c46.Name = "c46";
            this.c46.Size = new System.Drawing.Size(241, 16);
            this.c46.TabIndex = 6;
            this.c46.Text = "1. In tiền khám bệnh";
            this.c46.CheckedChanged += new System.EventHandler(this.c46_CheckedChanged);
            // 
            // c53
            // 
            this.c53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c53.Location = new System.Drawing.Point(5, 182);
            this.c53.Name = "c53";
            this.c53.Size = new System.Drawing.Size(241, 18);
            this.c53.TabIndex = 7;
            this.c53.Text = "8. Sửa đơn giá trong đăng ký";
            this.c53.CheckedChanged += new System.EventHandler(this.c53_CheckedChanged);
            // 
            // c52
            // 
            this.c52.Location = new System.Drawing.Point(360, 277);
            this.c52.Name = "c52";
            this.c52.Size = new System.Drawing.Size(168, 19);
            this.c52.TabIndex = 3;
            this.c52.Text = "In phiếu điều trị";
            // 
            // c214
            // 
            this.c214.Location = new System.Drawing.Point(5, 354);
            this.c214.Name = "c214";
            this.c214.Size = new System.Drawing.Size(265, 19);
            this.c214.TabIndex = 198;
            this.c214.Text = "18. In số vào viện trong phiếu thanh toán ra viện";
            // 
            // c205
            // 
            this.c205.Location = new System.Drawing.Point(4, 41);
            this.c205.Name = "c205";
            this.c205.Size = new System.Drawing.Size(337, 19);
            this.c205.TabIndex = 190;
            this.c205.Text = "Kiểm tra hạn sử dụng khi sử dụng dịch vụ";
            // 
            // c204
            // 
            this.c204.Location = new System.Drawing.Point(4, 22);
            this.c204.Name = "c204";
            this.c204.Size = new System.Drawing.Size(337, 19);
            this.c204.TabIndex = 189;
            this.c204.Text = "Kiểm tra số thẻ && mã  người bệnh";
            // 
            // c199
            // 
            this.c199.Location = new System.Drawing.Point(5, 43);
            this.c199.Name = "c199";
            this.c199.Size = new System.Drawing.Size(163, 19);
            this.c199.TabIndex = 183;
            this.c199.Text = "In chỉ định theo mẫu điền";
            // 
            // c198
            // 
            this.c198.Location = new System.Drawing.Point(5, 121);
            this.c198.Name = "c198";
            this.c198.Size = new System.Drawing.Size(240, 19);
            this.c198.TabIndex = 181;
            this.c198.Text = "Cho thuốc nhiều ngày trong ngày nghỉ,lễ tết";
            // 
            // c197
            // 
            this.c197.Location = new System.Drawing.Point(360, 187);
            this.c197.Name = "c197";
            this.c197.Size = new System.Drawing.Size(192, 19);
            this.c197.TabIndex = 180;
            this.c197.Text = "Số lưu trữ không được trùng";
            // 
            // c194
            // 
            this.c194.Location = new System.Drawing.Point(5, 174);
            this.c194.Name = "c194";
            this.c194.Size = new System.Drawing.Size(246, 24);
            this.c194.TabIndex = 179;
            this.c194.Text = "Tự động cập nhật lại đơn thuốc của bác sỹ";
            // 
            // c193
            // 
            this.c193.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c193.Location = new System.Drawing.Point(263, 333);
            this.c193.Name = "c193";
            this.c193.Size = new System.Drawing.Size(85, 21);
            this.c193.TabIndex = 177;
            // 
            // c192
            // 
            this.c192.Location = new System.Drawing.Point(4, 58);
            this.c192.Name = "c192";
            this.c192.Size = new System.Drawing.Size(208, 24);
            this.c192.TabIndex = 173;
            this.c192.Text = "Chỉnh sửa đối tượng trong khám bệnh";
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.CaptionText = "Lễ tết";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(747, 0);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(76, 92);
            this.dataGrid2.TabIndex = 172;
            // 
            // c188
            // 
            this.c188.Location = new System.Drawing.Point(605, 26);
            this.c188.Name = "c188";
            this.c188.Size = new System.Drawing.Size(208, 20);
            this.c188.TabIndex = 171;
            this.c188.Text = "44.Trẻ sơ sinh thanh toán theo bà mẹ";
            // 
            // mmtn
            // 
            this.mmtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmtn.Location = new System.Drawing.Point(226, 333);
            this.mmtn.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.mmtn.Name = "mmtn";
            this.mmtn.Size = new System.Drawing.Size(35, 21);
            this.mmtn.TabIndex = 169;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(217, 334);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(8, 16);
            this.label48.TabIndex = 170;
            this.label48.Text = ":";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hhtn
            // 
            this.hhtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hhtn.Location = new System.Drawing.Point(180, 333);
            this.hhtn.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hhtn.Name = "hhtn";
            this.hhtn.Size = new System.Drawing.Size(35, 21);
            this.hhtn.TabIndex = 168;
            // 
            // c153
            // 
            this.c153.Location = new System.Drawing.Point(5, 333);
            this.c153.Name = "c153";
            this.c153.Size = new System.Drawing.Size(186, 19);
            this.c153.TabIndex = 166;
            this.c153.Text = "Phân biệt khám trong/ngoài giờ";
            this.c153.CheckedChanged += new System.EventHandler(this.c153_CheckedChanged);
            // 
            // c184
            // 
            this.c184.Location = new System.Drawing.Point(5, 156);
            this.c184.Name = "c184";
            this.c184.Size = new System.Drawing.Size(208, 24);
            this.c184.TabIndex = 165;
            this.c184.Text = "Đơn thuốc số lần trong ngày";
            // 
            // c183
            // 
            this.c183.Location = new System.Drawing.Point(5, 444);
            this.c183.Name = "c183";
            this.c183.Size = new System.Drawing.Size(291, 19);
            this.c183.TabIndex = 164;
            this.c183.Text = "22. Đưa chi phí điều trị ngoại trú BHYT vào nội trú";
            // 
            // c182
            // 
            this.c182.Location = new System.Drawing.Point(5, 320);
            this.c182.Name = "c182";
            this.c182.Size = new System.Drawing.Size(280, 18);
            this.c182.TabIndex = 163;
            this.c182.Text = "16. Đơn thuốc cấp về tính vào chi phí nội ngoại trú";
            // 
            // c181
            // 
            this.c181.Location = new System.Drawing.Point(5, 310);
            this.c181.Name = "c181";
            this.c181.Size = new System.Drawing.Size(208, 24);
            this.c181.TabIndex = 162;
            this.c181.Text = "Y lệnh kèm theo đơn nhà thuốc";
            // 
            // c180
            // 
            this.c180.Location = new System.Drawing.Point(4, 77);
            this.c180.Name = "c180";
            this.c180.Size = new System.Drawing.Size(208, 24);
            this.c180.TabIndex = 161;
            this.c180.Text = "Chỉnh sửa đối tượng trong nhập khoa";
            // 
            // c169
            // 
            this.c169.Location = new System.Drawing.Point(5, 139);
            this.c169.Name = "c169";
            this.c169.Size = new System.Drawing.Size(192, 20);
            this.c169.TabIndex = 159;
            this.c169.Text = "Kiểm tra thuốc trùng trong ngày";
            // 
            // c159
            // 
            this.c159.Location = new System.Drawing.Point(9, 60);
            this.c159.Name = "c159";
            this.c159.Size = new System.Drawing.Size(226, 19);
            this.c159.TabIndex = 156;
            this.c159.Text = "Nhập số phiếu trong phẫu thủ thuật";
            // 
            // c164
            // 
            this.c164.Location = new System.Drawing.Point(5, 104);
            this.c164.Name = "c164";
            this.c164.Size = new System.Drawing.Size(160, 19);
            this.c164.TabIndex = 148;
            this.c164.Text = "In chỉ định vào đơn thuốc";
            // 
            // c163
            // 
            this.c163.Location = new System.Drawing.Point(4, 4);
            this.c163.Name = "c163";
            this.c163.Size = new System.Drawing.Size(192, 19);
            this.c163.TabIndex = 147;
            this.c163.Text = "BHYT nhập từ ngày ... đến ngày";
            // 
            // c273
            // 
            this.c273.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c273.Location = new System.Drawing.Point(344, 68);
            this.c273.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c273.Name = "c273";
            this.c273.Size = new System.Drawing.Size(44, 21);
            this.c273.TabIndex = 263;
            this.c273.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.c273.Visible = false;
            // 
            // c272
            // 
            this.c272.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c272.Location = new System.Drawing.Point(298, 68);
            this.c272.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c272.Name = "c272";
            this.c272.Size = new System.Drawing.Size(44, 21);
            this.c272.TabIndex = 262;
            this.c272.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // c271
            // 
            this.c271.Location = new System.Drawing.Point(8, 94);
            this.c271.Name = "c271";
            this.c271.Size = new System.Drawing.Size(186, 18);
            this.c271.TabIndex = 261;
            this.c271.Text = "Đọc hàng chục,trăm,ngàn";
            // 
            // c270
            // 
            this.c270.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c270.Location = new System.Drawing.Point(252, 68);
            this.c270.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c270.Name = "c270";
            this.c270.Size = new System.Drawing.Size(44, 21);
            this.c270.TabIndex = 260;
            this.c270.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // c269
            // 
            this.c269.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c269.Location = new System.Drawing.Point(206, 68);
            this.c269.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c269.Name = "c269";
            this.c269.Size = new System.Drawing.Size(44, 21);
            this.c269.TabIndex = 259;
            this.c269.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // c268
            // 
            this.c268.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c268.Location = new System.Drawing.Point(160, 68);
            this.c268.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c268.Name = "c268";
            this.c268.Size = new System.Drawing.Size(44, 21);
            this.c268.TabIndex = 258;
            this.c268.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // c267
            // 
            this.c267.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c267.Location = new System.Drawing.Point(115, 68);
            this.c267.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c267.Name = "c267";
            this.c267.Size = new System.Drawing.Size(44, 21);
            this.c267.TabIndex = 257;
            this.c267.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(9, 70);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(42, 17);
            this.label58.TabIndex = 256;
            this.label58.Text = "Sleep :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c266
            // 
            this.c266.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c266.Location = new System.Drawing.Point(66, 68);
            this.c266.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c266.Name = "c266";
            this.c266.Size = new System.Drawing.Size(48, 21);
            this.c266.TabIndex = 255;
            this.c266.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // c263
            // 
            this.c263.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c263.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c263.Location = new System.Drawing.Point(407, 329);
            this.c263.Name = "c263";
            this.c263.Size = new System.Drawing.Size(188, 21);
            this.c263.TabIndex = 249;
            // 
            // c262
            // 
            this.c262.Location = new System.Drawing.Point(298, 332);
            this.c262.Name = "c262";
            this.c262.Size = new System.Drawing.Size(127, 16);
            this.c262.TabIndex = 250;
            this.c262.Text = "39.Thu tiền in thẻ";
            this.c262.CheckedChanged += new System.EventHandler(this.c262_CheckedChanged);
            // 
            // c261
            // 
            this.c261.Location = new System.Drawing.Point(321, 48);
            this.c261.Name = "c261";
            this.c261.Size = new System.Drawing.Size(219, 19);
            this.c261.TabIndex = 248;
            this.c261.Text = "Hiện tổng số tiền tương đối trong đơn cấp";
            // 
            // c260
            // 
            this.c260.Location = new System.Drawing.Point(321, 66);
            this.c260.Name = "c260";
            this.c260.Size = new System.Drawing.Size(221, 19);
            this.c260.TabIndex = 247;
            this.c260.Text = "Đơn thuốc mua ngoài kiểm tra tồn kho";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(106, 48);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(22, 17);
            this.label56.TabIndex = 244;
            this.label56.Text = "số ";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c257
            // 
            this.c257.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c257.Location = new System.Drawing.Point(66, 45);
            this.c257.Name = "c257";
            this.c257.Size = new System.Drawing.Size(38, 21);
            this.c257.TabIndex = 242;
            this.c257.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(10, 45);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(55, 17);
            this.label55.TabIndex = 243;
            this.label55.Text = "1 lần gọi :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c256
            // 
            this.c256.Location = new System.Drawing.Point(9, 24);
            this.c256.Name = "c256";
            this.c256.Size = new System.Drawing.Size(201, 19);
            this.c256.TabIndex = 241;
            this.c256.Text = "Gọi người bệnh vào khám";
            this.c256.CheckedChanged += new System.EventHandler(this.c256_CheckedChanged);
            // 
            // c255
            // 
            this.c255.Location = new System.Drawing.Point(9, 5);
            this.c255.Name = "c255";
            this.c255.Size = new System.Drawing.Size(170, 19);
            this.c255.TabIndex = 240;
            this.c255.Text = "Gọi người bệnh vào đăng ký";
            this.c255.CheckedChanged += new System.EventHandler(this.c255_CheckedChanged);
            // 
            // c254
            // 
            this.c254.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c254.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c254.Location = new System.Drawing.Point(173, 77);
            this.c254.Name = "c254";
            this.c254.Size = new System.Drawing.Size(274, 21);
            this.c254.TabIndex = 239;
            // 
            // c253
            // 
            this.c253.Location = new System.Drawing.Point(9, 77);
            this.c253.Name = "c253";
            this.c253.Size = new System.Drawing.Size(238, 19);
            this.c253.TabIndex = 238;
            this.c253.Text = "Thủ thuật nhập theo chỉ định";
            this.c253.CheckedChanged += new System.EventHandler(this.c253_CheckedChanged);
            // 
            // c251
            // 
            this.c251.Location = new System.Drawing.Point(5, 7);
            this.c251.Name = "c251";
            this.c251.Size = new System.Drawing.Size(333, 19);
            this.c251.TabIndex = 236;
            this.c251.Text = "Gửi tin nhắn sau khi chỉ định";
            // 
            // c249
            // 
            this.c249.Location = new System.Drawing.Point(5, 426);
            this.c249.Name = "c249";
            this.c249.Size = new System.Drawing.Size(283, 19);
            this.c249.TabIndex = 234;
            this.c249.Text = "21. Đối tượng nộp tiền phải đóng tiền trước khi vào khám";
            this.c249.CheckedChanged += new System.EventHandler(this.c249_CheckedChanged);
            // 
            // c247
            // 
            this.c247.Location = new System.Drawing.Point(7, 28);
            this.c247.Name = "c247";
            this.c247.Size = new System.Drawing.Size(206, 19);
            this.c247.TabIndex = 232;
            this.c247.Text = "Bắt buộc nhập giường";
            // 
            // c246
            // 
            this.c246.Location = new System.Drawing.Point(5, 371);
            this.c246.Name = "c246";
            this.c246.Size = new System.Drawing.Size(278, 19);
            this.c246.TabIndex = 231;
            this.c246.Text = "19. In đối tượng hao phí trong phiếu thanh toán";
            this.c246.CheckedChanged += new System.EventHandler(this.c246_CheckedChanged);
            // 
            // c244
            // 
            this.c244.Location = new System.Drawing.Point(321, 84);
            this.c244.Name = "c244";
            this.c244.Size = new System.Drawing.Size(186, 19);
            this.c244.TabIndex = 229;
            this.c244.Text = "Tự động lưu lại cách dùng";
            // 
            // c243
            // 
            this.c243.Location = new System.Drawing.Point(5, 102);
            this.c243.Name = "c243";
            this.c243.Size = new System.Drawing.Size(278, 19);
            this.c243.TabIndex = 228;
            this.c243.Text = "Số khám phòng lưu tăng tự động";
            // 
            // c240
            // 
            this.c240.Location = new System.Drawing.Point(334, 265);
            this.c240.Name = "c240";
            this.c240.Size = new System.Drawing.Size(266, 19);
            this.c240.TabIndex = 227;
            this.c240.Text = "Xóa trắng bác sĩ khám bệnh khi nhập người bệnh mới";
            // 
            // c238
            // 
            this.c238.Location = new System.Drawing.Point(605, 100);
            this.c238.Name = "c238";
            this.c238.Size = new System.Drawing.Size(278, 19);
            this.c238.TabIndex = 226;
            this.c238.Text = "48. Cộng công khám khi in chi phí khám bệnh";
            // 
            // c237
            // 
            this.c237.Location = new System.Drawing.Point(605, 81);
            this.c237.Name = "c237";
            this.c237.Size = new System.Drawing.Size(297, 19);
            this.c237.TabIndex = 225;
            this.c237.Text = "47. In chi phí chuyển dịch vụ vào viện phí khám bệnh";
            // 
            // c236
            // 
            this.c236.Location = new System.Drawing.Point(7, 66);
            this.c236.Name = "c236";
            this.c236.Size = new System.Drawing.Size(160, 19);
            this.c236.TabIndex = 224;
            this.c236.Text = "Một giường 1 người bệnh";
            // 
            // c235
            // 
            this.c235.Location = new System.Drawing.Point(7, 47);
            this.c235.Name = "c235";
            this.c235.Size = new System.Drawing.Size(206, 19);
            this.c235.TabIndex = 223;
            this.c235.Text = "Quản lý phòng giường";
            this.c235.CheckedChanged += new System.EventHandler(this.c235_CheckedChanged);
            // 
            // c234
            // 
            this.c234.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c234.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c234.Location = new System.Drawing.Point(160, 5);
            this.c234.Name = "c234";
            this.c234.Size = new System.Drawing.Size(244, 21);
            this.c234.TabIndex = 222;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(-1, 7);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(160, 17);
            this.label54.TabIndex = 221;
            this.label54.Text = "Nhóm viện phí phòng/giường :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c233
            // 
            this.c233.Location = new System.Drawing.Point(321, 30);
            this.c233.Name = "c233";
            this.c233.Size = new System.Drawing.Size(265, 19);
            this.c233.TabIndex = 220;
            this.c233.Text = "In chữ ký điện tử trong đơn thuốc + chỉ định";
            // 
            // c232
            // 
            this.c232.Location = new System.Drawing.Point(334, 282);
            this.c232.Name = "c232";
            this.c232.Size = new System.Drawing.Size(171, 19);
            this.c232.TabIndex = 219;
            this.c232.Text = "Kiểm tra khi tạo số liệu mới";
            // 
            // c231
            // 
            this.c231.Location = new System.Drawing.Point(298, 256);
            this.c231.Name = "c231";
            this.c231.Size = new System.Drawing.Size(265, 19);
            this.c231.TabIndex = 218;
            this.c231.Text = "35. In chi phí theo loại viện phí";
            // 
            // c230
            // 
            this.c230.Location = new System.Drawing.Point(298, 293);
            this.c230.Name = "c230";
            this.c230.Size = new System.Drawing.Size(265, 19);
            this.c230.TabIndex = 217;
            this.c230.Text = "37. Phòng khám cuối in tổng hợp chi phí điều trị";
            // 
            // c229
            // 
            this.c229.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c229.Location = new System.Drawing.Point(266, 195);
            this.c229.Name = "c229";
            this.c229.Size = new System.Drawing.Size(96, 21);
            this.c229.TabIndex = 216;
            // 
            // c228
            // 
            this.c228.Location = new System.Drawing.Point(5, 196);
            this.c228.Name = "c228";
            this.c228.Size = new System.Drawing.Size(265, 19);
            this.c228.TabIndex = 215;
            this.c228.Text = "Đơn thuốc dược phát trong khám bệnh trừ tồn kho";
            this.c228.CheckedChanged += new System.EventHandler(this.c228_CheckedChanged);
            // 
            // c224
            // 
            this.c224.Location = new System.Drawing.Point(5, 141);
            this.c224.Name = "c224";
            this.c224.Size = new System.Drawing.Size(254, 24);
            this.c224.TabIndex = 214;
            this.c224.Text = "Đọc mã vạch";
            // 
            // c223
            // 
            this.c223.Location = new System.Drawing.Point(5, 119);
            this.c223.Name = "c223";
            this.c223.Size = new System.Drawing.Size(254, 24);
            this.c223.TabIndex = 213;
            this.c223.Text = "Mã BN tự động trong đăng ký khám bệnh";
            // 
            // c220
            // 
            this.c220.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c220.Location = new System.Drawing.Point(298, 410);
            this.c220.Name = "c220";
            this.c220.Size = new System.Drawing.Size(297, 21);
            this.c220.TabIndex = 212;
            // 
            // c219
            // 
            this.c219.Location = new System.Drawing.Point(307, 392);
            this.c219.Name = "c219";
            this.c219.Size = new System.Drawing.Size(265, 19);
            this.c219.TabIndex = 211;
            this.c219.Text = "41. Tái khám chuyển chi phí vào điều trị";
            this.c219.CheckedChanged += new System.EventHandler(this.c219_CheckedChanged_1);
            // 
            // c218
            // 
            this.c218.Location = new System.Drawing.Point(298, 221);
            this.c218.Name = "c218";
            this.c218.Size = new System.Drawing.Size(265, 19);
            this.c218.TabIndex = 210;
            this.c218.Text = "33. Thanh toán làm tròn số lượng";
            // 
            // c217
            // 
            this.c217.Location = new System.Drawing.Point(298, 310);
            this.c217.Name = "c217";
            this.c217.Size = new System.Drawing.Size(297, 19);
            this.c217.TabIndex = 209;
            this.c217.Text = "38. In phiếu thanh toán ra viện khi người bệnh đã ra viện";
            // 
            // c171
            // 
            this.c171.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c171.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c171.Location = new System.Drawing.Point(178, 113);
            this.c171.Name = "c171";
            this.c171.Size = new System.Drawing.Size(420, 21);
            this.c171.TabIndex = 155;
            // 
            // c170
            // 
            this.c170.Location = new System.Drawing.Point(7, 114);
            this.c170.Name = "c170";
            this.c170.Size = new System.Drawing.Size(192, 24);
            this.c170.TabIndex = 154;
            this.c170.Text = "Kết xuất nội dung ra bảng điện";
            this.c170.CheckedChanged += new System.EventHandler(this.c170_CheckedChanged);
            // 
            // c59
            // 
            this.c59.Controls.Add(this.c593);
            this.c59.Controls.Add(this.c592);
            this.c59.Controls.Add(this.c591);
            this.c59.Location = new System.Drawing.Point(5, 168);
            this.c59.Name = "c59";
            this.c59.Size = new System.Drawing.Size(300, 47);
            this.c59.TabIndex = 70;
            this.c59.TabStop = false;
            this.c59.Text = "Số khám tự động";
            // 
            // c593
            // 
            this.c593.Location = new System.Drawing.Point(197, 15);
            this.c593.Name = "c593";
            this.c593.Size = new System.Drawing.Size(95, 25);
            this.c593.TabIndex = 2;
            this.c593.Text = "Bỏ qua";
            // 
            // c592
            // 
            this.c592.Location = new System.Drawing.Point(93, 15);
            this.c592.Name = "c592";
            this.c592.Size = new System.Drawing.Size(152, 25);
            this.c592.TabIndex = 1;
            this.c592.Text = "Theo phòng";
            // 
            // c591
            // 
            this.c591.Checked = true;
            this.c591.Location = new System.Drawing.Point(8, 15);
            this.c591.Name = "c591";
            this.c591.Size = new System.Drawing.Size(152, 26);
            this.c591.TabIndex = 0;
            this.c591.TabStop = true;
            this.c591.Text = "Toàn viện";
            // 
            // c56
            // 
            this.c56.Controls.Add(this.c563);
            this.c56.Controls.Add(this.c562);
            this.c56.Controls.Add(this.c561);
            this.c56.Location = new System.Drawing.Point(615, 6);
            this.c56.Name = "c56";
            this.c56.Size = new System.Drawing.Size(119, 83);
            this.c56.TabIndex = 71;
            this.c56.TabStop = false;
            this.c56.Text = "Xem sử dụng thuốc";
            // 
            // c563
            // 
            this.c563.Location = new System.Drawing.Point(9, 58);
            this.c563.Name = "c563";
            this.c563.Size = new System.Drawing.Size(88, 22);
            this.c563.TabIndex = 2;
            this.c563.Text = "Bỏ qua";
            // 
            // c562
            // 
            this.c562.Location = new System.Drawing.Point(9, 38);
            this.c562.Name = "c562";
            this.c562.Size = new System.Drawing.Size(85, 21);
            this.c562.TabIndex = 1;
            this.c562.Text = "Theo đợt";
            // 
            // c561
            // 
            this.c561.Checked = true;
            this.c561.Location = new System.Drawing.Point(9, 18);
            this.c561.Name = "c561";
            this.c561.Size = new System.Drawing.Size(82, 21);
            this.c561.TabIndex = 0;
            this.c561.TabStop = true;
            this.c561.Text = "Toàn bộ";
            // 
            // c60
            // 
            this.c60.Controls.Add(this.c604);
            this.c60.Controls.Add(this.c603);
            this.c60.Controls.Add(this.c602);
            this.c60.Controls.Add(this.c601);
            this.c60.Location = new System.Drawing.Point(477, 5);
            this.c60.Name = "c60";
            this.c60.Size = new System.Drawing.Size(121, 102);
            this.c60.TabIndex = 72;
            this.c60.TabStop = false;
            this.c60.Text = "Xem chỉ định";
            // 
            // c604
            // 
            this.c604.Location = new System.Drawing.Point(10, 74);
            this.c604.Name = "c604";
            this.c604.Size = new System.Drawing.Size(80, 19);
            this.c604.TabIndex = 3;
            this.c604.Text = "Bỏ qua";
            // 
            // c603
            // 
            this.c603.Location = new System.Drawing.Point(10, 54);
            this.c603.Name = "c603";
            this.c603.Size = new System.Drawing.Size(101, 19);
            this.c603.TabIndex = 2;
            this.c603.Text = "Đợt vào khoa";
            // 
            // c602
            // 
            this.c602.Location = new System.Drawing.Point(10, 35);
            this.c602.Name = "c602";
            this.c602.Size = new System.Drawing.Size(104, 19);
            this.c602.TabIndex = 1;
            this.c602.Text = "Đợt vào viện";
            // 
            // c601
            // 
            this.c601.Checked = true;
            this.c601.Location = new System.Drawing.Point(10, 16);
            this.c601.Name = "c601";
            this.c601.Size = new System.Drawing.Size(92, 19);
            this.c601.TabIndex = 0;
            this.c601.TabStop = true;
            this.c601.Text = "Toàn bộ";
            // 
            // c113
            // 
            this.c113.Controls.Add(this.c1134);
            this.c113.Controls.Add(this.c1133);
            this.c113.Controls.Add(this.c1132);
            this.c113.Controls.Add(this.c1131);
            this.c113.Location = new System.Drawing.Point(606, 420);
            this.c113.Name = "c113";
            this.c113.Size = new System.Drawing.Size(296, 57);
            this.c113.TabIndex = 73;
            this.c113.TabStop = false;
            this.c113.Text = "53. Xem chi phí điều trị";
            // 
            // c1134
            // 
            this.c1134.Location = new System.Drawing.Point(149, 33);
            this.c1134.Name = "c1134";
            this.c1134.Size = new System.Drawing.Size(107, 20);
            this.c1134.TabIndex = 3;
            this.c1134.Text = "Bỏ qua";
            // 
            // c1133
            // 
            this.c1133.Location = new System.Drawing.Point(21, 33);
            this.c1133.Name = "c1133";
            this.c1133.Size = new System.Drawing.Size(115, 19);
            this.c1133.TabIndex = 2;
            this.c1133.Text = "Đợt vào khoa";
            // 
            // c1132
            // 
            this.c1132.Location = new System.Drawing.Point(149, 16);
            this.c1132.Name = "c1132";
            this.c1132.Size = new System.Drawing.Size(111, 16);
            this.c1132.TabIndex = 1;
            this.c1132.Text = "Đợt vào viện";
            // 
            // c1131
            // 
            this.c1131.Checked = true;
            this.c1131.Location = new System.Drawing.Point(21, 16);
            this.c1131.Name = "c1131";
            this.c1131.Size = new System.Drawing.Size(91, 19);
            this.c1131.TabIndex = 0;
            this.c1131.TabStop = true;
            this.c1131.Text = "Toàn bộ";
            // 
            // chophep
            // 
            this.chophep.Enabled = false;
            this.chophep.Location = new System.Drawing.Point(431, 194);
            this.chophep.Name = "chophep";
            this.chophep.Size = new System.Drawing.Size(176, 24);
            this.chophep.TabIndex = 2;
            this.chophep.Text = "Cho phép tiếp đón người bệnh";
            this.chophep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chophep_KeyDown);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(148, 197);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(280, 21);
            this.ten.TabIndex = 1;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.HighlightText;
            this.id.Enabled = false;
            this.id.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(53, 198);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(40, 21);
            this.id.TabIndex = 0;
            this.id.Validated += new System.EventHandler(this.id_Validated);
            this.id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(69, 196);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 23);
            this.label23.TabIndex = 23;
            this.label23.Text = "Diễn giải :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(-18, 198);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 23);
            this.label22.TabIndex = 21;
            this.label22.Text = "Mã số :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(601, 200);
            this.dataGrid1.TabIndex = 20;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(368, 223);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(306, 223);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(244, 223);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butThem
            // 
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(182, 223);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 5;
            this.butThem.Text = "&Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // c178
            // 
            this.c178.Location = new System.Drawing.Point(4, 138);
            this.c178.Name = "c178";
            this.c178.Size = new System.Drawing.Size(226, 19);
            this.c178.TabIndex = 157;
            this.c178.Text = "Hiện danh sách khi nhập số thẻ";
            // 
            // c148
            // 
            this.c148.Location = new System.Drawing.Point(360, 206);
            this.c148.Name = "c148";
            this.c148.Size = new System.Drawing.Size(168, 19);
            this.c148.TabIndex = 131;
            this.c148.Text = "Chọn bác sỹ trong đăng ký";
            this.c148.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c195
            // 
            this.c195.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c195.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c195.Location = new System.Drawing.Point(334, 248);
            this.c195.Name = "c195";
            this.c195.Size = new System.Drawing.Size(192, 19);
            this.c195.TabIndex = 178;
            this.c195.Text = "Mẫu đăng ký khám bệnh số 1";
            // 
            // c108
            // 
            this.c108.Location = new System.Drawing.Point(5, 221);
            this.c108.Name = "c108";
            this.c108.Size = new System.Drawing.Size(339, 19);
            this.c108.TabIndex = 184;
            this.c108.Text = "Tự động chuyển thông tin vào điều trị nội trú trong khám bệnh";
            // 
            // c109
            // 
            this.c109.Location = new System.Drawing.Point(5, 238);
            this.c109.Name = "c109";
            this.c109.Size = new System.Drawing.Size(337, 19);
            this.c109.TabIndex = 185;
            this.c109.Text = "Tự động chuyển thông tin vào điều trị ngoại trú trong khám bệnh";
            // 
            // c201
            // 
            this.c201.Location = new System.Drawing.Point(5, 255);
            this.c201.Name = "c201";
            this.c201.Size = new System.Drawing.Size(337, 19);
            this.c201.TabIndex = 186;
            this.c201.Text = "Tự động chuyển thông tin vào điều trị nội trú trong ngoại trú";
            // 
            // c203
            // 
            this.c203.Location = new System.Drawing.Point(5, 271);
            this.c203.Name = "c203";
            this.c203.Size = new System.Drawing.Size(337, 19);
            this.c203.TabIndex = 188;
            this.c203.Text = "Tự động chuyển thông tin vào điều trị ngoại trú trong phòng lưu";
            // 
            // c202
            // 
            this.c202.Location = new System.Drawing.Point(5, 288);
            this.c202.Name = "c202";
            this.c202.Size = new System.Drawing.Size(337, 19);
            this.c202.TabIndex = 187;
            this.c202.Text = "Tự động chuyển thông tin vào điều trị nội trú trong phòng lưu";
            // 
            // ngonngu
            // 
            this.ngonngu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngonngu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngonngu.Location = new System.Drawing.Point(185, 305);
            this.ngonngu.Name = "ngonngu";
            this.ngonngu.Size = new System.Drawing.Size(98, 21);
            this.ngonngu.TabIndex = 114;
            this.ngonngu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngonngu_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(78, 305);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 21);
            this.label30.TabIndex = 113;
            this.label30.Text = "Ngôn ngữ thể hiện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c118
            // 
            this.c118.Location = new System.Drawing.Point(5, 112);
            this.c118.Name = "c118";
            this.c118.Size = new System.Drawing.Size(331, 19);
            this.c118.TabIndex = 112;
            this.c118.Text = "Nhập phẫu thuật thủ thuật theo phòng mỗ";
            this.c118.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c114
            // 
            this.c114.Location = new System.Drawing.Point(8, 120);
            this.c114.Name = "c114";
            this.c114.Size = new System.Drawing.Size(312, 18);
            this.c114.TabIndex = 110;
            this.c114.Text = "Bắt buộc nhập mã bà mẹ";
            // 
            // c107
            // 
            this.c107.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c107.Location = new System.Drawing.Point(143, 194);
            this.c107.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.c107.Name = "c107";
            this.c107.Size = new System.Drawing.Size(40, 21);
            this.c107.TabIndex = 105;
            this.c107.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(185, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 17);
            this.label9.TabIndex = 108;
            this.label9.Text = "tuổi";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(2, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 16);
            this.label12.TabIndex = 107;
            this.label12.Text = "Tuổi tối đa người bệnh";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c106
            // 
            this.c106.Location = new System.Drawing.Point(360, 22);
            this.c106.Name = "c106";
            this.c106.Size = new System.Drawing.Size(177, 19);
            this.c106.TabIndex = 106;
            this.c106.Text = "Phân biệt người bệnh mới/cũ";
            // 
            // ngaylv
            // 
            this.ngaylv.Location = new System.Drawing.Point(83, 249);
            this.ngaylv.Name = "ngaylv";
            this.ngaylv.Size = new System.Drawing.Size(269, 16);
            this.ngaylv.TabIndex = 87;
            this.ngaylv.Text = "Mặc nhiên ngày làm việc bằng ngày hiện hành";
            // 
            // c100
            // 
            this.c100.Location = new System.Drawing.Point(5, 77);
            this.c100.Name = "c100";
            this.c100.Size = new System.Drawing.Size(339, 17);
            this.c100.TabIndex = 95;
            this.c100.Text = "Thống kê chẩn đoán nguyên nhân vào tình hình bệnh tật";
            // 
            // c54
            // 
            this.c54.Location = new System.Drawing.Point(360, 149);
            this.c54.Name = "c54";
            this.c54.Size = new System.Drawing.Size(107, 18);
            this.c54.TabIndex = 76;
            this.c54.Text = "Chỉnh sửa ICD10";
            // 
            // c44
            // 
            this.c44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c44.Location = new System.Drawing.Point(8, 139);
            this.c44.Name = "c44";
            this.c44.Size = new System.Drawing.Size(331, 16);
            this.c44.TabIndex = 94;
            this.c44.Text = "Kiểm tra hợp lệ họ tên và giới tính";
            // 
            // c0
            // 
            this.c0.Location = new System.Drawing.Point(8, 104);
            this.c0.Name = "c0";
            this.c0.Size = new System.Drawing.Size(344, 16);
            this.c0.TabIndex = 83;
            this.c0.Text = "Cho phép điều chỉnh thông tin hành chính trong nhập/xuất khoa";
            // 
            // songay
            // 
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(364, 186);
            this.songay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(50, 21);
            this.songay.TabIndex = 82;
            this.songay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // c36
            // 
            this.c36.Location = new System.Drawing.Point(5, 38);
            this.c36.Name = "c36";
            this.c36.Size = new System.Drawing.Size(339, 23);
            this.c36.TabIndex = 90;
            this.c36.Text = "Chỉnh sửa thông tin nhập viện trong nhập khoa";
            // 
            // saoluu33
            // 
            this.saoluu33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saoluu33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.saoluu33.Location = new System.Drawing.Point(83, 229);
            this.saoluu33.Name = "saoluu33";
            this.saoluu33.Size = new System.Drawing.Size(331, 17);
            this.saoluu33.TabIndex = 84;
            this.saoluu33.Text = "Thông báo sao lưu số liệu trước khi kết thúc chương trình";
            // 
            // noichuyen
            // 
            this.noichuyen.Location = new System.Drawing.Point(5, 56);
            this.noichuyen.Name = "noichuyen";
            this.noichuyen.Size = new System.Drawing.Size(331, 22);
            this.noichuyen.TabIndex = 89;
            this.noichuyen.Text = "Cho phép điều chỉnh nơi chuyển trong nhập khoa";
            // 
            // khambenh
            // 
            this.khambenh.Location = new System.Drawing.Point(5, 5);
            this.khambenh.Name = "khambenh";
            this.khambenh.Size = new System.Drawing.Size(328, 20);
            this.khambenh.TabIndex = 79;
            this.khambenh.Text = "Bắt buộc phải nhập chẩn đoán trong khám bệnh";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(413, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 86;
            this.label11.Text = "ngày";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(63, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 17);
            this.label10.TabIndex = 92;
            this.label10.Text = "Khoảng cách ngày làm việc so với ngày hệ thống :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label50.Location = new System.Drawing.Point(17, 209);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(344, 17);
            this.label50.TabIndex = 170;
            this.label50.Text = "Số chương trình Medisoft kích hoạt tối đa trên mỗi máy là :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c189
            // 
            this.c189.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c189.Location = new System.Drawing.Point(364, 209);
            this.c189.Name = "c189";
            this.c189.Size = new System.Drawing.Size(50, 21);
            this.c189.TabIndex = 169;
            this.c189.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // c160
            // 
            this.c160.Location = new System.Drawing.Point(5, 131);
            this.c160.Name = "c160";
            this.c160.Size = new System.Drawing.Size(192, 19);
            this.c160.TabIndex = 143;
            this.c160.Text = "Chẩn đoán phải có trong ICD10";
            // 
            // c45
            // 
            this.c45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c45.Location = new System.Drawing.Point(83, 267);
            this.c45.Name = "c45";
            this.c45.Size = new System.Drawing.Size(162, 15);
            this.c45.TabIndex = 4;
            this.c45.Text = "Xem trước khi in";
            // 
            // c142
            // 
            this.c142.Location = new System.Drawing.Point(8, 156);
            this.c142.Name = "c142";
            this.c142.Size = new System.Drawing.Size(241, 19);
            this.c142.TabIndex = 123;
            this.c142.Text = "Nhập điện thoại người bệnh trong đăng ký";
            this.c142.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c105
            // 
            this.c105.Location = new System.Drawing.Point(5, 169);
            this.c105.Name = "c105";
            this.c105.Size = new System.Drawing.Size(312, 16);
            this.c105.TabIndex = 2;
            this.c105.Text = "Hiện danh sách đăng ký trong khám bệnh";
            // 
            // c215
            // 
            this.c215.Location = new System.Drawing.Point(5, 22);
            this.c215.Name = "c215";
            this.c215.Size = new System.Drawing.Size(229, 19);
            this.c215.TabIndex = 199;
            this.c215.Text = "Thông tin phòng khám phải được chỉ định";
            // 
            // c213
            // 
            this.c213.Location = new System.Drawing.Point(5, 205);
            this.c213.Name = "c213";
            this.c213.Size = new System.Drawing.Size(307, 19);
            this.c213.TabIndex = 197;
            this.c213.Text = "Phòng mỗ sử dụng thuốc && dịch vụ không cần nhập khoa";
            // 
            // c167
            // 
            this.c167.Location = new System.Drawing.Point(360, 111);
            this.c167.Name = "c167";
            this.c167.Size = new System.Drawing.Size(160, 22);
            this.c167.TabIndex = 160;
            this.c167.Text = "In số vào viện trong y lệnh";
            // 
            // c162
            // 
            this.c162.Location = new System.Drawing.Point(360, 76);
            this.c162.Name = "c162";
            this.c162.Size = new System.Drawing.Size(136, 19);
            this.c162.TabIndex = 158;
            this.c162.Text = "Xem các lần tiếp đón";
            // 
            // c172
            // 
            this.c172.Location = new System.Drawing.Point(608, 63);
            this.c172.Name = "c172";
            this.c172.Size = new System.Drawing.Size(192, 20);
            this.c172.TabIndex = 154;
            this.c172.Text = "Nhập nơi giới thiệu trong đăng ký";
            // 
            // c275
            // 
            this.c275.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c275.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c275.Items.AddRange(new object[] {
            "BMP",
            "JPG",
            "JPEG",
            "GIF",
            "TIFF",
            "PNG"});
            this.c275.Location = new System.Drawing.Point(143, 60);
            this.c275.Name = "c275";
            this.c275.Size = new System.Drawing.Size(50, 21);
            this.c275.TabIndex = 264;
            // 
            // c264
            // 
            this.c264.Location = new System.Drawing.Point(8, 61);
            this.c264.Name = "c264";
            this.c264.Size = new System.Drawing.Size(141, 19);
            this.c264.TabIndex = 254;
            this.c264.Text = "Lưu thành tập tin";
            this.c264.CheckedChanged += new System.EventHandler(this.c264_CheckedChanged);
            // 
            // butImage
            // 
            this.butImage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImage.Location = new System.Drawing.Point(583, 82);
            this.butImage.Name = "butImage";
            this.butImage.Size = new System.Drawing.Size(24, 23);
            this.butImage.TabIndex = 253;
            this.butImage.Text = "...";
            this.butImage.UseVisualStyleBackColor = true;
            this.butImage.Click += new System.EventHandler(this.butImage_Click);
            // 
            // c265
            // 
            this.c265.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c265.Enabled = false;
            this.c265.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c265.Location = new System.Drawing.Point(143, 83);
            this.c265.Name = "c265";
            this.c265.Size = new System.Drawing.Size(437, 21);
            this.c265.TabIndex = 252;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(-27, 80);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(168, 23);
            this.label57.TabIndex = 251;
            this.label57.Text = "Đường dẫn sao lưu số liệu :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c259
            // 
            this.c259.Location = new System.Drawing.Point(5, 257);
            this.c259.Name = "c259";
            this.c259.Size = new System.Drawing.Size(214, 19);
            this.c259.TabIndex = 246;
            this.c259.Text = "Nhập triệu chứng lâm sàng ban đầu";
            // 
            // c258
            // 
            this.c258.Location = new System.Drawing.Point(8, 21);
            this.c258.Name = "c258";
            this.c258.Size = new System.Drawing.Size(201, 19);
            this.c258.TabIndex = 245;
            this.c258.Text = "Chọn hình người bệnh";
            this.c258.CheckedChanged += new System.EventHandler(this.c258_CheckedChanged);
            // 
            // c252
            // 
            this.c252.Location = new System.Drawing.Point(5, 186);
            this.c252.Name = "c252";
            this.c252.Size = new System.Drawing.Size(238, 19);
            this.c252.TabIndex = 237;
            this.c252.Text = "Dấu sinh tồn trong khám bệnh && phòng lưu";
            // 
            // c250
            // 
            this.c250.Location = new System.Drawing.Point(5, 241);
            this.c250.Name = "c250";
            this.c250.Size = new System.Drawing.Size(333, 19);
            this.c250.TabIndex = 235;
            this.c250.Text = "Chuyển phòng khám tự động chuyển vào danh sách chờ";
            // 
            // c248
            // 
            this.c248.Location = new System.Drawing.Point(8, 4);
            this.c248.Name = "c248";
            this.c248.Size = new System.Drawing.Size(142, 19);
            this.c248.TabIndex = 233;
            this.c248.Text = "Quản lý hình người bệnh";
            this.c248.CheckedChanged += new System.EventHandler(this.c248_CheckedChanged);
            // 
            // c245
            // 
            this.c245.Location = new System.Drawing.Point(5, 150);
            this.c245.Name = "c245";
            this.c245.Size = new System.Drawing.Size(232, 19);
            this.c245.TabIndex = 230;
            this.c245.Text = "Chuyển khám bắt buộc nhập chẩn đoán";
            // 
            // c276
            // 
            this.c276.Location = new System.Drawing.Point(5, 276);
            this.c276.Name = "c276";
            this.c276.Size = new System.Drawing.Size(228, 18);
            this.c276.TabIndex = 263;
            this.c276.Text = "Đơn thuốc nhập theo sáng, trưa , chiều";
            // 
            // c274
            // 
            this.c274.Location = new System.Drawing.Point(360, 58);
            this.c274.Name = "c274";
            this.c274.Size = new System.Drawing.Size(186, 18);
            this.c274.TabIndex = 262;
            this.c274.Text = "Chỉnh sửa giờ khám bệnh";
            // 
            // c121
            // 
            this.c121.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c121.ItemHeight = 13;
            this.c121.Location = new System.Drawing.Point(73, 263);
            this.c121.Name = "c121";
            this.c121.Size = new System.Drawing.Size(153, 21);
            this.c121.TabIndex = 113;
            // 
            // but174
            // 
            this.but174.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but174.Location = new System.Drawing.Point(585, 96);
            this.but174.Name = "but174";
            this.but174.Size = new System.Drawing.Size(24, 23);
            this.but174.TabIndex = 158;
            this.but174.Text = "...";
            this.but174.UseVisualStyleBackColor = true;
            this.but174.Click += new System.EventHandler(this.but174_Click);
            // 
            // c174
            // 
            this.c174.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c174.Enabled = false;
            this.c174.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c174.Location = new System.Drawing.Point(83, 96);
            this.c174.Name = "c174";
            this.c174.Size = new System.Drawing.Size(498, 21);
            this.c174.TabIndex = 157;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(-83, 94);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(168, 23);
            this.label41.TabIndex = 156;
            this.label41.Text = "Sao lưu số liệu :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c124
            // 
            this.c124.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c124.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c124.Location = new System.Drawing.Point(73, 217);
            this.c124.Name = "c124";
            this.c124.Size = new System.Drawing.Size(537, 21);
            this.c124.TabIndex = 110;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(32, 310);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 23);
            this.label29.TabIndex = 118;
            this.label29.Text = "Tỉnh :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c123
            // 
            this.c123.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c123.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c123.ItemHeight = 13;
            this.c123.Location = new System.Drawing.Point(73, 308);
            this.c123.Name = "c123";
            this.c123.Size = new System.Drawing.Size(153, 21);
            this.c123.TabIndex = 115;
            // 
            // c122
            // 
            this.c122.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c122.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c122.ItemHeight = 13;
            this.c122.Location = new System.Drawing.Point(73, 285);
            this.c122.Name = "c122";
            this.c122.Size = new System.Drawing.Size(153, 21);
            this.c122.TabIndex = 114;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(15, 283);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 23);
            this.label28.TabIndex = 117;
            this.label28.Text = "Dân tộc :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c119
            // 
            this.c119.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c119.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c119.ItemHeight = 13;
            this.c119.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.c119.Location = new System.Drawing.Point(73, 240);
            this.c119.Name = "c119";
            this.c119.Size = new System.Drawing.Size(72, 21);
            this.c119.TabIndex = 111;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 217);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 23);
            this.label27.TabIndex = 116;
            this.label27.Text = "VÔ DANH :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 240);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 107;
            this.label24.Text = "Giới tính :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c120
            // 
            this.c120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c120.Location = new System.Drawing.Point(186, 240);
            this.c120.Name = "c120";
            this.c120.Size = new System.Drawing.Size(40, 21);
            this.c120.TabIndex = 112;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(148, 240);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 23);
            this.label25.TabIndex = 108;
            this.label25.Text = "Tuổi :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(-8, 263);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 23);
            this.label26.TabIndex = 109;
            this.label26.Text = "Nghề nghiệp :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c39
            // 
            this.c39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c39.Location = new System.Drawing.Point(82, 350);
            this.c39.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c39.Name = "c39";
            this.c39.Size = new System.Drawing.Size(135, 21);
            this.c39.TabIndex = 100;
            // 
            // c40
            // 
            this.c40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c40.Location = new System.Drawing.Point(273, 350);
            this.c40.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c40.Name = "c40";
            this.c40.Size = new System.Drawing.Size(135, 21);
            this.c40.TabIndex = 101;
            // 
            // c41
            // 
            this.c41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c41.Location = new System.Drawing.Point(474, 350);
            this.c41.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c41.Name = "c41";
            this.c41.Size = new System.Drawing.Size(135, 21);
            this.c41.TabIndex = 102;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(392, 348);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 106;
            this.label17.Text = "Thống kê :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(215, 348);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 23);
            this.label16.TabIndex = 105;
            this.label16.Text = "KHTH :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(19, 351);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 104;
            this.label15.Text = "Giám đốc :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bsPttt
            // 
            this.bsPttt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsPttt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsPttt.Location = new System.Drawing.Point(265, 40);
            this.bsPttt.Name = "bsPttt";
            this.bsPttt.Size = new System.Drawing.Size(144, 20);
            this.bsPttt.TabIndex = 99;
            this.bsPttt.Text = "Phẩu thuật - thủ thuật";
            // 
            // bsXuatvien
            // 
            this.bsXuatvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsXuatvien.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsXuatvien.Location = new System.Drawing.Point(143, 40);
            this.bsXuatvien.Name = "bsXuatvien";
            this.bsXuatvien.Size = new System.Drawing.Size(87, 20);
            this.bsXuatvien.TabIndex = 98;
            this.bsXuatvien.Text = "Xuất viện";
            // 
            // bsXuatkhoa
            // 
            this.bsXuatkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsXuatkhoa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsXuatkhoa.Location = new System.Drawing.Point(16, 40);
            this.bsXuatkhoa.Name = "bsXuatkhoa";
            this.bsXuatkhoa.Size = new System.Drawing.Size(80, 20);
            this.bsXuatkhoa.TabIndex = 97;
            this.bsXuatkhoa.Text = "Xuất khoa";
            // 
            // bsNhapkhoa
            // 
            this.bsNhapkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNhapkhoa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsNhapkhoa.Location = new System.Drawing.Point(379, 23);
            this.bsNhapkhoa.Name = "bsNhapkhoa";
            this.bsNhapkhoa.Size = new System.Drawing.Size(96, 20);
            this.bsNhapkhoa.TabIndex = 96;
            this.bsNhapkhoa.Text = "Nhập khoa";
            // 
            // bsNhanbenh
            // 
            this.bsNhanbenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNhanbenh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsNhanbenh.Location = new System.Drawing.Point(265, 23);
            this.bsNhanbenh.Name = "bsNhanbenh";
            this.bsNhanbenh.Size = new System.Drawing.Size(80, 20);
            this.bsNhanbenh.TabIndex = 95;
            this.bsNhanbenh.Text = "Nhận bệnh";
            // 
            // bsNgoaitru
            // 
            this.bsNgoaitru.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNgoaitru.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsNgoaitru.Location = new System.Drawing.Point(142, 23);
            this.bsNgoaitru.Name = "bsNgoaitru";
            this.bsNgoaitru.Size = new System.Drawing.Size(113, 20);
            this.bsNgoaitru.TabIndex = 94;
            this.bsNgoaitru.Text = "Bệnh án ngoại trú";
            // 
            // bsKhambenh
            // 
            this.bsKhambenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsKhambenh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bsKhambenh.Location = new System.Drawing.Point(16, 23);
            this.bsKhambenh.Name = "bsKhambenh";
            this.bsKhambenh.Size = new System.Drawing.Size(120, 20);
            this.bsKhambenh.TabIndex = 93;
            this.bsKhambenh.Text = "Phiếu khám bệnh";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(2, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 450);
            this.treeView1.TabIndex = 76;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // txtNodeTextSearch
            // 
            this.txtNodeTextSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNodeTextSearch.ForeColor = System.Drawing.Color.Red;
            this.txtNodeTextSearch.Location = new System.Drawing.Point(2, 3);
            this.txtNodeTextSearch.Name = "txtNodeTextSearch";
            this.txtNodeTextSearch.Size = new System.Drawing.Size(152, 21);
            this.txtNodeTextSearch.TabIndex = 77;
            this.txtNodeTextSearch.Text = "Tìm kiếm";
            this.txtNodeTextSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNodeTextSearch.TextChanged += new System.EventHandler(this.txtNodeTextSearch_TextChanged);
            this.txtNodeTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeTextSearch_KeyDown);
            this.txtNodeTextSearch.Enter += new System.EventHandler(this.txtNodeTextSearch_Enter);
            // 
            // p01
            // 
            this.p01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p01.AutoScroll = true;
            this.p01.Controls.Add(this.c386);
            this.p01.Controls.Add(this.c115);
            this.p01.Controls.Add(this.songaydemo);
            this.p01.Controls.Add(this.demo);
            this.p01.Controls.Add(this.but341);
            this.p01.Controls.Add(this.c341);
            this.p01.Controls.Add(this.c340);
            this.p01.Controls.Add(this.c138h);
            this.p01.Controls.Add(this.c138m);
            this.p01.Controls.Add(this.label53);
            this.p01.Controls.Add(this.c277);
            this.p01.Controls.Add(this.butTemp);
            this.p01.Controls.Add(this.tTemp);
            this.p01.Controls.Add(this.lTemp);
            this.p01.Controls.Add(this.c112);
            this.p01.Controls.Add(this.c232);
            this.p01.Controls.Add(this.c240);
            this.p01.Controls.Add(this.label8);
            this.p01.Controls.Add(this.c104);
            this.p01.Controls.Add(this.label7);
            this.p01.Controls.Add(this.label34);
            this.p01.Controls.Add(this.groupBox1);
            this.p01.Controls.Add(this.c41);
            this.p01.Controls.Add(this.songay);
            this.p01.Controls.Add(this.but174);
            this.p01.Controls.Add(this.dienthoai);
            this.p01.Controls.Add(this.c195);
            this.p01.Controls.Add(this.c174);
            this.p01.Controls.Add(this.label20);
            this.p01.Controls.Add(this.c43);
            this.p01.Controls.Add(this.label18);
            this.p01.Controls.Add(this.c42);
            this.p01.Controls.Add(this.label19);
            this.p01.Controls.Add(this.matt);
            this.p01.Controls.Add(this.label41);
            this.p01.Controls.Add(this.diachi);
            this.p01.Controls.Add(this.soyte);
            this.p01.Controls.Add(this.benhvien);
            this.p01.Controls.Add(this.maqu);
            this.p01.Controls.Add(this.loaidv);
            this.p01.Controls.Add(this.c189);
            this.p01.Controls.Add(this.label50);
            this.p01.Controls.Add(this.ngonngu);
            this.p01.Controls.Add(this.c40);
            this.p01.Controls.Add(this.label17);
            this.p01.Controls.Add(this.ngaylv);
            this.p01.Controls.Add(this.c39);
            this.p01.Controls.Add(this.label1);
            this.p01.Controls.Add(this.label30);
            this.p01.Controls.Add(this.label16);
            this.p01.Controls.Add(this.label2);
            this.p01.Controls.Add(this.label13);
            this.p01.Controls.Add(this.label3);
            this.p01.Controls.Add(this.label15);
            this.p01.Controls.Add(this.label4);
            this.p01.Controls.Add(this.label5);
            this.p01.Controls.Add(this.label6);
            this.p01.Controls.Add(this.label21);
            this.p01.Controls.Add(this.butThongbao);
            this.p01.Controls.Add(this.saoluu33);
            this.p01.Controls.Add(this.label10);
            this.p01.Controls.Add(this.label11);
            this.p01.Controls.Add(this.c45);
            this.p01.Location = new System.Drawing.Point(159, 3);
            this.p01.Name = "p01";
            this.p01.Size = new System.Drawing.Size(527, 500);
            this.p01.TabIndex = 78;
            this.p01.Visible = false;
            // 
            // c386
            // 
            this.c386.Location = new System.Drawing.Point(83, 449);
            this.c386.Name = "c386";
            this.c386.Size = new System.Drawing.Size(233, 19);
            this.c386.TabIndex = 240;
            this.c386.Text = "Bật bộ gõ tiếng việt theo chương trình";
            // 
            // songaydemo
            // 
            this.songaydemo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaydemo.Location = new System.Drawing.Point(512, 185);
            this.songaydemo.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.songaydemo.Name = "songaydemo";
            this.songaydemo.Size = new System.Drawing.Size(36, 21);
            this.songaydemo.TabIndex = 239;
            this.songaydemo.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.songaydemo.Visible = false;
            // 
            // demo
            // 
            this.demo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.demo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.demo.Location = new System.Drawing.Point(460, 186);
            this.demo.Name = "demo";
            this.demo.Size = new System.Drawing.Size(141, 17);
            this.demo.TabIndex = 238;
            this.demo.Text = "Demo               ngày";
            this.demo.Visible = false;
            // 
            // but341
            // 
            this.but341.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but341.Location = new System.Drawing.Point(585, 119);
            this.but341.Name = "but341";
            this.but341.Size = new System.Drawing.Size(24, 23);
            this.but341.TabIndex = 237;
            this.but341.Text = "...";
            this.but341.UseVisualStyleBackColor = true;
            this.but341.Click += new System.EventHandler(this.but341_Click);
            // 
            // c341
            // 
            this.c341.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c341.Enabled = false;
            this.c341.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c341.Location = new System.Drawing.Point(359, 119);
            this.c341.Name = "c341";
            this.c341.Size = new System.Drawing.Size(223, 21);
            this.c341.TabIndex = 236;
            // 
            // c340
            // 
            this.c340.Location = new System.Drawing.Point(9, 120);
            this.c340.Name = "c340";
            this.c340.Size = new System.Drawing.Size(358, 22);
            this.c340.TabIndex = 235;
            this.c340.Text = "Tự động cập nhật lại version, thư mục chứa MEDISOFT tổng thể :";
            this.c340.CheckedChanged += new System.EventHandler(this.c340_CheckedChanged);
            // 
            // c138h
            // 
            this.c138h.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c138h.Location = new System.Drawing.Point(185, 282);
            this.c138h.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.c138h.Name = "c138h";
            this.c138h.Size = new System.Drawing.Size(40, 21);
            this.c138h.TabIndex = 232;
            // 
            // c138m
            // 
            this.c138m.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c138m.Location = new System.Drawing.Point(235, 282);
            this.c138m.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.c138m.Name = "c138m";
            this.c138m.Size = new System.Drawing.Size(40, 21);
            this.c138m.TabIndex = 233;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(226, 284);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(8, 16);
            this.label53.TabIndex = 234;
            this.label53.Text = ":";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c277
            // 
            this.c277.Location = new System.Drawing.Point(345, 140);
            this.c277.Name = "c277";
            this.c277.Size = new System.Drawing.Size(244, 22);
            this.c277.TabIndex = 231;
            this.c277.Text = "Tự động hủy các tập tin trong thư mục TEMP";
            // 
            // butTemp
            // 
            this.butTemp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTemp.Location = new System.Drawing.Point(583, 162);
            this.butTemp.Name = "butTemp";
            this.butTemp.Size = new System.Drawing.Size(24, 23);
            this.butTemp.TabIndex = 230;
            this.butTemp.Text = "...";
            this.butTemp.UseVisualStyleBackColor = true;
            this.butTemp.Click += new System.EventHandler(this.butTemp_Click);
            // 
            // tTemp
            // 
            this.tTemp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tTemp.Enabled = false;
            this.tTemp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTemp.Location = new System.Drawing.Point(83, 163);
            this.tTemp.Name = "tTemp";
            this.tTemp.Size = new System.Drawing.Size(498, 21);
            this.tTemp.TabIndex = 229;
            // 
            // lTemp
            // 
            this.lTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lTemp.Location = new System.Drawing.Point(5, 141);
            this.lTemp.Name = "lTemp";
            this.lTemp.Size = new System.Drawing.Size(507, 23);
            this.lTemp.TabIndex = 228;
            this.lTemp.Text = "Thư mục TEMP của :";
            this.lTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bsKhambenh);
            this.groupBox1.Controls.Add(this.bsNgoaitru);
            this.groupBox1.Controls.Add(this.bsNhanbenh);
            this.groupBox1.Controls.Add(this.bsNhapkhoa);
            this.groupBox1.Controls.Add(this.bsXuatkhoa);
            this.groupBox1.Controls.Add(this.bsXuatvien);
            this.groupBox1.Controls.Add(this.bsPttt);
            this.groupBox1.Location = new System.Drawing.Point(83, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 62);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LỌC DANH SÁCH BÁC SĨ THEO KHOA/PHÒNG TRONG CÁC BIỂU NHẬP SAU :";
            // 
            // p02
            // 
            this.p02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p02.AutoScroll = true;
            this.p02.Controls.Add(this.c343);
            this.p02.Controls.Add(this.c121);
            this.p02.Controls.Add(this.c119);
            this.p02.Controls.Add(this.c275);
            this.p02.Controls.Add(this.c125);
            this.p02.Controls.Add(this.c123);
            this.p02.Controls.Add(this.label29);
            this.p02.Controls.Add(this.c0);
            this.p02.Controls.Add(this.c114);
            this.p02.Controls.Add(this.c122);
            this.p02.Controls.Add(this.c44);
            this.p02.Controls.Add(this.butImage);
            this.p02.Controls.Add(this.label28);
            this.p02.Controls.Add(this.label9);
            this.p02.Controls.Add(this.c107);
            this.p02.Controls.Add(this.c265);
            this.p02.Controls.Add(this.c124);
            this.p02.Controls.Add(this.label12);
            this.p02.Controls.Add(this.label57);
            this.p02.Controls.Add(this.c264);
            this.p02.Controls.Add(this.c142);
            this.p02.Controls.Add(this.label27);
            this.p02.Controls.Add(this.label26);
            this.p02.Controls.Add(this.c120);
            this.p02.Controls.Add(this.label24);
            this.p02.Controls.Add(this.label25);
            this.p02.Controls.Add(this.c248);
            this.p02.Controls.Add(this.c258);
            this.p02.Location = new System.Drawing.Point(159, 3);
            this.p02.Name = "p02";
            this.p02.Size = new System.Drawing.Size(527, 500);
            this.p02.TabIndex = 79;
            this.p02.Visible = false;
            // 
            // c343
            // 
            this.c343.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c343.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c343.Location = new System.Drawing.Point(8, 40);
            this.c343.Name = "c343";
            this.c343.Size = new System.Drawing.Size(201, 19);
            this.c343.TabIndex = 265;
            this.c343.Text = "Quản lý Smard Card";
            // 
            // p03
            // 
            this.p03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p03.AutoScroll = true;
            this.p03.Controls.Add(this.c404);
            this.p03.Controls.Add(this.c393);
            this.p03.Controls.Add(this.c385);
            this.p03.Controls.Add(this.c373);
            this.p03.Controls.Add(this.c361);
            this.p03.Controls.Add(this.c354);
            this.p03.Controls.Add(this.c344);
            this.p03.Controls.Add(this.c330);
            this.p03.Controls.Add(this.label35);
            this.p03.Controls.Add(this.c139);
            this.p03.Controls.Add(this.c329);
            this.p03.Controls.Add(this.c327);
            this.p03.Controls.Add(this.label80);
            this.p03.Controls.Add(this.c325);
            this.p03.Controls.Add(this.label81);
            this.p03.Controls.Add(this.c324);
            this.p03.Controls.Add(this.c323);
            this.p03.Controls.Add(this.c322);
            this.p03.Controls.Add(this.c315);
            this.p03.Controls.Add(this.label74);
            this.p03.Controls.Add(this.label66);
            this.p03.Controls.Add(this.c305);
            this.p03.Controls.Add(this.label65);
            this.p03.Controls.Add(this.c296);
            this.p03.Controls.Add(this.c295);
            this.p03.Controls.Add(this.c193);
            this.p03.Controls.Add(this.chandoan);
            this.p03.Controls.Add(this.mmtn);
            this.p03.Controls.Add(this.c55);
            this.p03.Controls.Add(this.label48);
            this.p03.Controls.Add(this.hhtn);
            this.p03.Controls.Add(this.c126);
            this.p03.Controls.Add(this.c130);
            this.p03.Controls.Add(this.c153);
            this.p03.Controls.Add(this.solieu);
            this.p03.Controls.Add(this.c181);
            this.p03.Controls.Add(this.c276);
            this.p03.Controls.Add(this.c215);
            this.p03.Controls.Add(this.c274);
            this.p03.Controls.Add(this.c52);
            this.p03.Controls.Add(this.c197);
            this.p03.Controls.Add(this.c38);
            this.p03.Controls.Add(this.khambenh);
            this.p03.Controls.Add(this.c54);
            this.p03.Controls.Add(this.c148);
            this.p03.Controls.Add(this.c200);
            this.p03.Controls.Add(this.c213);
            this.p03.Controls.Add(this.c111);
            this.p03.Controls.Add(this.noichuyen);
            this.p03.Controls.Add(this.c36);
            this.p03.Controls.Add(this.c116);
            this.p03.Controls.Add(this.c100);
            this.p03.Controls.Add(this.c106);
            this.p03.Controls.Add(this.c118);
            this.p03.Controls.Add(this.c160);
            this.p03.Controls.Add(this.c105);
            this.p03.Controls.Add(this.c162);
            this.p03.Controls.Add(this.c259);
            this.p03.Controls.Add(this.c167);
            this.p03.Controls.Add(this.c252);
            this.p03.Controls.Add(this.c250);
            this.p03.Controls.Add(this.c172);
            this.p03.Controls.Add(this.c245);
            this.p03.Controls.Add(this.soluutru);
            this.p03.Controls.Add(this.label36);
            this.p03.Controls.Add(this.c127);
            this.p03.Location = new System.Drawing.Point(159, 3);
            this.p03.Name = "p03";
            this.p03.Size = new System.Drawing.Size(527, 500);
            this.p03.TabIndex = 80;
            this.p03.Visible = false;
            // 
            // c393
            // 
            this.c393.Location = new System.Drawing.Point(608, 96);
            this.c393.Name = "c393";
            this.c393.Size = new System.Drawing.Size(341, 20);
            this.c393.TabIndex = 285;
            this.c393.Text = "Người bệnh đang điều trị ngoại trú không cho nhập phòng khám";
            // 
            // c385
            // 
            this.c385.Location = new System.Drawing.Point(608, 79);
            this.c385.Name = "c385";
            this.c385.Size = new System.Drawing.Size(243, 20);
            this.c385.TabIndex = 284;
            this.c385.Text = "Lọc thuốc + dịch vụ theo đối tượng chỉ định";
            // 
            // c373
            // 
            this.c373.Location = new System.Drawing.Point(5, 223);
            this.c373.Name = "c373";
            this.c373.Size = new System.Drawing.Size(281, 17);
            this.c373.TabIndex = 283;
            this.c373.Text = "Nhập tường trình phẩu thuật vắng tắt trong xuất khoa";
            // 
            // c361
            // 
            this.c361.Location = new System.Drawing.Point(608, 4);
            this.c361.Name = "c361";
            this.c361.Size = new System.Drawing.Size(348, 17);
            this.c361.TabIndex = 282;
            this.c361.Text = "Tiếp đón nhiều phòng khám cùng 1 lúc in chung chi phí điều trị";
            // 
            // c354
            // 
            this.c354.Location = new System.Drawing.Point(608, 48);
            this.c354.Name = "c354";
            this.c354.Size = new System.Drawing.Size(221, 17);
            this.c354.TabIndex = 281;
            this.c354.Text = "Chọn bác sỹ trong khám bệnh";
            // 
            // c344
            // 
            this.c344.Location = new System.Drawing.Point(360, 458);
            this.c344.Name = "c344";
            this.c344.Size = new System.Drawing.Size(221, 17);
            this.c344.TabIndex = 280;
            this.c344.Text = "Tiền sử bệnh nhập tự do";
            // 
            // c330
            // 
            this.c330.Location = new System.Drawing.Point(360, 442);
            this.c330.Name = "c330";
            this.c330.Size = new System.Drawing.Size(221, 17);
            this.c330.TabIndex = 279;
            this.c330.Text = "Khám bệnh nhập theo mẫu bệnh án";
            // 
            // c329
            // 
            this.c329.Location = new System.Drawing.Point(360, 425);
            this.c329.Name = "c329";
            this.c329.Size = new System.Drawing.Size(221, 17);
            this.c329.TabIndex = 278;
            this.c329.Text = "Toa thuốc && chỉ định lấy ngày hiện hành";
            // 
            // c327
            // 
            this.c327.Location = new System.Drawing.Point(360, 407);
            this.c327.Name = "c327";
            this.c327.Size = new System.Drawing.Size(221, 21);
            this.c327.TabIndex = 277;
            this.c327.Text = "Tiếp đón nhận bệnh điều trị ngoại trú";
            // 
            // label80
            // 
            this.label80.Location = new System.Drawing.Point(507, 389);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(32, 16);
            this.label80.TabIndex = 275;
            this.label80.Text = "ngày";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c325
            // 
            this.c325.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c325.Location = new System.Drawing.Point(460, 386);
            this.c325.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c325.Name = "c325";
            this.c325.Size = new System.Drawing.Size(43, 21);
            this.c325.TabIndex = 274;
            // 
            // label81
            // 
            this.label81.Location = new System.Drawing.Point(359, 387);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(179, 17);
            this.label81.TabIndex = 276;
            this.label81.Text = "Hẹn tái khám tối đa";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c324
            // 
            this.c324.CheckOnClick = true;
            this.c324.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c324.FormattingEnabled = true;
            this.c324.Location = new System.Drawing.Point(360, 332);
            this.c324.Name = "c324";
            this.c324.Size = new System.Drawing.Size(230, 52);
            this.c324.TabIndex = 273;
            // 
            // c323
            // 
            this.c323.Location = new System.Drawing.Point(509, 312);
            this.c323.Name = "c323";
            this.c323.Size = new System.Drawing.Size(85, 21);
            this.c323.TabIndex = 272;
            this.c323.Text = "In phiếu hẹn";
            // 
            // c322
            // 
            this.c322.Location = new System.Drawing.Point(360, 312);
            this.c322.Name = "c322";
            this.c322.Size = new System.Drawing.Size(200, 21);
            this.c322.TabIndex = 271;
            this.c322.Text = "Tái khám nhập ngày hẹn";
            this.c322.CheckedChanged += new System.EventHandler(this.c322_CheckedChanged);
            // 
            // c315
            // 
            this.c315.CheckOnClick = true;
            this.c315.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c315.FormattingEnabled = true;
            this.c315.Location = new System.Drawing.Point(128, 419);
            this.c315.Name = "c315";
            this.c315.Size = new System.Drawing.Size(220, 52);
            this.c315.TabIndex = 270;
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(7, 416);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(179, 17);
            this.label74.TabIndex = 269;
            this.label74.Text = "Chỉ được chuyển khoa";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(212, 396);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(32, 16);
            this.label66.TabIndex = 267;
            this.label66.Text = "lần";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c305
            // 
            this.c305.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c305.Location = new System.Drawing.Point(166, 393);
            this.c305.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c305.Name = "c305";
            this.c305.Size = new System.Drawing.Size(43, 21);
            this.c305.TabIndex = 266;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(5, 395);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(179, 17);
            this.label65.TabIndex = 268;
            this.label65.Text = "Số lần tái khám điều trị ngoại trú";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c296
            // 
            this.c296.Location = new System.Drawing.Point(5, 375);
            this.c296.Name = "c296";
            this.c296.Size = new System.Drawing.Size(346, 21);
            this.c296.TabIndex = 265;
            this.c296.Text = "Nhập thông tin bác sĩ, bệnh viện giới thiệu";
            // 
            // c295
            // 
            this.c295.Location = new System.Drawing.Point(5, 355);
            this.c295.Name = "c295";
            this.c295.Size = new System.Drawing.Size(347, 21);
            this.c295.TabIndex = 264;
            this.c295.Text = "Cho phép nhập khám bệnh người bệnh đăng ký ngày hôm qua";
            // 
            // p12
            // 
            this.p12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p12.AutoScroll = true;
            this.p12.Controls.Add(this.butFile);
            this.p12.Controls.Add(this.id);
            this.p12.Controls.Add(this.butBoqua);
            this.p12.Controls.Add(this.chophep);
            this.p12.Controls.Add(this.butLuu);
            this.p12.Controls.Add(this.dataGrid1);
            this.p12.Controls.Add(this.butSua);
            this.p12.Controls.Add(this.ten);
            this.p12.Controls.Add(this.butThem);
            this.p12.Controls.Add(this.label22);
            this.p12.Controls.Add(this.label23);
            this.p12.Controls.Add(this.dataGrid3);
            this.p12.Location = new System.Drawing.Point(159, 3);
            this.p12.Name = "p12";
            this.p12.Size = new System.Drawing.Size(527, 500);
            this.p12.TabIndex = 81;
            this.p12.Visible = false;
            // 
            // butFile
            // 
            this.butFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butFile.Location = new System.Drawing.Point(587, 227);
            this.butFile.Name = "butFile";
            this.butFile.Size = new System.Drawing.Size(24, 23);
            this.butFile.TabIndex = 199;
            this.butFile.Text = "...";
            this.toolTip1.SetToolTip(this.butFile, "Tập tin tin nhắn giống nhau trong phân hệ");
            this.butFile.Click += new System.EventHandler(this.butFile_Click);
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.CaptionText = "Nhập vào tập tin tin nhắn";
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(7, 231);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 10;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(602, 264);
            this.dataGrid3.TabIndex = 198;
            // 
            // p04
            // 
            this.p04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p04.AutoScroll = true;
            this.p04.Controls.Add(this.c346);
            this.p04.Controls.Add(this.c301);
            this.p04.Controls.Add(this.c239);
            this.p04.Controls.Add(this.c216);
            this.p04.Controls.Add(this.c59);
            this.p04.Controls.Add(this.c241);
            this.p04.Controls.Add(this.sovaovien);
            this.p04.Controls.Add(this.c225);
            this.p04.Controls.Add(this.c226);
            this.p04.Controls.Add(this.c51);
            this.p04.Controls.Add(this.c140);
            this.p04.Controls.Add(this.c177);
            this.p04.Controls.Add(this.c243);
            this.p04.Controls.Add(this.c108);
            this.p04.Controls.Add(this.c203);
            this.p04.Controls.Add(this.c201);
            this.p04.Controls.Add(this.c202);
            this.p04.Controls.Add(this.c109);
            this.p04.Controls.Add(this.c223);
            this.p04.Controls.Add(this.c224);
            this.p04.Controls.Add(this.c102);
            this.p04.Controls.Add(this.c227);
            this.p04.Location = new System.Drawing.Point(159, 3);
            this.p04.Name = "p04";
            this.p04.Size = new System.Drawing.Size(527, 500);
            this.p04.TabIndex = 82;
            this.p04.Visible = false;
            // 
            // c346
            // 
            this.c346.Location = new System.Drawing.Point(4, 306);
            this.c346.Name = "c346";
            this.c346.Size = new System.Drawing.Size(337, 19);
            this.c346.TabIndex = 230;
            this.c346.Text = "Tự động chuyển thông tin vào phòng lưu trong khám bệnh";
            // 
            // c301
            // 
            this.c301.Location = new System.Drawing.Point(178, 29);
            this.c301.Name = "c301";
            this.c301.Size = new System.Drawing.Size(104, 18);
            this.c301.TabIndex = 229;
            this.c301.Text = "Trong xuất khoa";
            this.c301.CheckedChanged += new System.EventHandler(this.c301_CheckedChanged);
            // 
            // p05
            // 
            this.p05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p05.AutoScroll = true;
            this.p05.Controls.Add(this.c365);
            this.p05.Controls.Add(this.label95);
            this.p05.Controls.Add(this.c362);
            this.p05.Controls.Add(this.c360);
            this.p05.Controls.Add(this.c348);
            this.p05.Controls.Add(this.c353);
            this.p05.Controls.Add(this.c351);
            this.p05.Controls.Add(this.c352);
            this.p05.Controls.Add(this.c350);
            this.p05.Controls.Add(this.c349);
            this.p05.Controls.Add(this.lbl60);
            this.p05.Controls.Add(this.label93);
            this.p05.Controls.Add(this.label94);
            this.p05.Controls.Add(this.label92);
            this.p05.Controls.Add(this.label91);
            this.p05.Controls.Add(this.label90);
            this.p05.Controls.Add(this.label89);
            this.p05.Controls.Add(this.label88);
            this.p05.Controls.Add(this.label87);
            this.p05.Controls.Add(this.c347);
            this.p05.Controls.Add(this.c345);
            this.p05.Controls.Add(this.label84);
            this.p05.Controls.Add(this.c333);
            this.p05.Controls.Add(this.label83);
            this.p05.Controls.Add(this.c332);
            this.p05.Controls.Add(this.label82);
            this.p05.Controls.Add(this.c321);
            this.p05.Controls.Add(this.c163);
            this.p05.Controls.Add(this.c205);
            this.p05.Controls.Add(this.c131);
            this.p05.Controls.Add(this.c204);
            this.p05.Controls.Add(this.c180);
            this.p05.Controls.Add(this.c192);
            this.p05.Controls.Add(this.c132);
            this.p05.Controls.Add(this.c154);
            this.p05.Controls.Add(this.c178);
            this.p05.Location = new System.Drawing.Point(159, 3);
            this.p05.Name = "p05";
            this.p05.Size = new System.Drawing.Size(527, 500);
            this.p05.TabIndex = 83;
            this.p05.Visible = false;
            // 
            // c365
            // 
            this.c365.Location = new System.Drawing.Point(531, 4);
            this.c365.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c365.Name = "c365";
            this.c365.Size = new System.Drawing.Size(79, 20);
            this.c365.TabIndex = 217;
            this.c365.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c365.Value = new decimal(new int[] {
            7000000,
            0,
            0,
            0});
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(309, 8);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(219, 13);
            this.label95.TabIndex = 216;
            this.label95.Text = "Thứ 7, chủ nhật BHYT chi trả chi phí tối đa :";
            // 
            // c362
            // 
            this.c362.Location = new System.Drawing.Point(4, 465);
            this.c362.Name = "c362";
            this.c362.Size = new System.Drawing.Size(312, 19);
            this.c362.TabIndex = 215;
            this.c362.Text = "Kiểm tra số thẻ và nơi đăng ký khám chữa bệnh";
            // 
            // c360
            // 
            this.c360.Location = new System.Drawing.Point(285, 240);
            this.c360.Name = "c360";
            this.c360.Size = new System.Drawing.Size(170, 19);
            this.c360.TabIndex = 214;
            this.c360.Text = "Chênh lệch theo giá mua";
            // 
            // c348
            // 
            this.c348.Location = new System.Drawing.Point(259, 277);
            this.c348.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c348.Name = "c348";
            this.c348.Size = new System.Drawing.Size(79, 20);
            this.c348.TabIndex = 200;
            this.c348.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c348.Value = new decimal(new int[] {
            7000000,
            0,
            0,
            0});
            // 
            // c353
            // 
            this.c353.Location = new System.Drawing.Point(3, 259);
            this.c353.Name = "c353";
            this.c353.Size = new System.Drawing.Size(364, 19);
            this.c353.TabIndex = 213;
            this.c353.Text = "Nhập ngày bắt đầu hưởng các khoản chi phí, chăm sóc,thuốc đặc trị";
            // 
            // c351
            // 
            this.c351.Location = new System.Drawing.Point(531, 421);
            this.c351.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c351.Name = "c351";
            this.c351.Size = new System.Drawing.Size(79, 20);
            this.c351.TabIndex = 212;
            this.c351.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c351.Value = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            this.c351.ValueChanged += new System.EventHandler(this.c351_ValueChanged);
            // 
            // c352
            // 
            this.c352.Location = new System.Drawing.Point(274, 443);
            this.c352.Name = "c352";
            this.c352.Size = new System.Drawing.Size(38, 20);
            this.c352.TabIndex = 211;
            this.c352.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c352.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // c350
            // 
            this.c350.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c350.Location = new System.Drawing.Point(228, 422);
            this.c350.Name = "c350";
            this.c350.Size = new System.Drawing.Size(200, 20);
            this.c350.TabIndex = 210;
            // 
            // c349
            // 
            this.c349.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c349.Location = new System.Drawing.Point(228, 401);
            this.c349.Name = "c349";
            this.c349.Size = new System.Drawing.Size(200, 20);
            this.c349.TabIndex = 209;
            // 
            // lbl60
            // 
            this.lbl60.AutoSize = true;
            this.lbl60.Location = new System.Drawing.Point(35, 446);
            this.lbl60.Name = "lbl60";
            this.lbl60.Size = new System.Drawing.Size(391, 13);
            this.lbl60.TabIndex = 208;
            this.lbl60.Text = "2.3. Những thẻ bắt buộc còn lại được thanh toán               %,  nhưng không quá" +
                " :";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(35, 425);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(498, 13);
            this.label93.TabIndex = 207;
            this.label93.Text = "2.2. Những thẻ được thanh toán 100 %                                             " +
                "                         , nhưng không quá :";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(35, 404);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(192, 13);
            this.label94.TabIndex = 206;
            this.label94.Text = "2.1. Những thẻ được thanh toán 100 %";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.ForeColor = System.Drawing.Color.Red;
            this.label92.Location = new System.Drawing.Point(5, 383);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(66, 13);
            this.label92.TabIndex = 205;
            this.label92.Text = "2. Nếu trên :";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(48, 364);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(232, 13);
            this.label91.TabIndex = 204;
            this.label91.Text = "(tùy theo ngày được hưởng dịch vụ ghi trên thẻ)";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(35, 345);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(235, 13);
            this.label90.TabIndex = 203;
            this.label90.Text = "1.2. Đối tượng tự nguyện được thanh toán 80 % ";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(35, 324);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(233, 13);
            this.label89.TabIndex = 202;
            this.label89.Text = "1.1. Đối tượng bắt buộc được thanh toán 100 %";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.Red;
            this.label88.Location = new System.Drawing.Point(3, 301);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(68, 13);
            this.label88.TabIndex = 201;
            this.label88.Text = "1. Nếu dưới :";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(4, 280);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(257, 13);
            this.label87.TabIndex = 199;
            this.label87.Text = "Mức chi phí dịch vụ kỹ thuật cao bảo hiểm qui định :";
            // 
            // c347
            // 
            this.c347.Location = new System.Drawing.Point(3, 240);
            this.c347.Name = "c347";
            this.c347.Size = new System.Drawing.Size(309, 19);
            this.c347.TabIndex = 198;
            this.c347.Text = "Bảo hiểm quyết toán giá thuốc theo giá qui định";
            this.c347.CheckedChanged += new System.EventHandler(this.c347_CheckedChanged);
            // 
            // c345
            // 
            this.c345.Location = new System.Drawing.Point(4, 223);
            this.c345.Name = "c345";
            this.c345.Size = new System.Drawing.Size(312, 19);
            this.c345.TabIndex = 197;
            this.c345.Text = "Nhập số thẻ trong danh mục bảo hiểm cung cấp";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(177, 199);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(133, 13);
            this.label84.TabIndex = 196;
            this.label84.Text = "được hưởng tất cả dịch vụ";
            // 
            // c333
            // 
            this.c333.Location = new System.Drawing.Point(138, 196);
            this.c333.Name = "c333";
            this.c333.Size = new System.Drawing.Size(38, 20);
            this.c333.TabIndex = 195;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(104, 201);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(35, 13);
            this.label83.TabIndex = 194;
            this.label83.Text = "Vị trí :";
            // 
            // c332
            // 
            this.c332.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c332.Location = new System.Drawing.Point(47, 196);
            this.c332.Name = "c332";
            this.c332.Size = new System.Drawing.Size(57, 20);
            this.c332.TabIndex = 193;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(3, 201);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(44, 13);
            this.label82.TabIndex = 192;
            this.label82.Text = "Số thẻ :";
            // 
            // c321
            // 
            this.c321.Location = new System.Drawing.Point(4, 175);
            this.c321.Name = "c321";
            this.c321.Size = new System.Drawing.Size(312, 19);
            this.c321.TabIndex = 191;
            this.c321.Text = "Người bệnh BHYT trong ngày chỉ khám 1 lần";
            // 
            // p06
            // 
            this.p06.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p06.AutoScroll = true;
            this.p06.Controls.Add(this.c402);
            this.p06.Controls.Add(this.c401);
            this.p06.Controls.Add(this.c400);
            this.p06.Controls.Add(this.c394);
            this.p06.Controls.Add(this.c300);
            this.p06.Controls.Add(this.c390);
            this.p06.Controls.Add(this.c389);
            this.p06.Controls.Add(this.label103);
            this.p06.Controls.Add(this.c383);
            this.p06.Controls.Add(this.c379);
            this.p06.Controls.Add(this.label102);
            this.p06.Controls.Add(this.c229);
            this.p06.Controls.Add(this.c165);
            this.p06.Controls.Add(this.c376);
            this.p06.Controls.Add(this.label101);
            this.p06.Controls.Add(this.c375);
            this.p06.Controls.Add(this.label100);
            this.p06.Controls.Add(this.c374);
            this.p06.Controls.Add(this.c364);
            this.p06.Controls.Add(this.c363);
            this.p06.Controls.Add(this.dataGrid2);
            this.p06.Controls.Add(this.mml);
            this.p06.Controls.Add(this.c342);
            this.p06.Controls.Add(this.c334);
            this.p06.Controls.Add(this.c137);
            this.p06.Controls.Add(this.c299);
            this.p06.Controls.Add(this.c298);
            this.p06.Controls.Add(this.label61);
            this.p06.Controls.Add(this.c297);
            this.p06.Controls.Add(this.c294);
            this.p06.Controls.Add(this.hhl);
            this.p06.Controls.Add(this.c293);
            this.p06.Controls.Add(this.c292);
            this.p06.Controls.Add(this.c291);
            this.p06.Controls.Add(this.label63);
            this.p06.Controls.Add(this.label62);
            this.p06.Controls.Add(this.label60);
            this.p06.Controls.Add(this.c282);
            this.p06.Controls.Add(this.c281);
            this.p06.Controls.Add(this.c166);
            this.p06.Controls.Add(this.c145);
            this.p06.Controls.Add(this.c147);
            this.p06.Controls.Add(this.c61);
            this.p06.Controls.Add(this.c156);
            this.p06.Controls.Add(this.c56);
            this.p06.Controls.Add(this.c194);
            this.p06.Controls.Add(this.c198);
            this.p06.Controls.Add(this.c191);
            this.p06.Controls.Add(this.c48);
            this.p06.Controls.Add(this.label51);
            this.p06.Controls.Add(this.c135);
            this.p06.Controls.Add(this.c261);
            this.p06.Controls.Add(this.label52);
            this.p06.Controls.Add(this.c260);
            this.p06.Controls.Add(this.label31);
            this.p06.Controls.Add(this.c184);
            this.p06.Controls.Add(this.hh);
            this.p06.Controls.Add(this.label32);
            this.p06.Controls.Add(this.c169);
            this.p06.Controls.Add(this.c186);
            this.p06.Controls.Add(this.mm);
            this.p06.Controls.Add(this.label45);
            this.p06.Controls.Add(this.mmt);
            this.p06.Controls.Add(this.c164);
            this.p06.Controls.Add(this.c244);
            this.p06.Controls.Add(this.label33);
            this.p06.Controls.Add(this.c233);
            this.p06.Controls.Add(this.c176);
            this.p06.Controls.Add(this.label46);
            this.p06.Controls.Add(this.label44);
            this.p06.Controls.Add(this.mmb);
            this.p06.Controls.Add(this.label38);
            this.p06.Controls.Add(this.hht);
            this.p06.Controls.Add(this.label43);
            this.p06.Controls.Add(this.hhb);
            this.p06.Controls.Add(this.label47);
            this.p06.Controls.Add(this.label42);
            this.p06.Controls.Add(this.c228);
            this.p06.Controls.Add(this.label40);
            this.p06.Location = new System.Drawing.Point(159, 3);
            this.p06.Name = "p06";
            this.p06.Size = new System.Drawing.Size(527, 500);
            this.p06.TabIndex = 84;
            // 
            // c402
            // 
            this.c402.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c402.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c402.Location = new System.Drawing.Point(616, 235);
            this.c402.Name = "c402";
            this.c402.Size = new System.Drawing.Size(227, 21);
            this.c402.TabIndex = 288;
            // 
            // c401
            // 
            this.c401.CheckOnClick = true;
            this.c401.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c401.FormattingEnabled = true;
            this.c401.Location = new System.Drawing.Point(617, 149);
            this.c401.Name = "c401";
            this.c401.Size = new System.Drawing.Size(226, 84);
            this.c401.TabIndex = 287;
            this.c401.SelectedValueChanged += new System.EventHandler(this.c401_SelectedValueChanged);
            // 
            // c400
            // 
            this.c400.Location = new System.Drawing.Point(618, 131);
            this.c400.Name = "c400";
            this.c400.Size = new System.Drawing.Size(292, 19);
            this.c400.TabIndex = 286;
            this.c400.Text = "Tự động duyệt phiếu dự trù sau khi chuyển xuống kho";
            this.c400.CheckedChanged += new System.EventHandler(this.c400_CheckedChanged);
            // 
            // c394
            // 
            this.c394.Location = new System.Drawing.Point(618, 113);
            this.c394.Name = "c394";
            this.c394.Size = new System.Drawing.Size(168, 19);
            this.c394.TabIndex = 285;
            this.c394.Text = "Cho phép khoa sau hoàn trả";
            // 
            // c300
            // 
            this.c300.CheckOnClick = true;
            this.c300.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c300.FormattingEnabled = true;
            this.c300.Location = new System.Drawing.Point(86, 368);
            this.c300.Name = "c300";
            this.c300.Size = new System.Drawing.Size(276, 52);
            this.c300.TabIndex = 265;
            this.c300.SelectedValueChanged += new System.EventHandler(this.c300_SelectedValueChanged);
            // 
            // c390
            // 
            this.c390.CheckOnClick = true;
            this.c390.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c390.FormattingEnabled = true;
            this.c390.Location = new System.Drawing.Point(397, 414);
            this.c390.Name = "c390";
            this.c390.Size = new System.Drawing.Size(210, 68);
            this.c390.TabIndex = 284;
            this.c390.SelectedValueChanged += new System.EventHandler(this.c390_SelectedValueChanged);
            // 
            // c389
            // 
            this.c389.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c389.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c389.Location = new System.Drawing.Point(435, 446);
            this.c389.Name = "c389";
            this.c389.Size = new System.Drawing.Size(139, 21);
            this.c389.TabIndex = 283;
            this.c389.Visible = false;
            // 
            // label103
            // 
            this.label103.Location = new System.Drawing.Point(361, 393);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(248, 16);
            this.label103.TabIndex = 282;
            this.label103.Text = "Kho phát theo khai báo khoa phòng của dược";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c383
            // 
            this.c383.Location = new System.Drawing.Point(618, 94);
            this.c383.Name = "c383";
            this.c383.Size = new System.Drawing.Size(240, 19);
            this.c383.TabIndex = 281;
            this.c383.Text = "Chọn thông số dược trong phẫu thủ thuật";
            // 
            // c379
            // 
            this.c379.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c379.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c379.Location = new System.Drawing.Point(397, 369);
            this.c379.Name = "c379";
            this.c379.Size = new System.Drawing.Size(210, 21);
            this.c379.TabIndex = 280;
            // 
            // label102
            // 
            this.label102.Location = new System.Drawing.Point(350, 370);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(50, 16);
            this.label102.TabIndex = 279;
            this.label102.Text = "Kho 2 :";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c376
            // 
            this.c376.CheckOnClick = true;
            this.c376.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c376.FormattingEnabled = true;
            this.c376.Location = new System.Drawing.Point(397, 236);
            this.c376.Name = "c376";
            this.c376.Size = new System.Drawing.Size(210, 132);
            this.c376.TabIndex = 277;
            this.c376.SelectedValueChanged += new System.EventHandler(this.c376_SelectedValueChanged);
            // 
            // label101
            // 
            this.label101.Location = new System.Drawing.Point(358, 234);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(44, 16);
            this.label101.TabIndex = 278;
            this.label101.Text = "Khoa : ";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c375
            // 
            this.c375.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c375.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c375.Location = new System.Drawing.Point(397, 213);
            this.c375.Name = "c375";
            this.c375.Size = new System.Drawing.Size(210, 21);
            this.c375.TabIndex = 276;
            // 
            // label100
            // 
            this.label100.Location = new System.Drawing.Point(350, 214);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(50, 16);
            this.label100.TabIndex = 275;
            this.label100.Text = "Kho 1 :";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c374
            // 
            this.c374.Location = new System.Drawing.Point(368, 196);
            this.c374.Name = "c374";
            this.c374.Size = new System.Drawing.Size(233, 19);
            this.c374.TabIndex = 274;
            this.c374.Text = "Phát thuốc phân theo kho và khoa phòng";
            this.c374.CheckedChanged += new System.EventHandler(this.c374_CheckedChanged);
            // 
            // c364
            // 
            this.c364.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c364.Location = new System.Drawing.Point(4, 456);
            this.c364.Name = "c364";
            this.c364.Size = new System.Drawing.Size(358, 21);
            this.c364.TabIndex = 273;
            // 
            // c363
            // 
            this.c363.Location = new System.Drawing.Point(5, 439);
            this.c363.Name = "c363";
            this.c363.Size = new System.Drawing.Size(280, 19);
            this.c363.TabIndex = 272;
            this.c363.Text = "Đơn thuốc xuất khoa cho về trừ tồn kho";
            this.c363.CheckedChanged += new System.EventHandler(this.c363_CheckedChanged);
            // 
            // c342
            // 
            this.c342.Location = new System.Drawing.Point(5, 422);
            this.c342.Name = "c342";
            this.c342.Size = new System.Drawing.Size(280, 19);
            this.c342.TabIndex = 267;
            this.c342.Text = "Đơn thuốc mua ngoài cho phép nhập ngoài tồn kho";
            // 
            // c334
            // 
            this.c334.Location = new System.Drawing.Point(321, 174);
            this.c334.Name = "c334";
            this.c334.Size = new System.Drawing.Size(280, 19);
            this.c334.TabIndex = 266;
            this.c334.Text = "Điều trị có cấp đơn thuốc";
            // 
            // c299
            // 
            this.c299.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c299.Location = new System.Drawing.Point(235, 346);
            this.c299.Name = "c299";
            this.c299.Size = new System.Drawing.Size(127, 21);
            this.c299.TabIndex = 263;
            // 
            // c298
            // 
            this.c298.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c298.Location = new System.Drawing.Point(86, 346);
            this.c298.Name = "c298";
            this.c298.Size = new System.Drawing.Size(87, 21);
            this.c298.TabIndex = 262;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(176, 349);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(62, 16);
            this.label61.TabIndex = 264;
            this.label61.Text = "Đối tượng :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c297
            // 
            this.c297.Location = new System.Drawing.Point(6, 347);
            this.c297.Name = "c297";
            this.c297.Size = new System.Drawing.Size(76, 19);
            this.c297.TabIndex = 261;
            this.c297.Text = "Ngoại trú ";
            this.c297.CheckedChanged += new System.EventHandler(this.c297_CheckedChanged);
            // 
            // c294
            // 
            this.c294.Location = new System.Drawing.Point(321, 156);
            this.c294.Name = "c294";
            this.c294.Size = new System.Drawing.Size(280, 19);
            this.c294.TabIndex = 260;
            this.c294.Text = "Lĩnh thuốc ngoài giờ dựa vào ngày giờ y lệnh";
            // 
            // c293
            // 
            this.c293.CustomFormat = "HH:mm";
            this.c293.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c293.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c293.Location = new System.Drawing.Point(556, 6);
            this.c293.Name = "c293";
            this.c293.Size = new System.Drawing.Size(52, 21);
            this.c293.TabIndex = 259;
            // 
            // c292
            // 
            this.c292.CustomFormat = "HH:mm";
            this.c292.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c292.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c292.Location = new System.Drawing.Point(445, 6);
            this.c292.Name = "c292";
            this.c292.Size = new System.Drawing.Size(52, 21);
            this.c292.TabIndex = 258;
            // 
            // c291
            // 
            this.c291.CustomFormat = "HH:mm";
            this.c291.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c291.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c291.Location = new System.Drawing.Point(366, 6);
            this.c291.Name = "c291";
            this.c291.Size = new System.Drawing.Size(52, 21);
            this.c291.TabIndex = 257;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(497, 8);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(98, 17);
            this.label63.TabIndex = 256;
            this.label63.Text = "Ngày nghỉ :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(289, 8);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(192, 17);
            this.label62.TabIndex = 255;
            this.label62.Text = "giờ nghỉ trưa từ                    đến ";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(5, 8);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(192, 17);
            this.label60.TabIndex = 251;
            this.label60.Text = "Phiếu lĩnh ngoài giờ ngày thường sau :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c282
            // 
            this.c282.Location = new System.Drawing.Point(321, 139);
            this.c282.Name = "c282";
            this.c282.Size = new System.Drawing.Size(280, 19);
            this.c282.TabIndex = 250;
            this.c282.Text = "Đơn thuốc khám bệnh chỉ nhập 1 lần trong lần khám";
            // 
            // c281
            // 
            this.c281.Location = new System.Drawing.Point(321, 120);
            this.c281.Name = "c281";
            this.c281.Size = new System.Drawing.Size(261, 19);
            this.c281.TabIndex = 249;
            this.c281.Text = "Đơn thuốc khác ngày chỉ Admin mới in lại được";
            // 
            // p07
            // 
            this.p07.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p07.AutoScroll = true;
            this.p07.Controls.Add(this.c403);
            this.p07.Controls.Add(this.c399);
            this.p07.Controls.Add(this.c398);
            this.p07.Controls.Add(this.c238);
            this.p07.Controls.Add(this.c237);
            this.p07.Controls.Add(this.c397);
            this.p07.Controls.Add(this.label104);
            this.p07.Controls.Add(this.c396);
            this.p07.Controls.Add(this.c395);
            this.p07.Controls.Add(this.c392);
            this.p07.Controls.Add(this.c387);
            this.p07.Controls.Add(this.c384);
            this.p07.Controls.Add(this.c382);
            this.p07.Controls.Add(this.c381);
            this.p07.Controls.Add(this.c378);
            this.p07.Controls.Add(this.c372);
            this.p07.Controls.Add(this.label99);
            this.p07.Controls.Add(this.c220);
            this.p07.Controls.Add(this.c219);
            this.p07.Controls.Add(this.c290);
            this.p07.Controls.Add(this.c371);
            this.p07.Controls.Add(this.c335);
            this.p07.Controls.Add(this.c302);
            this.p07.Controls.Add(this.c179);
            this.p07.Controls.Add(this.c370);
            this.p07.Controls.Add(this.c369);
            this.p07.Controls.Add(this.c368);
            this.p07.Controls.Add(this.label98);
            this.p07.Controls.Add(this.c367);
            this.p07.Controls.Add(this.c366);
            this.p07.Controls.Add(this.label97);
            this.p07.Controls.Add(this.label96);
            this.p07.Controls.Add(this.c359);
            this.p07.Controls.Add(this.label85);
            this.p07.Controls.Add(this.c331);
            this.p07.Controls.Add(this.c320);
            this.p07.Controls.Add(this.c304);
            this.p07.Controls.Add(this.c303);
            this.p07.Controls.Add(this.label64);
            this.p07.Controls.Add(this.c289);
            this.p07.Controls.Add(this.c288);
            this.p07.Controls.Add(this.c287);
            this.p07.Controls.Add(this.c284);
            this.p07.Controls.Add(this.c286);
            this.p07.Controls.Add(this.label49);
            this.p07.Controls.Add(this.label14);
            this.p07.Controls.Add(this.c283);
            this.p07.Controls.Add(this.c263);
            this.p07.Controls.Add(this.c249);
            this.p07.Controls.Add(this.c214);
            this.p07.Controls.Add(this.c188);
            this.p07.Controls.Add(this.c113);
            this.p07.Controls.Add(this.c242);
            this.p07.Controls.Add(this.c196);
            this.p07.Controls.Add(this.c129);
            this.p07.Controls.Add(this.c128);
            this.p07.Controls.Add(this.c149);
            this.p07.Controls.Add(this.c183);
            this.p07.Controls.Add(this.c46);
            this.p07.Controls.Add(this.label39);
            this.p07.Controls.Add(this.c262);
            this.p07.Controls.Add(this.c182);
            this.p07.Controls.Add(this.c133);
            this.p07.Controls.Add(this.c151);
            this.p07.Controls.Add(this.c58);
            this.p07.Controls.Add(this.c47);
            this.p07.Controls.Add(this.c53);
            this.p07.Controls.Add(this.c157);
            this.p07.Controls.Add(this.c134);
            this.p07.Controls.Add(this.c161);
            this.p07.Controls.Add(this.c57);
            this.p07.Controls.Add(this.c141);
            this.p07.Controls.Add(this.c144);
            this.p07.Controls.Add(this.c246);
            this.p07.Controls.Add(this.c155);
            this.p07.Controls.Add(this.c150);
            this.p07.Controls.Add(this.c110);
            this.p07.Controls.Add(this.c217);
            this.p07.Controls.Add(this.c218);
            this.p07.Controls.Add(this.c230);
            this.p07.Controls.Add(this.c231);
            this.p07.Location = new System.Drawing.Point(159, 3);
            this.p07.Name = "p07";
            this.p07.Size = new System.Drawing.Size(527, 500);
            this.p07.TabIndex = 82;
            this.p07.Visible = false;
            // 
            // c403
            // 
            this.c403.Location = new System.Drawing.Point(607, 352);
            this.c403.Name = "c403";
            this.c403.Size = new System.Drawing.Size(346, 19);
            this.c403.TabIndex = 295;
            this.c403.Text = "55. Đối tượng thu phí chuyển khám tính công";
            // 
            // c399
            // 
            this.c399.Location = new System.Drawing.Point(607, 335);
            this.c399.Name = "c399";
            this.c399.Size = new System.Drawing.Size(346, 19);
            this.c399.TabIndex = 294;
            this.c399.Text = "54. Thanh toán BHYT tại ngoại trú theo cách tính phòng khám";
            // 
            // c398
            // 
            this.c398.Location = new System.Drawing.Point(607, 318);
            this.c398.Name = "c398";
            this.c398.Size = new System.Drawing.Size(346, 19);
            this.c398.TabIndex = 293;
            this.c398.Text = "53. Thanh toán BHYT tại phòng lưu theo cách tính phòng khám";
            // 
            // c397
            // 
            this.c397.CheckOnClick = true;
            this.c397.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c397.FormattingEnabled = true;
            this.c397.Location = new System.Drawing.Point(607, 214);
            this.c397.Name = "c397";
            this.c397.Size = new System.Drawing.Size(282, 100);
            this.c397.TabIndex = 292;
            this.c397.SelectedValueChanged += new System.EventHandler(this.c397_SelectedValueChanged);
            // 
            // label104
            // 
            this.label104.Location = new System.Drawing.Point(603, 173);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(260, 17);
            this.label104.TabIndex = 291;
            this.label104.Text = "52. Tự động chuyển vào chỉ định khi đăng ký";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c396
            // 
            this.c396.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c396.Location = new System.Drawing.Point(607, 191);
            this.c396.Name = "c396";
            this.c396.Size = new System.Drawing.Size(282, 21);
            this.c396.TabIndex = 290;
            // 
            // c395
            // 
            this.c395.Location = new System.Drawing.Point(496, 457);
            this.c395.Name = "c395";
            this.c395.Size = new System.Drawing.Size(99, 20);
            this.c395.TabIndex = 289;
            this.c395.Text = "Thu trực tiếp";
            this.c395.Visible = false;
            // 
            // c392
            // 
            this.c392.Location = new System.Drawing.Point(605, 155);
            this.c392.Name = "c392";
            this.c392.Size = new System.Drawing.Size(278, 19);
            this.c392.TabIndex = 288;
            this.c392.Text = "51. Phòng lưu chuyển khám không tính tiền khám";
            // 
            // c387
            // 
            this.c387.Location = new System.Drawing.Point(605, 137);
            this.c387.Name = "c387";
            this.c387.Size = new System.Drawing.Size(278, 19);
            this.c387.TabIndex = 287;
            this.c387.Text = "50. Giá trọn gói tính theo đối tượng";
            // 
            // c384
            // 
            this.c384.Location = new System.Drawing.Point(490, 87);
            this.c384.Name = "c384";
            this.c384.Size = new System.Drawing.Size(121, 19);
            this.c384.TabIndex = 286;
            this.c384.Text = "Khai báo danh mục";
            // 
            // c382
            // 
            this.c382.Location = new System.Drawing.Point(605, 119);
            this.c382.Name = "c382";
            this.c382.Size = new System.Drawing.Size(278, 19);
            this.c382.TabIndex = 285;
            this.c382.Text = "49. Đưa chi phí khám bệnh vào nội ngoại trú";
            this.c382.CheckedChanged += new System.EventHandler(this.c382_CheckedChanged);
            // 
            // c381
            // 
            this.c381.Location = new System.Drawing.Point(299, 46);
            this.c381.Name = "c381";
            this.c381.Size = new System.Drawing.Size(146, 19);
            this.c381.TabIndex = 284;
            this.c381.Text = "26. Thu trực tiếp";
            // 
            // c378
            // 
            this.c378.Location = new System.Drawing.Point(298, 105);
            this.c378.Name = "c378";
            this.c378.Size = new System.Drawing.Size(331, 19);
            this.c378.TabIndex = 282;
            this.c378.Text = "28.Miễn giảm công khám, phần chênh lệch BN tự thanh toán";
            this.c378.CheckedChanged += new System.EventHandler(this.c378_CheckedChanged);
            // 
            // c372
            // 
            this.c372.Location = new System.Drawing.Point(101, 407);
            this.c372.Name = "c372";
            this.c372.Size = new System.Drawing.Size(186, 20);
            this.c372.TabIndex = 280;
            // 
            // label99
            // 
            this.label99.Location = new System.Drawing.Point(6, 408);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(120, 17);
            this.label99.TabIndex = 281;
            this.label99.Text = "Nội dung hao phí :";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c290
            // 
            this.c290.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c290.Location = new System.Drawing.Point(298, 369);
            this.c290.Name = "c290";
            this.c290.Size = new System.Drawing.Size(297, 21);
            this.c290.TabIndex = 261;
            // 
            // c371
            // 
            this.c371.Location = new System.Drawing.Point(5, 389);
            this.c371.Name = "c371";
            this.c371.Size = new System.Drawing.Size(305, 19);
            this.c371.TabIndex = 279;
            this.c371.Text = "20. In hao phí chung đối tượng vào trong phiếu thanh toán";
            // 
            // c335
            // 
            this.c335.Location = new System.Drawing.Point(355, 66);
            this.c335.Name = "c335";
            this.c335.Size = new System.Drawing.Size(240, 20);
            this.c335.TabIndex = 268;
            // 
            // c302
            // 
            this.c302.Location = new System.Drawing.Point(502, 29);
            this.c302.Name = "c302";
            this.c302.Size = new System.Drawing.Size(99, 19);
            this.c302.TabIndex = 262;
            this.c302.Text = "Theo đối tượng";
            // 
            // c370
            // 
            this.c370.Location = new System.Drawing.Point(5, 26);
            this.c370.Name = "c370";
            this.c370.Size = new System.Drawing.Size(328, 20);
            this.c370.TabIndex = 278;
            this.c370.Text = "2. BHYT, Miễn, Trả sau chuyển công khám vào chỉ định";
            // 
            // c369
            // 
            this.c369.Location = new System.Drawing.Point(5, 463);
            this.c369.Name = "c369";
            this.c369.Size = new System.Drawing.Size(450, 19);
            this.c369.TabIndex = 277;
            this.c369.Text = "23. Người bệnh BHYT, tiếp đón cùng 1 lúc nhiều phòng khám in chung chi phí điều t" +
                "rị";
            // 
            // c368
            // 
            this.c368.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c368.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c368.Location = new System.Drawing.Point(480, 165);
            this.c368.Name = "c368";
            this.c368.Size = new System.Drawing.Size(115, 21);
            this.c368.TabIndex = 276;
            // 
            // label98
            // 
            this.label98.Location = new System.Drawing.Point(300, 167);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(185, 17);
            this.label98.TabIndex = 275;
            this.label98.Text = "30.In phiếu thanh toán vào đối tượng :";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c367
            // 
            this.c367.Location = new System.Drawing.Point(422, 144);
            this.c367.Name = "c367";
            this.c367.Size = new System.Drawing.Size(173, 20);
            this.c367.TabIndex = 274;
            // 
            // c366
            // 
            this.c366.Location = new System.Drawing.Point(355, 124);
            this.c366.Name = "c366";
            this.c366.Size = new System.Drawing.Size(41, 20);
            this.c366.TabIndex = 273;
            // 
            // label97
            // 
            this.label97.Location = new System.Drawing.Point(300, 124);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(289, 17);
            this.label97.TabIndex = 272;
            this.label97.Text = "Miễn giảm                 %, phần chênh lệch BN tự thanh toán";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.Location = new System.Drawing.Point(300, 146);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(120, 17);
            this.label96.TabIndex = 271;
            this.label96.Text = "29.Nhập nơi làm việc là :";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c359
            // 
            this.c359.Location = new System.Drawing.Point(298, 86);
            this.c359.Name = "c359";
            this.c359.Size = new System.Drawing.Size(213, 19);
            this.c359.TabIndex = 270;
            this.c359.Text = "27.Chênh lệch giá thuốc+vật tư y tế";
            this.c359.CheckedChanged += new System.EventHandler(this.c359_CheckedChanged);
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(300, 66);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(120, 17);
            this.label85.TabIndex = 269;
            this.label85.Text = "Nội dung :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c331
            // 
            this.c331.Location = new System.Drawing.Point(605, 45);
            this.c331.Name = "c331";
            this.c331.Size = new System.Drawing.Size(295, 19);
            this.c331.TabIndex = 267;
            this.c331.Text = "45. Hiện đơn giá trong liệt kê chỉ định + viện phí khoa";
            // 
            // c320
            // 
            this.c320.AutoSize = true;
            this.c320.Location = new System.Drawing.Point(203, 106);
            this.c320.Name = "c320";
            this.c320.Size = new System.Drawing.Size(61, 17);
            this.c320.TabIndex = 266;
            this.c320.Text = "In 1 lần";
            this.c320.UseVisualStyleBackColor = true;
            // 
            // c304
            // 
            this.c304.Location = new System.Drawing.Point(154, 44);
            this.c304.Name = "c304";
            this.c304.Size = new System.Drawing.Size(127, 20);
            this.c304.TabIndex = 265;
            this.c304.Text = "3a In biên lai miễn phí";
            // 
            // c303
            // 
            this.c303.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c303.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c303.Location = new System.Drawing.Point(409, 432);
            this.c303.Name = "c303";
            this.c303.Size = new System.Drawing.Size(186, 21);
            this.c303.TabIndex = 264;
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(280, 435);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(128, 17);
            this.label64.TabIndex = 263;
            this.label64.Text = "42. Nhóm viện phí thuốc :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c289
            // 
            this.c289.Location = new System.Drawing.Point(298, 351);
            this.c289.Name = "c289";
            this.c289.Size = new System.Drawing.Size(313, 19);
            this.c289.TabIndex = 260;
            this.c289.Text = "40. Công khám ngoại trú chuyển vào chi phí điều trị";
            this.c289.CheckedChanged += new System.EventHandler(this.c289_CheckedChanged);
            // 
            // c288
            // 
            this.c288.Location = new System.Drawing.Point(605, 8);
            this.c288.Name = "c288";
            this.c288.Size = new System.Drawing.Size(329, 20);
            this.c288.TabIndex = 259;
            this.c288.Text = "43.Phục hồi bệnh án khi hủy số liệu chuyển xuống viện phí";
            // 
            // c287
            // 
            this.c287.Location = new System.Drawing.Point(5, 44);
            this.c287.Name = "c287";
            this.c287.Size = new System.Drawing.Size(254, 20);
            this.c287.TabIndex = 258;
            this.c287.Text = "3. Ký hiệu biên lai theo máy";
            // 
            // c284
            // 
            this.c284.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c284.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c284.Location = new System.Drawing.Point(98, 136);
            this.c284.Name = "c284";
            this.c284.Size = new System.Drawing.Size(158, 21);
            this.c284.TabIndex = 252;
            // 
            // c286
            // 
            this.c286.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c286.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c286.Location = new System.Drawing.Point(98, 158);
            this.c286.Name = "c286";
            this.c286.Size = new System.Drawing.Size(158, 21);
            this.c286.TabIndex = 254;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(8, 160);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(120, 17);
            this.label49.TabIndex = 256;
            this.label49.Text = "Sang đối tượng :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(7, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 17);
            this.label14.TabIndex = 255;
            this.label14.Text = "Đối tượng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c283
            // 
            this.c283.Location = new System.Drawing.Point(5, 117);
            this.c283.Name = "c283";
            this.c283.Size = new System.Drawing.Size(199, 21);
            this.c283.TabIndex = 251;
            this.c283.Text = "7. Chuyển đối tượng trong đăng ký";
            this.c283.CheckedChanged += new System.EventHandler(this.c283_CheckedChanged);
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(570, 506);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(17, 17);
            this.label59.TabIndex = 257;
            this.label59.Text = "Viện phí :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label59.Visible = false;
            // 
            // p08
            // 
            this.p08.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p08.AutoScroll = true;
            this.p08.Controls.Add(this.c391);
            this.p08.Controls.Add(this.c388);
            this.p08.Controls.Add(this.c339);
            this.p08.Controls.Add(this.label86);
            this.p08.Controls.Add(this.c338);
            this.p08.Controls.Add(this.c337);
            this.p08.Controls.Add(this.c336);
            this.p08.Controls.Add(this.c328);
            this.p08.Controls.Add(this.c326);
            this.p08.Controls.Add(this.c199);
            this.p08.Controls.Add(this.c251);
            this.p08.Controls.Add(this.c60);
            this.p08.Location = new System.Drawing.Point(159, 3);
            this.p08.Name = "p08";
            this.p08.Size = new System.Drawing.Size(527, 500);
            this.p08.TabIndex = 85;
            this.p08.Visible = false;
            // 
            // c391
            // 
            this.c391.Location = new System.Drawing.Point(2, 178);
            this.c391.Name = "c391";
            this.c391.Size = new System.Drawing.Size(158, 19);
            this.c391.TabIndex = 245;
            this.c391.Text = "Chỉ định theo loại viện phí";
            // 
            // c388
            // 
            this.c388.Location = new System.Drawing.Point(3, 160);
            this.c388.Name = "c388";
            this.c388.Size = new System.Drawing.Size(330, 19);
            this.c388.TabIndex = 244;
            this.c388.Text = "Duyệt dịch vụ cận lâm sàng thực hiện";
            // 
            // c339
            // 
            this.c339.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.c339.Location = new System.Drawing.Point(220, 137);
            this.c339.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.c339.Name = "c339";
            this.c339.Size = new System.Drawing.Size(65, 20);
            this.c339.TabIndex = 243;
            this.c339.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(5, 140);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(213, 13);
            this.label86.TabIndex = 242;
            this.label86.Text = "Thời gian tự động đọc tinh nhắn âm thanh :";
            // 
            // c338
            // 
            this.c338.Location = new System.Drawing.Point(4, 117);
            this.c338.Name = "c338";
            this.c338.Size = new System.Drawing.Size(333, 19);
            this.c338.TabIndex = 241;
            this.c338.Text = "Chỉ định nội trú đóng tiền trước khi thực hiện";
            // 
            // c337
            // 
            this.c337.Location = new System.Drawing.Point(4, 99);
            this.c337.Name = "c337";
            this.c337.Size = new System.Drawing.Size(333, 19);
            this.c337.TabIndex = 240;
            this.c337.Text = "Chỉ định ngoại trú đóng tiền trước khi thực hiện";
            // 
            // c336
            // 
            this.c336.Location = new System.Drawing.Point(5, 25);
            this.c336.Name = "c336";
            this.c336.Size = new System.Drawing.Size(333, 19);
            this.c336.TabIndex = 239;
            this.c336.Text = "Gửi tin nhắn âm thanh sau khi chỉ định";
            // 
            // c328
            // 
            this.c328.Location = new System.Drawing.Point(5, 80);
            this.c328.Name = "c328";
            this.c328.Size = new System.Drawing.Size(311, 19);
            this.c328.TabIndex = 238;
            this.c328.Text = "Bắt buộc nhập chẩn đoán và bác sỹ trong chỉ định";
            // 
            // c326
            // 
            this.c326.Location = new System.Drawing.Point(5, 61);
            this.c326.Name = "c326";
            this.c326.Size = new System.Drawing.Size(163, 19);
            this.c326.TabIndex = 237;
            this.c326.Text = "Chỉ định xuất ra File.TXT";
            // 
            // p09
            // 
            this.p09.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p09.AutoScroll = true;
            this.p09.Controls.Add(this.c254);
            this.p09.Controls.Add(this.pttt);
            this.p09.Controls.Add(this.c146);
            this.p09.Controls.Add(this.c158);
            this.p09.Controls.Add(this.c143);
            this.p09.Controls.Add(this.label37);
            this.p09.Controls.Add(this.c159);
            this.p09.Controls.Add(this.c253);
            this.p09.Location = new System.Drawing.Point(159, 3);
            this.p09.Name = "p09";
            this.p09.Size = new System.Drawing.Size(527, 500);
            this.p09.TabIndex = 86;
            this.p09.Visible = false;
            // 
            // p11
            // 
            this.p11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p11.AutoScroll = true;
            this.p11.Controls.Add(this.c171);
            this.p11.Controls.Add(this.c273);
            this.p11.Controls.Add(this.c170);
            this.p11.Controls.Add(this.c255);
            this.p11.Controls.Add(this.c272);
            this.p11.Controls.Add(this.c256);
            this.p11.Controls.Add(this.c270);
            this.p11.Controls.Add(this.c271);
            this.p11.Controls.Add(this.c269);
            this.p11.Controls.Add(this.label55);
            this.p11.Controls.Add(this.c268);
            this.p11.Controls.Add(this.c257);
            this.p11.Controls.Add(this.c267);
            this.p11.Controls.Add(this.label56);
            this.p11.Controls.Add(this.c266);
            this.p11.Controls.Add(this.label58);
            this.p11.Location = new System.Drawing.Point(159, 3);
            this.p11.Name = "p11";
            this.p11.Size = new System.Drawing.Size(527, 500);
            this.p11.TabIndex = 87;
            this.p11.Visible = false;
            // 
            // p10
            // 
            this.p10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p10.AutoScroll = true;
            this.p10.Controls.Add(this.c377);
            this.p10.Controls.Add(this.c280);
            this.p10.Controls.Add(this.c279);
            this.p10.Controls.Add(this.c278);
            this.p10.Controls.Add(this.c247);
            this.p10.Controls.Add(this.c236);
            this.p10.Controls.Add(this.label54);
            this.p10.Controls.Add(this.c235);
            this.p10.Controls.Add(this.c234);
            this.p10.Location = new System.Drawing.Point(159, 3);
            this.p10.Name = "p10";
            this.p10.Size = new System.Drawing.Size(527, 500);
            this.p10.TabIndex = 88;
            this.p10.Visible = false;
            // 
            // c377
            // 
            this.c377.Location = new System.Drawing.Point(7, 121);
            this.c377.Name = "c377";
            this.c377.Size = new System.Drawing.Size(203, 19);
            this.c377.TabIndex = 236;
            this.c377.Text = "Theo bệnh án";
            // 
            // c280
            // 
            this.c280.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c280.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c280.Location = new System.Drawing.Point(160, 98);
            this.c280.Name = "c280";
            this.c280.Size = new System.Drawing.Size(244, 21);
            this.c280.TabIndex = 235;
            // 
            // c279
            // 
            this.c279.Location = new System.Drawing.Point(7, 100);
            this.c279.Name = "c279";
            this.c279.Size = new System.Drawing.Size(344, 19);
            this.c279.TabIndex = 234;
            this.c279.Text = "Đối tượng phòng dịch vụ";
            this.c279.CheckedChanged += new System.EventHandler(this.c279_CheckedChanged);
            // 
            // c278
            // 
            this.c278.Location = new System.Drawing.Point(7, 83);
            this.c278.Name = "c278";
            this.c278.Size = new System.Drawing.Size(344, 19);
            this.c278.TabIndex = 233;
            this.c278.Text = "Giường dịch vụ <12 giờ tính nữa ngày, Giường thường ngày ra-ngày vào";
            // 
            // p13
            // 
            this.p13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p13.Controls.Add(this.c319);
            this.p13.Controls.Add(this.c318);
            this.p13.Controls.Add(this.c317);
            this.p13.Controls.Add(this.c316);
            this.p13.Controls.Add(this.label79);
            this.p13.Controls.Add(this.label78);
            this.p13.Controls.Add(this.label77);
            this.p13.Controls.Add(this.label76);
            this.p13.Controls.Add(this.label75);
            this.p13.Controls.Add(this.c314);
            this.p13.Controls.Add(this.c313);
            this.p13.Controls.Add(this.c312);
            this.p13.Controls.Add(this.c311);
            this.p13.Controls.Add(this.c310);
            this.p13.Controls.Add(this.c309);
            this.p13.Controls.Add(this.c308);
            this.p13.Controls.Add(this.label73);
            this.p13.Controls.Add(this.label72);
            this.p13.Controls.Add(this.label71);
            this.p13.Controls.Add(this.label70);
            this.p13.Controls.Add(this.label69);
            this.p13.Controls.Add(this.label68);
            this.p13.Controls.Add(this.label67);
            this.p13.Controls.Add(this.c307);
            this.p13.Controls.Add(this.c306);
            this.p13.Location = new System.Drawing.Point(159, 3);
            this.p13.Name = "p13";
            this.p13.Size = new System.Drawing.Size(527, 500);
            this.p13.TabIndex = 89;
            this.p13.Visible = false;
            // 
            // c319
            // 
            this.c319.CheckOnClick = true;
            this.c319.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c319.FormattingEnabled = true;
            this.c319.Location = new System.Drawing.Point(141, 423);
            this.c319.Name = "c319";
            this.c319.Size = new System.Drawing.Size(212, 68);
            this.c319.TabIndex = 24;
            // 
            // c318
            // 
            this.c318.CheckOnClick = true;
            this.c318.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c318.FormattingEnabled = true;
            this.c318.Location = new System.Drawing.Point(141, 353);
            this.c318.Name = "c318";
            this.c318.Size = new System.Drawing.Size(212, 68);
            this.c318.TabIndex = 23;
            // 
            // c317
            // 
            this.c317.CheckOnClick = true;
            this.c317.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c317.FormattingEnabled = true;
            this.c317.Location = new System.Drawing.Point(141, 283);
            this.c317.Name = "c317";
            this.c317.Size = new System.Drawing.Size(212, 68);
            this.c317.TabIndex = 22;
            // 
            // c316
            // 
            this.c316.CheckOnClick = true;
            this.c316.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c316.FormattingEnabled = true;
            this.c316.Location = new System.Drawing.Point(141, 213);
            this.c316.Name = "c316";
            this.c316.Size = new System.Drawing.Size(212, 68);
            this.c316.TabIndex = 21;
            // 
            // label79
            // 
            this.label79.Location = new System.Drawing.Point(14, 423);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(140, 13);
            this.label79.TabIndex = 20;
            this.label79.Text = "4. Xét nghiệm khác :";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(14, 354);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(116, 13);
            this.label78.TabIndex = 19;
            this.label78.Text = "3. Chẩn đoán hình :";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.Location = new System.Drawing.Point(14, 286);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(127, 13);
            this.label77.TabIndex = 18;
            this.label77.Text = "2. Xét nghiệm nước tiểu :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(14, 214);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(116, 13);
            this.label76.TabIndex = 17;
            this.label76.Text = "1. Xét nghiệm máu :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(8, 188);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(116, 13);
            this.label75.TabIndex = 16;
            this.label75.Text = "Cận lâm sàng :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c314
            // 
            this.c314.FormattingEnabled = true;
            this.c314.Location = new System.Drawing.Point(141, 159);
            this.c314.Name = "c314";
            this.c314.Size = new System.Drawing.Size(212, 21);
            this.c314.TabIndex = 15;
            // 
            // c313
            // 
            this.c313.FormattingEnabled = true;
            this.c313.Location = new System.Drawing.Point(141, 137);
            this.c313.Name = "c313";
            this.c313.Size = new System.Drawing.Size(212, 21);
            this.c313.TabIndex = 14;
            // 
            // c312
            // 
            this.c312.FormattingEnabled = true;
            this.c312.Location = new System.Drawing.Point(141, 115);
            this.c312.Name = "c312";
            this.c312.Size = new System.Drawing.Size(212, 21);
            this.c312.TabIndex = 13;
            // 
            // c311
            // 
            this.c311.FormattingEnabled = true;
            this.c311.Location = new System.Drawing.Point(141, 93);
            this.c311.Name = "c311";
            this.c311.Size = new System.Drawing.Size(212, 21);
            this.c311.TabIndex = 12;
            // 
            // c310
            // 
            this.c310.FormattingEnabled = true;
            this.c310.Location = new System.Drawing.Point(141, 70);
            this.c310.Name = "c310";
            this.c310.Size = new System.Drawing.Size(212, 21);
            this.c310.TabIndex = 11;
            // 
            // c309
            // 
            this.c309.FormattingEnabled = true;
            this.c309.Location = new System.Drawing.Point(141, 48);
            this.c309.Name = "c309";
            this.c309.Size = new System.Drawing.Size(212, 21);
            this.c309.TabIndex = 10;
            // 
            // c308
            // 
            this.c308.FormattingEnabled = true;
            this.c308.Location = new System.Drawing.Point(141, 26);
            this.c308.Name = "c308";
            this.c308.Size = new System.Drawing.Size(212, 21);
            this.c308.TabIndex = 9;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(23, 162);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(116, 13);
            this.label73.TabIndex = 8;
            this.label73.Text = "Xử trí khám sức khỏe :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(23, 140);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(116, 13);
            this.label72.TabIndex = 7;
            this.label72.Text = "Khám sản phụ khoa :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(23, 116);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(116, 13);
            this.label71.TabIndex = 6;
            this.label71.Text = "Khám TMH :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(23, 96);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(116, 13);
            this.label70.TabIndex = 5;
            this.label70.Text = "Khám RHM :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(23, 73);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(116, 13);
            this.label69.TabIndex = 4;
            this.label69.Text = "Khám mắt :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(23, 51);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(116, 13);
            this.label68.TabIndex = 3;
            this.label68.Text = "Khám ngoại :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(23, 29);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(116, 13);
            this.label67.TabIndex = 2;
            this.label67.Text = "Khám nội :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c307
            // 
            this.c307.FormattingEnabled = true;
            this.c307.Location = new System.Drawing.Point(141, 4);
            this.c307.Name = "c307";
            this.c307.Size = new System.Drawing.Size(212, 21);
            this.c307.TabIndex = 1;
            // 
            // c306
            // 
            this.c306.AutoSize = true;
            this.c306.Location = new System.Drawing.Point(13, 8);
            this.c306.Name = "c306";
            this.c306.Size = new System.Drawing.Size(100, 17);
            this.c306.TabIndex = 0;
            this.c306.Text = "Khám sức khỏe";
            this.c306.UseVisualStyleBackColor = true;
            this.c306.CheckedChanged += new System.EventHandler(this.c306_CheckedChanged);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(79, 477);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 55;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(8, 477);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 54;
            this.butOk.Text = "    &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // c404
            // 
            this.c404.Location = new System.Drawing.Point(608, 115);
            this.c404.Name = "c404";
            this.c404.Size = new System.Drawing.Size(341, 20);
            this.c404.TabIndex = 286;
            this.c404.Text = "Xử trí hẹn không cho phép in chi phí tại phòng khám";
            // 
            // frmThongso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(692, 506);
            this.Controls.Add(this.p03);
            this.Controls.Add(this.p07);
            this.Controls.Add(this.p06);
            this.Controls.Add(this.p05);
            this.Controls.Add(this.p08);
            this.Controls.Add(this.p11);
            this.Controls.Add(this.p10);
            this.Controls.Add(this.p09);
            this.Controls.Add(this.p01);
            this.Controls.Add(this.p02);
            this.Controls.Add(this.p04);
            this.Controls.Add(this.p12);
            this.Controls.Add(this.p13);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.txtNodeTextSearch);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmThongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số hệ thống";
            this.Load += new System.EventHandler(this.frmThongso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongso_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.c104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c139)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hhtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c273)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c272)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c270)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c269)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c268)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c267)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c266)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c257)).EndInit();
            this.c59.ResumeLayout(false);
            this.c56.ResumeLayout(false);
            this.c60.ResumeLayout(false);
            this.c113.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c189)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c120)).EndInit();
            this.p01.ResumeLayout(false);
            this.p01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songaydemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138m)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.p02.ResumeLayout(false);
            this.p02.PerformLayout();
            this.p03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c325)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c305)).EndInit();
            this.p12.ResumeLayout(false);
            this.p12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.p04.ResumeLayout(false);
            this.p05.ResumeLayout(false);
            this.p05.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c365)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c348)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c351)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c352)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c333)).EndInit();
            this.p06.ResumeLayout(false);
            this.p07.ResumeLayout(false);
            this.p07.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c366)).EndInit();
            this.p08.ResumeLayout(false);
            this.p08.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c339)).EndInit();
            this.p09.ResumeLayout(false);
            this.p11.ResumeLayout(false);
            this.p11.PerformLayout();
            this.p10.ResumeLayout(false);
            this.p13.ResumeLayout(false);
            this.p13.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmThongso_Load(object sender, System.EventArgs e)
		{
            if (bAdmin) this.Text = "F5 : Nạp thông số mặc nhiên, F6 : Lưu thông số mặc nhiên, F7 : Nạp thông số đã cấu hình, F8 : Lưu thông số cấu hình";
            sTemp = m.getPathTemp;
            tTemp.Text = sTemp;
            lTemp.Text = "Thư mục TEMP của "+Environment.UserName.ToString();
            user = m.user;
			ins();
            load_treeview();
            dsletet.ReadXml("..//..//..//xml//m_letet.xml");
            foreach (DataRow r in dsletet.Tables[0].Rows)
            {
                if (r["ngay"].ToString().Trim().Length == 5 && r["ngay"].ToString().Trim().IndexOf("/") != -1)
                {
                    if (m.get_data("select * from "+user+".letet where ngay='" + r["ngay"].ToString() + "'").Tables[0].Rows.Count == 0)
                        m.execute_data("insert into "+user+".letet(ngay) values ('" + r["ngay"].ToString() + "')");
                }
            }
            dsletet = m.get_data("select * from "+user+".letet");
            dataGrid2.DataSource = dsletet.Tables[0];
            AddGridTableStyle2();
            dataGrid2.ReadOnly = false;
            CurrencyManager cm2 = (CurrencyManager)BindingContext[dataGrid2.DataSource, dataGrid2.DataMember];
            DataView dv2 = (DataView)cm2.List;
            dv2.AllowNew = true; 

			c165.DisplayMember="TEN";
			c165.ValueMember="ID";
			c165.DataSource=m.get_data("select * from "+user+".d_dmnhomkho order by stt").Tables[0];
			c165.SelectedValue=m.nhom_nhathuoc.ToString();

			c166.DisplayMember="TEN";
			c166.ValueMember="ID";
            c166.DataSource = m.get_data("select * from " + user + ".d_dmnhomkho order by stt").Tables[0];
			c166.SelectedValue=m.nhom_duoc.ToString();

            c229.DisplayMember = "USERID";
            c229.ValueMember = "ID";
            c229.DataSource = m.get_data("select * from " + user + ".d_dlogin where nhomkho="+m.nhom_duoc+" order by id").Tables[0];

            c147.DisplayMember="DOITUONG";
			c147.ValueMember="MADOITUONG";
            c147.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where mien=1 order by madoituong").Tables[0];

			c149.DisplayMember="DOITUONG";
			c149.ValueMember="MADOITUONG";
            c149.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where mien=0 order by madoituong").Tables[0];

            sql = "select * from "+user+".doituong order by madoituong";
            dtdt = m.get_data(sql).Tables[0];
            c324.DataSource = dtdt;
            c324.DisplayMember = "DOITUONG";
            c324.ValueMember = "MADOITUONG";
           
            c193.DisplayMember = "DOITUONG";
            c193.ValueMember = "MADOITUONG";
            c193.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];

            c280.DisplayMember = "DOITUONG";
            c280.ValueMember = "MADOITUONG";
            c280.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];

            c284.DisplayMember = "DOITUONG";
            c284.ValueMember = "MADOITUONG";
            c284.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];          

            c396.DisplayMember = "TEN";
            c396.ValueMember = "ID";
            c396.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            c286.DisplayMember = "DOITUONG";
            c286.ValueMember = "MADOITUONG";
            c286.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];

            c298.DisplayMember = "TEN";
            c298.ValueMember = "ID";
            c298.DataSource = m.get_data("select * from "+user+".d_dmkho where nhom=" + m.nhom_duoc + " order by stt").Tables[0];

            c299.DisplayMember = "DOITUONG";
            c299.ValueMember = "MADOITUONG";
            c299.DataSource = m.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];

            c364.DisplayMember = "USERID";
            c364.ValueMember = "ID";
            c364.DataSource = m.get_data("select * from " + user + ".d_dlogin where nhomkho=" + m.nhom_duoc + " order by id").Tables[0];

            sql = "select * from "+user+".btdkp_bv where makp<>'01' and loai=1";
            sql += " order by loai,makp";
            dtkp = m.get_data(sql).Tables[0];
            c300.DataSource = dtkp;
            c300.DisplayMember = "TENKP";
            c300.ValueMember = "MAKP";

           
            dsc = m.get_data("select * from " + user + ".dmcomputer order by computer");
            dataGrid3.DataSource = dsc.Tables[0];
            AddGridTableStyle3();
            dataGrid3.ReadOnly = false;
            CurrencyManager cm3 = (CurrencyManager)BindingContext[dataGrid3.DataSource, dataGrid3.DataMember];
            DataView dv3 = (DataView)cm3.List;
            dv3.AllowNew = false; 

            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0";
            sql += " order by loai,makp";
            dtk = m.get_data(sql).Tables[0];
            c315.DataSource = dtk;
            c315.DisplayMember = "TENKP";
            c315.ValueMember = "MAKP";

			c143.DisplayMember="TEN";
			c143.ValueMember="MA";
            c143.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

            c303.DisplayMember = "TEN";
            c303.ValueMember = "MA";
            c303.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

            c234.DisplayMember = "TEN";
            c234.ValueMember = "MA";
            c234.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

            c254.DisplayMember = "TEN";
            c254.ValueMember = "MA";
            c254.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

			dsnn.ReadXml("..//..//..//xml//ngonngu.xml");
			ngonngu.DisplayMember="TEN";
			ngonngu.ValueMember="TEN";
			ngonngu.DataSource=dsnn.Tables[0];

			c137.DisplayMember="TEN";
			c137.ValueMember="ID";

			c176.DisplayMember="TEN";
			c176.ValueMember="ID";

            c186.DisplayMember = "TEN";
            c186.ValueMember = "ID";

            c191.DisplayMember = "TEN";
            c191.ValueMember = "ID";

            c196.DisplayMember = "HOTEN";
            c196.ValueMember = "ID";
            c196.DataSource = m.get_data("select * from "+user+".v_dlogin order by id").Tables[0];

            c220.DisplayMember = "TEN";
            c220.ValueMember = "ID";
            c220.DataSource = d.get_data("select a.* from "+user+".v_giavp a,"+user+".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            c290.DisplayMember = "TEN";
            c290.ValueMember = "ID";
            c290.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            c263.DisplayMember = "TEN";
            c263.ValueMember = "ID";
            c263.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            if (ngonngu.Items.Count>0) ngonngu.SelectedIndex=int.Parse(m.Thongso("Ngonngu"));
			c121.DisplayMember="TENNN";
			c121.ValueMember="MANN";
            c121.DataSource = m.get_data("select * from " + user + ".btdnn_bv order by mann").Tables[0];
			c119.SelectedIndex=0;
			c122.DisplayMember="DANTOC";
			c122.ValueMember="MADANTOC";
            c122.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];
			c123.DisplayMember="TENTT";
			c123.ValueMember="MATT";
            c123.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];
			loaidv.SelectedIndex=2;
            bTenvien = m.get_data("select * from " + user + ".tenvien_add").Tables[0].Rows.Count != 0;
			bKhaibao=m.bKhaibaobandau;
			loaidv.Enabled=!bKhaibao;
			if (!bTenvien)
			{
				matt.Enabled=loaidv.Enabled;
				maqu.Enabled=loaidv.Enabled;
				benhvien.Enabled=loaidv.Enabled;
			}
			songay.Maximum=Decimal.Parse(int.MaxValue.ToString());
			dsts.ReadXml("..//..//..//xml//thongso.xml");
			ds.ReadXml("..//..//..//xml//maincode.xml");
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + user + ".btdtt where matt<>'000' order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";

            c307.DataSource = m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
            c307.DisplayMember = "DOITUONG";
            c307.ValueMember = "MADOITUONG";

            c308.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c308.DisplayMember = "TENKP";
            c308.ValueMember = "MAKP";

            c309.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c309.DisplayMember = "TENKP";
            c309.ValueMember = "MAKP";

            c310.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c310.DisplayMember = "TENKP";
            c310.ValueMember = "MAKP";

            c311.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c311.DisplayMember = "TENKP";
            c311.ValueMember = "MAKP";

            c312.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c312.DisplayMember = "TENKP";
            c312.ValueMember = "MAKP";

            c313.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c313.DisplayMember = "TENKP";
            c313.ValueMember = "MAKP";

            c314.DisplayMember = "TEN";
            c314.ValueMember = "MA";
            c314.DataSource = m.get_data("select * from "+user+".xutrikb order by ma").Tables[0];

            dtlvp = d.get_data("select * from " + user + ".v_loaivp b order by stt").Tables[0];

            c316.DataSource = d.get_data("select * from " + user + ".v_loaivp b order by stt").Tables[0];
            c316.DisplayMember = "TEN";
            c316.ValueMember = "ID";

            c317.DataSource = d.get_data("select * from " + user + ".v_loaivp b order by stt").Tables[0];
            c317.DisplayMember = "TEN";
            c317.ValueMember = "ID";

            c318.DataSource = d.get_data("select * from " + user + ".v_loaivp b order by stt").Tables[0];
            c318.DisplayMember = "TEN";
            c318.ValueMember = "ID";

            c319.DataSource = d.get_data("select * from " + user + ".v_loaivp b order by stt").Tables[0];
            c319.DisplayMember = "TEN";
            c319.ValueMember = "ID";

            c368.DisplayMember = "DOITUONG";
            c368.ValueMember = "MADOITUONG";
            c368.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where mien=1 order by madoituong").Tables[0];

            s_makho = d.get_dmkho(1);
            sql = "select * from " + user + ".d_dmkho where nhom<>0 ";
            if (c166.SelectedIndex != -1) sql += " and nhom=" + int.Parse(c166.SelectedValue.ToString());
            if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by stt";
            c375.DisplayMember = "TEN";
            c375.ValueMember = "ID";
            c375.DataSource = m.get_data(sql).Tables[0];

            c389.DisplayMember = "TEN";
            c389.ValueMember = "ID";
            c389.DataSource = m.get_data(sql).Tables[0];

            c379.DisplayMember = "TEN";
            c379.ValueMember = "ID";
            c379.DataSource = m.get_data(sql).Tables[0];

            dt397 = m.get_data("select * from " + user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            c397.DataSource = dt397;
            c397.DisplayMember = "TENKP";
            c397.ValueMember = "MAKP";

            dtkho = m.get_data("select * from "+user+".d_dmkho where nhom=" + m.nhom_duoc + " order by stt").Tables[0];
            c401.DataSource = dtkho;
            c401.DisplayMember = "TEN";
            c401.ValueMember = "ID";

            c402.DisplayMember = "HOTEN";
            c402.ValueMember = "ID";			

            dt = m.get_data("select * from " + user + ".tenvien order by mabv").Tables[0];
			benhvien.DisplayMember="TENBV";
			benhvien.ValueMember="MABV";
			benhvien.DataSource=dt;
			benhvien.SelectedIndex=-1;
            _id = "";
			try
			{
				switch (m.iSokham)
				{
					case 1: c591.Checked=true;
						break;
					case 2: c592.Checked=true;
						break;
					default : c593.Checked=true;
						break;
				}
				switch (m.iSudungthuoc)
				{
					case 1: c561.Checked=true;
						break;
					case 2: c562.Checked=true;
						break;
					default : c563.Checked=true;
						break;
				}
				switch (m.iChidinh)
				{
					case 1: c601.Checked=true;
						break;
					case 2: c602.Checked=true;
						break;
					case 3: c603.Checked=true;
						break;
					default : c604.Checked=true;
						break;
				}
				switch (m.iVienphi)
				{
					case 1: c1131.Checked=true;
						break;
					case 2: c1132.Checked=true;
						break;
					case 3 : c1133.Checked=true;
						break;
					default : c1134.Checked=true;
						break;
				}
				matt.SelectedValue=m.Mabv.Substring(0,3).ToString();
				maqu.SelectedValue=m.Maqu.ToString();
				benhvien.SelectedValue=m.Mabv.ToString();
                c275.SelectedIndex = 0;
                load_tso("ten");
			}
            catch (Exception ex) { MessageBox.Show(_id+"\n"+ex.Message); }
			load_grid();
			AddGridTableStyle();
            c257.Enabled = c255.Checked || c256.Checked;
            c341.Enabled = but341.Enabled = c340.Checked;
            if (bAdmin)
            {
                demo.Visible = songaydemo.Visible = true;
                demo.Checked = m.Ngaydemo("medisoft")!="";
                songaydemo.Value = m.Songaydemo;
            }
			mm.Enabled=c135.Checked;
			c146.Enabled=c144.Checked;
			c151.Enabled=c133.Checked || c46.Checked;
            c225.Enabled=sovaovien.Checked;
            c241.Enabled = sovaovien.Checked;
			c177.Enabled=c140.Checked;
            c371.Enabled = c246.Checked;
            c239.Enabled = c226.Checked;
            c301.Enabled = c226.Checked;
            ena_kho_khoa();
			hh.Enabled=mm.Enabled;
			c137.Enabled=hh.Enabled;
			c165.Enabled=hh.Enabled;
            lbl60.Text = "2.3. Những thẻ bắt buộc còn lại được thanh toán               %,  nhưng không quá :" + c351.Value.ToString();
            hhtn.Enabled = c153.Checked;
            mmtn.Enabled = c153.Checked;
            c193.Enabled = c153.Checked;
            c220.Enabled = c219.Checked;
            c290.Enabled = c289.Checked;
            c263.Enabled = c262.Checked;
            c229.Enabled = c228.Checked;
            c236.Enabled = c235.Checked;
            c254.Enabled = c253.Checked;
            c278.Enabled = c235.Checked;
            c279.Enabled = c235.Checked;
            c280.Enabled = c279.Checked;
            c264.Enabled = c248.Checked || c258.Checked;
            c275.Enabled = c248.Checked || c258.Checked;
            c283.Enabled = c47.Checked;
            c284.Enabled = c283.Checked && c47.Checked;
            c286.Enabled = c283.Checked && c47.Checked;
            c360.Enabled = c347.Checked;
            butImage.Enabled = c264.Enabled;
            c300.Enabled=c299.Enabled = c298.Enabled = c297.Checked;
            c359.Enabled=c335.Enabled=c302.Enabled = c179.Checked;
            c364.Enabled = c363.Checked;
            c401.Enabled = c402.Enabled = c400.Checked;
            ena_taikham();
            load_356_358();
            c384.Enabled = c359.Checked;
            if (c297.Checked)
            {
                for (int i = 0; i < c300.Items.Count; i++)
                    if (s_300.IndexOf("'" + dtkp.Rows[i]["makp"].ToString() + "'") != -1) c300.SetItemCheckState(i, CheckState.Checked);
                    else c300.SetItemCheckState(i, CheckState.Unchecked);
            }
            ena_ksk();
            for (int i = 0; i < c315.Items.Count; i++)
                if (s_315.IndexOf("'" + dtk.Rows[i]["makp"].ToString() + "'") != -1) c315.SetItemCheckState(i, CheckState.Checked);
                else c315.SetItemCheckState(i, CheckState.Unchecked);
            c287.Enabled = c46.Checked;

            for (int i = 0; i < c316.Items.Count; i++)
                if (s_316.IndexOf(dtlvp.Rows[i]["id"].ToString().PadLeft(3,'0')) != -1) c316.SetItemCheckState(i, CheckState.Checked);
                else c316.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c317.Items.Count; i++)
                if (s_317.IndexOf(dtlvp.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c317.SetItemCheckState(i, CheckState.Checked);
                else c317.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c318.Items.Count; i++)
                if (s_318.IndexOf(dtlvp.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c318.SetItemCheckState(i, CheckState.Checked);
                else c318.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c319.Items.Count; i++)
                if (s_319.IndexOf(dtlvp.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c319.SetItemCheckState(i, CheckState.Checked);
                else c319.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c324.Items.Count; i++)
                if (s_324.IndexOf(dtdt.Rows[i]["madoituong"].ToString().PadLeft(2, '0')) != -1) c324.SetItemCheckState(i, CheckState.Checked);
                else c324.SetItemCheckState(i, CheckState.Unchecked);

             if (c374.Checked)
            {
                for (int i = 0; i < c376.Items.Count; i++)
                    if (s_376.IndexOf(dtkhok.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c376.SetItemCheckState(i, CheckState.Checked);
                    else c376.SetItemCheckState(i, CheckState.Unchecked);
                for (int i = 0; i < c390.Items.Count; i++)
                    if (s_390.IndexOf(dtkhotua.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c390.SetItemCheckState(i, CheckState.Checked);
                    else c390.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < c397.Items.Count; i++)
                if (s_397.IndexOf(dt397.Rows[i]["makp"].ToString()) != -1) c390.SetItemCheckState(i, CheckState.Checked);
                else c397.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c401.Items.Count; i++)
                if (s_401.IndexOf(dtkho.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c401.SetItemCheckState(i, CheckState.Checked);
                else c401.SetItemCheckState(i, CheckState.Unchecked);

			if (c165.Enabled) load_137();
			load_176();
            load_186();
            load_191();
            load_402();
			c171.Enabled=c170.Checked;
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
            check(p06);
		}

        private void load_402()
        {
            try
            {
                c402.DataSource = m.get_data("select id,trim(hoten)||' ('||trim(userid)||')' as hoten from "+user+".d_dlogin where nhomkho=" + int.Parse(c166.SelectedValue.ToString()) + "order by id").Tables[0];
                c402.SelectedValue = s_402;
            }
            catch { }
        }
        private void load_tso(string fie)
        {
            foreach (DataRow r in m.get_data("select * from " + user + ".thongso order by id").Tables[0].Rows)
            {
                _id = r["id"].ToString();
                if (r[fie].ToString() != "")
                {
                    switch (int.Parse(r["id"].ToString()))
                    {
                        case 1: loaidv.SelectedIndex = int.Parse(r[fie].ToString().Trim());
                            break;
                        case 2: matt.SelectedValue = m.Mabv.Substring(0, 3);
                            break;
                        case 4: soyte.Text = r[fie].ToString().Trim();
                            break;
                        case 5: diachi.Text = r[fie].ToString().Trim();
                            break;
                        case 6: dienthoai.Text = r[fie].ToString().Trim();
                            break;
                        case 14: songay.Value = Decimal.Parse(m.Thongso("c14"));
                            break;
                        case 15: sovaovien.Checked = int.Parse(r[fie].ToString().Trim()) == 1;
                            break;
                        case 16: soluutru.Checked = int.Parse(r[fie].ToString().Trim()) == 1;
                            break;
                        case 17: chandoan.Checked = int.Parse(m.Thongso("c17")) == 1;
                            break;
                        case 18: pttt.Checked = int.Parse(m.Thongso("c18")) == 1;
                            break;
                        case 21: ngaylv.Checked = int.Parse(m.Thongso("c21")) == 1;
                            break;
                        case 22: solieu.Checked = int.Parse(m.Thongso("c22")) == 1;
                            break;
                        case 23: khambenh.Checked = int.Parse(m.Thongso("c23")) == 1;
                            break;
                        case 24: maqu.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 25: noichuyen.Checked = int.Parse(m.Thongso("c25")) == 1;
                            break;
                        case 26: bsKhambenh.Checked = int.Parse(m.Thongso("c26")) == 1;
                            break;
                        case 27: bsNgoaitru.Checked = int.Parse(m.Thongso("c27")) == 1;
                            break;
                        case 28: bsNhanbenh.Checked = int.Parse(m.Thongso("c28")) == 1;
                            break;
                        case 29: bsNhapkhoa.Checked = int.Parse(m.Thongso("c29")) == 1;
                            break;
                        case 30: bsXuatkhoa.Checked = int.Parse(m.Thongso("c30")) == 1;
                            break;
                        case 31: bsXuatvien.Checked = int.Parse(m.Thongso("c31")) == 1;
                            break;
                        case 32: bsPttt.Checked = int.Parse(m.Thongso("c32")) == 1;
                            break;
                        case 33: saoluu33.Checked = int.Parse(m.Thongso("c33")) == 1;
                            break;
                        case 36: c36.Checked = int.Parse(m.Thongso("c36")) == 1;
                            break;
                        case 38: c38.Checked = int.Parse(m.Thongso("c38")) == 1;
                            break;
                        case 39: c39.Text = m.Thongso("c39");
                            break;
                        case 40: c40.Text = m.Thongso("c40");
                            break;
                        case 41: c41.Text = m.Thongso("c41");
                            break;
                        case 42: c42.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 43: c43.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 44: c44.Checked = int.Parse(m.Thongso("c44")) == 1;
                            break;
                        case 45: c45.Checked = int.Parse(m.Thongso("c45")) == 1;
                            break;
                        case 46: c46.Checked = int.Parse(m.Thongso("c46")) == 1;
                            break;
                        case 47: c47.Checked = int.Parse(m.Thongso("c47")) == 1;
                            break;
                        case 48: c48.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 51: c51.Checked = int.Parse(m.Thongso("c51")) == 1;
                            break;
                        case 52: c52.Checked = int.Parse(m.Thongso("c52")) == 1;
                            break;
                        case 53: c53.Checked = int.Parse(m.Thongso("c53")) == 1;
                            break;
                        case 54: c54.Checked = r[fie].ToString() == "1";
                            break;
                        case 55: c55.Checked = int.Parse(m.Thongso("c55")) == 1;
                            break;
                        case 57: c57.Checked = int.Parse(m.Thongso("c57")) == 1;
                            break;
                        case 58: c58.Checked = int.Parse(m.Thongso("c58")) == 1;
                            break;
                        case 61: c61.Checked = int.Parse(m.Thongso("c61")) == 1;
                            break;
                        case 0: c0.Checked = r[fie].ToString() == "1";
                            break;
                        case 100: c100.Checked = r[fie].ToString() == "1";
                            break;
                        case 102: c102.Checked = r[fie].ToString() == "1";
                            break;
                        case 104: c104.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 105: c105.Checked = int.Parse(m.Thongso("c105")) == 1;
                            break;
                        case 106: c106.Checked = r[fie].ToString() == "1";
                            break;
                        case 107: c107.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 108: c108.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 109: c109.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 110: c110.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 111: c111.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 112: c112.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 114: c114.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 115: c115.Text = r[fie].ToString().Trim();
                            break;
                        case 116: c116.Checked = int.Parse(m.Thongso("c116")) == 1;
                            break;
                        case 118: c118.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 119: c119.SelectedIndex = int.Parse(r[fie].ToString().Trim());
                            break;
                        case 120: c120.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 121: c121.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 122: c122.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 123: c123.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 124: c124.Text = r[fie].ToString().Trim();
                            break;
                        case 200: c200.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 125: c125.Checked = int.Parse(m.Thongso("c125")) == 1;
                            break;
                        case 126: c126.Checked = int.Parse(m.Thongso("c126")) == 1;
                            break;
                        case 127: c127.Checked = int.Parse(m.Thongso("c127")) == 1;
                            break;
                        case 128: c128.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 129: c129.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 130: c130.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 131: c131.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 132: c132.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 133: c133.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 134: c134.Checked = m.Thongso("c134") == "1";
                            break;
                        case 135: c135.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 136: hh.Value = decimal.Parse(r[fie].ToString().Substring(0, 2));
                            mm.Value = decimal.Parse(r[fie].ToString().Substring(3, 2));
                            break;
                        case 137: c137.SelectedValue = r[fie].ToString();
                            s_137 = r[fie].ToString();
                            break;
                        case 138:
                            _id = (r[fie].ToString().Trim() == "") ? "00:00" : r[fie].ToString();
                            c138h.Value = decimal.Parse(_id.Substring(0, 2));
                            c138m.Value = decimal.Parse(_id.Substring(3, 2));
                            break;
                        case 139: c139.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 140: c140.Checked = int.Parse(m.Thongso("c140")) == 1;
                            break;
                        case 141: c141.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 142: c142.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 143: c143.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 144: c144.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 145: c145.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 146: c146.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 147: c147.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 148: c148.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 149: c149.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 150: c150.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 151: c151.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 153: c153.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 154: c154.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 155: c155.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 156: c156.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 157: c157.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 158: c158.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 159: c159.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 160: c160.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 161: c161.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 162: c162.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 163: c163.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 164: c164.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 165: c165.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 166: c166.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 167: c167.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 169: c169.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 170: c170.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 171: c171.Text = r[fie].ToString().Trim();
                            break;
                        case 172: c172.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 174: c174.Text = r[fie].ToString().Trim();
                            break;
                        case 175: hhb.Value = decimal.Parse(r[fie].ToString().Substring(0, 2));
                            mmb.Value = decimal.Parse(r[fie].ToString().Substring(3, 2));
                            break;
                        case 176: c176.SelectedValue = r[fie].ToString().Trim();
                            s_176 = r[fie].ToString();
                            break;
                        case 177: c177.Checked = int.Parse(m.Thongso("c177")) == 1;
                            break;
                        case 178: c178.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 179: c179.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 180: c180.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 181: c181.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 182: c182.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 183: c183.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 184: c184.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 185: hht.Value = decimal.Parse(r[fie].ToString().Substring(0, 2));
                            mmt.Value = decimal.Parse(r[fie].ToString().Substring(3, 2));
                            break;
                        case 186: c186.SelectedValue = r[fie].ToString().Trim();
                            s_186 = r[fie].ToString();
                            break;
                        case 187: hhtn.Value = decimal.Parse(r[fie].ToString().Substring(0, 2));
                            mmtn.Value = decimal.Parse(r[fie].ToString().Substring(3, 2));
                            break;
                        case 188: c188.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 189: c189.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 190: hhl.Value = decimal.Parse(r[fie].ToString().Substring(0, 2));
                            mml.Value = decimal.Parse(r[fie].ToString().Substring(3, 2));
                            break;
                        case 191: c191.SelectedValue = r[fie].ToString().Trim();
                            s_191 = r[fie].ToString();
                            break;
                        case 192: c192.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 193: if (c153.Checked) c193.SelectedValue = r[fie].ToString().Trim();
                            else c193.SelectedIndex = -1;
                            break;
                        case 194: c194.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 195: c195.Checked = int.Parse(m.Thongso("c195")) == 1;
                            break;
                        case 196: c196.SelectedValue = m.Thongso("c196");
                            s_196 = m.Thongso("c196");
                            break;
                        case 197: c197.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 198: c198.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 199: c199.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 201: c201.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 202: c202.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 203: c203.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 204: c204.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 205: c205.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 213: c213.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 214: c214.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 215: c215.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 216: c216.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 217: c217.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 218: c218.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 219: c219.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 220: c220.SelectedValue = r[fie].ToString();
                            break;
                        case 223: c223.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 224: c224.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 225: c225.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 226: c226.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 227: c227.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 228: c228.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 229: if (r[fie].ToString() != "0") c229.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 230: c230.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 231: c231.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 232: c232.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 233: c233.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 234: c234.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 235: c235.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 236: c236.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 237: c237.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 238: c238.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 239: c239.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 240: c240.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 241: c241.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 242: c242.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 243: c243.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 244: c244.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 245: c245.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 246: c246.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 247: c247.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 248: c248.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 249: c249.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 250: c250.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 251: c251.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 252: c252.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 253: c253.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 254: c254.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 255: c255.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 256: c256.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 257: c257.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 258: c258.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 259: c259.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 260: c260.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 261: c261.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 262: c262.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 263: c263.SelectedValue = r[fie].ToString();
                            break;
                        case 264: c264.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 265: c265.Text = r[fie].ToString();
                            break;
                        case 266: c266.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 267: c267.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 268: c268.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 269: c269.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 270: c270.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 271: c271.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 272: c272.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 273: c273.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 274: c274.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 275: c275.Text = r[fie].ToString().Trim();
                            break;
                        case 276: c276.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 277: c277.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 278: c278.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 279: c279.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 280: c280.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 281: c281.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 282: c282.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 283: c283.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 284: c284.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 286: c286.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 287: c287.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 288: c288.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 289: c289.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 290: c290.SelectedValue = r[fie].ToString();
                            break;
                        case 291: c291.Value = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(r[fie].ToString().Substring(0, 2)), int.Parse(r[fie].ToString().Substring(3)), 0);
                            break;
                        case 292: c292.Value = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(r[fie].ToString().Substring(0, 2)), int.Parse(r[fie].ToString().Substring(3)), 0);
                            break;
                        case 293: c293.Value = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(r[fie].ToString().Substring(0, 2)), int.Parse(r[fie].ToString().Substring(3)), 0);
                            break;
                        case 294: c294.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 295: c295.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 296: c296.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 297: c297.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 298: c298.SelectedValue = r[fie].ToString();
                            break;
                        case 299: c299.SelectedValue = r[fie].ToString();
                            break;
                        case 300: s_300 = r[fie].ToString().Trim();
                            break;
                        case 301: c301.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 302: c302.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 303: c303.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 304: c304.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 305: c305.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 306: c306.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 307: c307.SelectedValue= r[fie].ToString().Trim();
                            break;
                        case 308: c308.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 309: c309.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 310: c310.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 311: c311.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 312: c312.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 313: c313.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 314: c314.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 315: s_315 = r[fie].ToString().Trim();
                            break;
                        case 316: s_316 = r[fie].ToString().Trim();
                            break;
                        case 317: s_317 = r[fie].ToString().Trim();
                            break;
                        case 318: s_318 = r[fie].ToString().Trim();
                            break;
                        case 319: s_319 = r[fie].ToString().Trim();
                            break;
                        case 320: c320.Checked = r[fie].ToString().Trim()=="1";
                            break;
                        case 321: c321.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 322: c322.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 323: c323.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 324: s_324 = r[fie].ToString().Trim();
                            break;
                        case 325: c325.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 326: c326.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 327: c327.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 328: c328.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 329: c329.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 330: c330.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 331: c331.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 332: c332.Text = r[fie].ToString().Trim();
                            break;
                        case 333: c333.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 334: c334.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 335: c335.Text = r[fie].ToString().Trim();
                            break;
                        case 336: c336.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 337: c337.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 338: c338.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 339: c339.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 340: c340.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 341: c341.Text = r[fie].ToString();
                            break;
                        case 342: c342.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 343: c343.Checked = m.Thongso("smartcard").ToString().Trim() == "1";
                            break;
                        case 344: c344.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 345: c345.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 346: c346.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 347: c347.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 348: c348.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 349: c349.Text = r[fie].ToString();
                            break;
                        case 350: c350.Text = r[fie].ToString();
                            break;
                        case 351: c351.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 352: c352.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 353: c353.Checked = r[fie].ToString() == "1";
                            break;
                        case 354: c354.Checked = r[fie].ToString() == "1";
                            break;
                       case 356: s_356 = r[fie].ToString().Trim();
                            break;
                         case 358: s_358 = r[fie].ToString().Trim();
                            break;
                        case 359: c359.Checked = r[fie].ToString() == "1";
                            break;
                        case 360: c360.Checked = r[fie].ToString() == "1";
                            break;
                        case 361: c361.Checked = r[fie].ToString() == "1";
                            break;
                        case 362: c362.Checked = r[fie].ToString() == "1";
                            break;
                        case 363: c363.Checked = r[fie].ToString() == "1";
                            break;
                        case 364: if (r[fie].ToString() != "0") c364.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 365: c365.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 366: c366.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 367: c367.Text = r[fie].ToString();
                            break;
                        case 368: c368.SelectedValue = r[fie].ToString().Trim();
                            break;
                        case 369: c369.Checked = r[fie].ToString().Trim()=="1";
                            break;
                        case 370: c370.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 371: c371.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 372: c372.Text = r[fie].ToString().Trim();
                            break;
                        case 373: c373.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 374: c374.Checked = r[fie].ToString() == "1";
                            break;
                        case 375: c375.SelectedValue = r[fie].ToString();
                            break;
                        case 376: s_376 = r[fie].ToString().Trim();
                            break;
                        case 377: c377.Checked = r[fie].ToString() == "1";
                            break;
                        case 378: c378.Checked = r[fie].ToString() == "1";
                            break;
                        case 379: c379.SelectedValue = r[fie].ToString();
                            break;
                        case 381: c381.Checked = r[fie].ToString() == "1";
                            break;
                        case 382: c382.Checked = r[fie].ToString() == "1";
                            break;
                        case 383: c383.Checked = r[fie].ToString() == "1";
                            break;
                        case 384: c384.Checked = r[fie].ToString() == "1";
                            break;
                        case 385: c385.Checked = r[fie].ToString() == "1";
                            break;
                        case 386: c386.Checked = r[fie].ToString() == "1";
                            break;
                        case 387: c387.Checked = r[fie].ToString() == "1";
                            break;
                        case 388: c388.Checked = r[fie].ToString() == "1";
                            break;
                        case 389: c389.SelectedValue = r[fie].ToString();
                            break;
                        case 390: s_390 = r[fie].ToString().Trim();
                            break;
                        case 391: c391.Checked = r[fie].ToString() == "1";
                            break;
                        case 392: c392.Checked = r[fie].ToString() == "1";
                            break;
                        case 393: c393.Checked = r[fie].ToString() == "1";
                            break;
                        case 394: c394.Checked = r[fie].ToString() == "1";
                            break;
                        case 395: c395.Checked = r[fie].ToString() == "1";
                            break;
                        case 396: c396.SelectedValue = r[fie].ToString();
                            break;
                        case 397: s_397 = r[fie].ToString().Trim();
                            break;
                        case 398: c398.Checked = r[fie].ToString() == "1";
                            break;
                        case 399: c399.Checked = r[fie].ToString() == "1";
                            break;
                        case 400: c400.Checked = r[fie].ToString() == "1";
                            break;
                        case 401: s_401 = r[fie].ToString();
                            break;
                        case 402: c402.SelectedValue = r[fie].ToString();
                            s_402 = r[fie].ToString();
                            break;
                        case 403: c403.Checked = r[fie].ToString() == "1";
                            break;
                        case 404: c404.Checked = r[fie].ToString() == "1";
                            break;
                    }
                }
            }
        }
        private void check(Panel p)
        {
            foreach (System.Windows.Forms.Control c in p.Controls)
            {
                try
                {
                    CheckBox chk = (CheckBox)c;
                    if (chk.Checked) chk.ForeColor = Color.Red;
                }
                catch { }
            }
        }

        private void load_treeview()
        {
            dssys.ReadXml("..//..//..//xml//tsosystem.xml");
            TreeNode node;
            TreeNode nod;
            node = treeView1.Nodes.Add("Medisoft");
            foreach (DataRow r in dssys.Tables[0].Rows)
            {
                nod = new TreeNode();
                nod.Text = r["text"].ToString();
                nod.Tag = r["tag"].ToString();
                node.Nodes.Add(nod);
            }
            treeView1.ExpandAll();
            this.p01.Location = new System.Drawing.Point(159, 3);
            this.p02.Location = new System.Drawing.Point(159, 3);
            this.p03.Location = new System.Drawing.Point(159, 3);
            this.p04.Location = new System.Drawing.Point(159, 3);
            this.p05.Location = new System.Drawing.Point(159, 3);
            this.p06.Location = new System.Drawing.Point(159, 3);
            this.p07.Location = new System.Drawing.Point(159, 3);
            this.p08.Location = new System.Drawing.Point(159, 3);
            this.p09.Location = new System.Drawing.Point(159, 3);
            this.p11.Location = new System.Drawing.Point(159, 3);
            this.p10.Location = new System.Drawing.Point(159, 3);
            this.p12.Location = new System.Drawing.Point(159, 3);
            this.p13.Location = new System.Drawing.Point(159, 3);
            //this.p01.Visible = true;
        }

		private void load_176()
		{
			s_makho=d.get_dmkho(5);
            sql = "select * from " + user + ".d_dmkho where nhom<>0 ";
			if (c166.SelectedIndex!=-1) sql+=" and nhom="+int.Parse(c166.SelectedValue.ToString());
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			c176.DataSource=m.get_data(sql).Tables[0];
			if (s_176!="") c176.SelectedValue=s_176;
		}

        private void load_186()
        {
            s_makho = d.get_dmkho(6);
            sql = "select * from " + user + ".d_dmkho where nhom<>0 ";
            if (c166.SelectedIndex != -1) sql += " and nhom=" + int.Parse(c166.SelectedValue.ToString());
            if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by stt";
            c186.DataSource = m.get_data(sql).Tables[0];
            if (s_186!="") c186.SelectedValue = s_186;
        }

        private void load_191()
        {
            s_makho = d.get_dmkho(1);
            sql = "select * from "+user+".d_dmkho where nhom<>0 ";
            if (c166.SelectedIndex != -1) sql += " and nhom=" + int.Parse(c166.SelectedValue.ToString());
            if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by stt";
            c191.DataSource = m.get_data(sql).Tables[0];
            if (s_191!="") c191.SelectedValue = s_191;
        }

        private void load_356_358()
        {
            sql = "select * from " + user + ".d_duockp ";
            if (c166.SelectedIndex != -1) sql += " where nhom like '%" + c166.SelectedValue.ToString() + ",%'";
            sql += " order by stt";
            dtkhok = m.get_data(sql).Tables[0];
            c376.DataSource = dtkhok;
            c376.DisplayMember = "TEN";
            c376.ValueMember = "ID";

            dtkhotua = m.get_data(sql).Tables[0];
            c390.DataSource = dtkhotua;
            c390.DisplayMember = "TEN";
            c390.ValueMember = "ID";

            /*
            dtl = m.get_data(sql).Tables[0];
            dtc = m.get_data(sql).Tables[0];
            c356.DataSource = dtc;
            c358.DataSource = dtl;

            c356.DisplayMember = "TEN";
            c356.ValueMember = "ID";

            c358.DisplayMember = "TEN";
            c358.ValueMember = "ID";
             * */
        }

		private void load_137()
		{
			s_makho=d.get_dmkho(7);
            sql = "select * from " + user + ".d_dmkho where nhom<>0 ";
			if (c165.SelectedIndex!=-1) sql+=" and nhom="+int.Parse(c165.SelectedValue.ToString());
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			c137.DataSource=m.get_data(sql).Tables[0];
			if (s_137!="") c137.SelectedValue=s_137;
		}

		private void ins()
		{
            m.execute_data("delete from " + user + ".thongso where id=221 and ten=''");
            m.execute_data("delete from " + user + ".thongso where id=222 and ten=''");
            if (m.get_data("select * from " + user + ".thongso where id=57").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (57,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=54").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (54,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=0").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (0,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=100").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (100,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=101").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (101,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=102").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (102,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=103").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (103,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=104").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (104,'15')");
            if (m.get_data("select * from " + user + ".thongso where id=105").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (105,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=61").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (61,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=106").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (106,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=107").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (107,'200')");
            if (m.get_data("select * from " + user + ".thongso where id=108").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (108,'1')");
            if (m.get_data("select * from " + user + ".thongso where id=109").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (109,'1')");
			if (m.get_data("select * from " + user + ".thongso where id=110").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (110,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=111").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (111,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=112").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (112,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=113").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (113,'4')");
			if (m.get_data("select * from " + user + ".thongso where id=114").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (114,'1')");
			if (m.get_data("select * from " + user + ".thongso where id=115").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id) values (115)");
			if (m.get_data("select * from " + user + ".thongso where id=116").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (116,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=117").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (117,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=118").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (118,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=119").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (119,'1')");
			if (m.get_data("select * from " + user + ".thongso where id=120").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (120,'30')");
			if (m.get_data("select * from " + user + ".thongso where id=121").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (121,'99')");
			if (m.get_data("select * from " + user + ".thongso where id=122").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (122,'25')");
			if (m.get_data("select * from " + user + ".thongso where id=123").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (123,'"+m.Mabv.Substring(0,3)+"')");
            if (m.get_data("select * from " + user + ".thongso where id=124").Tables[0].Rows.Count == 0) m.upd_thongso(124, "VODANH,VD", "VODANH,VD", "VODANH,VD");
			if (m.get_data("select * from " + user + ".thongso where id=125").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (125,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=126").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (126,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=127").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (127,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=128").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (128,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=129").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (129,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=130").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (130,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=131").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (131,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=132").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (132,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=133").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (133,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=134").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (134,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=135").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (135,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=136").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (136,'00:00')");
			if (m.get_data("select * from " + user + ".thongso where id=137").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (137,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=138").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (138,'00:00')");
			if (m.get_data("select * from " + user + ".thongso where id=139").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (139,'30')");
			if (m.get_data("select * from " + user + ".thongso where id=140").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (140,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=141").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (141,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=142").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (142,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=143").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (143,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=144").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (144,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=145").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (145,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=146").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (146,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=147").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (147,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=148").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (148,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=149").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (149,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=150").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (150,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=151").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (151,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=152").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (152,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=153").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (153,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=154").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (154,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=155").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (155,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=156").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (156,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=157").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (157,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=158").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (158,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=159").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (159,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=160").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (160,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=161").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (161,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=162").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (162,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=163").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (163,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=164").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (164,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=165").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (165,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=166").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (166,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=167").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (167,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=168").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (168,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=169").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (169,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=170").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (170,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=171").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (171,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=172").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (172,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=173").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (173,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=174").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (174,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=175").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (175,'00:00')");
			if (m.get_data("select * from " + user + ".thongso where id=176").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (176,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=177").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (177,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=178").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (178,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=179").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (179,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=180").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (180,'0')");
			if (m.get_data("select * from " + user + ".thongso where id=181").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (181,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=182").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (182," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=183").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (183," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=184").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (184," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=185").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (185,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=186").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (186," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=187").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (187,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=188").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (188," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=189").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (189," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=190").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (190,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=191").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (191," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=192").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (192," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=193").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (193," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=194").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (194," + "1" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=195").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (195," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=196").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (196," + "0" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=197").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (197," + "1" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=198").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (198," + "1" + ")");
            if (m.get_data("select * from " + user + ".thongso where id=199").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (199," + "" + ")");
			if (m.get_data("select * from " + user + ".thongso where id=200").Tables[0].Rows.Count==0) m.execute_data("insert into " + user + ".thongso(id,ten) values (200,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=201").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (201,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=202").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (202,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=203").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (203,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=204").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (204,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=205").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (205,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=206").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (206,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=207").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (207,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=208").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (208,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=209").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (209,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=210").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (210,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=211").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (211,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=212").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (212,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=213").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (213,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=214").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (214,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=215").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (215,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=216").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (216,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=217").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (217,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=218").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (218,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=219").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (219,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=220").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (220,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=221").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (221,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=222").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (222,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=223").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (223,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=224").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (224,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=225").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (225,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=226").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (226,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=227").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (227,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=228").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (228,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=229").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (229,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=230").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (230,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=231").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (231,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=232").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (232,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=233").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (233,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=234").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (234,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=235").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (235,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=236").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (236,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=237").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (237,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=238").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (238,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=239").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (239,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=240").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (240,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=241").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (241,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=242").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (242,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=243").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (243,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=244").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (244,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=245").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (245,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=246").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (246,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=247").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (247,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=248").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (248,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=249").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (249,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=250").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (250,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=251").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (251,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=252").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (252,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=253").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (253,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=254").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (254,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=255").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (255,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=256").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (256,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=257").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (257,'4')");
            if (m.get_data("select * from " + user + ".thongso where id=258").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (258,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=259").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (259,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=260").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (260,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=261").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (261,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=262").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (262,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=263").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (263,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=264").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (264,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=265").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (265,'')");
            if (m.get_data("select * from " + user + ".thongso where id=266").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (266,'1800')");
            if (m.get_data("select * from " + user + ".thongso where id=267").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (267,'600')");
            if (m.get_data("select * from " + user + ".thongso where id=268").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (268,'300')");
            if (m.get_data("select * from " + user + ".thongso where id=269").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (269,'600')");
            if (m.get_data("select * from " + user + ".thongso where id=270").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (270,'600')");
            if (m.get_data("select * from " + user + ".thongso where id=271").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (271,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=272").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (272,'600')");
            if (m.get_data("select * from " + user + ".thongso where id=273").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (273,'600')");
            if (m.get_data("select * from " + user + ".thongso where id=274").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (274,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=275").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (275,'BMP')");
            if (m.get_data("select * from " + user + ".thongso where id=276").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (276,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=277").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (277,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=278").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (278,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=279").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (279,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=280").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (280,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=281").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (281,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=282").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (282,'1')");
            if (m.get_data("select * from " + user + ".thongso where id=283").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (283,'1')");
            if (m.get_data("select * from " + user + ".thongso where id=284").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (284,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=285").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (285,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=286").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (286,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=287").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (287,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=288").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (288,'1')");
            if (m.get_data("select * from " + user + ".thongso where id=289").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (289,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=290").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (290,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=291").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (291,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=292").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (292,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=293").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (293,'00:00')");
            if (m.get_data("select * from " + user + ".thongso where id=294").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (294,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=295").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (295,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=296").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (296,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=297").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (297,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=298").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (298,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=299").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (299,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=300").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (300,'')");
            if (m.get_data("select * from " + user + ".thongso where id=301").Tables[0].Rows.Count == 0) m.execute_data("insert into " + user + ".thongso(id,ten) values (301,'0')");
            if (m.get_data("select * from " + user + ".thongso where id=302").Tables[0].Rows.Count == 0) m.upd_thongso(302, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=303").Tables[0].Rows.Count == 0) m.upd_thongso(303, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=304").Tables[0].Rows.Count == 0) m.upd_thongso(304, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=305").Tables[0].Rows.Count == 0) m.upd_thongso(305, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=306").Tables[0].Rows.Count == 0) m.upd_thongso(306, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=307").Tables[0].Rows.Count == 0) m.upd_thongso(307, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=308").Tables[0].Rows.Count == 0) m.upd_thongso(308, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=309").Tables[0].Rows.Count == 0) m.upd_thongso(309, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=310").Tables[0].Rows.Count == 0) m.upd_thongso(310, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=311").Tables[0].Rows.Count == 0) m.upd_thongso(311, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=312").Tables[0].Rows.Count == 0) m.upd_thongso(312, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=313").Tables[0].Rows.Count == 0) m.upd_thongso(313, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=314").Tables[0].Rows.Count == 0) m.upd_thongso(314, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=315").Tables[0].Rows.Count == 0) m.upd_thongso(315, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=316").Tables[0].Rows.Count == 0) m.upd_thongso(316, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=317").Tables[0].Rows.Count == 0) m.upd_thongso(317, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=318").Tables[0].Rows.Count == 0) m.upd_thongso(318, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=319").Tables[0].Rows.Count == 0) m.upd_thongso(319, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=320").Tables[0].Rows.Count == 0) m.upd_thongso(320, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=321").Tables[0].Rows.Count == 0) m.upd_thongso(321, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=322").Tables[0].Rows.Count == 0) m.upd_thongso(322, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=323").Tables[0].Rows.Count == 0) m.upd_thongso(323, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=324").Tables[0].Rows.Count == 0) m.upd_thongso(324, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=325").Tables[0].Rows.Count == 0) m.upd_thongso(325, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=326").Tables[0].Rows.Count == 0) m.upd_thongso(326, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=327").Tables[0].Rows.Count == 0) m.upd_thongso(327, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=328").Tables[0].Rows.Count == 0) m.upd_thongso(328, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=329").Tables[0].Rows.Count == 0) m.upd_thongso(329, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=330").Tables[0].Rows.Count == 0) m.upd_thongso(330, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=331").Tables[0].Rows.Count == 0) m.upd_thongso(331, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=332").Tables[0].Rows.Count == 0) m.upd_thongso(332, "JL", "JL", "JL");
            if (m.get_data("select * from " + user + ".thongso where id=333").Tables[0].Rows.Count == 0) m.upd_thongso(333, "12", "12", "12");
            if (m.get_data("select * from " + user + ".thongso where id=334").Tables[0].Rows.Count == 0) m.upd_thongso(334, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=335").Tables[0].Rows.Count == 0) m.upd_thongso(335, "BN thanh toán chệnh lệch", "BN thanh toán chênh lệch", "BN thanh toán chênh lệch");
            if (m.get_data("select * from " + user + ".thongso where id=336").Tables[0].Rows.Count == 0) m.upd_thongso(336, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=337").Tables[0].Rows.Count == 0) m.upd_thongso(337, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=338").Tables[0].Rows.Count == 0) m.upd_thongso(338, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=339").Tables[0].Rows.Count == 0) m.upd_thongso(339, "1000", "1000", "1000");
            if (m.get_data("select * from " + user + ".thongso where id=340").Tables[0].Rows.Count == 0) m.upd_thongso(340, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=341").Tables[0].Rows.Count == 0) m.upd_thongso(341, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=342").Tables[0].Rows.Count == 0) m.upd_thongso(342, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=343").Tables[0].Rows.Count == 0) m.upd_thongso(343, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=344").Tables[0].Rows.Count == 0) m.upd_thongso(344, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=345").Tables[0].Rows.Count == 0) m.upd_thongso(345, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=346").Tables[0].Rows.Count == 0) m.upd_thongso(346, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=347").Tables[0].Rows.Count == 0) m.upd_thongso(347, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=348").Tables[0].Rows.Count == 0) m.upd_thongso(348, "7000000", "7000000", "7000000");
            if (m.get_data("select * from " + user + ".thongso where id=349").Tables[0].Rows.Count == 0) m.upd_thongso(349, "ES+BS+AS+IS", "ES+BS+AS+IS", "ES+BS+AS+IS");
            if (m.get_data("select * from " + user + ".thongso where id=350").Tables[0].Rows.Count == 0) m.upd_thongso(350, "EL+FL+IL+HL+HN+HS+GL+JL", "EL+FL+IL+HL+HN+HS+GL+JL", "EL+FL+IL+HL+HN+HS+GL+JL");
            if (m.get_data("select * from " + user + ".thongso where id=351").Tables[0].Rows.Count == 0) m.upd_thongso(351, "20000000", "20000000", "20000000");
            if (m.get_data("select * from " + user + ".thongso where id=352").Tables[0].Rows.Count == 0) m.upd_thongso(352, "60", "60", "60");
            if (m.get_data("select * from " + user + ".thongso where id=353").Tables[0].Rows.Count == 0) m.upd_thongso(353, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=354").Tables[0].Rows.Count == 0) m.upd_thongso(354, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=355").Tables[0].Rows.Count == 0) m.upd_thongso(355, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=356").Tables[0].Rows.Count == 0) m.upd_thongso(356, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=357").Tables[0].Rows.Count == 0) m.upd_thongso(357, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=358").Tables[0].Rows.Count == 0) m.upd_thongso(358, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=359").Tables[0].Rows.Count == 0) m.upd_thongso(359, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=360").Tables[0].Rows.Count == 0) m.upd_thongso(360, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=361").Tables[0].Rows.Count == 0) m.upd_thongso(361, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=362").Tables[0].Rows.Count == 0) m.upd_thongso(362, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=363").Tables[0].Rows.Count == 0) m.upd_thongso(363, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=364").Tables[0].Rows.Count == 0) m.upd_thongso(364, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=365").Tables[0].Rows.Count == 0) m.upd_thongso(365, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=366").Tables[0].Rows.Count == 0) m.upd_thongso(366, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=367").Tables[0].Rows.Count == 0) m.upd_thongso(367, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=368").Tables[0].Rows.Count == 0) m.upd_thongso(368, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=369").Tables[0].Rows.Count == 0) m.upd_thongso(369, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=370").Tables[0].Rows.Count == 0) m.upd_thongso(370, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=371").Tables[0].Rows.Count == 0) m.upd_thongso(371, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=372").Tables[0].Rows.Count == 0) m.upd_thongso(372, "trong phẫu thuật", "trong phẫu thuật", "trong phẫu thuật");
            if (m.get_data("select * from " + user + ".thongso where id=373").Tables[0].Rows.Count == 0) m.upd_thongso(373, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=374").Tables[0].Rows.Count == 0) m.upd_thongso(374, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=375").Tables[0].Rows.Count == 0) m.upd_thongso(375, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=376").Tables[0].Rows.Count == 0) m.upd_thongso(376, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=377").Tables[0].Rows.Count == 0) m.upd_thongso(377, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=378").Tables[0].Rows.Count == 0) m.upd_thongso(378, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=379").Tables[0].Rows.Count == 0) m.upd_thongso(379, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=380").Tables[0].Rows.Count == 0) m.upd_thongso(380, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=381").Tables[0].Rows.Count == 0) m.upd_thongso(381, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=382").Tables[0].Rows.Count == 0) m.upd_thongso(382, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=383").Tables[0].Rows.Count == 0) m.upd_thongso(383, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=384").Tables[0].Rows.Count == 0) m.upd_thongso(384, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=385").Tables[0].Rows.Count == 0) m.upd_thongso(385, "1", "1", "1");
            if (m.get_data("select * from " + user + ".thongso where id=386").Tables[0].Rows.Count == 0) m.upd_thongso(386, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=387").Tables[0].Rows.Count == 0) m.upd_thongso(387, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=388").Tables[0].Rows.Count == 0) m.upd_thongso(388, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=389").Tables[0].Rows.Count == 0) m.upd_thongso(389, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=390").Tables[0].Rows.Count == 0) m.upd_thongso(390, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=391").Tables[0].Rows.Count == 0) m.upd_thongso(391, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=392").Tables[0].Rows.Count == 0) m.upd_thongso(392, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=393").Tables[0].Rows.Count == 0) m.upd_thongso(393, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=394").Tables[0].Rows.Count == 0) m.upd_thongso(394, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=395").Tables[0].Rows.Count == 0) m.upd_thongso(395, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=396").Tables[0].Rows.Count == 0) m.upd_thongso(396, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=397").Tables[0].Rows.Count == 0) m.upd_thongso(397, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=398").Tables[0].Rows.Count == 0) m.upd_thongso(398, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=399").Tables[0].Rows.Count == 0) m.upd_thongso(399, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=400").Tables[0].Rows.Count == 0) m.upd_thongso(400, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=401").Tables[0].Rows.Count == 0) m.upd_thongso(401, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=402").Tables[0].Rows.Count == 0) m.upd_thongso(402, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=403").Tables[0].Rows.Count == 0) m.upd_thongso(403, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=404").Tables[0].Rows.Count == 0) m.upd_thongso(404, "0", "0", "0");
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			if (benhvien.SelectedIndex==-1) Application.Exit();
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            if (sTemp != tTemp.Text && tTemp.Text != "")
            {
                if (!System.IO.Directory.Exists(tTemp.Text)) System.IO.Directory.CreateDirectory(tTemp.Text);
                Environment.SetEnvironmentVariable("TEMP", tTemp.Text, EnvironmentVariableTarget.User);
            }
            if (c283.Checked && c283.Enabled)
            {
                if (c284.SelectedIndex == -1)
                {
                    c284.Focus();
                    return;
                }
                /*
                if (c285.SelectedIndex == -1)
                {
                    c285.Focus();
                    return;
                }*/
                if (c286.SelectedIndex == -1)
                {
                    c286.Focus();
                    return;
                }
            }
            if (c264.Checked && c265.Text == "")
            {
                MessageBox.Show("Chọn đường dẫn lưu hình !", LibMedi.AccessData.Msg);
                butImage.Focus();
                return;
            }
			if (c46.Checked && c47.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ chỉ chọn in hoặc danh sách chờ đóng tiền !"),LibMedi.AccessData.Msg);
				c46.Focus();
				return;
			}
			if (c141.Checked)			
			{
				if  (!(c134.Checked ||c53.Checked || c47.Checked || c133.Checked || c46.Checked))
				{
					MessageBox.Show("Khai báo không hợp lệ !",LibMedi.AccessData.Msg);
					c141.Focus();
					return;
				}
				else if (m.get_data("select * from "+user+".v_lydomien").Tables[0].Rows.Count==0 || m.get_data("select * from "+user+".v_dsduyet").Tables[0].Rows.Count==0)
				{
					MessageBox.Show("Chưa khai báo lý do miễn hoặc danh sách ký miễn !",LibMedi.AccessData.Msg);
					c141.Focus();
					return;
				}
			}
			if (!c46.Checked && !c133.Checked) c53.Checked=false;
			if (matt.SelectedIndex==-1)
			{
				if (matt.Enabled) matt.Focus();
				else
				{
					matt.Enabled=true;
					matt.SelectedValue=m.Mabv.Substring(0,3).ToString();
				}
				return;
			}
			if (maqu.SelectedIndex==-1)
			{
				if (maqu.Enabled) maqu.Focus();
				else 
				{
					maqu.Enabled=true;
					maqu.SelectedValue=m.Maqu.ToString();
				}
				return;
			}
			if (benhvien.SelectedIndex==-1)
			{
				if (benhvien.Enabled) benhvien.Focus();
				else
				{
					benhvien.Enabled=true;
					benhvien.SelectedValue=m.Mabv.ToString();
				}
				return;
			}        
			switch (loaidv.SelectedIndex)
			{
				case 0:
					mabv=matt.SelectedValue.ToString();
					tenbv="Bộ Y Tế";
					break;
				case 1:
					mabv=matt.SelectedValue.ToString();
					tenbv="Sở Y Tế";
					break;
				default:
					mabv=benhvien.SelectedValue.ToString();
					tenbv=benhvien.Text;
					break;
			}
            /*
            int itable = m.tableid("", "thongso");
            foreach (DataRow r in m.get_data("select * from " + user + ".thongso order by id").Tables[0].Rows)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".thongso", "id=" + long.Parse(r["id"].ToString())));
            }
            */
            upd_tso("ten");
		}

        private void upd_tso(string fie)
        {
            Cursor = Cursors.WaitCursor;
            if (!bKhaibao || bTenvien)
            {
                m.upd_thongso(1,fie,loaidv.SelectedIndex.ToString());
                m.upd_thongso(2, fie, mabv.ToString().Trim());
                m.upd_thongso(3, fie, tenbv.ToString().Trim());
                m.upd_thongso(24, fie, maqu.SelectedValue.ToString());

                /*foreach (DataRow r in m.get_data("select "+user+".table_ from " + user + ".rec_del").Tables[0].Rows)
                    if (r["table_"].ToString().Substring(0, 5) == "KH_DM") m.execute_data("delete from " + user + "." + r["table_"].ToString() + " where ma>0");
                */
                if (m.Matuyen(benhvien.SelectedValue.ToString()) == "4") //huyen
                {
                    foreach (DataRow r in m.get_data("select * from " + user + ".btdpxa where substr(maphuongxa,6,2)<>'00' and maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0].Rows)
                    {
                        m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_01");
                        m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_02");
                        m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_04");
                    }
                    foreach (DataRow r in m.get_data("select * from " + user + ".btdquan where substr(maqu,4,2)<>'00' and matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0].Rows)
                    {
                        m.upd_danhmuc(int.Parse(r["maqu"].ToString().Substring(3, 2)), "1", r["tenquan"].ToString(), "kh_dm_143");
                    }
                    m.sort_stt();
                    m.sort_danhmuc("kh_dm_143");
                }
                /*
                else
                {
                    foreach (DataRow r in m.get_data("select table_ from " + user + ".rec_upd").Tables[0].Rows)
                        m.upd_danhmuc(1, "1", benhvien.Text, r["table_"].ToString());
                }*/

                ds.Tables[0].Rows[0]["mabv"] = mabv.ToString().Trim();
                ds.Tables[0].Rows[0]["tenbv"] = tenbv.ToString().Trim();
                ds.WriteXml("..//..//..//xml//maincode.xml");
                if (bTenvien) m.execute_data("delete from " + user + ".tenvien_add");
            }
            else if (maqu.Enabled) m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
            if (fie != "ten")
            {
                m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
                m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
            }
            ds.Tables[0].Rows[0]["syte"] = soyte.Text.ToString().Trim();
            ds.Tables[0].Rows[0]["diachi"] = diachi.Text.ToString().Trim();
            ds.Tables[0].Rows[0]["dienthoai"] = dienthoai.Text.ToString().Trim();
            ds.WriteXml("..//..//..//xml//maincode.xml");
            m.upd_thongso(1, fie, loaidv.SelectedIndex.ToString());
            m.upd_thongso(2, fie, mabv.ToString().Trim());
            m.upd_thongso(3, fie, tenbv.ToString().Trim());
            m.upd_thongso(15, fie, (sovaovien.Checked) ? "1" : "0");
            m.upd_thongso(16, fie, (soluutru.Checked) ? "1" : "0");
            m.upd_thongso(4, fie, soyte.Text.ToString().Trim());
            m.upd_thongso(5, fie, diachi.Text.ToString().Trim());
            m.upd_thongso(6, fie, dienthoai.Text.ToString().Trim());
            m.upd_thongso(42, fie, c42.Value.ToString());
            m.upd_thongso(43, fie, c43.Value.ToString());
            m.upd_thongso(48, fie, (c48.Checked) ? "1" : "0");
            m.upd_thongso(54, fie, (c54.Checked) ? "1" : "0");
            m.upd_thongso(100, fie, (c100.Checked) ? "1" : "0");
            m.upd_thongso(102, fie, (c102.Checked) ? "1" : "0");
            m.upd_thongso(106, fie, (c106.Checked) ? "1" : "0");
            m.upd_thongso(0, fie, (c0.Checked) ? "1" : "0");
            m.upd_thongso(104, fie, c104.Value.ToString());
            m.upd_thongso(107, fie, c107.Value.ToString());
            m.upd_thongso(108, fie, (c108.Checked) ? "1" : "0");
            m.upd_thongso(109, fie, (c109.Checked) ? "1" : "0");
            m.upd_thongso(110, fie, (c110.Checked) ? "1" : "0");
            m.upd_thongso(111, fie, (c111.Checked) ? "1" : "0");
            m.upd_thongso(112, fie, (c112.Checked) ? "1" : "0");
            m.upd_thongso(114, fie, (c114.Checked) ? "1" : "0");
            m.upd_thongso(115, fie, c115.Text);
            m.upd_thongso(116, fie, (c116.Checked) ? "1" : "0");
            m.upd_thongso(118, fie, (c118.Checked) ? "1" : "0");
            m.upd_thongso(127, fie, (c127.Checked) ? "1" : "0");
            m.upd_thongso(119, fie, c119.SelectedIndex.ToString());
            m.upd_thongso(120, fie, c120.Value.ToString());
            if (c121.SelectedIndex != -1) m.upd_thongso(121, fie, c121.SelectedValue.ToString());
            if (c122.SelectedIndex != -1) m.upd_thongso(122, fie, c122.SelectedValue.ToString());
            if (c123.SelectedIndex != -1) m.upd_thongso(123, fie, c123.SelectedValue.ToString());
            m.upd_thongso(124, fie, c124.Text.ToString());
            DataRow r1 = m.getrowbyid(dt, "mabv='" + benhvien.SelectedValue.ToString() + "'");
            if (r1 != null) m.upd_thongso(117, fie, (r1["maloai"].ToString().Trim() == "2.912") ? "1" : "0");
            m.upd_thongso(128, fie, (c128.Checked) ? "1" : "0");
            m.upd_thongso(129, fie, (c129.Checked) ? "1" : "0");
            m.upd_thongso(130, fie, (c130.Checked) ? "1" : "0");
            m.upd_thongso(131, fie, (c131.Checked) ? "1" : "0");
            m.upd_thongso(132, fie, (c132.Checked) ? "1" : "0");
            m.upd_thongso(133, fie, (c133.Checked) ? "1" : "0");
            m.upd_thongso(134, fie, (c134.Checked) ? "1" : "0");
            m.upd_thongso(135, fie, (c135.Checked) ? "1" : "0");
            m.upd_thongso(136, fie, hh.Value.ToString().PadLeft(2, '0') + ":" + mm.Value.ToString().PadLeft(2, '0'));
            if (c137.SelectedIndex != -1) m.upd_thongso(137, fie, c137.SelectedValue.ToString());
            m.upd_thongso(138, fie, c138h.Value.ToString().PadLeft(2, '0') + ":" + c138m.Value.ToString().PadLeft(2, '0'));
            m.upd_thongso(139, fie, c139.Value.ToString());
            m.upd_thongso(140, fie, (c140.Checked) ? "1" : "0");
            m.upd_thongso(141, fie, (c141.Checked) ? "1" : "0");
            m.upd_thongso(142, fie, (c142.Checked) ? "1" : "0");
            if (c143.SelectedIndex != -1) m.upd_thongso(143, fie, c143.SelectedValue.ToString());
            m.upd_thongso(144, fie, (c144.Checked) ? "1" : "0");
            m.upd_thongso(145, fie, (c145.Checked) ? "1" : "0");
            m.upd_thongso(146, fie, (c146.Checked) ? "1" : "0");
            if (c147.SelectedIndex != -1) m.upd_thongso(147, fie, (c147.SelectedIndex != -1) ? c147.SelectedValue.ToString() : "0");
            m.upd_thongso(148, fie, (c148.Checked) ? "1" : "0");
            if (c149.SelectedIndex != -1) m.upd_thongso(149, fie, (c149.SelectedIndex != -1) ? c149.SelectedValue.ToString() : "0");
            m.upd_thongso(150, fie, (c150.Checked) ? "1" : "0");
            m.upd_thongso(151, fie, (c151.Checked) ? "1" : "0");
            m.upd_thongso(153, fie, (c153.Checked) ? "1" : "0");
            m.upd_thongso(154, fie, (c154.Checked) ? "1" : "0");
            m.upd_thongso(155, fie, (c155.Checked) ? "1" : "0");
            m.upd_thongso(156, fie, (c156.Checked) ? "1" : "0");
            m.upd_thongso(157, fie, (c157.Checked) ? "1" : "0");
            m.upd_thongso(158, fie, (c158.Checked) ? "1" : "0");
            m.upd_thongso(159, fie, (c159.Checked) ? "1" : "0");
            m.upd_thongso(160, fie, (c160.Checked) ? "1" : "0");
            m.upd_thongso(161, fie, (c161.Checked) ? "1" : "0");
            m.upd_thongso(162, fie, (c162.Checked) ? "1" : "0");
            m.upd_thongso(163, fie, (c163.Checked) ? "1" : "0");
            m.upd_thongso(164, fie, (c164.Checked) ? "1" : "0");
            if (c165.SelectedIndex != -1) m.upd_thongso(165, fie, c165.SelectedValue.ToString());
            if (c166.SelectedIndex != -1) m.upd_thongso(166, fie, c166.SelectedValue.ToString());
            m.upd_thongso(167, fie, (c167.Checked) ? "1" : "0");
            m.upd_thongso(169, fie, (c169.Checked) ? "1" : "0");
            m.upd_thongso(170, fie, (c170.Checked) ? "1" : "0");
            m.upd_thongso(171, fie, c171.Text);
            m.upd_thongso(172, fie, (c172.Checked) ? "1" : "0");
            m.upd_thongso(174, fie, c174.Text);
            m.upd_thongso(175, fie, hhb.Value.ToString().PadLeft(2, '0') + ":" + mmb.Value.ToString().PadLeft(2, '0'));
            if (c176.SelectedIndex != -1) m.upd_thongso(176, fie, c176.SelectedValue.ToString());
            m.upd_thongso(177, fie, (c177.Checked) ? "1" : "0");
            m.upd_thongso(178, fie, (c178.Checked) ? "1" : "0");
            m.upd_thongso(179, fie, (c179.Checked) ? "1" : "0");
            m.upd_thongso(180, fie, (c180.Checked) ? "1" : "0");
            m.upd_thongso(181, fie, (c181.Checked) ? "1" : "0");
            m.upd_thongso(182, fie, (c182.Checked) ? "1" : "0");
            m.upd_thongso(183, fie, (c183.Checked) ? "1" : "0");
            m.upd_thongso(184, fie, (c184.Checked) ? "1" : "0");
            m.upd_thongso(185, fie, hht.Value.ToString().PadLeft(2, '0') + ":" + mmt.Value.ToString().PadLeft(2, '0'));
            if (c186.SelectedIndex != -1) m.upd_thongso(186, fie, c186.SelectedValue.ToString());
            m.upd_thongso(187, fie, hhtn.Value.ToString().PadLeft(2, '0') + ":" + mmtn.Value.ToString().PadLeft(2, '0'));
            m.upd_thongso(188, fie, (c188.Checked) ? "1" : "0");
            m.upd_thongso(189, fie, c189.Value.ToString());
            m.upd_thongso(190, fie, hhl.Value.ToString().PadLeft(2, '0') + ":" + mml.Value.ToString().PadLeft(2, '0'));
            if (c191.SelectedIndex != -1) m.upd_thongso(191, fie, c191.SelectedValue.ToString());
            m.upd_thongso(192, fie, (c192.Checked) ? "1" : "0");
            m.upd_thongso(193, fie, (c193.SelectedIndex != -1 && c153.Checked) ? c193.SelectedValue.ToString() : "0");
            m.upd_thongso(194, fie, (c194.Checked) ? "1" : "0");//binh181108
            m.upd_thongso(197, fie, (c197.Checked) ? "1" : "0");
            m.upd_thongso(198, fie, (c198.Checked) ? "1" : "0");
            m.upd_thongso(199, fie, (c199.Checked) ? "1" : "0");
            m.upd_thongso(200, fie, (c200.Checked) ? "1" : "0");
            m.upd_thongso(201, fie, (c201.Checked) ? "1" : "0");
            m.upd_thongso(202, fie, (c202.Checked) ? "1" : "0");
            m.upd_thongso(203, fie, (c203.Checked) ? "1" : "0");
            m.upd_thongso(204, fie, (c204.Checked) ? "1" : "0");
            m.upd_thongso(205, fie, (c205.Checked) ? "1" : "0");
            m.upd_thongso(213, fie, (c213.Checked) ? "1" : "0");
            m.upd_thongso(214, fie, (c214.Checked) ? "1" : "0");
            m.upd_thongso(215, fie, (c215.Checked) ? "1" : "0");
            m.upd_thongso(216, fie, (c216.Checked) ? "1" : "0");
            m.upd_thongso(217, fie, (c217.Checked) ? "1" : "0");
            m.upd_thongso(218, fie, (c218.Checked) ? "1" : "0");
            m.upd_thongso(219, fie, (c219.Checked) ? "1" : "0");
            if (c219.Checked && c220.SelectedIndex != -1) m.upd_thongso(220, fie, c220.SelectedValue.ToString());
            m.upd_thongso(223, fie, (c223.Checked) ? "1" : "0");
            m.upd_thongso(224, fie, (c224.Checked) ? "1" : "0");
            m.upd_thongso(225, fie, (c225.Checked) ? "1" : "0");
            m.upd_thongso(226, fie, (c226.Checked) ? "1" : "0");
            m.upd_thongso(227, fie, (c227.Checked) ? "1" : "0");
            m.upd_thongso(228, fie, (c228.Checked) ? "1" : "0");
            m.upd_thongso(229, fie, (c228.Checked && c229.SelectedIndex != -1) ? c229.SelectedValue.ToString() : "0");
            m.upd_thongso(230, fie, (c230.Checked) ? "1" : "0");
            m.upd_thongso(231, fie, (c231.Checked) ? "1" : "0");
            m.upd_thongso(232, fie, (c232.Checked) ? "1" : "0");
            m.upd_thongso(233, fie, (c233.Checked) ? "1" : "0");
            m.upd_thongso(234, fie, (c234.SelectedIndex != -1) ? c234.SelectedValue.ToString() : "0");
            m.upd_thongso(235, fie, (c235.Checked) ? "1" : "0");
            m.upd_thongso(236, fie, (c235.Checked && c236.Checked) ? "1" : "0");
            m.upd_thongso(237, fie, (c237.Checked) ? "1" : "0");
            m.upd_thongso(238, fie, (c238.Checked) ? "1" : "0");
            m.upd_thongso(239, fie, (c239.Checked) ? "1" : "0");
            m.upd_thongso(240, fie, (c240.Checked) ? "1" : "0");
            m.upd_thongso(241, fie, (c241.Checked) ? "1" : "0");
            m.upd_thongso(242, fie, (c242.Checked) ? "1" : "0");
            m.upd_thongso(243, fie, (c243.Checked) ? "1" : "0");
            m.upd_thongso(244, fie, (c244.Checked) ? "1" : "0");
            m.upd_thongso(245, fie, (c245.Checked) ? "1" : "0");
            m.upd_thongso(246, fie, (c246.Checked) ? "1" : "0");
            m.upd_thongso(247, fie, (c247.Checked) ? "1" : "0");
            m.upd_thongso(248, fie, (c248.Checked) ? "1" : "0");
            m.upd_thongso(249, fie, (c249.Checked) ? "1" : "0");
            m.upd_thongso(250, fie, (c250.Checked) ? "1" : "0");
            m.upd_thongso(251, fie, (c251.Checked) ? "1" : "0");
            m.upd_thongso(252, fie, (c252.Checked) ? "1" : "0");
            m.upd_thongso(253, fie, (c253.Checked) ? "1" : "0");
            m.upd_thongso(254, fie, (c254.SelectedIndex != -1) ? c254.SelectedValue.ToString() : "0");
            m.upd_thongso(255, fie, (c255.Checked) ? "1" : "0");
            m.upd_thongso(256, fie, (c256.Checked) ? "1" : "0");
            m.upd_thongso(257, fie, c257.Value.ToString());
            m.upd_thongso(258, fie, (c258.Checked) ? "1" : "0");
            m.upd_thongso(259, fie, (c259.Checked) ? "1" : "0");
            m.upd_thongso(260, fie, (c260.Checked) ? "1" : "0");
            m.upd_thongso(261, fie, (c261.Checked) ? "1" : "0");
            m.upd_thongso(262, fie, (c262.Checked) ? "1" : "0");
            if (c262.Checked && c263.SelectedIndex != -1) m.upd_thongso(263, fie, c263.SelectedValue.ToString());
            m.upd_thongso(264, fie, (c264.Checked) ? "1" : "0");
            m.upd_thongso(265, fie, (c264.Checked) ? c265.Text : "");
            m.upd_thongso(266, fie, c266.Value.ToString());
            m.upd_thongso(267, fie, c267.Value.ToString());
            m.upd_thongso(268, fie, c268.Value.ToString());
            m.upd_thongso(269, fie, c269.Value.ToString());
            m.upd_thongso(270, fie, c270.Value.ToString());
            m.upd_thongso(271, fie, (c271.Checked) ? "1" : "0");
            m.upd_thongso(272, fie, c272.Value.ToString());
            m.upd_thongso(273, fie, c273.Value.ToString());
            m.upd_thongso(274, fie, (c274.Checked) ? "1" : "0");
            m.upd_thongso(275, fie, (c275.SelectedIndex != -1) ? c275.Text : "BMP");
            m.upd_thongso(276, fie, (c276.Checked) ? "1" : "0");
            m.upd_thongso(277, fie, (c277.Checked) ? "1" : "0");
            m.upd_thongso(278, fie, (c278.Checked) ? "1" : "0");
            m.upd_thongso(279, fie, (c279.Checked) ? "1" : "0");
            m.upd_thongso(280, fie, (c280.SelectedIndex != -1) ? c280.SelectedValue.ToString() : "0");
            m.upd_thongso(281, fie, (c281.Checked) ? "1" : "0");
            m.upd_thongso(282, fie, (c282.Checked) ? "1" : "0");
            m.upd_thongso(283, fie, (c283.Checked) ? "1" : "0");
            m.upd_thongso(284, fie, (c284.SelectedIndex != -1) ? c284.SelectedValue.ToString() : "0");
            m.upd_thongso(286, fie, (c286.SelectedIndex != -1) ? c286.SelectedValue.ToString() : "0");
            m.upd_thongso(287, fie, (c287.Checked) ? "1" : "0");
            m.upd_thongso(288, fie, (c288.Checked) ? "1" : "0");
            m.upd_thongso(289, fie, (c289.Checked) ? "1" : "0");
            if (c289.Checked && c290.SelectedIndex != -1) m.upd_thongso(290, fie, c290.SelectedValue.ToString());
            m.upd_thongso(291, fie, c291.Text.ToString());
            m.upd_thongso(292, fie, c292.Text.ToString());
            m.upd_thongso(293, fie, c293.Text.ToString());
            m.upd_thongso(294, fie, (c294.Checked) ? "1" : "0");
            m.upd_thongso(295, fie, (c295.Checked) ? "1" : "0");
            m.upd_thongso(296, fie, (c296.Checked) ? "1" : "0");
            m.upd_thongso(297, fie, (c297.Checked) ? "1" : "0");
            m.upd_thongso(298, fie, (c297.Checked && c298.SelectedIndex != -1) ? c298.SelectedValue.ToString() : "0");
            m.upd_thongso(299, fie, (c297.Checked && c299.SelectedIndex != -1) ? c299.SelectedValue.ToString() : "0");
            s_300 = "'";
            if (c297.Checked)
            {
                for (int j = 0; j < c300.Items.Count; j++)
                    if (c300.GetItemChecked(j)) s_300 += dtkp.Rows[j]["makp"].ToString() + "','";
            }
            m.upd_thongso(300, fie, (s_300.Length > 1) ? s_300.Substring(0, s_300.Length - 2) : "");
            m.upd_thongso(301, fie, (c301.Checked) ? "1" : "0");
            m.upd_thongso(302, fie, (c302.Checked) ? "1" : "0");
            if (c303.SelectedIndex != -1) m.upd_thongso(303, fie, c303.SelectedValue.ToString());
            m.upd_thongso(304, fie, (c304.Checked) ? "1" : "0");
            m.upd_thongso(305, fie, c305.Value.ToString());
            m.upd_thongso(306, fie, (c306.Checked) ? "1" : "0");
            m.upd_thongso(307, fie, (c307.SelectedIndex!=-1) ? c307.SelectedValue.ToString() : "0");
            m.upd_thongso(308, fie, (c308.SelectedIndex != -1) ? c308.SelectedValue.ToString() : "0");
            m.upd_thongso(309, fie, (c309.SelectedIndex != -1) ? c309.SelectedValue.ToString() : "0");
            m.upd_thongso(310, fie, (c310.SelectedIndex != -1) ? c310.SelectedValue.ToString() : "0");
            m.upd_thongso(311, fie, (c311.SelectedIndex != -1) ? c311.SelectedValue.ToString() : "0");
            m.upd_thongso(312, fie, (c312.SelectedIndex != -1) ? c312.SelectedValue.ToString() : "0");
            m.upd_thongso(313, fie, (c313.SelectedIndex != -1) ? c313.SelectedValue.ToString() : "0");
            m.upd_thongso(314, fie, (c314.SelectedIndex != -1) ? c314.SelectedValue.ToString() : "0");
            s_315 = "'";
            for (int j = 0; j < c315.Items.Count; j++)
                if (c315.GetItemChecked(j)) s_315 += dtlvp.Rows[j]["makp"].ToString() + "','";
            m.upd_thongso(315, fie, (s_315.Length > 1) ? s_315.Substring(0, s_315.Length - 2) : "");
            s_316 = "";
            for (int j = 0; j < c316.Items.Count; j++)
                if (c316.GetItemChecked(j)) s_316 += dtlvp.Rows[j]["id"].ToString().PadLeft(3,'0') + ",";
            m.upd_thongso(316, fie, (s_316!="") ? s_316.Substring(0, s_316.Length - 1) : "");

            s_317 = "";
            for (int j = 0; j < c317.Items.Count; j++)
                if (c317.GetItemChecked(j)) s_317 += dtlvp.Rows[j]["id"].ToString().PadLeft(3,'0') + ",";
            m.upd_thongso(317, fie, (s_317 != "") ? s_317.Substring(0, s_317.Length - 1) : "");

            s_318 = "";
            for (int j = 0; j < c318.Items.Count; j++)
                if (c318.GetItemChecked(j)) s_318 += dtlvp.Rows[j]["id"].ToString().PadLeft(3,'0') + ",";
            m.upd_thongso(318, fie, (s_318 != "") ? s_318.Substring(0, s_318.Length - 1) : "");

            s_319 = "";
            for (int j = 0; j < c319.Items.Count; j++)
                if (c319.GetItemChecked(j)) s_319 += dtlvp.Rows[j]["id"].ToString().PadLeft(3,'0') + ",";
            m.upd_thongso(319, fie, (s_319 != "") ? s_319.Substring(0, s_319.Length - 1) : "");
            m.upd_thongso(320, fie, (c320.Checked)? "1": "0");
            m.upd_thongso(321, fie, (c321.Checked) ? "1" : "0");
            m.upd_thongso(322, fie, (c322.Checked) ? "1" : "0");
            m.upd_thongso(323, fie, (c323.Checked) ? "1" : "0");
            s_324 = "";
            for (int j = 0; j < c324.Items.Count; j++)
                if (c324.GetItemChecked(j)) s_324 += dtdt.Rows[j]["madoituong"].ToString().PadLeft(2, '0') + ",";
            m.upd_thongso(324, fie, (s_324 != "") ? s_324.Substring(0, s_324.Length - 1) : "");
            m.upd_thongso(325, fie, c325.Value.ToString());
            m.upd_thongso(326, fie, (c326.Checked) ? "1" : "0");
            m.upd_thongso(327, fie, (c327.Checked) ? "1" : "0");
            m.upd_thongso(328, fie, (c328.Checked) ? "1" : "0");
            m.upd_thongso(329, fie, (c329.Checked) ? "1" : "0");
            m.upd_thongso(330, fie, (c330.Checked) ? "1" : "0");
            m.upd_thongso(331, fie, (c331.Checked) ? "1" : "0");
            m.upd_thongso(332, fie, c332.Text);
            m.upd_thongso(333, fie, c333.Value.ToString());
            m.upd_thongso(334, fie, (c334.Checked) ? "1" : "0");
            m.upd_thongso(335, fie, c335.Text);

            foreach (DataRow r in dsc.Tables[0].Rows)
                m.execute_data("update " + user + ".dmcomputer set fmedisoft='" + r["fmedisoft"].ToString() + "',fduoc='" + r["fduoc"].ToString() + "',fvienphi='" + r["fvienphi"].ToString() + "',fxn='" + r["fxn"].ToString() + "',fcls='" + r["fcls"].ToString() + "' where id=" + long.Parse(r["id"].ToString()));

            m.upd_thongso(336, fie, (c336.Checked) ? "1" : "0");
            m.upd_thongso(337, fie, (c337.Checked) ? "1" : "0");
            m.upd_thongso(338, fie, (c338.Checked) ? "1" : "0");
            m.upd_thongso(339, fie, c339.Value.ToString());
            m.upd_thongso(340, fie, (c340.Checked) ? "1" : "0");
            m.upd_thongso(341, fie, c341.Text);
            m.upd_thongso(342, fie, (c342.Checked) ? "1" : "0");
            m.upd_thongso(343, fie, (c343.Checked) ? "1" : "0");
            m.upd_thongso(344, fie, (c344.Checked) ? "1" : "0");
            m.upd_thongso(345, fie, (c345.Checked) ? "1" : "0");
            m.upd_thongso(346, fie, (c346.Checked) ? "1" : "0");
            m.upd_thongso(347, fie, (c347.Checked) ? "1" : "0");
            m.upd_thongso(348, fie, c348.Value.ToString());
            m.upd_thongso(349, fie, c349.Text);
            m.upd_thongso(350, fie, c350.Text);
            m.upd_thongso(351, fie, c351.Value.ToString());
            m.upd_thongso(352, fie, c352.Value.ToString());
            m.upd_thongso(353, fie, (c353.Checked) ? "1" : "0");
            m.upd_thongso(354, fie, (c354.Checked) ? "1" : "0");
            m.upd_thongso(359, fie, (c359.Checked) ? "1" : "0");
            m.upd_thongso(360, fie, (c360.Checked) ? "1" : "0");
            m.upd_thongso(361, fie, (c361.Checked) ? "1" : "0");
            m.upd_thongso(362, fie, (c362.Checked) ? "1" : "0");

            if (c346.Checked)
            {
                int tableid = m.tableid("", "xutrikb");
                m.upd_eve_tables(tableid, i_userid, "upd");
                m.upd_eve_upd_del(tableid,i_userid,"upd",m.fields(m.user+".xutrikb","ma=4"));
                m.upd_xutrikb(4, "Chuyển phòng lưu");
            }

            m.upd_thongso(363, fie, (c363.Checked) ? "1" : "0");
            m.upd_thongso(364, fie, (c363.Checked && c364.SelectedIndex != -1) ? c364.SelectedValue.ToString() : "0");
            m.upd_thongso(365, fie, c365.Value.ToString());
            m.upd_thongso(366, fie, c366.Value.ToString());
            m.upd_thongso(367, fie, c367.Text);
            m.upd_thongso(368, fie, (c368.SelectedIndex != -1) ? c368.SelectedValue.ToString() : "0");
            m.upd_thongso(369, fie, (c369.Checked) ? "1" : "0");
            m.upd_thongso(370, fie, (c370.Checked) ? "1" : "0");
            m.upd_thongso(371, fie, (c371.Checked) ? "1" : "0");
            m.upd_thongso(372, fie, c372.Text);
            m.upd_thongso(373, fie, (c373.Checked) ? "1" : "0");
            m.upd_thongso(374, fie, (c374.Checked) ? "1" : "0");
            m.upd_thongso(375, fie, (c374.Checked && c375.SelectedIndex!=-1) ? c375.SelectedValue.ToString() : "0");

            s_390=s_376 = "";
            if (c374.Checked)
            {
                for (int j = 0; j < c376.Items.Count; j++)
                    if (c376.GetItemChecked(j)) s_376 += dtkhok.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
                for (int j = 0; j < c390.Items.Count; j++)
                    if (c390.GetItemChecked(j)) s_390 += dtkhotua.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            }
            m.upd_thongso(376, fie, s_376);
            m.upd_thongso(377, fie, (c377.Checked) ? "1" : "0");
            m.upd_thongso(378, fie, (c378.Checked) ? "1" : "0");
            m.upd_thongso(379, fie, (c374.Checked && c379.SelectedIndex != -1) ? c379.SelectedValue.ToString() : "0");
            m.upd_thongso(381, fie, (c381.Checked) ? "1" : "0");
            m.upd_thongso(382, fie, (c382.Checked) ? "1" : "0");
            m.upd_thongso(383, fie, (c383.Checked) ? "1" : "0");
            m.upd_thongso(384, fie, (c384.Checked && c359.Checked) ? "1" : "0");
            m.upd_thongso(385, fie, (c385.Checked) ? "1" : "0");
            m.upd_thongso(386, fie, (c386.Checked) ? "1" : "0");
            m.upd_thongso(387, fie, (c387.Checked) ? "1" : "0");
            m.upd_thongso(388, fie, (c388.Checked) ? "1" : "0");
            m.upd_thongso(389, fie, (c374.Checked && c389.SelectedIndex != -1) ? c389.SelectedValue.ToString() : "0");
            m.upd_thongso(390, fie, s_390);
            m.upd_thongso(391, fie, (c391.Checked) ? "1" : "0");
            m.upd_thongso(392, fie, (c392.Checked) ? "1" : "0");
            m.upd_thongso(393, fie, (c393.Checked) ? "1" : "0");
            m.upd_thongso(394, fie, (c394.Checked) ? "1" : "0");
            m.upd_thongso(395, fie, (c395.Checked) ? "1" : "0");
            m.upd_thongso(396, fie, (c396.SelectedIndex != -1) ? c396.SelectedValue.ToString() : "0");
            s_397 = "";
            for (int j = 0; j < c397.Items.Count; j++)
                if (c397.GetItemChecked(j)) s_397 += dt397.Rows[j]["makp"].ToString() + ",";
            m.upd_thongso(397, fie, s_397);
            m.upd_thongso(398, fie, (c398.Checked) ? "1" : "0");
            m.upd_thongso(399, fie, (c399.Checked) ? "1" : "0");
            m.upd_thongso(400, fie, (c400.Checked) ? "1" : "0");
            s_401 = "";
            for (int j = 0; j < c401.Items.Count; j++)
                if (c401.GetItemChecked(j)) s_401 += dtkho.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            m.upd_thongso(402, fie, (c402.SelectedIndex != -1) ? c402.SelectedValue.ToString() : "0");
            m.upd_thongso(403, fie, (c403.Checked) ? "1" : "0");
            m.upd_thongso(404, fie, (c404.Checked) ? "1" : "0");

            dsts.Tables[0].Rows[0]["c14"] = songay.Value.ToString().Trim();
            dsts.Tables[0].Rows[0]["c17"] = (chandoan.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c18"] = (pttt.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c21"] = (ngaylv.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c22"] = (solieu.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c23"] = (khambenh.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c25"] = (noichuyen.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c26"] = (bsKhambenh.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c27"] = (bsNgoaitru.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c28"] = (bsNhanbenh.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c29"] = (bsNhapkhoa.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c30"] = (bsXuatkhoa.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c31"] = (bsXuatvien.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c32"] = (bsPttt.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c33"] = (saoluu33.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c36"] = (c36.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c38"] = (c38.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c44"] = (c44.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c45"] = (c45.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c46"] = (c46.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c47"] = (c47.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c48"] = (c48.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c51"] = (c51.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c52"] = (c52.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c53"] = (c53.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c55"] = (c55.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c57"] = (c57.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c58"] = (c58.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c61"] = (c61.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c134"] = (c134.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c39"] = c39.Text;
            dsts.Tables[0].Rows[0]["c40"] = c40.Text;
            dsts.Tables[0].Rows[0]["c41"] = c41.Text;
            dsts.Tables[0].Rows[0]["c105"] = (c105.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c116"] = (c116.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c125"] = (c125.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c126"] = (c126.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c127"] = (c127.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c140"] = (c140.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c177"] = (c177.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c178"] = (c178.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c195"] = (c195.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c196"] = (c196.SelectedIndex != -1) ? c196.SelectedValue.ToString() : "0";
            dsts.Tables[0].Rows[0]["ngonngu"] = ngonngu.SelectedIndex.ToString();
            int i = 3;
            if (c561.Checked) i = 1;
            else if (c562.Checked) i = 2;
            dsts.Tables[0].Rows[0]["c56"] = i.ToString();
            i = 3;
            if (c591.Checked) i = 1;
            else if (c592.Checked) i = 2;
            dsts.Tables[0].Rows[0]["c59"] = i.ToString();
            i = 4;
            if (c601.Checked) i = 1;
            else if (c602.Checked) i = 2;
            else if (c603.Checked) i = 3;
            dsts.Tables[0].Rows[0]["c60"] = i.ToString();
            dsts.WriteXml("..//..//..//xml//thongso.xml");
            m.writeXml("thongso", "smartcard", (c343.Checked) ? "1" : "0");
            i = 4;
            if (c1131.Checked) i = 1;
            else if (c1132.Checked) i = 2;
            else if (c1133.Checked) i = 3;
            m.upd_thongso(113, fie, i.ToString());
            m.get_dmcomputer();
            m.execute_data("delete from " + user + ".letet");
            foreach (DataRow r in dsletet.Tables[0].Rows)
            {
                if (r["ngay"].ToString().Trim().Length == 5 && r["ngay"].ToString().Trim().IndexOf("/") != -1)
                {
                    if (m.get_data("select * from " + user + ".letet where ngay='" + r["ngay"].ToString() + "'").Tables[0].Rows.Count == 0)
                        m.execute_data("insert into " + user + ".letet(ngay) values ('" + r["ngay"].ToString() + "')");
                }                
            }
            if (bAdmin)
            {
                if (demo.Checked)
                {
                    m.upd_thongso(-3, "ten", m.ngayhienhanh_server.Substring(0, 10));
                    m.upd_thongso(-4, "ten", songaydemo.Value.ToString());
                }
                else m.execute_data("delete from " + user + ".thongso where id in (-3,-4)");
            }
            Cursor = Cursors.Default;
            if (benhvien.Enabled)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu thoát khỏi chương trình sau đó vào lại !"), LibMedi.AccessData.Msg);
                Application.Exit();
            }
            butCancel.Focus();
        }
		private void loaidv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (matt.SelectedIndex==-1) matt.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void soyte_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void benhvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dienthoai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void thunhap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ketxuat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void saoluu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
                benhvien.DataSource = m.get_data("select * from " + user + ".tenvien where substr(mabv,1,3)='" + matt.SelectedValue.ToString() + "'" + " order by mabv").Tables[0];
                maqu.DataSource = m.get_data("select * from " + user + ".btdquan where substr(maqu,4,2)<>'00' and matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
				if (m.Mabv!="") benhvien.SelectedValue=m.Mabv;
				if (!bTenvien) benhvien.Enabled=loaidv.Enabled;
			}
			catch{}
		}

		private void loaidv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (loaidv.SelectedIndex==2) benhvien.Enabled=true;
				else
				{
					benhvien.SelectedIndex=-1;
					benhvien.Enabled=false;
				}
			}
			catch{}
		}

		private void songay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmThongso_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butCancel_Click(sender,e);
            else if (bAdmin)
            {
                if (e.KeyCode == Keys.F5) load_tso("tendef");//load default
                else if (e.KeyCode == Keys.F6)
                {
                    if (MessageBox.Show("Bạn có đồng ý lưu thông số mặc nhiên ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        upd_tso("tendef");//update default 
                        MessageBox.Show("Đã lưu thông số mặc nhiên !", LibMedi.AccessData.Msg);
                    }
                }
                else if (e.KeyCode == Keys.F7) load_tso("tencur"); //load current
                else if (e.KeyCode == Keys.F8)
                {
                    if (MessageBox.Show("Bạn có đồng ý lưu thông số cấu hình ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        upd_tso("tencur"); //upddate current
                        MessageBox.Show("Đã lưu thông số cấu hình !", LibMedi.AccessData.Msg);
                    }
                }
            }
		}

		private void sovaovien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void soluutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void pttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngaylv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void network_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maqu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (maqu.SelectedIndex==-1) maqu.SelectedIndex=0;
				SendKeys.Send("{Tab}");	
			}
		}

		private void khambenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void noichuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsKhambenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNgoaitru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNhanbenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNhapkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsXuatkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsXuatvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsPttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void saoluu33_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c38_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c39_Validated(object sender, System.EventArgs e)
		{
			c39.Text=m.Caps(c39.Text);
		}

		private void c40_Validated(object sender, System.EventArgs e)
		{
			c40.Text=m.Caps(c40.Text);
		}

		private void c41_Validated(object sender, System.EventArgs e)
		{
			c41.Text=m.Caps(c41.Text);		
		}

		private void c42_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c43_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butPath_Click(object sender, System.EventArgs e)
		{
			string sDir=System.Environment.CurrentDirectory.ToString();
			OpenFileDialog of=new OpenFileDialog();
			of.Filter="*.DOC|*.rtf";
			of.ShowDialog();
			c115.Text=of.FileName.ToString();
			System.Environment.CurrentDirectory=sDir;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dttd.TableName;
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 450;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chophep";
			TextCol.HeaderText = "Tiếp đón";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ena_object(bool ena)
		{
			id.Enabled=ena;
			ten.Enabled=ena;
			chophep.Enabled=ena;
			butThem.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				id.Value=decimal.Parse(dataGrid1[i,0].ToString());
				ten.Text=dataGrid1[i,1].ToString();
				chophep.Checked=dataGrid1[i,2].ToString()=="1";
			}
			catch{}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (dttd.Rows.Count==0) id.Value=1;
			else id.Value=decimal.Parse(dttd.Rows[dttd.Rows.Count-1]["id"].ToString())+1;
			ten.Text="";chophep.Checked=false;
			ena_object(true);
			id.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dttd.Rows.Count==0) return;
			ena_object(true);
			id.Enabled=false;
			ten.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (id.Value==0)
			{
				id.Focus();return;
			}
			if (ten.Text=="")
			{
				ten.Focus();return;
			}
			m.upd_dmnoitiepdon(Convert.ToInt16(id.Value),ten.Text,(chophep.Checked)?1:0);
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dttd.Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				if (m.get_data("select * from "+user+".sukien where noitiepdon="+id.Value).Tables[0].Rows.Count>0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Đã sử dụng không được phép hủy !"),LibMedi.AccessData.Msg);
					return;
				}
                m.execute_data("delete from " + user + ".dmnoitiepdon where id=" + id.Value);
				load_grid();
				ref_text();
			}
		}
		private void load_grid()
		{
            dttd = m.get_data("select * from " + user + ".dmnoitiepdon order by id").Tables[0];
			dataGrid1.DataSource=dttd;
		}

		private void id_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chophep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void id_Validated(object sender, System.EventArgs e)
		{
			DataRow r=m.getrowbyid(dttd,"id="+id.Value);
			if (r!=null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số đã tồn tại !"),LibMedi.AccessData.Msg);
				id.Focus();
			}
		}

		private void c46_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c46.Checked) c133.Checked=false;
			c151.Enabled=c46.Checked;
			if (!c46.Checked) c151.Checked=false;
            c287.Enabled = c46.Checked;
            c320.Enabled = c46.Checked;
		}

		private void c133_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c133.Checked) c46.Checked=false;
			c151.Enabled=c133.Checked;
			if (!c133.Checked) c151.Checked=false;
		}

		private void ngonngu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ngonngu.SelectedIndex==-1 && ngonngu.Items.Count>0) ngonngu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void c53_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c53.Checked && c134.Checked) c134.Checked=false;
		}

		private void c134_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c134.Checked && c53.Checked) c53.Checked=false;
		}

		private void c48_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c48.Checked && c135.Checked) c135.Checked=false;
		}

		private void c135_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c48.Checked && c135.Checked) c48.Checked=false;
			hh.Enabled=c135.Checked;
			mm.Enabled=hh.Enabled;
			c137.Enabled=hh.Enabled;
			c165.Enabled=hh.Enabled;
		}

		private void c144_CheckedChanged(object sender, System.EventArgs e)
		{
			c146.Enabled=c144.Checked;
			if (!c144.Checked) c146.Checked=false;
		}

		private void c165_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c165 && c165.SelectedIndex!=-1) load_137();
		}
		private void c170_CheckedChanged(object sender, System.EventArgs e)
		{
			c171.Enabled=c170.Checked;
		}

		private void but174_Click(object sender, System.EventArgs e)
		{
			string sDir=System.Environment.CurrentDirectory.ToString();
			frmThumuc f=new frmThumuc(c174.Text,"Chọn thư mục sao lưu số liệu",0);
			f.ShowDialog();
			if (f.s_dir!="") c174.Text=f.s_dir;
			System.Environment.CurrentDirectory=sDir;
		}

		private void c166_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == c166 && c166.SelectedIndex != -1)
            {
                load_176();
                load_186();
                load_191();
                load_356_358();
                load_402();
                c229.DataSource = m.get_data("select * from " + user + ".d_dlogin where nhomkho=" + int.Parse(c166.SelectedValue.ToString()) + " order by id").Tables[0];
            }
		}

		private void c140_CheckedChanged(object sender, System.EventArgs e)
		{
			c177.Enabled=c140.Checked;
			if (!c140.Checked) c177.Checked=false;
		}

        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = dsletet.Tables[0].TableName;
            ts.AllowSorting = false;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 40;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        private void c153_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == c153)
            {
                hhtn.Enabled = c153.Checked;
                mmtn.Enabled = c153.Checked;
                c193.Enabled = c153.Checked;
            }
        }

        private void but199_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.MDB|*.*";
            of.ShowDialog();
            c199.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
        }

        private void c219_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c219) c220.Enabled = c219.Checked;
        }

        private void sovaovien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == sovaovien)
            {
                c225.Enabled = sovaovien.Checked;
                c241.Enabled = sovaovien.Checked;
            }
        }

        private void c102_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c102 && c102.Checked)
            {
                c216.Checked = false;
                c226.Checked = false;
                c227.Checked = false;
            }
        }

        private void c216_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c216 && c216.Checked)
            {
                c102.Checked = false;
                c226.Checked = false;
                c227.Checked = false;
            }
        }

        private void c226_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c226)
            {
                c239.Enabled = c226.Checked;
                c301.Enabled = c226.Checked;
                if (c226.Checked)
                {
                    c102.Checked = false;
                    c216.Checked = false;
                    c227.Checked = false;
                }
            }
        }

        private void c227_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c227 && c227.Checked)
            {
                c102.Checked = false;
                c216.Checked = false;
                c226.Checked = false;
            }
        }

        private void c228_CheckedChanged(object sender, EventArgs e)
        {
            c229.Enabled = c228.Checked;
        }

        private void c235_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c235)
            {
                c236.Enabled = c235.Checked;
                c247.Enabled = !c235.Checked;
                c278.Enabled = c235.Checked;
                c279.Enabled = c235.Checked;
            }
        }

        private void c110_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c110 && c110.Checked) c242.Checked = false;
        }

        private void c242_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c242 && c242.Checked) c110.Checked = false;
        }

        private void c253_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c253) c254.Enabled = c253.Checked;
        }

        private void c219_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.ActiveControl == c219) c220.Enabled = c219.Checked;
        }

        private void c255_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c255)
            {
                c257.Enabled = c255.Checked || c256.Checked;
            }
        }

        private void c256_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c256)
            {
                c257.Enabled = c255.Checked || c256.Checked;
            }
        }

        private void c248_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c248)
            {
                if (c258.Checked) c258.Checked = false;
                c264.Enabled = c248.Checked;
                c275.Enabled = c248.Checked;
            }
        }

        private void c258_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c258)
            {
                if (c248.Checked) c248.Checked = false;
                c264.Enabled = c258.Checked;
                c275.Enabled = c258.Checked;
            }
        }

        private void c262_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c262) c263.Enabled = c262.Checked;
        }

        private void c264_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c264) butImage.Enabled = c264.Checked;
        }

        private void butImage_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            //frmThumuc f = new frmThumuc(c265.Text, "Chọn thư mục lưu hình", 0);
            //f.ShowDialog();
            //if (f.s_dir != "") c265.Text = f.s_dir;
            SaveFileDialog f = new SaveFileDialog();
            f.CheckPathExists = true;
            f.InitialDirectory = c265.Text;
            f.FileName = "tmp";
            string tmp = "";
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.FileName != "")
                {
                    c265.Text = f.FileName;
                    try
                    {
                        tmp=c265.Text.Substring(0,c265.Text.LastIndexOf("\\")+1);
                    }
                    catch { tmp = "";}
                    c265.Text = tmp;
                    c265.Update();
                }
            }
            f.Dispose();
            System.Environment.CurrentDirectory = sDir;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                /*
                Panel p=new Panel();
                foreach (DataRow r in dssys.Tables[0].Rows)
                {
                    p.Name = r["tag"].ToString();
                    p.Visible = false;
                }
                p.Name=treeView1.SelectedNode.Tag.ToString();
                p.Visible = true;
                 * */
                p01.Visible = false;p02.Visible = false;p03.Visible = false;
                p04.Visible = false;p05.Visible = false;p06.Visible = false;
                p07.Visible = false;p08.Visible = false;p09.Visible = false;
                p11.Visible = false;p10.Visible = false;p12.Visible = false;
                p13.Visible = false;

                switch (treeView1.SelectedNode.Tag.ToString())
                {
                    case "p01": p01.Visible = true; check(p01); break;
                    case "p02": p02.Visible = true; check(p02); break;
                    case "p03": p03.Visible = true; check(p03); break;
                    case "p04": p04.Visible = true; check(p04); break;
                    case "p05": p05.Visible = true; check(p05); break;
                    case "p06": p06.Visible = true; check(p06); f300(); f356_358();break;
                    case "p07": p07.Visible = true; check(p07); f397(); break;
                    case "p08": p08.Visible = true; check(p08); break;
                    case "p09": p09.Visible = true; check(p09); break;
                    case "p10": p10.Visible = true; check(p10); break;
                    case "p11": p11.Visible = true; check(p11); break;
                    case "p12": p12.Visible = true; check(p12); break;
                    case "p13": p13.Visible = true; check(p13); break;
                }
            }
            catch { }
        }

        private void f300()
        {
            for (int i = 0; i < c300.Items.Count; i++)
                if (s_300.IndexOf("'" + dtkp.Rows[i]["makp"].ToString() + "'") != -1) c300.SetItemCheckState(i, CheckState.Checked);
                else c300.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void f397()
        {
            for (int i = 0; i < c397.Items.Count; i++)
                if (s_397.IndexOf(dt397.Rows[i]["makp"].ToString()) != -1) c397.SetItemCheckState(i, CheckState.Checked);
                else c397.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void f356_358()
        {
            for (int i = 0; i < c376.Items.Count; i++)
            {
                if (s_376.IndexOf(dtkhok.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c376.SetItemCheckState(i, CheckState.Checked);
                else c376.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < c390.Items.Count; i++)
            {
                if (s_390.IndexOf(dtkhotua.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c390.SetItemCheckState(i, CheckState.Checked);
                else c390.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < c401.Items.Count; i++)
            {
                if (s_401.IndexOf(dtkho.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c401.SetItemCheckState(i, CheckState.Checked);
                else c401.SetItemCheckState(i, CheckState.Unchecked);
            }
            /*
            for (int i = 0; i < c356.Items.Count; i++)
                if (s_356.IndexOf(dtc.Rows[i]["id"].ToString().PadLeft(3,'0') + "'") != -1) c356.SetItemCheckState(i, CheckState.Checked);
                else c356.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c358.Items.Count; i++)
                if (s_358.IndexOf(dtl.Rows[i]["id"].ToString().PadLeft(3, '0') + "'") != -1) c358.SetItemCheckState(i, CheckState.Checked);
                else c358.SetItemCheckState(i, CheckState.Unchecked);
             * */
        }
        private void FindByText()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }


        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtNodeTextSearch.Text.ToLower().Trim())!=-1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }

        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }

        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }

        private void NodeTextSearch()
        {
            ClearBackColor();
            FindByText();
        }

        private void txtNodeTextSearch_TextChanged(object sender, EventArgs e)
        {
            NodeTextSearch();
        }

        private void txtNodeTextSearch_Enter(object sender, EventArgs e)
        {
            txtNodeTextSearch.Text = "";
        }

        private void txtNodeTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) treeView1.Focus();
        }

        private void butTemp_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            frmThumuc f = new frmThumuc(tTemp.Text, "Chọn thư mục", 0);
            f.ShowDialog();
            if (f.s_dir != "") tTemp.Text = f.s_dir;
            System.Environment.CurrentDirectory = sDir;
        }

        private void c279_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c279) c280.Enabled = c279.Checked;
        }

        private void c283_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c283)
            {
                c284.Enabled = c283.Checked;
                c286.Enabled = c283.Checked;
            }
        }

        private void c47_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c47)
            {
                c283.Enabled = c47.Checked;
                if (!c47.Checked)
                {
                    c284.Enabled = false;
                    c286.Enabled = false;
                }
            }
        }

        private void c289_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c289) c290.Enabled = c289.Checked;
        }

        private void c297_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c297)
            {
                c298.Enabled = c297.Checked;
                c299.Enabled = c297.Checked;
                c300.Enabled = c297.Checked;
            }
        }

        private void c300_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c300.CheckedItems.Count > 0)
            {
                s_300 = "'";
                for (int j = 0; j < c300.Items.Count; j++)
                    if (c300.GetItemChecked(j)) s_300 += dtkp.Rows[j]["makp"].ToString() + "','";
            }
        }

        private void c301_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c301 && c301.Checked) c239.Checked = false;
        }

        private void c239_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c239 && c239.Checked) c301.Checked = false;   
        }

        private void c179_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c179) c395.Enabled=c359.Enabled=c335.Enabled=c302.Enabled = c179.Checked;
        }

        private void c249_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c249 && c249.Checked && !c215.Checked) c215.Checked = true;
        }

        private void c306_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c306) ena_ksk();
        }

        private void ena_ksk()
        {
            c307.Enabled = c306.Checked;
            c308.Enabled = c306.Checked;
            c309.Enabled = c306.Checked;
            c310.Enabled = c306.Checked;
            c311.Enabled = c306.Checked;
            c312.Enabled = c306.Checked;
            c313.Enabled = c306.Checked;
            c314.Enabled = c306.Checked;
            c316.Enabled = c306.Checked;
            c317.Enabled = c306.Checked;
            c318.Enabled = c306.Checked;
            c319.Enabled = c306.Checked;
        }

        private void c322_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c322) ena_taikham();
        }
        private void ena_taikham()
        {
            c323.Enabled = c322.Checked;
            c324.Enabled = c322.Checked;
            c325.Enabled = c322.Checked;
        }

        private void AddGridTableStyle3()
        {
            DataGridColoredTextBoxColumn TextCol1;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = dsc.Tables[0].TableName;
            ts.AllowSorting = false;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "computer";
            TextCol1.HeaderText = "Máy";
            TextCol1.Width = 165;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "fmedisoft";
            TextCol1.HeaderText = "Medisoft";
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "fduoc";
            TextCol1.HeaderText = "Dược";
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "fvienphi";
            TextCol1.HeaderText = "Viện phí";
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "fxn";
            TextCol1.HeaderText = "Xét nghiệm";
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "fcls";
            TextCol1.HeaderText = "CĐHA";
            TextCol1.Width = 80;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);
        }

        public Color MyGetColorRowCol(int row, int col)
        {
            return Color.Black;
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

                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

        private void butFile_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGrid3.CurrentCell.RowNumber;
                string fm = dataGrid3[i, 1].ToString(), fd = dataGrid3[i, 2].ToString(), fv = dataGrid3[i, 3].ToString();
                string fxn = dataGrid3[i, 4].ToString(),fcls=dataGrid3[i,5].ToString();
                foreach (DataRow r in dsc.Tables[0].Rows)
                {
                    r["fmedisoft"] = fm; r["fduoc"] = fd; r["fvienphi"] = fv;
                    r["fxn"] = fxn; r["fcls"] = fcls;
                }
                dsc.AcceptChanges();
            }
            catch { }
        }

        private void but341_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            frmThumuc f = new frmThumuc(c341.Text, "Thư mục chứa MEDISOFT tổng thể", 0);
            f.ShowDialog();
            if (f.s_dir != "") c341.Text = f.s_dir;
            System.Environment.CurrentDirectory = sDir;
        }

        private void c340_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c340) c341.Enabled = but341.Enabled = c340.Checked;
        }

        private void c351_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c351) lbl60.Text = "2.3. Những thẻ bắt buộc còn lại được thanh toán               %,  nhưng không quá :" + c351.Value.ToString();
        }

  
        private void c347_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c347) c360.Enabled = c347.Checked;
        }

        private void c363_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c363) c364.Enabled = c363.Checked;
        }

        private void c246_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c246) c371.Enabled = c246.Checked;
        }

        private void c374_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c374) ena_kho_khoa();
        }
        private void ena_kho_khoa()
        {
            c389.Enabled=c390.Enabled=c375.Enabled = c376.Enabled=c379.Enabled=c374.Checked;
        }

        private void c376_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c376.CheckedItems.Count > 0)
            {
                s_376 = "";
                for (int j = 0; j < c376.Items.Count; j++)
                    if (c376.GetItemChecked(j)) s_376 += dtkhok.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            }
        }

        private void c378_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.ActiveControl == c378 && c378.Checked) c366.Value = 0;
        }

        private void c382_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c382)
            {
                if (c382.Checked && !c182.Checked) c182.Checked = true;
            }
        }

        private void c359_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c359) c384.Enabled = c359.Checked;
        }

        private void c390_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c390.CheckedItems.Count > 0)
            {
                s_390 = "";
                for (int j = 0; j < c390.Items.Count; j++)
                    if (c390.GetItemChecked(j)) s_390 += dtkhotua.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            }
        }

        private void c397_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c397.CheckedItems.Count > 0)
            {
                s_397 = "";
                for (int j = 0; j < c397.Items.Count; j++)
                    if (c397.GetItemChecked(j)) s_397 += dt397.Rows[j]["makp"].ToString() + ",";
            }
        }

        private void c400_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c400) c401.Enabled = c402.Enabled = c400.Checked;
        }

        private void c401_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c401.CheckedItems.Count > 0)
            {
                s_401 = "";
                for (int j = 0; j < c401.Items.Count; j++)
                    if (c401.GetItemChecked(j)) s_401 += dtkho.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            }
        }

	}
}
