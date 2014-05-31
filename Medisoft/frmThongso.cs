using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
//linh
using System.IO.Ports;
namespace Medisoft
{
	public class frmThongso : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private int i_ngonngu = 0;
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
        private DataTable dtkho_ng = new DataTable();
        private DataTable dtnhomvp_pttt = new DataTable();
        private DataTable dtnhomvp_pttt_I05 = new DataTable();
        private DataSet dsc = new DataSet();
        private DataTable dtkhok = new DataTable();
        private DataTable dtkhotua = new DataTable();
		private bool bKhaibao,bTenvien,bAdmin;
        private int i_userid;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.Label label13;
        private string sql, s_makho, user;
        private string s_137 = "", s_176 = "", s_186 = "", s_191 = "", s_196 = "", sTemp = "", s_300 = "", _id,
            mabv = "", tenbv = "", s_315 = "", s_316 = "", s_317 = "", s_318 = "", s_319 = "", s_324 = "", s_356 = "", 
            s_358 = "", s_376 = "", s_390 = "", s_397 = "", s_401 = "", s_402 = "", s_411 = "", s_415 = "", s_416 = "", 
            s_143 = "",s_1136="",s_254= "";
        private DataTable dt397 = new DataTable();
        private DataTable dt411 = new DataTable();
        private DataTable dt415 = new DataTable();
        private DataTable dt416 = new DataTable();
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
		private System.Windows.Forms.ComboBox c1433;
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
        private Panel p01_chung;
        private Panel p02_hanhchinh;
        private GroupBox groupBox1;
        private Panel p03_chuyenmon;
        private Panel p12_khamsuckhoe;
        private Panel p04_masotudong;
        private Panel p05_doituong;
        private Panel p06_duoc;
        private Panel p07_vienphi;
        private Panel p08_CLS;
        private Panel p09_phauthuthuat;
        private Panel p11_bangdien;
        private Panel p10_phonggiuong;
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
        private CheckBox c405;
        private CheckBox c406;
        private CheckBox c407;
        private TextBox c408;
        private CheckBox c409;
        private CheckBox c410;
        private CheckedListBox c411;
        private CheckBox c412;
        private CheckBox c413;
        private CheckBox c414;
        private CheckedListBox c416;
        private CheckedListBox c415;
        private ComboBox c417;
        private ComboBox c418;
        private CheckBox c419;
        private CheckBox c420;
        private CheckBox c421;
        private CheckBox c422;
        private NumericUpDown c423;
        private Label label110;
        private NumericUpDown c424;
        private Label label109;
        private Label label108;
        private Label label107;
        private CheckBox c425;
        private CheckBox c426;
        private NumericUpDown c428;
        private Label label112;
        private NumericUpDown c427;
        private Label label111;
        private NumericUpDown c429;
        private Label label113;
        private CheckBox c430;
        private MaskedTextBox.MaskedTextBox c49;
        private MaskedTextBox.MaskedTextBox c175;
        private Label label114;
        private Label label115;
        private Label label116;
        private Label label117;
        private Label label118;
        private Label label119;
        private MaskedTextBox.MaskedTextBox d51;
        private MaskedTextBox.MaskedTextBox d53;
        private NumericUpDown c431;
        private Label label121;
        private MaskedTextBox.MaskedTextBox ma13;
        private Label label120;
        private Label label122;
        private MaskedTextBox.MaskedTextBox d50;
        private MaskedTextBox.MaskedTextBox d52;
        private CheckBox c432;
        private CheckBox c433;
        private CheckBox c434;
        private DataTable dtl = new DataTable();
        private ComboBox cboStopbit;
        private Label label126;
        private Label label125;
        private Label label222;
        private ComboBox cboBaudrate;
        private ComboBox cboParity;
        private ComboBox cboDatabit;
        private ComboBox cboPort;
        private CheckBox c435;
        private Label label124;
        private Label label127;
        private CheckBox c438;
        private CheckBox c439;
        private CheckBox c440;
        private CheckBox c441;
        private Label label123;
        private MaskedTextBox.MaskedTextBox c442;
        private CheckBox c443;
        private CheckBox c444;
        private CheckBox c1001;
        private CheckBox c1002;
        private CheckBox c1003;
        private CheckBox c1004;
        private CheckBox c1005;
        private CheckBox c1006;
        private NumericUpDown c1008;
        private CheckBox c1007;
        private CheckBox c1009;
        private CheckBox c1010;
        private CheckBox c1011;
        private CheckBox c1012;
        private NumericUpDown c1019;
        private NumericUpDown c1018;
        private NumericUpDown c1017;
        private NumericUpDown c1016;
        private NumericUpDown c1015;
        private NumericUpDown c1014;
        private NumericUpDown c1013;
        private Label label128;
        private CheckedListBox c191;
        private CheckBox c1020;
        private CheckBox c1021;
        private CheckBox c1022;
        private CheckBox c1023;
        private CheckBox c1024;
        private CheckBox c1025;
        private CheckBox c1026;
        private CheckBox c1027;
        private CheckBox c1028;
        private CheckBox c1029;
        private NumericUpDown c1030;
        private Label label129;
        private CheckBox c1031;
        private CheckBox c1032;
        private CheckBox c1033;
        private CheckBox c1034;
        private CheckBox c1035;
        private CheckBox c1036;
        private CheckBox c1037;
        private CheckBox c1038;
        private CheckBox c1039;
        private CheckBox c1040;
        private CheckBox c1041;
        private CheckBox c1043;
        private CheckBox c1042;
        private CheckBox c1044;
        private CheckBox c1045;
        private CheckBox c1046;
        private CheckBox c1047;
        private CheckBox c1048;
        private CheckBox c1049;
        private CheckBox c1050;
        private CheckBox c1051;
        private CheckBox c1052;
        private CheckBox c1053;
        private CheckBox c1054;
        private CheckBox c1055;
        private CheckBox c1056;
        private CheckBox c1057;
        private CheckBox c1058;
        private CheckBox c1059;
        private CheckBox c1060;
        private CheckBox c1061;
        private NumericUpDown c1062;
        private Label label130;
        private Label label131;
        private NumericUpDown c1063;
        private Label label132;
        private CheckedListBox c143;
        private CheckBox c1064;
        private CheckBox c1066;
        private CheckBox c1065;
        private CheckBox c1067;
        private CheckBox c1068;
        private NumericUpDown c1069;
        private Label label133;
        private CheckBox c1070;
        private CheckBox c1071;
        private CheckBox c1072;
        private CheckBox c1073;
        private CheckBox c1074;
        #endregion
        private Panel p14;
        private ComboBox cbokhotc;
        private CheckBox chkkho;
        private ComboBox cbotutruc;
        private CheckBox chktutruc;
        private ComboBox cbophongtc;
        private Label label134;
        private CheckBox c1075;
        private CheckBox c1135;
        private CheckBox c1076;
        private CheckBox c1077;
        private CheckBox c1078;
        private CheckBox c1079;
        private CheckBox c1080;
        private CheckBox c1083;
        private CheckBox c1082;
        private CheckBox c1081;
        private CheckBox c1084;
        private ComboBox c999;
        private Label label135;
        private CheckBox c998;
        private TextBox c1085;
        private Label label136;
        private TextBox mst;
        private Label label137;
        private CheckBox c1086;
        private CheckBox c1136;
        private CheckedListBox chkdmNhom;
        private CheckBox c1087;
        private CheckBox c1089;
        private CheckBox c1090;
        private CheckBox c1091;
        private CheckBox c1092;
        private CheckBox c1093;
        private TextBox txtVienphi;
        private TextBox c1094;
        private Button butDichvu;
        private int i_chinhanh = 0;
        private CheckBox c1095;
        private CheckBox c1096;
        private CheckBox c1097;
        private CheckBox c1501;
        private NumericUpDown numSongaychotoa;
        private Label label138;
        private Label label139;
        private ComboBox c594;
        private Label label140;
        private Label label141;
        private MaskedTextBox.MaskedTextBox txtmatinh;
        private MaskedTextBox.MaskedTextBox txtkituchu;
        private CheckBox c997;
        private CheckBox c445;
        private CheckBox c595;
        private CheckBox c1101;
        private CheckBox c1100;
        private CheckBox c1102;
        private CheckBox c1103;
        private CheckBox c1099;
        private CheckBox c1098;
        private RadioButton rbcaptheotv;
        private RadioButton rbcaptheokhoa;
        private CheckBox c446;
        private CheckBox c395;
        private CheckBox c384;
        private CheckBox c1088;
        private Label label106;
        private Label label105;
        private CheckBox c62;
        private CheckBox c1502;
        private CheckBox C1503;
        private CheckBox c1104;
        private CheckBox c1504;
        private CheckBox c1505;
        private Label label142;
        private TextBox c1138;
        private Label label144;
        private CheckBox c1137;
        private Label label143;
        private TextBox c1141;
        private Label label147;
        private Label label148;
        private NumericUpDown c1140;
        private TextBox c1139;
        private Label label145;
        private Label label146;
        private Label label149;
        private Label label150;
        public MaskedBox.MaskedBox txtNgayBenhNhanThongTuLienTich;
        private ComboBox cboNgayGiaVienPhiThongTuLienTich;
        private Label label151;
        private CheckBox chkApDungThongTuLienTich15042012;
        private CheckBox c1506;
        private CheckBox c1507;
        private CheckedListBox c254;
        private CheckBox c1508;
        private CheckBox c1509;
        private Label label152;
        private NumericUpDown C1000;
        private NumericUpDown c1510;
        private Label label154;
        private Label label153;
        private CheckBox c1105;
        private CheckBox c1511;
        private CheckBox c1512;
        private CheckBox c1513;
        private CheckBox c1600;
        private CheckBox c1260;
        private CheckBox c1261;
        private CheckBox sovaovien;
        private NumericUpDown c352;
        private CheckBox c50034;
        private CheckBox c50114;
        private CheckBox c40091;

        //linh
        private DataSet dsCom = new DataSet();
        //end linh
		public frmThongso(LibMedi.AccessData acc,int userid,bool admin)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; bAdmin = admin;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            i_chinhanh = m.i_Chinhanh_hientai;
            
		}
        public frmThongso(LibMedi.AccessData acc, int userid, bool admin, int _chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_userid = userid; bAdmin = admin;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            i_chinhanh = _chinhanh;
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
            this.c242 = new System.Windows.Forms.CheckBox();
            this.c196 = new System.Windows.Forms.ComboBox();
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
            this.c1433 = new System.Windows.Forms.ComboBox();
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
            this.p01_chung = new System.Windows.Forms.Panel();
            this.c1510 = new System.Windows.Forms.NumericUpDown();
            this.label154 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.C1000 = new System.Windows.Forms.NumericUpDown();
            this.label152 = new System.Windows.Forms.Label();
            this.mst = new System.Windows.Forms.TextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.c999 = new System.Windows.Forms.ComboBox();
            this.label135 = new System.Windows.Forms.Label();
            this.c1135 = new System.Windows.Forms.CheckBox();
            this.c1073 = new System.Windows.Forms.CheckBox();
            this.label131 = new System.Windows.Forms.Label();
            this.c1063 = new System.Windows.Forms.NumericUpDown();
            this.label132 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tTemp = new System.Windows.Forms.TextBox();
            this.lTemp = new System.Windows.Forms.Label();
            this.c998 = new System.Windows.Forms.CheckBox();
            this.p02_hanhchinh = new System.Windows.Forms.Panel();
            this.c1600 = new System.Windows.Forms.CheckBox();
            this.c1091 = new System.Windows.Forms.CheckBox();
            this.c1087 = new System.Windows.Forms.CheckBox();
            this.c1086 = new System.Windows.Forms.CheckBox();
            this.c1085 = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.c1077 = new System.Windows.Forms.CheckBox();
            this.c1058 = new System.Windows.Forms.CheckBox();
            this.c343 = new System.Windows.Forms.CheckBox();
            this.p04_masotudong = new System.Windows.Forms.Panel();
            this.rbcaptheotv = new System.Windows.Forms.RadioButton();
            this.rbcaptheokhoa = new System.Windows.Forms.RadioButton();
            this.c1090 = new System.Windows.Forms.CheckBox();
            this.c1074 = new System.Windows.Forms.CheckBox();
            this.c1066 = new System.Windows.Forms.CheckBox();
            this.c1065 = new System.Windows.Forms.CheckBox();
            this.c1064 = new System.Windows.Forms.CheckBox();
            this.c1060 = new System.Windows.Forms.CheckBox();
            this.c1056 = new System.Windows.Forms.CheckBox();
            this.c1047 = new System.Windows.Forms.CheckBox();
            this.c1029 = new System.Windows.Forms.CheckBox();
            this.c1028 = new System.Windows.Forms.CheckBox();
            this.c1027 = new System.Windows.Forms.CheckBox();
            this.c433 = new System.Windows.Forms.CheckBox();
            this.c346 = new System.Windows.Forms.CheckBox();
            this.c301 = new System.Windows.Forms.CheckBox();
            this.sovaovien = new System.Windows.Forms.CheckBox();
            this.p05_doituong = new System.Windows.Forms.Panel();
            this.c50034 = new System.Windows.Forms.CheckBox();
            this.c352 = new System.Windows.Forms.NumericUpDown();
            this.label149 = new System.Windows.Forms.Label();
            this.c1141 = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.c1140 = new System.Windows.Forms.NumericUpDown();
            this.c1139 = new System.Windows.Forms.TextBox();
            this.label145 = new System.Windows.Forms.Label();
            this.c1138 = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.c1137 = new System.Windows.Forms.CheckBox();
            this.label143 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.c62 = new System.Windows.Forms.CheckBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.txtmatinh = new MaskedTextBox.MaskedTextBox();
            this.txtkituchu = new MaskedTextBox.MaskedTextBox();
            this.c997 = new System.Windows.Forms.CheckBox();
            this.c1080 = new System.Windows.Forms.CheckBox();
            this.c1076 = new System.Windows.Forms.CheckBox();
            this.c1075 = new System.Windows.Forms.CheckBox();
            this.c1053 = new System.Windows.Forms.CheckBox();
            this.c1046 = new System.Windows.Forms.CheckBox();
            this.c1045 = new System.Windows.Forms.CheckBox();
            this.c1038 = new System.Windows.Forms.CheckBox();
            this.c1023 = new System.Windows.Forms.CheckBox();
            this.c1008 = new System.Windows.Forms.NumericUpDown();
            this.c1007 = new System.Windows.Forms.CheckBox();
            this.c49 = new MaskedTextBox.MaskedTextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.c442 = new MaskedTextBox.MaskedTextBox();
            this.c438 = new System.Windows.Forms.CheckBox();
            this.d50 = new MaskedTextBox.MaskedTextBox();
            this.ma13 = new MaskedTextBox.MaskedTextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.d52 = new MaskedTextBox.MaskedTextBox();
            this.c431 = new System.Windows.Forms.NumericUpDown();
            this.label121 = new System.Windows.Forms.Label();
            this.d53 = new MaskedTextBox.MaskedTextBox();
            this.d51 = new MaskedTextBox.MaskedTextBox();
            this.c175 = new MaskedTextBox.MaskedTextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.c428 = new System.Windows.Forms.NumericUpDown();
            this.label112 = new System.Windows.Forms.Label();
            this.c427 = new System.Windows.Forms.NumericUpDown();
            this.label111 = new System.Windows.Forms.Label();
            this.c426 = new System.Windows.Forms.CheckBox();
            this.c365 = new System.Windows.Forms.NumericUpDown();
            this.label95 = new System.Windows.Forms.Label();
            this.c360 = new System.Windows.Forms.CheckBox();
            this.c348 = new System.Windows.Forms.NumericUpDown();
            this.c353 = new System.Windows.Forms.CheckBox();
            this.c351 = new System.Windows.Forms.NumericUpDown();
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
            this.c362 = new System.Windows.Forms.CheckBox();
            this.p03_chuyenmon = new System.Windows.Forms.Panel();
            this.c50114 = new System.Windows.Forms.CheckBox();
            this.c1513 = new System.Windows.Forms.CheckBox();
            this.c1511 = new System.Windows.Forms.CheckBox();
            this.c1509 = new System.Windows.Forms.CheckBox();
            this.c1508 = new System.Windows.Forms.CheckBox();
            this.c1507 = new System.Windows.Forms.CheckBox();
            this.c1506 = new System.Windows.Forms.CheckBox();
            this.c1104 = new System.Windows.Forms.CheckBox();
            this.c1099 = new System.Windows.Forms.CheckBox();
            this.c1098 = new System.Windows.Forms.CheckBox();
            this.c1094 = new System.Windows.Forms.TextBox();
            this.butDichvu = new System.Windows.Forms.Button();
            this.txtVienphi = new System.Windows.Forms.TextBox();
            this.c1093 = new System.Windows.Forms.CheckBox();
            this.c1092 = new System.Windows.Forms.CheckBox();
            this.c1061 = new System.Windows.Forms.CheckBox();
            this.c1051 = new System.Windows.Forms.CheckBox();
            this.c1031 = new System.Windows.Forms.CheckBox();
            this.c1026 = new System.Windows.Forms.CheckBox();
            this.c1021 = new System.Windows.Forms.CheckBox();
            this.c1020 = new System.Windows.Forms.CheckBox();
            this.c1011 = new System.Windows.Forms.CheckBox();
            this.c1010 = new System.Windows.Forms.CheckBox();
            this.c1003 = new System.Windows.Forms.CheckBox();
            this.c1001 = new System.Windows.Forms.CheckBox();
            this.c430 = new System.Windows.Forms.CheckBox();
            this.label110 = new System.Windows.Forms.Label();
            this.c425 = new System.Windows.Forms.CheckBox();
            this.c424 = new System.Windows.Forms.NumericUpDown();
            this.label109 = new System.Windows.Forms.Label();
            this.c423 = new System.Windows.Forms.NumericUpDown();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.c422 = new System.Windows.Forms.CheckBox();
            this.c408 = new System.Windows.Forms.TextBox();
            this.c406 = new System.Windows.Forms.CheckBox();
            this.c405 = new System.Windows.Forms.CheckBox();
            this.c404 = new System.Windows.Forms.CheckBox();
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
            this.p12_khamsuckhoe = new System.Windows.Forms.Panel();
            this.butFile = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.p06_duoc = new System.Windows.Forms.Panel();
            this.c1260 = new System.Windows.Forms.CheckBox();
            this.c1512 = new System.Windows.Forms.CheckBox();
            this.C1503 = new System.Windows.Forms.CheckBox();
            this.c1100 = new System.Windows.Forms.CheckBox();
            this.c445 = new System.Windows.Forms.CheckBox();
            this.numSongaychotoa = new System.Windows.Forms.NumericUpDown();
            this.label138 = new System.Windows.Forms.Label();
            this.c1095 = new System.Windows.Forms.CheckBox();
            this.c1136 = new System.Windows.Forms.CheckBox();
            this.chkdmNhom = new System.Windows.Forms.CheckedListBox();
            this.c1072 = new System.Windows.Forms.CheckBox();
            this.c1069 = new System.Windows.Forms.NumericUpDown();
            this.label133 = new System.Windows.Forms.Label();
            this.c364 = new System.Windows.Forms.ComboBox();
            this.c1002 = new System.Windows.Forms.CheckBox();
            this.c1068 = new System.Windows.Forms.CheckBox();
            this.c1067 = new System.Windows.Forms.CheckBox();
            this.c1062 = new System.Windows.Forms.NumericUpDown();
            this.label130 = new System.Windows.Forms.Label();
            this.c1055 = new System.Windows.Forms.CheckBox();
            this.c1048 = new System.Windows.Forms.CheckBox();
            this.c1030 = new System.Windows.Forms.NumericUpDown();
            this.label129 = new System.Windows.Forms.Label();
            this.c191 = new System.Windows.Forms.CheckedListBox();
            this.c420 = new System.Windows.Forms.CheckBox();
            this.c413 = new System.Windows.Forms.CheckBox();
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
            this.c363 = new System.Windows.Forms.CheckBox();
            this.c342 = new System.Windows.Forms.CheckBox();
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
            this.c334 = new System.Windows.Forms.CheckBox();
            this.p07_vienphi = new System.Windows.Forms.Panel();
            this.c1105 = new System.Windows.Forms.CheckBox();
            this.c284 = new System.Windows.Forms.ComboBox();
            this.label150 = new System.Windows.Forms.Label();
            this.txtNgayBenhNhanThongTuLienTich = new MaskedBox.MaskedBox();
            this.cboNgayGiaVienPhiThongTuLienTich = new System.Windows.Forms.ComboBox();
            this.label151 = new System.Windows.Forms.Label();
            this.chkApDungThongTuLienTich15042012 = new System.Windows.Forms.CheckBox();
            this.c418 = new System.Windows.Forms.ComboBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.c395 = new System.Windows.Forms.CheckBox();
            this.c384 = new System.Windows.Forms.CheckBox();
            this.c1088 = new System.Windows.Forms.CheckBox();
            this.c594 = new System.Windows.Forms.ComboBox();
            this.label139 = new System.Windows.Forms.Label();
            this.c1501 = new System.Windows.Forms.CheckBox();
            this.c1097 = new System.Windows.Forms.CheckBox();
            this.c1096 = new System.Windows.Forms.CheckBox();
            this.c1089 = new System.Windows.Forms.CheckBox();
            this.c1059 = new System.Windows.Forms.CheckBox();
            this.c1050 = new System.Windows.Forms.CheckBox();
            this.c1044 = new System.Windows.Forms.CheckBox();
            this.c1043 = new System.Windows.Forms.CheckBox();
            this.c1042 = new System.Windows.Forms.CheckBox();
            this.c1041 = new System.Windows.Forms.CheckBox();
            this.c1039 = new System.Windows.Forms.CheckBox();
            this.c1037 = new System.Windows.Forms.CheckBox();
            this.c1036 = new System.Windows.Forms.CheckBox();
            this.c1034 = new System.Windows.Forms.CheckBox();
            this.c1024 = new System.Windows.Forms.CheckBox();
            this.c1022 = new System.Windows.Forms.CheckBox();
            this.c1012 = new System.Windows.Forms.CheckBox();
            this.c1009 = new System.Windows.Forms.CheckBox();
            this.c1006 = new System.Windows.Forms.CheckBox();
            this.c1005 = new System.Windows.Forms.CheckBox();
            this.c444 = new System.Windows.Forms.CheckBox();
            this.c443 = new System.Windows.Forms.CheckBox();
            this.c432 = new System.Windows.Forms.CheckBox();
            this.c429 = new System.Windows.Forms.NumericUpDown();
            this.label113 = new System.Windows.Forms.Label();
            this.c421 = new System.Windows.Forms.CheckBox();
            this.c419 = new System.Windows.Forms.CheckBox();
            this.c417 = new System.Windows.Forms.ComboBox();
            this.c416 = new System.Windows.Forms.CheckedListBox();
            this.c415 = new System.Windows.Forms.CheckedListBox();
            this.c414 = new System.Windows.Forms.CheckBox();
            this.c412 = new System.Windows.Forms.CheckBox();
            this.c411 = new System.Windows.Forms.CheckedListBox();
            this.c410 = new System.Windows.Forms.CheckBox();
            this.c409 = new System.Windows.Forms.CheckBox();
            this.c407 = new System.Windows.Forms.CheckBox();
            this.c399 = new System.Windows.Forms.CheckBox();
            this.c398 = new System.Windows.Forms.CheckBox();
            this.c397 = new System.Windows.Forms.CheckedListBox();
            this.label104 = new System.Windows.Forms.Label();
            this.c396 = new System.Windows.Forms.ComboBox();
            this.c392 = new System.Windows.Forms.CheckBox();
            this.c387 = new System.Windows.Forms.CheckBox();
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
            this.c289 = new System.Windows.Forms.CheckBox();
            this.c288 = new System.Windows.Forms.CheckBox();
            this.c287 = new System.Windows.Forms.CheckBox();
            this.c286 = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.c283 = new System.Windows.Forms.CheckBox();
            this.c434 = new System.Windows.Forms.CheckBox();
            this.c403 = new System.Windows.Forms.CheckBox();
            this.label64 = new System.Windows.Forms.Label();
            this.c1502 = new System.Windows.Forms.CheckBox();
            this.c446 = new System.Windows.Forms.CheckBox();
            this.c595 = new System.Windows.Forms.CheckBox();
            this.p10_phonggiuong = new System.Windows.Forms.Panel();
            this.c1103 = new System.Windows.Forms.CheckBox();
            this.c1102 = new System.Windows.Forms.CheckBox();
            this.c1071 = new System.Windows.Forms.CheckBox();
            this.c278 = new System.Windows.Forms.CheckBox();
            this.c1070 = new System.Windows.Forms.CheckBox();
            this.c1057 = new System.Windows.Forms.CheckBox();
            this.c377 = new System.Windows.Forms.CheckBox();
            this.c280 = new System.Windows.Forms.ComboBox();
            this.c279 = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.p08_CLS = new System.Windows.Forms.Panel();
            this.c1261 = new System.Windows.Forms.CheckBox();
            this.c1505 = new System.Windows.Forms.CheckBox();
            this.c1101 = new System.Windows.Forms.CheckBox();
            this.c1084 = new System.Windows.Forms.CheckBox();
            this.c1083 = new System.Windows.Forms.CheckBox();
            this.c1082 = new System.Windows.Forms.CheckBox();
            this.c1081 = new System.Windows.Forms.CheckBox();
            this.c1079 = new System.Windows.Forms.CheckBox();
            this.c1078 = new System.Windows.Forms.CheckBox();
            this.c1052 = new System.Windows.Forms.CheckBox();
            this.c1049 = new System.Windows.Forms.CheckBox();
            this.c1040 = new System.Windows.Forms.CheckBox();
            this.c1035 = new System.Windows.Forms.CheckBox();
            this.c1025 = new System.Windows.Forms.CheckBox();
            this.c440 = new System.Windows.Forms.CheckBox();
            this.c391 = new System.Windows.Forms.CheckBox();
            this.c388 = new System.Windows.Forms.CheckBox();
            this.c339 = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.c338 = new System.Windows.Forms.CheckBox();
            this.c337 = new System.Windows.Forms.CheckBox();
            this.c336 = new System.Windows.Forms.CheckBox();
            this.c328 = new System.Windows.Forms.CheckBox();
            this.c326 = new System.Windows.Forms.CheckBox();
            this.c439 = new System.Windows.Forms.CheckBox();
            this.p09_phauthuthuat = new System.Windows.Forms.Panel();
            this.c254 = new System.Windows.Forms.CheckedListBox();
            this.c1504 = new System.Windows.Forms.CheckBox();
            this.c143 = new System.Windows.Forms.CheckedListBox();
            this.c1033 = new System.Windows.Forms.CheckBox();
            this.c1032 = new System.Windows.Forms.CheckBox();
            this.c1004 = new System.Windows.Forms.CheckBox();
            this.p11_bangdien = new System.Windows.Forms.Panel();
            this.c1054 = new System.Windows.Forms.CheckBox();
            this.c1019 = new System.Windows.Forms.NumericUpDown();
            this.c1018 = new System.Windows.Forms.NumericUpDown();
            this.c1017 = new System.Windows.Forms.NumericUpDown();
            this.c1016 = new System.Windows.Forms.NumericUpDown();
            this.c1015 = new System.Windows.Forms.NumericUpDown();
            this.c1014 = new System.Windows.Forms.NumericUpDown();
            this.c1013 = new System.Windows.Forms.NumericUpDown();
            this.label128 = new System.Windows.Forms.Label();
            this.c441 = new System.Windows.Forms.CheckBox();
            this.cboStopbit = new System.Windows.Forms.ComboBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDatabit = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.c435 = new System.Windows.Forms.CheckBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
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
            this.p14 = new System.Windows.Forms.Panel();
            this.cbokhotc = new System.Windows.Forms.ComboBox();
            this.chkkho = new System.Windows.Forms.CheckBox();
            this.cbotutruc = new System.Windows.Forms.ComboBox();
            this.chktutruc = new System.Windows.Forms.CheckBox();
            this.cbophongtc = new System.Windows.Forms.ComboBox();
            this.label134 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.c40091 = new System.Windows.Forms.CheckBox();
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
            this.p01_chung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1510)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1063)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songaydemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138m)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.p02_hanhchinh.SuspendLayout();
            this.p04_masotudong.SuspendLayout();
            this.p05_doituong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c352)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1140)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1008)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c431)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c428)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c427)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c365)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c348)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c351)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c333)).BeginInit();
            this.p03_chuyenmon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c424)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c423)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c325)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c305)).BeginInit();
            this.p12_khamsuckhoe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.p06_duoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSongaychotoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1069)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1062)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1030)).BeginInit();
            this.p07_vienphi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c429)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c366)).BeginInit();
            this.p10_phonggiuong.SuspendLayout();
            this.p08_CLS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c339)).BeginInit();
            this.p09_phauthuthuat.SuspendLayout();
            this.p11_bangdien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1019)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1018)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1017)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1015)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1014)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1013)).BeginInit();
            this.p13.SuspendLayout();
            this.p14.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "A01. Loại đơn vị :";
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
            this.label2.Location = new System.Drawing.Point(165, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "A02. Tỉnh/T. phố :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label3.Location = new System.Drawing.Point(1, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "A04. Chủ quản :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhvien
            // 
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhvien.DropDownWidth = 300;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(443, 27);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(166, 21);
            this.benhvien.TabIndex = 4;
            this.benhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhvien_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(347, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "A05. Bệnh viện :";
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
            this.label5.Location = new System.Drawing.Point(-9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "A06. Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(443, 50);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(167, 21);
            this.dienthoai.TabIndex = 6;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dienthoai_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(352, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "A07. Điện thoại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maqu.DropDownWidth = 250;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(443, 4);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(167, 21);
            this.maqu.TabIndex = 2;
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(350, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "A03. Quận/Huyện :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c61
            // 
            this.c61.Location = new System.Drawing.Point(5, 87);
            this.c61.Name = "c61";
            this.c61.Size = new System.Drawing.Size(284, 19);
            this.c61.TabIndex = 12;
            this.c61.Text = "F03 + Kiểm tra dị ứng trong đơn thuốc";
            this.c61.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(225, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 23);
            this.label21.TabIndex = 71;
            this.label21.Text = "A08. File thông báo :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c115
            // 
            this.c115.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c115.Enabled = false;
            this.c115.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c115.Location = new System.Drawing.Point(339, 73);
            this.c115.Name = "c115";
            this.c115.Size = new System.Drawing.Size(242, 21);
            this.c115.TabIndex = 72;
            // 
            // butThongbao
            // 
            this.butThongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThongbao.Location = new System.Drawing.Point(585, 72);
            this.butThongbao.Name = "butThongbao";
            this.butThongbao.Size = new System.Drawing.Size(24, 23);
            this.butThongbao.TabIndex = 73;
            this.butThongbao.Text = "...";
            this.butThongbao.Click += new System.EventHandler(this.butPath_Click);
            // 
            // c241
            // 
            this.c241.Location = new System.Drawing.Point(383, 11);
            this.c241.Name = "c241";
            this.c241.Size = new System.Drawing.Size(179, 18);
            this.c241.TabIndex = 203;
            this.c241.Text = "+ Trong nội trú  và Phòng lưu";
            // 
            // c239
            // 
            this.c239.Location = new System.Drawing.Point(383, 30);
            this.c239.Name = "c239";
            this.c239.Size = new System.Drawing.Size(177, 18);
            this.c239.TabIndex = 202;
            this.c239.Text = "+ Trong xuất viện";
            this.c239.CheckedChanged += new System.EventHandler(this.c239_CheckedChanged);
            // 
            // chandoan
            // 
            this.chandoan.Location = new System.Drawing.Point(360, 259);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(257, 20);
            this.chandoan.TabIndex = 88;
            this.chandoan.Text = "C38 - Cho phép nhập theo chẩn đoán bệnh";
            // 
            // c227
            // 
            this.c227.Location = new System.Drawing.Point(383, 66);
            this.c227.Name = "c227";
            this.c227.Size = new System.Drawing.Size(216, 16);
            this.c227.TabIndex = 184;
            this.c227.Text = "D06 + Số lưu trữ = Số vào viện";
            this.c227.CheckedChanged += new System.EventHandler(this.c227_CheckedChanged);
            // 
            // c216
            // 
            this.c216.Location = new System.Drawing.Point(5, 69);
            this.c216.Name = "c216";
            this.c216.Size = new System.Drawing.Size(315, 19);
            this.c216.TabIndex = 201;
            this.c216.Text = "D03 - Số lưu trữ tăng tự động = 3 ký tự ICD+stt+năm 2 số";
            this.c216.CheckedChanged += new System.EventHandler(this.c216_CheckedChanged);
            // 
            // c226
            // 
            this.c226.Location = new System.Drawing.Point(5, 29);
            this.c226.Name = "c226";
            this.c226.Size = new System.Drawing.Size(168, 18);
            this.c226.TabIndex = 183;
            this.c226.Text = "D02 + Số lưu trữ tăng tự động";
            this.c226.CheckedChanged += new System.EventHandler(this.c226_CheckedChanged);
            // 
            // c225
            // 
            this.c225.Location = new System.Drawing.Point(168, 11);
            this.c225.Name = "c225";
            this.c225.Size = new System.Drawing.Size(123, 18);
            this.c225.TabIndex = 117;
            this.c225.Text = "+ Trong nội trú";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(80, 284);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(103, 16);
            this.label34.TabIndex = 115;
            this.label34.Text = "A20. Giờ báo cáo :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c200
            // 
            this.c200.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c200.Location = new System.Drawing.Point(360, 128);
            this.c200.Name = "c200";
            this.c200.Size = new System.Drawing.Size(232, 24);
            this.c200.TabIndex = 111;
            this.c200.Text = "C31 + Số liệu cộng dồn theo kỳ";
            this.c200.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c111
            // 
            this.c111.Location = new System.Drawing.Point(360, 4);
            this.c111.Name = "c111";
            this.c111.Size = new System.Drawing.Size(232, 19);
            this.c111.TabIndex = 109;
            this.c111.Text = "C24 - Nhập số lưu trữ trong nhập viện";
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
            this.label7.Location = new System.Drawing.Point(418, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "A25. Khám nhi phải dưới";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c116
            // 
            this.c116.Location = new System.Drawing.Point(360, 95);
            this.c116.Name = "c116";
            this.c116.Size = new System.Drawing.Size(232, 19);
            this.c116.TabIndex = 99;
            this.c116.Text = "C29 - Thông tin khám thai";
            // 
            // c102
            // 
            this.c102.Location = new System.Drawing.Point(383, 49);
            this.c102.Name = "c102";
            this.c102.Size = new System.Drawing.Size(216, 16);
            this.c102.TabIndex = 78;
            this.c102.Text = "D04 - Số lưu trữ = Mã người bệnh";
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
            this.label19.Location = new System.Drawing.Point(53, 330);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 14);
            this.label19.TabIndex = 97;
            this.label19.Text = "A24. Trẻ dưới ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c38
            // 
            this.c38.Location = new System.Drawing.Point(5, 93);
            this.c38.Name = "c38";
            this.c38.Size = new System.Drawing.Size(345, 21);
            this.c38.TabIndex = 81;
            this.c38.Text = "C06 - Liệt kê bệnh khác trong BC nhiễm,SXH,lây,viêm phổi,ARI";
            // 
            // solieu
            // 
            this.solieu.Location = new System.Drawing.Point(360, 239);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(257, 26);
            this.solieu.TabIndex = 80;
            this.solieu.Text = "C37 + Chỉ xem những mục có số liệu phát sinh";
            // 
            // pttt
            // 
            this.pttt.Location = new System.Drawing.Point(8, 6);
            this.pttt.Name = "pttt";
            this.pttt.Size = new System.Drawing.Size(331, 18);
            this.pttt.TabIndex = 85;
            this.pttt.Text = "I01 + Cho phép nhập theo phương pháp phẫu thuật - thủ thuật";
            // 
            // soluutru
            // 
            this.soluutru.Location = new System.Drawing.Point(360, 169);
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(232, 16);
            this.soluutru.TabIndex = 77;
            this.soluutru.Text = "C33 + Bắt buộc nhập số lưu trữ";
            // 
            // c242
            // 
            this.c242.Location = new System.Drawing.Point(319, 200);
            this.c242.Name = "c242";
            this.c242.Size = new System.Drawing.Size(411, 19);
            this.c242.TabIndex = 178;
            this.c242.Text = "G36 - Thanh toán theo khoa";
            this.c242.CheckedChanged += new System.EventHandler(this.c242_CheckedChanged);
            // 
            // c196
            // 
            this.c196.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c196.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c196.Location = new System.Drawing.Point(146, 1);
            this.c196.Name = "c196";
            this.c196.Size = new System.Drawing.Size(128, 21);
            this.c196.TabIndex = 177;
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
            this.label51.Location = new System.Drawing.Point(585, 27);
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
            this.c179.Location = new System.Drawing.Point(320, 25);
            this.c179.Name = "c179";
            this.c179.Size = new System.Drawing.Size(225, 19);
            this.c179.TabIndex = 162;
            this.c179.Text = "G27 + Thanh toán chênh lệch giá dịch vụ";
            this.c179.CheckedChanged += new System.EventHandler(this.c179_CheckedChanged);
            // 
            // c112
            // 
            this.c112.Location = new System.Drawing.Point(334, 300);
            this.c112.Name = "c112";
            this.c112.Size = new System.Drawing.Size(264, 19);
            this.c112.TabIndex = 13;
            this.c112.Text = "A23+ Nhập thuốc && viện phí theo tên người bệnh";
            this.c112.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c128
            // 
            this.c128.Location = new System.Drawing.Point(661, 59);
            this.c128.Name = "c128";
            this.c128.Size = new System.Drawing.Size(295, 19);
            this.c128.TabIndex = 104;
            this.c128.Text = "G51 - Thanh toán viện phí (Không lấy số liệu dược)";
            this.c128.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c129
            // 
            this.c129.Location = new System.Drawing.Point(319, 234);
            this.c129.Name = "c129";
            this.c129.Size = new System.Drawing.Size(411, 19);
            this.c129.TabIndex = 105;
            this.c129.Text = "G38 - In chi tiết thanh toán theo từng khoa";
            this.c129.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c55
            // 
            this.c55.Location = new System.Drawing.Point(360, 293);
            this.c55.Name = "c55";
            this.c55.Size = new System.Drawing.Size(232, 21);
            this.c55.TabIndex = 1;
            this.c55.Text = "C40 + Nhập dấu sinh tồn trong y lệnh";
            // 
            // c58
            // 
            this.c58.Location = new System.Drawing.Point(6, 246);
            this.c58.Name = "c58";
            this.c58.Size = new System.Drawing.Size(305, 19);
            this.c58.TabIndex = 8;
            this.c58.Text = "G13 - Ràng buộc số biên lai trong khoản từ ... đến";
            // 
            // c177
            // 
            this.c177.Location = new System.Drawing.Point(170, 105);
            this.c177.Name = "c177";
            this.c177.Size = new System.Drawing.Size(163, 19);
            this.c177.TabIndex = 161;
            this.c177.Text = "D08 - Mã BN tự động";
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
            this.c166.Location = new System.Drawing.Point(736, 6);
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
            this.label40.Location = new System.Drawing.Point(613, 8);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(120, 17);
            this.label40.TabIndex = 148;
            this.label40.Text = "Nhóm dược bệnh viện :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c161
            // 
            this.c161.Location = new System.Drawing.Point(319, 289);
            this.c161.Name = "c161";
            this.c161.Size = new System.Drawing.Size(411, 19);
            this.c161.TabIndex = 144;
            this.c161.Text = "G41 - Mặc nhiên in phiếu thanh toán khi xuất khoa";
            // 
            // c158
            // 
            this.c158.Location = new System.Drawing.Point(8, 42);
            this.c158.Name = "c158";
            this.c158.Size = new System.Drawing.Size(331, 19);
            this.c158.TabIndex = 141;
            this.c158.Text = "I03 + Nhập thông tin hồi sức && dụng cụ";
            this.c158.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c157
            // 
            this.c157.Location = new System.Drawing.Point(6, 333);
            this.c157.Name = "c157";
            this.c157.Size = new System.Drawing.Size(305, 19);
            this.c157.TabIndex = 140;
            this.c157.Text = "G18 + Lấy thông tin chỉ định vào viện phí";
            this.c157.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c156
            // 
            this.c156.Location = new System.Drawing.Point(5, 70);
            this.c156.Name = "c156";
            this.c156.Size = new System.Drawing.Size(284, 19);
            this.c156.TabIndex = 139;
            this.c156.Text = "F02 + In đơn thuốc kèm cách dùng";
            this.c156.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c155
            // 
            this.c155.Location = new System.Drawing.Point(6, 263);
            this.c155.Name = "c155";
            this.c155.Size = new System.Drawing.Size(305, 19);
            this.c155.TabIndex = 138;
            this.c155.Text = "G14 - Thu tiền trong ngày (Chiều hôm qua && sáng hôm nay)";
            // 
            // c154
            // 
            this.c154.Location = new System.Drawing.Point(3, 181);
            this.c154.Name = "c154";
            this.c154.Size = new System.Drawing.Size(194, 19);
            this.c154.TabIndex = 137;
            this.c154.Text = "E07 + Kiểm tra hạn sử dụng số thẻ ";
            this.c154.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c151
            // 
            this.c151.Location = new System.Drawing.Point(6, 78);
            this.c151.Name = "c151";
            this.c151.Size = new System.Drawing.Size(315, 22);
            this.c151.TabIndex = 135;
            this.c151.Text = "G05 - Sử dụng chung ký hiệu quyển sổ trong đăng ký";
            this.c151.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c150
            // 
            this.c150.Location = new System.Drawing.Point(6, 298);
            this.c150.Name = "c150";
            this.c150.Size = new System.Drawing.Size(225, 19);
            this.c150.TabIndex = 134;
            this.c150.Text = "G16 + Chuyển chi phí cấp cứu vào nội trú";
            this.c150.CheckedChanged += new System.EventHandler(this.c150_CheckedChanged);
            this.c150.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c149
            // 
            this.c149.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c149.Location = new System.Drawing.Point(396, 2);
            this.c149.Name = "c149";
            this.c149.Size = new System.Drawing.Size(121, 21);
            this.c149.TabIndex = 133;
            this.c149.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(321, 3);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(323, 17);
            this.label39.TabIndex = 132;
            this.label39.Text = "G26.Đối tượng                                          chuyển tính chênh lệch";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.c146.Location = new System.Drawing.Point(8, 24);
            this.c146.Name = "c146";
            this.c146.Size = new System.Drawing.Size(331, 19);
            this.c146.TabIndex = 128;
            this.c146.Text = "I02 - Sửa chi phí phẫu thủ thuật";
            this.c146.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c145
            // 
            this.c145.Location = new System.Drawing.Point(318, 102);
            this.c145.Name = "c145";
            this.c145.Size = new System.Drawing.Size(300, 19);
            this.c145.TabIndex = 127;
            this.c145.Text = "F19 - Chuyển thuốc/vật tư tiêu hao pttt vào dược";
            this.c145.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c144
            // 
            this.c144.Location = new System.Drawing.Point(6, 281);
            this.c144.Name = "c144";
            this.c144.Size = new System.Drawing.Size(305, 19);
            this.c144.TabIndex = 126;
            this.c144.Text = "G15 + Chuyển chi phí phẫu thủ thuật vào viện phí";
            this.c144.CheckedChanged += new System.EventHandler(this.c144_CheckedChanged);
            this.c144.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c1433
            // 
            this.c1433.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c1433.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1433.Location = new System.Drawing.Point(364, 213);
            this.c1433.Name = "c1433";
            this.c1433.Size = new System.Drawing.Size(274, 21);
            this.c1433.TabIndex = 125;
            this.c1433.Visible = false;
            this.c1433.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(326, 72);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(189, 17);
            this.label37.TabIndex = 124;
            this.label37.Text = "I06. Nhóm viện phí phẫu thủ thuật :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c48
            // 
            this.c48.Location = new System.Drawing.Point(5, 217);
            this.c48.Name = "c48";
            this.c48.Size = new System.Drawing.Size(357, 16);
            this.c48.TabIndex = 5;
            this.c48.Text = "F10 - Cấp toa thuốc lấy số liệu trong danh mục thuốc bệnh viện";
            this.c48.CheckedChanged += new System.EventHandler(this.c48_CheckedChanged);
            // 
            // c135
            // 
            this.c135.Location = new System.Drawing.Point(5, 236);
            this.c135.Name = "c135";
            this.c135.Size = new System.Drawing.Size(287, 16);
            this.c135.TabIndex = 111;
            this.c135.Text = "F11 - Cấp toa thuốc lấy số liệu tồn nhà thuốc";
            this.c135.CheckedChanged += new System.EventHandler(this.c135_CheckedChanged);
            this.c135.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c131
            // 
            this.c131.Location = new System.Drawing.Point(3, 218);
            this.c131.Name = "c131";
            this.c131.Size = new System.Drawing.Size(306, 19);
            this.c131.TabIndex = 107;
            this.c131.Text = "E09 Cho phép chỉnh sửa đối tượng ban đầu trong thuốc,vp";
            this.c131.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c140
            // 
            this.c140.Location = new System.Drawing.Point(5, 105);
            this.c140.Name = "c140";
            this.c140.Size = new System.Drawing.Size(163, 19);
            this.c140.TabIndex = 121;
            this.c140.Text = "D07 - Quản lý vân tay";
            this.c140.CheckedChanged += new System.EventHandler(this.c140_CheckedChanged);
            this.c140.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saoluu33_KeyDown);
            // 
            // c132
            // 
            this.c132.Location = new System.Drawing.Point(3, 161);
            this.c132.Name = "c132";
            this.c132.Size = new System.Drawing.Size(228, 19);
            this.c132.TabIndex = 108;
            this.c132.Text = "E06 - Chỉnh sửa đối tượng dịch vụ chi tiết";
            this.c132.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c130
            // 
            this.c130.Location = new System.Drawing.Point(5, 294);
            this.c130.Name = "c130";
            this.c130.Size = new System.Drawing.Size(345, 19);
            this.c130.TabIndex = 106;
            this.c130.Text = "C17 - In y lệnh kèm theo cách dùng";
            // 
            // c126
            // 
            this.c126.Location = new System.Drawing.Point(360, 223);
            this.c126.Name = "c126";
            this.c126.Size = new System.Drawing.Size(232, 19);
            this.c126.TabIndex = 102;
            this.c126.Text = "C36 - Dấu sinh tồn trong đăng ký";
            this.c126.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c125
            // 
            this.c125.Location = new System.Drawing.Point(8, 173);
            this.c125.Name = "c125";
            this.c125.Size = new System.Drawing.Size(226, 19);
            this.c125.TabIndex = 101;
            this.c125.Text = "B10 - Tình trạng hôn nhân";
            this.c125.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c110
            // 
            this.c110.Location = new System.Drawing.Point(319, 183);
            this.c110.Name = "c110";
            this.c110.Size = new System.Drawing.Size(411, 19);
            this.c110.TabIndex = 11;
            this.c110.Text = "G35 - Thanh toán nhiều đợt";
            this.c110.CheckedChanged += new System.EventHandler(this.c110_CheckedChanged);
            this.c110.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c51
            // 
            this.c51.Location = new System.Drawing.Point(5, 88);
            this.c51.Name = "c51";
            this.c51.Size = new System.Drawing.Size(192, 16);
            this.c51.TabIndex = 0;
            this.c51.Text = "D05 - Quản lý mã vạch";
            // 
            // c141
            // 
            this.c141.Location = new System.Drawing.Point(6, 229);
            this.c141.Name = "c141";
            this.c141.Size = new System.Drawing.Size(305, 19);
            this.c141.TabIndex = 122;
            this.c141.Text = "G12 + Nhập lý do miễn trong đăng ký";
            this.c141.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c139
            // 
            this.c139.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c139.Location = new System.Drawing.Point(793, 21);
            this.c139.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
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
            this.label35.Location = new System.Drawing.Point(837, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 16);
            this.label35.TabIndex = 119;
            this.label35.Text = "ngày";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(607, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(344, 17);
            this.label36.TabIndex = 120;
            this.label36.Text = "C48.1 - Kết thúc điều trị ngoại trú sau : ";
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
            this.c134.Location = new System.Drawing.Point(6, 210);
            this.c134.Name = "c134";
            this.c134.Size = new System.Drawing.Size(305, 21);
            this.c134.TabIndex = 110;
            this.c134.Text = "G11 - Lựa chọn tiền khám trong đăng ký";
            this.c134.CheckedChanged += new System.EventHandler(this.c134_CheckedChanged);
            this.c134.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c57
            // 
            this.c57.Location = new System.Drawing.Point(6, 195);
            this.c57.Name = "c57";
            this.c57.Size = new System.Drawing.Size(305, 19);
            this.c57.TabIndex = 10;
            this.c57.Text = "G10 + Chọn ký hiệu biên lai";
            // 
            // c133
            // 
            this.c133.Location = new System.Drawing.Point(6, 58);
            this.c133.Name = "c133";
            this.c133.Size = new System.Drawing.Size(299, 23);
            this.c133.TabIndex = 109;
            this.c133.Text = "G04 - Chuyển tiền khám vào viện phí (không in)";
            this.c133.CheckedChanged += new System.EventHandler(this.c133_CheckedChanged);
            this.c133.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c127
            // 
            this.c127.Location = new System.Drawing.Point(360, 40);
            this.c127.Name = "c127";
            this.c127.Size = new System.Drawing.Size(232, 19);
            this.c127.TabIndex = 103;
            this.c127.Text = "C26 - Lý do khám trong đăng ký";
            this.c127.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c47
            // 
            this.c47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c47.ForeColor = System.Drawing.Color.Black;
            this.c47.Location = new System.Drawing.Point(6, 99);
            this.c47.Name = "c47";
            this.c47.Size = new System.Drawing.Size(241, 17);
            this.c47.TabIndex = 9;
            this.c47.Text = "G06 + Danh sách chờ đóng tiền";
            this.c47.CheckedChanged += new System.EventHandler(this.c47_CheckedChanged);
            // 
            // c46
            // 
            this.c46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c46.Location = new System.Drawing.Point(7, 3);
            this.c46.Name = "c46";
            this.c46.Size = new System.Drawing.Size(241, 16);
            this.c46.TabIndex = 6;
            this.c46.Text = "G01 - In tiền khám bệnh";
            this.c46.CheckedChanged += new System.EventHandler(this.c46_CheckedChanged);
            // 
            // c53
            // 
            this.c53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c53.Location = new System.Drawing.Point(6, 178);
            this.c53.Name = "c53";
            this.c53.Size = new System.Drawing.Size(305, 18);
            this.c53.TabIndex = 7;
            this.c53.Text = "G09 - Sửa đơn giá trong đăng ký";
            this.c53.CheckedChanged += new System.EventHandler(this.c53_CheckedChanged);
            // 
            // c52
            // 
            this.c52.Location = new System.Drawing.Point(360, 277);
            this.c52.Name = "c52";
            this.c52.Size = new System.Drawing.Size(232, 19);
            this.c52.TabIndex = 3;
            this.c52.Text = "C39 - In phiếu điều trị";
            // 
            // c214
            // 
            this.c214.Location = new System.Drawing.Point(6, 350);
            this.c214.Name = "c214";
            this.c214.Size = new System.Drawing.Size(305, 19);
            this.c214.TabIndex = 198;
            this.c214.Text = "G19 - In số vào viện trong phiếu thanh toán ra viện";
            // 
            // c205
            // 
            this.c205.Location = new System.Drawing.Point(3, 103);
            this.c205.Name = "c205";
            this.c205.Size = new System.Drawing.Size(256, 19);
            this.c205.TabIndex = 190;
            this.c205.Text = "E03 + Kiểm tra hạn sử dụng khi sử dụng dịch vụ";
            // 
            // c204
            // 
            this.c204.Location = new System.Drawing.Point(3, 84);
            this.c204.Name = "c204";
            this.c204.Size = new System.Drawing.Size(236, 19);
            this.c204.TabIndex = 189;
            this.c204.Text = "E02 + Kiểm tra số thẻ && mã  người bệnh";
            // 
            // c199
            // 
            this.c199.Location = new System.Drawing.Point(9, 43);
            this.c199.Name = "c199";
            this.c199.Size = new System.Drawing.Size(346, 19);
            this.c199.TabIndex = 183;
            this.c199.Text = "H03 - In chỉ định theo mẫu điền";
            // 
            // c198
            // 
            this.c198.Location = new System.Drawing.Point(5, 121);
            this.c198.Name = "c198";
            this.c198.Size = new System.Drawing.Size(284, 19);
            this.c198.TabIndex = 181;
            this.c198.Text = "F05 + Cho thuốc nhiều ngày trong ngày nghỉ,lễ tết";
            // 
            // c197
            // 
            this.c197.Location = new System.Drawing.Point(360, 187);
            this.c197.Name = "c197";
            this.c197.Size = new System.Drawing.Size(232, 19);
            this.c197.TabIndex = 180;
            this.c197.Text = "C34 + Số lưu trữ không được trùng";
            // 
            // c194
            // 
            this.c194.Location = new System.Drawing.Point(5, 174);
            this.c194.Name = "c194";
            this.c194.Size = new System.Drawing.Size(284, 24);
            this.c194.TabIndex = 179;
            this.c194.Text = "F08 - Tự động cập nhật lại đơn thuốc của bác sỹ";
            // 
            // c193
            // 
            this.c193.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c193.Location = new System.Drawing.Point(292, 333);
            this.c193.Name = "c193";
            this.c193.Size = new System.Drawing.Size(61, 21);
            this.c193.TabIndex = 177;
            // 
            // c192
            // 
            this.c192.Location = new System.Drawing.Point(3, 120);
            this.c192.Name = "c192";
            this.c192.Size = new System.Drawing.Size(256, 24);
            this.c192.TabIndex = 173;
            this.c192.Text = "E04 - Chỉnh sửa đối tượng trong khám bệnh";
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
            this.dataGrid2.Location = new System.Drawing.Point(777, 117);
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
            this.c188.Location = new System.Drawing.Point(661, 22);
            this.c188.Name = "c188";
            this.c188.Size = new System.Drawing.Size(251, 20);
            this.c188.TabIndex = 171;
            this.c188.Text = "G49 - Trẻ sơ sinh thanh toán theo bà mẹ";
            // 
            // mmtn
            // 
            this.mmtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmtn.Location = new System.Drawing.Point(254, 333);
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
            this.label48.Location = new System.Drawing.Point(247, 334);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(8, 16);
            this.label48.TabIndex = 170;
            this.label48.Text = ":";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hhtn
            // 
            this.hhtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hhtn.Location = new System.Drawing.Point(210, 333);
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
            this.c153.Size = new System.Drawing.Size(224, 19);
            this.c153.TabIndex = 166;
            this.c153.Text = "C19 - Phân biệt khám trong/ngoài giờ";
            this.c153.CheckedChanged += new System.EventHandler(this.c153_CheckedChanged);
            // 
            // c184
            // 
            this.c184.Location = new System.Drawing.Point(5, 156);
            this.c184.Name = "c184";
            this.c184.Size = new System.Drawing.Size(284, 24);
            this.c184.TabIndex = 165;
            this.c184.Text = "F07 + Đơn thuốc số lần trong ngày";
            // 
            // c183
            // 
            this.c183.Location = new System.Drawing.Point(6, 440);
            this.c183.Name = "c183";
            this.c183.Size = new System.Drawing.Size(323, 19);
            this.c183.TabIndex = 164;
            this.c183.Text = "G24 - Đưa chi phí điều trị ngoại trú BHYT vào nội trú";
            // 
            // c182
            // 
            this.c182.Location = new System.Drawing.Point(6, 316);
            this.c182.Name = "c182";
            this.c182.Size = new System.Drawing.Size(311, 18);
            this.c182.TabIndex = 163;
            this.c182.Text = "G17 - Chi phí phòng khám chuyển vào chi phí ngoại nội trú";
            // 
            // c181
            // 
            this.c181.Location = new System.Drawing.Point(5, 310);
            this.c181.Name = "c181";
            this.c181.Size = new System.Drawing.Size(345, 24);
            this.c181.TabIndex = 162;
            this.c181.Text = "C18 - Y lệnh kèm theo đơn nhà thuốc";
            // 
            // c180
            // 
            this.c180.Location = new System.Drawing.Point(3, 139);
            this.c180.Name = "c180";
            this.c180.Size = new System.Drawing.Size(239, 24);
            this.c180.TabIndex = 161;
            this.c180.Text = "E05. Chỉnh sửa đối tượng trong nhập khoa";
            // 
            // c169
            // 
            this.c169.Location = new System.Drawing.Point(5, 139);
            this.c169.Name = "c169";
            this.c169.Size = new System.Drawing.Size(284, 20);
            this.c169.TabIndex = 159;
            this.c169.Text = "F06 + Kiểm tra thuốc trùng trong ngày";
            // 
            // c159
            // 
            this.c159.Location = new System.Drawing.Point(8, 60);
            this.c159.Name = "c159";
            this.c159.Size = new System.Drawing.Size(331, 19);
            this.c159.TabIndex = 156;
            this.c159.Text = "I04 + Nhập số phiếu trong phẫu thủ thuật";
            // 
            // c164
            // 
            this.c164.Location = new System.Drawing.Point(5, 104);
            this.c164.Name = "c164";
            this.c164.Size = new System.Drawing.Size(284, 19);
            this.c164.TabIndex = 148;
            this.c164.Text = "F04 - In chỉ định vào đơn thuốc";
            // 
            // c163
            // 
            this.c163.Location = new System.Drawing.Point(3, 67);
            this.c163.Name = "c163";
            this.c163.Size = new System.Drawing.Size(223, 19);
            this.c163.TabIndex = 147;
            this.c163.Text = "E01 - BHYT nhập từ ngày ... đến ngày";
            // 
            // c273
            // 
            this.c273.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c273.Location = new System.Drawing.Point(381, 68);
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
            this.c272.Location = new System.Drawing.Point(335, 68);
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
            this.c271.Location = new System.Drawing.Point(10, 142);
            this.c271.Name = "c271";
            this.c271.Size = new System.Drawing.Size(186, 18);
            this.c271.TabIndex = 261;
            this.c271.Text = "K05 + Đọc hàng chục,trăm,ngàn";
            // 
            // c270
            // 
            this.c270.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c270.Location = new System.Drawing.Point(289, 68);
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
            this.c269.Location = new System.Drawing.Point(243, 68);
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
            this.c268.Location = new System.Drawing.Point(197, 68);
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
            this.c267.Location = new System.Drawing.Point(152, 68);
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
            this.label58.Location = new System.Drawing.Point(13, 70);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(76, 19);
            this.label58.TabIndex = 256;
            this.label58.Text = "K04. Sleep :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c266
            // 
            this.c266.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c266.Location = new System.Drawing.Point(103, 68);
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
            this.c263.Location = new System.Drawing.Point(436, 325);
            this.c263.Name = "c263";
            this.c263.Size = new System.Drawing.Size(191, 21);
            this.c263.TabIndex = 249;
            // 
            // c262
            // 
            this.c262.Location = new System.Drawing.Point(319, 328);
            this.c262.Name = "c262";
            this.c262.Size = new System.Drawing.Size(127, 16);
            this.c262.TabIndex = 250;
            this.c262.Text = "G43 -Thu tiền in thẻ";
            this.c262.CheckedChanged += new System.EventHandler(this.c262_CheckedChanged);
            // 
            // c261
            // 
            this.c261.Location = new System.Drawing.Point(318, 48);
            this.c261.Name = "c261";
            this.c261.Size = new System.Drawing.Size(300, 19);
            this.c261.TabIndex = 248;
            this.c261.Text = "F16 - Hiện tổng số tiền tương đối trong đơn cấp";
            // 
            // c260
            // 
            this.c260.Location = new System.Drawing.Point(318, 66);
            this.c260.Name = "c260";
            this.c260.Size = new System.Drawing.Size(300, 19);
            this.c260.TabIndex = 247;
            this.c260.Text = "F17- Đơn thuốc mua ngoài kiểm tra tồn kho";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(143, 48);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(22, 17);
            this.label56.TabIndex = 244;
            this.label56.Text = "số ";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c257
            // 
            this.c257.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c257.Location = new System.Drawing.Point(103, 45);
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
            this.label55.Location = new System.Drawing.Point(-5, 47);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(107, 17);
            this.label55.TabIndex = 243;
            this.label55.Text = "K03. 1 lần gọi :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c256
            // 
            this.c256.Location = new System.Drawing.Point(9, 24);
            this.c256.Name = "c256";
            this.c256.Size = new System.Drawing.Size(201, 19);
            this.c256.TabIndex = 241;
            this.c256.Text = "K02 - Gọi người bệnh vào khám";
            this.c256.CheckedChanged += new System.EventHandler(this.c256_CheckedChanged);
            // 
            // c255
            // 
            this.c255.Location = new System.Drawing.Point(9, 5);
            this.c255.Name = "c255";
            this.c255.Size = new System.Drawing.Size(243, 19);
            this.c255.TabIndex = 240;
            this.c255.Text = "K01 + Gọi người bệnh vào đăng ký";
            this.c255.CheckedChanged += new System.EventHandler(this.c255_CheckedChanged);
            // 
            // c253
            // 
            this.c253.Location = new System.Drawing.Point(8, 77);
            this.c253.Name = "c253";
            this.c253.Size = new System.Drawing.Size(238, 19);
            this.c253.TabIndex = 238;
            this.c253.Text = "I05 + Thủ thuật nhập theo chỉ định";
            this.c253.CheckedChanged += new System.EventHandler(this.c253_CheckedChanged);
            // 
            // c251
            // 
            this.c251.Location = new System.Drawing.Point(9, 7);
            this.c251.Name = "c251";
            this.c251.Size = new System.Drawing.Size(346, 19);
            this.c251.TabIndex = 236;
            this.c251.Text = "H01 + Gửi tin nhắn sau khi chỉ định";
            // 
            // c249
            // 
            this.c249.Location = new System.Drawing.Point(6, 422);
            this.c249.Name = "c249";
            this.c249.Size = new System.Drawing.Size(315, 19);
            this.c249.TabIndex = 234;
            this.c249.Text = "G23 + Đối tượng nộp tiền phải đóng tiền trước khi vào khám";
            this.c249.CheckedChanged += new System.EventHandler(this.c249_CheckedChanged);
            // 
            // c247
            // 
            this.c247.Location = new System.Drawing.Point(6, 28);
            this.c247.Name = "c247";
            this.c247.Size = new System.Drawing.Size(206, 19);
            this.c247.TabIndex = 232;
            this.c247.Text = "J02 + Bắt buộc nhập giường";
            // 
            // c246
            // 
            this.c246.Location = new System.Drawing.Point(6, 367);
            this.c246.Name = "c246";
            this.c246.Size = new System.Drawing.Size(305, 19);
            this.c246.TabIndex = 231;
            this.c246.Text = "G20 + In đối tượng hao phí trong phiếu thanh toán";
            this.c246.CheckedChanged += new System.EventHandler(this.c246_CheckedChanged);
            // 
            // c244
            // 
            this.c244.Location = new System.Drawing.Point(318, 84);
            this.c244.Name = "c244";
            this.c244.Size = new System.Drawing.Size(300, 19);
            this.c244.TabIndex = 229;
            this.c244.Text = "F18 - Tự động lưu lại cách dùng";
            // 
            // c243
            // 
            this.c243.Location = new System.Drawing.Point(5, 141);
            this.c243.Name = "c243";
            this.c243.Size = new System.Drawing.Size(278, 19);
            this.c243.TabIndex = 228;
            this.c243.Text = "D09 + Số khám phòng lưu tăng tự động";
            // 
            // c240
            // 
            this.c240.Location = new System.Drawing.Point(334, 265);
            this.c240.Name = "c240";
            this.c240.Size = new System.Drawing.Size(335, 19);
            this.c240.TabIndex = 227;
            this.c240.Text = "A19 - Xóa trắng bác sĩ khám bệnh khi nhập người bệnh mới";
            // 
            // c238
            // 
            this.c238.Location = new System.Drawing.Point(661, 96);
            this.c238.Name = "c238";
            this.c238.Size = new System.Drawing.Size(278, 19);
            this.c238.TabIndex = 226;
            this.c238.Text = "G53 + Cộng công khám khi in chi phí khám bệnh";
            // 
            // c237
            // 
            this.c237.Location = new System.Drawing.Point(661, 77);
            this.c237.Name = "c237";
            this.c237.Size = new System.Drawing.Size(345, 19);
            this.c237.TabIndex = 225;
            this.c237.Text = "G52 + In chi phí chuyển dịch vụ vào viện phí khám bệnh";
            // 
            // c236
            // 
            this.c236.Location = new System.Drawing.Point(6, 66);
            this.c236.Name = "c236";
            this.c236.Size = new System.Drawing.Size(160, 19);
            this.c236.TabIndex = 224;
            this.c236.Text = "J04 - Một giường 1 người bệnh";
            // 
            // c235
            // 
            this.c235.Location = new System.Drawing.Point(6, 47);
            this.c235.Name = "c235";
            this.c235.Size = new System.Drawing.Size(206, 19);
            this.c235.TabIndex = 223;
            this.c235.Text = "J03 - Quản lý phòng giường";
            this.c235.Click += new System.EventHandler(this.c235_Click);
            this.c235.CheckedChanged += new System.EventHandler(this.c235_CheckedChanged);
            // 
            // c234
            // 
            this.c234.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c234.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c234.Location = new System.Drawing.Point(179, 7);
            this.c234.Name = "c234";
            this.c234.Size = new System.Drawing.Size(244, 21);
            this.c234.TabIndex = 222;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(-1, 9);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(452, 17);
            this.label54.TabIndex = 221;
            this.label54.Text = "J01. Nhóm viện phí phòng/giường :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c233
            // 
            this.c233.Location = new System.Drawing.Point(318, 30);
            this.c233.Name = "c233";
            this.c233.Size = new System.Drawing.Size(300, 19);
            this.c233.TabIndex = 220;
            this.c233.Text = "F15 - In chữ ký điện tử trong đơn thuốc + chỉ định";
            // 
            // c232
            // 
            this.c232.Location = new System.Drawing.Point(334, 282);
            this.c232.Name = "c232";
            this.c232.Size = new System.Drawing.Size(224, 19);
            this.c232.TabIndex = 219;
            this.c232.Text = "A21 - Kiểm tra khi tạo số liệu mới";
            // 
            // c231
            // 
            this.c231.Location = new System.Drawing.Point(319, 252);
            this.c231.Name = "c231";
            this.c231.Size = new System.Drawing.Size(411, 19);
            this.c231.TabIndex = 218;
            this.c231.Text = "G39 - In chi phí theo loại viện phí";
            // 
            // c230
            // 
            this.c230.Location = new System.Drawing.Point(319, 309);
            this.c230.Name = "c230";
            this.c230.Size = new System.Drawing.Size(272, 19);
            this.c230.TabIndex = 217;
            this.c230.Text = "G42 - Phòng khám cuối in tổng hợp chi phí điều trị";
            this.c230.CheckedChanged += new System.EventHandler(this.c230_CheckedChanged);
            // 
            // c229
            // 
            this.c229.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c229.Location = new System.Drawing.Point(273, 195);
            this.c229.Name = "c229";
            this.c229.Size = new System.Drawing.Size(89, 21);
            this.c229.TabIndex = 216;
            // 
            // c228
            // 
            this.c228.Location = new System.Drawing.Point(5, 196);
            this.c228.Name = "c228";
            this.c228.Size = new System.Drawing.Size(270, 19);
            this.c228.TabIndex = 215;
            this.c228.Text = "F09 - Đơn thuốc dược phát trong khám bệnh trừ tồn kho";
            this.c228.CheckedChanged += new System.EventHandler(this.c228_CheckedChanged);
            // 
            // c224
            // 
            this.c224.Location = new System.Drawing.Point(5, 192);
            this.c224.Name = "c224";
            this.c224.Size = new System.Drawing.Size(254, 17);
            this.c224.TabIndex = 214;
            this.c224.Text = "D11 - Đọc mã vạch";
            // 
            // c223
            // 
            this.c223.Location = new System.Drawing.Point(5, 158);
            this.c223.Name = "c223";
            this.c223.Size = new System.Drawing.Size(254, 18);
            this.c223.TabIndex = 213;
            this.c223.Text = "D10 - Mã BN tự động trong đăng ký khám bệnh";
            this.c223.CheckedChanged += new System.EventHandler(this.c223_CheckedChanged);
            // 
            // c220
            // 
            this.c220.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c220.Location = new System.Drawing.Point(321, 406);
            this.c220.Name = "c220";
            this.c220.Size = new System.Drawing.Size(306, 21);
            this.c220.TabIndex = 212;
            // 
            // c219
            // 
            this.c219.Location = new System.Drawing.Point(320, 388);
            this.c219.Name = "c219";
            this.c219.Size = new System.Drawing.Size(269, 19);
            this.c219.TabIndex = 211;
            this.c219.Text = "G45 - Tái khám chuyển chi phí vào điều trị";
            this.c219.CheckedChanged += new System.EventHandler(this.c219_CheckedChanged_1);
            // 
            // c218
            // 
            this.c218.Location = new System.Drawing.Point(319, 217);
            this.c218.Name = "c218";
            this.c218.Size = new System.Drawing.Size(411, 19);
            this.c218.TabIndex = 210;
            this.c218.Text = "G37 - Thanh toán làm tròn số lượng";
            // 
            // c217
            // 
            this.c217.Location = new System.Drawing.Point(319, 271);
            this.c217.Name = "c217";
            this.c217.Size = new System.Drawing.Size(411, 19);
            this.c217.TabIndex = 209;
            this.c217.Text = "G40 - Chuyển số liệu thanh toán sang viện phí khi xuất khoa";
            this.c217.CheckedChanged += new System.EventHandler(this.c217_CheckedChanged);
            // 
            // c171
            // 
            this.c171.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c171.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c171.Location = new System.Drawing.Point(207, 161);
            this.c171.Name = "c171";
            this.c171.Size = new System.Drawing.Size(393, 21);
            this.c171.TabIndex = 155;
            // 
            // c170
            // 
            this.c170.Location = new System.Drawing.Point(9, 162);
            this.c170.Name = "c170";
            this.c170.Size = new System.Drawing.Size(280, 24);
            this.c170.TabIndex = 154;
            this.c170.Text = "K06. Kết xuất nội dung ra bảng điện";
            this.c170.CheckedChanged += new System.EventHandler(this.c170_CheckedChanged);
            // 
            // c59
            // 
            this.c59.Controls.Add(this.c593);
            this.c59.Controls.Add(this.c592);
            this.c59.Controls.Add(this.c591);
            this.c59.Location = new System.Drawing.Point(5, 207);
            this.c59.Name = "c59";
            this.c59.Size = new System.Drawing.Size(300, 47);
            this.c59.TabIndex = 70;
            this.c59.TabStop = false;
            this.c59.Text = "D12 + Số khám tự động";
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
            this.c56.Location = new System.Drawing.Point(619, 123);
            this.c56.Name = "c56";
            this.c56.Size = new System.Drawing.Size(140, 83);
            this.c56.TabIndex = 71;
            this.c56.TabStop = false;
            this.c56.Text = "F26. Xem sử dụng thuốc";
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
            this.c60.Text = "H11. Xem chỉ định";
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
            this.c113.Location = new System.Drawing.Point(1029, 0);
            this.c113.Name = "c113";
            this.c113.Size = new System.Drawing.Size(296, 57);
            this.c113.TabIndex = 73;
            this.c113.TabStop = false;
            this.c113.Text = "G64. Xem chi phí điều trị";
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
            this.c178.Location = new System.Drawing.Point(3, 200);
            this.c178.Name = "c178";
            this.c178.Size = new System.Drawing.Size(317, 19);
            this.c178.TabIndex = 157;
            this.c178.Text = "E08 - Hiện danh sách khi nhập số thẻ";
            // 
            // c148
            // 
            this.c148.Location = new System.Drawing.Point(360, 206);
            this.c148.Name = "c148";
            this.c148.Size = new System.Drawing.Size(232, 19);
            this.c148.TabIndex = 131;
            this.c148.Text = "C35 - Chọn bác sỹ trong đăng ký";
            this.c148.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c195
            // 
            this.c195.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c195.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c195.Location = new System.Drawing.Point(334, 248);
            this.c195.Name = "c195";
            this.c195.Size = new System.Drawing.Size(233, 19);
            this.c195.TabIndex = 178;
            this.c195.Text = "A17+ Mẫu đăng ký khám bệnh số 1";
            this.c195.Click += new System.EventHandler(this.c195_Click);
            // 
            // c108
            // 
            this.c108.Location = new System.Drawing.Point(5, 260);
            this.c108.Name = "c108";
            this.c108.Size = new System.Drawing.Size(370, 19);
            this.c108.TabIndex = 184;
            this.c108.Text = "D13 + Tự động chuyển thông tin vào điều trị nội trú trong khám bệnh";
            // 
            // c109
            // 
            this.c109.Location = new System.Drawing.Point(5, 277);
            this.c109.Name = "c109";
            this.c109.Size = new System.Drawing.Size(368, 19);
            this.c109.TabIndex = 185;
            this.c109.Text = "D14 + Tự động chuyển thông tin vào điều trị ngoại trú trong khám bệnh";
            // 
            // c201
            // 
            this.c201.Location = new System.Drawing.Point(5, 294);
            this.c201.Name = "c201";
            this.c201.Size = new System.Drawing.Size(368, 19);
            this.c201.TabIndex = 186;
            this.c201.Text = "D15 + Tự động chuyển thông tin vào điều trị nội trú trong ngoại trú";
            // 
            // c203
            // 
            this.c203.Location = new System.Drawing.Point(5, 310);
            this.c203.Name = "c203";
            this.c203.Size = new System.Drawing.Size(368, 19);
            this.c203.TabIndex = 188;
            this.c203.Text = "D16 + Tự động chuyển thông tin vào điều trị ngoại trú trong phòng lưu";
            // 
            // c202
            // 
            this.c202.Location = new System.Drawing.Point(5, 327);
            this.c202.Name = "c202";
            this.c202.Size = new System.Drawing.Size(368, 19);
            this.c202.TabIndex = 187;
            this.c202.Text = "D17 + Tự động chuyển thông tin vào điều trị nội trú trong phòng lưu";
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
            this.label30.Location = new System.Drawing.Point(33, 305);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(149, 21);
            this.label30.TabIndex = 113;
            this.label30.Text = "A22. Ngôn ngữ thể hiện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c118
            // 
            this.c118.Location = new System.Drawing.Point(5, 112);
            this.c118.Name = "c118";
            this.c118.Size = new System.Drawing.Size(345, 19);
            this.c118.TabIndex = 112;
            this.c118.Text = "C07 - Nhập phẫu thuật thủ thuật theo phòng mỗ";
            this.c118.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c114
            // 
            this.c114.Location = new System.Drawing.Point(8, 121);
            this.c114.Name = "c114";
            this.c114.Size = new System.Drawing.Size(312, 18);
            this.c114.TabIndex = 110;
            this.c114.Text = "B07 - Bắt buộc nhập mã bà mẹ";
            // 
            // c107
            // 
            this.c107.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c107.Location = new System.Drawing.Point(163, 194);
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
            this.label9.Location = new System.Drawing.Point(206, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 17);
            this.label9.TabIndex = 108;
            this.label9.Text = "tuổi";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-10, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 16);
            this.label12.TabIndex = 107;
            this.label12.Text = "B11. Tuổi tối đa người bệnh";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c106
            // 
            this.c106.Location = new System.Drawing.Point(360, 22);
            this.c106.Name = "c106";
            this.c106.Size = new System.Drawing.Size(232, 19);
            this.c106.TabIndex = 106;
            this.c106.Text = "C25 - Phân biệt người bệnh mới/cũ";
            // 
            // ngaylv
            // 
            this.ngaylv.Location = new System.Drawing.Point(44, 249);
            this.ngaylv.Name = "ngaylv";
            this.ngaylv.Size = new System.Drawing.Size(308, 16);
            this.ngaylv.TabIndex = 87;
            this.ngaylv.Text = "A16+ Mặc nhiên ngày làm việc bằng ngày hiện hành";
            // 
            // c100
            // 
            this.c100.Location = new System.Drawing.Point(5, 77);
            this.c100.Name = "c100";
            this.c100.Size = new System.Drawing.Size(345, 17);
            this.c100.TabIndex = 95;
            this.c100.Text = "C05 - Thống kê chẩn đoán nguyên nhân vào tình hình bệnh tật";
            // 
            // c54
            // 
            this.c54.Location = new System.Drawing.Point(360, 150);
            this.c54.Name = "c54";
            this.c54.Size = new System.Drawing.Size(232, 18);
            this.c54.TabIndex = 76;
            this.c54.Text = "C32 - Chỉnh sửa ICD10";
            // 
            // c44
            // 
            this.c44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c44.Location = new System.Drawing.Point(8, 139);
            this.c44.Name = "c44";
            this.c44.Size = new System.Drawing.Size(331, 16);
            this.c44.TabIndex = 94;
            this.c44.Text = "B08 - Kiểm tra hợp lệ họ tên và giới tính";
            this.c44.ThreeState = true;
            // 
            // c0
            // 
            this.c0.Location = new System.Drawing.Point(8, 103);
            this.c0.Name = "c0";
            this.c0.Size = new System.Drawing.Size(406, 16);
            this.c0.TabIndex = 83;
            this.c0.Text = "B06 - Cho phép điều chỉnh thông tin hành chính trong nhập/xuất khoa";
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
            this.c36.Size = new System.Drawing.Size(345, 23);
            this.c36.TabIndex = 90;
            this.c36.Text = "C03 - Chỉnh sửa thông tin nhập viện trong nhập khoa";
            // 
            // saoluu33
            // 
            this.saoluu33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saoluu33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.saoluu33.Location = new System.Drawing.Point(44, 229);
            this.saoluu33.Name = "saoluu33";
            this.saoluu33.Size = new System.Drawing.Size(331, 17);
            this.saoluu33.TabIndex = 84;
            this.saoluu33.Text = "A15 - Thông báo sao lưu số liệu trước khi kết thúc chương trình";
            // 
            // noichuyen
            // 
            this.noichuyen.Location = new System.Drawing.Point(5, 56);
            this.noichuyen.Name = "noichuyen";
            this.noichuyen.Size = new System.Drawing.Size(345, 22);
            this.noichuyen.TabIndex = 89;
            this.noichuyen.Text = "C04 - Cho phép điều chỉnh nơi chuyển trong nhập khoa";
            // 
            // khambenh
            // 
            this.khambenh.Location = new System.Drawing.Point(5, 5);
            this.khambenh.Name = "khambenh";
            this.khambenh.Size = new System.Drawing.Size(303, 20);
            this.khambenh.TabIndex = 79;
            this.khambenh.Text = "C01 - Bắt buộc phải nhập chẩn đoán trong khám bệnh";
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
            this.label10.Location = new System.Drawing.Point(30, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(303, 17);
            this.label10.TabIndex = 92;
            this.label10.Text = "A13. Khoảng cách ngày làm việc so với ngày hệ thống :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label50.Location = new System.Drawing.Point(24, 209);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(344, 17);
            this.label50.TabIndex = 170;
            this.label50.Text = "A14. Số chương trình Medisoft kích hoạt tối đa trên mỗi máy là :";
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
            this.c160.Size = new System.Drawing.Size(345, 19);
            this.c160.TabIndex = 143;
            this.c160.Text = "C08 + Chẩn đoán chính phải có trong ICD10";
            // 
            // c45
            // 
            this.c45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c45.Location = new System.Drawing.Point(44, 267);
            this.c45.Name = "c45";
            this.c45.Size = new System.Drawing.Size(162, 15);
            this.c45.TabIndex = 4;
            this.c45.Text = "A18 - Xem trước khi in";
            // 
            // c142
            // 
            this.c142.Location = new System.Drawing.Point(8, 156);
            this.c142.Name = "c142";
            this.c142.Size = new System.Drawing.Size(312, 19);
            this.c142.TabIndex = 123;
            this.c142.Text = "B09 + Nhập điện thoại người bệnh trong đăng ký";
            this.c142.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c43_KeyDown);
            // 
            // c105
            // 
            this.c105.Location = new System.Drawing.Point(5, 169);
            this.c105.Name = "c105";
            this.c105.Size = new System.Drawing.Size(345, 16);
            this.c105.TabIndex = 2;
            this.c105.Text = "C10 + Hiện danh sách đăng ký trong khám bệnh";
            // 
            // c215
            // 
            this.c215.Location = new System.Drawing.Point(5, 22);
            this.c215.Name = "c215";
            this.c215.Size = new System.Drawing.Size(345, 19);
            this.c215.TabIndex = 199;
            this.c215.Text = "C02 + Thông tin phòng khám phải được chỉ định";
            // 
            // c213
            // 
            this.c213.Location = new System.Drawing.Point(5, 205);
            this.c213.Name = "c213";
            this.c213.Size = new System.Drawing.Size(345, 19);
            this.c213.TabIndex = 197;
            this.c213.Text = "C12 + Phòng mỗ sử dụng thuốc && dịch vụ không cần nhập khoa";
            // 
            // c167
            // 
            this.c167.Location = new System.Drawing.Point(360, 111);
            this.c167.Name = "c167";
            this.c167.Size = new System.Drawing.Size(232, 22);
            this.c167.TabIndex = 160;
            this.c167.Text = "C30 - In số vào viện trong y lệnh";
            // 
            // c162
            // 
            this.c162.Location = new System.Drawing.Point(360, 76);
            this.c162.Name = "c162";
            this.c162.Size = new System.Drawing.Size(232, 19);
            this.c162.TabIndex = 158;
            this.c162.Text = "C28 + Xem các lần tiếp đón";
            // 
            // c172
            // 
            this.c172.Location = new System.Drawing.Point(608, 97);
            this.c172.Name = "c172";
            this.c172.Size = new System.Drawing.Size(364, 20);
            this.c172.TabIndex = 154;
            this.c172.Text = "C50 - Nhập nơi giới thiệu trong đăng ký";
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
            this.c275.Location = new System.Drawing.Point(191, 60);
            this.c275.Name = "c275";
            this.c275.Size = new System.Drawing.Size(102, 21);
            this.c275.TabIndex = 264;
            // 
            // c264
            // 
            this.c264.Location = new System.Drawing.Point(8, 61);
            this.c264.Name = "c264";
            this.c264.Size = new System.Drawing.Size(223, 19);
            this.c264.TabIndex = 254;
            this.c264.Text = "B04. Lưu ảnh BN theo định dạng";
            this.c264.CheckedChanged += new System.EventHandler(this.c264_CheckedChanged);
            // 
            // butImage
            // 
            this.butImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImage.Location = new System.Drawing.Point(582, 82);
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
            this.c265.Location = new System.Drawing.Point(191, 82);
            this.c265.Name = "c265";
            this.c265.Size = new System.Drawing.Size(390, 21);
            this.c265.TabIndex = 252;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(17, 79);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(168, 23);
            this.label57.TabIndex = 251;
            this.label57.Text = "B05. Đường dẫn sao lưu số liệu :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c259
            // 
            this.c259.Location = new System.Drawing.Point(5, 257);
            this.c259.Name = "c259";
            this.c259.Size = new System.Drawing.Size(345, 19);
            this.c259.TabIndex = 246;
            this.c259.Text = "C15 + Nhập triệu chứng lâm sàng ban đầu";
            // 
            // c258
            // 
            this.c258.Location = new System.Drawing.Point(8, 21);
            this.c258.Name = "c258";
            this.c258.Size = new System.Drawing.Size(201, 19);
            this.c258.TabIndex = 245;
            this.c258.Text = "B02 - Chọn hình người bệnh";
            this.c258.CheckedChanged += new System.EventHandler(this.c258_CheckedChanged);
            // 
            // c252
            // 
            this.c252.Location = new System.Drawing.Point(5, 186);
            this.c252.Name = "c252";
            this.c252.Size = new System.Drawing.Size(345, 19);
            this.c252.TabIndex = 237;
            this.c252.Text = "C11 - Dấu sinh tồn trong khám bệnh && phòng lưu";
            // 
            // c250
            // 
            this.c250.Location = new System.Drawing.Point(5, 241);
            this.c250.Name = "c250";
            this.c250.Size = new System.Drawing.Size(345, 19);
            this.c250.TabIndex = 235;
            this.c250.Text = "C14 - Chuyển phòng khám tự động chuyển vào danh sách chờ";
            // 
            // c248
            // 
            this.c248.Location = new System.Drawing.Point(8, 4);
            this.c248.Name = "c248";
            this.c248.Size = new System.Drawing.Size(215, 19);
            this.c248.TabIndex = 233;
            this.c248.Text = "B01 - Quản lý hình người bệnh";
            this.c248.CheckedChanged += new System.EventHandler(this.c248_CheckedChanged);
            // 
            // c245
            // 
            this.c245.Location = new System.Drawing.Point(5, 150);
            this.c245.Name = "c245";
            this.c245.Size = new System.Drawing.Size(345, 19);
            this.c245.TabIndex = 230;
            this.c245.Text = "C09 + Chuyển khám bắt buộc nhập chẩn đoán";
            // 
            // c276
            // 
            this.c276.Location = new System.Drawing.Point(5, 276);
            this.c276.Name = "c276";
            this.c276.Size = new System.Drawing.Size(345, 18);
            this.c276.TabIndex = 263;
            this.c276.Text = "C16 - Đơn thuốc nhập theo sáng, trưa , chiều";
            // 
            // c274
            // 
            this.c274.Location = new System.Drawing.Point(360, 58);
            this.c274.Name = "c274";
            this.c274.Size = new System.Drawing.Size(232, 18);
            this.c274.TabIndex = 262;
            this.c274.Text = "C27 - Chỉnh sửa giờ khám bệnh";
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
            this.but174.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.c174.Location = new System.Drawing.Point(101, 96);
            this.c174.Name = "c174";
            this.c174.Size = new System.Drawing.Size(480, 21);
            this.c174.TabIndex = 157;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(0, 94);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(111, 23);
            this.label41.TabIndex = 156;
            this.label41.Text = "A09. Sao lưu số liệu :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c124
            // 
            this.c124.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c124.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c124.Location = new System.Drawing.Point(115, 217);
            this.c124.Name = "c124";
            this.c124.Size = new System.Drawing.Size(495, 21);
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
            this.label27.Location = new System.Drawing.Point(22, 218);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(151, 23);
            this.label27.TabIndex = 116;
            this.label27.Text = "B12. VÔ DANH :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.c39.Location = new System.Drawing.Point(85, 350);
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
            this.label15.Location = new System.Drawing.Point(3, 354);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 20);
            this.label15.TabIndex = 104;
            this.label15.Text = "A26. Giám đốc :";
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
            this.txtNodeTextSearch.Size = new System.Drawing.Size(147, 21);
            this.txtNodeTextSearch.TabIndex = 77;
            this.txtNodeTextSearch.Text = "Tìm kiếm";
            this.txtNodeTextSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNodeTextSearch.Enter += new System.EventHandler(this.txtNodeTextSearch_Enter);
            this.txtNodeTextSearch.TextChanged += new System.EventHandler(this.txtNodeTextSearch_TextChanged);
            this.txtNodeTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeTextSearch_KeyDown);
            // 
            // p01_chung
            // 
            this.p01_chung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p01_chung.AutoScroll = true;
            this.p01_chung.Controls.Add(this.c1510);
            this.p01_chung.Controls.Add(this.label154);
            this.p01_chung.Controls.Add(this.label153);
            this.p01_chung.Controls.Add(this.C1000);
            this.p01_chung.Controls.Add(this.label152);
            this.p01_chung.Controls.Add(this.mst);
            this.p01_chung.Controls.Add(this.label137);
            this.p01_chung.Controls.Add(this.c999);
            this.p01_chung.Controls.Add(this.label135);
            this.p01_chung.Controls.Add(this.c1135);
            this.p01_chung.Controls.Add(this.c1073);
            this.p01_chung.Controls.Add(this.label131);
            this.p01_chung.Controls.Add(this.c1063);
            this.p01_chung.Controls.Add(this.label132);
            this.p01_chung.Controls.Add(this.c386);
            this.p01_chung.Controls.Add(this.c115);
            this.p01_chung.Controls.Add(this.songaydemo);
            this.p01_chung.Controls.Add(this.demo);
            this.p01_chung.Controls.Add(this.but341);
            this.p01_chung.Controls.Add(this.c341);
            this.p01_chung.Controls.Add(this.c340);
            this.p01_chung.Controls.Add(this.c138h);
            this.p01_chung.Controls.Add(this.c138m);
            this.p01_chung.Controls.Add(this.label53);
            this.p01_chung.Controls.Add(this.c277);
            this.p01_chung.Controls.Add(this.butTemp);
            this.p01_chung.Controls.Add(this.c112);
            this.p01_chung.Controls.Add(this.c232);
            this.p01_chung.Controls.Add(this.c240);
            this.p01_chung.Controls.Add(this.label8);
            this.p01_chung.Controls.Add(this.c104);
            this.p01_chung.Controls.Add(this.label7);
            this.p01_chung.Controls.Add(this.label34);
            this.p01_chung.Controls.Add(this.groupBox1);
            this.p01_chung.Controls.Add(this.c41);
            this.p01_chung.Controls.Add(this.songay);
            this.p01_chung.Controls.Add(this.but174);
            this.p01_chung.Controls.Add(this.dienthoai);
            this.p01_chung.Controls.Add(this.c195);
            this.p01_chung.Controls.Add(this.c174);
            this.p01_chung.Controls.Add(this.label20);
            this.p01_chung.Controls.Add(this.c43);
            this.p01_chung.Controls.Add(this.label18);
            this.p01_chung.Controls.Add(this.c42);
            this.p01_chung.Controls.Add(this.label19);
            this.p01_chung.Controls.Add(this.matt);
            this.p01_chung.Controls.Add(this.label41);
            this.p01_chung.Controls.Add(this.diachi);
            this.p01_chung.Controls.Add(this.soyte);
            this.p01_chung.Controls.Add(this.benhvien);
            this.p01_chung.Controls.Add(this.maqu);
            this.p01_chung.Controls.Add(this.loaidv);
            this.p01_chung.Controls.Add(this.c189);
            this.p01_chung.Controls.Add(this.label50);
            this.p01_chung.Controls.Add(this.ngonngu);
            this.p01_chung.Controls.Add(this.c40);
            this.p01_chung.Controls.Add(this.label17);
            this.p01_chung.Controls.Add(this.ngaylv);
            this.p01_chung.Controls.Add(this.c39);
            this.p01_chung.Controls.Add(this.label1);
            this.p01_chung.Controls.Add(this.label30);
            this.p01_chung.Controls.Add(this.label16);
            this.p01_chung.Controls.Add(this.label2);
            this.p01_chung.Controls.Add(this.label13);
            this.p01_chung.Controls.Add(this.label3);
            this.p01_chung.Controls.Add(this.label15);
            this.p01_chung.Controls.Add(this.label4);
            this.p01_chung.Controls.Add(this.label5);
            this.p01_chung.Controls.Add(this.label6);
            this.p01_chung.Controls.Add(this.label21);
            this.p01_chung.Controls.Add(this.butThongbao);
            this.p01_chung.Controls.Add(this.saoluu33);
            this.p01_chung.Controls.Add(this.label11);
            this.p01_chung.Controls.Add(this.c45);
            this.p01_chung.Controls.Add(this.label10);
            this.p01_chung.Controls.Add(this.tTemp);
            this.p01_chung.Controls.Add(this.lTemp);
            this.p01_chung.Controls.Add(this.c998);
            this.p01_chung.Location = new System.Drawing.Point(157, 3);
            this.p01_chung.Name = "p01_chung";
            this.p01_chung.Size = new System.Drawing.Size(961, 475);
            this.p01_chung.TabIndex = 78;
            this.p01_chung.Visible = false;
            // 
            // c1510
            // 
            this.c1510.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1510.Location = new System.Drawing.Point(117, 484);
            this.c1510.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.c1510.Name = "c1510";
            this.c1510.Size = new System.Drawing.Size(43, 21);
            this.c1510.TabIndex = 326;
            this.c1510.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(161, 487);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(155, 13);
            this.label154.TabIndex = 325;
            this.label154.Text = "tháng tuổi hiển thị số tháng tuổi";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(23, 487);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(96, 13);
            this.label153.TabIndex = 324;
            this.label153.Text = "A32. Bệnh nhân < ";
            // 
            // C1000
            // 
            this.C1000.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1000.Location = new System.Drawing.Point(478, 460);
            this.C1000.Name = "C1000";
            this.C1000.Size = new System.Drawing.Size(31, 21);
            this.C1000.TabIndex = 252;
            this.C1000.Tag = "";
            this.C1000.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label152
            // 
            this.label152.Location = new System.Drawing.Point(359, 459);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(117, 23);
            this.label152.TabIndex = 251;
            this.label152.Text = "A31. Số quầy tiếp đón:";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mst
            // 
            this.mst.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst.Location = new System.Drawing.Point(83, 72);
            this.mst.Name = "mst";
            this.mst.Size = new System.Drawing.Size(167, 21);
            this.mst.TabIndex = 249;
            // 
            // label137
            // 
            this.label137.Location = new System.Drawing.Point(-8, 72);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(94, 23);
            this.label137.TabIndex = 250;
            this.label137.Text = "A07.1. MS thuế :";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c999
            // 
            this.c999.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c999.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c999.Location = new System.Drawing.Point(144, 461);
            this.c999.Name = "c999";
            this.c999.Size = new System.Drawing.Size(207, 21);
            this.c999.TabIndex = 247;
            // 
            // label135
            // 
            this.label135.Location = new System.Drawing.Point(2, 459);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(144, 23);
            this.label135.TabIndex = 248;
            this.label135.Text = "A30. Chi nhánh hiện tại :";
            this.label135.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c1135
            // 
            this.c1135.AutoSize = true;
            this.c1135.Location = new System.Drawing.Point(546, 249);
            this.c1135.Name = "c1135";
            this.c1135.Size = new System.Drawing.Size(101, 17);
            this.c1135.TabIndex = 245;
            this.c1135.Text = "A17.1 Mẫu số 2";
            this.c1135.UseVisualStyleBackColor = true;
            this.c1135.Click += new System.EventHandler(this.c1135_Click);
            // 
            // c1073
            // 
            this.c1073.Location = new System.Drawing.Point(418, 211);
            this.c1073.Name = "c1073";
            this.c1073.Size = new System.Drawing.Size(233, 20);
            this.c1073.TabIndex = 244;
            this.c1073.Text = "A14.1. Quản lý theo khu";
            // 
            // label131
            // 
            this.label131.Location = new System.Drawing.Point(578, 439);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(32, 17);
            this.label131.TabIndex = 243;
            this.label131.Text = "ngày";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c1063
            // 
            this.c1063.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1063.Location = new System.Drawing.Point(547, 436);
            this.c1063.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c1063.Name = "c1063";
            this.c1063.Size = new System.Drawing.Size(31, 21);
            this.c1063.TabIndex = 241;
            this.c1063.Tag = "A29";
            this.c1063.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label132
            // 
            this.label132.Location = new System.Drawing.Point(328, 437);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(220, 20);
            this.label132.TabIndex = 242;
            this.label132.Text = "A29. Ngày điều trị= ngày ra - ngày vào + ";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c386
            // 
            this.c386.Location = new System.Drawing.Point(83, 437);
            this.c386.Name = "c386";
            this.c386.Size = new System.Drawing.Size(233, 20);
            this.c386.TabIndex = 240;
            this.c386.Text = "A28 - Bật bộ gõ tiếng Việt theo chương trình";
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
            this.but341.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.c341.Location = new System.Drawing.Point(371, 119);
            this.c341.Name = "c341";
            this.c341.Size = new System.Drawing.Size(212, 21);
            this.c341.TabIndex = 236;
            // 
            // c340
            // 
            this.c340.Location = new System.Drawing.Point(9, 121);
            this.c340.Name = "c340";
            this.c340.Size = new System.Drawing.Size(390, 22);
            this.c340.TabIndex = 235;
            this.c340.Text = "A10 - Tự động cập nhật lại version, thư mục chứa MEDISOFT tổng thể :";
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
            this.c277.Location = new System.Drawing.Point(331, 140);
            this.c277.Name = "c277";
            this.c277.Size = new System.Drawing.Size(284, 22);
            this.c277.TabIndex = 231;
            this.c277.Text = "A12+ Tự động hủy các tập tin trong thư mục TEMP";
            // 
            // butTemp
            // 
            this.butTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTemp.Location = new System.Drawing.Point(583, 162);
            this.butTemp.Name = "butTemp";
            this.butTemp.Size = new System.Drawing.Size(24, 23);
            this.butTemp.TabIndex = 230;
            this.butTemp.Text = "...";
            this.butTemp.UseVisualStyleBackColor = true;
            this.butTemp.Click += new System.EventHandler(this.butTemp_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(83, 373);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 62);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "A27. LỌC DANH SÁCH BÁC SĨ THEO KHOA/PHÒNG TRONG CÁC BIỂU NHẬP SAU :";
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
            this.lTemp.Text = "A11. Thư mục TEMP của :";
            this.lTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c998
            // 
            this.c998.Location = new System.Drawing.Point(418, 227);
            this.c998.Name = "c998";
            this.c998.Size = new System.Drawing.Size(233, 20);
            this.c998.TabIndex = 246;
            this.c998.Text = "A14.2. Quản lý theo chi nhánh";
            // 
            // p02_hanhchinh
            // 
            this.p02_hanhchinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p02_hanhchinh.AutoScroll = true;
            this.p02_hanhchinh.Controls.Add(this.c1600);
            this.p02_hanhchinh.Controls.Add(this.c1091);
            this.p02_hanhchinh.Controls.Add(this.c1087);
            this.p02_hanhchinh.Controls.Add(this.c142);
            this.p02_hanhchinh.Controls.Add(this.c1086);
            this.p02_hanhchinh.Controls.Add(this.c1085);
            this.p02_hanhchinh.Controls.Add(this.label136);
            this.p02_hanhchinh.Controls.Add(this.c1077);
            this.p02_hanhchinh.Controls.Add(this.c1058);
            this.p02_hanhchinh.Controls.Add(this.c343);
            this.p02_hanhchinh.Controls.Add(this.c121);
            this.p02_hanhchinh.Controls.Add(this.c119);
            this.p02_hanhchinh.Controls.Add(this.c275);
            this.p02_hanhchinh.Controls.Add(this.c125);
            this.p02_hanhchinh.Controls.Add(this.c123);
            this.p02_hanhchinh.Controls.Add(this.label29);
            this.p02_hanhchinh.Controls.Add(this.c0);
            this.p02_hanhchinh.Controls.Add(this.c114);
            this.p02_hanhchinh.Controls.Add(this.c122);
            this.p02_hanhchinh.Controls.Add(this.c44);
            this.p02_hanhchinh.Controls.Add(this.butImage);
            this.p02_hanhchinh.Controls.Add(this.label28);
            this.p02_hanhchinh.Controls.Add(this.label9);
            this.p02_hanhchinh.Controls.Add(this.c107);
            this.p02_hanhchinh.Controls.Add(this.c265);
            this.p02_hanhchinh.Controls.Add(this.c124);
            this.p02_hanhchinh.Controls.Add(this.label12);
            this.p02_hanhchinh.Controls.Add(this.label57);
            this.p02_hanhchinh.Controls.Add(this.c264);
            this.p02_hanhchinh.Controls.Add(this.label27);
            this.p02_hanhchinh.Controls.Add(this.label26);
            this.p02_hanhchinh.Controls.Add(this.c120);
            this.p02_hanhchinh.Controls.Add(this.label24);
            this.p02_hanhchinh.Controls.Add(this.label25);
            this.p02_hanhchinh.Controls.Add(this.c248);
            this.p02_hanhchinh.Controls.Add(this.c258);
            this.p02_hanhchinh.Location = new System.Drawing.Point(157, 3);
            this.p02_hanhchinh.Name = "p02_hanhchinh";
            this.p02_hanhchinh.Size = new System.Drawing.Size(663, 509);
            this.p02_hanhchinh.TabIndex = 79;
            this.p02_hanhchinh.Visible = false;
            // 
            // c1600
            // 
            this.c1600.AutoSize = true;
            this.c1600.Location = new System.Drawing.Point(7, 428);
            this.c1600.Name = "c1600";
            this.c1600.Size = new System.Drawing.Size(211, 17);
            this.c1600.TabIndex = 273;
            this.c1600.Text = "B18. BHYT dùng QA code khi đăng ký";
            this.c1600.UseVisualStyleBackColor = true;
            this.c1600.CheckedChanged += new System.EventHandler(this.c1600_CheckedChanged);
            // 
            // c1091
            // 
            this.c1091.AutoSize = true;
            this.c1091.Location = new System.Drawing.Point(7, 409);
            this.c1091.Name = "c1091";
            this.c1091.Size = new System.Drawing.Size(322, 17);
            this.c1091.TabIndex = 272;
            this.c1091.Text = "B17. Bệnh nhân phòng lưu bắt buộc nhập thông tin người thân";
            this.c1091.UseVisualStyleBackColor = true;
            // 
            // c1087
            // 
            this.c1087.AutoSize = true;
            this.c1087.Location = new System.Drawing.Point(191, 351);
            this.c1087.Name = "c1087";
            this.c1087.Size = new System.Drawing.Size(366, 17);
            this.c1087.TabIndex = 271;
            this.c1087.Text = "B14.1 Nhắc nhở chụp hình chứng từ đối với bệnh nhân BHYT trái tuyến";
            this.c1087.UseVisualStyleBackColor = true;
            // 
            // c1086
            // 
            this.c1086.AutoSize = true;
            this.c1086.Location = new System.Drawing.Point(7, 391);
            this.c1086.Name = "c1086";
            this.c1086.Size = new System.Drawing.Size(360, 17);
            this.c1086.TabIndex = 270;
            this.c1086.Text = "B16. Bệnh nhân dưới 72 tháng tuổi bắt buộc nhập thông tin người thân";
            this.c1086.UseVisualStyleBackColor = true;
            // 
            // c1085
            // 
            this.c1085.Location = new System.Drawing.Point(191, 368);
            this.c1085.Name = "c1085";
            this.c1085.Size = new System.Drawing.Size(388, 20);
            this.c1085.TabIndex = 269;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(23, 372);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(163, 13);
            this.label136.TabIndex = 268;
            this.label136.Text = "B15. Thư mục lưu ảnh chứng từ: ";
            // 
            // c1077
            // 
            this.c1077.AutoSize = true;
            this.c1077.Location = new System.Drawing.Point(7, 351);
            this.c1077.Name = "c1077";
            this.c1077.Size = new System.Drawing.Size(144, 17);
            this.c1077.TabIndex = 267;
            this.c1077.Text = "B14. Chụp hình chứng từ";
            this.c1077.UseVisualStyleBackColor = true;
            // 
            // c1058
            // 
            this.c1058.Location = new System.Drawing.Point(7, 331);
            this.c1058.Name = "c1058";
            this.c1058.Size = new System.Drawing.Size(342, 19);
            this.c1058.TabIndex = 266;
            this.c1058.Text = "B13. Xóa trắng ô nơi đăng ký KCB ban đầu khi chọn BHYT";
            // 
            // c343
            // 
            this.c343.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c343.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.c343.Location = new System.Drawing.Point(8, 40);
            this.c343.Name = "c343";
            this.c343.Size = new System.Drawing.Size(201, 19);
            this.c343.TabIndex = 265;
            this.c343.Text = "B03 - Quản lý Smart Card";
            // 
            // p04_masotudong
            // 
            this.p04_masotudong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p04_masotudong.AutoScroll = true;
            this.p04_masotudong.Controls.Add(this.c40091);
            this.p04_masotudong.Controls.Add(this.rbcaptheotv);
            this.p04_masotudong.Controls.Add(this.rbcaptheokhoa);
            this.p04_masotudong.Controls.Add(this.c1090);
            this.p04_masotudong.Controls.Add(this.c1074);
            this.p04_masotudong.Controls.Add(this.c1066);
            this.p04_masotudong.Controls.Add(this.c1065);
            this.p04_masotudong.Controls.Add(this.c1064);
            this.p04_masotudong.Controls.Add(this.c1060);
            this.p04_masotudong.Controls.Add(this.c1056);
            this.p04_masotudong.Controls.Add(this.c1047);
            this.p04_masotudong.Controls.Add(this.c1029);
            this.p04_masotudong.Controls.Add(this.c1028);
            this.p04_masotudong.Controls.Add(this.c241);
            this.p04_masotudong.Controls.Add(this.c1027);
            this.p04_masotudong.Controls.Add(this.c433);
            this.p04_masotudong.Controls.Add(this.c225);
            this.p04_masotudong.Controls.Add(this.c346);
            this.p04_masotudong.Controls.Add(this.c301);
            this.p04_masotudong.Controls.Add(this.c239);
            this.p04_masotudong.Controls.Add(this.c216);
            this.p04_masotudong.Controls.Add(this.c59);
            this.p04_masotudong.Controls.Add(this.sovaovien);
            this.p04_masotudong.Controls.Add(this.c226);
            this.p04_masotudong.Controls.Add(this.c51);
            this.p04_masotudong.Controls.Add(this.c140);
            this.p04_masotudong.Controls.Add(this.c177);
            this.p04_masotudong.Controls.Add(this.c243);
            this.p04_masotudong.Controls.Add(this.c108);
            this.p04_masotudong.Controls.Add(this.c203);
            this.p04_masotudong.Controls.Add(this.c201);
            this.p04_masotudong.Controls.Add(this.c202);
            this.p04_masotudong.Controls.Add(this.c109);
            this.p04_masotudong.Controls.Add(this.c223);
            this.p04_masotudong.Controls.Add(this.c224);
            this.p04_masotudong.Controls.Add(this.c102);
            this.p04_masotudong.Controls.Add(this.c227);
            this.p04_masotudong.Location = new System.Drawing.Point(157, 3);
            this.p04_masotudong.Name = "p04_masotudong";
            this.p04_masotudong.Size = new System.Drawing.Size(663, 509);
            this.p04_masotudong.TabIndex = 82;
            this.p04_masotudong.Visible = false;
            // 
            // rbcaptheotv
            // 
            this.rbcaptheotv.AutoSize = true;
            this.rbcaptheotv.Location = new System.Drawing.Point(132, 50);
            this.rbcaptheotv.Name = "rbcaptheotv";
            this.rbcaptheotv.Size = new System.Drawing.Size(115, 17);
            this.rbcaptheotv.TabIndex = 244;
            this.rbcaptheotv.TabStop = true;
            this.rbcaptheotv.Text = "Cấp theo toàn viện";
            this.rbcaptheotv.UseVisualStyleBackColor = true;
            this.rbcaptheotv.CheckedChanged += new System.EventHandler(this.rbcaptheotv_CheckedChanged);
            // 
            // rbcaptheokhoa
            // 
            this.rbcaptheokhoa.AutoSize = true;
            this.rbcaptheokhoa.Location = new System.Drawing.Point(13, 49);
            this.rbcaptheokhoa.Name = "rbcaptheokhoa";
            this.rbcaptheokhoa.Size = new System.Drawing.Size(95, 17);
            this.rbcaptheokhoa.TabIndex = 243;
            this.rbcaptheokhoa.TabStop = true;
            this.rbcaptheokhoa.Text = "Cấp theo khoa";
            this.rbcaptheokhoa.UseVisualStyleBackColor = true;
            this.rbcaptheokhoa.CheckedChanged += new System.EventHandler(this.rbcaptheokhoa_CheckedChanged);
            // 
            // c1090
            // 
            this.c1090.AccessibleDescription = "";
            this.c1090.Location = new System.Drawing.Point(383, 252);
            this.c1090.Name = "c1090";
            this.c1090.Size = new System.Drawing.Size(401, 24);
            this.c1090.TabIndex = 242;
            this.c1090.Text = "D28 - Số lưu trữ khu khám, ngoại trú tăng tự động(CNYYMMXXXXXX)";
            // 
            // c1074
            // 
            this.c1074.Location = new System.Drawing.Point(23, 177);
            this.c1074.Name = "c1074";
            this.c1074.Size = new System.Drawing.Size(262, 17);
            this.c1074.TabIndex = 241;
            this.c1074.Text = "D10.1 - Mã BN tự động theo máy (MSBN liên tục)";
            this.c1074.CheckedChanged += new System.EventHandler(this.c1074_CheckedChanged);
            // 
            // c1066
            // 
            this.c1066.Location = new System.Drawing.Point(383, 216);
            this.c1066.Name = "c1066";
            this.c1066.Size = new System.Drawing.Size(423, 18);
            this.c1066.TabIndex = 240;
            this.c1066.Text = "D26. Số phiếu thanh toán ra viện tăng theo tháng, tính từ ngày tạo số liệu";
            this.c1066.CheckedChanged += new System.EventHandler(this.c1066_CheckedChanged);
            // 
            // c1065
            // 
            this.c1065.Location = new System.Drawing.Point(383, 197);
            this.c1065.Name = "c1065";
            this.c1065.Size = new System.Drawing.Size(362, 18);
            this.c1065.TabIndex = 239;
            this.c1065.Text = "D25. Số phiếu thanh toán ra viện tăng theo tháng, tính từ ngày 1";
            this.c1065.CheckedChanged += new System.EventHandler(this.c1065_CheckedChanged);
            // 
            // c1064
            // 
            this.c1064.Location = new System.Drawing.Point(383, 178);
            this.c1064.Name = "c1064";
            this.c1064.Size = new System.Drawing.Size(423, 18);
            this.c1064.TabIndex = 238;
            this.c1064.Text = "D24. Số phiếu thanh toán ra viện tăng theo năm, tính từ ngày tạo số liệu tháng 1";
            this.c1064.CheckedChanged += new System.EventHandler(this.c1064_CheckedChanged);
            // 
            // c1060
            // 
            this.c1060.AccessibleDescription = "";
            this.c1060.Location = new System.Drawing.Point(383, 233);
            this.c1060.Name = "c1060";
            this.c1060.Size = new System.Drawing.Size(324, 24);
            this.c1060.TabIndex = 237;
            this.c1060.Text = "D27 - Mã bệnh nhân tăng tự động lấy từ server internet";
            // 
            // c1056
            // 
            this.c1056.Location = new System.Drawing.Point(383, 159);
            this.c1056.Name = "c1056";
            this.c1056.Size = new System.Drawing.Size(362, 18);
            this.c1056.TabIndex = 236;
            this.c1056.Text = "D23. Số phiếu thanh toán ra viện tăng theo năm, tính từ ngày 1";
            this.c1056.CheckedChanged += new System.EventHandler(this.c1056_CheckedChanged);
            // 
            // c1047
            // 
            this.c1047.Location = new System.Drawing.Point(23, 124);
            this.c1047.Name = "c1047";
            this.c1047.Size = new System.Drawing.Size(274, 19);
            this.c1047.TabIndex = 235;
            this.c1047.Text = "D07.1 - Bắt buộc phải lăn vân tay";
            // 
            // c1029
            // 
            this.c1029.Location = new System.Drawing.Point(383, 140);
            this.c1029.Name = "c1029";
            this.c1029.Size = new System.Drawing.Size(362, 18);
            this.c1029.TabIndex = 234;
            this.c1029.Text = "D22. Số chuyển viện tăng tự động";
            // 
            // c1028
            // 
            this.c1028.Location = new System.Drawing.Point(383, 121);
            this.c1028.Name = "c1028";
            this.c1028.Size = new System.Drawing.Size(362, 18);
            this.c1028.TabIndex = 233;
            this.c1028.Text = "D21. Số vào viện ngoại trú tăng tự động (theo dãy số riêng)";
            this.c1028.Click += new System.EventHandler(this.c1028_Click);
            // 
            // c1027
            // 
            this.c1027.Location = new System.Drawing.Point(383, 102);
            this.c1027.Name = "c1027";
            this.c1027.Size = new System.Drawing.Size(362, 18);
            this.c1027.TabIndex = 232;
            this.c1027.Text = "D20. Số vào viện ngoại trú tăng tự động chung với nội trú";
            this.c1027.Click += new System.EventHandler(this.c1027_Click);
            // 
            // c433
            // 
            this.c433.Location = new System.Drawing.Point(383, 83);
            this.c433.Name = "c433";
            this.c433.Size = new System.Drawing.Size(264, 18);
            this.c433.TabIndex = 231;
            this.c433.Text = "D19 - Số lưu trữ ngoại trú tăng tự động theo năm";
            // 
            // c346
            // 
            this.c346.Location = new System.Drawing.Point(5, 345);
            this.c346.Name = "c346";
            this.c346.Size = new System.Drawing.Size(368, 19);
            this.c346.TabIndex = 230;
            this.c346.Text = "D18 + Tự động chuyển thông tin vào phòng lưu trong khám bệnh";
            // 
            // c301
            // 
            this.c301.Location = new System.Drawing.Point(168, 29);
            this.c301.Name = "c301";
            this.c301.Size = new System.Drawing.Size(145, 18);
            this.c301.TabIndex = 229;
            this.c301.Text = "- Trong xuất khoa";
            this.c301.CheckedChanged += new System.EventHandler(this.c301_CheckedChanged);
            // 
            // sovaovien
            // 
            this.sovaovien.Location = new System.Drawing.Point(5, 10);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(175, 18);
            this.sovaovien.TabIndex = 75;
            this.sovaovien.Text = "D01 + Số vào viện tự động";
            this.sovaovien.CheckedChanged += new System.EventHandler(this.sovaovien_CheckedChanged);
            // 
            // p05_doituong
            // 
            this.p05_doituong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p05_doituong.AutoScroll = true;
            this.p05_doituong.Controls.Add(this.c50034);
            this.p05_doituong.Controls.Add(this.c352);
            this.p05_doituong.Controls.Add(this.label149);
            this.p05_doituong.Controls.Add(this.c1141);
            this.p05_doituong.Controls.Add(this.label147);
            this.p05_doituong.Controls.Add(this.label148);
            this.p05_doituong.Controls.Add(this.c1140);
            this.p05_doituong.Controls.Add(this.c1139);
            this.p05_doituong.Controls.Add(this.label145);
            this.p05_doituong.Controls.Add(this.c1138);
            this.p05_doituong.Controls.Add(this.label144);
            this.p05_doituong.Controls.Add(this.c1137);
            this.p05_doituong.Controls.Add(this.label143);
            this.p05_doituong.Controls.Add(this.label142);
            this.p05_doituong.Controls.Add(this.label146);
            this.p05_doituong.Controls.Add(this.c62);
            this.p05_doituong.Controls.Add(this.label140);
            this.p05_doituong.Controls.Add(this.label141);
            this.p05_doituong.Controls.Add(this.txtmatinh);
            this.p05_doituong.Controls.Add(this.txtkituchu);
            this.p05_doituong.Controls.Add(this.c997);
            this.p05_doituong.Controls.Add(this.c1080);
            this.p05_doituong.Controls.Add(this.c1076);
            this.p05_doituong.Controls.Add(this.c1075);
            this.p05_doituong.Controls.Add(this.c1053);
            this.p05_doituong.Controls.Add(this.c1046);
            this.p05_doituong.Controls.Add(this.c1045);
            this.p05_doituong.Controls.Add(this.c1038);
            this.p05_doituong.Controls.Add(this.c1023);
            this.p05_doituong.Controls.Add(this.c1008);
            this.p05_doituong.Controls.Add(this.c1007);
            this.p05_doituong.Controls.Add(this.c49);
            this.p05_doituong.Controls.Add(this.label123);
            this.p05_doituong.Controls.Add(this.c442);
            this.p05_doituong.Controls.Add(this.c438);
            this.p05_doituong.Controls.Add(this.d50);
            this.p05_doituong.Controls.Add(this.ma13);
            this.p05_doituong.Controls.Add(this.label120);
            this.p05_doituong.Controls.Add(this.label122);
            this.p05_doituong.Controls.Add(this.d52);
            this.p05_doituong.Controls.Add(this.c431);
            this.p05_doituong.Controls.Add(this.label121);
            this.p05_doituong.Controls.Add(this.d53);
            this.p05_doituong.Controls.Add(this.d51);
            this.p05_doituong.Controls.Add(this.c175);
            this.p05_doituong.Controls.Add(this.label114);
            this.p05_doituong.Controls.Add(this.label115);
            this.p05_doituong.Controls.Add(this.label116);
            this.p05_doituong.Controls.Add(this.label117);
            this.p05_doituong.Controls.Add(this.label118);
            this.p05_doituong.Controls.Add(this.label119);
            this.p05_doituong.Controls.Add(this.c428);
            this.p05_doituong.Controls.Add(this.label112);
            this.p05_doituong.Controls.Add(this.c427);
            this.p05_doituong.Controls.Add(this.label111);
            this.p05_doituong.Controls.Add(this.c426);
            this.p05_doituong.Controls.Add(this.c365);
            this.p05_doituong.Controls.Add(this.label95);
            this.p05_doituong.Controls.Add(this.c360);
            this.p05_doituong.Controls.Add(this.c348);
            this.p05_doituong.Controls.Add(this.c353);
            this.p05_doituong.Controls.Add(this.c351);
            this.p05_doituong.Controls.Add(this.c350);
            this.p05_doituong.Controls.Add(this.c349);
            this.p05_doituong.Controls.Add(this.lbl60);
            this.p05_doituong.Controls.Add(this.label93);
            this.p05_doituong.Controls.Add(this.label94);
            this.p05_doituong.Controls.Add(this.label92);
            this.p05_doituong.Controls.Add(this.label91);
            this.p05_doituong.Controls.Add(this.label90);
            this.p05_doituong.Controls.Add(this.label89);
            this.p05_doituong.Controls.Add(this.label88);
            this.p05_doituong.Controls.Add(this.label87);
            this.p05_doituong.Controls.Add(this.c347);
            this.p05_doituong.Controls.Add(this.c345);
            this.p05_doituong.Controls.Add(this.label84);
            this.p05_doituong.Controls.Add(this.c333);
            this.p05_doituong.Controls.Add(this.label83);
            this.p05_doituong.Controls.Add(this.c332);
            this.p05_doituong.Controls.Add(this.label82);
            this.p05_doituong.Controls.Add(this.c321);
            this.p05_doituong.Controls.Add(this.c163);
            this.p05_doituong.Controls.Add(this.c205);
            this.p05_doituong.Controls.Add(this.c131);
            this.p05_doituong.Controls.Add(this.c204);
            this.p05_doituong.Controls.Add(this.c180);
            this.p05_doituong.Controls.Add(this.c192);
            this.p05_doituong.Controls.Add(this.c132);
            this.p05_doituong.Controls.Add(this.c154);
            this.p05_doituong.Controls.Add(this.c178);
            this.p05_doituong.Controls.Add(this.c362);
            this.p05_doituong.Location = new System.Drawing.Point(157, 3);
            this.p05_doituong.Name = "p05_doituong";
            this.p05_doituong.Size = new System.Drawing.Size(672, 509);
            this.p05_doituong.TabIndex = 83;
            this.p05_doituong.Visible = false;
            // 
            // c50034
            // 
            this.c50034.AutoSize = true;
            this.c50034.Location = new System.Drawing.Point(716, 391);
            this.c50034.Name = "c50034";
            this.c50034.Size = new System.Drawing.Size(296, 17);
            this.c50034.TabIndex = 281;
            this.c50034.Text = "E34. BN đã in mẫu 01, trong ngày không cho đăng ký lại";
            this.c50034.UseVisualStyleBackColor = true;
            // 
            // c352
            // 
            this.c352.Location = new System.Drawing.Point(1016, 370);
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
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(713, 372);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(312, 13);
            this.label149.TabIndex = 279;
            this.label149.Text = "E33. Các đối tượng còn lại hưởng              % nhưng không quá : ";
            // 
            // c1141
            // 
            this.c1141.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c1141.Location = new System.Drawing.Point(855, 349);
            this.c1141.Name = "c1141";
            this.c1141.Size = new System.Drawing.Size(200, 20);
            this.c1141.TabIndex = 277;
            this.c1141.Text = "BT4+HN4+HT5";
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(712, 352);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(140, 13);
            this.label147.TabIndex = 276;
            this.label147.Text = "E32. Đối tượng hưởng 95%: ";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(1057, 352);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(64, 13);
            this.label148.TabIndex = 278;
            this.label148.Text = "không quá: ";
            // 
            // c1140
            // 
            this.c1140.Location = new System.Drawing.Point(1119, 328);
            this.c1140.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c1140.Name = "c1140";
            this.c1140.Size = new System.Drawing.Size(79, 20);
            this.c1140.TabIndex = 274;
            this.c1140.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1140.Value = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            // 
            // c1139
            // 
            this.c1139.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c1139.Location = new System.Drawing.Point(855, 328);
            this.c1139.Name = "c1139";
            this.c1139.Size = new System.Drawing.Size(200, 20);
            this.c1139.TabIndex = 273;
            this.c1139.Text = "CA3+HT2+CK2";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(712, 331);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(146, 13);
            this.label145.TabIndex = 272;
            this.label145.Text = "E31. Đối tượng hưởng 100%: ";
            // 
            // c1138
            // 
            this.c1138.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c1138.Location = new System.Drawing.Point(855, 307);
            this.c1138.Name = "c1138";
            this.c1138.Size = new System.Drawing.Size(200, 20);
            this.c1138.TabIndex = 271;
            this.c1138.Text = "TE1+CC1";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(712, 310);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(146, 13);
            this.label144.TabIndex = 270;
            this.label144.Text = "E30. Đối tượng hưởng 100%: ";
            // 
            // c1137
            // 
            this.c1137.Location = new System.Drawing.Point(914, 291);
            this.c1137.Name = "c1137";
            this.c1137.Size = new System.Drawing.Size(222, 19);
            this.c1137.TabIndex = 269;
            this.c1137.Text = "E29. Tính tiền theo từng dịch vụ";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(705, 293);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(209, 13);
            this.label143.TabIndex = 268;
            this.label143.Text = "DỊCH VỤ KỸ THUẬT CAO, CHI PHÍ LỚN: ";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(691, 273);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(384, 13);
            this.label142.TabIndex = 267;
            this.label142.Text = "DỊCH VỤ KỸ THUẬT CAO CHI PHÍ LỚN THEO TT03 VÀ QĐ36      ";
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(1057, 331);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(64, 13);
            this.label146.TabIndex = 275;
            this.label146.Text = "không quá: ";
            // 
            // c62
            // 
            this.c62.AutoSize = true;
            this.c62.Location = new System.Drawing.Point(331, 210);
            this.c62.Name = "c62";
            this.c62.Size = new System.Drawing.Size(316, 17);
            this.c62.TabIndex = 266;
            this.c62.Text = "E19 Bệnh nhân khác tỉnh tính trái tuyến tử phòng khám thứ 2";
            this.c62.UseVisualStyleBackColor = true;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(696, 160);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(179, 13);
            this.label140.TabIndex = 265;
            this.label140.Text = "Những mã tỉnh ngoài trong qui định :";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(695, 51);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(159, 13);
            this.label141.TabIndex = 264;
            this.label141.Text = "2 kí tự chữ qui định của BHYT :";
            // 
            // txtmatinh
            // 
            this.txtmatinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmatinh.Enabled = false;
            this.txtmatinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmatinh.Location = new System.Drawing.Point(702, 175);
            this.txtmatinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.txtmatinh.Multiline = true;
            this.txtmatinh.Name = "txtmatinh";
            this.txtmatinh.Size = new System.Drawing.Size(148, 86);
            this.txtmatinh.TabIndex = 263;
            // 
            // txtkituchu
            // 
            this.txtkituchu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtkituchu.Enabled = false;
            this.txtkituchu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkituchu.Location = new System.Drawing.Point(699, 71);
            this.txtkituchu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.txtkituchu.Multiline = true;
            this.txtkituchu.Name = "txtkituchu";
            this.txtkituchu.Size = new System.Drawing.Size(148, 86);
            this.txtkituchu.TabIndex = 262;
            // 
            // c997
            // 
            this.c997.Location = new System.Drawing.Point(694, 3);
            this.c997.Name = "c997";
            this.c997.Size = new System.Drawing.Size(166, 46);
            this.c997.TabIndex = 261;
            this.c997.Text = "E28. Kiểm tra tính hợp lệ của thẻ dựa vào 5 kí tự đầu theo qui định của BHYT";
            this.c997.UseVisualStyleBackColor = true;
            this.c997.CheckedChanged += new System.EventHandler(this.c997_CheckedChanged);
            // 
            // c1080
            // 
            this.c1080.AutoSize = true;
            this.c1080.Location = new System.Drawing.Point(392, 374);
            this.c1080.Name = "c1080";
            this.c1080.Size = new System.Drawing.Size(194, 17);
            this.c1080.TabIndex = 255;
            this.c1080.Text = "E27. Quản lý Bệnh nhân Trung cao";
            this.c1080.UseVisualStyleBackColor = true;
            // 
            // c1076
            // 
            this.c1076.AutoSize = true;
            this.c1076.Location = new System.Drawing.Point(392, 357);
            this.c1076.Name = "c1076";
            this.c1076.Size = new System.Drawing.Size(205, 17);
            this.c1076.TabIndex = 254;
            this.c1076.Text = "E26. BN BHYT bắt buộc nhập CMND";
            this.c1076.UseVisualStyleBackColor = true;
            // 
            // c1075
            // 
            this.c1075.Location = new System.Drawing.Point(392, 338);
            this.c1075.Name = "c1075";
            this.c1075.Size = new System.Drawing.Size(293, 19);
            this.c1075.TabIndex = 253;
            this.c1075.Text = "E25. BHYT cần phân biệt nhân viên của bệnh viện";
            // 
            // c1053
            // 
            this.c1053.Location = new System.Drawing.Point(392, 320);
            this.c1053.Name = "c1053";
            this.c1053.Size = new System.Drawing.Size(282, 19);
            this.c1053.TabIndex = 252;
            this.c1053.Text = "E24. CPVC xét kèm mã quyền lợi (ký tự thứ 3 trên thẻ)";
            this.toolTip1.SetToolTip(this.c1053, "Chi phí vận chuyển xét kèm mã quyền lợi ( ký tự thứ 3 trên  thẻ)");
            // 
            // c1046
            // 
            this.c1046.Location = new System.Drawing.Point(392, 302);
            this.c1046.Name = "c1046";
            this.c1046.Size = new System.Drawing.Size(277, 19);
            this.c1046.TabIndex = 251;
            this.c1046.Text = "E23. BHYT trái tuyến tính theo tỷ lệ chi trả riêng";
            // 
            // c1045
            // 
            this.c1045.Checked = true;
            this.c1045.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1045.Location = new System.Drawing.Point(331, 285);
            this.c1045.Name = "c1045";
            this.c1045.Size = new System.Drawing.Size(316, 19);
            this.c1045.TabIndex = 250;
            this.c1045.Text = "E22. Lấy giá mua khi giá BH=0, hoặc giá BH > Giá mua";
            // 
            // c1038
            // 
            this.c1038.Location = new System.Drawing.Point(331, 247);
            this.c1038.Name = "c1038";
            this.c1038.Size = new System.Drawing.Size(301, 19);
            this.c1038.TabIndex = 249;
            this.c1038.Text = "E20. Thẻ BHYT khác tỉnh mặc định là trái tuyến";
            // 
            // c1023
            // 
            this.c1023.Location = new System.Drawing.Point(331, 266);
            this.c1023.Name = "c1023";
            this.c1023.Size = new System.Drawing.Size(354, 18);
            this.c1023.TabIndex = 248;
            this.c1023.Text = "Sửa đối tượng tự động sửa đối tượng dịch vụ theo ngày trình thẻ\r\n";
            this.c1023.CheckedChanged += new System.EventHandler(this.c1023_CheckedChanged);
            // 
            // c1008
            // 
            this.c1008.Location = new System.Drawing.Point(507, 225);
            this.c1008.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c1008.Name = "c1008";
            this.c1008.Size = new System.Drawing.Size(79, 20);
            this.c1008.TabIndex = 247;
            this.c1008.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1008.Value = new decimal(new int[] {
            20000000,
            0,
            0,
            0});
            // 
            // c1007
            // 
            this.c1007.Location = new System.Drawing.Point(331, 227);
            this.c1007.Name = "c1007";
            this.c1007.Size = new System.Drawing.Size(211, 19);
            this.c1007.TabIndex = 246;
            this.c1007.Text = "KT cao, BHYT chỉ chi trả tối đa: ";
            this.c1007.Click += new System.EventHandler(this.c1007_Click);
            // 
            // c49
            // 
            this.c49.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c49.Location = new System.Drawing.Point(151, 45);
            this.c49.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c49.Name = "c49";
            this.c49.Size = new System.Drawing.Size(249, 21);
            this.c49.TabIndex = 225;
            // 
            // label123
            // 
            this.label123.Location = new System.Drawing.Point(397, 44);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(38, 23);
            this.label123.TabIndex = 245;
            this.label123.Text = "95 % :";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c442
            // 
            this.c442.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c442.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c442.Location = new System.Drawing.Point(435, 45);
            this.c442.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c442.Name = "c442";
            this.c442.Size = new System.Drawing.Size(72, 21);
            this.c442.TabIndex = 244;
            // 
            // c438
            // 
            this.c438.Location = new System.Drawing.Point(331, 191);
            this.c438.Name = "c438";
            this.c438.Size = new System.Drawing.Size(211, 19);
            this.c438.TabIndex = 243;
            this.c438.Text = "E18.4 - Trên chi phí bảo hiểm chi trả";
            // 
            // d50
            // 
            this.d50.BackColor = System.Drawing.SystemColors.HighlightText;
            this.d50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d50.Location = new System.Drawing.Point(519, 23);
            this.d50.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.d50.Name = "d50";
            this.d50.Size = new System.Drawing.Size(57, 21);
            this.d50.TabIndex = 239;
            this.d50.Text = "20000";
            this.d50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ma13
            // 
            this.ma13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma13.Location = new System.Drawing.Point(151, 23);
            this.ma13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma13.Name = "ma13";
            this.ma13.Size = new System.Drawing.Size(248, 21);
            this.ma13.TabIndex = 238;
            // 
            // label120
            // 
            this.label120.Location = new System.Drawing.Point(-11, 23);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(160, 23);
            this.label120.TabIndex = 237;
            this.label120.Text = "Số thẻ 15 ký tự, Chi trả 80 % :";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label122
            // 
            this.label122.Location = new System.Drawing.Point(507, 22);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(16, 23);
            this.label122.TabIndex = 241;
            this.label122.Text = ">";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // d52
            // 
            this.d52.BackColor = System.Drawing.SystemColors.HighlightText;
            this.d52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d52.Location = new System.Drawing.Point(577, 22);
            this.d52.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.d52.Name = "d52";
            this.d52.Size = new System.Drawing.Size(39, 21);
            this.d52.TabIndex = 240;
            this.d52.Text = "5,1";
            this.d52.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c431
            // 
            this.c431.Location = new System.Drawing.Point(517, 170);
            this.c431.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c431.Name = "c431";
            this.c431.Size = new System.Drawing.Size(68, 20);
            this.c431.TabIndex = 236;
            this.c431.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(327, 173);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(277, 13);
            this.label121.TabIndex = 235;
            this.label121.Text = "E18.3. Mức bảo hiểm chi trả  :                                        %";
            // 
            // d53
            // 
            this.d53.BackColor = System.Drawing.SystemColors.HighlightText;
            this.d53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d53.Location = new System.Drawing.Point(578, 45);
            this.d53.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.d53.Name = "d53";
            this.d53.Size = new System.Drawing.Size(39, 21);
            this.d53.TabIndex = 228;
            this.d53.Text = "5,2";
            this.d53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // d51
            // 
            this.d51.BackColor = System.Drawing.SystemColors.HighlightText;
            this.d51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d51.Location = new System.Drawing.Point(519, 45);
            this.d51.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.d51.Name = "d51";
            this.d51.Size = new System.Drawing.Size(57, 21);
            this.d51.TabIndex = 227;
            this.d51.Text = "20000";
            this.d51.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c175
            // 
            this.c175.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c175.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c175.Location = new System.Drawing.Point(435, 23);
            this.c175.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c175.Name = "c175";
            this.c175.Size = new System.Drawing.Size(72, 21);
            this.c175.TabIndex = 226;
            // 
            // label114
            // 
            this.label114.Location = new System.Drawing.Point(397, 22);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(38, 23);
            this.label114.TabIndex = 232;
            this.label114.Text = "95 % :";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label115
            // 
            this.label115.Location = new System.Drawing.Point(4, 2);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(120, 23);
            this.label115.TabIndex = 223;
            this.label115.Text = "Bảo hiểm cùng chi trả";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label116
            // 
            this.label116.Location = new System.Drawing.Point(-16, 44);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(165, 23);
            this.label116.TabIndex = 224;
            this.label116.Text = "Số thẻ 18 ký tự, Chi trả 80 % :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label117
            // 
            this.label117.Location = new System.Drawing.Point(507, 43);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(16, 23);
            this.label117.TabIndex = 230;
            this.label117.Text = ">";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label118
            // 
            this.label118.Location = new System.Drawing.Point(518, 2);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(48, 23);
            this.label118.TabIndex = 229;
            this.label118.Text = "Số tiền";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label119
            // 
            this.label119.Location = new System.Drawing.Point(575, 2);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(39, 23);
            this.label119.TabIndex = 231;
            this.label119.Text = "Vị trí";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c428
            // 
            this.c428.Location = new System.Drawing.Point(517, 149);
            this.c428.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c428.Name = "c428";
            this.c428.Size = new System.Drawing.Size(68, 20);
            this.c428.TabIndex = 222;
            this.c428.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c428.Value = new decimal(new int[] {
            550000,
            0,
            0,
            0});
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(327, 152);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(318, 13);
            this.label112.TabIndex = 221;
            this.label112.Text = "E18.2. Mức chi trả tối đa nội trú :                                   đợt điều tr" +
                "ị";
            // 
            // c427
            // 
            this.c427.Location = new System.Drawing.Point(517, 127);
            this.c427.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.c427.Name = "c427";
            this.c427.Size = new System.Drawing.Size(68, 20);
            this.c427.TabIndex = 220;
            this.c427.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c427.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(327, 130);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(346, 13);
            this.label111.TabIndex = 219;
            this.label111.Text = "E18.1. Mức chi trả tối đa phòng khám :                   lần khám và cấp toa";
            // 
            // c426
            // 
            this.c426.Location = new System.Drawing.Point(329, 109);
            this.c426.Name = "c426";
            this.c426.Size = new System.Drawing.Size(228, 19);
            this.c426.TabIndex = 218;
            this.c426.Text = "E18 - Áp dụng thanh toán trái tuyến BHYT";
            this.c426.CheckedChanged += new System.EventHandler(this.c426_CheckedChanged);
            // 
            // c365
            // 
            this.c365.Location = new System.Drawing.Point(565, 87);
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
            this.label95.Location = new System.Drawing.Point(325, 91);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(244, 13);
            this.label95.TabIndex = 216;
            this.label95.Text = "E17. Thứ 7, chủ nhật BHYT chi trả chi phí tối đa :";
            // 
            // c360
            // 
            this.c360.Location = new System.Drawing.Point(2, 303);
            this.c360.Name = "c360";
            this.c360.Size = new System.Drawing.Size(224, 19);
            this.c360.TabIndex = 214;
            this.c360.Text = "E13.1 Chênh lệch theo giá mua";
            // 
            // c348
            // 
            this.c348.Location = new System.Drawing.Point(302, 338);
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
            this.c353.Location = new System.Drawing.Point(3, 320);
            this.c353.Name = "c353";
            this.c353.Size = new System.Drawing.Size(452, 19);
            this.c353.TabIndex = 213;
            this.c353.Text = "E14 + Nhập ngày bắt đầu hưởng các khoản chi phí, chăm sóc,thuốc đặc trị";
            // 
            // c351
            // 
            this.c351.Location = new System.Drawing.Point(532, 438);
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
            // c350
            // 
            this.c350.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c350.Location = new System.Drawing.Point(228, 438);
            this.c350.Name = "c350";
            this.c350.Size = new System.Drawing.Size(200, 20);
            this.c350.TabIndex = 210;
            // 
            // c349
            // 
            this.c349.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c349.Location = new System.Drawing.Point(228, 417);
            this.c349.Name = "c349";
            this.c349.Size = new System.Drawing.Size(200, 20);
            this.c349.TabIndex = 209;
            // 
            // lbl60
            // 
            this.lbl60.AutoSize = true;
            this.lbl60.Location = new System.Drawing.Point(35, 462);
            this.lbl60.Name = "lbl60";
            this.lbl60.Size = new System.Drawing.Size(391, 13);
            this.lbl60.TabIndex = 208;
            this.lbl60.Text = "2.3. Những thẻ bắt buộc còn lại được thanh toán               %,  nhưng không quá" +
                " :";
            this.lbl60.Visible = false;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(35, 441);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(498, 13);
            this.label93.TabIndex = 207;
            this.label93.Text = "2.2. Những thẻ được thanh toán 100 %                                             " +
                "                         , nhưng không quá :";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(35, 420);
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
            this.label92.Location = new System.Drawing.Point(5, 403);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(66, 13);
            this.label92.TabIndex = 205;
            this.label92.Text = "2. Nếu trên :";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(270, 390);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(232, 13);
            this.label91.TabIndex = 204;
            this.label91.Text = "(tùy theo ngày được hưởng dịch vụ ghi trên thẻ)";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(35, 390);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(235, 13);
            this.label90.TabIndex = 203;
            this.label90.Text = "1.2. Đối tượng tự nguyện được thanh toán 80 % ";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(35, 374);
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
            this.label88.Location = new System.Drawing.Point(3, 357);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(68, 13);
            this.label88.TabIndex = 201;
            this.label88.Text = "1. Nếu dưới :";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(18, 341);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(282, 13);
            this.label87.TabIndex = 199;
            this.label87.Text = "E15. Mức chi phí dịch vụ kỹ thuật cao bảo hiểm qui định :";
            // 
            // c347
            // 
            this.c347.Location = new System.Drawing.Point(3, 286);
            this.c347.Name = "c347";
            this.c347.Size = new System.Drawing.Size(309, 19);
            this.c347.TabIndex = 198;
            this.c347.Text = "E13 - Bảo hiểm quyết toán giá thuốc theo giá qui định";
            this.c347.CheckedChanged += new System.EventHandler(this.c347_CheckedChanged);
            // 
            // c345
            // 
            this.c345.Location = new System.Drawing.Point(3, 270);
            this.c345.Name = "c345";
            this.c345.Size = new System.Drawing.Size(371, 19);
            this.c345.TabIndex = 197;
            this.c345.Text = "E12 - Nhập số thẻ theo danh mục bảo hiểm cung cấp";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(195, 255);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(133, 13);
            this.label84.TabIndex = 196;
            this.label84.Text = "được hưởng tất cả dịch vụ";
            // 
            // c333
            // 
            this.c333.Location = new System.Drawing.Point(156, 252);
            this.c333.Name = "c333";
            this.c333.Size = new System.Drawing.Size(38, 20);
            this.c333.TabIndex = 195;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(122, 257);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(35, 13);
            this.label83.TabIndex = 194;
            this.label83.Text = "Vị trí :";
            // 
            // c332
            // 
            this.c332.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c332.Location = new System.Drawing.Point(65, 252);
            this.c332.Name = "c332";
            this.c332.Size = new System.Drawing.Size(57, 20);
            this.c332.TabIndex = 193;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(-1, 257);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(69, 13);
            this.label82.TabIndex = 192;
            this.label82.Text = "E11. Số thẻ :";
            // 
            // c321
            // 
            this.c321.Location = new System.Drawing.Point(3, 233);
            this.c321.Name = "c321";
            this.c321.Size = new System.Drawing.Size(310, 19);
            this.c321.TabIndex = 191;
            this.c321.Text = "E10. Người bệnh BHYT trong ngày chỉ khám 1 lần";
            // 
            // c362
            // 
            this.c362.Location = new System.Drawing.Point(327, 69);
            this.c362.Name = "c362";
            this.c362.Size = new System.Drawing.Size(318, 19);
            this.c362.TabIndex = 215;
            this.c362.Text = "E16 - Kiểm tra số thẻ và nơi đăng ký khám chữa bệnh";
            // 
            // p03_chuyenmon
            // 
            this.p03_chuyenmon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p03_chuyenmon.AutoScroll = true;
            this.p03_chuyenmon.Controls.Add(this.c50114);
            this.p03_chuyenmon.Controls.Add(this.c1513);
            this.p03_chuyenmon.Controls.Add(this.c1511);
            this.p03_chuyenmon.Controls.Add(this.c1509);
            this.p03_chuyenmon.Controls.Add(this.c1508);
            this.p03_chuyenmon.Controls.Add(this.c1507);
            this.p03_chuyenmon.Controls.Add(this.c1506);
            this.p03_chuyenmon.Controls.Add(this.c1104);
            this.p03_chuyenmon.Controls.Add(this.c1099);
            this.p03_chuyenmon.Controls.Add(this.c1098);
            this.p03_chuyenmon.Controls.Add(this.c1094);
            this.p03_chuyenmon.Controls.Add(this.butDichvu);
            this.p03_chuyenmon.Controls.Add(this.txtVienphi);
            this.p03_chuyenmon.Controls.Add(this.c1093);
            this.p03_chuyenmon.Controls.Add(this.c1092);
            this.p03_chuyenmon.Controls.Add(this.c1061);
            this.p03_chuyenmon.Controls.Add(this.c1051);
            this.p03_chuyenmon.Controls.Add(this.c1031);
            this.p03_chuyenmon.Controls.Add(this.c1026);
            this.p03_chuyenmon.Controls.Add(this.c1021);
            this.p03_chuyenmon.Controls.Add(this.c1020);
            this.p03_chuyenmon.Controls.Add(this.c1011);
            this.p03_chuyenmon.Controls.Add(this.c1010);
            this.p03_chuyenmon.Controls.Add(this.c1003);
            this.p03_chuyenmon.Controls.Add(this.c1001);
            this.p03_chuyenmon.Controls.Add(this.c430);
            this.p03_chuyenmon.Controls.Add(this.label110);
            this.p03_chuyenmon.Controls.Add(this.c425);
            this.p03_chuyenmon.Controls.Add(this.c424);
            this.p03_chuyenmon.Controls.Add(this.label109);
            this.p03_chuyenmon.Controls.Add(this.c423);
            this.p03_chuyenmon.Controls.Add(this.label108);
            this.p03_chuyenmon.Controls.Add(this.label107);
            this.p03_chuyenmon.Controls.Add(this.c422);
            this.p03_chuyenmon.Controls.Add(this.c408);
            this.p03_chuyenmon.Controls.Add(this.c406);
            this.p03_chuyenmon.Controls.Add(this.c405);
            this.p03_chuyenmon.Controls.Add(this.c404);
            this.p03_chuyenmon.Controls.Add(this.c393);
            this.p03_chuyenmon.Controls.Add(this.c385);
            this.p03_chuyenmon.Controls.Add(this.c373);
            this.p03_chuyenmon.Controls.Add(this.c361);
            this.p03_chuyenmon.Controls.Add(this.c354);
            this.p03_chuyenmon.Controls.Add(this.c344);
            this.p03_chuyenmon.Controls.Add(this.c330);
            this.p03_chuyenmon.Controls.Add(this.label35);
            this.p03_chuyenmon.Controls.Add(this.c139);
            this.p03_chuyenmon.Controls.Add(this.c329);
            this.p03_chuyenmon.Controls.Add(this.c327);
            this.p03_chuyenmon.Controls.Add(this.label80);
            this.p03_chuyenmon.Controls.Add(this.c325);
            this.p03_chuyenmon.Controls.Add(this.label81);
            this.p03_chuyenmon.Controls.Add(this.c324);
            this.p03_chuyenmon.Controls.Add(this.c323);
            this.p03_chuyenmon.Controls.Add(this.c322);
            this.p03_chuyenmon.Controls.Add(this.c315);
            this.p03_chuyenmon.Controls.Add(this.label74);
            this.p03_chuyenmon.Controls.Add(this.label66);
            this.p03_chuyenmon.Controls.Add(this.c305);
            this.p03_chuyenmon.Controls.Add(this.label65);
            this.p03_chuyenmon.Controls.Add(this.c296);
            this.p03_chuyenmon.Controls.Add(this.c295);
            this.p03_chuyenmon.Controls.Add(this.c193);
            this.p03_chuyenmon.Controls.Add(this.chandoan);
            this.p03_chuyenmon.Controls.Add(this.mmtn);
            this.p03_chuyenmon.Controls.Add(this.c55);
            this.p03_chuyenmon.Controls.Add(this.label48);
            this.p03_chuyenmon.Controls.Add(this.hhtn);
            this.p03_chuyenmon.Controls.Add(this.c126);
            this.p03_chuyenmon.Controls.Add(this.c130);
            this.p03_chuyenmon.Controls.Add(this.c153);
            this.p03_chuyenmon.Controls.Add(this.solieu);
            this.p03_chuyenmon.Controls.Add(this.c181);
            this.p03_chuyenmon.Controls.Add(this.c215);
            this.p03_chuyenmon.Controls.Add(this.c274);
            this.p03_chuyenmon.Controls.Add(this.c52);
            this.p03_chuyenmon.Controls.Add(this.c197);
            this.p03_chuyenmon.Controls.Add(this.c38);
            this.p03_chuyenmon.Controls.Add(this.khambenh);
            this.p03_chuyenmon.Controls.Add(this.c148);
            this.p03_chuyenmon.Controls.Add(this.c200);
            this.p03_chuyenmon.Controls.Add(this.c213);
            this.p03_chuyenmon.Controls.Add(this.c111);
            this.p03_chuyenmon.Controls.Add(this.noichuyen);
            this.p03_chuyenmon.Controls.Add(this.c116);
            this.p03_chuyenmon.Controls.Add(this.c100);
            this.p03_chuyenmon.Controls.Add(this.c160);
            this.p03_chuyenmon.Controls.Add(this.c105);
            this.p03_chuyenmon.Controls.Add(this.c259);
            this.p03_chuyenmon.Controls.Add(this.c167);
            this.p03_chuyenmon.Controls.Add(this.c252);
            this.p03_chuyenmon.Controls.Add(this.c250);
            this.p03_chuyenmon.Controls.Add(this.c172);
            this.p03_chuyenmon.Controls.Add(this.soluutru);
            this.p03_chuyenmon.Controls.Add(this.label36);
            this.p03_chuyenmon.Controls.Add(this.c127);
            this.p03_chuyenmon.Controls.Add(this.c106);
            this.p03_chuyenmon.Controls.Add(this.c118);
            this.p03_chuyenmon.Controls.Add(this.c162);
            this.p03_chuyenmon.Controls.Add(this.c245);
            this.p03_chuyenmon.Controls.Add(this.c36);
            this.p03_chuyenmon.Controls.Add(this.c276);
            this.p03_chuyenmon.Controls.Add(this.c54);
            this.p03_chuyenmon.Location = new System.Drawing.Point(157, 3);
            this.p03_chuyenmon.Name = "p03_chuyenmon";
            this.p03_chuyenmon.Size = new System.Drawing.Size(667, 509);
            this.p03_chuyenmon.TabIndex = 80;
            this.p03_chuyenmon.Visible = false;
            this.p03_chuyenmon.Paint += new System.Windows.Forms.PaintEventHandler(this.p03_Paint);
            // 
            // c50114
            // 
            this.c50114.Location = new System.Drawing.Point(1056, 256);
            this.c50114.Name = "c50114";
            this.c50114.Size = new System.Drawing.Size(348, 21);
            this.c50114.TabIndex = 323;
            this.c50114.Text = "C79 - In số thứ tự trong phiếu lĩnh trùng với số thứ tự trong phiếu công khai\r\n";
            // 
            // c1513
            // 
            this.c1513.Location = new System.Drawing.Point(1056, 237);
            this.c1513.Name = "c1513";
            this.c1513.Size = new System.Drawing.Size(348, 21);
            this.c1513.TabIndex = 322;
            this.c1513.Text = "C78 - Xuất thuốc tủ trực theo gói không cho phép sửa";
            this.c1513.CheckedChanged += new System.EventHandler(this.c1513_CheckedChanged);
            // 
            // c1511
            // 
            this.c1511.Location = new System.Drawing.Point(1056, 217);
            this.c1511.Name = "c1511";
            this.c1511.Size = new System.Drawing.Size(348, 21);
            this.c1511.TabIndex = 321;
            this.c1511.Text = "C77 - Không cho phép đăng kí nếu chưa hết ngày thuốc BHYT";
            // 
            // c1509
            // 
            this.c1509.Location = new System.Drawing.Point(1056, 198);
            this.c1509.Name = "c1509";
            this.c1509.Size = new System.Drawing.Size(348, 21);
            this.c1509.TabIndex = 320;
            this.c1509.Text = "C76 - Từ chối nhập viện nếu chưa thanh toán viện phí";
            // 
            // c1508
            // 
            this.c1508.Location = new System.Drawing.Point(1056, 180);
            this.c1508.Name = "c1508";
            this.c1508.Size = new System.Drawing.Size(348, 21);
            this.c1508.TabIndex = 319;
            this.c1508.Text = "C75 - Quản lí nhân viên sale";
            this.c1508.CheckedChanged += new System.EventHandler(this.c1508_CheckedChanged);
            // 
            // c1507
            // 
            this.c1507.Location = new System.Drawing.Point(1056, 163);
            this.c1507.Name = "c1507";
            this.c1507.Size = new System.Drawing.Size(350, 19);
            this.c1507.TabIndex = 318;
            this.c1507.Text = "C74 - Lấy chẩn đoán theo khoa cuối trong phiếu thanh toán ra viện";
            // 
            // c1506
            // 
            this.c1506.Location = new System.Drawing.Point(1056, 146);
            this.c1506.Name = "c1506";
            this.c1506.Size = new System.Drawing.Size(331, 19);
            this.c1506.TabIndex = 317;
            this.c1506.Text = "C73 - Không cho phép sửa chẩn đoán lúc in giấy chuyển viện.";
            // 
            // c1104
            // 
            this.c1104.AutoSize = true;
            this.c1104.Location = new System.Drawing.Point(1056, 130);
            this.c1104.Name = "c1104";
            this.c1104.Size = new System.Drawing.Size(201, 17);
            this.c1104.TabIndex = 315;
            this.c1104.Text = "C71 - Phát quà thôi nôi khi xuất khoa";
            this.c1104.UseVisualStyleBackColor = true;
            // 
            // c1099
            // 
            this.c1099.AutoSize = true;
            this.c1099.Location = new System.Drawing.Point(1056, 114);
            this.c1099.Name = "c1099";
            this.c1099.Size = new System.Drawing.Size(219, 17);
            this.c1099.TabIndex = 314;
            this.c1099.Text = "C70 - Thông báo số lưu trữ khi xuất khoa";
            this.c1099.UseVisualStyleBackColor = true;
            // 
            // c1098
            // 
            this.c1098.AutoSize = true;
            this.c1098.Location = new System.Drawing.Point(1056, 98);
            this.c1098.Name = "c1098";
            this.c1098.Size = new System.Drawing.Size(347, 17);
            this.c1098.TabIndex = 313;
            this.c1098.Text = "C69 - Thông báo số vào viện khi nhập khoa, khám bệnh, phòng lưu";
            this.c1098.UseVisualStyleBackColor = true;
            // 
            // c1094
            // 
            this.c1094.Location = new System.Drawing.Point(1337, 19);
            this.c1094.Name = "c1094";
            this.c1094.Size = new System.Drawing.Size(86, 20);
            this.c1094.TabIndex = 312;
            this.c1094.Visible = false;
            // 
            // butDichvu
            // 
            this.butDichvu.Location = new System.Drawing.Point(1299, 17);
            this.butDichvu.Name = "butDichvu";
            this.butDichvu.Size = new System.Drawing.Size(29, 23);
            this.butDichvu.TabIndex = 311;
            this.butDichvu.Text = "...";
            this.butDichvu.UseVisualStyleBackColor = true;
            this.butDichvu.Click += new System.EventHandler(this.butDichvu_Click);
            // 
            // txtVienphi
            // 
            this.txtVienphi.Location = new System.Drawing.Point(1056, 40);
            this.txtVienphi.Multiline = true;
            this.txtVienphi.Name = "txtVienphi";
            this.txtVienphi.ReadOnly = true;
            this.txtVienphi.Size = new System.Drawing.Size(366, 38);
            this.txtVienphi.TabIndex = 310;
            // 
            // c1093
            // 
            this.c1093.Location = new System.Drawing.Point(1056, 20);
            this.c1093.Name = "c1093";
            this.c1093.Size = new System.Drawing.Size(417, 20);
            this.c1093.TabIndex = 309;
            this.c1093.Text = "C68. Bệnh nhân tử vong bắt buộc có kết quả:";
            this.c1093.CheckedChanged += new System.EventHandler(this.c1093_CheckedChanged);
            // 
            // c1092
            // 
            this.c1092.Location = new System.Drawing.Point(1056, 3);
            this.c1092.Name = "c1092";
            this.c1092.Size = new System.Drawing.Size(417, 20);
            this.c1092.TabIndex = 308;
            this.c1092.Text = "C67. Chuyển phải qua duyệt khi chuyển sang bệnh viện ngoài danh sách";
            // 
            // c1061
            // 
            this.c1061.Location = new System.Drawing.Point(608, 463);
            this.c1061.Name = "c1061";
            this.c1061.Size = new System.Drawing.Size(417, 20);
            this.c1061.TabIndex = 307;
            this.c1061.Text = "C66. Biểu 02 không hiển thị khoa điều trị";
            // 
            // c1051
            // 
            this.c1051.Location = new System.Drawing.Point(608, 445);
            this.c1051.Name = "c1051";
            this.c1051.Size = new System.Drawing.Size(417, 20);
            this.c1051.TabIndex = 306;
            this.c1051.Text = "C65. Load lại thông tin quan hệ của lần đăng ký trước";
            // 
            // c1031
            // 
            this.c1031.Location = new System.Drawing.Point(608, 426);
            this.c1031.Name = "c1031";
            this.c1031.Size = new System.Drawing.Size(417, 20);
            this.c1031.TabIndex = 305;
            this.c1031.Text = "C64. Phòng lưu: kiểm tra thông tin chuyển viện trước khi in";
            // 
            // c1026
            // 
            this.c1026.Location = new System.Drawing.Point(608, 406);
            this.c1026.Name = "c1026";
            this.c1026.Size = new System.Drawing.Size(417, 20);
            this.c1026.TabIndex = 304;
            this.c1026.Text = "C63 - Phòng khám không được xử trí chuyển viện";
            // 
            // c1021
            // 
            this.c1021.Location = new System.Drawing.Point(624, 148);
            this.c1021.Name = "c1021";
            this.c1021.Size = new System.Drawing.Size(303, 19);
            this.c1021.TabIndex = 303;
            this.c1021.Text = "C51.2 - Lọc thuốc dự trù, tủ trực ... theo đối tượng";
            // 
            // c1020
            // 
            this.c1020.Checked = true;
            this.c1020.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1020.Location = new System.Drawing.Point(625, 130);
            this.c1020.Name = "c1020";
            this.c1020.Size = new System.Drawing.Size(269, 20);
            this.c1020.TabIndex = 302;
            this.c1020.Text = "C51.1 - Lọc thuốc cấp toa theo đối tượng";
            // 
            // c1011
            // 
            this.c1011.Location = new System.Drawing.Point(608, 386);
            this.c1011.Name = "c1011";
            this.c1011.Size = new System.Drawing.Size(417, 20);
            this.c1011.TabIndex = 301;
            this.c1011.Text = "C62 - Chẩn đoán nguyên nhân phải có trong ICD10";
            // 
            // c1010
            // 
            this.c1010.Location = new System.Drawing.Point(608, 367);
            this.c1010.Name = "c1010";
            this.c1010.Size = new System.Drawing.Size(417, 20);
            this.c1010.TabIndex = 300;
            this.c1010.Text = "C61 - Chẩn đoán kèm theo, nơi chuyển đến, phân biệt phải có trong ICD10";
            // 
            // c1003
            // 
            this.c1003.Location = new System.Drawing.Point(608, 348);
            this.c1003.Name = "c1003";
            this.c1003.Size = new System.Drawing.Size(417, 20);
            this.c1003.TabIndex = 299;
            this.c1003.Text = "C60-Phòng khám bắt buộc nhập xử trí khi có chẩn đoán chính";
            // 
            // c1001
            // 
            this.c1001.Location = new System.Drawing.Point(608, 329);
            this.c1001.Name = "c1001";
            this.c1001.Size = new System.Drawing.Size(417, 20);
            this.c1001.TabIndex = 298;
            this.c1001.Text = "C59-Phòng lưu kết thúc điều trị mới được phép cấp toa cho về";
            // 
            // c430
            // 
            this.c430.Location = new System.Drawing.Point(623, 308);
            this.c430.Name = "c430";
            this.c430.Size = new System.Drawing.Size(417, 20);
            this.c430.TabIndex = 297;
            this.c430.Text = "C58 - Cho phép phòng khám chỉnh sữa thông tin hành chánh";
            // 
            // label110
            // 
            this.label110.Location = new System.Drawing.Point(1007, 45);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(32, 16);
            this.label110.TabIndex = 296;
            this.label110.Text = "ngày";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c425
            // 
            this.c425.Location = new System.Drawing.Point(608, 288);
            this.c425.Name = "c425";
            this.c425.Size = new System.Drawing.Size(417, 20);
            this.c425.TabIndex = 296;
            this.c425.Text = "C57 - Nhập phòng khám sau khi nhập mã người bệnh con trỏ đến chẩn đoán";
            // 
            // c424
            // 
            this.c424.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c424.Location = new System.Drawing.Point(961, 42);
            this.c424.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c424.Name = "c424";
            this.c424.Size = new System.Drawing.Size(43, 21);
            this.c424.TabIndex = 295;
            this.c424.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(607, 45);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(358, 13);
            this.label109.TabIndex = 294;
            this.label109.Text = "C48.2 - Kết thúc điều trị ngoại trú khi bệnh nhân không quay lại tái khám : ";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c423
            // 
            this.c423.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c423.Location = new System.Drawing.Point(783, 264);
            this.c423.Name = "c423";
            this.c423.Size = new System.Drawing.Size(43, 21);
            this.c423.TabIndex = 291;
            this.c423.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(607, 269);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(178, 13);
            this.label108.TabIndex = 293;
            this.label108.Text = "C56 - Số ngày cho thuốc mặc định :";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label107
            // 
            this.label107.Location = new System.Drawing.Point(827, 263);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(32, 16);
            this.label107.TabIndex = 292;
            this.label107.Text = "ngày";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c422
            // 
            this.c422.Location = new System.Drawing.Point(607, 63);
            this.c422.Name = "c422";
            this.c422.Size = new System.Drawing.Size(374, 17);
            this.c422.TabIndex = 290;
            this.c422.Text = "C48.3 - Hiện danh sách vượt quá điều trị ngoại trú khi vào nhập bệnh án";
            // 
            // c408
            // 
            this.c408.Location = new System.Drawing.Point(608, 242);
            this.c408.Name = "c408";
            this.c408.Size = new System.Drawing.Size(329, 20);
            this.c408.TabIndex = 289;
            this.c408.Text = "Triệu chứng lâm sàng ban đầu :";
            // 
            // c406
            // 
            this.c406.Location = new System.Drawing.Point(608, 223);
            this.c406.Name = "c406";
            this.c406.Size = new System.Drawing.Size(364, 20);
            this.c406.TabIndex = 288;
            this.c406.Text = "C55 - Điều trị ngoại trú lọc theo bác sỹ";
            // 
            // c405
            // 
            this.c405.Location = new System.Drawing.Point(608, 203);
            this.c405.Name = "c405";
            this.c405.Size = new System.Drawing.Size(364, 20);
            this.c405.TabIndex = 287;
            this.c405.Text = "C54 - Đơn thuốc nhập bấm huyệt";
            // 
            // c404
            // 
            this.c404.Location = new System.Drawing.Point(608, 184);
            this.c404.Name = "c404";
            this.c404.Size = new System.Drawing.Size(364, 20);
            this.c404.TabIndex = 286;
            this.c404.Text = "C53 - Xử trí hẹn không cho phép in chi phí tại phòng khám";
            // 
            // c393
            // 
            this.c393.Location = new System.Drawing.Point(608, 165);
            this.c393.Name = "c393";
            this.c393.Size = new System.Drawing.Size(364, 20);
            this.c393.TabIndex = 285;
            this.c393.Text = "C52 + Người bệnh đang điều trị ngoại trú không cho nhập phòng khám";
            // 
            // c385
            // 
            this.c385.Location = new System.Drawing.Point(608, 113);
            this.c385.Name = "c385";
            this.c385.Size = new System.Drawing.Size(232, 20);
            this.c385.TabIndex = 284;
            this.c385.Text = "C51 + Lọc dịch vụ theo đối tượng chỉ định";
            // 
            // c373
            // 
            this.c373.Location = new System.Drawing.Point(5, 223);
            this.c373.Name = "c373";
            this.c373.Size = new System.Drawing.Size(345, 17);
            this.c373.TabIndex = 283;
            this.c373.Text = "C13 - Nhập tường trình phẩu thuật vắng tắt trong xuất khoa";
            // 
            // c361
            // 
            this.c361.Location = new System.Drawing.Point(608, 4);
            this.c361.Name = "c361";
            this.c361.Size = new System.Drawing.Size(364, 17);
            this.c361.TabIndex = 282;
            this.c361.Text = "C47 - Tiếp đón nhiều phòng khám cùng 1 lúc in chung chi phí điều trị";
            // 
            // c354
            // 
            this.c354.Location = new System.Drawing.Point(608, 81);
            this.c354.Name = "c354";
            this.c354.Size = new System.Drawing.Size(364, 17);
            this.c354.TabIndex = 281;
            this.c354.Text = "C49 - Chọn bác sỹ trong khám bệnh";
            // 
            // c344
            // 
            this.c344.Location = new System.Drawing.Point(360, 458);
            this.c344.Name = "c344";
            this.c344.Size = new System.Drawing.Size(221, 17);
            this.c344.TabIndex = 280;
            this.c344.Text = "C46 + Tiền sử bệnh nhập tự do";
            // 
            // c330
            // 
            this.c330.Location = new System.Drawing.Point(360, 442);
            this.c330.Name = "c330";
            this.c330.Size = new System.Drawing.Size(254, 17);
            this.c330.TabIndex = 279;
            this.c330.Text = "C45 - Khám bệnh nhập theo mẫu bệnh án";
            // 
            // c329
            // 
            this.c329.Location = new System.Drawing.Point(360, 425);
            this.c329.Name = "c329";
            this.c329.Size = new System.Drawing.Size(255, 17);
            this.c329.TabIndex = 278;
            this.c329.Text = "C44 + Toa thuốc && chỉ định lấy ngày hiện hành";
            // 
            // c327
            // 
            this.c327.Location = new System.Drawing.Point(360, 407);
            this.c327.Name = "c327";
            this.c327.Size = new System.Drawing.Size(249, 21);
            this.c327.TabIndex = 277;
            this.c327.Text = "C43 + Tiếp đón nhận bệnh điều trị ngoại trú";
            // 
            // label80
            // 
            this.label80.Location = new System.Drawing.Point(535, 389);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(32, 16);
            this.label80.TabIndex = 275;
            this.label80.Text = "ngày";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c325
            // 
            this.c325.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c325.Location = new System.Drawing.Point(488, 386);
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
            this.label81.Text = "C42. Hẹn tái khám tối đa";
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
            this.c323.Location = new System.Drawing.Point(532, 312);
            this.c323.Name = "c323";
            this.c323.Size = new System.Drawing.Size(104, 21);
            this.c323.TabIndex = 272;
            this.c323.Text = "- In phiếu hẹn";
            // 
            // c322
            // 
            this.c322.Location = new System.Drawing.Point(360, 312);
            this.c322.Name = "c322";
            this.c322.Size = new System.Drawing.Size(200, 21);
            this.c322.TabIndex = 271;
            this.c322.Text = "C41 + Tái khám nhập ngày hẹn";
            this.c322.CheckedChanged += new System.EventHandler(this.c322_CheckedChanged);
            // 
            // c315
            // 
            this.c315.CheckOnClick = true;
            this.c315.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c315.FormattingEnabled = true;
            this.c315.Location = new System.Drawing.Point(156, 419);
            this.c315.Name = "c315";
            this.c315.Size = new System.Drawing.Size(197, 52);
            this.c315.TabIndex = 270;
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(18, 416);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(179, 17);
            this.label74.TabIndex = 269;
            this.label74.Text = "C23. Chỉ được chuyển khoa";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(272, 396);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(32, 16);
            this.label66.TabIndex = 267;
            this.label66.Text = "lần";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c305
            // 
            this.c305.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c305.Location = new System.Drawing.Point(226, 393);
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
            this.label65.Location = new System.Drawing.Point(20, 395);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(207, 17);
            this.label65.TabIndex = 268;
            this.label65.Text = "C22. Số lần tái khám điều trị ngoại trú";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c296
            // 
            this.c296.Location = new System.Drawing.Point(5, 375);
            this.c296.Name = "c296";
            this.c296.Size = new System.Drawing.Size(348, 21);
            this.c296.TabIndex = 265;
            this.c296.Text = "C21 - Nhập thông tin bác sĩ, bệnh viện giới thiệu";
            this.c296.CheckedChanged += new System.EventHandler(this.c296_CheckedChanged);
            // 
            // c295
            // 
            this.c295.Location = new System.Drawing.Point(5, 355);
            this.c295.Name = "c295";
            this.c295.Size = new System.Drawing.Size(380, 21);
            this.c295.TabIndex = 264;
            this.c295.Text = "C20 - Cho phép nhập khám bệnh người bệnh đăng ký ngày hôm qua";
            // 
            // p12_khamsuckhoe
            // 
            this.p12_khamsuckhoe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p12_khamsuckhoe.AutoScroll = true;
            this.p12_khamsuckhoe.Controls.Add(this.butFile);
            this.p12_khamsuckhoe.Controls.Add(this.id);
            this.p12_khamsuckhoe.Controls.Add(this.butBoqua);
            this.p12_khamsuckhoe.Controls.Add(this.chophep);
            this.p12_khamsuckhoe.Controls.Add(this.butLuu);
            this.p12_khamsuckhoe.Controls.Add(this.butSua);
            this.p12_khamsuckhoe.Controls.Add(this.ten);
            this.p12_khamsuckhoe.Controls.Add(this.butThem);
            this.p12_khamsuckhoe.Controls.Add(this.label22);
            this.p12_khamsuckhoe.Controls.Add(this.label23);
            this.p12_khamsuckhoe.Controls.Add(this.dataGrid3);
            this.p12_khamsuckhoe.Controls.Add(this.dataGrid1);
            this.p12_khamsuckhoe.Location = new System.Drawing.Point(157, 3);
            this.p12_khamsuckhoe.Name = "p12_khamsuckhoe";
            this.p12_khamsuckhoe.Size = new System.Drawing.Size(663, 509);
            this.p12_khamsuckhoe.TabIndex = 81;
            this.p12_khamsuckhoe.Visible = false;
            // 
            // butFile
            // 
            this.butFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // p06_duoc
            // 
            this.p06_duoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p06_duoc.AutoScroll = true;
            this.p06_duoc.Controls.Add(this.c1260);
            this.p06_duoc.Controls.Add(this.c1512);
            this.p06_duoc.Controls.Add(this.C1503);
            this.p06_duoc.Controls.Add(this.c1100);
            this.p06_duoc.Controls.Add(this.c445);
            this.p06_duoc.Controls.Add(this.numSongaychotoa);
            this.p06_duoc.Controls.Add(this.label138);
            this.p06_duoc.Controls.Add(this.c1095);
            this.p06_duoc.Controls.Add(this.c1136);
            this.p06_duoc.Controls.Add(this.chkdmNhom);
            this.p06_duoc.Controls.Add(this.c1072);
            this.p06_duoc.Controls.Add(this.c1069);
            this.p06_duoc.Controls.Add(this.label133);
            this.p06_duoc.Controls.Add(this.c364);
            this.p06_duoc.Controls.Add(this.c1002);
            this.p06_duoc.Controls.Add(this.c1068);
            this.p06_duoc.Controls.Add(this.c1067);
            this.p06_duoc.Controls.Add(this.c1062);
            this.p06_duoc.Controls.Add(this.label130);
            this.p06_duoc.Controls.Add(this.c1055);
            this.p06_duoc.Controls.Add(this.c1048);
            this.p06_duoc.Controls.Add(this.c1030);
            this.p06_duoc.Controls.Add(this.label129);
            this.p06_duoc.Controls.Add(this.c191);
            this.p06_duoc.Controls.Add(this.c56);
            this.p06_duoc.Controls.Add(this.c420);
            this.p06_duoc.Controls.Add(this.c413);
            this.p06_duoc.Controls.Add(this.c402);
            this.p06_duoc.Controls.Add(this.c401);
            this.p06_duoc.Controls.Add(this.c400);
            this.p06_duoc.Controls.Add(this.c394);
            this.p06_duoc.Controls.Add(this.c300);
            this.p06_duoc.Controls.Add(this.c390);
            this.p06_duoc.Controls.Add(this.c389);
            this.p06_duoc.Controls.Add(this.label103);
            this.p06_duoc.Controls.Add(this.c383);
            this.p06_duoc.Controls.Add(this.c379);
            this.p06_duoc.Controls.Add(this.label102);
            this.p06_duoc.Controls.Add(this.c229);
            this.p06_duoc.Controls.Add(this.c165);
            this.p06_duoc.Controls.Add(this.c376);
            this.p06_duoc.Controls.Add(this.label101);
            this.p06_duoc.Controls.Add(this.c375);
            this.p06_duoc.Controls.Add(this.label100);
            this.p06_duoc.Controls.Add(this.c374);
            this.p06_duoc.Controls.Add(this.c363);
            this.p06_duoc.Controls.Add(this.dataGrid2);
            this.p06_duoc.Controls.Add(this.mml);
            this.p06_duoc.Controls.Add(this.c342);
            this.p06_duoc.Controls.Add(this.c137);
            this.p06_duoc.Controls.Add(this.c299);
            this.p06_duoc.Controls.Add(this.c298);
            this.p06_duoc.Controls.Add(this.label61);
            this.p06_duoc.Controls.Add(this.c297);
            this.p06_duoc.Controls.Add(this.c294);
            this.p06_duoc.Controls.Add(this.hhl);
            this.p06_duoc.Controls.Add(this.c293);
            this.p06_duoc.Controls.Add(this.c292);
            this.p06_duoc.Controls.Add(this.c291);
            this.p06_duoc.Controls.Add(this.label63);
            this.p06_duoc.Controls.Add(this.label62);
            this.p06_duoc.Controls.Add(this.label60);
            this.p06_duoc.Controls.Add(this.c282);
            this.p06_duoc.Controls.Add(this.c281);
            this.p06_duoc.Controls.Add(this.c166);
            this.p06_duoc.Controls.Add(this.c145);
            this.p06_duoc.Controls.Add(this.c147);
            this.p06_duoc.Controls.Add(this.c61);
            this.p06_duoc.Controls.Add(this.c156);
            this.p06_duoc.Controls.Add(this.c194);
            this.p06_duoc.Controls.Add(this.c198);
            this.p06_duoc.Controls.Add(this.c48);
            this.p06_duoc.Controls.Add(this.label51);
            this.p06_duoc.Controls.Add(this.c135);
            this.p06_duoc.Controls.Add(this.c261);
            this.p06_duoc.Controls.Add(this.label52);
            this.p06_duoc.Controls.Add(this.c260);
            this.p06_duoc.Controls.Add(this.label31);
            this.p06_duoc.Controls.Add(this.c184);
            this.p06_duoc.Controls.Add(this.hh);
            this.p06_duoc.Controls.Add(this.label32);
            this.p06_duoc.Controls.Add(this.c169);
            this.p06_duoc.Controls.Add(this.c186);
            this.p06_duoc.Controls.Add(this.mm);
            this.p06_duoc.Controls.Add(this.label45);
            this.p06_duoc.Controls.Add(this.mmt);
            this.p06_duoc.Controls.Add(this.c164);
            this.p06_duoc.Controls.Add(this.c244);
            this.p06_duoc.Controls.Add(this.label33);
            this.p06_duoc.Controls.Add(this.c233);
            this.p06_duoc.Controls.Add(this.c176);
            this.p06_duoc.Controls.Add(this.label46);
            this.p06_duoc.Controls.Add(this.label44);
            this.p06_duoc.Controls.Add(this.mmb);
            this.p06_duoc.Controls.Add(this.label38);
            this.p06_duoc.Controls.Add(this.hht);
            this.p06_duoc.Controls.Add(this.label43);
            this.p06_duoc.Controls.Add(this.hhb);
            this.p06_duoc.Controls.Add(this.label47);
            this.p06_duoc.Controls.Add(this.label42);
            this.p06_duoc.Controls.Add(this.c228);
            this.p06_duoc.Controls.Add(this.label40);
            this.p06_duoc.Controls.Add(this.c334);
            this.p06_duoc.Location = new System.Drawing.Point(157, 3);
            this.p06_duoc.Name = "p06_duoc";
            this.p06_duoc.Size = new System.Drawing.Size(663, 509);
            this.p06_duoc.TabIndex = 84;
            this.p06_duoc.Paint += new System.Windows.Forms.PaintEventHandler(this.p06_Paint);
            // 
            // c1260
            // 
            this.c1260.Location = new System.Drawing.Point(964, 279);
            this.c1260.Name = "c1260";
            this.c1260.Size = new System.Drawing.Size(330, 19);
            this.c1260.TabIndex = 312;
            this.c1260.Text = "F45. Cấp toa lọc theo danh mục phân loại";
            this.toolTip1.SetToolTip(this.c1260, "Check vào để chọn");
            // 
            // c1512
            // 
            this.c1512.Location = new System.Drawing.Point(964, 260);
            this.c1512.Name = "c1512";
            this.c1512.Size = new System.Drawing.Size(330, 19);
            this.c1512.TabIndex = 311;
            this.c1512.Text = "F44. Đơn thuốc F5 trừ tồn kho (F09)";
            this.toolTip1.SetToolTip(this.c1512, "Check vào để chọn");
            // 
            // C1503
            // 
            this.C1503.AutoSize = true;
            this.C1503.Location = new System.Drawing.Point(832, 387);
            this.C1503.Name = "C1503";
            this.C1503.Size = new System.Drawing.Size(206, 17);
            this.C1503.TabIndex = 310;
            this.C1503.Text = "F31.1 Chỉ áp dụng cho toa dược phát.";
            this.C1503.UseVisualStyleBackColor = true;
            // 
            // c1100
            // 
            this.c1100.Location = new System.Drawing.Point(964, 238);
            this.c1100.Name = "c1100";
            this.c1100.Size = new System.Drawing.Size(330, 19);
            this.c1100.TabIndex = 309;
            this.c1100.Text = "F43. Đơn thuốc dịch vụ được phép cấp nhiều lần trong ngày";
            this.toolTip1.SetToolTip(this.c1100, "Check vào để chọn");
            // 
            // c445
            // 
            this.c445.Location = new System.Drawing.Point(964, 214);
            this.c445.Name = "c445";
            this.c445.Size = new System.Drawing.Size(154, 19);
            this.c445.TabIndex = 308;
            this.c445.Text = "F42. Quản lý thuốc mổ";
            this.toolTip1.SetToolTip(this.c445, "Check vào để chọn");
            // 
            // numSongaychotoa
            // 
            this.numSongaychotoa.Location = new System.Drawing.Point(1232, 193);
            this.numSongaychotoa.Name = "numSongaychotoa";
            this.numSongaychotoa.Size = new System.Drawing.Size(39, 20);
            this.numSongaychotoa.TabIndex = 307;
            this.numSongaychotoa.Tag = "-1000";
            this.numSongaychotoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(963, 196);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(342, 13);
            this.label138.TabIndex = 306;
            this.label138.Text = "F41. Cảnh báo khi số ngày cho trong toa thuốc lớn hơn                 ngày";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c1095
            // 
            this.c1095.Location = new System.Drawing.Point(965, 172);
            this.c1095.Name = "c1095";
            this.c1095.Size = new System.Drawing.Size(279, 19);
            this.c1095.TabIndex = 305;
            this.c1095.Text = "F40. Cấp toa xong tự động lưu và kết thúc khám";
            this.toolTip1.SetToolTip(this.c1095, "Check vào để chọn");
            // 
            // c1136
            // 
            this.c1136.Location = new System.Drawing.Point(965, 86);
            this.c1136.Name = "c1136";
            this.c1136.Size = new System.Drawing.Size(279, 19);
            this.c1136.TabIndex = 304;
            this.c1136.Text = "F39. -Nhóm thuốc hướng tâm thần";
            this.toolTip1.SetToolTip(this.c1136, "Check vào để chọn");
            this.c1136.CheckedChanged += new System.EventHandler(this.c1100_CheckedChanged);
            // 
            // chkdmNhom
            // 
            this.chkdmNhom.FormattingEnabled = true;
            this.chkdmNhom.Location = new System.Drawing.Point(965, 105);
            this.chkdmNhom.Name = "chkdmNhom";
            this.chkdmNhom.Size = new System.Drawing.Size(226, 64);
            this.chkdmNhom.TabIndex = 0;
            // 
            // c1072
            // 
            this.c1072.Location = new System.Drawing.Point(965, 66);
            this.c1072.Name = "c1072";
            this.c1072.Size = new System.Drawing.Size(341, 19);
            this.c1072.TabIndex = 303;
            this.c1072.Text = "F38. -Dự trù tài sản trên cơ sở dữ liệu kho TTB mới";
            // 
            // c1069
            // 
            this.c1069.Location = new System.Drawing.Point(1216, 43);
            this.c1069.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.c1069.Name = "c1069";
            this.c1069.Size = new System.Drawing.Size(78, 20);
            this.c1069.TabIndex = 302;
            this.c1069.Tag = "F37";
            this.c1069.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1069.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(963, 47);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(250, 13);
            this.label133.TabIndex = 301;
            this.label133.Text = "F37. Cảnh báo khi số tiền cấp toa BHYT vượt quá :";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c364
            // 
            this.c364.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c364.Location = new System.Drawing.Point(4, 456);
            this.c364.Name = "c364";
            this.c364.Size = new System.Drawing.Size(358, 21);
            this.c364.TabIndex = 273;
            // 
            // c1002
            // 
            this.c1002.Location = new System.Drawing.Point(245, 439);
            this.c1002.Name = "c1002";
            this.c1002.Size = new System.Drawing.Size(150, 19);
            this.c1002.TabIndex = 291;
            this.c1002.Text = "F14.1. Phòng lưu";
            // 
            // c1068
            // 
            this.c1068.Location = new System.Drawing.Point(965, 25);
            this.c1068.Name = "c1068";
            this.c1068.Size = new System.Drawing.Size(341, 19);
            this.c1068.TabIndex = 300;
            this.c1068.Text = "F36. -Cấp toa lọc kho theo khai báo khoa phòng trong Dược";
            // 
            // c1067
            // 
            this.c1067.Location = new System.Drawing.Point(965, 6);
            this.c1067.Name = "c1067";
            this.c1067.Size = new System.Drawing.Size(341, 19);
            this.c1067.TabIndex = 299;
            this.c1067.Text = "F35. Cấp toa theo danh mục thuốc được phép kê toa";
            // 
            // c1062
            // 
            this.c1062.Location = new System.Drawing.Point(747, 461);
            this.c1062.Name = "c1062";
            this.c1062.Size = new System.Drawing.Size(50, 20);
            this.c1062.TabIndex = 298;
            this.c1062.Tag = "F35";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(619, 465);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(120, 13);
            this.label130.TabIndex = 297;
            this.label130.Text = "F35. Số lần in toa thuốc";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c1055
            // 
            this.c1055.Location = new System.Drawing.Point(619, 444);
            this.c1055.Name = "c1055";
            this.c1055.Size = new System.Drawing.Size(341, 19);
            this.c1055.TabIndex = 296;
            this.c1055.Text = "F34. Đối tượng khác BHYT không load thuốc BHYT";
            // 
            // c1048
            // 
            this.c1048.Location = new System.Drawing.Point(620, 426);
            this.c1048.Name = "c1048";
            this.c1048.Size = new System.Drawing.Size(341, 19);
            this.c1048.TabIndex = 295;
            this.c1048.Text = "F33. BN phòng lưu ra viện không cho phép xuất tủ trực";
            // 
            // c1030
            // 
            this.c1030.Location = new System.Drawing.Point(879, 405);
            this.c1030.Name = "c1030";
            this.c1030.Size = new System.Drawing.Size(50, 20);
            this.c1030.TabIndex = 294;
            this.c1030.Tag = "F32";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(617, 409);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(263, 13);
            this.label129.TabIndex = 293;
            this.label129.Text = "F32. Khoảng cách ngày cấp toa so với ngày khám là: ";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c191
            // 
            this.c191.CheckOnClick = true;
            this.c191.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c191.FormattingEnabled = true;
            this.c191.Location = new System.Drawing.Point(619, 31);
            this.c191.Name = "c191";
            this.c191.Size = new System.Drawing.Size(279, 84);
            this.c191.TabIndex = 292;
            // 
            // c420
            // 
            this.c420.Location = new System.Drawing.Point(620, 387);
            this.c420.Name = "c420";
            this.c420.Size = new System.Drawing.Size(217, 19);
            this.c420.TabIndex = 290;
            this.c420.Text = "F31. Đơn thuốc ngoại trú duyệt tự động.";
            this.c420.CheckedChanged += new System.EventHandler(this.c420_CheckedChanged);
            // 
            // c413
            // 
            this.c413.Location = new System.Drawing.Point(620, 369);
            this.c413.Name = "c413";
            this.c413.Size = new System.Drawing.Size(341, 19);
            this.c413.TabIndex = 289;
            this.c413.Text = "F30. Cho phép nhập hai mặt hàng giống trong dự trù, đơn thuốc";
            // 
            // c402
            // 
            this.c402.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c402.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c402.Location = new System.Drawing.Point(620, 346);
            this.c402.Name = "c402";
            this.c402.Size = new System.Drawing.Size(227, 21);
            this.c402.TabIndex = 288;
            // 
            // c401
            // 
            this.c401.CheckOnClick = true;
            this.c401.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c401.FormattingEnabled = true;
            this.c401.Location = new System.Drawing.Point(621, 260);
            this.c401.Name = "c401";
            this.c401.Size = new System.Drawing.Size(226, 84);
            this.c401.TabIndex = 287;
            this.c401.SelectedValueChanged += new System.EventHandler(this.c401_SelectedValueChanged);
            // 
            // c400
            // 
            this.c400.Location = new System.Drawing.Point(622, 243);
            this.c400.Name = "c400";
            this.c400.Size = new System.Drawing.Size(292, 19);
            this.c400.TabIndex = 286;
            this.c400.Text = "F29. Tự động duyệt phiếu dự trù sau khi chuyển xuống kho";
            this.c400.CheckedChanged += new System.EventHandler(this.c400_CheckedChanged);
            // 
            // c394
            // 
            this.c394.Location = new System.Drawing.Point(622, 227);
            this.c394.Name = "c394";
            this.c394.Size = new System.Drawing.Size(267, 19);
            this.c394.TabIndex = 285;
            this.c394.Text = "F28. Cho phép khoa sau hoàn trả";
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
            this.label103.Size = new System.Drawing.Size(308, 16);
            this.label103.TabIndex = 282;
            this.label103.Text = "F25 + Kho phát theo khai báo khoa phòng của dược";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c383
            // 
            this.c383.Location = new System.Drawing.Point(622, 211);
            this.c383.Name = "c383";
            this.c383.Size = new System.Drawing.Size(286, 19);
            this.c383.TabIndex = 281;
            this.c383.Text = "F27. Chọn thông số dược trong phẫu thủ thuật";
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
            this.c374.Size = new System.Drawing.Size(285, 19);
            this.c374.TabIndex = 274;
            this.c374.Text = "F24 - Phát thuốc phân theo kho và khoa phòng";
            this.c374.CheckedChanged += new System.EventHandler(this.c374_CheckedChanged);
            // 
            // c363
            // 
            this.c363.Location = new System.Drawing.Point(5, 439);
            this.c363.Name = "c363";
            this.c363.Size = new System.Drawing.Size(284, 19);
            this.c363.TabIndex = 272;
            this.c363.Text = "F14. Đơn thuốc xuất khoa cho về trừ tồn kho";
            this.c363.CheckedChanged += new System.EventHandler(this.c363_CheckedChanged);
            // 
            // c342
            // 
            this.c342.Location = new System.Drawing.Point(5, 422);
            this.c342.Name = "c342";
            this.c342.Size = new System.Drawing.Size(328, 19);
            this.c342.TabIndex = 267;
            this.c342.Text = "F13 - Đơn thuốc mua ngoài cho phép nhập ngoài tồn kho";
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
            this.c298.Location = new System.Drawing.Point(98, 346);
            this.c298.Name = "c298";
            this.c298.Size = new System.Drawing.Size(82, 21);
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
            this.c297.Size = new System.Drawing.Size(131, 20);
            this.c297.TabIndex = 261;
            this.c297.Text = "F12. Ngoại trú ";
            this.c297.CheckedChanged += new System.EventHandler(this.c297_CheckedChanged);
            // 
            // c294
            // 
            this.c294.Location = new System.Drawing.Point(318, 156);
            this.c294.Name = "c294";
            this.c294.Size = new System.Drawing.Size(300, 19);
            this.c294.TabIndex = 260;
            this.c294.Text = "F22 - Lĩnh thuốc ngoài giờ dựa vào ngày giờ y lệnh";
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
            this.label60.Text = "F01. Phiếu lĩnh ngoài giờ ngày thường sau :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c282
            // 
            this.c282.Location = new System.Drawing.Point(318, 139);
            this.c282.Name = "c282";
            this.c282.Size = new System.Drawing.Size(333, 19);
            this.c282.TabIndex = 250;
            this.c282.Text = "F21 + Đơn thuốc khám bệnh chỉ nhập 1 lần trong lần khám";
            // 
            // c281
            // 
            this.c281.Location = new System.Drawing.Point(318, 120);
            this.c281.Name = "c281";
            this.c281.Size = new System.Drawing.Size(300, 19);
            this.c281.TabIndex = 249;
            this.c281.Text = "F20 + Đơn thuốc khác ngày chỉ Admin mới in lại được";
            // 
            // c334
            // 
            this.c334.Location = new System.Drawing.Point(318, 174);
            this.c334.Name = "c334";
            this.c334.Size = new System.Drawing.Size(300, 19);
            this.c334.TabIndex = 266;
            this.c334.Text = "F23 - Điều trị nội trú có cấp đơn thuốc";
            // 
            // p07_vienphi
            // 
            this.p07_vienphi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p07_vienphi.AutoScroll = true;
            this.p07_vienphi.Controls.Add(this.c1105);
            this.p07_vienphi.Controls.Add(this.c284);
            this.p07_vienphi.Controls.Add(this.label150);
            this.p07_vienphi.Controls.Add(this.txtNgayBenhNhanThongTuLienTich);
            this.p07_vienphi.Controls.Add(this.cboNgayGiaVienPhiThongTuLienTich);
            this.p07_vienphi.Controls.Add(this.label151);
            this.p07_vienphi.Controls.Add(this.chkApDungThongTuLienTich15042012);
            this.p07_vienphi.Controls.Add(this.c418);
            this.p07_vienphi.Controls.Add(this.label106);
            this.p07_vienphi.Controls.Add(this.label105);
            this.p07_vienphi.Controls.Add(this.c395);
            this.p07_vienphi.Controls.Add(this.c238);
            this.p07_vienphi.Controls.Add(this.c237);
            this.p07_vienphi.Controls.Add(this.c384);
            this.p07_vienphi.Controls.Add(this.c1088);
            this.p07_vienphi.Controls.Add(this.c594);
            this.p07_vienphi.Controls.Add(this.label139);
            this.p07_vienphi.Controls.Add(this.c1501);
            this.p07_vienphi.Controls.Add(this.c1097);
            this.p07_vienphi.Controls.Add(this.c1096);
            this.p07_vienphi.Controls.Add(this.c1089);
            this.p07_vienphi.Controls.Add(this.c188);
            this.p07_vienphi.Controls.Add(this.c1059);
            this.p07_vienphi.Controls.Add(this.c1050);
            this.p07_vienphi.Controls.Add(this.c1044);
            this.p07_vienphi.Controls.Add(this.c1043);
            this.p07_vienphi.Controls.Add(this.c1042);
            this.p07_vienphi.Controls.Add(this.c1041);
            this.p07_vienphi.Controls.Add(this.c1039);
            this.p07_vienphi.Controls.Add(this.c1037);
            this.p07_vienphi.Controls.Add(this.c1036);
            this.p07_vienphi.Controls.Add(this.c1034);
            this.p07_vienphi.Controls.Add(this.c1024);
            this.p07_vienphi.Controls.Add(this.c1022);
            this.p07_vienphi.Controls.Add(this.c1012);
            this.p07_vienphi.Controls.Add(this.c263);
            this.p07_vienphi.Controls.Add(this.c1009);
            this.p07_vienphi.Controls.Add(this.c1006);
            this.p07_vienphi.Controls.Add(this.c1005);
            this.p07_vienphi.Controls.Add(this.c444);
            this.p07_vienphi.Controls.Add(this.c443);
            this.p07_vienphi.Controls.Add(this.c432);
            this.p07_vienphi.Controls.Add(this.c429);
            this.p07_vienphi.Controls.Add(this.label113);
            this.p07_vienphi.Controls.Add(this.c421);
            this.p07_vienphi.Controls.Add(this.c419);
            this.p07_vienphi.Controls.Add(this.c417);
            this.p07_vienphi.Controls.Add(this.c416);
            this.p07_vienphi.Controls.Add(this.c415);
            this.p07_vienphi.Controls.Add(this.c414);
            this.p07_vienphi.Controls.Add(this.c412);
            this.p07_vienphi.Controls.Add(this.c411);
            this.p07_vienphi.Controls.Add(this.c410);
            this.p07_vienphi.Controls.Add(this.c409);
            this.p07_vienphi.Controls.Add(this.c407);
            this.p07_vienphi.Controls.Add(this.c399);
            this.p07_vienphi.Controls.Add(this.c398);
            this.p07_vienphi.Controls.Add(this.c397);
            this.p07_vienphi.Controls.Add(this.label104);
            this.p07_vienphi.Controls.Add(this.c396);
            this.p07_vienphi.Controls.Add(this.c392);
            this.p07_vienphi.Controls.Add(this.c387);
            this.p07_vienphi.Controls.Add(this.c382);
            this.p07_vienphi.Controls.Add(this.c381);
            this.p07_vienphi.Controls.Add(this.c378);
            this.p07_vienphi.Controls.Add(this.c372);
            this.p07_vienphi.Controls.Add(this.label99);
            this.p07_vienphi.Controls.Add(this.c220);
            this.p07_vienphi.Controls.Add(this.c219);
            this.p07_vienphi.Controls.Add(this.c290);
            this.p07_vienphi.Controls.Add(this.c371);
            this.p07_vienphi.Controls.Add(this.c335);
            this.p07_vienphi.Controls.Add(this.c302);
            this.p07_vienphi.Controls.Add(this.c179);
            this.p07_vienphi.Controls.Add(this.c370);
            this.p07_vienphi.Controls.Add(this.c369);
            this.p07_vienphi.Controls.Add(this.c368);
            this.p07_vienphi.Controls.Add(this.label98);
            this.p07_vienphi.Controls.Add(this.c367);
            this.p07_vienphi.Controls.Add(this.c366);
            this.p07_vienphi.Controls.Add(this.label97);
            this.p07_vienphi.Controls.Add(this.label96);
            this.p07_vienphi.Controls.Add(this.c359);
            this.p07_vienphi.Controls.Add(this.label85);
            this.p07_vienphi.Controls.Add(this.c331);
            this.p07_vienphi.Controls.Add(this.c320);
            this.p07_vienphi.Controls.Add(this.c304);
            this.p07_vienphi.Controls.Add(this.c303);
            this.p07_vienphi.Controls.Add(this.c289);
            this.p07_vienphi.Controls.Add(this.c288);
            this.p07_vienphi.Controls.Add(this.c287);
            this.p07_vienphi.Controls.Add(this.c286);
            this.p07_vienphi.Controls.Add(this.label49);
            this.p07_vienphi.Controls.Add(this.label14);
            this.p07_vienphi.Controls.Add(this.c283);
            this.p07_vienphi.Controls.Add(this.c214);
            this.p07_vienphi.Controls.Add(this.c113);
            this.p07_vienphi.Controls.Add(this.c242);
            this.p07_vienphi.Controls.Add(this.c196);
            this.p07_vienphi.Controls.Add(this.c128);
            this.p07_vienphi.Controls.Add(this.c149);
            this.p07_vienphi.Controls.Add(this.c46);
            this.p07_vienphi.Controls.Add(this.label39);
            this.p07_vienphi.Controls.Add(this.c262);
            this.p07_vienphi.Controls.Add(this.c182);
            this.p07_vienphi.Controls.Add(this.c133);
            this.p07_vienphi.Controls.Add(this.c151);
            this.p07_vienphi.Controls.Add(this.c58);
            this.p07_vienphi.Controls.Add(this.c47);
            this.p07_vienphi.Controls.Add(this.c53);
            this.p07_vienphi.Controls.Add(this.c157);
            this.p07_vienphi.Controls.Add(this.c134);
            this.p07_vienphi.Controls.Add(this.c161);
            this.p07_vienphi.Controls.Add(this.c141);
            this.p07_vienphi.Controls.Add(this.c144);
            this.p07_vienphi.Controls.Add(this.c246);
            this.p07_vienphi.Controls.Add(this.c155);
            this.p07_vienphi.Controls.Add(this.c150);
            this.p07_vienphi.Controls.Add(this.c110);
            this.p07_vienphi.Controls.Add(this.c217);
            this.p07_vienphi.Controls.Add(this.c218);
            this.p07_vienphi.Controls.Add(this.c230);
            this.p07_vienphi.Controls.Add(this.c231);
            this.p07_vienphi.Controls.Add(this.c434);
            this.p07_vienphi.Controls.Add(this.c403);
            this.p07_vienphi.Controls.Add(this.label64);
            this.p07_vienphi.Controls.Add(this.c249);
            this.p07_vienphi.Controls.Add(this.c183);
            this.p07_vienphi.Controls.Add(this.c57);
            this.p07_vienphi.Controls.Add(this.c129);
            this.p07_vienphi.Controls.Add(this.c1502);
            this.p07_vienphi.Controls.Add(this.c446);
            this.p07_vienphi.Controls.Add(this.c595);
            this.p07_vienphi.Location = new System.Drawing.Point(157, 3);
            this.p07_vienphi.Name = "p07_vienphi";
            this.p07_vienphi.Size = new System.Drawing.Size(672, 508);
            this.p07_vienphi.TabIndex = 82;
            this.p07_vienphi.Visible = false;
            this.p07_vienphi.Paint += new System.Windows.Forms.PaintEventHandler(this.p07_Paint);
            // 
            // c1105
            // 
            this.c1105.AutoSize = true;
            this.c1105.Location = new System.Drawing.Point(1414, 456);
            this.c1105.Name = "c1105";
            this.c1105.Size = new System.Drawing.Size(249, 17);
            this.c1105.TabIndex = 360;
            this.c1105.Text = "G94 - Chi phí vượt tạm ứng không cho chỉ định";
            this.c1105.UseVisualStyleBackColor = true;
            // 
            // c284
            // 
            this.c284.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c284.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c284.Location = new System.Drawing.Point(99, 132);
            this.c284.Name = "c284";
            this.c284.Size = new System.Drawing.Size(158, 21);
            this.c284.TabIndex = 252;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(1461, 442);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(252, 13);
            this.label150.TabIndex = 359;
            this.label150.Text = "Áp dụng cho những bệnh nhân vào viện kể từ ngày";
            // 
            // txtNgayBenhNhanThongTuLienTich
            // 
            this.txtNgayBenhNhanThongTuLienTich.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgayBenhNhanThongTuLienTich.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayBenhNhanThongTuLienTich.Location = new System.Drawing.Point(1715, 437);
            this.txtNgayBenhNhanThongTuLienTich.Mask = "##/##/####";
            this.txtNgayBenhNhanThongTuLienTich.Name = "txtNgayBenhNhanThongTuLienTich";
            this.txtNgayBenhNhanThongTuLienTich.Size = new System.Drawing.Size(62, 21);
            this.txtNgayBenhNhanThongTuLienTich.TabIndex = 358;
            this.txtNgayBenhNhanThongTuLienTich.Tag = "\"\"";
            this.txtNgayBenhNhanThongTuLienTich.Text = "  /  /    ";
            this.txtNgayBenhNhanThongTuLienTich.Validating += new System.ComponentModel.CancelEventHandler(this.txtNgayBenhNhanThongTuLienTich_Validating);
            // 
            // cboNgayGiaVienPhiThongTuLienTich
            // 
            this.cboNgayGiaVienPhiThongTuLienTich.FormattingEnabled = true;
            this.cboNgayGiaVienPhiThongTuLienTich.Location = new System.Drawing.Point(1585, 418);
            this.cboNgayGiaVienPhiThongTuLienTich.Name = "cboNgayGiaVienPhiThongTuLienTich";
            this.cboNgayGiaVienPhiThongTuLienTich.Size = new System.Drawing.Size(83, 21);
            this.cboNgayGiaVienPhiThongTuLienTich.TabIndex = 357;
            this.cboNgayGiaVienPhiThongTuLienTich.Tag = "\"\"";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(1459, 422);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(117, 13);
            this.label151.TabIndex = 356;
            this.label151.Text = "Sử dụng bảng giá ngày";
            // 
            // chkApDungThongTuLienTich15042012
            // 
            this.chkApDungThongTuLienTich15042012.Location = new System.Drawing.Point(1413, 396);
            this.chkApDungThongTuLienTich15042012.Name = "chkApDungThongTuLienTich15042012";
            this.chkApDungThongTuLienTich15042012.Size = new System.Drawing.Size(292, 22);
            this.chkApDungThongTuLienTich15042012.TabIndex = 355;
            this.chkApDungThongTuLienTich15042012.Tag = "false";
            this.chkApDungThongTuLienTich15042012.Text = "G93. Áp dụng thông tư liên tịch ngày 15/04/2012";
            this.toolTip1.SetToolTip(this.chkApDungThongTuLienTich15042012, "Làm tròn đơn giá 2 ký tự và làm tròn tổng tiền 3 ký tự đối với đối tượng khác BHY" +
                    "T ");
            this.chkApDungThongTuLienTich15042012.CheckedChanged += new System.EventHandler(this.chkApDungThongTuLienTich15042012_CheckedChanged);
            // 
            // c418
            // 
            this.c418.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c418.Location = new System.Drawing.Point(1111, 282);
            this.c418.Name = "c418";
            this.c418.Size = new System.Drawing.Size(200, 21);
            this.c418.TabIndex = 305;
            // 
            // label106
            // 
            this.label106.Location = new System.Drawing.Point(1027, 284);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(94, 17);
            this.label106.TabIndex = 346;
            this.label106.Text = "Phẫu thủ thuật :";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label105
            // 
            this.label105.Location = new System.Drawing.Point(1027, 261);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(58, 17);
            this.label105.TabIndex = 345;
            this.label105.Text = "Khoa :";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c395
            // 
            this.c395.ForeColor = System.Drawing.Color.Red;
            this.c395.Location = new System.Drawing.Point(453, 455);
            this.c395.Name = "c395";
            this.c395.Size = new System.Drawing.Size(112, 20);
            this.c395.TabIndex = 344;
            this.c395.Text = "G47.Thu trực tiếp";
            this.c395.Visible = false;
            // 
            // c384
            // 
            this.c384.Location = new System.Drawing.Point(523, 82);
            this.c384.Name = "c384";
            this.c384.Size = new System.Drawing.Size(157, 19);
            this.c384.TabIndex = 343;
            this.c384.Text = "G30.Khai báo danh mục";
            // 
            // c1088
            // 
            this.c1088.Location = new System.Drawing.Point(540, 25);
            this.c1088.Name = "c1088";
            this.c1088.Size = new System.Drawing.Size(119, 19);
            this.c1088.TabIndex = 342;
            this.c1088.Text = "G27.1 giá phụ thu";
            // 
            // c594
            // 
            this.c594.FormattingEnabled = true;
            this.c594.Location = new System.Drawing.Point(1528, 326);
            this.c594.Name = "c594";
            this.c594.Size = new System.Drawing.Size(149, 21);
            this.c594.TabIndex = 339;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(1429, 329);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(95, 13);
            this.label139.TabIndex = 338;
            this.label139.Text = "G89. Nhóm bác sĩ";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c1501
            // 
            this.c1501.Location = new System.Drawing.Point(232, 299);
            this.c1501.Name = "c1501";
            this.c1501.Size = new System.Drawing.Size(86, 19);
            this.c1501.TabIndex = 337;
            this.c1501.Text = "Thu phí";
            // 
            // c1097
            // 
            this.c1097.Location = new System.Drawing.Point(1413, 307);
            this.c1097.Name = "c1097";
            this.c1097.Size = new System.Drawing.Size(430, 22);
            this.c1097.TabIndex = 336;
            this.c1097.Text = "G88. Chênh lệch công khám lúc đăng ký cho phép nhân viên chọn";
            // 
            // c1096
            // 
            this.c1096.Location = new System.Drawing.Point(1431, 128);
            this.c1096.Name = "c1096";
            this.c1096.Size = new System.Drawing.Size(395, 33);
            this.c1096.TabIndex = 335;
            this.c1096.Text = "G79.2. BN BHYT đăng ký nhiều phòng khám (hay đăng ký nhiều lần trong ngày), BH ch" +
                "ỉ trả 1 công khám, CÒN LẠI TÍNH THEO ĐT TỰ NGUYỆN (G26)";
            this.c1096.Click += new System.EventHandler(this.c1096_Click);
            // 
            // c1089
            // 
            this.c1089.Location = new System.Drawing.Point(1413, 290);
            this.c1089.Name = "c1089";
            this.c1089.Size = new System.Drawing.Size(430, 22);
            this.c1089.TabIndex = 334;
            this.c1089.Text = "G87. BN tái khám do dị ứng thuốc được miễn phụ thu tiền khám";
            // 
            // c1059
            // 
            this.c1059.Location = new System.Drawing.Point(1431, 99);
            this.c1059.Name = "c1059";
            this.c1059.Size = new System.Drawing.Size(351, 33);
            this.c1059.TabIndex = 332;
            this.c1059.Text = "G79.1. BN BHYT đăng ký nhiều phòng khám (hay đăng ký nhiều lần trong ngày), BH ch" +
                "ỉ trả 1 công khám, CÒN LẠI KHÔNG TÍNH";
            this.c1059.Click += new System.EventHandler(this.c1059_Click);
            // 
            // c1050
            // 
            this.c1050.Location = new System.Drawing.Point(1413, 272);
            this.c1050.Name = "c1050";
            this.c1050.Size = new System.Drawing.Size(430, 22);
            this.c1050.TabIndex = 331;
            this.c1050.Text = "G86. (-) Tính chênh lệch ở khu khám vào ngày nghỉ (T7,CN,lễ tết)";
            // 
            // c1044
            // 
            this.c1044.Location = new System.Drawing.Point(1413, 254);
            this.c1044.Name = "c1044";
            this.c1044.Size = new System.Drawing.Size(430, 22);
            this.c1044.TabIndex = 330;
            this.c1044.Text = "G85. BN chưa làm thủ tục thanh toán ra viện, không cho in giấy ra viện";
            // 
            // c1043
            // 
            this.c1043.Location = new System.Drawing.Point(1413, 237);
            this.c1043.Name = "c1043";
            this.c1043.Size = new System.Drawing.Size(430, 22);
            this.c1043.TabIndex = 329;
            this.c1043.Text = "G84. BN chưa làm thủ tục thanh toán ra viện đợt trước, không cho nhập viện";
            // 
            // c1042
            // 
            this.c1042.Location = new System.Drawing.Point(1413, 223);
            this.c1042.Name = "c1042";
            this.c1042.Size = new System.Drawing.Size(430, 17);
            this.c1042.TabIndex = 328;
            this.c1042.Text = "G83. BN chưa làm thủ tục thanh toán ra viện đợt trước, không cho đăng ký khám bện" +
                "h";
            // 
            // c1041
            // 
            this.c1041.Location = new System.Drawing.Point(1413, 205);
            this.c1041.Name = "c1041";
            this.c1041.Size = new System.Drawing.Size(351, 22);
            this.c1041.TabIndex = 327;
            this.c1041.Text = "G82. In phiếu TTRV (mẫu 38) đầy đủ";
            // 
            // c1039
            // 
            this.c1039.Location = new System.Drawing.Point(1413, 188);
            this.c1039.Name = "c1039";
            this.c1039.Size = new System.Drawing.Size(351, 22);
            this.c1039.TabIndex = 326;
            this.c1039.Text = "G81. Khám từ PK thứ 2 tính giá tái khám";
            // 
            // c1037
            // 
            this.c1037.Location = new System.Drawing.Point(1413, 159);
            this.c1037.Name = "c1037";
            this.c1037.Size = new System.Drawing.Size(351, 33);
            this.c1037.TabIndex = 325;
            this.c1037.Text = "G80. Dịch vụ, vật tư, thuốc BHYT chi trả dưới 100%, phần còn lại tính vào đối tượ" +
                "ng thu phí";
            // 
            // c1036
            // 
            this.c1036.Location = new System.Drawing.Point(1413, 68);
            this.c1036.Name = "c1036";
            this.c1036.Size = new System.Drawing.Size(351, 33);
            this.c1036.TabIndex = 324;
            this.c1036.Text = "G79. BN BHYT đăng ký nhiều phòng khám (hay đăng ký nhiều lần trong ngày), BH chỉ " +
                "trả 1 công khám, còn lại chuyển thu phí";
            this.c1036.Click += new System.EventHandler(this.c1036_Click);
            // 
            // c1034
            // 
            this.c1034.Location = new System.Drawing.Point(1413, 39);
            this.c1034.Name = "c1034";
            this.c1034.Size = new System.Drawing.Size(366, 31);
            this.c1034.TabIndex = 323;
            this.c1034.Text = "G78. BN BHYT, miễn: Chuyển khám tính công khám đối tượng thu phí (Enabled khi G60" +
                ".1 được check)";
            this.toolTip1.SetToolTip(this.c1034, "chỉ Enabled khi G60.1 được check");
            // 
            // c1024
            // 
            this.c1024.Enabled = false;
            this.c1024.Location = new System.Drawing.Point(911, 114);
            this.c1024.Name = "c1024";
            this.c1024.Size = new System.Drawing.Size(114, 19);
            this.c1024.TabIndex = 322;
            this.c1024.Text = "G54.1-Bỏ Thu phí";
            // 
            // c1022
            // 
            this.c1022.Location = new System.Drawing.Point(1413, 17);
            this.c1022.Name = "c1022";
            this.c1022.Size = new System.Drawing.Size(351, 19);
            this.c1022.TabIndex = 321;
            this.c1022.Text = "G77. TTRV tổng hợp tất cả biên lai tạm ứng chưa hoàn";
            // 
            // c1012
            // 
            this.c1012.Location = new System.Drawing.Point(1413, 0);
            this.c1012.Name = "c1012";
            this.c1012.Size = new System.Drawing.Size(351, 19);
            this.c1012.TabIndex = 320;
            this.c1012.Text = "G76. Phòng khám in chi phí điều trị gom cả chi phí phòng lưu";
            // 
            // c1009
            // 
            this.c1009.Location = new System.Drawing.Point(1029, 457);
            this.c1009.Name = "c1009";
            this.c1009.Size = new System.Drawing.Size(335, 19);
            this.c1009.TabIndex = 318;
            this.c1009.Text = "G75 - In tên hoạt chất TRƯỚC trong phiếu thanh toán ra viện";
            // 
            // c1006
            // 
            this.c1006.Location = new System.Drawing.Point(1029, 440);
            this.c1006.Name = "c1006";
            this.c1006.Size = new System.Drawing.Size(408, 18);
            this.c1006.TabIndex = 317;
            this.c1006.Text = "G74 - Thanh toán BHYT tại phòng lưu như phòng khám khi BN không nhập viện";
            // 
            // c1005
            // 
            this.c1005.Location = new System.Drawing.Point(1029, 422);
            this.c1005.Name = "c1005";
            this.c1005.Size = new System.Drawing.Size(341, 19);
            this.c1005.TabIndex = 316;
            this.c1005.Text = "G73 - BHYT, Miễn: Chuyển khám tính chênh lệnh công khám";
            // 
            // c444
            // 
            this.c444.Location = new System.Drawing.Point(1029, 404);
            this.c444.Name = "c444";
            this.c444.Size = new System.Drawing.Size(380, 19);
            this.c444.TabIndex = 315;
            this.c444.Text = "G72 - Yêu cầu bệnh nhân phòng khám đóng tiền tạm ứng khi chưa đóng";
            // 
            // c443
            // 
            this.c443.Location = new System.Drawing.Point(1029, 386);
            this.c443.Name = "c443";
            this.c443.Size = new System.Drawing.Size(346, 19);
            this.c443.TabIndex = 314;
            this.c443.Text = "G71 - Thanh toán BHYT tại nội trú theo cách tính phòng khám";
            // 
            // c432
            // 
            this.c432.Location = new System.Drawing.Point(1029, 369);
            this.c432.Name = "c432";
            this.c432.Size = new System.Drawing.Size(343, 19);
            this.c432.TabIndex = 312;
            this.c432.Text = "G70 - Chỉ định khám chuyên khoa chuyển vào danh sách chờ đóng tiền";
            // 
            // c429
            // 
            this.c429.Location = new System.Drawing.Point(1203, 344);
            this.c429.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.c429.Name = "c429";
            this.c429.Size = new System.Drawing.Size(108, 20);
            this.c429.TabIndex = 311;
            this.c429.Tag = "G69";
            // 
            // label113
            // 
            this.label113.Location = new System.Drawing.Point(1026, 346);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(180, 17);
            this.label113.TabIndex = 310;
            this.label113.Text = "G69. Thông báo số tiền tạm ứng <=";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c421
            // 
            this.c421.Location = new System.Drawing.Point(1029, 324);
            this.c421.Name = "c421";
            this.c421.Size = new System.Drawing.Size(343, 19);
            this.c421.TabIndex = 309;
            this.c421.Text = "G68 - Phiếu thanh toán ra viện xuất ra nhiều giá";
            // 
            // c419
            // 
            this.c419.Location = new System.Drawing.Point(1029, 307);
            this.c419.Name = "c419";
            this.c419.Size = new System.Drawing.Size(343, 19);
            this.c419.TabIndex = 308;
            this.c419.Text = "G67 - Tái khám in chi phí riêng trong khám bệnh";
            // 
            // c417
            // 
            this.c417.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c417.Location = new System.Drawing.Point(1111, 259);
            this.c417.Name = "c417";
            this.c417.Size = new System.Drawing.Size(200, 21);
            this.c417.TabIndex = 304;
            // 
            // c416
            // 
            this.c416.CheckOnClick = true;
            this.c416.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c416.FormattingEnabled = true;
            this.c416.Location = new System.Drawing.Point(1029, 156);
            this.c416.Name = "c416";
            this.c416.Size = new System.Drawing.Size(282, 100);
            this.c416.TabIndex = 303;
            this.c416.SelectedValueChanged += new System.EventHandler(this.c416_SelectedValueChanged);
            // 
            // c415
            // 
            this.c415.CheckOnClick = true;
            this.c415.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c415.FormattingEnabled = true;
            this.c415.Location = new System.Drawing.Point(1029, 102);
            this.c415.Name = "c415";
            this.c415.Size = new System.Drawing.Size(282, 52);
            this.c415.TabIndex = 302;
            this.c415.SelectedValueChanged += new System.EventHandler(this.c415_SelectedValueChanged);
            // 
            // c414
            // 
            this.c414.Location = new System.Drawing.Point(1029, 84);
            this.c414.Name = "c414";
            this.c414.Size = new System.Drawing.Size(346, 19);
            this.c414.TabIndex = 301;
            this.c414.Text = "G66 - Khoán vật tư tiêu hao theo khoa, phẫu thủ thuật";
            this.c414.CheckedChanged += new System.EventHandler(this.c414_CheckedChanged);
            // 
            // c412
            // 
            this.c412.Location = new System.Drawing.Point(1029, 65);
            this.c412.Name = "c412";
            this.c412.Size = new System.Drawing.Size(346, 19);
            this.c412.TabIndex = 300;
            this.c412.Text = "G65 - Phòng khám xử trí tái khám chuyển vào danh sách chờ đóng tiền";
            // 
            // c411
            // 
            this.c411.CheckOnClick = true;
            this.c411.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c411.FormattingEnabled = true;
            this.c411.Location = new System.Drawing.Point(661, 421);
            this.c411.Name = "c411";
            this.c411.Size = new System.Drawing.Size(282, 52);
            this.c411.TabIndex = 299;
            this.c411.SelectedValueChanged += new System.EventHandler(this.c411_SelectedValueChanged);
            // 
            // c410
            // 
            this.c410.Location = new System.Drawing.Point(662, 404);
            this.c410.Name = "c410";
            this.c410.Size = new System.Drawing.Size(346, 19);
            this.c410.TabIndex = 298;
            this.c410.Text = "G63 - Không tính công khám khi xử trí nhập viện";
            this.c410.CheckedChanged += new System.EventHandler(this.c410_CheckedChanged);
            // 
            // c409
            // 
            this.c409.Location = new System.Drawing.Point(662, 386);
            this.c409.Name = "c409";
            this.c409.Size = new System.Drawing.Size(346, 19);
            this.c409.TabIndex = 297;
            this.c409.Text = "G62 - Sữa khoa phòng trong sữa đối tượng dịch vụ";
            // 
            // c407
            // 
            this.c407.Location = new System.Drawing.Point(663, 367);
            this.c407.Name = "c407";
            this.c407.Size = new System.Drawing.Size(346, 19);
            this.c407.TabIndex = 296;
            this.c407.Text = "G61 - Phiếu thanh toán dịch vụ in kèm giá gốc";
            // 
            // c399
            // 
            this.c399.Location = new System.Drawing.Point(663, 331);
            this.c399.Name = "c399";
            this.c399.Size = new System.Drawing.Size(346, 19);
            this.c399.TabIndex = 294;
            this.c399.Text = "G59 - Thanh toán BHYT tại ngoại trú theo cách tính phòng khám";
            // 
            // c398
            // 
            this.c398.Location = new System.Drawing.Point(663, 314);
            this.c398.Name = "c398";
            this.c398.Size = new System.Drawing.Size(346, 19);
            this.c398.TabIndex = 293;
            this.c398.Text = "G58 - Thanh toán BHYT tại phòng lưu theo cách tính phòng khám";
            // 
            // c397
            // 
            this.c397.CheckOnClick = true;
            this.c397.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c397.FormattingEnabled = true;
            this.c397.Location = new System.Drawing.Point(663, 210);
            this.c397.Name = "c397";
            this.c397.Size = new System.Drawing.Size(282, 100);
            this.c397.TabIndex = 292;
            this.c397.SelectedValueChanged += new System.EventHandler(this.c397_SelectedValueChanged);
            // 
            // label104
            // 
            this.label104.Location = new System.Drawing.Point(659, 169);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(260, 17);
            this.label104.TabIndex = 291;
            this.label104.Text = "G57 - Tự động chuyển vào chỉ định khi đăng ký";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c396
            // 
            this.c396.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c396.Location = new System.Drawing.Point(663, 187);
            this.c396.Name = "c396";
            this.c396.Size = new System.Drawing.Size(282, 21);
            this.c396.TabIndex = 290;
            // 
            // c392
            // 
            this.c392.Location = new System.Drawing.Point(661, 151);
            this.c392.Name = "c392";
            this.c392.Size = new System.Drawing.Size(278, 19);
            this.c392.TabIndex = 288;
            this.c392.Text = "G56 + Phòng lưu chuyển khám không tính tiền khám";
            // 
            // c387
            // 
            this.c387.Location = new System.Drawing.Point(661, 133);
            this.c387.Name = "c387";
            this.c387.Size = new System.Drawing.Size(278, 19);
            this.c387.TabIndex = 287;
            this.c387.Text = "G55 - Giá trọn gói tính theo đối tượng";
            // 
            // c382
            // 
            this.c382.Location = new System.Drawing.Point(661, 115);
            this.c382.Name = "c382";
            this.c382.Size = new System.Drawing.Size(278, 19);
            this.c382.TabIndex = 285;
            this.c382.Text = "G54 - Đưa chi phí khám bệnh vào nội ngoại trú";
            this.c382.CheckedChanged += new System.EventHandler(this.c382_CheckedChanged);
            // 
            // c381
            // 
            this.c381.Location = new System.Drawing.Point(434, 42);
            this.c381.Name = "c381";
            this.c381.Size = new System.Drawing.Size(146, 19);
            this.c381.TabIndex = 284;
            this.c381.Text = "G28 - Thu trực tiếp";
            // 
            // c378
            // 
            this.c378.Location = new System.Drawing.Point(319, 101);
            this.c378.Name = "c378";
            this.c378.Size = new System.Drawing.Size(331, 19);
            this.c378.TabIndex = 282;
            this.c378.Text = "G31 +Miễn giảm công khám, phần chênh lệch BN tự thanh toán";
            this.c378.CheckedChanged += new System.EventHandler(this.c378_CheckedChanged);
            // 
            // c372
            // 
            this.c372.Location = new System.Drawing.Point(139, 403);
            this.c372.Name = "c372";
            this.c372.Size = new System.Drawing.Size(162, 20);
            this.c372.TabIndex = 280;
            // 
            // label99
            // 
            this.label99.Location = new System.Drawing.Point(21, 404);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(120, 17);
            this.label99.TabIndex = 281;
            this.label99.Text = "G22. Nội dung hao phí :";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c290
            // 
            this.c290.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c290.Location = new System.Drawing.Point(319, 365);
            this.c290.Name = "c290";
            this.c290.Size = new System.Drawing.Size(308, 21);
            this.c290.TabIndex = 261;
            // 
            // c371
            // 
            this.c371.Location = new System.Drawing.Point(6, 385);
            this.c371.Name = "c371";
            this.c371.Size = new System.Drawing.Size(347, 19);
            this.c371.TabIndex = 279;
            this.c371.Text = "G21 - In hao phí chung đối tượng vào trong phiếu thanh toán";
            // 
            // c335
            // 
            this.c335.Location = new System.Drawing.Point(376, 62);
            this.c335.Name = "c335";
            this.c335.Size = new System.Drawing.Size(240, 20);
            this.c335.TabIndex = 268;
            // 
            // c302
            // 
            this.c302.Location = new System.Drawing.Point(319, 43);
            this.c302.Name = "c302";
            this.c302.Size = new System.Drawing.Size(99, 19);
            this.c302.TabIndex = 262;
            this.c302.Text = "Theo đối tượng";
            // 
            // c370
            // 
            this.c370.Location = new System.Drawing.Point(7, 22);
            this.c370.Name = "c370";
            this.c370.Size = new System.Drawing.Size(328, 20);
            this.c370.TabIndex = 278;
            this.c370.Text = "G02 + BHYT, Miễn, Trả sau chuyển công khám vào chỉ định";
            // 
            // c369
            // 
            this.c369.Location = new System.Drawing.Point(6, 459);
            this.c369.Name = "c369";
            this.c369.Size = new System.Drawing.Size(475, 19);
            this.c369.TabIndex = 277;
            this.c369.Text = "G25 - Người bệnh BHYT, tiếp đón cùng 1 lúc nhiều phòng khám in chung chi phí điều" +
                " trị";
            // 
            // c368
            // 
            this.c368.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c368.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c368.Location = new System.Drawing.Point(512, 161);
            this.c368.Name = "c368";
            this.c368.Size = new System.Drawing.Size(115, 21);
            this.c368.TabIndex = 276;
            // 
            // label98
            // 
            this.label98.Location = new System.Drawing.Point(321, 163);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(247, 17);
            this.label98.TabIndex = 275;
            this.label98.Text = "G34.In phiếu thanh toán vào đối tượng :";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c367
            // 
            this.c367.Location = new System.Drawing.Point(463, 140);
            this.c367.Name = "c367";
            this.c367.Size = new System.Drawing.Size(162, 20);
            this.c367.TabIndex = 274;
            // 
            // c366
            // 
            this.c366.Location = new System.Drawing.Point(406, 120);
            this.c366.Name = "c366";
            this.c366.Size = new System.Drawing.Size(41, 20);
            this.c366.TabIndex = 273;
            // 
            // label97
            // 
            this.label97.Location = new System.Drawing.Point(321, 120);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(333, 17);
            this.label97.TabIndex = 272;
            this.label97.Text = "G32. Miễn giảm                 %, phần chênh lệch BN tự thanh toán";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.Location = new System.Drawing.Point(321, 142);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(161, 17);
            this.label96.TabIndex = 271;
            this.label96.Text = "G33 - Nhập nơi làm việc là :";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c359
            // 
            this.c359.Location = new System.Drawing.Point(319, 82);
            this.c359.Name = "c359";
            this.c359.Size = new System.Drawing.Size(213, 19);
            this.c359.TabIndex = 270;
            this.c359.Text = "G29 - Chênh lệch giá thuốc,vật tư y tế";
            this.c359.CheckedChanged += new System.EventHandler(this.c359_CheckedChanged);
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(321, 62);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(120, 17);
            this.label85.TabIndex = 269;
            this.label85.Text = "Nội dung :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c331
            // 
            this.c331.Location = new System.Drawing.Point(661, 41);
            this.c331.Name = "c331";
            this.c331.Size = new System.Drawing.Size(295, 19);
            this.c331.TabIndex = 267;
            this.c331.Text = "G50 + Hiện đơn giá trong liệt kê chỉ định + viện phí khoa";
            // 
            // c320
            // 
            this.c320.AutoSize = true;
            this.c320.Location = new System.Drawing.Point(216, 102);
            this.c320.Name = "c320";
            this.c320.Size = new System.Drawing.Size(90, 17);
            this.c320.TabIndex = 266;
            this.c320.Text = "G07 - In 1 lần";
            this.c320.UseVisualStyleBackColor = true;
            // 
            // c304
            // 
            this.c304.Location = new System.Drawing.Point(176, 41);
            this.c304.Name = "c304";
            this.c304.Size = new System.Drawing.Size(157, 20);
            this.c304.TabIndex = 265;
            this.c304.Text = "G03.a-In biên lai miễn phí";
            // 
            // c303
            // 
            this.c303.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c303.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c303.Location = new System.Drawing.Point(440, 428);
            this.c303.Name = "c303";
            this.c303.Size = new System.Drawing.Size(187, 21);
            this.c303.TabIndex = 264;
            this.c303.Tag = "G46";
            // 
            // c289
            // 
            this.c289.Location = new System.Drawing.Point(319, 347);
            this.c289.Name = "c289";
            this.c289.Size = new System.Drawing.Size(313, 19);
            this.c289.TabIndex = 260;
            this.c289.Text = "G44 - Công khám ngoại trú chuyển vào chi phí điều trị";
            this.c289.CheckedChanged += new System.EventHandler(this.c289_CheckedChanged);
            // 
            // c288
            // 
            this.c288.Location = new System.Drawing.Point(661, 4);
            this.c288.Name = "c288";
            this.c288.Size = new System.Drawing.Size(329, 20);
            this.c288.TabIndex = 259;
            this.c288.Text = "G48 + Phục hồi bệnh án khi hủy số liệu chuyển xuống viện phí";
            // 
            // c287
            // 
            this.c287.Location = new System.Drawing.Point(6, 40);
            this.c287.Name = "c287";
            this.c287.Size = new System.Drawing.Size(254, 20);
            this.c287.TabIndex = 258;
            this.c287.Text = "G03 - Ký hiệu biên lai theo máy";
            // 
            // c286
            // 
            this.c286.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c286.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c286.Location = new System.Drawing.Point(99, 154);
            this.c286.Name = "c286";
            this.c286.Size = new System.Drawing.Size(158, 21);
            this.c286.TabIndex = 254;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(9, 156);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(120, 17);
            this.label49.TabIndex = 256;
            this.label49.Text = "Sang đối tượng :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 17);
            this.label14.TabIndex = 255;
            this.label14.Text = "Đối tượng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c283
            // 
            this.c283.Location = new System.Drawing.Point(6, 113);
            this.c283.Name = "c283";
            this.c283.Size = new System.Drawing.Size(283, 21);
            this.c283.TabIndex = 251;
            this.c283.Text = "G08 - Chuyển đối tượng trong đăng ký";
            this.c283.CheckedChanged += new System.EventHandler(this.c283_CheckedChanged);
            // 
            // c434
            // 
            this.c434.Location = new System.Drawing.Point(917, 349);
            this.c434.Name = "c434";
            this.c434.Size = new System.Drawing.Size(119, 19);
            this.c434.TabIndex = 313;
            this.c434.Text = "G60.1.BHYT,Miễn";
            this.toolTip1.SetToolTip(this.c434, "Các đối tượng BHYT, Miễn khi chuyển khám tính công khám");
            this.c434.CheckedChanged += new System.EventHandler(this.c434_CheckedChanged);
            // 
            // c403
            // 
            this.c403.Location = new System.Drawing.Point(663, 348);
            this.c403.Name = "c403";
            this.c403.Size = new System.Drawing.Size(269, 19);
            this.c403.TabIndex = 295;
            this.c403.Text = "G60 + Đối tượng thu phí chuyển khám tính công";
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(309, 429);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(140, 17);
            this.label64.TabIndex = 263;
            this.label64.Text = "G46. Nhóm viện phí thuốc :";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c1502
            // 
            this.c1502.Location = new System.Drawing.Point(1413, 379);
            this.c1502.Name = "c1502";
            this.c1502.Size = new System.Drawing.Size(477, 22);
            this.c1502.TabIndex = 347;
            this.c1502.Text = "G92. BN trái tuyến BHYT không chi trả(Theo qui định BHYT dành cho BV tư nhân từ n" +
                "gày 15/02/2012)";
            this.toolTip1.SetToolTip(this.c1502, "Áp dụng công thức tính chênh lệch");
            // 
            // c446
            // 
            this.c446.Location = new System.Drawing.Point(1413, 361);
            this.c446.Name = "c446";
            this.c446.Size = new System.Drawing.Size(292, 22);
            this.c446.TabIndex = 341;
            this.c446.Text = "G91. Áp dụng công thức tính chênh lệch công khám";
            this.toolTip1.SetToolTip(this.c446, "Áp dụng công thức tính chênh lệch");
            this.c446.CheckedChanged += new System.EventHandler(this.c446_CheckedChanged);
            // 
            // c595
            // 
            this.c595.Location = new System.Drawing.Point(1413, 344);
            this.c595.Name = "c595";
            this.c595.Size = new System.Drawing.Size(292, 22);
            this.c595.TabIndex = 340;
            this.c595.Text = "G90. Làm tròn đơn giá toa thuốc mua ngoài";
            this.toolTip1.SetToolTip(this.c595, "Làm tròn đơn giá 2 ký tự và làm tròn tổng tiền 3 ký tự đối với đối tượng khác BHY" +
                    "T ");
            // 
            // p10_phonggiuong
            // 
            this.p10_phonggiuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p10_phonggiuong.AutoScroll = true;
            this.p10_phonggiuong.Controls.Add(this.c1103);
            this.p10_phonggiuong.Controls.Add(this.c1102);
            this.p10_phonggiuong.Controls.Add(this.c1071);
            this.p10_phonggiuong.Controls.Add(this.c278);
            this.p10_phonggiuong.Controls.Add(this.c1070);
            this.p10_phonggiuong.Controls.Add(this.c1057);
            this.p10_phonggiuong.Controls.Add(this.c234);
            this.p10_phonggiuong.Controls.Add(this.c377);
            this.p10_phonggiuong.Controls.Add(this.c280);
            this.p10_phonggiuong.Controls.Add(this.c279);
            this.p10_phonggiuong.Controls.Add(this.c247);
            this.p10_phonggiuong.Controls.Add(this.c236);
            this.p10_phonggiuong.Controls.Add(this.label54);
            this.p10_phonggiuong.Controls.Add(this.c235);
            this.p10_phonggiuong.Location = new System.Drawing.Point(157, 3);
            this.p10_phonggiuong.Name = "p10_phonggiuong";
            this.p10_phonggiuong.Size = new System.Drawing.Size(3102, 475);
            this.p10_phonggiuong.TabIndex = 88;
            this.p10_phonggiuong.Visible = false;
            // 
            // c1103
            // 
            this.c1103.Location = new System.Drawing.Point(33, 240);
            this.c1103.Name = "c1103";
            this.c1103.Size = new System.Drawing.Size(342, 32);
            this.c1103.TabIndex = 241;
            this.c1103.Text = "J10.1 Nếu ngày phẫu thuật hoặc ngày sanh trừ ngày vào khoa <1 thì không tính";
            // 
            // c1102
            // 
            this.c1102.Location = new System.Drawing.Point(6, 217);
            this.c1102.Name = "c1102";
            this.c1102.Size = new System.Drawing.Size(392, 19);
            this.c1102.TabIndex = 240;
            this.c1102.Text = "J10. Tính tiền giường tự động theo bảng giá của BHYT";
            this.c1102.CheckedChanged += new System.EventHandler(this.c1102_CheckedChanged);
            // 
            // c1071
            // 
            this.c1071.Location = new System.Drawing.Point(6, 198);
            this.c1071.Name = "c1071";
            this.c1071.Size = new System.Drawing.Size(392, 19);
            this.c1071.TabIndex = 239;
            this.c1071.Text = "J09. Tính tiền giường lúc đặt giường";
            // 
            // c278
            // 
            this.c278.Location = new System.Drawing.Point(6, 85);
            this.c278.Name = "c278";
            this.c278.Size = new System.Drawing.Size(444, 19);
            this.c278.TabIndex = 233;
            this.c278.Text = "J05 - Giường dịch vụ <12 giờ tính nữa ngày, Giường thường ngày ra-ngày vào";
            this.c278.CheckedChanged += new System.EventHandler(this.c278_CheckedChanged);
            // 
            // c1070
            // 
            this.c1070.Location = new System.Drawing.Point(6, 99);
            this.c1070.Name = "c1070";
            this.c1070.Size = new System.Drawing.Size(444, 36);
            this.c1070.TabIndex = 238;
            this.c1070.Text = "J05.1 - Giường thường ngày ra-ngày vào, Giường dịch vụ tính thêm 0.5 ngày khi: Và" +
                "o sáng, ra sáng hoặc vào chiều ra chiều; tính thêm 1 ngày: vào sáng ra chiều";
            this.c1070.CheckedChanged += new System.EventHandler(this.c1070_CheckedChanged);
            // 
            // c1057
            // 
            this.c1057.Location = new System.Drawing.Point(6, 179);
            this.c1057.Name = "c1057";
            this.c1057.Size = new System.Drawing.Size(392, 19);
            this.c1057.TabIndex = 237;
            this.c1057.Text = "J08 - Bệnh nhân khoa A, có thể nằm giường khoa B (do hết giường khoa A)";
            // 
            // c377
            // 
            this.c377.Location = new System.Drawing.Point(6, 160);
            this.c377.Name = "c377";
            this.c377.Size = new System.Drawing.Size(392, 19);
            this.c377.TabIndex = 236;
            this.c377.Text = "J07 - Theo bệnh án";
            // 
            // c280
            // 
            this.c280.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c280.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c280.Location = new System.Drawing.Point(178, 137);
            this.c280.Name = "c280";
            this.c280.Size = new System.Drawing.Size(244, 21);
            this.c280.TabIndex = 235;
            // 
            // c279
            // 
            this.c279.Location = new System.Drawing.Point(6, 139);
            this.c279.Name = "c279";
            this.c279.Size = new System.Drawing.Size(344, 19);
            this.c279.TabIndex = 234;
            this.c279.Text = "J06. Đối tượng phòng dịch vụ";
            this.c279.CheckedChanged += new System.EventHandler(this.c279_CheckedChanged);
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(570, 514);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(17, 17);
            this.label59.TabIndex = 257;
            this.label59.Text = "Viện phí :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label59.Visible = false;
            // 
            // p08_CLS
            // 
            this.p08_CLS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p08_CLS.AutoScroll = true;
            this.p08_CLS.Controls.Add(this.c1261);
            this.p08_CLS.Controls.Add(this.c1505);
            this.p08_CLS.Controls.Add(this.c1101);
            this.p08_CLS.Controls.Add(this.c1084);
            this.p08_CLS.Controls.Add(this.c1083);
            this.p08_CLS.Controls.Add(this.c1082);
            this.p08_CLS.Controls.Add(this.c1081);
            this.p08_CLS.Controls.Add(this.c1079);
            this.p08_CLS.Controls.Add(this.c1078);
            this.p08_CLS.Controls.Add(this.c1052);
            this.p08_CLS.Controls.Add(this.c1049);
            this.p08_CLS.Controls.Add(this.c1040);
            this.p08_CLS.Controls.Add(this.c1035);
            this.p08_CLS.Controls.Add(this.c1025);
            this.p08_CLS.Controls.Add(this.c440);
            this.p08_CLS.Controls.Add(this.c391);
            this.p08_CLS.Controls.Add(this.c388);
            this.p08_CLS.Controls.Add(this.c339);
            this.p08_CLS.Controls.Add(this.label86);
            this.p08_CLS.Controls.Add(this.c338);
            this.p08_CLS.Controls.Add(this.c337);
            this.p08_CLS.Controls.Add(this.c336);
            this.p08_CLS.Controls.Add(this.c328);
            this.p08_CLS.Controls.Add(this.c326);
            this.p08_CLS.Controls.Add(this.c199);
            this.p08_CLS.Controls.Add(this.c251);
            this.p08_CLS.Controls.Add(this.c60);
            this.p08_CLS.Controls.Add(this.c439);
            this.p08_CLS.Location = new System.Drawing.Point(157, 3);
            this.p08_CLS.Name = "p08_CLS";
            this.p08_CLS.Size = new System.Drawing.Size(672, 509);
            this.p08_CLS.TabIndex = 85;
            this.p08_CLS.Visible = false;
            // 
            // c1261
            // 
            this.c1261.AutoSize = true;
            this.c1261.Checked = true;
            this.c1261.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1261.Location = new System.Drawing.Point(398, 121);
            this.c1261.Name = "c1261";
            this.c1261.Size = new System.Drawing.Size(275, 17);
            this.c1261.TabIndex = 261;
            this.c1261.Text = "H27. Chi phí vượt tạm ứng không cho thực hiện CLS";
            this.c1261.UseVisualStyleBackColor = true;
            // 
            // c1505
            // 
            this.c1505.AutoSize = true;
            this.c1505.Location = new System.Drawing.Point(9, 467);
            this.c1505.Name = "c1505";
            this.c1505.Size = new System.Drawing.Size(332, 17);
            this.c1505.TabIndex = 260;
            this.c1505.Text = "H26 - Chuyển CLS và thông tin người bệnh sang chi nhánh khác";
            this.c1505.UseVisualStyleBackColor = true;
            // 
            // c1101
            // 
            this.c1101.AutoSize = true;
            this.c1101.Location = new System.Drawing.Point(9, 450);
            this.c1101.Name = "c1101";
            this.c1101.Size = new System.Drawing.Size(263, 17);
            this.c1101.TabIndex = 259;
            this.c1101.Text = "H25 - In số thứ tự thực hiện CLS theo loại viện phí";
            this.c1101.UseVisualStyleBackColor = true;
            // 
            // c1084
            // 
            this.c1084.Location = new System.Drawing.Point(9, 432);
            this.c1084.Name = "c1084";
            this.c1084.Size = new System.Drawing.Size(378, 19);
            this.c1084.TabIndex = 258;
            this.c1084.Text = "H24 - Kiểm tra dịch vụ kéo dài nhiều ngày để yêu cầu làm HSBA ngoại trú";
            // 
            // c1083
            // 
            this.c1083.Location = new System.Drawing.Point(9, 413);
            this.c1083.Name = "c1083";
            this.c1083.Size = new System.Drawing.Size(375, 19);
            this.c1083.TabIndex = 257;
            this.c1083.Text = "H23 - Kiểm tra dịch vụ có xâm lấn để yêu cầu làm HSBA ngoại trú";
            // 
            // c1082
            // 
            this.c1082.Location = new System.Drawing.Point(9, 395);
            this.c1082.Name = "c1082";
            this.c1082.Size = new System.Drawing.Size(375, 19);
            this.c1082.TabIndex = 256;
            this.c1082.Text = "H22 - Kiểm tra dịch vụ cần giấy cam đoan";
            // 
            // c1081
            // 
            this.c1081.Location = new System.Drawing.Point(9, 376);
            this.c1081.Name = "c1081";
            this.c1081.Size = new System.Drawing.Size(375, 19);
            this.c1081.TabIndex = 255;
            this.c1081.Text = "H21 - Kiểm tra dịch vụ cần biên bản hội chẩn";
            // 
            // c1079
            // 
            this.c1079.Location = new System.Drawing.Point(9, 357);
            this.c1079.Name = "c1079";
            this.c1079.Size = new System.Drawing.Size(375, 19);
            this.c1079.TabIndex = 254;
            this.c1079.Text = "H20 - Kiểm tra các chỉ định không phù hợp";
            // 
            // c1078
            // 
            this.c1078.Location = new System.Drawing.Point(9, 338);
            this.c1078.Name = "c1078";
            this.c1078.Size = new System.Drawing.Size(375, 19);
            this.c1078.TabIndex = 253;
            this.c1078.Text = "H19 (-) Cận lâm sàng phân biệt giá trong giờ, ngoài giờ";
            // 
            // c1052
            // 
            this.c1052.Location = new System.Drawing.Point(9, 318);
            this.c1052.Name = "c1052";
            this.c1052.Size = new System.Drawing.Size(375, 19);
            this.c1052.TabIndex = 252;
            this.c1052.Text = "H18. (+) Chỉ có quản trị mới được phép in phiếu chỉ định ngày trước";
            // 
            // c1049
            // 
            this.c1049.Location = new System.Drawing.Point(9, 298);
            this.c1049.Name = "c1049";
            this.c1049.Size = new System.Drawing.Size(375, 19);
            this.c1049.TabIndex = 251;
            this.c1049.Text = "H17. (-) Đã duyệt chi phí mẫu 38 không được chỉ định CLS [G42]";
            this.c1049.CheckedChanged += new System.EventHandler(this.c1049_CheckedChanged);
            // 
            // c1040
            // 
            this.c1040.Checked = true;
            this.c1040.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1040.Location = new System.Drawing.Point(9, 278);
            this.c1040.Name = "c1040";
            this.c1040.Size = new System.Drawing.Size(346, 19);
            this.c1040.TabIndex = 250;
            this.c1040.Text = "H16. Liệt kê danh mục dịch vụ kèm giá";
            // 
            // c1035
            // 
            this.c1035.Location = new System.Drawing.Point(9, 257);
            this.c1035.Name = "c1035";
            this.c1035.Size = new System.Drawing.Size(346, 19);
            this.c1035.TabIndex = 249;
            this.c1035.Text = "H15. (-) Khi ra phòng lưu không được phép chỉ định";
            // 
            // c1025
            // 
            this.c1025.Location = new System.Drawing.Point(9, 237);
            this.c1025.Name = "c1025";
            this.c1025.Size = new System.Drawing.Size(346, 19);
            this.c1025.TabIndex = 248;
            this.c1025.Text = "H14. (-) Đã in không được hủy phiếu chỉ định";
            // 
            // c440
            // 
            this.c440.Location = new System.Drawing.Point(9, 218);
            this.c440.Name = "c440";
            this.c440.Size = new System.Drawing.Size(346, 19);
            this.c440.TabIndex = 247;
            this.c440.Text = "H13 (-) Chọn ngày chỉ định trong phòng lưu";
            // 
            // c391
            // 
            this.c391.Location = new System.Drawing.Point(9, 178);
            this.c391.Name = "c391";
            this.c391.Size = new System.Drawing.Size(346, 19);
            this.c391.TabIndex = 245;
            this.c391.Text = "H10 (-) Chỉ định theo loại viện phí";
            // 
            // c388
            // 
            this.c388.Location = new System.Drawing.Point(9, 160);
            this.c388.Name = "c388";
            this.c388.Size = new System.Drawing.Size(346, 19);
            this.c388.TabIndex = 244;
            this.c388.Text = "H09 + Duyệt dịch vụ cận lâm sàng thực hiện";
            // 
            // c339
            // 
            this.c339.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.c339.Location = new System.Drawing.Point(258, 137);
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
            this.label86.Location = new System.Drawing.Point(18, 140);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(233, 13);
            this.label86.TabIndex = 242;
            this.label86.Text = "H08. Thời gian tự động đọc tin nhắn âm thanh :";
            // 
            // c338
            // 
            this.c338.Location = new System.Drawing.Point(9, 117);
            this.c338.Name = "c338";
            this.c338.Size = new System.Drawing.Size(346, 19);
            this.c338.TabIndex = 241;
            this.c338.Text = "H07 + Chỉ định nội trú đóng tiền trước khi thực hiện";
            // 
            // c337
            // 
            this.c337.Location = new System.Drawing.Point(9, 99);
            this.c337.Name = "c337";
            this.c337.Size = new System.Drawing.Size(346, 19);
            this.c337.TabIndex = 240;
            this.c337.Text = "H06 + Chỉ định ngoại trú đóng tiền trước khi thực hiện";
            // 
            // c336
            // 
            this.c336.Location = new System.Drawing.Point(9, 25);
            this.c336.Name = "c336";
            this.c336.Size = new System.Drawing.Size(346, 19);
            this.c336.TabIndex = 239;
            this.c336.Text = "H02 + Gửi tin nhắn âm thanh sau khi chỉ định";
            // 
            // c328
            // 
            this.c328.Location = new System.Drawing.Point(9, 80);
            this.c328.Name = "c328";
            this.c328.Size = new System.Drawing.Size(346, 19);
            this.c328.TabIndex = 238;
            this.c328.Text = "H05 - Bắt buộc nhập chẩn đoán và bác sỹ trong chỉ định";
            // 
            // c326
            // 
            this.c326.Location = new System.Drawing.Point(9, 61);
            this.c326.Name = "c326";
            this.c326.Size = new System.Drawing.Size(346, 19);
            this.c326.TabIndex = 237;
            this.c326.Text = "H04 - Chỉ định xuất ra File.TXT";
            // 
            // c439
            // 
            this.c439.Location = new System.Drawing.Point(9, 199);
            this.c439.Name = "c439";
            this.c439.Size = new System.Drawing.Size(346, 19);
            this.c439.TabIndex = 246;
            this.c439.Text = "H12 (-) In số phiếu trong chỉ định";
            // 
            // p09_phauthuthuat
            // 
            this.p09_phauthuthuat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p09_phauthuthuat.AutoScroll = true;
            this.p09_phauthuthuat.Controls.Add(this.c254);
            this.p09_phauthuthuat.Controls.Add(this.c1504);
            this.p09_phauthuthuat.Controls.Add(this.c143);
            this.p09_phauthuthuat.Controls.Add(this.c1033);
            this.p09_phauthuthuat.Controls.Add(this.c1032);
            this.p09_phauthuthuat.Controls.Add(this.c1004);
            this.p09_phauthuthuat.Controls.Add(this.pttt);
            this.p09_phauthuthuat.Controls.Add(this.c146);
            this.p09_phauthuthuat.Controls.Add(this.c158);
            this.p09_phauthuthuat.Controls.Add(this.c1433);
            this.p09_phauthuthuat.Controls.Add(this.label37);
            this.p09_phauthuthuat.Controls.Add(this.c159);
            this.p09_phauthuthuat.Controls.Add(this.c253);
            this.p09_phauthuthuat.Location = new System.Drawing.Point(157, 3);
            this.p09_phauthuthuat.Name = "p09_phauthuthuat";
            this.p09_phauthuthuat.Size = new System.Drawing.Size(663, 509);
            this.p09_phauthuthuat.TabIndex = 86;
            this.p09_phauthuthuat.Visible = false;
            // 
            // c254
            // 
            this.c254.FormattingEnabled = true;
            this.c254.Location = new System.Drawing.Point(27, 96);
            this.c254.Name = "c254";
            this.c254.Size = new System.Drawing.Size(274, 109);
            this.c254.TabIndex = 245;
            this.c254.Tag = "I05";
            // 
            // c1504
            // 
            this.c1504.Location = new System.Drawing.Point(7, 283);
            this.c1504.Name = "c1504";
            this.c1504.Size = new System.Drawing.Size(331, 19);
            this.c1504.TabIndex = 244;
            this.c1504.Text = "I10 - Ngoại trú được phép nhập phẩu thuật.";
            // 
            // c143
            // 
            this.c143.FormattingEnabled = true;
            this.c143.Location = new System.Drawing.Point(364, 93);
            this.c143.Name = "c143";
            this.c143.Size = new System.Drawing.Size(274, 109);
            this.c143.TabIndex = 243;
            this.c143.Tag = "I06";
            // 
            // c1033
            // 
            this.c1033.Enabled = false;
            this.c1033.Location = new System.Drawing.Point(7, 266);
            this.c1033.Name = "c1033";
            this.c1033.Size = new System.Drawing.Size(331, 19);
            this.c1033.TabIndex = 242;
            this.c1033.Text = "I09 - Chênh lệch giá với BHYT cũng tính miễn giảm theo";
            // 
            // c1032
            // 
            this.c1032.Location = new System.Drawing.Point(7, 249);
            this.c1032.Name = "c1032";
            this.c1032.Size = new System.Drawing.Size(331, 19);
            this.c1032.TabIndex = 241;
            this.c1032.Text = "I08 - Nhập PTTT trong viện khoa, chỉ định có nhập miễn giảm";
            this.c1032.CheckedChanged += new System.EventHandler(this.c1032_CheckedChanged);
            // 
            // c1004
            // 
            this.c1004.Location = new System.Drawing.Point(7, 231);
            this.c1004.Name = "c1004";
            this.c1004.Size = new System.Drawing.Size(331, 19);
            this.c1004.TabIndex = 240;
            this.c1004.Text = "I07 + Cho phép nhập PTTT khi bệnh nhân đã xuất viện";
            // 
            // p11_bangdien
            // 
            this.p11_bangdien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p11_bangdien.AutoScroll = true;
            this.p11_bangdien.Controls.Add(this.c1054);
            this.p11_bangdien.Controls.Add(this.c1019);
            this.p11_bangdien.Controls.Add(this.c1018);
            this.p11_bangdien.Controls.Add(this.c1017);
            this.p11_bangdien.Controls.Add(this.c1016);
            this.p11_bangdien.Controls.Add(this.c1015);
            this.p11_bangdien.Controls.Add(this.c1014);
            this.p11_bangdien.Controls.Add(this.c1013);
            this.p11_bangdien.Controls.Add(this.label128);
            this.p11_bangdien.Controls.Add(this.c441);
            this.p11_bangdien.Controls.Add(this.cboStopbit);
            this.p11_bangdien.Controls.Add(this.label126);
            this.p11_bangdien.Controls.Add(this.label125);
            this.p11_bangdien.Controls.Add(this.label222);
            this.p11_bangdien.Controls.Add(this.cboBaudrate);
            this.p11_bangdien.Controls.Add(this.cboParity);
            this.p11_bangdien.Controls.Add(this.cboDatabit);
            this.p11_bangdien.Controls.Add(this.cboPort);
            this.p11_bangdien.Controls.Add(this.c435);
            this.p11_bangdien.Controls.Add(this.label124);
            this.p11_bangdien.Controls.Add(this.label127);
            this.p11_bangdien.Controls.Add(this.c171);
            this.p11_bangdien.Controls.Add(this.c273);
            this.p11_bangdien.Controls.Add(this.c170);
            this.p11_bangdien.Controls.Add(this.c255);
            this.p11_bangdien.Controls.Add(this.c272);
            this.p11_bangdien.Controls.Add(this.c256);
            this.p11_bangdien.Controls.Add(this.c270);
            this.p11_bangdien.Controls.Add(this.c271);
            this.p11_bangdien.Controls.Add(this.c269);
            this.p11_bangdien.Controls.Add(this.label55);
            this.p11_bangdien.Controls.Add(this.c268);
            this.p11_bangdien.Controls.Add(this.c257);
            this.p11_bangdien.Controls.Add(this.c267);
            this.p11_bangdien.Controls.Add(this.label56);
            this.p11_bangdien.Controls.Add(this.c266);
            this.p11_bangdien.Controls.Add(this.label58);
            this.p11_bangdien.Location = new System.Drawing.Point(157, 3);
            this.p11_bangdien.Name = "p11_bangdien";
            this.p11_bangdien.Size = new System.Drawing.Size(672, 509);
            this.p11_bangdien.TabIndex = 87;
            this.p11_bangdien.Visible = false;
            // 
            // c1054
            // 
            this.c1054.Location = new System.Drawing.Point(9, 207);
            this.c1054.Name = "c1054";
            this.c1054.Size = new System.Drawing.Size(292, 20);
            this.c1054.TabIndex = 318;
            this.c1054.Text = "K08. Phòng khám xuất số thứ tự ra bảng điện (Kontum)";
            this.c1054.Click += new System.EventHandler(this.c1054_Click);
            // 
            // c1019
            // 
            this.c1019.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1019.Location = new System.Drawing.Point(381, 91);
            this.c1019.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1019.Name = "c1019";
            this.c1019.Size = new System.Drawing.Size(44, 21);
            this.c1019.TabIndex = 317;
            this.c1019.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.c1019.Visible = false;
            // 
            // c1018
            // 
            this.c1018.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1018.Location = new System.Drawing.Point(335, 91);
            this.c1018.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1018.Name = "c1018";
            this.c1018.Size = new System.Drawing.Size(44, 21);
            this.c1018.TabIndex = 316;
            this.c1018.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // c1017
            // 
            this.c1017.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1017.Location = new System.Drawing.Point(289, 91);
            this.c1017.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1017.Name = "c1017";
            this.c1017.Size = new System.Drawing.Size(44, 21);
            this.c1017.TabIndex = 315;
            this.c1017.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // c1016
            // 
            this.c1016.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1016.Location = new System.Drawing.Point(243, 91);
            this.c1016.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1016.Name = "c1016";
            this.c1016.Size = new System.Drawing.Size(44, 21);
            this.c1016.TabIndex = 314;
            this.c1016.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // c1015
            // 
            this.c1015.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1015.Location = new System.Drawing.Point(197, 91);
            this.c1015.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1015.Name = "c1015";
            this.c1015.Size = new System.Drawing.Size(44, 21);
            this.c1015.TabIndex = 313;
            this.c1015.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // c1014
            // 
            this.c1014.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1014.Location = new System.Drawing.Point(152, 91);
            this.c1014.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1014.Name = "c1014";
            this.c1014.Size = new System.Drawing.Size(44, 21);
            this.c1014.TabIndex = 312;
            this.c1014.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // c1013
            // 
            this.c1013.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1013.Location = new System.Drawing.Point(103, 91);
            this.c1013.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c1013.Name = "c1013";
            this.c1013.Size = new System.Drawing.Size(48, 21);
            this.c1013.TabIndex = 310;
            this.c1013.Value = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            // 
            // label128
            // 
            this.label128.Location = new System.Drawing.Point(6, 93);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(93, 17);
            this.label128.TabIndex = 311;
            this.label128.Text = "K04.1. Sleep PK :";
            this.label128.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c441
            // 
            this.c441.Location = new System.Drawing.Point(9, 184);
            this.c441.Name = "c441";
            this.c441.Size = new System.Drawing.Size(292, 24);
            this.c441.TabIndex = 309;
            this.c441.Text = "K07. Phòng khám xuất số thứ tự ra bảng điện (Hà nội)";
            this.c441.Click += new System.EventHandler(this.c441_Click);
            // 
            // cboStopbit
            // 
            this.cboStopbit.BackColor = System.Drawing.Color.White;
            this.cboStopbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopbit.Enabled = false;
            this.cboStopbit.FormattingEnabled = true;
            this.cboStopbit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboStopbit.Location = new System.Drawing.Point(498, 115);
            this.cboStopbit.Name = "cboStopbit";
            this.cboStopbit.Size = new System.Drawing.Size(44, 21);
            this.cboStopbit.TabIndex = 300;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(459, 119);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(41, 13);
            this.label126.TabIndex = 308;
            this.label126.Text = "StopBit";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(280, 119);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(32, 13);
            this.label125.TabIndex = 307;
            this.label125.Text = "Baud";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(198, 119);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(26, 13);
            this.label222.TabIndex = 304;
            this.label222.Text = "Port";
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.BackColor = System.Drawing.Color.White;
            this.cboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudrate.Enabled = false;
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cboBaudrate.Location = new System.Drawing.Point(312, 115);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(63, 21);
            this.cboBaudrate.TabIndex = 303;
            // 
            // cboParity
            // 
            this.cboParity.BackColor = System.Drawing.Color.White;
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.Enabled = false;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "none",
            "odd",
            "event"});
            this.cboParity.Location = new System.Drawing.Point(403, 115);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(55, 21);
            this.cboParity.TabIndex = 302;
            // 
            // cboDatabit
            // 
            this.cboDatabit.BackColor = System.Drawing.Color.White;
            this.cboDatabit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabit.Enabled = false;
            this.cboDatabit.FormattingEnabled = true;
            this.cboDatabit.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.cboDatabit.Location = new System.Drawing.Point(580, 115);
            this.cboDatabit.Name = "cboDatabit";
            this.cboDatabit.Size = new System.Drawing.Size(34, 21);
            this.cboDatabit.TabIndex = 301;
            // 
            // cboPort
            // 
            this.cboPort.BackColor = System.Drawing.Color.White;
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.Enabled = false;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(224, 115);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(56, 21);
            this.cboPort.TabIndex = 299;
            // 
            // c435
            // 
            this.c435.Location = new System.Drawing.Point(9, 114);
            this.c435.Name = "c435";
            this.c435.Size = new System.Drawing.Size(224, 24);
            this.c435.TabIndex = 298;
            this.c435.Text = "K02.1. Xuất bảng điện phòng khám:";
            this.c435.CheckedChanged += new System.EventHandler(this.c435_CheckedChanged);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(373, 119);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(33, 13);
            this.label124.TabIndex = 305;
            this.label124.Text = "Parity";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(540, 119);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(41, 13);
            this.label127.TabIndex = 306;
            this.label127.Text = "Databit";
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
            this.p13.Location = new System.Drawing.Point(157, 3);
            this.p13.Name = "p13";
            this.p13.Size = new System.Drawing.Size(663, 509);
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
            this.label75.Text = "M09. Cận lâm sàng :";
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
            this.label73.Text = "M08. Xử trí khám sức khỏe :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(23, 140);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(116, 13);
            this.label72.TabIndex = 7;
            this.label72.Text = "M07. Khám sản phụ khoa :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(23, 116);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(116, 13);
            this.label71.TabIndex = 6;
            this.label71.Text = "M06. Khám TMH :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(23, 96);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(116, 13);
            this.label70.TabIndex = 5;
            this.label70.Text = "M05. Khám RHM :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(23, 73);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(116, 13);
            this.label69.TabIndex = 4;
            this.label69.Text = "M04. Khám mắt :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(23, 51);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(116, 13);
            this.label68.TabIndex = 3;
            this.label68.Text = "M03. Khám ngoại :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(23, 29);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(116, 13);
            this.label67.TabIndex = 2;
            this.label67.Text = "M02. Khám nội :";
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
            this.c306.Size = new System.Drawing.Size(127, 17);
            this.c306.TabIndex = 0;
            this.c306.Text = "M01. Khám sức khỏe";
            this.c306.UseVisualStyleBackColor = true;
            this.c306.CheckedChanged += new System.EventHandler(this.c306_CheckedChanged);
            // 
            // p14
            // 
            this.p14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p14.AutoScroll = true;
            this.p14.Controls.Add(this.cbokhotc);
            this.p14.Controls.Add(this.chkkho);
            this.p14.Controls.Add(this.cbotutruc);
            this.p14.Controls.Add(this.chktutruc);
            this.p14.Controls.Add(this.cbophongtc);
            this.p14.Controls.Add(this.label134);
            this.p14.Location = new System.Drawing.Point(157, 3);
            this.p14.Name = "p14";
            this.p14.Size = new System.Drawing.Size(663, 509);
            this.p14.TabIndex = 244;
            this.p14.Visible = false;
            // 
            // cbokhotc
            // 
            this.cbokhotc.Enabled = false;
            this.cbokhotc.FormattingEnabled = true;
            this.cbokhotc.Location = new System.Drawing.Point(155, 61);
            this.cbokhotc.Name = "cbokhotc";
            this.cbokhotc.Size = new System.Drawing.Size(211, 21);
            this.cbokhotc.TabIndex = 11;
            // 
            // chkkho
            // 
            this.chkkho.AutoSize = true;
            this.chkkho.Location = new System.Drawing.Point(7, 64);
            this.chkkho.Name = "chkkho";
            this.chkkho.Size = new System.Drawing.Size(149, 17);
            this.chkkho.TabIndex = 10;
            this.chkkho.Text = "T02-Chọn kho tiêm chủng";
            this.chkkho.UseVisualStyleBackColor = true;
            this.chkkho.CheckedChanged += new System.EventHandler(this.chkkho_CheckedChanged);
            // 
            // cbotutruc
            // 
            this.cbotutruc.Enabled = false;
            this.cbotutruc.FormattingEnabled = true;
            this.cbotutruc.Location = new System.Drawing.Point(155, 37);
            this.cbotutruc.Name = "cbotutruc";
            this.cbotutruc.Size = new System.Drawing.Size(211, 21);
            this.cbotutruc.TabIndex = 9;
            // 
            // chktutruc
            // 
            this.chktutruc.AutoSize = true;
            this.chktutruc.Location = new System.Drawing.Point(7, 40);
            this.chktutruc.Name = "chktutruc";
            this.chktutruc.Size = new System.Drawing.Size(117, 17);
            this.chktutruc.TabIndex = 8;
            this.chktutruc.Text = "T01-Quản lý tủ trực";
            this.chktutruc.UseVisualStyleBackColor = true;
            this.chktutruc.CheckedChanged += new System.EventHandler(this.chktutruc_CheckedChanged);
            // 
            // cbophongtc
            // 
            this.cbophongtc.FormattingEnabled = true;
            this.cbophongtc.Location = new System.Drawing.Point(155, 13);
            this.cbophongtc.Name = "cbophongtc";
            this.cbophongtc.Size = new System.Drawing.Size(211, 21);
            this.cbophongtc.TabIndex = 7;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(5, 16);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(126, 13);
            this.label134.TabIndex = 6;
            this.label134.Text = "Chọn phòng tiêm chủng :";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(79, 486);
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
            this.butOk.Location = new System.Drawing.Point(8, 486);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 54;
            this.butOk.Text = "    &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // c40091
            // 
            this.c40091.AccessibleDescription = "";
            this.c40091.Location = new System.Drawing.Point(383, 270);
            this.c40091.Name = "c40091";
            this.c40091.Size = new System.Drawing.Size(401, 24);
            this.c40091.TabIndex = 245;
            this.c40091.Text = "D29 - Số lưu trữ khu khám, phòng lưu tăng tự động 6 chữ số";
            // 
            // frmThongso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(828, 515);
            this.Controls.Add(this.p04_masotudong);
            this.Controls.Add(this.p03_chuyenmon);
            this.Controls.Add(this.p01_chung);
            this.Controls.Add(this.p02_hanhchinh);
            this.Controls.Add(this.p07_vienphi);
            this.Controls.Add(this.p06_duoc);
            this.Controls.Add(this.p08_CLS);
            this.Controls.Add(this.p09_phauthuthuat);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.txtNodeTextSearch);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.p12_khamsuckhoe);
            this.Controls.Add(this.p13);
            this.Controls.Add(this.p11_bangdien);
            this.Controls.Add(this.p14);
            this.Controls.Add(this.p10_phonggiuong);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.p05_doituong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmThongso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số hệ thống";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongso_KeyDown);
            this.Load += new System.EventHandler(this.frmThongso_Load);
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
            this.p01_chung.ResumeLayout(false);
            this.p01_chung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1510)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1063)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songaydemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c138m)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.p02_hanhchinh.ResumeLayout(false);
            this.p02_hanhchinh.PerformLayout();
            this.p04_masotudong.ResumeLayout(false);
            this.p04_masotudong.PerformLayout();
            this.p05_doituong.ResumeLayout(false);
            this.p05_doituong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c352)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1140)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1008)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c431)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c428)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c427)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c365)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c348)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c351)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c333)).EndInit();
            this.p03_chuyenmon.ResumeLayout(false);
            this.p03_chuyenmon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c424)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c423)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c325)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c305)).EndInit();
            this.p12_khamsuckhoe.ResumeLayout(false);
            this.p12_khamsuckhoe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.p06_duoc.ResumeLayout(false);
            this.p06_duoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSongaychotoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1069)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1062)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1030)).EndInit();
            this.p07_vienphi.ResumeLayout(false);
            this.p07_vienphi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c429)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c366)).EndInit();
            this.p10_phonggiuong.ResumeLayout(false);
            this.p08_CLS.ResumeLayout(false);
            this.p08_CLS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c339)).EndInit();
            this.p09_phauthuthuat.ResumeLayout(false);
            this.p11_bangdien.ResumeLayout(false);
            this.p11_bangdien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1019)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1018)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1017)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1016)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1015)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1014)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1013)).EndInit();
            this.p13.ResumeLayout(false);
            this.p13.PerformLayout();
            this.p14.ResumeLayout(false);
            this.p14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmThongso_Load(object sender, System.EventArgs e)
		{
            if (bAdmin) this.Text = "F5 : Nạp thông số mặc nhiên, F6 : Lưu thông số mặc nhiên, F7 : Nạp thông số đã cấu hình, F8 : Lưu thông số cấu hình";
            ngonngu.Tag = "";
            load_tooltip();
            sTemp = m.getPathTemp;
            tTemp.Text = sTemp;
            lTemp.Text = "Thư mục TEMP của "+Environment.UserName.ToString();
            //
            sql = "select * from " + m.user + ".thongso where id>1000  ";
            DataSet lds = m.get_data(sql);
            if (lds.Tables[0].Rows.Count <= 0)
            {
                sql = "alter table " + m.user + ".thongso ALTER id TYPE numeric(7)";
                m.execute_data(sql);
            }
            //
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
            //links
            c999.DisplayMember = "TEN";
            c999.ValueMember = "ID";
            //c999.DataSource = m.get_data("select id,ten from " + user + ".dmchinhanh order by id").Tables[0];//linh
            string s_ip_local = m.Maincode("Ip");
            string s_database_local = m.Maincode("Database");
            DataSet dsChinhanh = m.get_data(" select id,ten from " + user +
                ".dmchinhanh where ip='" + s_ip_local + "' and lower(database_local)='" + s_database_local + "' and port='" + m.Maincode("Post") + "' order by ten");
            c999.DataSource = dsChinhanh.Tables[0];
            c999.SelectedIndex = -1;
            if (c999.Items.Count > 0)
            {
                c999.SelectedIndex = 0;
                c999.Enabled = false;
            }
            //end linh
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
            c396.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by a.ten,b.stt,a.stt").Tables[0];

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

            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=1  and chinhanh in (" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ")";//gam 06/09/2011
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

            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=0  and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ")";//gam 06/09/2011
            sql += " order by loai,makp";
            dtk = m.get_data(sql).Tables[0];
            c315.DataSource = dtk;
            c315.DisplayMember = "TENKP";
            c315.ValueMember = "MAKP";

            dtnhomvp_pttt = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];
            c143.DataSource = dtnhomvp_pttt; //m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];
            c143.DisplayMember="TEN";
			c143.ValueMember="MA";
            

            c303.DisplayMember = "TEN";
            c303.ValueMember = "MA";
            c303.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

            c234.DisplayMember = "TEN";
            c234.ValueMember = "MA";
            c234.DataSource = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];

            dtnhomvp_pttt_I05 = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];
            c254.DataSource = dtnhomvp_pttt_I05; 
            c254.DisplayMember = "TEN";
            c254.ValueMember = "MA";

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

            c196.DisplayMember = "HOTEN";
            c196.ValueMember = "ID";
            c196.DataSource = m.get_data("select * from "+user+".v_dlogin order by id").Tables[0];

            c220.DisplayMember = "TEN";
            c220.ValueMember = "ID";
            c220.DataSource = d.get_data("select a.* from "+user+".v_giavp a,"+user+".v_loaivp b where a.id_loai=b.id order by a.ten, b.stt,a.stt").Tables[0];

            c290.DisplayMember = "TEN";
            c290.ValueMember = "ID";
            c290.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by a.ten, b.stt,a.stt").Tables[0];

            c263.DisplayMember = "TEN";
            c263.ValueMember = "ID";
            c263.DataSource = d.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by a.ten, b.stt,a.stt").Tables[0];

            if (ngonngu.Items.Count > 0) { i_ngonngu = int.Parse(m.Thongso("Ngonngu")); ngonngu.SelectedIndex = i_ngonngu; }
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
            bTenvien =false;// m.get_data("select * from " + user + ".tenvien_add").Tables[0].Rows.Count != 0;
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
            //
            try
            {
                ds.Tables[0].Columns.Add("MST");
            }
            catch { }
            //
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + user + ".btdtt where matt<>'000' order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";

            c307.DataSource = m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
            c307.DisplayMember = "DOITUONG";
            c307.ValueMember = "MADOITUONG";

            c308.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c308.DisplayMember = "TENKP";
            c308.ValueMember = "MAKP";

            c309.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c309.DisplayMember = "TENKP";
            c309.ValueMember = "MAKP";

            c310.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c310.DisplayMember = "TENKP";
            c310.ValueMember = "MAKP";

            c311.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c311.DisplayMember = "TENKP";
            c311.ValueMember = "MAKP";

            c312.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c312.DisplayMember = "TENKP";
            c312.ValueMember = "MAKP";

            c313.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
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

            dt397 = m.get_data("select * from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ") order by makp").Tables[0];//gam 06/09/2011
            c397.DataSource = dt397;
            c397.DisplayMember = "TENKP";
            c397.ValueMember = "MAKP";

            dt411 = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];
            c411.DataSource = dt411;
            c411.DisplayMember = "DOITUONG";
            c411.ValueMember = "MADOITUONG";

            dt415=dt411.Copy();//linh bỏ -> = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];
            c415.DataSource = dt415;
            c415.DisplayMember = "DOITUONG";
            c415.ValueMember = "MADOITUONG";

            dt416 = m.get_data("select * from " + user + ".v_nhomvp order by stt").Tables[0];
            c416.DataSource = dt416;
            c416.DisplayMember = "TEN";
            c416.ValueMember = "MA";

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
            //gam 12/08/2011 
            c594.DisplayMember = "ten";
            c594.ValueMember = "id";
            c594.DataSource = m.get_data("select to_number('0') as id,'' as ten union select id,ten from " + user + ".nhomnhanvien").Tables[0];
            // end gam
            // hien them : thong so F39: Nhóm thuốc hướng tâm thần
            load_huongtamthan();
            // endhien
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
					case 1: c601.Checked=true;//toan bo
						break;
					case 2: c602.Checked=true;//dot vao vien
						break;
					case 3: c603.Checked=true;//dot vao khoa
						break;
					default : c604.Checked=true;//bo qu
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
				
			}
            catch (Exception ex) { MessageBox.Show(_id+"\n"+ex.Message); }
            //
            matt.SelectedValue = m.Mabv.Substring(0, 3).ToString();
            maqu.SelectedValue = m.Maqu.ToString();
            benhvien.SelectedValue = m.Mabv.ToString();
            c275.SelectedIndex = 0;
            //Tu:22/08/2011
            txtkituchu.Text = "DN~HX~CH~NN~TK~HC~XK~CA~HT~TB~MS~XB~XN~TN~CC~CK~CB~KC~HD~BT~HN~TC~TQ~TA~TY~TE~HG~LS~CN~HS~GD~TL~XV~NO";
            txtmatinh.Text = "00~03~05~07~09~13~16~18~21~23~28~29~32~39~41~43~47~50~53~55~57~59~61~63~65~69~71~73~76~78~81~85~88~90~93~96~97~98~99";
            //end Tu
            load_tso("ten");
            chkApDungThongTuLienTich15042012_CheckedChanged(null, null);//linh 25092012
            //
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
            // Thuy 31.12.2011
            rbcaptheokhoa.Enabled = c226.Checked;
            rbcaptheotv.Enabled = c226.Checked;//end 31.12.2011
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
            c420.Enabled=c229.Enabled = c228.Checked;
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
            c415.Enabled = c416.Enabled = c417.Enabled=c418.Enabled=c414.Checked;
            c431.Enabled=c427.Enabled = c428.Enabled = c426.Checked;

            sql = "select a.* from " + user + ".v_giavp a,"+user+".v_loaivp b where a.id_loai=b.id ";
            if (s_416 != "") sql += " and b.id_nhom in (" + s_416.Substring(0, s_416.Length - 1) + ")";
            sql+=" order by a.ten, a.stt";
            c417.DataSource = m.get_data(sql).Tables[0];
            c417.DisplayMember = "TEN";
            c417.ValueMember = "ID";
            c417.SelectedValue = m.iKhoan_mavp.ToString();

            sql = "select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id ";
            if (s_416 != "") sql += " and b.id_nhom in (" + s_416.Substring(0, s_416.Length - 1) + ")";
            sql += " order by a.ten, a.stt";
            c418.DataSource = m.get_data(sql).Tables[0];
            c418.DisplayMember = "TEN";
            c418.ValueMember = "ID";
            c418.SelectedValue = m.iKhoan_mavp_pttt.ToString();
            butImage.Enabled = c264.Enabled;
            c300.Enabled=c299.Enabled = c298.Enabled = c297.Checked;
            c359.Enabled=c335.Enabled=c302.Enabled = c179.Checked;
            c364.Enabled = c363.Checked;
            c401.Enabled = c402.Enabled = c400.Checked;
            c161.Enabled = c217.Checked;
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
                if (s_397.IndexOf(dt397.Rows[i]["makp"].ToString()) != -1) c397.SetItemCheckState(i, CheckState.Checked);
                else c397.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c415.Items.Count; i++)
                if (s_415.IndexOf(dt415.Rows[i]["madoituong"].ToString().PadLeft(2,'0')) != -1) c415.SetItemCheckState(i, CheckState.Checked);
                else c415.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c416.Items.Count; i++)
                if (s_416.IndexOf(dt416.Rows[i]["ma"].ToString().PadLeft(3, '0')) != -1) c416.SetItemCheckState(i, CheckState.Checked);
                else c416.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c411.Items.Count; i++)
                if (s_411.IndexOf(dt411.Rows[i]["madoituong"].ToString().PadLeft(2,'0')) != -1) c411.SetItemCheckState(i, CheckState.Checked);
                else c411.SetItemCheckState(i, CheckState.Unchecked);

            for (int i = 0; i < c401.Items.Count; i++)
                if (s_401.IndexOf(dtkho.Rows[i]["id"].ToString().PadLeft(3, '0')) != -1) c401.SetItemCheckState(i, CheckState.Checked);
                else c401.SetItemCheckState(i, CheckState.Unchecked);

			if (c165.Enabled) load_137();
			load_176();
            load_186();
            load_191();
            load_402();
            c171.Enabled = c170.Checked; c411.Enabled = c410.Checked;
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
            check(p06_duoc);
            C1503.Enabled=c420.Checked;

            //Tu: 09/05/2011
            cbophongtc.DisplayMember = "TENKP";
            cbophongtc.ValueMember = "MAKP";
            cbophongtc.DataSource = m.get_data("select makp,tenkp from " + user + ".btdkp_bv where loai=1 and chinhanh in(" + (i_chinhanh == -1 ? 0 : i_chinhanh) + ")").Tables[0];//gam 06/09/2011

            cbotutruc.DisplayMember = "TEN";
            cbotutruc.ValueMember = "ID";
            cbotutruc.DataSource = m.get_data("select id,ten from " + user + ".d_dmkho").Tables[0];

            cbokhotc.DisplayMember = "TEN";
            cbokhotc.ValueMember = "ID";
            cbokhotc.DataSource = m.get_data("select id,ten from " + user + ".d_dmkho").Tables[0];

            try
            {
                cbophongtc.SelectedValue = dsts.Tables[0].Rows[0]["cbophongtc"].ToString();
                cbotutruc.SelectedValue = dsts.Tables[0].Rows[0]["cbotutruc"].ToString();
                cbokhotc.SelectedValue = dsts.Tables[0].Rows[0]["cbokhotc"].ToString();
                if (dsts.Tables[0].Rows[0]["t01"].ToString() == "1") chktutruc.Checked = true;
                if (dsts.Tables[0].Rows[0]["t02"].ToString() == "1") chkkho.Checked = true;
            }
            catch { }
            //end Tu
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
                            //linh
                        case (int) LibMedi.IDThongSo.ID_SoNgayToaThuocCanCanhBao:
                            string _value = r[fie].ToString().Trim();
                            try {
                                decimal _songay = decimal.Parse(_value);
                                numSongaychotoa.Maximum = Math.Max(numSongaychotoa.Maximum, _songay);
                                numSongaychotoa.Value = _songay;
                                numSongaychotoa.Tag = _songay.ToString();
                            }
                            catch { numSongaychotoa.Value = 0;
                            numSongaychotoa.Maximum = 100;
                        }
                            break;//linh 25092012
                        case (int)IDThongSo.ID_ThongTuLienTich15042012:
                            chkApDungThongTuLienTich15042012.Checked = r[fie].ToString() == "1";
                            chkApDungThongTuLienTich15042012.Tag = chkApDungThongTuLienTich15042012.Checked.ToString();
                            if (!chkApDungThongTuLienTich15042012.Checked)
                            {
                                cboNgayGiaVienPhiThongTuLienTich.Text = "";
                                cboNgayGiaVienPhiThongTuLienTich.Tag = "";
                                txtNgayBenhNhanThongTuLienTich.Text = "";
                                txtNgayBenhNhanThongTuLienTich.Tag = "";
                            }
                            break;
                        case (int)IDThongSo.ID_NgayVienPhiThongTuLienTich15042012:
                            cboNgayGiaVienPhiThongTuLienTich.Text = r[fie].ToString();
                            break;
                        case (int)IDThongSo.ID_NgayBenhNhanThongTuLienTich15042012:
                            txtNgayBenhNhanThongTuLienTich.Text = r[fie].ToString();
                            break;
                        //end linh
                            //end linh
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
                        case -6: mst.Text = r[fie].ToString().Trim();
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
                        case 47: c47.Checked = r[fie].ToString()=="1";
                            break;
                        case 48: c48.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 49: ma13.Text = r[fie].ToString().Trim();
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
                        case 57: c57.Checked = int.Parse(m.Thongso("c57")) == 1 && c47.Checked == false;
                            break;
                        case 58: c58.Checked = int.Parse(m.Thongso("c58")) == 1;
                            break;
                        case 61: c61.Checked = int.Parse(m.Thongso("c61")) == 1;
                            break;
                        case 62: c62.Checked = r[fie].ToString() == "1"; //gam 12/01/2012
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
                        case 143: //c1433.SelectedValue = r[fie].ToString().Trim();
                            s_143 = r[fie].ToString().Trim().Trim(',');
                            if (s_143 != "")
                            {
                                string tmp_143 = "," + s_143.Trim().Trim(',') + ",";
                                //c191.SelectedValue = s_191;
                                for (int i = 0; i < c143.Items.Count; i++)
                                {
                                    if (tmp_143.IndexOf("," + dtnhomvp_pttt.Rows[i]["ma"].ToString() + ",") != -1) c143.SetItemCheckState(i, CheckState.Checked);
                                    else c143.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }                            
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
                        case 1501: c1501.Checked = r[fie].ToString().Trim() == "1";
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
                        case 191:
                            {
                                //c191.SelectedValue = r[fie].ToString().Trim();
                                s_191 = r[fie].ToString();
                                if (s_191 != "")
                                {
                                    string tmp_191 = "," + s_191.Trim().Trim(',') + ",";
                                    //c191.SelectedValue = s_191;
                                    for (int i = 0; i < c191.Items.Count; i++)
                                    {
                                        if (tmp_191.IndexOf("," + dtkho_ng.Rows[i]["id"].ToString() + ",") != -1) c191.SetItemCheckState(i, CheckState.Checked);
                                        else c191.SetItemCheckState(i, CheckState.Unchecked);
                                    }
                                }
                                break;
                            }
                        case 192: c192.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 193: if (c153.Checked) c193.SelectedValue = r[fie].ToString().Trim();
                            else c193.SelectedIndex = -1;
                            break;
                        case 194: c194.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 195: c195.Checked = r[fie].ToString().Trim() == "1";//Khuong sua ngay 19/05/2011
                            break;
                        case 1135: c1135.Checked = r[fie].ToString().Trim() == "1";//Khuong sua ngay 19/05/2011
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
                        case 254:
                            s_254 = r[fie].ToString().Trim().Trim(',');
                            if (s_254 != "")
                            {
                                string tmp_254 = "," + s_254.Trim().Trim(',') + ",";
                                for (int i = 0; i < c254.Items.Count; i++)
                                {
                                    if (tmp_254.IndexOf("," + dtnhomvp_pttt_I05.Rows[i]["ma"].ToString() + ",") != -1) c254.SetItemCheckState(i, CheckState.Checked);
                                    else c254.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }
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
                            //Thuy 31.12.2011
                        case 3011: rbcaptheokhoa.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 3012: rbcaptheotv.Checked = r[fie].ToString().Trim() == "1";
                            break;
                            //end 31.12.2011
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
                            c1024.Enabled = c382.Checked == true;
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
                        case 396:
                            try
                            {
                                c396.SelectedValue = r[fie].ToString();
                            }
                            catch { }
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
                        case 405: c405.Checked = r[fie].ToString() == "1";
                            break;
                        case 406: c406.Checked = r[fie].ToString() == "1";
                            break;
                        case 407: c407.Checked = r[fie].ToString() == "1";
                            break;
                        case 408: c408.Text = r[fie].ToString();
                            break;
                        case 409: c409.Checked = r[fie].ToString() == "1";
                            break;
                        case 410: c410.Checked = r[fie].ToString() == "1";
                            break;
                        case 411: s_411 = r[fie].ToString().Trim();
                            break;
                        case 412: c412.Checked = r[fie].ToString() == "1";
                            break;
                        case 413: c413.Checked = r[fie].ToString() == "1";
                            break;
                        case 414: c414.Checked = r[fie].ToString() == "1";
                            break;
                        case 415: s_415 = r[fie].ToString().Trim();
                            break;
                        case 416: s_416 = r[fie].ToString().Trim();
                            break;
                        case 417:c417.SelectedValue=r[fie].ToString();
                            break;
                        case 418: c418.SelectedValue = r[fie].ToString();
                            break;
                        case 419: c419.Checked = r[fie].ToString() == "1";
                            break;
                        case 420: c420.Checked = r[fie].ToString() == "1";
                            break;
                        case 421: c421.Checked = r[fie].ToString() == "1";
                            break;
                        case 422: c422.Checked = r[fie].ToString() == "1";
                            break;
                        case 423: c423.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 424: c424.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 425: c425.Checked = r[fie].ToString() == "1";
                            break;
                        case 426: c426.Checked = r[fie].ToString() == "1";
                            break;
                        case 427: c427.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 428: c428.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 429: c429.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 430: c430.Checked = r[fie].ToString() == "1";
                            break;
                        case 50: c49.Text = r[fie].ToString();
                            break;
                        case -50: c175.Text = r[fie].ToString();
                            break;
                        case 431: c431.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 432: c432.Checked = r[fie].ToString() == "1";
                            break;
                        case 433: c433.Checked = r[fie].ToString() == "1";
                            break;
                        case 434: c434.Checked = r[fie].ToString() == "1";
                            c1034.Enabled = c434.Checked;
                            //c1036.Enabled = c434.Checked;
                            c1039.Enabled = c434.Checked;
                            if (c434.Checked == false)
                            {
                                c1034.Checked = false;
                                //c1036.Checked = false;
                                c1039.Checked = false;
                            }
                            break;
                        //linh
                        case 435: c435.Checked = r[fie].ToString() == "1";
                            break;
                        //end linh
                        case 438: c438.Checked = r[fie].ToString() == "1";
                            break;
                        case 439: c439.Checked = r[fie].ToString() == "1";
                            break;
                        case 440: c440.Checked = r[fie].ToString() == "1";
                            break;
                        case 441: c441.Checked = r[fie].ToString() == "1";
                            break;
                        case 442: c442.Text = r[fie].ToString();
                            break;
                        case 443: c443.Checked = r[fie].ToString() == "1";
                            break;
                        case 446: c446.Checked = r[fie].ToString() == "1";
                            break;
                            //
                            //gam 11/08/2011
                        case 594: c594.SelectedValue = r[fie].ToString().Trim();
                            break;
                        //end gam
                        case 1000:
                            try
                            {
                                C1000.Value = r[fie].ToString() == "" ? 0 : decimal.Parse(r[fie].ToString());
                            }
                            catch { C1000.Value = 1; }
                            break;
                        case 1001: c1001.Checked = r[fie].ToString() == "1";
                            break;
                        case 1002: c1002.Checked = r[fie].ToString() == "1";
                            break;
                        case 1003: c1003.Checked = r[fie].ToString() == "1";
                            break;
                        case 1004: c1004.Checked = r[fie].ToString() == "1";
                            break;
                        case 1005: c1005.Checked = r[fie].ToString() == "1";
                            break;
                        case 1006: c1006.Checked = r[fie].ToString() == "1";
                            break;
                        case 1007: c1007.Checked = r[fie].ToString() == "1";
                            c348.Enabled = c349.Enabled = c350.Enabled = c351.Enabled = c352.Enabled = !c1007.Checked;
                            c1008.Enabled = c1007.Checked;
                            break;
                        case 1008: try { c1008.Value =(r[fie].ToString().Trim()=="")?26000000: decimal.Parse(r[fie].ToString()); }
                                catch { }
                            break;
                        case 1009: c1009.Checked = r[fie].ToString() == "1";
                            break;
                        case 1010: c1010.Checked = r[fie].ToString() == "1";
                            break;
                        case 1011: c1011.Checked = r[fie].ToString() == "1";
                            break;
                        case 1012: c1012.Checked = r[fie].ToString() == "1";
                            break;
                            //bang dien phong kham
                        case 1013: c1013.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1014: c1014.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1015: c1015.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1016: c1016.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1017: c1017.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1018: c1018.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1019: c1019.Value = decimal.Parse(r[fie].ToString());
                            break;
                        case 1020: c1020.Checked = r[fie].ToString() == "1";
                            break;
                        case 1021: c1021.Checked = r[fie].ToString() == "1";
                            break;
                        case 1022: c1022.Checked = r[fie].ToString() == "1";
                            break;
                        case 1023: c1023.Checked = r[fie].ToString() == "1";
                            break;
                        case 1024: c1024.Checked = r[fie].ToString() == "1";
                            break;
                        case 1025: c1025.Checked = r[fie].ToString() == "1";
                            break;
                        case 1026: c1026.Checked = r[fie].ToString() == "1";
                            break;
                        case 1027: c1027.Checked = r[fie].ToString() == "1";
                            break;
                        case 1028: c1028.Checked = r[fie].ToString() == "1";
                            break;
                        case 1029: c1029.Checked = r[fie].ToString() == "1";
                            break;
                        case 1030:
                            try
                            {
                                c1030.Value = r[fie].ToString() == "" ? 0 : decimal.Parse(r[fie].ToString());//F32
                            }
                            catch { c1030.Value = 0; }
                            break;
                        case 1031: c1031.Checked = r[fie].ToString() == "1";
                            break;
                        case 1032: c1032.Checked = r[fie].ToString() == "1";
                            break;
                        case 1033: c1033.Checked = r[fie].ToString() == "1";
                            break;
                        case 1034: c1034.Checked = r[fie].ToString() == "1";
                            break;
                        case 1035: c1035.Checked = r[fie].ToString() == "1";
                            break;
                        case 1036: c1036.Checked = r[fie].ToString() == "1";
                            if (c1036.Checked) c1059.Checked = false;
                            break;
                        case 1037: c1037.Checked = r[fie].ToString() == "1";
                            break;
                        case 1038: c1038.Checked = r[fie].ToString() == "1";
                            break;
                        case 1039: c1039.Checked = r[fie].ToString() == "1";
                            break;
                        case 1040: c1040.Checked = r[fie].ToString() == "1";
                            break;
                        case 1041: c1041.Checked = r[fie].ToString() == "1";
                            break;
                        case 1042: c1042.Checked = r[fie].ToString() == "1";
                            break;
                        case 1043: c1043.Checked = r[fie].ToString() == "1";
                            break;
                        case 1044: c1044.Checked = r[fie].ToString() == "1";
                            break;
                        case 1045: c1045.Checked = r[fie].ToString() == "1";
                            break;
                        case 1046: c1046.Checked = r[fie].ToString() == "1";
                            break;
                       case 50034: c50034.Checked = r[fie].ToString() == "1";
                            break;
                        case 40091: c40091.Checked = r[fie].ToString() == "1";
                            break;
                        case 1047: c1047.Checked = r[fie].ToString() == "1";
                            break;
                        case 1048: c1048.Checked = r[fie].ToString() == "1";
                            break;
                        case 1049: c1049.Checked = r[fie].ToString() == "1";
                            break;
                        case 1050: c1050.Checked = r[fie].ToString() == "1";
                            break;
                        case 1051: c1051.Checked = r[fie].ToString() == "1";
                            break;
                        case 1052: c1052.Checked = r[fie].ToString() == "1";
                            break;
                        case 1053: c1053.Checked = r[fie].ToString() == "1";
                            break;
                        case 1054: c1054.Checked = r[fie].ToString() == "1";
                            break;
                        case 1055: c1055.Checked = r[fie].ToString() == "1";
                            break;
                        case 1056: c1056.Checked = r[fie].ToString() == "1";
                            break;
                        case 1057: c1057.Checked = r[fie].ToString() == "1";
                            break;
                        case 1058: c1058.Checked = r[fie].ToString() == "1";
                            break;
                        case 1059: c1059.Checked = r[fie].ToString() == "1";
                            if (c1059.Checked) c1036.Checked = false;
                            break;
                        case 1060: c1060.Checked = r[fie].ToString() == "1";
                            break;
                        case 1061: c1061.Checked = r[fie].ToString() == "1";
                            break;
                        case 1062:
                            try
                            {
                                c1062.Value = r[fie].ToString() == "" ? 0 : decimal.Parse(r[fie].ToString());//F35
                            }
                            catch { c1062.Value = 0; }
                            break;
                        case 1063:
                            try
                            {
                                c1063.Value = r[fie].ToString() == "" ? 0 : decimal.Parse(r[fie].ToString());//F35
                            }
                            catch { c1063.Value = 1; }
                            break;
                        case 1064: c1064.Checked = r[fie].ToString() == "1";
                            break;
                        case 1065: c1065.Checked = r[fie].ToString() == "1";
                            break;
                        case 1066: c1066.Checked = r[fie].ToString() == "1";
                            break;
                        case 1067: c1067.Checked = r[fie].ToString() == "1";
                            break;
                        case 1068: c1068.Checked = r[fie].ToString() == "1";
                            break;
                        case 1069:
                            try
                            {
                                c1069.Value = r[fie].ToString() == "" ? 0 : decimal.Parse(r[fie].ToString());//F37
                            }
                            catch { c1069.Value = 0; }
                            break;
                        case 1070: c1070.Checked = r[fie].ToString() == "1";
                            break;
                        case 1071: c1071.Checked = r[fie].ToString() == "1";
                            break;
                        case 1072: c1072.Checked = r[fie].ToString() == "1";
                            break;
                        case 1073: c1073.Checked = r[fie].ToString() == "1";
                            break;
                        case 1074: c1074.Checked = r[fie].ToString() == "1";
                            break;
                        case 1075: c1075.Checked = r[fie].ToString() == "1";
                            break;
                        case 1076: c1076.Checked = r[fie].ToString() == "1";
                            break;
                        case 1077: c1077.Checked = r[fie].ToString() == "1";
                            break;
                        case 1078: c1078.Checked = r[fie].ToString() == "1";
                            break;

                        case 1079: c1079.Checked = r[fie].ToString() == "1";
                            break;
                        case 1080: c1080.Checked = r[fie].ToString() == "1";
                            break;
                        case 1081: c1081.Checked = r[fie].ToString() == "1";
                            break;
                        case 1082: c1082.Checked = r[fie].ToString() == "1";
                            break;
                        case 1083: c1083.Checked = r[fie].ToString() == "1";
                            break;
                        case 1084: c1084.Checked = r[fie].ToString() == "1";
                            break;
                        case 1085: c1085.Text = r[fie].ToString();
                            break;
                        case 1086: c1086.Checked = r[fie].ToString() == "1";
                            break;
                        case 1087: c1087.Checked = r[fie].ToString() == "1";
                            break;

                        case 1088: c1088.Checked = r[fie].ToString() == "1";
                            break;
                        case 1089: c1089.Checked = r[fie].ToString() == "1";
                            break;
                        //Tú:28/06/2011
                        case 1090: c1090.Checked = r[fie].ToString() == "1";
                            break;
                        //end Tú
                        case 1091: c1091.Checked = r[fie].ToString() == "1";
                            break;
                        case 1092: c1092.Checked = r[fie].ToString() == "1";
                            break;
                        case 1093:
                            
                            c1093.Checked = r[fie].ToString() == "1";
                            butDichvu.Enabled = c1093.Checked;
                            break;
                        case 1094: c1094.Text = r[fie].ToString();
                            load_1094(c1094.Text);
                            break;
                        case 1095:
                            c1095.Checked = r[fie].ToString() == "1";                            
                            break;
                        case 1096:
                            c1096.Checked = r[fie].ToString() == "1";
                            break;
                        case 1097:
                            c1097.Checked = r[fie].ToString() == "1";
                            break;
                        case 1098:
                            c1098.Checked = r[fie].ToString() == "1";//Thuy 30.12.2011
                            break;
                        case 1099:
                            c1099.Checked = r[fie].ToString() == "1";//Thuy 30.12.2011
                            break;
                        case 1100:
                            c1100.Checked = r[fie].ToString() == "1";
                            break;
                        case 1512:
                            c1512.Checked = r[fie].ToString() == "1";
                            break;
                        case 1101:
                            c1101.Checked = r[fie].ToString() == "1";//gam 26/10/2011
                            break;
                        case 1505:
                            c1505.Checked = r[fie].ToString() == "1";//gam 26/10/2011
                            break;
                        case 1102:
                            c1102.Checked = r[fie].ToString() == "1";//Khuong 11/11/2011
                            break;
                        case 1103:
                            c1103.Checked = r[fie].ToString() == "1";//Khuong 13/12/2011
                            break;
                        case 1104:
                            {
                                c1104.Checked = r[fie].ToString() == "1";//gam 11042012
                                break;
                            }
                        case 1105:
                            {
                                c1105.Checked = r[fie].ToString() == "1";//Thuy 11.10.2012
                                break;
                            }
                        case 1502: c1502.Checked = r[fie].ToString() == "1";//gam 14/02/2012
                            break;
                        case 1504: c1504.Checked = r[fie].ToString() == "1";//Thuy 11.06.2012
                            break;
                        case 1506: c1506.Checked = r[fie].ToString() == "1";//Thuy 17.12.2012
                            break;
                        case 1507: c1507.Checked = r[fie].ToString() == "1";//Thuy 02.01.2013
                            break;
                        case 1260:
                            c1260.Checked = r[fie].ToString() == "1";
                            break;
                        case 1261:
                            c1261.Checked = r[fie].ToString() == "1";
                            break;
                        //Tu:22/08/2011 kiểm tra số thẻ hợp lệ theo qui định của BHYT
                        case 997:
                            c997.Checked = r[fie].ToString() == "1";
                            txtkituchu.Enabled = txtmatinh.Enabled = c997.Checked;
                            break;
                        case 9971:
                            txtkituchu.Enabled = txtmatinh.Enabled = c997.Checked;
                            txtkituchu.Text = r[fie].ToString();
                            break;
                        case 9972:
                            txtkituchu.Enabled = txtmatinh.Enabled = c997.Checked;
                            txtmatinh.Text = r[fie].ToString();
                            break;
                        //end Tu
                        case 445: c445.Checked = r[fie].ToString() == "1";//gam 09/09/2011 quản lý thuốc mổ
                            break;

                            //chi nhanh
                        case 998: c998.Checked = r[fie].ToString() == "1";//A14.2
                            break;
                        case 1503: C1503.Checked = r[fie].ToString() == "1";//Thuy 22.02.2012
                            break;
                        case 595: c595.Checked = r[fie].ToString() == "1";
                            break;
                        case 999:
                            {
                                try
                                {
                                    c999.SelectedValue = r[fie].ToString();
                                }
                                catch { c999.SelectedIndex = -1; }

                                break;
                            }
                            //ThanhCuong - 06/08/2012 - Kỹ thuật cao
                        case 1137: c1137.Checked = r[fie].ToString() == "1";
                            break;
                        case 1138: c1138.Text = r[fie].ToString();
                            break;
                        case 1139: c1139.Text = r[fie].ToString();
                            break;
                        case 1140: 
                            try 
                            { 
                                c1140.Value = (r[fie].ToString().Trim() == "") ? 26000000 : decimal.Parse(r[fie].ToString());
                                label148.Text = label148.Text + c1140.Value.ToString();
                                label149.Text = label149.Text + c1140.Value.ToString();
                            }
                            catch { }
                            break;
                        case 1141: c1141.Text = r[fie].ToString();
                            break;
                        case 1508: c1508.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 1509: c1509.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 1510: c1510.Value = (r[fie].ToString().Trim() == "") ? 12 : decimal.Parse(r[fie].ToString());
                            break;
                        case 1511: c1511.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 1513: c1513.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 1600: c1600.Checked = r[fie].ToString() == "1";
                            break;
                            //End 
                        case 50114: c50114.Checked = r[fie].ToString() == "1"; // truongthuy 23052014 them option  C79 - In số thứ tự trong phiếu lĩnh trùng với số thứ tự trong phiếu công khai

                            break;
                        //End 50114
                    }
                }
            }
            foreach (DataRow r in m.get_data("select * from " + user + ".d_thongso where id in (50,51,52,53) and nhom=" + m.nhom_duoc).Tables[0].Rows)
            {
                switch (int.Parse(r["id"].ToString()))
                {
                    case 50: d50.Text = r["ten"].ToString();
                        break;
                    case 51: d51.Text = r["ten"].ToString();
                        break;
                    case 52: d52.Text = r["ten"].ToString();
                        break;
                    case 53: d53.Text = r["ten"].ToString();
                        break;
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
            this.p01_chung.Location = new System.Drawing.Point(159, 3);
            this.p02_hanhchinh.Location = new System.Drawing.Point(159, 3);
            this.p03_chuyenmon.Location = new System.Drawing.Point(159, 3);
            this.p04_masotudong.Location = new System.Drawing.Point(159, 3);
            this.p05_doituong.Location = new System.Drawing.Point(159, 3);
            this.p06_duoc.Location = new System.Drawing.Point(159, 3);
            this.p07_vienphi.Location = new System.Drawing.Point(159, 3);
            this.p08_CLS.Location = new System.Drawing.Point(159, 3);
            this.p09_phauthuthuat.Location = new System.Drawing.Point(159, 3);
            this.p11_bangdien.Location = new System.Drawing.Point(159, 3);
            this.p10_phonggiuong.Location = new System.Drawing.Point(159, 3);
            this.p12_khamsuckhoe.Location = new System.Drawing.Point(159, 3);
            this.p13.Location = new System.Drawing.Point(159, 3);
            this.p14.Location = new System.Drawing.Point(159, 3);
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
            sql = "select * from "+user+".d_dmkho where nhom<>0 and ngoaigio=1 ";
            if (c166.SelectedIndex != -1) sql += " and nhom=" + int.Parse(c166.SelectedValue.ToString());
            if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by id";
            dtkho_ng=m.get_data(sql).Tables[0];
            c191.DataSource = dtkho_ng;
            c191.DisplayMember = "TEN";
            c191.ValueMember = "ID";
            if (s_191 != "")
            {
                string tmp_191 = "," + s_191.Trim().Trim(',') + ",";
                //c191.SelectedValue = s_191;
                for (int i = 0; i < c191.Items.Count; i++)
                {
                    if (tmp_191.IndexOf("," + dtkho_ng.Rows[i]["id"].ToString() + ",") != -1) c191.SetItemCheckState(i, CheckState.Checked);
                    else c191.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void load_143()
        {
            if (s_143 != "")
            {
                string tmp_143 = "," + s_143.Trim().Trim(',') + ",";
                //c191.SelectedValue = s_191;
                for (int i = 0; i < c143.Items.Count; i++)
                {
                    if (tmp_143.IndexOf("," + dtnhomvp_pttt.Rows[i]["id"].ToString() + ",") != -1) c143.SetItemCheckState(i, CheckState.Checked);
                    else c143.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
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
            if (m.get_data("select * from " + user + ".thongso where id=405").Tables[0].Rows.Count == 0) m.upd_thongso(405, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=406").Tables[0].Rows.Count == 0) m.upd_thongso(406, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=407").Tables[0].Rows.Count == 0) m.upd_thongso(407, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=408").Tables[0].Rows.Count == 0) m.upd_thongso(408, "Triệu chứng lâm sàng ban đầu :", "Triệu chứng lâm sàng ban đầu :", "Triệu chứng lâm sàng ban đầu :");
            if (m.get_data("select * from " + user + ".thongso where id=409").Tables[0].Rows.Count == 0) m.upd_thongso(409, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=410").Tables[0].Rows.Count == 0) m.upd_thongso(410, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=411").Tables[0].Rows.Count == 0) m.upd_thongso(411, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=412").Tables[0].Rows.Count == 0) m.upd_thongso(412, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=413").Tables[0].Rows.Count == 0) m.upd_thongso(413, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=414").Tables[0].Rows.Count == 0) m.upd_thongso(414, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=415").Tables[0].Rows.Count == 0) m.upd_thongso(415, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=416").Tables[0].Rows.Count == 0) m.upd_thongso(416, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=417").Tables[0].Rows.Count == 0) m.upd_thongso(417, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=418").Tables[0].Rows.Count == 0) m.upd_thongso(418, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=419").Tables[0].Rows.Count == 0) m.upd_thongso(419, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=420").Tables[0].Rows.Count == 0) m.upd_thongso(420, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=421").Tables[0].Rows.Count == 0) m.upd_thongso(421, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=422").Tables[0].Rows.Count == 0) m.upd_thongso(422, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=423").Tables[0].Rows.Count == 0) m.upd_thongso(423, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=424").Tables[0].Rows.Count == 0) m.upd_thongso(424, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=425").Tables[0].Rows.Count == 0) m.upd_thongso(425, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=426").Tables[0].Rows.Count == 0) m.upd_thongso(426, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=427").Tables[0].Rows.Count == 0) m.upd_thongso(427, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=428").Tables[0].Rows.Count == 0) m.upd_thongso(428, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=429").Tables[0].Rows.Count == 0) m.upd_thongso(429, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=430").Tables[0].Rows.Count == 0) m.upd_thongso(430, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=50").Tables[0].Rows.Count == 0) m.upd_thongso(50, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=-50").Tables[0].Rows.Count == 0) m.upd_thongso(-50, "", "", "");
            if (m.get_data("select * from " + user + ".thongso where id=431").Tables[0].Rows.Count == 0) m.upd_thongso(431, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=432").Tables[0].Rows.Count == 0) m.upd_thongso(432, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=433").Tables[0].Rows.Count == 0) m.upd_thongso(433, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=438").Tables[0].Rows.Count == 0) m.upd_thongso(438, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=439").Tables[0].Rows.Count == 0) m.upd_thongso(439, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=440").Tables[0].Rows.Count == 0) m.upd_thongso(440, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=441").Tables[0].Rows.Count == 0) m.upd_thongso(441, "0", "0", "0");
            if (m.get_data("select * from " + user + ".thongso where id=442").Tables[0].Rows.Count == 0) m.upd_thongso(442, "GL+JL+HN+HL", "GL+JL+HN+HL", "GL+JL+HN+HL");
            if (m.get_data("select * from " + user + ".thongso where id=443").Tables[0].Rows.Count == 0) m.upd_thongso(443, "0", "0", "0");
            
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			if (benhvien.SelectedIndex==-1) Application.Exit();
			m.close();this.Close();
		}
        void upd_ngonngu()
        {
            if (ngonngu.SelectedIndex.ToString() != ngonngu.Tag.ToString())
            {
                string goc = "ten";
                string copy = "ten_vn";
                if (ngonngu.SelectedIndex == 0) copy = "ten_vn";
                else if (ngonngu.SelectedIndex == 1) copy = "ten_en";
                else if (ngonngu.SelectedIndex == 2) copy = "ten_ot";
                DataSet dsdanhmuc = new DataSet();
                if (System.IO.File.Exists("..//..//..//xml//dsDanhmuc.xml") == false)
                {
                    string asql = "select '' as ten, '' as ten_vn, '' as ten_en, '' as ten_ot from " + m.user + ".doituong where 1=2";
                    DataSet lds = m.get_data (asql);
                    lds.WriteXml("..//..//..//xml//dsDanhmuc.xml", XmlWriteMode.WriteSchema);
                }
                dsdanhmuc.ReadXml("..//..//..//xml//dsDanhmuc.xml");

                foreach (DataRow r in dsdanhmuc.Tables[0].Rows)
                {
                    m.execute_data("update " + m.user + "." + r["ten"].ToString() + " set " + goc + "=" + copy);
                }
                ngonngu.Tag = ngonngu.SelectedIndex.ToString();
            }
        }
        void upd_xml()
        {
            if (ngonngu.SelectedIndex.ToString() != ngonngu.Tag.ToString())
            {
                string goc = "ten";
                string copy = "ten_vn";
                if (ngonngu.SelectedIndex == 0) copy = "ten_vn";
                else if (ngonngu.SelectedIndex == 1) copy = "ten_en";
                else if (ngonngu.SelectedIndex == 2) copy = "ten_ot";
                DataSet dsdanhmuc = new DataSet();
                if (System.IO.File.Exists("..//..//..//xml//dsDanhmuc_xml.xml") == false)
                {
                    string asql = "select '' as ten, '' as ten_vn, '' as ten_en, '' as ten_ot from " + m.user + ".doituong where 1=2";
                    DataSet lds = m.get_data(asql);
                    lds.WriteXml("..//..//..//xml//dsDanhmuc_xml.xml", XmlWriteMode.WriteSchema);
                }
                dsdanhmuc.ReadXml("..//..//..//xml//dsDanhmuc_xml.xml");
                foreach (DataRow r in dsdanhmuc.Tables[0].Rows)
                {
                    string tenfile = r["ten"].ToString().Replace(".xml", "") + ".xml";
                    if (System.IO.File.Exists("..//..//..//xml//" + tenfile))
                    {

                        if (tenfile.ToLower() == "tsosystem.xml")
                        {
                            goc = goc.Replace("ten", "text");
                            copy = copy.Replace("ten", "text");
                        }
                        else
                        {
                            goc = "ten";
                            copy = "ten_vn";
                            if (ngonngu.SelectedIndex == 0) copy = "ten_vn";
                            else if (ngonngu.SelectedIndex == 1) copy = "ten_en";
                            else if (ngonngu.SelectedIndex == 2) copy = "ten_ot";

                        }
                        DataSet tmp = new DataSet();
                        tmp.ReadXml("..//..//..//xml//" + tenfile, XmlReadMode.ReadSchema);
                        foreach (DataRow nr in tmp.Tables[0].Rows)
                        {
                            nr[goc] = nr[copy].ToString();
                        }
                        tmp.WriteXml("..//..//..//xml//" + tenfile, XmlWriteMode.WriteSchema);
                    }
                }
                //dsdanhmuc.WriteXml("..//..//..//xml//dsDanhmuc_xml.xml", XmlWriteMode.WriteSchema);
            }
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
                MessageBox.Show(lan.Change_language_MessageText("Chọn đường dẫn lưu hình !"), LibMedi.AccessData.Msg);
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
                    MessageBox.Show(lan.Change_language_MessageText("Khai báo không hợp lệ, Đề nghị chọn thêm 1 trong các tùy chọn: G01, G04, G06, G09, G11  !"), LibMedi.AccessData.Msg);
					c141.Focus();
					return;
				}
				else if (m.get_data("select * from "+user+".v_lydomien").Tables[0].Rows.Count==0 || m.get_data("select * from "+user+".v_dsduyet").Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chưa khai báo lý do miễn hoặc danh sách ký miễn !"),LibMedi.AccessData.Msg);
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
            //linh 25092012
            if (chkApDungThongTuLienTich15042012.Checked && (cboNgayGiaVienPhiThongTuLienTich.SelectedIndex == -1 || txtNgayBenhNhanThongTuLienTich.Text.Trim().Trim('/').Trim() == ""))
            {
                MessageBox.Show("Thông tin áp dụng thông tư liên tịch ngày 15/4/2012 không hợp lệ");
                return;
            }
            //end
            if(decimal.Parse(c429.Value.ToString())<=0)
            {
                c1261.Checked = false;
            }
            upd_tso("ten");
		}

        private void upd_tso(string fie)
        {
            if (c417.Enabled && c418.Enabled && c417.SelectedIndex != -1 && c418.SelectedIndex != -1)
            {
                if (c417.SelectedValue.ToString() == c418.SelectedValue.ToString())
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nội dung vật tư tiêu hao khoa ") + c417.Text + lan.Change_language_MessageText(" phải khác ") + c418.Text, LibMedi.AccessData.Msg);
                    c417.Focus();
                    return;
                }
            }
            Cursor = Cursors.WaitCursor;
            if (!bKhaibao || bTenvien)
            {
                m.upd_thongso(1, fie, loaidv.SelectedIndex.ToString());
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
                        if (r["maphuongxa"].ToString().Trim().Length == 7)
                        {
                            m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_01");
                            m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_02");
                            m.upd_danhmuc(int.Parse(r["maphuongxa"].ToString().Substring(5, 2)), "1", r["tenpxa"].ToString(), "kh_dm_04");
                        }
                    }
                    foreach (DataRow r in m.get_data("select * from " + user + ".btdquan where substr(maqu,4,2)<>'00' and matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0].Rows)
                    {
                        if (r["maqu"].ToString().Trim().Length == 5) m.upd_danhmuc(int.Parse(r["maqu"].ToString().Substring(3, 2)), "1", r["tenquan"].ToString(), "kh_dm_143");
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


                ds.Tables[0].Rows[0]["syte"] = soyte.Text.ToString().Trim();
                ds.Tables[0].Rows[0]["diachi"] = diachi.Text.ToString().Trim();
                ds.Tables[0].Rows[0]["dienthoai"] = dienthoai.Text.ToString().Trim();
                try
                {
                    ds.Tables[0].Rows[0]["mst"] = mst.Text.ToString().Trim();//binh 150611
                }
                catch { }
                ds.WriteXml("..//..//..//xml//maincode.xml");
            }
            else if (maqu.Enabled) m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
            //
            if (fie != "ten")
            {
                m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
                m.upd_thongso(24, fie, maqu.SelectedValue.ToString());
            }
            
            m.upd_thongso(1, fie, loaidv.SelectedIndex.ToString());
            m.upd_thongso(2, fie, mabv.ToString().Trim());
            m.upd_thongso(3, fie, tenbv.ToString().Trim());
            m.upd_thongso(15, fie, (sovaovien.Checked) ? "1" : "0");
            m.upd_thongso(16, fie, (soluutru.Checked) ? "1" : "0");
            m.upd_thongso(4, fie, soyte.Text.ToString().Trim());
            m.upd_thongso(5, fie, diachi.Text.ToString().Trim());
            m.upd_thongso(6, fie, dienthoai.Text.ToString().Trim());
            m.upd_thongso(-6, fie, mst.Text.ToString().Trim());
            m.upd_thongso(42, fie, c42.Value.ToString());
            m.upd_thongso(43, fie, c43.Value.ToString());
            m.upd_thongso(47, fie, (c47.Checked) ? "1" : "0");
            m.upd_thongso(48, fie, (c48.Checked) ? "1" : "0");
            m.upd_thongso(49, fie, ma13.Text);
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
            s_143 = "";
            for (int j = 0; j < c143.Items.Count; j++)
                if (c143.GetItemChecked(j)) s_143 += dtnhomvp_pttt.Rows[j]["ma"].ToString() + ",";
            m.upd_thongso(143, fie, s_143.Trim().Trim(','));
            //if (c1433.SelectedIndex != -1) m.upd_thongso(143, fie, c1433.SelectedValue.ToString());
            m.upd_thongso(144, fie, (c144.Checked) ? "1" : "0");
            m.upd_thongso(145, fie, (c145.Checked) ? "1" : "0");
            m.upd_thongso(146, fie, (c146.Checked) ? "1" : "0");
            if (c147.SelectedIndex != -1) m.upd_thongso(147, fie, (c147.SelectedIndex != -1) ? c147.SelectedValue.ToString() : "0");
            m.upd_thongso(148, fie, (c148.Checked) ? "1" : "0");
            if (c149.SelectedIndex != -1) m.upd_thongso(149, fie, (c149.SelectedIndex != -1) ? c149.SelectedValue.ToString() : "0");
            m.upd_thongso(150, fie, (c150.Checked) ? "1" : "0");
            //Tu:22/07/2011 thêm option Thu phí
            m.upd_thongso(1501, fie, (c1501.Checked) ? "1" : "0");
            //end Tu
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
            //
            s_191 = "";
            for (int j = 0; j < c191.Items.Count; j++)
                if (c191.GetItemChecked(j)) s_191 += dtkho_ng.Rows[j]["id"].ToString()+ ",";
            m.upd_thongso(191, fie, s_191);
            //if (c191.SelectedIndex != -1) m.upd_thongso(191, fie, c191.SelectedValue.ToString());
            //
            m.upd_thongso(192, fie, (c192.Checked) ? "1" : "0");
            m.upd_thongso(193, fie, (c193.SelectedIndex != -1 && c153.Checked) ? c193.SelectedValue.ToString() : "0");
            m.upd_thongso(194, fie, (c194.Checked) ? "1" : "0");//binh181108
            m.upd_thongso(195, fie, (c195.Checked) ? "1" : "0");//Khuong 19/05/2011
            m.upd_thongso(1135, fie, (c1135.Checked) ? "1" : "0");//Khuong 19/05/2011
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
            s_254 = "";
            for (int k = 0; k < c254.Items.Count; k++)
                if (c254.GetItemChecked(k)) s_254 += dtnhomvp_pttt_I05.Rows[k]["ma"].ToString() + ",";
            m.upd_thongso(254, fie, s_254.Trim().Trim(','));
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
            m.upd_thongso(1085, fie, c1085.Text);
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
            m.upd_thongso(3011, fie, (rbcaptheokhoa.Checked) ? "1" : "0");// Thuy 31.12.2011
            m.upd_thongso(3012, fie, (rbcaptheotv.Checked) ? "1" : "0");// Thuy 31.12.2011
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
            m.upd_thongso(1101, fie, (c1101.Checked) ? "1" : "0");
            m.upd_thongso(1505, fie, (c1505.Checked) ? "1" : "0");
            m.upd_thongso(1102, fie, (c1102.Checked) ? "1" : "0");
            m.upd_thongso(1103, fie, (c1103.Checked) ? "1" : "0");
            m.upd_thongso(1104, fie, (c1104.Checked) ? "1" : "0");//gam 11041012
            m.upd_thongso(1105, fie, (c1105.Checked) ? "1" : "0");//Thuy 11.10.2012
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
                m.execute_data("update " + user + ".dmcomputer set fmedisoft='" + r["fmedisoft"].ToString() + "',fduoc='" + r["fduoc"].ToString() + "',fvienphi='" + r["fvienphi"].ToString() + "',fxn='" + r["fxn"].ToString() + "',fcls='" + r["fcls"].ToString() + "' where id=" + decimal.Parse(r["id"].ToString()));

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
            m.upd_thongso(405, fie, (c405.Checked) ? "1" : "0");
            m.upd_thongso(406, fie, (c406.Checked) ? "1" : "0");
            m.upd_thongso(407, fie, (c407.Checked) ? "1" : "0");
            m.upd_thongso(408, fie, c408.Text);
            m.upd_thongso(409, fie, (c409.Checked) ? "1" : "0");
            m.upd_thongso(410, fie, (c410.Checked) ? "1" : "0");
            s_411 = "";
            for (int j = 0; j < c411.Items.Count; j++)
                if (c411.GetItemChecked(j)) s_411 += dt411.Rows[j]["madoituong"].ToString().PadLeft(2,'0') + ",";
            m.upd_thongso(411, fie, s_411);
            m.upd_thongso(412, fie, (c412.Checked) ? "1" : "0");
            m.upd_thongso(413, fie, (c413.Checked) ? "1" : "0");
            m.upd_thongso(414, fie, (c414.Checked) ? "1" : "0");
            s_415 = "";
            for (int j = 0; j < c415.Items.Count; j++)
                if (c415.GetItemChecked(j)) s_415 += dt415.Rows[j]["madoituong"].ToString().PadLeft(2,'0') + ",";
            m.upd_thongso(415, fie, s_415);

            s_416 = "";
            for (int j = 0; j < c416.Items.Count; j++)
                if (c416.GetItemChecked(j)) s_416 += dt416.Rows[j]["ma"].ToString().PadLeft(3, '0') + ",";
            m.upd_thongso(416, fie, s_416);
            m.upd_thongso(417, fie, (c414.Checked && c417.SelectedIndex != -1) ? c417.SelectedValue.ToString() : "0");
            m.upd_thongso(418, fie, (c414.Checked && c418.SelectedIndex != -1) ? c418.SelectedValue.ToString() : "0" );
            m.upd_thongso(419, fie, (c419.Checked) ? "1" : "0");
            m.upd_thongso(420, fie, (c420.Checked) ? "1" : "0");
            m.upd_thongso(421, fie, (c421.Checked) ? "1" : "0");
            m.upd_thongso(422, fie, (c422.Checked) ? "1" : "0");
            m.upd_thongso(423, fie, c423.Value.ToString());
            m.upd_thongso(424, fie, c424.Value.ToString());
            m.upd_thongso(425, fie, (c425.Checked) ? "1" : "0");
            m.upd_thongso(426, fie, (c426.Checked) ? "1" : "0");
            m.upd_thongso(427, fie, c427.Value.ToString());
            m.upd_thongso(428, fie, c428.Value.ToString());
            m.upd_thongso(429, fie, c429.Value.ToString());
            m.upd_thongso(430, fie, (c430.Checked) ? "1" : "0");
            m.upd_thongso(431, fie, c431.Value.ToString());
            m.upd_thongso(432, fie, (c432.Checked) ? "1" : "0");
            m.upd_thongso(433, fie, (c433.Checked) ? "1" : "0");
            //
            m.upd_thongso(434, fie, (c434.Checked) ? "1" : "0");//G60.1: khi chuyen khap cap nhat vao v-chidinh cua tat ca doi tuong
            m.upd_thongso(594,fie,c594.SelectedValue.ToString());//gam 11/08/2011
            //
            //linh
            m.upd_thongso(435, fie, (c435.Checked) ? "1" : "0");
            if (c435.Checked) save_Com();
            //end linh
            m.upd_thongso(438, fie, (c438.Checked) ? "1" : "0");
            m.upd_thongso(439, fie, (c439.Checked) ? "1" : "0");
            m.upd_thongso(440, fie, (c440.Checked) ? "1" : "0");
            m.upd_thongso(441, fie, (c441.Checked) ? "1" : "0");
            m.upd_thongso(442, fie, c442.Text);
            m.upd_thongso(443, fie, (c443.Checked) ? "1" : "0");
            //
            m.upd_thongso(1000, fie, C1000.Value.ToString());
            m.upd_thongso(1001, fie, (c1001.Checked) ? "1" : "0");
            m.upd_thongso(1002, fie, (c1002.Checked) ? "1" : "0");
            m.upd_thongso(1003, fie, (c1003.Checked) ? "1" : "0");
            if (c144.Checked) c1004.Checked = false;
            m.upd_thongso(1004, fie, (c1004.Checked) ? "1" : "0");
            m.upd_thongso(1005, fie, (c1005.Checked) ? "1" : "0");
            m.upd_thongso(1006, fie, (c1006.Checked) ? "1" : "0");
            m.upd_thongso(1007, fie, (c1007.Checked) ? "1" : "0");
            m.upd_thongso(1008, fie, c1008.Value.ToString());
            m.upd_thongso(1009, fie, (c1009.Checked) ? "1" : "0");
            m.upd_thongso(1010, fie, (c1010.Checked) ? "1" : "0");
            m.upd_thongso(1011, fie, (c1011.Checked) ? "1" : "0");
            m.upd_thongso(1012, fie, (c1012.Checked) ? "1" : "0");
            //
            m.upd_thongso(1013, fie, c1013.Value.ToString());
            m.upd_thongso(1014, fie, c1014.Value.ToString());
            m.upd_thongso(1015, fie, c1015.Value.ToString());
            m.upd_thongso(1016, fie, c1016.Value.ToString());
            m.upd_thongso(1017, fie, c1017.Value.ToString());
            m.upd_thongso(1018, fie, c1018.Value.ToString());
            m.upd_thongso(1019, fie, c1019.Value.ToString());
            m.upd_thongso(1020, fie, (c1020.Checked) ? "1" : "0");
            m.upd_thongso(1021, fie, (c1021.Checked) ? "1" : "0");
            m.upd_thongso(1022, fie, (c1022.Checked) ? "1" : "0");
            m.upd_thongso(1023, fie, (c1023.Checked) ? "1" : "0");
            m.upd_thongso(1024, fie, (c1024.Checked) ? "1" : "0");
            m.upd_thongso(1025, fie, (c1025.Checked) ? "1" : "0");
            m.upd_thongso(1026, fie, (c1026.Checked) ? "1" : "0");
            m.upd_thongso(1027, fie, (c1027.Checked) ? "1" : "0");
            m.upd_thongso(1028, fie, (c1028.Checked) ? "1" : "0");
            m.upd_thongso(1029, fie, (c1029.Checked) ? "1" : "0");
            m.upd_thongso(1030, fie, c1030.Value.ToString());
            m.upd_thongso(1031, fie, (c1031.Checked) ? "1" : "0");
            m.upd_thongso(1032, fie, (c1032.Checked) ? "1" : "0");
            m.upd_thongso(1033, fie, (c1033.Checked) ? "1" : "0");
            m.upd_thongso(1034, fie, (c1034.Checked) ? "1" : "0");
            m.upd_thongso(1035, fie, (c1035.Checked) ? "1" : "0");
            m.upd_thongso(1036, fie, (c1036.Checked) ? "1" : "0");
            m.upd_thongso(1037, fie, (c1037.Checked) ? "1" : "0");
            m.upd_thongso(1038, fie, (c1038.Checked) ? "1" : "0");
            m.upd_thongso(1039, fie, (c1039.Checked) ? "1" : "0");
            m.upd_thongso(1040, fie, (c1040.Checked) ? "1" : "0");
            m.upd_thongso(1041, fie, (c1041.Checked) ? "1" : "0");
            m.upd_thongso(1042, fie, (c1042.Checked) ? "1" : "0");
            m.upd_thongso(1043, fie, (c1043.Checked) ? "1" : "0");
            m.upd_thongso(1044, fie, (c1044.Checked) ? "1" : "0");
            m.upd_thongso(1045, fie, (c1045.Checked) ? "1" : "0");
            m.upd_thongso(1046, fie, (c1046.Checked) ? "1" : "0");
            m.upd_thongso(1047, fie, (c1047.Checked) ? "1" : "0");
            m.upd_thongso(1048, fie, (c1048.Checked) ? "1" : "0");
            m.upd_thongso(1049, fie, (c1049.Checked) ? "1" : "0");
            m.upd_thongso(1050, fie, (c1050.Checked) ? "1" : "0");
            m.upd_thongso(1051, fie, (c1051.Checked) ? "1" : "0");
            m.upd_thongso(1052, fie, (c1052.Checked) ? "1" : "0");
            m.upd_thongso(1053, fie, (c1053.Checked) ? "1" : "0");
            m.upd_thongso(1054, fie, (c1054.Checked) ? "1" : "0");
            m.upd_thongso(1055, fie, (c1055.Checked) ? "1" : "0");
            m.upd_thongso(1056, fie, (c1056.Checked) ? "1" : "0");
            m.upd_thongso(1057, fie, (c1057.Checked) ? "1" : "0");
            m.upd_thongso(1058, fie, (c1058.Checked) ? "1" : "0");
            m.upd_thongso(1059, fie, (c1059.Checked) ? "1" : "0");
            m.upd_thongso(1060, fie, (c1060.Checked) ? "1" : "0");
            m.upd_thongso(1061, fie, (c1061.Checked) ? "1" : "0");
            m.upd_thongso(1062, fie, c1062.Value.ToString());
            m.upd_thongso(1063, fie, c1063.Value.ToString());
            m.upd_thongso(1064, fie, (c1064.Checked) ? "1" : "0");
            m.upd_thongso(1065, fie, (c1065.Checked) ? "1" : "0");
            m.upd_thongso(1066, fie, (c1066.Checked) ? "1" : "0");
            m.upd_thongso(1067, fie, (c1067.Checked) ? "1" : "0");
            m.upd_thongso(1068, fie, (c1068.Checked) ? "1" : "0");
            m.upd_thongso(1069, fie, c1069.Value.ToString());
            m.upd_thongso(1070, fie, (c1070.Checked) ? "1" : "0");
            m.upd_thongso(1071, fie, (c1071.Checked) ? "1" : "0");
            m.upd_thongso(1072, fie, (c1072.Checked) ? "1" : "0");
            m.upd_thongso(1073, fie, (c1073.Checked) ? "1" : "0");
            m.upd_thongso(1074, fie, (c1074.Checked) ? "1" : "0");
            m.upd_thongso(1075, fie, (c1075.Checked) ? "1" : "0");
            m.upd_thongso(1076, fie, (c1076.Checked) ? "1" : "0");
            m.upd_thongso(1077, fie, (c1077.Checked) ? "1" : "0");
            m.upd_thongso(1078, fie, (c1078.Checked) ? "1" : "0");
            m.upd_thongso(1079, fie, (c1079.Checked) ? "1" : "0");
            m.upd_thongso(1080, fie, (c1080.Checked) ? "1" : "0");
            m.upd_thongso(1081, fie, (c1081.Checked) ? "1" : "0");
            m.upd_thongso(1082, fie, (c1082.Checked) ? "1" : "0");
            m.upd_thongso(1083, fie, (c1083.Checked) ? "1" : "0");
            m.upd_thongso(1084, fie, (c1084.Checked) ? "1" : "0");
            m.upd_thongso(1086, fie, (c1086.Checked) ? "1" : "0");
            m.upd_thongso(1087, fie, (c1087.Checked) ? "1" : "0");
            if (c179.Checked == false) c1088.Checked = false;
            m.upd_thongso(1088, fie, (c1088.Checked) ? "1" : "0");
            m.upd_thongso(1089, fie, (c1089.Checked) ? "1" : "0");
            //Tú:28/06/2011 thêm thông số soluutru tăng tự động trong phòng khám, phòng lưu, ngoại trú
            m.upd_thongso(1090, fie, (c1090.Checked) ? "1" : "0");
           //end Tú

            //Tú:22/08/2011 thêm thông số kiểm tra số thẻ hợp theo qui định của BHYT
            m.upd_thongso(997, fie, (c997.Checked) ? "1" : "0");
            m.upd_thongso(9971, fie, txtkituchu.Text);
            m.upd_thongso(9972, fie, txtmatinh.Text);
            //end Tú
            m.upd_thongso(1091, fie, (c1091.Checked) ? "1" : "0");
            m.upd_thongso(998, fie, (c998.Checked) ? "1" : "0");
            m.upd_thongso(999, fie, (c999.SelectedIndex == -1) ? "" : c999.SelectedValue.ToString());
            //
            m.upd_thongso(1092, fie, (c1092.Checked) ? "1" : "0");
            m.upd_thongso(1093, fie, (c1093.Checked) ? "1" : "0");
            m.upd_thongso(1094, fie, c1094.Text);
            m.upd_thongso(1095, fie, (c1095.Checked) ? "1" : "0");
            m.upd_thongso(1096, fie, (c1096.Checked) ? "1" : "0");
            m.upd_thongso(1097, fie, (c1097.Checked) ? "1" : "0");
            m.upd_thongso(1098, fie, (c1098.Checked) ? "1" : "0");// Thuy : 30.12.2011 thêm checkbox thông báo số vào viện
            m.upd_thongso(1099, fie, (c1099.Checked) ? "1" : "0");// Thuy : 30.12.2011 thêm checkbox thông báo số lưu trữ
            //Khuong 03/11 Them thong so F43: don thuoc dich vu duoc phep cap nhieu lan trong ngay
            m.upd_thongso(1100, fie, (c1100.Checked) ? "1" : "0"); 
            m.upd_thongso(1512, fie, (c1512.Checked) ? "1" : "0");
            //
            m.upd_thongso(1260, fie, (c1260.Checked) ? "1" : "0");//phan loai danh dau cap toa --> khi cap toa toc theo phan loai
            m.upd_thongso(1261, fie, (c1261.Checked) ? "1" : "0");//chi phi > tam ung khong cho lam cls
            //
            m.upd_thongso(445, fie, (c445.Checked) ? "1" : "0");//gam 09/09/2011 thêm thông số quản lý thuốc mổ ở tab Dược
            m.upd_thongso(595, fie, (c595.Checked) ? "1" : "0");//gam 18/10/2011
            m.upd_thongso(50,fie, c49.Text);
            m.upd_thongso(-50,fie, c175.Text);
            m.upd_thongso(446, fie, (c446.Checked) ? "1" : "0");//gam 11/01/2012 thêm G91.
            m.upd_thongso(62, fie, (c62.Checked) ? "1" : "0");//gam 12/01/2012 thêm E30.
            m.upd_thongso(1502, fie, (c1502.Checked) ? "1" : "0");//gam 14/02/2012 thêm G92.
            m.upd_thongso(1503, fie, (C1503.Checked) ? "1" : "0");//Thuy 22.02.2012
            m.upd_thongso(1504, fie, (c1504.Checked) ? "1" : "0");//Thuy 11.06.2012
            m.upd_thongso(1506, fie, (c1506.Checked) ? "1" : "0");//Thuy 17.12.2012
            m.upd_thongso(1507, fie, (c1507.Checked) ? "1" : "0");//Thuy 02.01.2013
            //ThanhCuong - 06/08/2012 - Kỹ thuật cao
            m.upd_thongso(1137, fie, (c1137.Checked) ? "1" : "0");
            m.upd_thongso(1138, fie, c1138.Text);
            m.upd_thongso(1139, fie, c1139.Text);
            m.upd_thongso(1140, fie, c1140.Value.ToString());
            m.upd_thongso(1141, fie, c1141.Text);
            m.upd_thongso(1508, fie, (c1508.Checked) ? "1" : "0");
            m.upd_thongso(1509, fie, (c1509.Checked) ? "1" : "0");
            m.upd_thongso(1510, fie, c1510.Value.ToString());
            m.upd_thongso(1511, fie, (c1511.Checked) ? "1" : "0");
            m.upd_thongso(1513, fie, (c1513.Checked) ? "1" : "0");
            m.upd_thongso(1600, fie, (c1600.Checked) ? "1" : "0");
            m.upd_thongso(50114, fie, (c50114.Checked) ? "1" : "0");//truongthuy 23.04.2014 them C79
            //End
            //linh
            m.upd_thongso(50034, fie, (c50034.Checked) ? "1" : "0"); //thuytruong 19.04.2014  //  thêm  E34
            m.upd_thongso(40091, fie, (c40091.Checked) ? "1" : "0"); //thuytruong 30.05.2014  //  thêm  D29
            if (numSongaychotoa.Tag.ToString() != numSongaychotoa.Value.ToString())
            {
                m.upd_thongso((int)LibMedi.IDThongSo.ID_SoNgayToaThuocCanCanhBao, fie, numSongaychotoa.Value.ToString());
            }
            //linh 25092012
            if (chkApDungThongTuLienTich15042012.Tag.ToString() != chkApDungThongTuLienTich15042012.Checked.ToString())//linh 25/9/2012
            {
                m.upd_thongso((int)IDThongSo.ID_ThongTuLienTich15042012, fie, chkApDungThongTuLienTich15042012.Checked ? "1" : "0");
                m.upd_thongso((int)IDThongSo.ID_NgayBenhNhanThongTuLienTich15042012, fie, txtNgayBenhNhanThongTuLienTich.Text);
                m.upd_thongso((int)IDThongSo.ID_NgayVienPhiThongTuLienTich15042012, fie, cboNgayGiaVienPhiThongTuLienTich.Text);
                chkApDungThongTuLienTich15042012.Tag = chkApDungThongTuLienTich15042012.Checked.ToString();
                txtNgayBenhNhanThongTuLienTich.Tag = txtNgayBenhNhanThongTuLienTich.Text;
                cboNgayGiaVienPhiThongTuLienTich.Tag = cboNgayGiaVienPhiThongTuLienTich.Text;
            }
            else
            {
                if (chkApDungThongTuLienTich15042012.Checked)
                {
                    if (txtNgayBenhNhanThongTuLienTich.Tag.ToString() != txtNgayBenhNhanThongTuLienTich.Text)
                    {
                        m.upd_thongso((int)IDThongSo.ID_NgayBenhNhanThongTuLienTich15042012, fie, txtNgayBenhNhanThongTuLienTich.Text.Trim().Trim('/').Trim());
                        txtNgayBenhNhanThongTuLienTich.Tag = txtNgayBenhNhanThongTuLienTich.Text.Trim().Trim('/').Trim();
                    }
                    if (cboNgayGiaVienPhiThongTuLienTich.Tag.ToString() != cboNgayGiaVienPhiThongTuLienTich.Text)
                    {
                        m.upd_thongso((int)IDThongSo.ID_NgayVienPhiThongTuLienTich15042012, fie, cboNgayGiaVienPhiThongTuLienTich.Text);
                        cboNgayGiaVienPhiThongTuLienTich.Tag = cboNgayGiaVienPhiThongTuLienTich.Text;
                    }
                }
            }
            //end linh
            //end linh
            #region dataset
            m.execute_data("update " + user + ".d_thongso set ten='" + d50.Text + "' where id=50");
            m.execute_data("update " + user + ".d_thongso set ten='" + d51.Text + "' where id=51");
            m.execute_data("update " + user + ".d_thongso set ten='" + d52.Text + "' where id=52");
            m.execute_data("update " + user + ".d_thongso set ten='" + d53.Text + "' where id=53");
            m.execute_data("update " + user + ".d_thongso set ten='" + c175.Text + "' where id=175");

            dsts.Tables[0].Rows[0]["c14"] = songay.Value.ToString().Trim(); m.upd_thongso(14, fie, songay.Value.ToString().Trim());
            dsts.Tables[0].Rows[0]["c17"] = (chandoan.Checked) ? "1" : "0"; m.upd_thongso(33, fie, (chandoan.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c18"] = (pttt.Checked) ? "1" : "0"; m.upd_thongso(18, fie, (pttt.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c21"] = (ngaylv.Checked) ? "1" : "0"; m.upd_thongso(21, fie, (ngaylv.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c22"] = (solieu.Checked) ? "1" : "0"; m.upd_thongso(22, fie, (solieu.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c23"] = (khambenh.Checked) ? "1" : "0"; m.upd_thongso(23, fie, (khambenh.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c25"] = (noichuyen.Checked) ? "1" : "0"; m.upd_thongso(25, fie, (noichuyen.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c26"] = (bsKhambenh.Checked) ? "1" : "0"; m.upd_thongso(26, fie, (bsKhambenh.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c27"] = (bsNgoaitru.Checked) ? "1" : "0"; m.upd_thongso(27, fie, (bsNgoaitru.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c28"] = (bsNhanbenh.Checked) ? "1" : "0"; m.upd_thongso(28, fie, (bsNhanbenh.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c29"] = (bsNhapkhoa.Checked) ? "1" : "0"; m.upd_thongso(29, fie, (bsNhapkhoa.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c30"] = (bsXuatkhoa.Checked) ? "1" : "0"; m.upd_thongso(30, fie, (bsXuatkhoa.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c31"] = (bsXuatvien.Checked) ? "1" : "0"; m.upd_thongso(31, fie, (bsXuatvien.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c32"] = (bsPttt.Checked) ? "1" : "0"; m.upd_thongso(32, fie, (bsPttt.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c33"] = (saoluu33.Checked) ? "1" : "0"; m.upd_thongso(33, fie, (saoluu33.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c36"] = (c36.Checked) ? "1" : "0"; m.upd_thongso(36, fie, (c36.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c38"] = (c38.Checked) ? "1" : "0"; m.upd_thongso(38, fie, (c48.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c44"] = (c44.Checked) ? "1" : "0"; m.upd_thongso(44, fie, (c44.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c45"] = (c45.Checked) ? "1" : "0"; m.upd_thongso(45, fie, (c45.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c46"] = (c46.Checked) ? "1" : "0"; m.upd_thongso(46, fie, (c46.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c47"] = (c47.Checked) ? "1" : "0"; m.upd_thongso(47, fie, (c47.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c48"] = (c48.Checked) ? "1" : "0"; m.upd_thongso(48, fie, (c48.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c51"] = (c51.Checked) ? "1" : "0"; m.upd_thongso(51, fie, (c51.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c52"] = (c52.Checked) ? "1" : "0"; m.upd_thongso(52, fie, (c52.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c53"] = (c53.Checked) ? "1" : "0"; m.upd_thongso(53, fie, (c53.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c55"] = (c55.Checked) ? "1" : "0"; m.upd_thongso(55, fie, (c55.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c57"] = (c57.Checked) ? "1" : "0"; m.upd_thongso(57, fie, (c57.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c58"] = (c58.Checked) ? "1" : "0"; m.upd_thongso(58, fie, (c58.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c61"] = (c61.Checked) ? "1" : "0"; m.upd_thongso(61, fie, (c61.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c134"] = (c134.Checked) ? "1" : "0"; m.upd_thongso(134, fie, (c134.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c39"] = c39.Text; m.upd_thongso(39, fie, c39.Text );
            dsts.Tables[0].Rows[0]["c40"] = c40.Text; m.upd_thongso(40, fie, c40.Text);
            dsts.Tables[0].Rows[0]["c41"] = c41.Text;m.upd_thongso(41, fie, c41.Text );
            dsts.Tables[0].Rows[0]["c105"] = (c105.Checked) ? "1" : "0"; m.upd_thongso(105, fie, (c105.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c116"] = (c116.Checked) ? "1" : "0"; m.upd_thongso(116, fie, (c116.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c125"] = (c125.Checked) ? "1" : "0"; m.upd_thongso(125, fie, (c125.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c126"] = (c126.Checked) ? "1" : "0"; m.upd_thongso(126, fie, (c126.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c127"] = (c127.Checked) ? "1" : "0"; m.upd_thongso(127, fie, (c127.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c140"] = (c140.Checked) ? "1" : "0"; m.upd_thongso(140, fie, (c140.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c177"] = (c177.Checked) ? "1" : "0"; m.upd_thongso(177, fie, (c177.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c178"] = (c178.Checked) ? "1" : "0"; m.upd_thongso(178, fie, (c178.Checked) ? "1" : "0");
            dsts.Tables[0].Rows[0]["c195"] = (c195.Checked) ? "1" : "0"; m.upd_thongso(195, fie, (c195.Checked) ? "1" : "0");
            try
            {
                dsts.Tables[0].Rows[0]["c1135"] = (c1135.Checked) ? "1" : "0";
            }
            catch { }
            dsts.Tables[0].Rows[0]["c196"] = (c196.SelectedIndex != -1) ? c196.SelectedValue.ToString() : "0";
            dsts.Tables[0].Rows[0]["ngonngu"] = ngonngu.SelectedIndex.ToString();
           //linh
            upd_xml();
            if (i_ngonngu != ngonngu.SelectedIndex) upd_ngonngu();//linh //binh 180611
            
            // hien 21-06-2011
            if (c1136.Checked)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[chkdmNhom.DataSource];
                DataView dv = (DataView)cm.List;
                for (int j = 0; j < chkdmNhom.Items.Count; j++)
                    if (chkdmNhom.GetItemChecked(j)) s_1136 += dv.Table.Rows[j]["id"].ToString() + ",";
            }
            else
            {
                s_1136 = "";
            }
            m.upd_thongso(1136, fie, s_1136);
            // end hien
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
            #endregion
            //Tu:09/05/2011
            m.writeXml("thongso", "t01", (chktutruc.Checked) ? "1" : "0");
            m.writeXml("thongso", "t02", (chkkho.Checked) ? "1" : "0");
            m.writeXml("thongso", "cbophongtc", (cbophongtc.SelectedIndex < 0) ? "0" : cbophongtc.SelectedValue.ToString());
            m.writeXml("thongso", "cbotutruc", (cbotutruc.SelectedIndex < 0) ? "0" : cbotutruc.SelectedValue.ToString());
            m.writeXml("thongso", "cbokhotc", (cbokhotc.SelectedIndex < 0) ? "0" : cbokhotc.SelectedValue.ToString());
            //end Tu
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
            else if (e.KeyCode == Keys.F3)
            {
                Cursor = Cursors.WaitCursor;
                tao_thongso_tim();
                capnhat_control();
                Cursor = Cursors.Default;
            }
            else if (bAdmin)
            {
                if (e.KeyCode == Keys.F5) load_tso("tendef");//load default
                else if (e.KeyCode == Keys.F6)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý lưu thông số mặc nhiên ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        upd_tso("tendef");//update default 
                        MessageBox.Show(lan.Change_language_MessageText("Đã lưu thông số mặc nhiên !"), LibMedi.AccessData.Msg);
                    }
                }
                else if (e.KeyCode == Keys.F7) load_tso("tencur"); //load current
                else if (e.KeyCode == Keys.F8)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý lưu thông số cấu hình ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        upd_tso("tencur"); //upddate current
                        MessageBox.Show(lan.Change_language_MessageText("Đã lưu thông số cấu hình !"), LibMedi.AccessData.Msg);
                    }
                }
            }
            if (e.KeyCode == Keys.B && e.Control && e.Shift && e.Alt)
            {
                bTenvien = !bTenvien;
                matt.Enabled = bTenvien;
                maqu.Enabled = bTenvien;
                benhvien.Enabled = bTenvien;
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
            string sDir = System.Environment.CurrentDirectory.ToString();
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "Chọn đường dẫn file thông báo.";
            fb.ShowDialog();
            c115.Text = fb.SelectedPath;
            System.Environment.CurrentDirectory = sDir;
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
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "Chọn đường dẫn sao lưu số liệu.";
            fb.ShowDialog();
            c174.Text = fb.SelectedPath;
            //frmThumuc f=new frmThumuc(c174.Text,"Chọn thư mục sao lưu số liệu",0);
            //f.ShowDialog();
            //if (f.s_dir!="") c174.Text=f.s_dir;
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
            c1047.Enabled = c140.Checked;
            if (!c140.Checked) { c177.Checked = false; c1047.Checked = false; }
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
                rbcaptheokhoa.Enabled = c226.Checked;
                rbcaptheotv.Enabled = c226.Checked;
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
            c420.Enabled=c229.Enabled = c1512.Enabled = c228.Checked;
        }

        private void c235_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c235)
            {
                c236.Enabled = c235.Checked;
                c247.Enabled = !c235.Checked;
                c278.Enabled = c235.Checked;
                c279.Enabled = c235.Checked;
                c1071.Enabled = c235.Checked;
                c1070.Enabled = c235.Checked;
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
                p01_chung.Visible = false;p02_hanhchinh.Visible = false;p03_chuyenmon.Visible = false;
                p04_masotudong.Visible = false;p05_doituong.Visible = false;p06_duoc.Visible = false;
                p07_vienphi.Visible = false;p08_CLS.Visible = false;p09_phauthuthuat.Visible = false;
                p11_bangdien.Visible = false;p10_phonggiuong.Visible = false;p12_khamsuckhoe.Visible = false;
                p13.Visible = false; p14.Visible = false;

                switch (treeView1.SelectedNode.Tag.ToString())
                {
                    case "p01": p01_chung.Visible = true; check(p01_chung); break;
                    case "p02": p02_hanhchinh.Visible = true; check(p02_hanhchinh); break;
                    case "p03": p03_chuyenmon.Visible = true; check(p03_chuyenmon); break;
                    case "p04": p04_masotudong.Visible = true; check(p04_masotudong); break;
                    case "p05": p05_doituong.Visible = true; check(p05_doituong); break;
                    case "p06": p06_duoc.Visible = true; check(p06_duoc); f300(); f356_358();break;
                    case "p07": p07_vienphi.Visible = true; check(p07_vienphi); f397(); break;
                    case "p08": p08_CLS.Visible = true; check(p08_CLS); break;
                    case "p09": p09_phauthuthuat.Visible = true; check(p09_phauthuthuat); break;
                    case "p10": p10_phonggiuong.Visible = true; check(p10_phonggiuong); break;
                    case "p11": p11_bangdien.Visible = true; check(p11_bangdien); break;
                    case "p12": p12_khamsuckhoe.Visible = true; check(p12_khamsuckhoe); break;
                    case "p13": p13.Visible = true; check(p13); break;
                    case "p14": p14.Visible = true; check(p14); break;
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
            for (int i = 0; i < c411.Items.Count; i++)
                if (s_411.IndexOf(dt411.Rows[i]["madoituong"].ToString().PadLeft(2,'0')) != -1) c411.SetItemCheckState(i, CheckState.Checked);
                else c411.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < c415.Items.Count; i++)
                if (s_415.IndexOf(dt415.Rows[i]["madoituong"].ToString().PadLeft(2, '0')) != -1) c415.SetItemCheckState(i, CheckState.Checked);
                else c415.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < c416.Items.Count; i++)
                if (s_416.IndexOf(dt416.Rows[i]["ma"].ToString().PadLeft(3, '0')) != -1) c416.SetItemCheckState(i, CheckState.Checked);
                else c416.SetItemCheckState(i, CheckState.Unchecked);
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
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "Chọn đường dẫn.";
            fb.ShowDialog();
            tTemp.Text = fb.SelectedPath;
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
                c57.Checked = (c57.Checked) ? false : c57.Checked;
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
            if (this.ActiveControl == c179) c395.Enabled = c359.Enabled = c335.Enabled = c302.Enabled = c1088.Enabled = c179.Checked;
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
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "Chọn đường dẫn.";
            fb.ShowDialog();
            c341.Text = fb.SelectedPath;
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
                if (c382.Checked)
                {
                    c1024.Enabled = true;
                }
                else
                {
                    c1024.Checked = false;
                    c102.Enabled = false;
                }
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
   
        private void load_tooltip()
        {
            ToolTip tip = new ToolTip();
            DataSet dstooltip = new DataSet();
            if (!System.IO.File.Exists(@"..\..\..\xml\tooltip_medi.xml"))
            {
                dstooltip = m.get_data("select '' control_name,'' text,'' vie,'' eng from dual").Clone();
                dstooltip.WriteXml(@"..\..\..\xml\tooltip_medi.xml", XmlWriteMode.WriteSchema);
            }
            dstooltip.ReadXml(@"..\..\..\xml\tooltip_medi.xml", XmlReadMode.ReadSchema);
            foreach (Control c in this.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.Panel":
                    case "System.Windows.Forms.GroupBox":
                        foreach (Control c2 in c.Controls)
                        {
                            DataRow r = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c2.Name + "'");
                            if (r == null)
                            {
                                DataRow nr = dstooltip.Tables[0].NewRow();
                                nr["control_name"] = c2.Name.ToString();
                                nr["text"] = c2.Text.Trim().ToString();
                                dstooltip.Tables[0].Rows.Add(nr);
                            }
                            else
                            {
                                r["text"] = c2.Text.Trim().ToString();
                                if (r["vie"].ToString().Trim() == "") r["vie"] = r["text"].ToString().Trim();
                                string strtip = r["vie"].ToString();
                                if (strtip.Length > 400)
                                {
                                    string[] a = strtip.Split(' ');
                                }
                                tip.SetToolTip(c2, "[" + c2.Name + "] " + strtip);
                            }
                            dstooltip.AcceptChanges();
                        }
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabclt = (TabControl)c;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            foreach (Control c3 in tab.Controls)
                            {
                                DataRow r = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c3.Name + "'");
                                if (r == null)
                                {
                                    DataRow nr = dstooltip.Tables[0].NewRow();
                                    nr["control_name"] = c3.Name.ToString();
                                    nr["text"] = c3.Text.Trim().ToString();
                                    dstooltip.Tables[0].Rows.Add(nr);
                                }
                                else
                                {
                                    r["text"] = c3.Text.Trim().ToString();
                                    if (r["vie"].ToString().Trim() == "") r["vie"] = r["text"].ToString().Trim();
                                    tip.SetToolTip(c3, "[" + c3.Name + "] " + r["vie"].ToString());
                                }
                                dstooltip.AcceptChanges();
                            }
                        }
                        break;
                    default:
                        DataRow r2 = m.getrowbyid(dstooltip.Tables[0], "control_name='" + c.Name + "'");
                        if (r2 == null)
                        {
                            DataRow nr = dstooltip.Tables[0].NewRow();
                            nr["control_name"] = c.Name.ToString();
                            nr["text"] = c.Text.Trim().ToString();
                            dstooltip.Tables[0].Rows.Add(nr);
                        }
                        else
                        {
                            r2["text"] = c.Text.Trim().ToString();
                            if (r2["vie"].ToString().Trim() == "") r2["vie"] = r2["text"].ToString().Trim();
                            tip.SetToolTip(c, "[" + c.Name + "] " + r2["vie"].ToString());
                        }
                        break;
                }
                dstooltip.AcceptChanges();
            }
            dstooltip.WriteXml(@"..\..\..\xml\tooltip_medi.xml", XmlWriteMode.WriteSchema);
        }

        private void c217_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c217) c161.Enabled = c217.Checked;
        }

        private void c411_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c411.CheckedItems.Count > 0)
            {
                s_411 = "";
                for (int j = 0; j < c411.Items.Count; j++)
                    if (c411.GetItemChecked(j)) s_411 += dt411.Rows[j]["madoituong"].ToString().PadLeft(2, '0') + ",";
            }
        }

        private void c410_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c410) c411.Enabled = c410.Checked;
        }

        private void c415_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c415.CheckedItems.Count > 0)
            {
                s_415 = "";
                for (int j = 0; j < c415.Items.Count; j++)
                    if (c415.GetItemChecked(j)) s_415 += dt415.Rows[j]["madoituong"].ToString().PadLeft(2, '0') + ",";
            }
        }

        private void c416_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c416.CheckedItems.Count > 0)
            {
                s_416 = "";
                for (int j = 0; j < c416.Items.Count; j++)
                    if (c416.GetItemChecked(j)) s_416 += dt416.Rows[j]["ma"].ToString().PadLeft(3, '0') + ",";
                sql = "select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id ";
                if (s_416 != "") sql += " and b.id_nhom in (" + s_416.Substring(0, s_416.Length - 1) + ")";
                sql += " order by a.ten";
                c417.DataSource = m.get_data(sql).Tables[0];
                c417.SelectedValue = m.iKhoan_mavp.ToString();
                c418.DataSource = m.get_data(sql).Tables[0];
                c418.SelectedValue = m.iKhoan_mavp_pttt.ToString();
            }
        }

        private void c414_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c414) c415.Enabled = c416.Enabled = c417.Enabled=c418.Enabled=c414.Checked;
        }

        private void c426_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c426) c438.Enabled=c431.Enabled=c427.Enabled = c428.Enabled = c426.Checked;
        }

        #region Capnhatthongso        
        private void capnhat_control()
        {
            string s_control = "", s_text = "", s_loai = "", s_giatri = "";

            foreach (Control c in this.Controls)
            {
                s_control = ""; s_text = ""; s_loai = "";
                if (c.GetType().ToString() == "System.Windows.Forms.Panel" || c.GetType().ToString() == "System.Windows.Forms.GroupBox" || c.GetType().ToString() == "System.Windows.Forms.TabControl" || c.GetType().ToString() == "System.Windows.Forms.TabPage" || c.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    capnhat_control(c);
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "CheckBox";
                    //CheckBox chk=CheckBox(c);
                    //s_giatri=(chk.Checked)?"1":"0";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ComboBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ListBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ListBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "TextBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "Label";
                }
                if (s_control != "")
                {
                    m.upd_m_thongso_tim("m_thongso_tim", s_control, s_text, s_loai);
                }
            }
        }
        private void capnhat_control(Control ctls)
        {
            string s_control = "", s_text = "", s_loai = "", s_parent = "";
            s_parent = ctls.Name;
            foreach (Control c in ctls.Controls)
            {
                s_control = ""; s_text = ""; s_loai = "";
                if (c.GetType().ToString() == "System.Windows.Forms.Panel" || c.GetType().ToString() == "System.Windows.Forms.GroupBox" || c.GetType().ToString() == "System.Windows.Forms.TabControl" || c.GetType().ToString() == "System.Windows.Forms.TabPage" || c.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    capnhat_control(c);
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "CheckBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ComboBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ListBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ListBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "TextBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "Label";
                }
                if (s_control != "")
                {
                    m.upd_m_thongso_tim("m_thongso_tim", s_control, s_text, s_parent + " - " + s_loai);
                }
            }
        }        
        private void capnhat_control1()
        {
            string s_control = "", s_text = "", s_loai = "";
            string s_control1 = "", s_text1 = "", s_loai1 = "";
            foreach (Control c in this.Controls)
            {
                s_control = ""; s_text = ""; s_loai = "";
                if (c.GetType().ToString() == "System.Windows.Forms.Panel" || c.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    foreach (Control c1 in c.Controls)
                    {
                        s_control1 = ""; s_text1 = ""; s_loai1 = "";
                        if (c1.GetType().ToString() == "System.Windows.Forms.CheckBox")
                        {
                            s_control1 = c1.Name;
                            s_text1 = c1.Text;
                            s_loai1 = "CheckBox";
                        }
                        else if (c1.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            s_control1 = c1.Name;
                            s_text1 = c1.Name;
                            s_loai1 = "ComboBox";
                        }
                        else if (c1.GetType().ToString() == "System.Windows.Forms.ListBox")
                        {
                            s_control1 = c1.Name;
                            s_text1 = c1.Name;
                            s_loai1 = "ListBox";
                        }
                        else if (c1.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            s_control1 = c1.Name;
                            s_text1 = c1.Name;
                            s_loai1 = "TextBox";
                        }
                        else if (c1.GetType().ToString() == "System.Windows.Forms.Label")
                        {
                            s_control1 = c1.Name;
                            s_text1 = c1.Text;
                            s_loai1 = "Label";
                        }
                        if (s_control1 != "")
                        {
                            m.upd_m_thongso_tim("m_thongso_tim", s_control1, s_text1, s_loai1);
                        }
                    }
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "CheckBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ComboBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.ListBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "ListBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    s_control = c.Name;
                    s_text = c.Name;
                    s_loai = "TextBox";
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    s_control = c.Name;
                    s_text = c.Text;
                    s_loai = "Label";
                }
                if (s_control != "")
                {
                    m.upd_m_thongso_tim("m_thongso_tim", s_control, s_text, s_loai);
                }
            }
        }
        #endregion
        //linh
        private void c435_CheckedChanged(object sender, EventArgs e)
        {
            cboPort.Enabled = c435.Checked;
            cboDatabit.Enabled = c435.Checked;
            cboStopbit.Enabled = c435.Checked;
            cboParity.Enabled = c435.Checked;
            cboBaudrate.Enabled = c435.Checked;
            if (c435.Checked) load_Com();
        }
        void load_Com_()
        {
            foreach (string s in SerialPort.GetPortNames()) cboPort.Items.Add(s);
            try
            {
                dsCom.ReadXml(@"..\..\..\xml\m_cauhinh.xml", XmlReadMode.ReadSchema);
                string port = dsCom.Tables[0].Rows[0]["port"].ToString();
                cboPort.Text = port;
                string format = dsCom.Tables[0].Rows[0]["config"].ToString();
                string[] config = format.Split(',');
                string baudrate = config[0];
                cboBaudrate.Text = baudrate;
                string parity = config[1];
                if (parity.ToLower() == "n") cboParity.SelectedIndex = 0;
                else if (parity.ToLower() == "o") cboParity.SelectedIndex = 1;
                else cboParity.SelectedIndex = 2;
                string databit = config[2];
                cboDatabit.Text = databit;
                string stopbit = config[3];
                cboStopbit.Text = stopbit;
            }
            catch { }
        }
        void save_Com_()
        {
            dsCom.Tables[0].Rows[0]["port"] = cboPort.Text;
            dsCom.Tables[0].Rows[0]["config"] = cboBaudrate.Text.Trim() + "," + cboParity.Text.Trim().Substring(0, 1).ToLower() + "," + cboDatabit.Text.Trim() + "," + cboStopbit.Text.Trim();
            dsCom.AcceptChanges();
            dsCom.WriteXml(@"..\..\..\xml\m_cauhinh.xml", XmlWriteMode.WriteSchema);
        }

        void load_Com()
        {
            foreach (string s in SerialPort.GetPortNames()) cboPort.Items.Add(s);
            try
            {
                dsCom.ReadXml(@"..\..\..\xml\m_cauhinh.xml", XmlReadMode.ReadSchema);
                string port = dsCom.Tables[0].Rows[0]["port"].ToString();
                cboPort.Text = port;
                string format = dsCom.Tables[0].Rows[0]["config"].ToString();
                string[] config = format.Split(',');
                string baudrate = config[0];
                cboBaudrate.Text = baudrate;
                string parity = config[1];
                if (parity.ToLower() == "n") cboParity.SelectedIndex = 0;
                else if (parity.ToLower() == "o") cboParity.SelectedIndex = 1;
                else cboParity.SelectedIndex = 2;
                string databit = config[2];
                cboDatabit.Text = databit;
                string stopbit = config[3];
                cboStopbit.Text = stopbit;
            }
            catch
            {
                dsCom.Tables.Add();
                dsCom.Tables[0].Columns.Add("port", typeof(string));
                dsCom.Tables[0].Columns.Add("config", typeof(string));
            }
        }
        void save_Com()
        {
            try
            {
                if (dsCom.Tables[0].Rows.Count == 0)
                {
                    DataRow dr = dsCom.Tables[0].NewRow();
                    dr["port"] = cboPort.Text;
                    dr["config"] = cboBaudrate.Text.Trim() + "," + cboParity.Text.Trim().Substring(0, 1).ToLower() + "," + cboDatabit.Text.Trim() + "," + cboStopbit.Text.Trim();
                    dsCom.Tables[0].Rows.Add(dr);
                    dsCom.WriteXml(@"..\..\..\xml\m_cauhinh.xml", XmlWriteMode.WriteSchema);
                }
                else
                {
                    dsCom.Tables[0].Rows[0]["port"] = cboPort.Text;
                    dsCom.Tables[0].Rows[0]["config"] = cboBaudrate.Text.Trim() + "," + cboParity.Text.Trim().Substring(0, 1).ToLower() + "," + cboDatabit.Text.Trim() + "," + cboStopbit.Text.Trim();
                    dsCom.AcceptChanges();
                    dsCom.WriteXml(@"..\..\..\xml\m_cauhinh.xml", XmlWriteMode.WriteSchema);
                }
            }
            catch { }
        }

        private void c1007_Click(object sender, EventArgs e)
        {
            c348.Enabled = c349.Enabled = c350.Enabled = c351.Enabled = c352.Enabled = !c1007.Checked;
            c1008.Enabled = c1007.Checked;
        }

        private void p03_Paint(object sender, PaintEventArgs e)
        {

        }

        private void c1028_Click(object sender, EventArgs e)
        {
            //chi chon duoc 1 trong 2: D20 (c1027) - D21 (c1028)
            if (c1027.Checked && c1028.Checked) c1027.Checked = false;
        }

        private void c1027_Click(object sender, EventArgs e)
        {
            //chi chon duoc 1 trong 2: D20 (c1027) - D21 (c1028)
            if (c1027.Checked && c1028.Checked) c1028.Checked = false;
        }

        private void c1032_CheckedChanged(object sender, EventArgs e)
        {
            c1033.Enabled = c1032.Checked;
            if (c1032.Checked == false) c1033.Checked = false;
        }

        private void c434_CheckedChanged(object sender, EventArgs e)
        {
            c1034.Enabled = c434.Checked;
            //c1036.Enabled = c434.Checked;
            c1039.Enabled = c434.Checked;
            if (c434.Checked == false)
            {
                c1034.Checked = false;
                //c1036.Checked = false;
                c1039.Checked = false;
            }
        }

        private void c230_CheckedChanged(object sender, EventArgs e)
        {
            if (c230.Checked) c1049.Checked = false;
        }

        private void c1049_CheckedChanged(object sender, EventArgs e)
        {
            if (c1049.Checked) c230.Checked = false;
        }

        private void c441_Click(object sender, EventArgs e)
        {
            if (c441.Checked) c1054.Checked = false;
        }

        private void c1054_Click(object sender, EventArgs e)
        {
            if (c1054.Checked) c441.Checked = false;
        }

        private void c235_Click(object sender, EventArgs e)
        {
            c1057.Enabled= c235.Checked;
            if (c235.Checked == false) c1057.Checked = false;
        }

        private void c1036_Click(object sender, EventArgs e)
        {
            c1059.Checked = (c1036.Checked) ? false : c1059.Checked;
            c1096.Checked = (c1036.Checked) ? false : c1096.Checked;
        }

        private void c1059_Click(object sender, EventArgs e)
        {
            c1036.Checked = (c1059.Checked) ? false : c1036.Checked;
            c1096.Checked = (c1059.Checked) ? false : c1096.Checked;
        }
        //end linh

        private void tao_thongso_tim()
        {
            sql = "select * from " + user + ".m_thongso_tim where rownum<5";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0) 
            {
                sql = "CREATE TABLE " + user + ".m_thongso_tim(controlname varchar(128), controltext text, loai varchar(128), ngayud timestamp DEFAULT now(), giatri text, CONSTRAINT pk_m_thongso_tim PRIMARY KEY (controlname))";
                m.execute_data(sql);
            }
            sql = "select giatri from " + user + ".m_thongso_tim where rownum<5";
            lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "ALTER TABLE " + user + ".m_thongso_tim add giatri text";
                m.execute_data(sql);
            }

        }

        private void c1056_CheckedChanged(object sender, EventArgs e)
        {
            if (c1056.Checked)
            {
                c1064.Checked = false;
                c1065.Checked = false;
                c1066.Checked = false;
            }
        }

        private void c1064_CheckedChanged(object sender, EventArgs e)
        {
            if (c1064.Checked)
            {
                c1056.Checked = false;
                c1065.Checked = false;
                c1066.Checked = false;
            }
        }

        private void c1065_CheckedChanged(object sender, EventArgs e)
        {
            if (c1065.Checked)
            {
                c1064.Checked = false;
                c1056.Checked = false;
                c1066.Checked = false;
            }
        }

        private void c1066_CheckedChanged(object sender, EventArgs e)
        {
            if (c1066.Checked)
            {
                c1064.Checked = false;
                c1065.Checked = false;
                c1056.Checked = false;
            }
        }

        private void c1070_CheckedChanged(object sender, EventArgs e)
        {
            if (c1070.Checked) c278.Checked = false;
        }

        private void c278_CheckedChanged(object sender, EventArgs e)
        {
            if (c278.Checked) c1070.Checked = false;
        }

        private void c223_CheckedChanged(object sender, EventArgs e)
        {
            if (c223.Checked) c1074.Checked = false;
        }

        private void c1074_CheckedChanged(object sender, EventArgs e)
        {
            if (c1074.Checked) c223.Checked = false;
        }

        private void chktutruc_CheckedChanged(object sender, EventArgs e)
        {
            if (chktutruc.Checked)
            {
                cbotutruc.Enabled = true;
                chkkho.Checked = false;
            }
            else
            {
                cbotutruc.Enabled = false;
            }
        }

        private void chkkho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkho.Checked)
            {
                cbokhotc.Enabled = true;
                chktutruc.Checked = false;
            }
            else
            {
                cbokhotc.Enabled = false;
            }
        }

        private void c195_Click(object sender, EventArgs e)
        {
            if (c1135.Checked)
                c1135.Checked = false;
        }

        private void c1135_Click(object sender, EventArgs e)
        {
            if (c195.Checked)
                c195.Checked = false;
        }

        private void c1100_CheckedChanged(object sender, EventArgs e)
        {
            chkdmNhom.Enabled = c1136.Checked;
        }
        /// <summary>
        /// Hiền thêm 21-06-2011: load nhóm thuốc hướng tâm thần
        /// </summary>
        private void load_huongtamthan()
        {
            try
            {
                chkdmNhom.DataSource = m.get_data("select id,ten from " + m.user + ".d_dmnhom ").Tables[0];
                chkdmNhom.DisplayMember = "ten";
                chkdmNhom.ValueMember = "id";
            }
            catch
            { }
             s_1136 = m.Nhom_thuoc_huong_tam;
             if (s_1136 != "")
             {
                 c1136.Checked = true;
                 string[] s_nhom = s_1136.Split(',');
                 CurrencyManager cm = (CurrencyManager)BindingContext[chkdmNhom.DataSource];
                 DataView dv = (DataView)cm.List;
                 for (int i = 0; i < s_nhom.Length; i++)
                 {
                     for (int j = 0; j < chkdmNhom.Items.Count; j++)
                     {
                         if (dv.Table.Rows[j]["id"].ToString() == s_nhom[i])
                         {
                             chkdmNhom.SetItemChecked(j, true);
                         }
                     }
                 }
             }
            c1100_CheckedChanged(null,null);
        }

        private void butDichvu_Click(object sender, EventArgs e)
        {
            DataTable dtDichvu = new DataTable();
            sql = "select b.id_nhom,c.ten nhom,a.id_loai,b.ten loai,a.id, a.ten from " + m.user + ".v_giavp a, " + m.user + ".v_loaivp b," + m.user + ".v_nhomvp c where a.id_loai=b.id and b.id_nhom=c.ma order by c.ten,b.ten,a.ten";
            dtDichvu = m.get_data(sql).Tables[0];
            frmChonvienphi f = new frmChonvienphi(m, dtDichvu,c1094.Text.Trim());
            f.ShowInTaskbar = false;
            f.ShowDialog();
            c1094.Text = f.s_mavp;
            load_1094(c1094.Text);
        }
        private void load_1094(string _mavp)
        {
            try
            {
                txtVienphi.Text = "";
                DataTable dtDichvu = new DataTable();
                sql = "select ten from " + m.user + ".v_giavp where id in(" + _mavp.Trim(',') + ")";
                dtDichvu = m.get_data(sql).Tables[0];
                for (int i = 0; i < dtDichvu.Rows.Count; i++)
                {
                    txtVienphi.Text += dtDichvu.Rows[i]["ten"].ToString()+", ";
                }
            }
            catch { }
        }

        private void c1093_CheckedChanged(object sender, EventArgs e)
        {
            butDichvu.Enabled = c1093.Checked;
        }

        private void c1096_Click(object sender, EventArgs e)
        {
            c1036.Checked = (c1096.Checked) ? false : c1036.Checked;
            c1059.Checked = (c1096.Checked) ? false : c1059.Checked;
        }

        //Tu:22/07/2011 thêm option Thu phí(khi chọn G16 thì option thu phí sẽ hiện lên, nếu chọn vào thu phí thì đối với bệnh
        //nhân thu phí trong trường hợp phòng lưu xử trí nhập viện chi phí phòng lưu sẽ được tự động chuyển xuống 
        //viện phí để thanh toán)
        private void c150_CheckedChanged(object sender, EventArgs e)
        {
            if (c150.Checked) c1501.Enabled = true;
            else c1501.Enabled = false;
        }

        private void c997_CheckedChanged(object sender, EventArgs e)
        {
            //Tu: 22/08/2011
            txtkituchu.Enabled = c997.Checked;
            txtmatinh.Enabled = c997.Checked;
            
        }

        private void c1102_CheckedChanged(object sender, EventArgs e)
        {
            c1103.Enabled = c1102.Checked;
            if (c1102.Checked == false)
                c1103.Checked = false;
        }

        private void rbcaptheokhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == rbcaptheokhoa && rbcaptheokhoa.Checked) rbcaptheotv.Checked = false;
        }

        private void rbcaptheotv_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == rbcaptheotv && rbcaptheotv.Checked) rbcaptheokhoa.Checked = false;
        }

        private void c446_CheckedChanged(object sender, EventArgs e)
        {
            if (c446.Checked)
            {
                frmCongthucchenhlech f = new frmCongthucchenhlech();
                f.ShowDialog();
            }
        }

        private void p07_Paint(object sender, PaintEventArgs e)
        {

        }
        //Thuy 22.02.2012
        private void c420_CheckedChanged(object sender, EventArgs e)
        {
            if (c420.Checked)
            {
                C1503.Enabled = true;
            }
            else
            {
                C1503.Enabled = false;
            }
        }
        //linh 25092012
        private void chkApDungThongTuLienTich15042012_CheckedChanged(object sender, EventArgs e)
        {
            cboNgayGiaVienPhiThongTuLienTich.Enabled = chkApDungThongTuLienTich15042012.Checked;
            txtNgayBenhNhanThongTuLienTich.Enabled = chkApDungThongTuLienTich15042012.Checked;
            if (cboNgayGiaVienPhiThongTuLienTich.Items.Count == 0 && chkApDungThongTuLienTich15042012.Checked)
            {
                cboNgayGiaVienPhiThongTuLienTich.DisplayMember = "NGAY";
                cboNgayGiaVienPhiThongTuLienTich.ValueMember = "NGAY";
                cboNgayGiaVienPhiThongTuLienTich.DataSource = m.get_data("select distinct to_char(ngay,'dd/mm/yyyy') as ngay from " + user + ".v_giavp_daapgia").Tables[0];
            }
            else if (!chkApDungThongTuLienTich15042012.Checked)
            {
                txtNgayBenhNhanThongTuLienTich.Text = "";
                cboNgayGiaVienPhiThongTuLienTich.SelectedIndex = -1;
                cboNgayGiaVienPhiThongTuLienTich.Text = "";
            }
        }

        private void txtNgayBenhNhanThongTuLienTich_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgayBenhNhanThongTuLienTich.Text.Trim().Trim('/').Trim() != "")
            {
                try
                {
                    m.StringToDate(txtNgayBenhNhanThongTuLienTich.Text);
                }
                catch
                {
                    MessageBox.Show("Ngày không hợp lệ. Vui lòng nhập lại");
                    txtNgayBenhNhanThongTuLienTich.Focus();
                }
            }
        }

        private void c296_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c296)
            {
                if (c296.Checked) c1508.Enabled = false;
                else c1508.Enabled = true;
            }
        }

        private void c1508_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c1508)
            {
                if (c1508.Checked) c296.Enabled = false;
                else c296.Enabled = true;
            }
        }

        private void p06_Paint(object sender, PaintEventArgs e)
        {

        }

        private void c1600_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c1600)
            {
                if (c1600.Checked)
                {
                    if (!c223.Checked && !c1074.Checked)
                    {
                        c223.Checked = true;
                    }
                }
            }
        }

        private void c1023_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void c1513_CheckedChanged(object sender, EventArgs e)
        {

        }
        //end
    }
}
