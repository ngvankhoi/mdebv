using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
//using DuTruKhoTTB;
using Medisoft_ksk;
using tiemchung;

namespace Medisoft
{
	public class frmMain : System.Windows.Forms.Form
    {
        private string __userid = "";
        private string __ngaylv = "";
        private string __ngaysl = "";
        //EMR
        private int i_loai = 0;
        private bool bAdmin = false;
        //EMR
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m=new AccessData();
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.ComponentModel.IContainer components=null;
        private string s_userid = "", s_right = "", s_makp = "", s_madoituong = "", s_nhomkho = "", s_cls = "", s_mabs = "", s_may = "", s_khudt = "";
        
		private int i_userid=0,i_mabv,traituyen=0, i_khudt=0, i_chinhanh=0;
		private bool b_sovaovien,b_soluutru,b_admin;
        private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem56;
		private System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem menuItem58;
		private System.Windows.Forms.MenuItem menuItem59;
		private System.Windows.Forms.MenuItem menuItem60;
		private System.Windows.Forms.MenuItem menuItem71;
		private System.Windows.Forms.MenuItem menuItem72;
		private System.Windows.Forms.MenuItem menuItem73;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem m310;
		private System.Windows.Forms.MenuItem menuItem62;
		private System.Windows.Forms.MenuItem menuItem64;
		private System.Windows.Forms.MenuItem menuItem65;
		private System.Windows.Forms.MenuItem menuItem66;
		private System.Windows.Forms.MenuItem menuItem68;
        private System.Windows.Forms.MenuItem menuItem89;
		private System.Windows.Forms.MenuItem menuItem69;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.MenuItem menuItem98;
		private System.Windows.Forms.MenuItem menuItem90;
		private System.Windows.Forms.MenuItem menuItem91;
		private System.Windows.Forms.MenuItem menuItem92;
		private System.Windows.Forms.MenuItem menuItem94;
		private System.Windows.Forms.MenuItem menuItem93;
		private System.Windows.Forms.MenuItem menuItem76;
		private System.Windows.Forms.MenuItem menuItem95;
		private System.Windows.Forms.MenuItem menuItem96;
		private System.Windows.Forms.MenuItem menuItem63;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem104;
		private System.Windows.Forms.MenuItem menuItem105;
		private System.Windows.Forms.MenuItem menuItem106;
		private System.Windows.Forms.MenuItem menuItem107;
		private System.Windows.Forms.MenuItem menuItem108;
		private System.Windows.Forms.MenuItem menuItem109;
		private System.Windows.Forms.MenuItem menuItem110;
		private System.Windows.Forms.MenuItem menuItem111;
		private System.Windows.Forms.MenuItem menuItem112;
		private System.Windows.Forms.MenuItem menuItem113;
		private System.Windows.Forms.MenuItem menuItem114;
		private System.Windows.Forms.MenuItem menuItem115;
		private System.Windows.Forms.MenuItem menuItem116;
		private System.Windows.Forms.MenuItem menuItem117;
		private System.Windows.Forms.MenuItem menuItem118;
		private System.Windows.Forms.MenuItem menuItem119;
		private System.Windows.Forms.MenuItem menuItem120;
		private System.Windows.Forms.MenuItem menuItem121;
		private System.Windows.Forms.MenuItem menuItem122;
		private System.Windows.Forms.MenuItem menuItem123;
		private System.Windows.Forms.MenuItem menuItem124;
		private System.Windows.Forms.MenuItem menuItem125;
		private System.Windows.Forms.MenuItem menuItem126;
		private System.Windows.Forms.MenuItem menuItem127;
		private System.Windows.Forms.MenuItem menuItem128;
		private System.Windows.Forms.MenuItem menuItem129;
		private System.Windows.Forms.MenuItem menuItem130;
		private System.Windows.Forms.MenuItem menuItem131;
		private System.Windows.Forms.MenuItem menuItem132;
		private System.Windows.Forms.MenuItem menuItem133;
		private System.Windows.Forms.MenuItem menuItem134;
		private System.Windows.Forms.MenuItem menuItem135;
		private System.Windows.Forms.MenuItem menuItem136;
		private System.Windows.Forms.MenuItem menuItem137;
		private System.Windows.Forms.MenuItem menuItem138;
		private System.Windows.Forms.MenuItem menuItem139;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem70;
		private System.Windows.Forms.MenuItem menuItem74;
		private System.Windows.Forms.MenuItem menuItem75;
		private System.Windows.Forms.MenuItem menuItem77;
		private System.Windows.Forms.MenuItem menuItem78;
		private System.Windows.Forms.MenuItem menuItem79;
		private System.Windows.Forms.MenuItem menuItem86;
		private System.Windows.Forms.MenuItem menuItem87;
		private System.Windows.Forms.MenuItem menuItem88;
		private System.Windows.Forms.MenuItem menuItem140;
		private System.Windows.Forms.MenuItem menuItem141;
		private System.Windows.Forms.MenuItem menuItem142;
		private System.Windows.Forms.MenuItem menuItem143;
		private System.Windows.Forms.MenuItem menuItem144;
		private System.Windows.Forms.MenuItem menuItem145;
		private System.Windows.Forms.MenuItem menuItem146;
		private System.Windows.Forms.MenuItem menuItem147;
		private System.Windows.Forms.MenuItem menuItem148;
		private System.Windows.Forms.MenuItem menuItem149;
		private System.Windows.Forms.MenuItem menuItem150;
		private System.Windows.Forms.MenuItem menuItem151;
		private System.Windows.Forms.MenuItem menuItem152;
		private System.Windows.Forms.MenuItem menuItem153;
		private System.Windows.Forms.MenuItem menuItem154;
		private System.Windows.Forms.MenuItem menuItem155;
		private System.Windows.Forms.MenuItem menuItem156;
		private System.Windows.Forms.MenuItem menuItem157;
		private System.Windows.Forms.MenuItem menuItem158;
		private System.Windows.Forms.MenuItem menuItem159;
		private System.Windows.Forms.MenuItem menuItem160;
		private System.Windows.Forms.MenuItem menuItem167;
		private System.Windows.Forms.MenuItem menuItem168;
		private System.Windows.Forms.MenuItem menuItem80;
		private System.Windows.Forms.MenuItem menuItem81;
		private System.Windows.Forms.MenuItem menuItem82;
		private System.Windows.Forms.MenuItem menuItem83;
		private System.Windows.Forms.MenuItem menuItem85;
		private System.Windows.Forms.MenuItem menuItem162;
		private System.Windows.Forms.MenuItem menuItem163;
        private System.Windows.Forms.MenuItem menuItem164;
        private System.Windows.Forms.MenuItem menuItem179;
		private System.Windows.Forms.MenuItem menuItem181;
		private System.Windows.Forms.MenuItem menuItem182;
		private System.Windows.Forms.MenuItem menuItem183;
		private System.Windows.Forms.MenuItem menuItem184;
		private System.Windows.Forms.MenuItem menuItem185;
		private System.Windows.Forms.MenuItem menuItem186;
		private System.Windows.Forms.MenuItem menuItem187;
		private System.Windows.Forms.MenuItem menuItem188;
		private System.Windows.Forms.MenuItem menuItem189;
		private System.Windows.Forms.MenuItem menuItem190;
		private System.Windows.Forms.MenuItem menuItem191;
		private System.Windows.Forms.MenuItem menuItem192;
		private System.Windows.Forms.MenuItem menuItem193;
		private System.Windows.Forms.MenuItem menuItem194;
		private System.Windows.Forms.MenuItem menuItem195;
		private System.Windows.Forms.MenuItem menuItem196;
		private System.Windows.Forms.MenuItem menuItem197;
		private System.Windows.Forms.MenuItem menuItem198;
		private System.Windows.Forms.MenuItem menuItem199;
		private System.Windows.Forms.MenuItem menuItem200;
		private System.Windows.Forms.MenuItem menuItem201;
		private System.Windows.Forms.MenuItem menuItem202;
		private System.Windows.Forms.MenuItem menuItem203;
		private System.Windows.Forms.MenuItem menuItem204;
		private System.Windows.Forms.MenuItem menuItem205;
		private System.Windows.Forms.MenuItem menuItem206;
		private System.Windows.Forms.MenuItem menuItem207;
		private System.Windows.Forms.MenuItem menuItem208;
		private System.Windows.Forms.MenuItem menuItem209;
		private System.Windows.Forms.MenuItem menuItem210;
		private System.Windows.Forms.MenuItem menuItem211;
		private System.Windows.Forms.MenuItem menuItem212;
		private System.Windows.Forms.MenuItem menuItem213;
		private System.Windows.Forms.MenuItem menuItem214;
		private System.Windows.Forms.MenuItem menuItem215;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem84;
		private System.Windows.Forms.MenuItem menuItem97;
		private System.Windows.Forms.MenuItem menuItem99;
		private System.Windows.Forms.MenuItem menuItem100;
		private System.Windows.Forms.MenuItem menuItem101;
		private System.Windows.Forms.MenuItem menuItem102;
		private System.Windows.Forms.MenuItem menuItem103;
		private System.Windows.Forms.MenuItem menuItem161;
		private System.Windows.Forms.MenuItem menuItem166;
		private System.Windows.Forms.MenuItem menuItem169;
		private System.Windows.Forms.MenuItem menuItem170;
		private System.Windows.Forms.MenuItem menuItem172;
		private System.Windows.Forms.MenuItem menuItem173;
		private System.Windows.Forms.MenuItem menuItem175;
		private System.Windows.Forms.MenuItem menuItem176;
		private System.Windows.Forms.MenuItem menuItem177;
		private System.Windows.Forms.MenuItem menuItem178;
		private System.Windows.Forms.MenuItem menuItem216;
		private System.Windows.Forms.MenuItem mnDmxutri;
		private System.Windows.Forms.MenuItem menuItem218;
		private System.Windows.Forms.MenuItem menuItem219;
		private System.Windows.Forms.MenuItem menuItem220;
		private System.Windows.Forms.MenuItem menuItem221;
		private System.Windows.Forms.MenuItem menuItem222;
		private System.Windows.Forms.MenuItem menuItem223;
		private System.Windows.Forms.MenuItem menuItem224;
		private System.Windows.Forms.MenuItem menuItem225;
		private System.Windows.Forms.MenuItem menuItem226;
		private System.Windows.Forms.MenuItem menuItem227;
		private System.Windows.Forms.MenuItem menuItem228;
		private System.Windows.Forms.MenuItem menuItem229;
		private System.Windows.Forms.MenuItem menuItem230;
		private System.Windows.Forms.MenuItem menuItem231;
        private System.Windows.Forms.MenuItem menuItem232;
		private System.Windows.Forms.MenuItem menuItem236;
		private System.Windows.Forms.MenuItem menuItem237;
        private System.Windows.Forms.MenuItem menuItem239;
		private System.Windows.Forms.MenuItem menuItem241;
		private System.Windows.Forms.MenuItem menuItem238;
		private System.Windows.Forms.MenuItem menuItem242;
		private System.Windows.Forms.MenuItem menuItem243;
		private System.Windows.Forms.MenuItem menuItem244;
        private System.Windows.Forms.MenuItem menuItem245;
		private System.Windows.Forms.MenuItem menuItem247;
		private System.Windows.Forms.MenuItem menuItem248;
		private System.Windows.Forms.MenuItem menuItem249;
		private System.Windows.Forms.MenuItem menuItem250;
		private System.Windows.Forms.MenuItem menuItem251;
		private System.Windows.Forms.MenuItem menuItem252;
		private System.Windows.Forms.MenuItem menuItem253;
		private System.Windows.Forms.MenuItem menuItem254;
		private System.Windows.Forms.MenuItem menuItem255;
		private System.Windows.Forms.MenuItem menuItem256;
		private System.Windows.Forms.MenuItem menuItem257;
		private System.Windows.Forms.MenuItem menuItem258;
		private System.Windows.Forms.MenuItem menuItem262;
		private System.Windows.Forms.MenuItem menuItem261;
		private System.Windows.Forms.MenuItem menuItem265;
		private System.Windows.Forms.MenuItem menuItem264;
		private System.Windows.Forms.MenuItem menuItem260;
		private System.Windows.Forms.MenuItem menuItem263;
		private System.Windows.Forms.MenuItem menuItem266;
		private System.Windows.Forms.MenuItem menuItem267;
		private System.Windows.Forms.MenuItem menuItem268;
        private System.Windows.Forms.MenuItem menuItem269;
		private System.Windows.Forms.MenuItem menuItem272;
        private System.Windows.Forms.MenuItem menuItem273;
        private System.Windows.Forms.MenuItem menuItem274;
		private System.Windows.Forms.MenuItem menuItem277;
		private System.Windows.Forms.MenuItem menuItem278;
		private System.Windows.Forms.MenuItem menuItem279;
		private System.Windows.Forms.MenuItem menuItem280;
        private System.Windows.Forms.MenuItem menuItem282;
		private System.Windows.Forms.MenuItem menuItem67;
        private System.Windows.Forms.MenuItem menuItem171;
		private System.Windows.Forms.MenuItem menuItem284;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem285;
        private System.Windows.Forms.MenuItem menuItem286;
        private System.Windows.Forms.MenuItem menuItem289;
		private System.Windows.Forms.MenuItem menuItem300;
		private System.Windows.Forms.MenuItem menuItem301;
		private System.Windows.Forms.MenuItem menuItem302;
		private System.Windows.Forms.MenuItem menuItem303;
		private System.Windows.Forms.MenuItem menuItem304;
		private System.Windows.Forms.MenuItem menuItem305;
		private System.Windows.Forms.MenuItem menuItem233;
        private System.Windows.Forms.MenuItem menuItem281;
		private System.Windows.Forms.MenuItem menuItem306;
		private System.Windows.Forms.MenuItem menuItem307;
		private System.Windows.Forms.MenuItem menuItem308;
		private System.Windows.Forms.MenuItem menuItem309;
		private System.Windows.Forms.MenuItem menuItem310;
		private System.Windows.Forms.MenuItem menuItem311;
		private System.Windows.Forms.MenuItem menuItem312;
		private System.Windows.Forms.MenuItem menuItem313;
        private System.Windows.Forms.MenuItem menuItem314;
		private System.Windows.Forms.MenuItem menuItem337;
		private System.Windows.Forms.MenuItem menuItem338;
		private System.Windows.Forms.MenuItem menuItem259;
		private System.Windows.Forms.MenuItem menuItem339;
        private MenuItem menuItem180;
        private MenuItem menuItem234;
        private MenuItem menuItem235;
        private MenuItem menuItem275;
        private MenuItem menuItem276;
        private MenuItem menuItem340;
        private MenuItem menuItem341;
        private MenuItem menuItem342;
        private MenuItem menuItem165;
        private MenuItem menuItem327;
        private MenuItem menuItem355;
        private MenuItem menuItem356;
        private MenuItem menuItem357;
        private MenuItem menuItem358;
        private MenuItem menuItem359;
        private MenuItem m301;
        private MenuItem menuItem352;
        private MenuItem menuItem365;
        private MenuItem menuItem363;
        private MenuItem menuItem362;
        private MenuItem menuItem361;
        private MenuItem menuItem364;
        private MenuItem m300;
        private MenuItem m303;
        private MenuItem menuItem360;
        private MenuItem m304;
        private MenuItem m305;
        private MenuItem m306;
        private MenuItem menuItem3661;
        private MenuItem m308;
        private MenuItem m307;
        private MenuItem menuItem367;
        private MenuItem m309;
        private MenuItem m311;
        private MenuItem menuItem368;
        private MenuItem m312;
        private MenuItem m313;
        private MenuItem m314;
        private MenuItem i315;
        private MenuItem m317;
        private MenuItem m318;
        private MenuItem m319;
        private MenuItem m320;
        private MenuItem m321;
        private MenuItem m322;
        private MenuItem m323;
        private MenuItem m324;
        private MenuItem m325;
        private MenuItem m326;
        private MenuItem m327;
        private MenuItem m328;
        private MenuItem m329;
        private MenuItem m330;
        private MenuItem m331;
        private MenuItem m333;
        private MenuItem m334;
        private MenuItem m335;
        private MenuItem m336;
        private MenuItem mnuRight_Bv;
        private MenuItem m337;
        private MenuItem m338;
        private MenuItem m339;
        private MenuItem m340;
        private MenuItem m342;
        private MenuItem menuItem30;
        private MenuItem m341;
        private MenuItem m343;
        private MenuItem m344;
        private MenuItem m345;
        private MenuItem m346;
        private MenuItem m347;
        private MenuItem m348;
        private MenuItem m349;
        private MenuItem m350;
        private MenuItem m351;
        private MenuItem m352;
        private MenuItem m353;
        private MenuItem m354;
        private MenuItem menuItem28;
        private MenuItem menuItem61;
        private MenuItem menuItem174;
        private MenuItem menuItem240;
        private MenuItem menuItem246;
        private MenuItem menuItem270;
        private MenuItem menuItem271;
        private MenuItem menuItem283;
        private MenuItem menuItem287;
        private MenuItem menuItem288;
        private MenuItem menuItem290;
        private MenuItem menuItem291;
        private MenuItem menuItem292;
        private MenuItem menuItem293;
        private MenuItem menuItem294;
        private MenuItem menuItem295;
        private MenuItem menuItem296;
        private MenuItem menuItem297;
        private MenuItem menuItem298;
        private MenuItem menuItem299;
        private MenuItem menuItem315;
        private MenuItem menuItem316;
        private MenuItem menuItem317;
        private MenuItem menuItem318;
        private MenuItem menuItem319;
        private MenuItem menuItem320;
        private MenuItem menuItem321;
        private MenuItem menuItem322;
        private MenuItem menuItem323;
        private MenuItem menuItem324;
        private MenuItem menuItem325;
        private MenuItem menuItem326;
        private MenuItem menuItem328;
        private MenuItem menuItem329;
        private MenuItem menuItem330;
        private MenuItem menuItem331;
        private MenuItem menuItem332;
        private MenuItem menuItem333;
        private MenuItem menuItem334;
        private MenuItem menuItem335;
        private MenuItem menuItem336;
        private MenuItem menuItem343;
        private MenuItem menuItem344;
        private MenuItem menuItem345;
        private MenuItem menuItem346;
        private MenuItem menuItem347;
        private MenuItem menuItem348;
        private MenuItem menuItem349;
        private MenuItem menuItem_dmcn;
        private MenuItem menuItem350;
        private MenuItem menuItem351;
        private MenuItem menuItem353;
        private MenuItem menuItem354;
        private MenuItem menuItem366;
        private MenuItem menuItem369;
        private MenuItem menuItem370;
        private MenuItem menuItem371;
        private MenuItem menuItem372;
        private MenuItem menuItem373;
        private MenuItem menuItem374;
        private MenuItem menuItem375;
        private MenuItem menuItem376;
        private MenuItem menuItem377;
        private MenuItem menuItem378;
        private MenuItem menuItem379;
        private MenuItem menuItem380;
        private MenuItem menuItem381;
        private MenuItem menuItem382;
        private MenuItem menuItem217;
        private MenuItem mnuDutrututruc;
        private MenuItem mnuQuanlyVacxin;
        private MenuItem menuItem383;
        private MenuItem mnuTheodoinhietdo;
        private MenuItem menuItem384;
        private MenuItem menuItem385;
        private MenuItem menuItem386;
        private MenuItem menuItem387;
        private MenuItem menuItem388;
        private MenuItem menuItem389;
        private MenuItem menuItem390;
        private MenuItem menuItem391;
        private MenuItem menuItem392;
        private MenuItem menuItem393;
        private MenuItem menuItem394;
        private MenuItem menuItem395;
        private MenuItem menuItem396;
        private MenuItem menuItem397;
        private MenuItem menuItem398;
        private MenuItem menuItem399;
        private MenuItem menuItem400;
        private MenuItem menuItem401;
        private MenuItem menuItem402;
        private MenuItem menuItem403;
        private MenuItem mnuNangchieudaikey;
        private MenuItem mnuChuyensolieu;
        private MenuItem menuItem404;
        private MenuItem menuItem405;
        private MenuItem menuItem406;
        private MenuItem menuItem407;
        private MenuItem menuItem408;
        private MenuItem menuItem409;
        private MenuItem menuItem410;
        private MenuItem menuItem411;
        private MenuItem menuItem412;
        private MenuItem menuItem413;
		private System.Windows.Forms.MenuItem m003;
        public frmMain(string v_userid, string v_ngaylv, string v_ngaysl)
        {
            __userid = v_userid;
            __ngaylv = v_ngaylv;
            __ngaysl = v_ngaysl;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            this.Text = "Medisoft";
            if (m.i_Chinhanh_hientai > 0) this.Text += " - CN: " + m.i_Chinhanh_hientai;//binh 29032012
			lan.Read_MainMenu_to_Xml(this.Name.ToString()+"mainMenu1",this.mainMenu1);
			lan.Change_mainmenu_to_English(this.Name.ToString()+"mainMenu1",this.mainMenu1);
            this.m300.Text = "Báo cáo đặc thù \"" + m.Tenbv.Trim() + "\"";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem163 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem289 = new System.Windows.Forms.MenuItem();
            this.menuItem348 = new System.Windows.Forms.MenuItem();
            this.menuItem380 = new System.Windows.Forms.MenuItem();
            this.menuItem381 = new System.Windows.Forms.MenuItem();
            this.menuItem382 = new System.Windows.Forms.MenuItem();
            this.mnuQuanlyVacxin = new System.Windows.Forms.MenuItem();
            this.menuItem385 = new System.Windows.Forms.MenuItem();
            this.menuItem386 = new System.Windows.Forms.MenuItem();
            this.m003 = new System.Windows.Forms.MenuItem();
            this.menuItem404 = new System.Windows.Forms.MenuItem();
            this.menuItem376 = new System.Windows.Forms.MenuItem();
            this.menuItem377 = new System.Windows.Forms.MenuItem();
            this.menuItem378 = new System.Windows.Forms.MenuItem();
            this.menuItem374 = new System.Windows.Forms.MenuItem();
            this.menuItem217 = new System.Windows.Forms.MenuItem();
            this.mnuDutrututruc = new System.Windows.Forms.MenuItem();
            this.menuItem389 = new System.Windows.Forms.MenuItem();
            this.menuItem383 = new System.Windows.Forms.MenuItem();
            this.mnuTheodoinhietdo = new System.Windows.Forms.MenuItem();
            this.menuItem257 = new System.Windows.Forms.MenuItem();
            this.m343 = new System.Windows.Forms.MenuItem();
            this.menuItem258 = new System.Windows.Forms.MenuItem();
            this.menuItem90 = new System.Windows.Forms.MenuItem();
            this.m303 = new System.Windows.Forms.MenuItem();
            this.menuItem94 = new System.Windows.Forms.MenuItem();
            this.m308 = new System.Windows.Forms.MenuItem();
            this.menuItem384 = new System.Windows.Forms.MenuItem();
            this.menuItem99 = new System.Windows.Forms.MenuItem();
            this.menuItem259 = new System.Windows.Forms.MenuItem();
            this.menuItem236 = new System.Windows.Forms.MenuItem();
            this.menuItem237 = new System.Windows.Forms.MenuItem();
            this.menuItem272 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.m354 = new System.Windows.Forms.MenuItem();
            this.m301 = new System.Windows.Forms.MenuItem();
            this.menuItem286 = new System.Windows.Forms.MenuItem();
            this.menuItem180 = new System.Windows.Forms.MenuItem();
            this.menuItem234 = new System.Windows.Forms.MenuItem();
            this.menuItem235 = new System.Windows.Forms.MenuItem();
            this.menuItem275 = new System.Windows.Forms.MenuItem();
            this.menuItem276 = new System.Windows.Forms.MenuItem();
            this.menuItem340 = new System.Windows.Forms.MenuItem();
            this.menuItem341 = new System.Windows.Forms.MenuItem();
            this.menuItem240 = new System.Windows.Forms.MenuItem();
            this.menuItem379 = new System.Windows.Forms.MenuItem();
            this.menuItem408 = new System.Windows.Forms.MenuItem();
            this.menuItem409 = new System.Windows.Forms.MenuItem();
            this.menuItem411 = new System.Windows.Forms.MenuItem();
            this.menuItem412 = new System.Windows.Forms.MenuItem();
            this.menuItem73 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem91 = new System.Windows.Forms.MenuItem();
            this.m351 = new System.Windows.Forms.MenuItem();
            this.m348 = new System.Windows.Forms.MenuItem();
            this.menuItem261 = new System.Windows.Forms.MenuItem();
            this.m338 = new System.Windows.Forms.MenuItem();
            this.menuItem260 = new System.Windows.Forms.MenuItem();
            this.menuItem342 = new System.Windows.Forms.MenuItem();
            this.m349 = new System.Windows.Forms.MenuItem();
            this.menuItem262 = new System.Windows.Forms.MenuItem();
            this.menuItem92 = new System.Windows.Forms.MenuItem();
            this.menuItem76 = new System.Windows.Forms.MenuItem();
            this.menuItem93 = new System.Windows.Forms.MenuItem();
            this.menuItem251 = new System.Windows.Forms.MenuItem();
            this.menuItem254 = new System.Windows.Forms.MenuItem();
            this.menuItem255 = new System.Windows.Forms.MenuItem();
            this.menuItem337 = new System.Windows.Forms.MenuItem();
            this.menuItem227 = new System.Windows.Forms.MenuItem();
            this.menuItem228 = new System.Windows.Forms.MenuItem();
            this.menuItem265 = new System.Windows.Forms.MenuItem();
            this.m352 = new System.Windows.Forms.MenuItem();
            this.menuItem264 = new System.Windows.Forms.MenuItem();
            this.m341 = new System.Windows.Forms.MenuItem();
            this.menuItem263 = new System.Windows.Forms.MenuItem();
            this.m337 = new System.Windows.Forms.MenuItem();
            this.menuItem229 = new System.Windows.Forms.MenuItem();
            this.menuItem231 = new System.Windows.Forms.MenuItem();
            this.menuItem232 = new System.Windows.Forms.MenuItem();
            this.menuItem230 = new System.Windows.Forms.MenuItem();
            this.menuItem252 = new System.Windows.Forms.MenuItem();
            this.m331 = new System.Windows.Forms.MenuItem();
            this.menuItem403 = new System.Windows.Forms.MenuItem();
            this.menuItem407 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem247 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItem239 = new System.Windows.Forms.MenuItem();
            this.m321 = new System.Windows.Forms.MenuItem();
            this.m320 = new System.Windows.Forms.MenuItem();
            this.menuItem241 = new System.Windows.Forms.MenuItem();
            this.menuItem245 = new System.Windows.Forms.MenuItem();
            this.menuItem285 = new System.Windows.Forms.MenuItem();
            this.menuItem248 = new System.Windows.Forms.MenuItem();
            this.m342 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem365 = new System.Windows.Forms.MenuItem();
            this.menuItem345 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem103 = new System.Windows.Forms.MenuItem();
            this.menuItem161 = new System.Windows.Forms.MenuItem();
            this.menuItem166 = new System.Windows.Forms.MenuItem();
            this.menuItem169 = new System.Windows.Forms.MenuItem();
            this.menuItem306 = new System.Windows.Forms.MenuItem();
            this.menuItem170 = new System.Windows.Forms.MenuItem();
            this.menuItem172 = new System.Windows.Forms.MenuItem();
            this.menuItem388 = new System.Windows.Forms.MenuItem();
            this.menuItem173 = new System.Windows.Forms.MenuItem();
            this.m322 = new System.Windows.Forms.MenuItem();
            this.m323 = new System.Windows.Forms.MenuItem();
            this.m324 = new System.Windows.Forms.MenuItem();
            this.m350 = new System.Windows.Forms.MenuItem();
            this.menuItem175 = new System.Windows.Forms.MenuItem();
            this.menuItem176 = new System.Windows.Forms.MenuItem();
            this.menuItem177 = new System.Windows.Forms.MenuItem();
            this.menuItem355 = new System.Windows.Forms.MenuItem();
            this.menuItem356 = new System.Windows.Forms.MenuItem();
            this.menuItem357 = new System.Windows.Forms.MenuItem();
            this.menuItem358 = new System.Windows.Forms.MenuItem();
            this.menuItem359 = new System.Windows.Forms.MenuItem();
            this.menuItem178 = new System.Windows.Forms.MenuItem();
            this.menuItem216 = new System.Windows.Forms.MenuItem();
            this.menuItem218 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem223 = new System.Windows.Forms.MenuItem();
            this.menuItem224 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem360 = new System.Windows.Forms.MenuItem();
            this.m304 = new System.Windows.Forms.MenuItem();
            this.menuItem221 = new System.Windows.Forms.MenuItem();
            this.menuItem3661 = new System.Windows.Forms.MenuItem();
            this.m307 = new System.Windows.Forms.MenuItem();
            this.m309 = new System.Windows.Forms.MenuItem();
            this.m311 = new System.Windows.Forms.MenuItem();
            this.menuItem367 = new System.Windows.Forms.MenuItem();
            this.menuItem273 = new System.Windows.Forms.MenuItem();
            this.menuItem222 = new System.Windows.Forms.MenuItem();
            this.m353 = new System.Windows.Forms.MenuItem();
            this.menuItem274 = new System.Windows.Forms.MenuItem();
            this.menuItem225 = new System.Windows.Forms.MenuItem();
            this.menuItem308 = new System.Windows.Forms.MenuItem();
            this.menuItem226 = new System.Windows.Forms.MenuItem();
            this.menuItem307 = new System.Windows.Forms.MenuItem();
            this.m345 = new System.Windows.Forms.MenuItem();
            this.m317 = new System.Windows.Forms.MenuItem();
            this.menuItem238 = new System.Windows.Forms.MenuItem();
            this.m344 = new System.Windows.Forms.MenuItem();
            this.menuItem280 = new System.Windows.Forms.MenuItem();
            this.menuItem279 = new System.Windows.Forms.MenuItem();
            this.menuItem300 = new System.Windows.Forms.MenuItem();
            this.menuItem233 = new System.Windows.Forms.MenuItem();
            this.menuItem310 = new System.Windows.Forms.MenuItem();
            this.menuItem311 = new System.Windows.Forms.MenuItem();
            this.menuItem313 = new System.Windows.Forms.MenuItem();
            this.menuItem314 = new System.Windows.Forms.MenuItem();
            this.menuItem304 = new System.Windows.Forms.MenuItem();
            this.menuItem302 = new System.Windows.Forms.MenuItem();
            this.menuItem301 = new System.Windows.Forms.MenuItem();
            this.menuItem303 = new System.Windows.Forms.MenuItem();
            this.menuItem305 = new System.Windows.Forms.MenuItem();
            this.menuItem281 = new System.Windows.Forms.MenuItem();
            this.menuItem309 = new System.Windows.Forms.MenuItem();
            this.menuItem406 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem104 = new System.Windows.Forms.MenuItem();
            this.menuItem108 = new System.Windows.Forms.MenuItem();
            this.menuItem109 = new System.Windows.Forms.MenuItem();
            this.menuItem110 = new System.Windows.Forms.MenuItem();
            this.menuItem111 = new System.Windows.Forms.MenuItem();
            this.menuItem112 = new System.Windows.Forms.MenuItem();
            this.menuItem113 = new System.Windows.Forms.MenuItem();
            this.menuItem114 = new System.Windows.Forms.MenuItem();
            this.menuItem115 = new System.Windows.Forms.MenuItem();
            this.menuItem116 = new System.Windows.Forms.MenuItem();
            this.menuItem117 = new System.Windows.Forms.MenuItem();
            this.menuItem118 = new System.Windows.Forms.MenuItem();
            this.menuItem119 = new System.Windows.Forms.MenuItem();
            this.menuItem120 = new System.Windows.Forms.MenuItem();
            this.menuItem121 = new System.Windows.Forms.MenuItem();
            this.menuItem122 = new System.Windows.Forms.MenuItem();
            this.menuItem346 = new System.Windows.Forms.MenuItem();
            this.menuItem105 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem80 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem74 = new System.Windows.Forms.MenuItem();
            this.menuItem75 = new System.Windows.Forms.MenuItem();
            this.menuItem77 = new System.Windows.Forms.MenuItem();
            this.menuItem78 = new System.Windows.Forms.MenuItem();
            this.menuItem79 = new System.Windows.Forms.MenuItem();
            this.menuItem246 = new System.Windows.Forms.MenuItem();
            this.menuItem271 = new System.Windows.Forms.MenuItem();
            this.menuItem283 = new System.Windows.Forms.MenuItem();
            this.menuItem287 = new System.Windows.Forms.MenuItem();
            this.menuItem288 = new System.Windows.Forms.MenuItem();
            this.menuItem290 = new System.Windows.Forms.MenuItem();
            this.menuItem291 = new System.Windows.Forms.MenuItem();
            this.menuItem292 = new System.Windows.Forms.MenuItem();
            this.menuItem293 = new System.Windows.Forms.MenuItem();
            this.menuItem294 = new System.Windows.Forms.MenuItem();
            this.menuItem295 = new System.Windows.Forms.MenuItem();
            this.menuItem296 = new System.Windows.Forms.MenuItem();
            this.menuItem297 = new System.Windows.Forms.MenuItem();
            this.menuItem298 = new System.Windows.Forms.MenuItem();
            this.menuItem299 = new System.Windows.Forms.MenuItem();
            this.menuItem315 = new System.Windows.Forms.MenuItem();
            this.menuItem316 = new System.Windows.Forms.MenuItem();
            this.menuItem317 = new System.Windows.Forms.MenuItem();
            this.menuItem336 = new System.Windows.Forms.MenuItem();
            this.menuItem390 = new System.Windows.Forms.MenuItem();
            this.menuItem392 = new System.Windows.Forms.MenuItem();
            this.menuItem393 = new System.Windows.Forms.MenuItem();
            this.menuItem344 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem106 = new System.Windows.Forms.MenuItem();
            this.menuItem123 = new System.Windows.Forms.MenuItem();
            this.menuItem124 = new System.Windows.Forms.MenuItem();
            this.menuItem125 = new System.Windows.Forms.MenuItem();
            this.menuItem126 = new System.Windows.Forms.MenuItem();
            this.menuItem127 = new System.Windows.Forms.MenuItem();
            this.menuItem128 = new System.Windows.Forms.MenuItem();
            this.menuItem129 = new System.Windows.Forms.MenuItem();
            this.menuItem130 = new System.Windows.Forms.MenuItem();
            this.menuItem131 = new System.Windows.Forms.MenuItem();
            this.menuItem132 = new System.Windows.Forms.MenuItem();
            this.menuItem133 = new System.Windows.Forms.MenuItem();
            this.menuItem134 = new System.Windows.Forms.MenuItem();
            this.menuItem135 = new System.Windows.Forms.MenuItem();
            this.menuItem136 = new System.Windows.Forms.MenuItem();
            this.menuItem137 = new System.Windows.Forms.MenuItem();
            this.menuItem347 = new System.Windows.Forms.MenuItem();
            this.menuItem138 = new System.Windows.Forms.MenuItem();
            this.menuItem139 = new System.Windows.Forms.MenuItem();
            this.menuItem107 = new System.Windows.Forms.MenuItem();
            this.menuItem86 = new System.Windows.Forms.MenuItem();
            this.menuItem87 = new System.Windows.Forms.MenuItem();
            this.menuItem88 = new System.Windows.Forms.MenuItem();
            this.menuItem140 = new System.Windows.Forms.MenuItem();
            this.menuItem141 = new System.Windows.Forms.MenuItem();
            this.menuItem142 = new System.Windows.Forms.MenuItem();
            this.menuItem143 = new System.Windows.Forms.MenuItem();
            this.menuItem144 = new System.Windows.Forms.MenuItem();
            this.menuItem145 = new System.Windows.Forms.MenuItem();
            this.menuItem146 = new System.Windows.Forms.MenuItem();
            this.menuItem147 = new System.Windows.Forms.MenuItem();
            this.menuItem148 = new System.Windows.Forms.MenuItem();
            this.menuItem149 = new System.Windows.Forms.MenuItem();
            this.menuItem150 = new System.Windows.Forms.MenuItem();
            this.menuItem81 = new System.Windows.Forms.MenuItem();
            this.menuItem151 = new System.Windows.Forms.MenuItem();
            this.menuItem152 = new System.Windows.Forms.MenuItem();
            this.menuItem153 = new System.Windows.Forms.MenuItem();
            this.menuItem154 = new System.Windows.Forms.MenuItem();
            this.menuItem155 = new System.Windows.Forms.MenuItem();
            this.menuItem156 = new System.Windows.Forms.MenuItem();
            this.menuItem157 = new System.Windows.Forms.MenuItem();
            this.menuItem158 = new System.Windows.Forms.MenuItem();
            this.menuItem159 = new System.Windows.Forms.MenuItem();
            this.menuItem160 = new System.Windows.Forms.MenuItem();
            this.menuItem167 = new System.Windows.Forms.MenuItem();
            this.menuItem270 = new System.Windows.Forms.MenuItem();
            this.menuItem318 = new System.Windows.Forms.MenuItem();
            this.menuItem319 = new System.Windows.Forms.MenuItem();
            this.menuItem320 = new System.Windows.Forms.MenuItem();
            this.menuItem321 = new System.Windows.Forms.MenuItem();
            this.menuItem322 = new System.Windows.Forms.MenuItem();
            this.menuItem323 = new System.Windows.Forms.MenuItem();
            this.menuItem324 = new System.Windows.Forms.MenuItem();
            this.menuItem325 = new System.Windows.Forms.MenuItem();
            this.menuItem326 = new System.Windows.Forms.MenuItem();
            this.menuItem328 = new System.Windows.Forms.MenuItem();
            this.menuItem329 = new System.Windows.Forms.MenuItem();
            this.menuItem330 = new System.Windows.Forms.MenuItem();
            this.menuItem331 = new System.Windows.Forms.MenuItem();
            this.menuItem332 = new System.Windows.Forms.MenuItem();
            this.menuItem333 = new System.Windows.Forms.MenuItem();
            this.menuItem334 = new System.Windows.Forms.MenuItem();
            this.menuItem335 = new System.Windows.Forms.MenuItem();
            this.menuItem343 = new System.Windows.Forms.MenuItem();
            this.menuItem391 = new System.Windows.Forms.MenuItem();
            this.menuItem394 = new System.Windows.Forms.MenuItem();
            this.menuItem395 = new System.Windows.Forms.MenuItem();
            this.menuItem396 = new System.Windows.Forms.MenuItem();
            this.menuItem181 = new System.Windows.Forms.MenuItem();
            this.menuItem191 = new System.Windows.Forms.MenuItem();
            this.menuItem192 = new System.Windows.Forms.MenuItem();
            this.menuItem193 = new System.Windows.Forms.MenuItem();
            this.menuItem194 = new System.Windows.Forms.MenuItem();
            this.menuItem195 = new System.Windows.Forms.MenuItem();
            this.menuItem196 = new System.Windows.Forms.MenuItem();
            this.menuItem97 = new System.Windows.Forms.MenuItem();
            this.menuItem199 = new System.Windows.Forms.MenuItem();
            this.menuItem197 = new System.Windows.Forms.MenuItem();
            this.menuItem198 = new System.Windows.Forms.MenuItem();
            this.menuItem200 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem250 = new System.Windows.Forms.MenuItem();
            this.menuItem256 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.m329 = new System.Windows.Forms.MenuItem();
            this.m330 = new System.Windows.Forms.MenuItem();
            this.menuItem349 = new System.Windows.Forms.MenuItem();
            this.menuItem182 = new System.Windows.Forms.MenuItem();
            this.menuItem201 = new System.Windows.Forms.MenuItem();
            this.menuItem202 = new System.Windows.Forms.MenuItem();
            this.menuItem183 = new System.Windows.Forms.MenuItem();
            this.menuItem203 = new System.Windows.Forms.MenuItem();
            this.menuItem204 = new System.Windows.Forms.MenuItem();
            this.m305 = new System.Windows.Forms.MenuItem();
            this.menuItem184 = new System.Windows.Forms.MenuItem();
            this.menuItem205 = new System.Windows.Forms.MenuItem();
            this.menuItem206 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem84 = new System.Windows.Forms.MenuItem();
            this.menuItem185 = new System.Windows.Forms.MenuItem();
            this.menuItem207 = new System.Windows.Forms.MenuItem();
            this.menuItem208 = new System.Windows.Forms.MenuItem();
            this.menuItem186 = new System.Windows.Forms.MenuItem();
            this.menuItem209 = new System.Windows.Forms.MenuItem();
            this.menuItem210 = new System.Windows.Forms.MenuItem();
            this.menuItem187 = new System.Windows.Forms.MenuItem();
            this.menuItem188 = new System.Windows.Forms.MenuItem();
            this.menuItem215 = new System.Windows.Forms.MenuItem();
            this.menuItem189 = new System.Windows.Forms.MenuItem();
            this.menuItem190 = new System.Windows.Forms.MenuItem();
            this.menuItem211 = new System.Windows.Forms.MenuItem();
            this.menuItem212 = new System.Windows.Forms.MenuItem();
            this.m339 = new System.Windows.Forms.MenuItem();
            this.menuItem213 = new System.Windows.Forms.MenuItem();
            this.menuItem214 = new System.Windows.Forms.MenuItem();
            this.menuItem244 = new System.Windows.Forms.MenuItem();
            this.menuItem249 = new System.Windows.Forms.MenuItem();
            this.menuItem269 = new System.Windows.Forms.MenuItem();
            this.menuItem278 = new System.Windows.Forms.MenuItem();
            this.m327 = new System.Windows.Forms.MenuItem();
            this.m300 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem397 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.m310 = new System.Windows.Forms.MenuItem();
            this.menuItem164 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem102 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem82 = new System.Windows.Forms.MenuItem();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem89 = new System.Windows.Forms.MenuItem();
            this.menuItem98 = new System.Windows.Forms.MenuItem();
            this.mnDmxutri = new System.Windows.Forms.MenuItem();
            this.menuItem243 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem168 = new System.Windows.Forms.MenuItem();
            this.menuItem219 = new System.Windows.Forms.MenuItem();
            this.menuItem220 = new System.Windows.Forms.MenuItem();
            this.menuItem242 = new System.Windows.Forms.MenuItem();
            this.menuItem266 = new System.Windows.Forms.MenuItem();
            this.menuItem171 = new System.Windows.Forms.MenuItem();
            this.menuItem284 = new System.Windows.Forms.MenuItem();
            this.menuItem339 = new System.Windows.Forms.MenuItem();
            this.menuItem350 = new System.Windows.Forms.MenuItem();
            this.menuItem351 = new System.Windows.Forms.MenuItem();
            this.menuItem353 = new System.Windows.Forms.MenuItem();
            this.menuItem398 = new System.Windows.Forms.MenuItem();
            this.menuItem399 = new System.Windows.Forms.MenuItem();
            this.menuItem400 = new System.Windows.Forms.MenuItem();
            this.menuItem401 = new System.Windows.Forms.MenuItem();
            this.menuItem402 = new System.Windows.Forms.MenuItem();
            this.menuItem410 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem95 = new System.Windows.Forms.MenuItem();
            this.menuItem96 = new System.Windows.Forms.MenuItem();
            this.m325 = new System.Windows.Forms.MenuItem();
            this.m340 = new System.Windows.Forms.MenuItem();
            this.m328 = new System.Windows.Forms.MenuItem();
            this.menuItem_dmcn = new System.Windows.Forms.MenuItem();
            this.m335 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.i315 = new System.Windows.Forms.MenuItem();
            this.mnuRight_Bv = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.m334 = new System.Windows.Forms.MenuItem();
            this.menuItem83 = new System.Windows.Forms.MenuItem();
            this.menuItem267 = new System.Windows.Forms.MenuItem();
            this.menuItem268 = new System.Windows.Forms.MenuItem();
            this.menuItem85 = new System.Windows.Forms.MenuItem();
            this.menuItem282 = new System.Windows.Forms.MenuItem();
            this.menuItem312 = new System.Windows.Forms.MenuItem();
            this.menuItem162 = new System.Windows.Forms.MenuItem();
            this.m336 = new System.Windows.Forms.MenuItem();
            this.menuItem179 = new System.Windows.Forms.MenuItem();
            this.menuItem338 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem413 = new System.Windows.Forms.MenuItem();
            this.menuItem327 = new System.Windows.Forms.MenuItem();
            this.menuItem405 = new System.Windows.Forms.MenuItem();
            this.menuItem165 = new System.Windows.Forms.MenuItem();
            this.m306 = new System.Windows.Forms.MenuItem();
            this.menuItem352 = new System.Windows.Forms.MenuItem();
            this.menuItem363 = new System.Windows.Forms.MenuItem();
            this.menuItem362 = new System.Windows.Forms.MenuItem();
            this.menuItem361 = new System.Windows.Forms.MenuItem();
            this.menuItem364 = new System.Windows.Forms.MenuItem();
            this.menuItem63 = new System.Windows.Forms.MenuItem();
            this.menuItem100 = new System.Windows.Forms.MenuItem();
            this.menuItem101 = new System.Windows.Forms.MenuItem();
            this.menuItem253 = new System.Windows.Forms.MenuItem();
            this.menuItem277 = new System.Windows.Forms.MenuItem();
            this.menuItem368 = new System.Windows.Forms.MenuItem();
            this.m312 = new System.Windows.Forms.MenuItem();
            this.m313 = new System.Windows.Forms.MenuItem();
            this.m314 = new System.Windows.Forms.MenuItem();
            this.m318 = new System.Windows.Forms.MenuItem();
            this.m319 = new System.Windows.Forms.MenuItem();
            this.m326 = new System.Windows.Forms.MenuItem();
            this.m333 = new System.Windows.Forms.MenuItem();
            this.m346 = new System.Windows.Forms.MenuItem();
            this.m347 = new System.Windows.Forms.MenuItem();
            this.menuItem354 = new System.Windows.Forms.MenuItem();
            this.menuItem371 = new System.Windows.Forms.MenuItem();
            this.menuItem387 = new System.Windows.Forms.MenuItem();
            this.menuItem372 = new System.Windows.Forms.MenuItem();
            this.menuItem373 = new System.Windows.Forms.MenuItem();
            this.menuItem375 = new System.Windows.Forms.MenuItem();
            this.menuItem174 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem366 = new System.Windows.Forms.MenuItem();
            this.menuItem369 = new System.Windows.Forms.MenuItem();
            this.menuItem370 = new System.Windows.Forms.MenuItem();
            this.mnuNangchieudaikey = new System.Windows.Forms.MenuItem();
            this.mnuChuyensolieu = new System.Windows.Forms.MenuItem();
            this.menuItem59 = new System.Windows.Forms.MenuItem();
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem58 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem73,
            this.menuItem227,
            this.menuItem72,
            this.menuItem71,
            this.menuItem3,
            this.menuItem4,
            this.menuItem55,
            this.menuItem36,
            this.mnuExit});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem163,
            this.menuItem24,
            this.menuItem289,
            this.menuItem348,
            this.m003,
            this.menuItem404,
            this.menuItem376,
            this.menuItem374,
            this.menuItem217,
            this.mnuDutrututruc,
            this.menuItem389,
            this.menuItem383,
            this.mnuTheodoinhietdo,
            this.menuItem257,
            this.m343,
            this.menuItem258,
            this.menuItem90,
            this.m303,
            this.menuItem94,
            this.m308,
            this.menuItem384,
            this.menuItem99,
            this.menuItem259,
            this.menuItem236,
            this.menuItem237,
            this.menuItem272,
            this.menuItem52,
            this.m354,
            this.m301,
            this.menuItem286,
            this.menuItem180,
            this.menuItem234,
            this.menuItem240,
            this.menuItem379,
            this.menuItem408,
            this.menuItem409,
            this.menuItem411,
            this.menuItem412});
            this.menuItem1.MergeOrder = 900;
            this.menuItem1.Text = "&Khám bệnh";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem163
            // 
            this.menuItem163.Index = 0;
            this.menuItem163.Tag = "000";
            this.menuItem163.Text = "Đăng ký khám bệnh";
            this.menuItem163.Click += new System.EventHandler(this.menuItem163_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 1;
            this.menuItem24.MergeOrder = 1;
            this.menuItem24.Tag = "001";
            this.menuItem24.Text = "Phiếu khám bệnh";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem289
            // 
            this.menuItem289.Index = 2;
            this.menuItem289.MergeOrder = 2;
            this.menuItem289.Tag = "003";
            this.menuItem289.Text = "Phiếu khám bệnh (Mẫu 2)";
            this.menuItem289.Click += new System.EventHandler(this.menuItem289_Click);
            // 
            // menuItem348
            // 
            this.menuItem348.Index = 3;
            this.menuItem348.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem380,
            this.menuItem381,
            this.menuItem382,
            this.mnuQuanlyVacxin,
            this.menuItem385,
            this.menuItem386});
            this.menuItem348.MergeOrder = 10400;
            this.menuItem348.Text = "Tiêm chủng";
            this.menuItem348.Click += new System.EventHandler(this.menuItem348_Click_1);
            // 
            // menuItem380
            // 
            this.menuItem380.Index = 0;
            this.menuItem380.MergeOrder = 10401;
            this.menuItem380.Text = "Câu hỏi sàng lọc tiêm chủng người lớn";
            this.menuItem380.Click += new System.EventHandler(this.menuItem380_Click);
            // 
            // menuItem381
            // 
            this.menuItem381.Index = 1;
            this.menuItem381.MergeOrder = 10402;
            this.menuItem381.Text = "Phiếu tiêm chủng";
            this.menuItem381.Click += new System.EventHandler(this.menuItem381_Click);
            // 
            // menuItem382
            // 
            this.menuItem382.Index = 2;
            this.menuItem382.MergeOrder = 10403;
            this.menuItem382.Text = "Thống kê người tiêm chủng";
            this.menuItem382.Click += new System.EventHandler(this.menuItem382_Click);
            // 
            // mnuQuanlyVacxin
            // 
            this.mnuQuanlyVacxin.Index = 3;
            this.mnuQuanlyVacxin.MergeOrder = 10404;
            this.mnuQuanlyVacxin.Text = "Sổ quản lý vacxin";
            this.mnuQuanlyVacxin.Click += new System.EventHandler(this.mnuQuanlyVacxin_Click);
            // 
            // menuItem385
            // 
            this.menuItem385.Index = 4;
            this.menuItem385.MergeOrder = 10405;
            this.menuItem385.Text = "Sổ quản lý tiêm vacxin";
            this.menuItem385.Click += new System.EventHandler(this.menuItem385_Click);
            // 
            // menuItem386
            // 
            this.menuItem386.Index = 5;
            this.menuItem386.MergeOrder = 10406;
            this.menuItem386.Text = "Biên bản hủy vỏ lọ vacxin";
            this.menuItem386.Click += new System.EventHandler(this.menuItem386_Click);
            // 
            // m003
            // 
            this.m003.Index = 4;
            this.m003.MergeOrder = 3;
            this.m003.Tag = "004";
            this.m003.Text = "Chuyển phòng khám";
            this.m003.Click += new System.EventHandler(this.menuItem333_Click);
            // 
            // menuItem404
            // 
            this.menuItem404.Index = 5;
            this.menuItem404.Text = "Chuyển phòng khám qua chi nhánh khác";
            this.menuItem404.Click += new System.EventHandler(this.menuItem404_Click);
            // 
            // menuItem376
            // 
            this.menuItem376.Index = 6;
            this.menuItem376.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem377,
            this.menuItem378});
            this.menuItem376.MergeOrder = 10600;
            this.menuItem376.Text = "Khám sức khỏe tổng quát";
            // 
            // menuItem377
            // 
            this.menuItem377.Index = 0;
            this.menuItem377.MergeOrder = 10601;
            this.menuItem377.Text = "Tiếp nhận Bệnh nhân Khám sức khỏe";
            // 
            // menuItem378
            // 
            this.menuItem378.Index = 1;
            this.menuItem378.MergeOrder = 10602;
            this.menuItem378.Text = "Khám sức khỏe tồng quát";
            this.menuItem378.Click += new System.EventHandler(this.menuItem378_Click);
            // 
            // menuItem374
            // 
            this.menuItem374.Index = 7;
            this.menuItem374.MergeOrder = 15800;
            this.menuItem374.Text = "In giấy chuyển viện";
            this.menuItem374.Click += new System.EventHandler(this.menuItem374_Click);
            // 
            // menuItem217
            // 
            this.menuItem217.Index = 8;
            this.menuItem217.Text = "-";
            // 
            // mnuDutrututruc
            // 
            this.mnuDutrututruc.Index = 9;
            this.mnuDutrututruc.MergeOrder = 12201;
            this.mnuDutrututruc.Text = "Dự trù tủ trực cho khoa phòng";
            this.mnuDutrututruc.Click += new System.EventHandler(this.mnuDutrututruc_Click);
            // 
            // menuItem389
            // 
            this.menuItem389.Index = 10;
            this.menuItem389.MergeOrder = 10409;
            this.menuItem389.Text = "Dự trù lĩnh hao phí theo khoa/phòng";
            this.menuItem389.Click += new System.EventHandler(this.menuItem389_Click);
            // 
            // menuItem383
            // 
            this.menuItem383.Index = 11;
            this.menuItem383.Text = "-";
            // 
            // mnuTheodoinhietdo
            // 
            this.mnuTheodoinhietdo.Index = 12;
            this.mnuTheodoinhietdo.MergeOrder = 10405;
            this.mnuTheodoinhietdo.Text = "Theo dõi nhiệt độ tủ lạnh";
            this.mnuTheodoinhietdo.Click += new System.EventHandler(this.menuItem384_Click);
            // 
            // menuItem257
            // 
            this.menuItem257.Index = 13;
            this.menuItem257.Text = "-";
            // 
            // m343
            // 
            this.m343.Index = 14;
            this.m343.MergeOrder = 343;
            this.m343.Text = "Sửa đối tượng các dịch vụ";
            this.m343.Click += new System.EventHandler(this.m343_Click);
            // 
            // menuItem258
            // 
            this.menuItem258.Index = 15;
            this.menuItem258.MergeOrder = 4;
            this.menuItem258.Text = "Phiếu thanh toán dịch vụ";
            this.menuItem258.Click += new System.EventHandler(this.menuItem258_Click);
            // 
            // menuItem90
            // 
            this.menuItem90.Index = 16;
            this.menuItem90.Text = "-";
            // 
            // m303
            // 
            this.m303.Index = 17;
            this.m303.MergeOrder = 303;
            this.m303.Text = "Tìm kiếm thông tin người bệnh";
            this.m303.Click += new System.EventHandler(this.m303_Click);
            // 
            // menuItem94
            // 
            this.menuItem94.Index = 18;
            this.menuItem94.MergeOrder = 5;
            this.menuItem94.Text = "Danh sách đăng ký khám bệnh";
            this.menuItem94.Visible = false;
            this.menuItem94.Click += new System.EventHandler(this.menuItem94_Click_1);
            // 
            // m308
            // 
            this.m308.Index = 19;
            this.m308.MergeOrder = 308;
            this.m308.Text = "Thông tin đăng ký khám bệnh";
            this.m308.Click += new System.EventHandler(this.m308_Click);
            // 
            // menuItem384
            // 
            this.menuItem384.Index = 20;
            this.menuItem384.MergeOrder = 11500;
            this.menuItem384.Text = "Thông tin đăng ký khám bệnh xuất LCD";
            this.menuItem384.Click += new System.EventHandler(this.menuItem384_Click_1);
            // 
            // menuItem99
            // 
            this.menuItem99.Index = 21;
            this.menuItem99.MergeOrder = 6;
            this.menuItem99.Text = "Danh sách khám bệnh";
            this.menuItem99.Click += new System.EventHandler(this.menuItem99_Click_1);
            // 
            // menuItem259
            // 
            this.menuItem259.Index = 22;
            this.menuItem259.MergeOrder = 7;
            this.menuItem259.Text = "Sổ khám bệnh";
            this.menuItem259.Click += new System.EventHandler(this.menuItem259_Click_1);
            // 
            // menuItem236
            // 
            this.menuItem236.Index = 23;
            this.menuItem236.MergeOrder = 8;
            this.menuItem236.Text = "Báo cáo phòng tiếp bệnh";
            this.menuItem236.Click += new System.EventHandler(this.menuItem236_Click);
            // 
            // menuItem237
            // 
            this.menuItem237.Index = 24;
            this.menuItem237.MergeOrder = 9;
            this.menuItem237.Text = "Báo cáo số liệu khám bệnh";
            this.menuItem237.Click += new System.EventHandler(this.menuItem237_Click);
            // 
            // menuItem272
            // 
            this.menuItem272.Index = 25;
            this.menuItem272.MergeOrder = 10;
            this.menuItem272.Text = "Sửa đối tượng";
            this.menuItem272.Click += new System.EventHandler(this.menuItem272_Click);
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 26;
            this.menuItem52.MergeOrder = 11;
            this.menuItem52.Text = "Truy vấn thông tin";
            this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
            // 
            // m354
            // 
            this.m354.Index = 27;
            this.m354.MergeOrder = 354;
            this.m354.Text = "In chỉ định dịch vụ";
            this.m354.Click += new System.EventHandler(this.m354_Click);
            // 
            // m301
            // 
            this.m301.Index = 28;
            this.m301.MergeOrder = 301;
            this.m301.Text = "Danh sách đã in chi phí khám bệnh";
            this.m301.Click += new System.EventHandler(this.menuItem360_Click);
            // 
            // menuItem286
            // 
            this.menuItem286.Index = 29;
            this.menuItem286.MergeOrder = 12;
            this.menuItem286.Text = "Tình hình bệnh tật tại phòng khám theo đối tượng";
            this.menuItem286.Click += new System.EventHandler(this.menuItem286_Click);
            // 
            // menuItem180
            // 
            this.menuItem180.Index = 30;
            this.menuItem180.Text = "-";
            // 
            // menuItem234
            // 
            this.menuItem234.Index = 31;
            this.menuItem234.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem235,
            this.menuItem275,
            this.menuItem276,
            this.menuItem340,
            this.menuItem341});
            this.menuItem234.MergeOrder = 901;
            this.menuItem234.Text = "Báo cáo chỉ định - viện phí - CLS";
            // 
            // menuItem235
            // 
            this.menuItem235.Index = 0;
            this.menuItem235.MergeOrder = 13;
            this.menuItem235.Tag = "0E1";
            this.menuItem235.Text = "Đối chiếu";
            this.menuItem235.Click += new System.EventHandler(this.menuItem235_Click);
            // 
            // menuItem275
            // 
            this.menuItem275.Index = 1;
            this.menuItem275.MergeOrder = 14;
            this.menuItem275.Tag = "0E2";
            this.menuItem275.Text = "Danh sách chỉ định";
            this.menuItem275.Click += new System.EventHandler(this.menuItem275_Click);
            // 
            // menuItem276
            // 
            this.menuItem276.Index = 2;
            this.menuItem276.MergeOrder = 15;
            this.menuItem276.Tag = "0E3";
            this.menuItem276.Text = "Danh sách được chỉ định chưa thực hiện";
            this.menuItem276.Click += new System.EventHandler(this.menuItem276_Click);
            // 
            // menuItem340
            // 
            this.menuItem340.Index = 3;
            this.menuItem340.MergeOrder = 16;
            this.menuItem340.Tag = "0E4";
            this.menuItem340.Text = "Danh sách đã nộp tiền nhưng chưa thực hiện";
            this.menuItem340.Click += new System.EventHandler(this.menuItem340_Click);
            // 
            // menuItem341
            // 
            this.menuItem341.Index = 4;
            this.menuItem341.MergeOrder = 17;
            this.menuItem341.Tag = "0E5";
            this.menuItem341.Text = "Danh sách đã thực hiện";
            this.menuItem341.Click += new System.EventHandler(this.menuItem341_Click);
            // 
            // menuItem240
            // 
            this.menuItem240.Index = 32;
            this.menuItem240.MergeOrder = 12100;
            this.menuItem240.Text = "Chỉ định đóng tạm ứng";
            this.menuItem240.Click += new System.EventHandler(this.menuItem240_Click);
            // 
            // menuItem379
            // 
            this.menuItem379.Index = 33;
            this.menuItem379.MergeOrder = 12200;
            this.menuItem379.Text = "Giấy thử phản ứng thuốc";
            this.menuItem379.Click += new System.EventHandler(this.menuItem379_Click);
            // 
            // menuItem408
            // 
            this.menuItem408.Index = 34;
            this.menuItem408.Text = "Phiếu xuất tủ trực";
            this.menuItem408.Click += new System.EventHandler(this.menuItem408_Click);
            // 
            // menuItem409
            // 
            this.menuItem409.Index = 35;
            this.menuItem409.MergeOrder = 12300;
            this.menuItem409.Text = "Xuất thông tin phòng khám ra màn hình LCD";
            this.menuItem409.Click += new System.EventHandler(this.menuItem409_Click);
            // 
            // menuItem411
            // 
            this.menuItem411.Index = 36;
            this.menuItem411.Text = "Cấp số thứ tự khám";
            this.menuItem411.Click += new System.EventHandler(this.menuItem411_Click);
            // 
            // menuItem412
            // 
            this.menuItem412.Index = 37;
            this.menuItem412.MergeOrder = 12400;
            this.menuItem412.Text = "Theo dõi thực hiện dịch vụ kĩ thuật";
            this.menuItem412.Click += new System.EventHandler(this.menuItem412_Click);
            // 
            // menuItem73
            // 
            this.menuItem73.Index = 1;
            this.menuItem73.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem25,
            this.menuItem91,
            this.m351,
            this.m348,
            this.menuItem261,
            this.m338,
            this.menuItem260,
            this.menuItem342,
            this.m349,
            this.menuItem262,
            this.menuItem92,
            this.menuItem76,
            this.menuItem93,
            this.menuItem251,
            this.menuItem254,
            this.menuItem255,
            this.menuItem337});
            this.menuItem73.MergeOrder = 902;
            this.menuItem73.Text = "N&goại trú";
            this.menuItem73.Click += new System.EventHandler(this.menuItem73_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 0;
            this.menuItem25.MergeOrder = 25;
            this.menuItem25.Tag = "100";
            this.menuItem25.Text = "Bệnh án ngoại trú";
            this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItem91
            // 
            this.menuItem91.Index = 1;
            this.menuItem91.Text = "-";
            // 
            // m351
            // 
            this.m351.Index = 2;
            this.m351.MergeOrder = 351;
            this.m351.Text = "Chỉ định tạm ứng";
            this.m351.Click += new System.EventHandler(this.m351_Click);
            // 
            // m348
            // 
            this.m348.Index = 3;
            this.m348.MergeOrder = 348;
            this.m348.Text = "Chỉ đinh đi khám";
            this.m348.Click += new System.EventHandler(this.m348_Click);
            // 
            // menuItem261
            // 
            this.menuItem261.Index = 4;
            this.menuItem261.MergeOrder = 26;
            this.menuItem261.Tag = "101";
            this.menuItem261.Text = "Sửa đối tượng các dịch vụ";
            this.menuItem261.Click += new System.EventHandler(this.menuItem261_Click);
            // 
            // m338
            // 
            this.m338.Index = 5;
            this.m338.MergeOrder = 338;
            this.m338.Text = "Công nợ";
            this.m338.Click += new System.EventHandler(this.m338_Click);
            // 
            // menuItem260
            // 
            this.menuItem260.Index = 6;
            this.menuItem260.MergeOrder = 27;
            this.menuItem260.Text = "Phiếu thanh toán dịch vụ";
            this.menuItem260.Click += new System.EventHandler(this.menuItem260_Click);
            // 
            // menuItem342
            // 
            this.menuItem342.Index = 7;
            this.menuItem342.MergeOrder = 28;
            this.menuItem342.Text = "Phiếu tổng hợp thuốc && viện phí";
            this.menuItem342.Click += new System.EventHandler(this.menuItem342_Click);
            // 
            // m349
            // 
            this.m349.Index = 8;
            this.m349.MergeOrder = 349;
            this.m349.Text = "In giấy ra viện";
            this.m349.Click += new System.EventHandler(this.m349_Click);
            // 
            // menuItem262
            // 
            this.menuItem262.Index = 9;
            this.menuItem262.Text = "-";
            // 
            // menuItem92
            // 
            this.menuItem92.Index = 10;
            this.menuItem92.MergeOrder = 29;
            this.menuItem92.Text = "Danh sách người bệnh vào điều trị ngoại trú";
            this.menuItem92.Click += new System.EventHandler(this.menuItem92_Click_1);
            // 
            // menuItem76
            // 
            this.menuItem76.Index = 11;
            this.menuItem76.MergeOrder = 30;
            this.menuItem76.Text = "Danh sách người bệnh kết thúc điều trị ngoại trú";
            this.menuItem76.Click += new System.EventHandler(this.menuItem76_Click);
            // 
            // menuItem93
            // 
            this.menuItem93.Index = 12;
            this.menuItem93.MergeOrder = 31;
            this.menuItem93.Text = "Danh sách người bệnh đang điều trị";
            this.menuItem93.Click += new System.EventHandler(this.menuItem93_Click_1);
            // 
            // menuItem251
            // 
            this.menuItem251.Index = 13;
            this.menuItem251.MergeOrder = 32;
            this.menuItem251.Text = "Tổng hợp tình hình người bệnh";
            this.menuItem251.Click += new System.EventHandler(this.menuItem251_Click);
            // 
            // menuItem254
            // 
            this.menuItem254.Index = 14;
            this.menuItem254.MergeOrder = 33;
            this.menuItem254.Text = "Danh sách nhập xuất";
            this.menuItem254.Click += new System.EventHandler(this.menuItem254_Click);
            // 
            // menuItem255
            // 
            this.menuItem255.Index = 15;
            this.menuItem255.MergeOrder = 34;
            this.menuItem255.Text = "Hoạt động phẫu thủ thuật";
            this.menuItem255.Click += new System.EventHandler(this.menuItem255_Click);
            // 
            // menuItem337
            // 
            this.menuItem337.Index = 16;
            this.menuItem337.MergeOrder = 35;
            this.menuItem337.Text = "Báo cáo ngoại trú theo bệnh";
            this.menuItem337.Click += new System.EventHandler(this.menuItem337_Click);
            // 
            // menuItem227
            // 
            this.menuItem227.Index = 2;
            this.menuItem227.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem228,
            this.menuItem265,
            this.m352,
            this.menuItem264,
            this.m341,
            this.menuItem263,
            this.m337,
            this.menuItem229,
            this.menuItem231,
            this.menuItem232,
            this.menuItem230,
            this.menuItem252,
            this.m331,
            this.menuItem403,
            this.menuItem407});
            this.menuItem227.MergeOrder = 903;
            this.menuItem227.Text = "&Phòng lưu";
            // 
            // menuItem228
            // 
            this.menuItem228.Index = 0;
            this.menuItem228.MergeOrder = 36;
            this.menuItem228.Text = "Nhập phòng lưu";
            this.menuItem228.Click += new System.EventHandler(this.menuItem228_Click);
            // 
            // menuItem265
            // 
            this.menuItem265.Index = 1;
            this.menuItem265.Text = "-";
            // 
            // m352
            // 
            this.m352.Index = 2;
            this.m352.MergeOrder = 352;
            this.m352.Text = "Chỉ định tạm ứng";
            this.m352.Click += new System.EventHandler(this.m352_Click);
            // 
            // menuItem264
            // 
            this.menuItem264.Index = 3;
            this.menuItem264.MergeOrder = 37;
            this.menuItem264.Text = "Sửa đối tượng các dịch vụ";
            this.menuItem264.Click += new System.EventHandler(this.menuItem264_Click);
            // 
            // m341
            // 
            this.m341.Index = 4;
            this.m341.MergeOrder = 341;
            this.m341.Text = "Công nợ";
            this.m341.Click += new System.EventHandler(this.m341_Click);
            // 
            // menuItem263
            // 
            this.menuItem263.Index = 5;
            this.menuItem263.MergeOrder = 38;
            this.menuItem263.Text = "Phiếu thanh toán dịch vụ";
            this.menuItem263.Click += new System.EventHandler(this.menuItem263_Click);
            // 
            // m337
            // 
            this.m337.Index = 6;
            this.m337.MergeOrder = 337;
            this.m337.Text = "In giấy ra viện";
            this.m337.Click += new System.EventHandler(this.m337_Click);
            // 
            // menuItem229
            // 
            this.menuItem229.Index = 7;
            this.menuItem229.Text = "-";
            // 
            // menuItem231
            // 
            this.menuItem231.Index = 8;
            this.menuItem231.MergeOrder = 39;
            this.menuItem231.Text = "Danh sách người bệnh vào phòng lưu";
            this.menuItem231.Click += new System.EventHandler(this.menuItem231_Click);
            // 
            // menuItem232
            // 
            this.menuItem232.Index = 9;
            this.menuItem232.MergeOrder = 40;
            this.menuItem232.Text = "Danh sách người bệnh ra phòng lưu";
            this.menuItem232.Click += new System.EventHandler(this.menuItem232_Click);
            // 
            // menuItem230
            // 
            this.menuItem230.Index = 10;
            this.menuItem230.MergeOrder = 41;
            this.menuItem230.Text = "Danh sách người bệnh đang nằm phòng lưu";
            this.menuItem230.Click += new System.EventHandler(this.menuItem230_Click);
            // 
            // menuItem252
            // 
            this.menuItem252.Index = 11;
            this.menuItem252.MergeOrder = 42;
            this.menuItem252.Text = "Tổng hợp tình hình người bệnh";
            this.menuItem252.Click += new System.EventHandler(this.menuItem252_Click);
            // 
            // m331
            // 
            this.m331.Index = 12;
            this.m331.MergeOrder = 331;
            this.m331.Text = "Sổ khám bệnh (phòng lưu)";
            this.m331.Click += new System.EventHandler(this.m331_Click);
            // 
            // menuItem403
            // 
            this.menuItem403.Index = 13;
            this.menuItem403.MergeOrder = 332;
            this.menuItem403.Text = "Phiếu tổng hợp thuốc";
            this.menuItem403.Click += new System.EventHandler(this.menuItem403_Click);
            // 
            // menuItem407
            // 
            this.menuItem407.Index = 14;
            this.menuItem407.Text = "Phiếu xuất tủ trực";
            this.menuItem407.Click += new System.EventHandler(this.menuItem407_Click);
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 3;
            this.menuItem72.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem33,
            this.menuItem34,
            this.menuItem247,
            this.menuItem35,
            this.menuItem248,
            this.m342,
            this.menuItem30,
            this.menuItem365,
            this.menuItem345,
            this.menuItem40,
            this.menuItem41,
            this.menuItem103,
            this.menuItem161,
            this.menuItem221,
            this.menuItem3661,
            this.menuItem367,
            this.menuItem273,
            this.menuItem222,
            this.m353,
            this.menuItem274,
            this.menuItem225,
            this.menuItem308,
            this.menuItem226,
            this.menuItem307,
            this.m345,
            this.m317,
            this.menuItem238,
            this.m344,
            this.menuItem280,
            this.menuItem279,
            this.menuItem300,
            this.menuItem301,
            this.menuItem406});
            this.menuItem72.MergeOrder = 904;
            this.menuItem72.Text = "&Nội trú";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 0;
            this.menuItem33.MergeOrder = 43;
            this.menuItem33.Text = "Nhập viện";
            this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 1;
            this.menuItem34.MergeOrder = 44;
            this.menuItem34.Text = "Nhập khoa";
            this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
            // 
            // menuItem247
            // 
            this.menuItem247.Index = 2;
            this.menuItem247.Text = "-";
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 3;
            this.menuItem35.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem239,
            this.m321,
            this.m320,
            this.menuItem241,
            this.menuItem245,
            this.menuItem285});
            this.menuItem35.MergeOrder = 905;
            this.menuItem35.Text = "Phẫu thuật, thủ thuật";
            // 
            // menuItem239
            // 
            this.menuItem239.Index = 0;
            this.menuItem239.MergeOrder = 45;
            this.menuItem239.Text = "Nhập phẫu thủ thuật";
            this.menuItem239.Click += new System.EventHandler(this.menuItem239_Click);
            // 
            // m321
            // 
            this.m321.Index = 1;
            this.m321.MergeOrder = 321;
            this.m321.Text = "Nhập thủ thuật";
            this.m321.Click += new System.EventHandler(this.m321_Click);
            // 
            // m320
            // 
            this.m320.Index = 2;
            this.m320.MergeOrder = 320;
            this.m320.Text = "Lịch phẫu thủ thuật";
            this.m320.Click += new System.EventHandler(this.m320_Click);
            // 
            // menuItem241
            // 
            this.menuItem241.Index = 3;
            this.menuItem241.MergeOrder = 46;
            this.menuItem241.Text = "Tường trình phẫu thủ thuật";
            this.menuItem241.Click += new System.EventHandler(this.menuItem241_Click);
            // 
            // menuItem245
            // 
            this.menuItem245.Index = 4;
            this.menuItem245.MergeOrder = 47;
            this.menuItem245.Text = "Danh sách phẫu thuật, thủ thuật";
            this.menuItem245.Click += new System.EventHandler(this.menuItem245_Click);
            // 
            // menuItem285
            // 
            this.menuItem285.Index = 5;
            this.menuItem285.MergeOrder = 48;
            this.menuItem285.Text = "Truy vấn thông tin";
            this.menuItem285.Click += new System.EventHandler(this.menuItem285_Click);
            // 
            // menuItem248
            // 
            this.menuItem248.Index = 4;
            this.menuItem248.Text = "-";
            // 
            // m342
            // 
            this.m342.Index = 5;
            this.m342.MergeOrder = 342;
            this.m342.Text = "Hồ sơ bệnh án";
            this.m342.Click += new System.EventHandler(this.menuItem28_Click_2);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 6;
            this.menuItem30.Text = "-";
            // 
            // menuItem365
            // 
            this.menuItem365.Index = 7;
            this.menuItem365.MergeOrder = 49;
            this.menuItem365.Text = "Chuyển phòng giường";
            this.menuItem365.Click += new System.EventHandler(this.menuItem365_Click);
            // 
            // menuItem345
            // 
            this.menuItem345.Index = 8;
            this.menuItem345.MergeOrder = 40600;
            this.menuItem345.Text = "Đăng ký thêm giường";
            this.menuItem345.Click += new System.EventHandler(this.menuItem345_Click_1);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 9;
            this.menuItem40.MergeOrder = 50;
            this.menuItem40.Text = "Xuất khoa";
            this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 10;
            this.menuItem41.MergeOrder = 51;
            this.menuItem41.Text = "Xuất viện";
            this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
            // 
            // menuItem103
            // 
            this.menuItem103.Index = 11;
            this.menuItem103.Text = "-";
            // 
            // menuItem161
            // 
            this.menuItem161.Index = 12;
            this.menuItem161.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem166,
            this.menuItem169,
            this.menuItem306,
            this.menuItem170,
            this.menuItem172,
            this.menuItem388,
            this.menuItem173,
            this.m322,
            this.m323,
            this.m324,
            this.m350,
            this.menuItem175,
            this.menuItem176,
            this.menuItem177,
            this.menuItem355,
            this.menuItem356,
            this.menuItem357,
            this.menuItem358,
            this.menuItem359,
            this.menuItem178,
            this.menuItem216,
            this.menuItem218,
            this.menuItem46,
            this.menuItem223,
            this.menuItem224,
            this.menuItem67,
            this.menuItem360,
            this.m304});
            this.menuItem161.MergeOrder = 906;
            this.menuItem161.Text = "Thuốc, Vật tư y tế, Tài sản";
            // 
            // menuItem166
            // 
            this.menuItem166.Index = 0;
            this.menuItem166.MergeOrder = 52;
            this.menuItem166.Text = "Dự trù thuốc, Vật tư y tế theo người bệnh ";
            this.menuItem166.Click += new System.EventHandler(this.menuItem166_Click_1);
            // 
            // menuItem169
            // 
            this.menuItem169.Index = 1;
            this.menuItem169.MergeOrder = 53;
            this.menuItem169.Text = "Phiếu xuất cơ số tủ trực theo người bệnh";
            this.menuItem169.Click += new System.EventHandler(this.menuItem169_Click_2);
            // 
            // menuItem306
            // 
            this.menuItem306.Index = 2;
            this.menuItem306.MergeOrder = 54;
            this.menuItem306.Text = "Phiếu xuất cơ số tủ trực theo khoa/phòng";
            this.menuItem306.Click += new System.EventHandler(this.menuItem306_Click);
            // 
            // menuItem170
            // 
            this.menuItem170.Index = 3;
            this.menuItem170.MergeOrder = 55;
            this.menuItem170.Text = "Phiếu hoàn trả thuốc, Vật tư y tế theo người bệnh";
            this.menuItem170.Click += new System.EventHandler(this.menuItem170_Click_2);
            // 
            // menuItem172
            // 
            this.menuItem172.Index = 4;
            this.menuItem172.MergeOrder = 56;
            this.menuItem172.Text = "Dự trù lĩnh hao phí theo khoa/phòng";
            this.menuItem172.Click += new System.EventHandler(this.menuItem172_Click_1);
            // 
            // menuItem388
            // 
            this.menuItem388.Index = 5;
            this.menuItem388.MergeOrder = 10408;
            this.menuItem388.Text = "Phiếu hoàn trả hao phí theo khoa/phòng";
            this.menuItem388.Click += new System.EventHandler(this.menuItem388_Click);
            // 
            // menuItem173
            // 
            this.menuItem173.Index = 6;
            this.menuItem173.MergeOrder = 57;
            this.menuItem173.Text = "Phiếu hoàn trả thuốc, Vật tư y tế thừa theo khoa/phòng ";
            this.menuItem173.Click += new System.EventHandler(this.menuItem173_Click_1);
            // 
            // m322
            // 
            this.m322.Index = 7;
            this.m322.MergeOrder = 322;
            this.m322.Text = "Đơn thuốc";
            this.m322.Click += new System.EventHandler(this.m322_Click);
            // 
            // m323
            // 
            this.m323.Index = 8;
            this.m323.MergeOrder = 323;
            this.m323.Text = "Phiếu lĩnh / hoàn trả (đơn thuốc)";
            this.m323.Click += new System.EventHandler(this.m323_Click);
            // 
            // m324
            // 
            this.m324.Index = 9;
            this.m324.MergeOrder = 324;
            this.m324.Text = "Phiếu xuất (đơn thuốc)";
            this.m324.Click += new System.EventHandler(this.m324_Click);
            // 
            // m350
            // 
            this.m350.Index = 10;
            this.m350.MergeOrder = 350;
            this.m350.Text = "Duyệt thuốc chờ lãnh đạo";
            this.m350.Click += new System.EventHandler(this.m350_Click);
            // 
            // menuItem175
            // 
            this.menuItem175.Index = 11;
            this.menuItem175.Text = "-";
            // 
            // menuItem176
            // 
            this.menuItem176.Index = 12;
            this.menuItem176.MergeOrder = 58;
            this.menuItem176.Text = "Phiếu dự trù tài sản";
            this.menuItem176.Click += new System.EventHandler(this.menuItem176_Click_1);
            // 
            // menuItem177
            // 
            this.menuItem177.Index = 13;
            this.menuItem177.MergeOrder = 59;
            this.menuItem177.Text = "Phiếu hoàn trả tài sản";
            this.menuItem177.Click += new System.EventHandler(this.menuItem177_Click_1);
            // 
            // menuItem355
            // 
            this.menuItem355.Index = 14;
            this.menuItem355.Text = "-";
            // 
            // menuItem356
            // 
            this.menuItem356.Index = 15;
            this.menuItem356.MergeOrder = 60;
            this.menuItem356.Text = "Xem cơ số tủ trực hiện tại";
            this.menuItem356.Click += new System.EventHandler(this.menuItem356_Click);
            // 
            // menuItem357
            // 
            this.menuItem357.Index = 16;
            this.menuItem357.MergeOrder = 61;
            this.menuItem357.Text = "Xem cơ số tủ trực từ ngày ... đến ngày";
            this.menuItem357.Click += new System.EventHandler(this.menuItem357_Click);
            // 
            // menuItem358
            // 
            this.menuItem358.Index = 17;
            this.menuItem358.MergeOrder = 62;
            this.menuItem358.Text = "Xem tài sản tại khoa";
            this.menuItem358.Click += new System.EventHandler(this.menuItem358_Click);
            // 
            // menuItem359
            // 
            this.menuItem359.Index = 18;
            this.menuItem359.MergeOrder = 63;
            this.menuItem359.Text = "Báo cáo sử dụng";
            this.menuItem359.Click += new System.EventHandler(this.menuItem359_Click);
            // 
            // menuItem178
            // 
            this.menuItem178.Index = 19;
            this.menuItem178.Text = "-";
            // 
            // menuItem216
            // 
            this.menuItem216.Index = 20;
            this.menuItem216.MergeOrder = 64;
            this.menuItem216.Text = "Phiếu tổng hợp y lệnh";
            this.menuItem216.Click += new System.EventHandler(this.menuItem216_Click);
            // 
            // menuItem218
            // 
            this.menuItem218.Index = 21;
            this.menuItem218.MergeOrder = 65;
            this.menuItem218.Text = "In phiếu lĩnh";
            this.menuItem218.Click += new System.EventHandler(this.menuItem218_Click);
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 22;
            this.menuItem46.MergeOrder = 66;
            this.menuItem46.Text = "In phiếu xuất";
            this.menuItem46.Click += new System.EventHandler(this.menuItem46_Click);
            // 
            // menuItem223
            // 
            this.menuItem223.Index = 23;
            this.menuItem223.Text = "-";
            // 
            // menuItem224
            // 
            this.menuItem224.Index = 24;
            this.menuItem224.MergeOrder = 67;
            this.menuItem224.Text = "Phiếu tổng hợp thuốc";
            this.menuItem224.Click += new System.EventHandler(this.menuItem224_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 25;
            this.menuItem67.MergeOrder = 68;
            this.menuItem67.Text = "In phiếu công khai sử dụng thuốc && dịch vụ";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click_1);
            // 
            // menuItem360
            // 
            this.menuItem360.Index = 26;
            this.menuItem360.Text = "-";
            // 
            // m304
            // 
            this.m304.Index = 27;
            this.m304.MergeOrder = 304;
            this.m304.Text = "Danh sách các phiếu đã dự trù";
            this.m304.Click += new System.EventHandler(this.m304_Click);
            // 
            // menuItem221
            // 
            this.menuItem221.Index = 13;
            this.menuItem221.Text = "-";
            // 
            // menuItem3661
            // 
            this.menuItem3661.Index = 14;
            this.menuItem3661.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m307,
            this.m309,
            this.m311});
            this.menuItem3661.MergeOrder = 907;
            this.menuItem3661.Text = "Dinh dưỡng";
            this.menuItem3661.Click += new System.EventHandler(this.m307_Click);
            // 
            // m307
            // 
            this.m307.Index = 0;
            this.m307.MergeOrder = 307;
            this.m307.Text = "Phiếu báo ăn";
            this.m307.Click += new System.EventHandler(this.m307_Click);
            // 
            // m309
            // 
            this.m309.Index = 1;
            this.m309.MergeOrder = 309;
            this.m309.Text = "In phiếu báo ăn";
            this.m309.Click += new System.EventHandler(this.m309_Click);
            // 
            // m311
            // 
            this.m311.Index = 2;
            this.m311.MergeOrder = 311;
            this.m311.Text = "Phiếu chấm ăn hàng ngày để thanh toán ra viện";
            // 
            // menuItem367
            // 
            this.menuItem367.Index = 15;
            this.menuItem367.Text = "-";
            // 
            // menuItem273
            // 
            this.menuItem273.Index = 16;
            this.menuItem273.MergeOrder = 69;
            this.menuItem273.Text = "Chỉ định dịch vụ";
            this.menuItem273.Click += new System.EventHandler(this.menuItem273_Click);
            // 
            // menuItem222
            // 
            this.menuItem222.Index = 17;
            this.menuItem222.MergeOrder = 70;
            this.menuItem222.Text = "Viện phí tại khoa";
            this.menuItem222.Click += new System.EventHandler(this.menuItem222_Click);
            // 
            // m353
            // 
            this.m353.Index = 18;
            this.m353.MergeOrder = 353;
            this.m353.Text = "Chỉ định tạm ứng";
            this.m353.Click += new System.EventHandler(this.m353_Click);
            // 
            // menuItem274
            // 
            this.menuItem274.Index = 19;
            this.menuItem274.MergeOrder = 71;
            this.menuItem274.Text = "Chỉ định đi khám";
            this.menuItem274.Click += new System.EventHandler(this.menuItem274_Click);
            // 
            // menuItem225
            // 
            this.menuItem225.Index = 20;
            this.menuItem225.MergeOrder = 72;
            this.menuItem225.Text = "Phiếu thanh toán ra viện";
            this.menuItem225.Click += new System.EventHandler(this.menuItem225_Click);
            // 
            // menuItem308
            // 
            this.menuItem308.Index = 21;
            this.menuItem308.MergeOrder = 73;
            this.menuItem308.Text = "Danh sách chỉ định && viện phí";
            this.menuItem308.Click += new System.EventHandler(this.menuItem308_Click);
            // 
            // menuItem226
            // 
            this.menuItem226.Index = 22;
            this.menuItem226.MergeOrder = 74;
            this.menuItem226.Text = "In giấy ra viện";
            this.menuItem226.Click += new System.EventHandler(this.menuItem226_Click);
            // 
            // menuItem307
            // 
            this.menuItem307.Index = 23;
            this.menuItem307.MergeOrder = 75;
            this.menuItem307.Text = "In giấy chuyển viện";
            this.menuItem307.Click += new System.EventHandler(this.menuItem307_Click);
            // 
            // m345
            // 
            this.m345.Index = 24;
            this.m345.MergeOrder = 41900;
            this.m345.Text = "In giấy xác nhận";
            this.m345.Click += new System.EventHandler(this.m345_Click);
            // 
            // m317
            // 
            this.m317.Index = 25;
            this.m317.MergeOrder = 317;
            this.m317.Text = "Biên bản kiểm thảo tử vong";
            this.m317.Click += new System.EventHandler(this.m317_Click);
            // 
            // menuItem238
            // 
            this.menuItem238.Index = 26;
            this.menuItem238.MergeOrder = 76;
            this.menuItem238.Text = "Sửa đối tượng các dịch vụ";
            this.menuItem238.Click += new System.EventHandler(this.menuItem238_Click);
            // 
            // m344
            // 
            this.m344.Index = 27;
            this.m344.MergeOrder = 344;
            this.m344.Text = "Sửa đối tượng tạm ứng";
            this.m344.Click += new System.EventHandler(this.m344_Click);
            // 
            // menuItem280
            // 
            this.menuItem280.Index = 28;
            this.menuItem280.MergeOrder = 77;
            this.menuItem280.Text = "Dấu sinh tồn";
            this.menuItem280.Click += new System.EventHandler(this.menuItem280_Click);
            // 
            // menuItem279
            // 
            this.menuItem279.Index = 29;
            this.menuItem279.Text = "-";
            // 
            // menuItem300
            // 
            this.menuItem300.Index = 30;
            this.menuItem300.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem233,
            this.menuItem310,
            this.menuItem311,
            this.menuItem313,
            this.menuItem314,
            this.menuItem304,
            this.menuItem302});
            this.menuItem300.MergeOrder = 908;
            this.menuItem300.Text = "Chi phí điều trị";
            this.menuItem300.Click += new System.EventHandler(this.menuItem300_Click);
            // 
            // menuItem233
            // 
            this.menuItem233.Index = 0;
            this.menuItem233.MergeOrder = 78;
            this.menuItem233.Text = "Công nợ";
            this.menuItem233.Click += new System.EventHandler(this.menuItem233_Click_1);
            // 
            // menuItem310
            // 
            this.menuItem310.Index = 1;
            this.menuItem310.MergeOrder = 79;
            this.menuItem310.Text = "Bảng thanh toán chi phí điều trị nội trú";
            this.menuItem310.Click += new System.EventHandler(this.menuItem310_Click);
            // 
            // menuItem311
            // 
            this.menuItem311.Index = 2;
            this.menuItem311.MergeOrder = 80;
            this.menuItem311.Text = "Bảng tổng hợp chi phí điều trị nội trú";
            this.menuItem311.Click += new System.EventHandler(this.menuItem311_Click);
            // 
            // menuItem313
            // 
            this.menuItem313.Index = 3;
            this.menuItem313.MergeOrder = 81;
            this.menuItem313.Text = "Bảng thanh toán chi phí KCB ngoại trú";
            this.menuItem313.Click += new System.EventHandler(this.menuItem313_Click);
            // 
            // menuItem314
            // 
            this.menuItem314.Index = 4;
            this.menuItem314.MergeOrder = 82;
            this.menuItem314.Text = "Bảng tổng hợp chi phí KCB ngoại trú";
            this.menuItem314.Click += new System.EventHandler(this.menuItem314_Click);
            // 
            // menuItem304
            // 
            this.menuItem304.Index = 5;
            this.menuItem304.MergeOrder = 83;
            this.menuItem304.Text = "Chi chí điều trị theo người bệnh";
            this.menuItem304.Click += new System.EventHandler(this.menuItem304_Click);
            // 
            // menuItem302
            // 
            this.menuItem302.Index = 6;
            this.menuItem302.MergeOrder = 84;
            this.menuItem302.Text = "Chi phí && số ngày điều trị theo chẩn đoán";
            this.menuItem302.Click += new System.EventHandler(this.menuItem302_Click);
            // 
            // menuItem301
            // 
            this.menuItem301.Index = 31;
            this.menuItem301.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem303,
            this.menuItem305,
            this.menuItem281,
            this.menuItem309});
            this.menuItem301.MergeOrder = 909;
            this.menuItem301.Text = "Dược lâm sàng";
            // 
            // menuItem303
            // 
            this.menuItem303.Index = 0;
            this.menuItem303.MergeOrder = 85;
            this.menuItem303.Text = "Sử dụng thuốc trước && sau mỗ";
            this.menuItem303.Click += new System.EventHandler(this.menuItem303_Click);
            // 
            // menuItem305
            // 
            this.menuItem305.Index = 1;
            this.menuItem305.MergeOrder = 86;
            this.menuItem305.Text = "Danh sách người bệnh sử dụng 1 loại thuốc";
            this.menuItem305.Click += new System.EventHandler(this.menuItem305_Click);
            // 
            // menuItem281
            // 
            this.menuItem281.Index = 2;
            this.menuItem281.MergeOrder = 87;
            this.menuItem281.Text = "Danh sách người bệnh sử dụng thuốc && vật tư";
            this.menuItem281.Click += new System.EventHandler(this.menuItem281_Click_1);
            // 
            // menuItem309
            // 
            this.menuItem309.Index = 3;
            this.menuItem309.MergeOrder = 88;
            this.menuItem309.Text = "Tổng hợp người bệnh && thuốc";
            this.menuItem309.Click += new System.EventHandler(this.menuItem309_Click);
            // 
            // menuItem406
            // 
            this.menuItem406.Index = 32;
            this.menuItem406.MergeOrder = 42600;
            this.menuItem406.Text = "Kiểm soát dịch vụ";
            this.menuItem406.Click += new System.EventHandler(this.menuItem406_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 4;
            this.menuItem71.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem104,
            this.menuItem105,
            this.menuItem246});
            this.menuItem71.MergeOrder = 910;
            this.menuItem71.Text = "&Nhập tổng hợp";
            // 
            // menuItem104
            // 
            this.menuItem104.Index = 0;
            this.menuItem104.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem108,
            this.menuItem109,
            this.menuItem110,
            this.menuItem111,
            this.menuItem112,
            this.menuItem113,
            this.menuItem114,
            this.menuItem115,
            this.menuItem116,
            this.menuItem117,
            this.menuItem118,
            this.menuItem119,
            this.menuItem120,
            this.menuItem121,
            this.menuItem122,
            this.menuItem346});
            this.menuItem104.MergeOrder = 911;
            this.menuItem104.Text = "Vụ điều trị";
            // 
            // menuItem108
            // 
            this.menuItem108.Index = 0;
            this.menuItem108.MergeOrder = 121;
            this.menuItem108.Text = "Biểu 01-CVCC";
            this.menuItem108.Click += new System.EventHandler(this.menuItem70_Click);
            // 
            // menuItem109
            // 
            this.menuItem109.Index = 1;
            this.menuItem109.MergeOrder = 122;
            this.menuItem109.Text = "Biểu 02-KB";
            this.menuItem109.Click += new System.EventHandler(this.menuItem74_Click);
            // 
            // menuItem110
            // 
            this.menuItem110.Index = 2;
            this.menuItem110.MergeOrder = 123;
            this.menuItem110.Text = "Biểu 03.1-ĐT";
            this.menuItem110.Click += new System.EventHandler(this.menuItem75_Click);
            // 
            // menuItem111
            // 
            this.menuItem111.Index = 3;
            this.menuItem111.MergeOrder = 124;
            this.menuItem111.Text = "Biểu 04-PT/TT";
            this.menuItem111.Click += new System.EventHandler(this.menuItem77_Click);
            // 
            // menuItem112
            // 
            this.menuItem112.Index = 4;
            this.menuItem112.MergeOrder = 125;
            this.menuItem112.Text = "Biểu 05-SKSS";
            this.menuItem112.Click += new System.EventHandler(this.menuItem78_Click);
            // 
            // menuItem113
            // 
            this.menuItem113.Index = 5;
            this.menuItem113.MergeOrder = 126;
            this.menuItem113.Text = "Biểu 06-CLS";
            this.menuItem113.Click += new System.EventHandler(this.menuItem79_Click);
            // 
            // menuItem114
            // 
            this.menuItem114.Index = 6;
            this.menuItem114.MergeOrder = 127;
            this.menuItem114.Text = "Biểu 07-DBV";
            this.menuItem114.Click += new System.EventHandler(this.menuItem80_Click);
            // 
            // menuItem115
            // 
            this.menuItem115.Index = 7;
            this.menuItem115.MergeOrder = 128;
            this.menuItem115.Text = "Biểu 08-TTB";
            this.menuItem115.Click += new System.EventHandler(this.menuItem81_Click);
            // 
            // menuItem116
            // 
            this.menuItem116.Index = 8;
            this.menuItem116.MergeOrder = 129;
            this.menuItem116.Text = "Biểu 09.1-CĐT";
            this.menuItem116.Click += new System.EventHandler(this.menuItem82_Click);
            // 
            // menuItem117
            // 
            this.menuItem117.Index = 9;
            this.menuItem117.MergeOrder = 130;
            this.menuItem117.Text = "Biểu 09.2-NCKH";
            this.menuItem117.Click += new System.EventHandler(this.menuItem83_Click);
            // 
            // menuItem118
            // 
            this.menuItem118.Index = 10;
            this.menuItem118.MergeOrder = 131;
            this.menuItem118.Text = "Biểu 10.1-TC";
            this.menuItem118.Click += new System.EventHandler(this.menuItem84_Click);
            // 
            // menuItem119
            // 
            this.menuItem119.Index = 11;
            this.menuItem119.MergeOrder = 132;
            this.menuItem119.Text = "Biểu 10.2.1-TCTVP/BH";
            this.menuItem119.Click += new System.EventHandler(this.menuItem85_Click);
            // 
            // menuItem120
            // 
            this.menuItem120.Index = 12;
            this.menuItem120.MergeOrder = 133;
            this.menuItem120.Text = "Biểu 10.2.2-TCC";
            this.menuItem120.Click += new System.EventHandler(this.menuItem86_Click);
            // 
            // menuItem121
            // 
            this.menuItem121.Index = 13;
            this.menuItem121.MergeOrder = 134;
            this.menuItem121.Text = "Biểu 10.3-TC/KT";
            this.menuItem121.Click += new System.EventHandler(this.menuItem87_Click);
            // 
            // menuItem122
            // 
            this.menuItem122.Index = 14;
            this.menuItem122.MergeOrder = 135;
            this.menuItem122.Text = "Biểu 11-BTTV";
            this.menuItem122.Click += new System.EventHandler(this.menuItem88_Click);
            // 
            // menuItem346
            // 
            this.menuItem346.Index = 15;
            this.menuItem346.MergeOrder = 50116;
            this.menuItem346.Text = "Biểu 11-BTTV-2010";
            this.menuItem346.Click += new System.EventHandler(this.menuItem346_Click_1);
            // 
            // menuItem105
            // 
            this.menuItem105.Index = 1;
            this.menuItem105.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem6,
            this.menuItem7,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem14,
            this.menuItem15,
            this.menuItem16,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19,
            this.menuItem80,
            this.menuItem20,
            this.menuItem21,
            this.menuItem23,
            this.menuItem70,
            this.menuItem74,
            this.menuItem75,
            this.menuItem77,
            this.menuItem78,
            this.menuItem79});
            this.menuItem105.MergeOrder = 912;
            this.menuItem105.Text = "Vụ kế hoạch";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MergeOrder = 136;
            this.menuItem2.Text = "Biểu 01 - Dân số, đơn vị hành chính, trạm y tế xã";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_1);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MergeOrder = 137;
            this.menuItem6.Text = "Biểu 02 - Thông tin về sinh, tử";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click_1);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MergeOrder = 138;
            this.menuItem7.Text = "Biểu 03 - Tình hình thu, chi ngân sách ngành y tế địa phương";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_1);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.MergeOrder = 139;
            this.menuItem9.Text = "Biểu 04 - Tình hình thu, chi ngân sách của tuyến xã";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click_1);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.MergeOrder = 140;
            this.menuItem10.Text = "Biểu 05 - Tình hình cơ sở y tế và giường bệnh";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click_1);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 5;
            this.menuItem11.MergeOrder = 141;
            this.menuItem11.Text = "Biểu 06 - Tình hình nhân lực y tế toàn huyện";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click_1);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 6;
            this.menuItem12.MergeOrder = 142;
            this.menuItem12.Text = "Biểu 07 - Tình hình sản xuất kinh doanh dược của huyện";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click_1);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 7;
            this.menuItem13.MergeOrder = 143;
            this.menuItem13.Text = "Biểu 08 - Tình hình trang thiết bị y tế của địa phương";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click_1);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 8;
            this.menuItem14.MergeOrder = 144;
            this.menuItem14.Text = "Biểu 09 - Chăm sóc sức khỏe trẻ em";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click_1);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 9;
            this.menuItem15.MergeOrder = 145;
            this.menuItem15.Text = "Biểu 10 - Tình hình chăm sóc sức khỏe bà mẹ";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click_1);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 10;
            this.menuItem16.MergeOrder = 146;
            this.menuItem16.Text = "Biểu 11 - Thực hiện công tác kế hoạch hóa gia đình";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click_1);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 11;
            this.menuItem17.MergeOrder = 147;
            this.menuItem17.Text = "Biểu 12.1 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click_1);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 12;
            this.menuItem18.MergeOrder = 148;
            this.menuItem18.Text = "Biểu 12.2 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click_1);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 13;
            this.menuItem19.MergeOrder = 149;
            this.menuItem19.Text = "Biểu 12.3 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click_1);
            // 
            // menuItem80
            // 
            this.menuItem80.Index = 14;
            this.menuItem80.MergeOrder = 150;
            this.menuItem80.Text = "Biểu 12.4 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem80.Click += new System.EventHandler(this.menuItem80_Click_1);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 15;
            this.menuItem20.MergeOrder = 151;
            this.menuItem20.Text = "Biểu 13.1 - Thực hiện công tác phòng bệnh";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click_1);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 16;
            this.menuItem21.MergeOrder = 152;
            this.menuItem21.Text = "Biểu 13.2 - Thực hiện công tác phòng bệnh";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 17;
            this.menuItem23.MergeOrder = 153;
            this.menuItem23.Text = "Biểu 13.3 - Thực hiện công tác phòng bệnh";
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click_1);
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 18;
            this.menuItem70.MergeOrder = 154;
            this.menuItem70.Text = "Biểu 14.1 - Các bệnh lây và bệnh quan trọng";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click_1);
            // 
            // menuItem74
            // 
            this.menuItem74.Index = 19;
            this.menuItem74.MergeOrder = 155;
            this.menuItem74.Text = "Biểu 14.2 - Các bệnh lây và bệnh quan trọng";
            this.menuItem74.Click += new System.EventHandler(this.menuItem74_Click_1);
            // 
            // menuItem75
            // 
            this.menuItem75.Index = 20;
            this.menuItem75.MergeOrder = 156;
            this.menuItem75.Text = "Biểu 14.3 - Các bệnh lây và bệnh quan trọng";
            this.menuItem75.Click += new System.EventHandler(this.menuItem75_Click_1);
            // 
            // menuItem77
            // 
            this.menuItem77.Index = 21;
            this.menuItem77.MergeOrder = 157;
            this.menuItem77.Text = "Biểu 14.4 - Các bệnh lây và bệnh quan trọng";
            this.menuItem77.Click += new System.EventHandler(this.menuItem77_Click_1);
            // 
            // menuItem78
            // 
            this.menuItem78.Index = 22;
            this.menuItem78.MergeOrder = 158;
            this.menuItem78.Text = "Biểu 14.5 - Báo cáo thống kê tai nạn, thương tích";
            this.menuItem78.Click += new System.EventHandler(this.menuItem78_Click_1);
            // 
            // menuItem79
            // 
            this.menuItem79.Index = 23;
            this.menuItem79.MergeOrder = 159;
            this.menuItem79.Text = "Biểu 15 - Tình hình bệnh tật, tử vong tại bệnh viện";
            this.menuItem79.Click += new System.EventHandler(this.menuItem79_Click_1);
            // 
            // menuItem246
            // 
            this.menuItem246.Index = 2;
            this.menuItem246.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem271,
            this.menuItem283,
            this.menuItem287,
            this.menuItem288,
            this.menuItem290,
            this.menuItem291,
            this.menuItem292,
            this.menuItem293,
            this.menuItem294,
            this.menuItem295,
            this.menuItem296,
            this.menuItem297,
            this.menuItem298,
            this.menuItem299,
            this.menuItem315,
            this.menuItem316,
            this.menuItem317,
            this.menuItem336,
            this.menuItem390,
            this.menuItem392,
            this.menuItem393,
            this.menuItem344});
            this.menuItem246.MergeOrder = 50300;
            this.menuItem246.Text = "Vụ kế hoạch (năm 2012)";
            // 
            // menuItem271
            // 
            this.menuItem271.Index = 0;
            this.menuItem271.MergeOrder = 50301;
            this.menuItem271.Text = "Biểu 01 - Dân số và đơn vị hành chính";
            this.menuItem271.Click += new System.EventHandler(this.menuItem271_Click);
            // 
            // menuItem283
            // 
            this.menuItem283.Index = 1;
            this.menuItem283.MergeOrder = 50302;
            this.menuItem283.Text = "Biểu 02 - Tình hình sinh tử trong tỉnh";
            this.menuItem283.Click += new System.EventHandler(this.menuItem283_Click_2);
            // 
            // menuItem287
            // 
            this.menuItem287.Index = 2;
            this.menuItem287.MergeOrder = 50303;
            this.menuItem287.Text = "Biểu 03 - Tình hình thu, chi ngân sách ngành y tế địa phương";
            this.menuItem287.Click += new System.EventHandler(this.menuItem287_Click_2);
            // 
            // menuItem288
            // 
            this.menuItem288.Index = 3;
            this.menuItem288.MergeOrder = 50304;
            this.menuItem288.Text = "Biểu 04a - Tình hình cơ sở y tế và giường bệnh";
            this.menuItem288.Click += new System.EventHandler(this.menuItem288_Click);
            // 
            // menuItem290
            // 
            this.menuItem290.Index = 4;
            this.menuItem290.MergeOrder = 50305;
            this.menuItem290.Text = "Biểu 04b - Tình hình y tế xã phường";
            this.menuItem290.Click += new System.EventHandler(this.menuItem290_Click_1);
            // 
            // menuItem291
            // 
            this.menuItem291.Index = 5;
            this.menuItem291.MergeOrder = 50305;
            this.menuItem291.Text = "Biểu 05 - Tình hình nhân lực y tế toàn tỉnh/thànhphố";
            this.menuItem291.Click += new System.EventHandler(this.menuItem291_Click);
            // 
            // menuItem292
            // 
            this.menuItem292.Index = 6;
            this.menuItem292.MergeOrder = 50307;
            this.menuItem292.Text = "Biểu 06 - Tình hình hoạt động BHYT";
            this.menuItem292.Click += new System.EventHandler(this.menuItem292_Click_1);
            // 
            // menuItem293
            // 
            this.menuItem293.Index = 7;
            this.menuItem293.MergeOrder = 50308;
            this.menuItem293.Text = "Biểu 07 - Tình hình sản xuất kinh doanh dược ";
            this.menuItem293.Click += new System.EventHandler(this.menuItem293_Click_1);
            // 
            // menuItem294
            // 
            this.menuItem294.Index = 8;
            this.menuItem294.MergeOrder = 50309;
            this.menuItem294.Text = "Biểu 08 - Tình hình đào tạo nhân lực y tế địa phương";
            this.menuItem294.Click += new System.EventHandler(this.menuItem294_Click_1);
            // 
            // menuItem295
            // 
            this.menuItem295.Index = 9;
            this.menuItem295.MergeOrder = 50310;
            this.menuItem295.Text = "Biểu 09 - Hoạt động chăm sóc bà mẹ";
            this.menuItem295.Click += new System.EventHandler(this.menuItem295_Click);
            // 
            // menuItem296
            // 
            this.menuItem296.Index = 10;
            this.menuItem296.MergeOrder = 50311;
            this.menuItem296.Text = "Biểu 10 - Tình hình mắc chết do tai biến sản khoa";
            this.menuItem296.Click += new System.EventHandler(this.menuItem296_Click);
            // 
            // menuItem297
            // 
            this.menuItem297.Index = 11;
            this.menuItem297.MergeOrder = 50312;
            this.menuItem297.Text = "Biểu 11 - Hoạt động khám chữa phụ khoa và nạo phá thai";
            this.menuItem297.Click += new System.EventHandler(this.menuItem297_Click_1);
            // 
            // menuItem298
            // 
            this.menuItem298.Index = 12;
            this.menuItem298.MergeOrder = 50313;
            this.menuItem298.Text = "Biểu 12 - Hoạt động cung cấp dịch vụ kế hoạch hóa gia đình";
            this.menuItem298.Click += new System.EventHandler(this.menuItem298_Click_1);
            // 
            // menuItem299
            // 
            this.menuItem299.Index = 13;
            this.menuItem299.MergeOrder = 50314;
            this.menuItem299.Text = "Biểu 13 - Tình hình sức khỏe trẻ em";
            this.menuItem299.Click += new System.EventHandler(this.menuItem299_Click_1);
            // 
            // menuItem315
            // 
            this.menuItem315.Index = 14;
            this.menuItem315.MergeOrder = 50315;
            this.menuItem315.Text = "Biểu 14 - Hoạt động tiêm chủng phòng 10 bệnh cho trẻ em";
            this.menuItem315.Click += new System.EventHandler(this.menuItem315_Click);
            // 
            // menuItem316
            // 
            this.menuItem316.Index = 15;
            this.menuItem316.MergeOrder = 50316;
            this.menuItem316.Text = "Biểu 15 - Tình hình mắc chết các bệnh có vắc xin phòng ngừa";
            this.menuItem316.Click += new System.EventHandler(this.menuItem316_Click_1);
            // 
            // menuItem317
            // 
            this.menuItem317.Index = 16;
            this.menuItem317.MergeOrder = 50317;
            this.menuItem317.Text = "Biểu 16.1 - Báo cáo hoạt động khám chữa bệnh";
            this.menuItem317.Click += new System.EventHandler(this.menuItem317_Click_1);
            // 
            // menuItem336
            // 
            this.menuItem336.Index = 17;
            this.menuItem336.MergeOrder = 50318;
            this.menuItem336.Text = "Biểu 16.2 - Hoạt động khám chữa bệnh (Tiếp)";
            this.menuItem336.Click += new System.EventHandler(this.menuItem336_Click_1);
            // 
            // menuItem390
            // 
            this.menuItem390.Index = 18;
            this.menuItem390.Text = "Biểu 17 - Hoạt động phòng chống bệnh xã hội";
            this.menuItem390.Click += new System.EventHandler(this.menuItem390_Click);
            // 
            // menuItem392
            // 
            this.menuItem392.Index = 19;
            this.menuItem392.Text = "Biểu 18 - Tình hình mắc chết bệnh truyền nhiễm gây dịch và bệnh quan trọng";
            this.menuItem392.Click += new System.EventHandler(this.menuItem392_Click);
            // 
            // menuItem393
            // 
            this.menuItem393.Index = 20;
            this.menuItem393.Text = "Biểu 19 - Tình hình bệnh tật, tử vong tại bệnh viện theo ICD 10 - WHO";
            this.menuItem393.Click += new System.EventHandler(this.menuItem393_Click);
            // 
            // menuItem344
            // 
            this.menuItem344.Index = 21;
            this.menuItem344.MergeOrder = 50319;
            this.menuItem344.Text = "Tạo cấu trúc cho các biểu mẫu mới";
            this.menuItem344.Visible = false;
            this.menuItem344.Click += new System.EventHandler(this.menuItem344_Click_1);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem106,
            this.menuItem107,
            this.menuItem270,
            this.menuItem181,
            this.menuItem182,
            this.menuItem183,
            this.menuItem184,
            this.menuItem29,
            this.menuItem185,
            this.menuItem186,
            this.menuItem187,
            this.menuItem188,
            this.menuItem215,
            this.menuItem189,
            this.menuItem190,
            this.menuItem211,
            this.menuItem212,
            this.m339,
            this.menuItem213,
            this.menuItem214,
            this.menuItem244,
            this.menuItem249,
            this.menuItem269,
            this.menuItem278,
            this.m327,
            this.m300,
            this.menuItem61,
            this.menuItem397});
            this.menuItem3.MergeOrder = 913;
            this.menuItem3.Text = "&Báo cáo";
            // 
            // menuItem106
            // 
            this.menuItem106.Index = 0;
            this.menuItem106.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem123,
            this.menuItem124,
            this.menuItem125,
            this.menuItem126,
            this.menuItem127,
            this.menuItem128,
            this.menuItem129,
            this.menuItem130,
            this.menuItem131,
            this.menuItem132,
            this.menuItem133,
            this.menuItem134,
            this.menuItem135,
            this.menuItem136,
            this.menuItem137,
            this.menuItem347,
            this.menuItem138,
            this.menuItem139});
            this.menuItem106.MergeOrder = 914;
            this.menuItem106.Text = "Vụ điều trị";
            // 
            // menuItem123
            // 
            this.menuItem123.Index = 0;
            this.menuItem123.MergeOrder = 160;
            this.menuItem123.Text = "Tình hình cán bộ, công chức, viên chức (Biểu 01-CCVC)";
            this.menuItem123.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem124
            // 
            this.menuItem124.Index = 1;
            this.menuItem124.MergeOrder = 161;
            this.menuItem124.Text = "Hoạt động khám bệnh (Biểu 02-KB)";
            this.menuItem124.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem125
            // 
            this.menuItem125.Index = 2;
            this.menuItem125.MergeOrder = 162;
            this.menuItem125.Text = "Hoạt động điều trị (Biểu 03.1-ĐT)";
            this.menuItem125.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem126
            // 
            this.menuItem126.Index = 3;
            this.menuItem126.MergeOrder = 163;
            this.menuItem126.Text = "Hoạt động phẩu thuật, thủ thuật (Biểu 04-PT/TT)";
            this.menuItem126.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem127
            // 
            this.menuItem127.Index = 4;
            this.menuItem127.MergeOrder = 164;
            this.menuItem127.Text = "Hoạt động sức khỏe sinh sản (Biểu 05-SKSS)";
            this.menuItem127.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem128
            // 
            this.menuItem128.Index = 5;
            this.menuItem128.MergeOrder = 165;
            this.menuItem128.Text = "Hoạt động cận lâm sàng (Biểu 06-CLS)";
            this.menuItem128.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem129
            // 
            this.menuItem129.Index = 6;
            this.menuItem129.MergeOrder = 166;
            this.menuItem129.Text = "Dược bệnh viện (Biểu 07-DBV)";
            this.menuItem129.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem130
            // 
            this.menuItem130.Index = 7;
            this.menuItem130.MergeOrder = 167;
            this.menuItem130.Text = "Trang thiết bị y tế (Biểu 08-TTB)";
            this.menuItem130.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem131
            // 
            this.menuItem131.Index = 8;
            this.menuItem131.MergeOrder = 168;
            this.menuItem131.Text = "Hoạt động chỉ đạo tuyến (Biểu 09.1-CĐT)";
            this.menuItem131.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem132
            // 
            this.menuItem132.Index = 9;
            this.menuItem132.MergeOrder = 169;
            this.menuItem132.Text = "Hoạt động nghiên cứu khoa học (Biểu 09.2-NCKH)";
            this.menuItem132.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem133
            // 
            this.menuItem133.Index = 10;
            this.menuItem133.MergeOrder = 170;
            this.menuItem133.Text = "Hoạt động tài chính (Biểu 10.1-TC)";
            this.menuItem133.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem134
            // 
            this.menuItem134.Index = 11;
            this.menuItem134.MergeOrder = 171;
            this.menuItem134.Text = "HĐTC - Chi tiết về thu viện phí,Bảo hiểm (Biểu 10.2.1-TCTVP/BH)";
            this.menuItem134.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem135
            // 
            this.menuItem135.Index = 12;
            this.menuItem135.MergeOrder = 172;
            this.menuItem135.Text = "HĐTC - Chi tiết về các khoản chi (Biểu 10.2.2-TCC)";
            this.menuItem135.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem136
            // 
            this.menuItem136.Index = 13;
            this.menuItem136.MergeOrder = 173;
            this.menuItem136.Text = "HĐTC - Các khoản không thu được (Biểu 10.3-TC/KT)";
            this.menuItem136.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem137
            // 
            this.menuItem137.Index = 14;
            this.menuItem137.MergeOrder = 174;
            this.menuItem137.Text = "Tình hình bệnh tật, tử vong tại bệnh viện (Biểu 11-BTTV)";
            this.menuItem137.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem347
            // 
            this.menuItem347.Index = 15;
            this.menuItem347.MergeOrder = 60116;
            this.menuItem347.Text = "Tình hình bệnh tật, tử vong tại bệnh viện (Biểu 11-BTTV) - 2010";
            this.menuItem347.Click += new System.EventHandler(this.menuItem347_Click_1);
            // 
            // menuItem138
            // 
            this.menuItem138.Index = 16;
            this.menuItem138.Text = "-";
            // 
            // menuItem139
            // 
            this.menuItem139.Index = 17;
            this.menuItem139.MergeOrder = 175;
            this.menuItem139.Text = "In trang bìa báo cáo";
            this.menuItem139.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem107
            // 
            this.menuItem107.Index = 1;
            this.menuItem107.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem86,
            this.menuItem87,
            this.menuItem88,
            this.menuItem140,
            this.menuItem141,
            this.menuItem142,
            this.menuItem143,
            this.menuItem144,
            this.menuItem145,
            this.menuItem146,
            this.menuItem147,
            this.menuItem148,
            this.menuItem149,
            this.menuItem150,
            this.menuItem81,
            this.menuItem151,
            this.menuItem152,
            this.menuItem153,
            this.menuItem154,
            this.menuItem155,
            this.menuItem156,
            this.menuItem157,
            this.menuItem158,
            this.menuItem159,
            this.menuItem160,
            this.menuItem167});
            this.menuItem107.MergeOrder = 915;
            this.menuItem107.Text = "Vụ kế hoạch";
            // 
            // menuItem86
            // 
            this.menuItem86.Index = 0;
            this.menuItem86.MergeOrder = 176;
            this.menuItem86.Text = "Biểu 01 - Dân số, đơn vị hành chính, trạm y tế xã";
            this.menuItem86.Click += new System.EventHandler(this.menuItem86_Click_1);
            // 
            // menuItem87
            // 
            this.menuItem87.Index = 1;
            this.menuItem87.MergeOrder = 177;
            this.menuItem87.Text = "Biểu 02 - Thông tin về sinh, tử";
            this.menuItem87.Click += new System.EventHandler(this.menuItem87_Click_1);
            // 
            // menuItem88
            // 
            this.menuItem88.Index = 2;
            this.menuItem88.MergeOrder = 178;
            this.menuItem88.Text = "Biểu 03 - Tình hình thu, chi ngân sách ngành y tế địa phương";
            this.menuItem88.Click += new System.EventHandler(this.menuItem88_Click_1);
            // 
            // menuItem140
            // 
            this.menuItem140.Index = 3;
            this.menuItem140.MergeOrder = 179;
            this.menuItem140.Text = "Biểu 04 - Tình hình thu, chi ngân sách của tuyến xã";
            this.menuItem140.Click += new System.EventHandler(this.menuItem140_Click);
            // 
            // menuItem141
            // 
            this.menuItem141.Index = 4;
            this.menuItem141.MergeOrder = 180;
            this.menuItem141.Text = "Biểu 05 - Tình hình cơ sở y tế và giường bệnh";
            this.menuItem141.Click += new System.EventHandler(this.menuItem141_Click);
            // 
            // menuItem142
            // 
            this.menuItem142.Index = 5;
            this.menuItem142.MergeOrder = 181;
            this.menuItem142.Text = "Biểu 06 - Tình hình nhân lực y tế toàn huyện";
            this.menuItem142.Click += new System.EventHandler(this.menuItem142_Click);
            // 
            // menuItem143
            // 
            this.menuItem143.Index = 6;
            this.menuItem143.MergeOrder = 182;
            this.menuItem143.Text = "Biểu 07 - Tình hình sản xuất kinh doanh dược của huyện";
            this.menuItem143.Click += new System.EventHandler(this.menuItem143_Click);
            // 
            // menuItem144
            // 
            this.menuItem144.Index = 7;
            this.menuItem144.MergeOrder = 183;
            this.menuItem144.Text = "Biểu 08 - Tình hình trang thiết bị y tế của địa phương";
            this.menuItem144.Click += new System.EventHandler(this.menuItem144_Click);
            // 
            // menuItem145
            // 
            this.menuItem145.Index = 8;
            this.menuItem145.MergeOrder = 184;
            this.menuItem145.Text = "Biểu 09 - Chăm sóc sức khỏe trẻ em";
            this.menuItem145.Click += new System.EventHandler(this.menuItem145_Click);
            // 
            // menuItem146
            // 
            this.menuItem146.Index = 9;
            this.menuItem146.MergeOrder = 185;
            this.menuItem146.Text = "Biểu 10 - Tình hình chăm sóc sức khỏe bà mẹ";
            this.menuItem146.Click += new System.EventHandler(this.menuItem146_Click);
            // 
            // menuItem147
            // 
            this.menuItem147.Index = 10;
            this.menuItem147.MergeOrder = 186;
            this.menuItem147.Text = "Biểu 11 - Thực hiện công tác kế hoạch hóa gia đình";
            this.menuItem147.Click += new System.EventHandler(this.menuItem147_Click);
            // 
            // menuItem148
            // 
            this.menuItem148.Index = 11;
            this.menuItem148.MergeOrder = 187;
            this.menuItem148.Text = "Biểu 12.1 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem148.Click += new System.EventHandler(this.menuItem148_Click);
            // 
            // menuItem149
            // 
            this.menuItem149.Index = 12;
            this.menuItem149.MergeOrder = 188;
            this.menuItem149.Text = "Biểu 12.2 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem149.Click += new System.EventHandler(this.menuItem149_Click);
            // 
            // menuItem150
            // 
            this.menuItem150.Index = 13;
            this.menuItem150.MergeOrder = 189;
            this.menuItem150.Text = "Biểu 12.3 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem150.Click += new System.EventHandler(this.menuItem150_Click);
            // 
            // menuItem81
            // 
            this.menuItem81.Index = 14;
            this.menuItem81.MergeOrder = 190;
            this.menuItem81.Text = "Biểu 12.4 - Công tác khám chữa bệnh và dịch vụ y tế";
            this.menuItem81.Click += new System.EventHandler(this.menuItem81_Click_1);
            // 
            // menuItem151
            // 
            this.menuItem151.Index = 15;
            this.menuItem151.MergeOrder = 191;
            this.menuItem151.Text = "Biểu 13.1 - Thực hiện công tác phòng bệnh";
            this.menuItem151.Click += new System.EventHandler(this.menuItem151_Click);
            // 
            // menuItem152
            // 
            this.menuItem152.Index = 16;
            this.menuItem152.MergeOrder = 192;
            this.menuItem152.Text = "Biểu 13.2 - Thực hiện công tác phòng bệnh";
            this.menuItem152.Click += new System.EventHandler(this.menuItem152_Click);
            // 
            // menuItem153
            // 
            this.menuItem153.Index = 17;
            this.menuItem153.MergeOrder = 193;
            this.menuItem153.Text = "Biểu 13.3 - Thực hiện công tác phòng bệnh";
            this.menuItem153.Click += new System.EventHandler(this.menuItem153_Click);
            // 
            // menuItem154
            // 
            this.menuItem154.Index = 18;
            this.menuItem154.MergeOrder = 194;
            this.menuItem154.Text = "Biểu 14.1 - Các bệnh lây và bệnh quan trọng";
            this.menuItem154.Click += new System.EventHandler(this.menuItem154_Click);
            // 
            // menuItem155
            // 
            this.menuItem155.Index = 19;
            this.menuItem155.MergeOrder = 195;
            this.menuItem155.Text = "Biểu 14.2 - Các bệnh lây và bệnh quan trọng";
            this.menuItem155.Click += new System.EventHandler(this.menuItem155_Click);
            // 
            // menuItem156
            // 
            this.menuItem156.Index = 20;
            this.menuItem156.MergeOrder = 196;
            this.menuItem156.Text = "Biểu 14.3 - Các bệnh lây và bệnh quan trọng";
            this.menuItem156.Click += new System.EventHandler(this.menuItem156_Click);
            // 
            // menuItem157
            // 
            this.menuItem157.Index = 21;
            this.menuItem157.MergeOrder = 197;
            this.menuItem157.Text = "Biểu 14.4 - Các bệnh lây và bệnh quan trọng";
            this.menuItem157.Click += new System.EventHandler(this.menuItem157_Click);
            // 
            // menuItem158
            // 
            this.menuItem158.Index = 22;
            this.menuItem158.MergeOrder = 198;
            this.menuItem158.Text = "Biểu 14.5 - Báo cáo thống kê tai nạn, thương tích";
            this.menuItem158.Click += new System.EventHandler(this.menuItem158_Click);
            // 
            // menuItem159
            // 
            this.menuItem159.Index = 23;
            this.menuItem159.MergeOrder = 199;
            this.menuItem159.Text = "Biểu 15 - Tình hình bệnh tật, tử vong tại bệnh viện";
            this.menuItem159.Click += new System.EventHandler(this.menuItem159_Click);
            // 
            // menuItem160
            // 
            this.menuItem160.Index = 24;
            this.menuItem160.Text = "-";
            // 
            // menuItem167
            // 
            this.menuItem167.Index = 25;
            this.menuItem167.MergeOrder = 200;
            this.menuItem167.Text = "In trang bìa báo cáo";
            this.menuItem167.Click += new System.EventHandler(this.menuItem167_Click);
            // 
            // menuItem270
            // 
            this.menuItem270.Index = 2;
            this.menuItem270.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem318,
            this.menuItem319,
            this.menuItem320,
            this.menuItem321,
            this.menuItem322,
            this.menuItem323,
            this.menuItem324,
            this.menuItem325,
            this.menuItem326,
            this.menuItem328,
            this.menuItem329,
            this.menuItem330,
            this.menuItem331,
            this.menuItem332,
            this.menuItem333,
            this.menuItem334,
            this.menuItem335,
            this.menuItem343,
            this.menuItem391,
            this.menuItem394,
            this.menuItem395,
            this.menuItem396});
            this.menuItem270.MergeOrder = 60300;
            this.menuItem270.Text = "Vụ kế hoạch (năm 2012)";
            // 
            // menuItem318
            // 
            this.menuItem318.Index = 0;
            this.menuItem318.MergeOrder = 60301;
            this.menuItem318.Text = "Biểu 01 - Dân số và đơn vị hành chính";
            this.menuItem318.Click += new System.EventHandler(this.menuItem318_Click);
            // 
            // menuItem319
            // 
            this.menuItem319.Index = 1;
            this.menuItem319.MergeOrder = 60302;
            this.menuItem319.Text = "Biểu 02 - Tình hình sinh tử trong tỉnh";
            this.menuItem319.Click += new System.EventHandler(this.menuItem319_Click_2);
            // 
            // menuItem320
            // 
            this.menuItem320.Index = 2;
            this.menuItem320.MergeOrder = 60303;
            this.menuItem320.Text = "Biểu 03 - Tình hình thu, chi ngân sách ngành y tế địa phương";
            this.menuItem320.Click += new System.EventHandler(this.menuItem320_Click);
            // 
            // menuItem321
            // 
            this.menuItem321.Index = 3;
            this.menuItem321.MergeOrder = 60304;
            this.menuItem321.Text = "Biểu 04a - Tình hình cơ sở y tế và giường bệnh";
            this.menuItem321.Click += new System.EventHandler(this.menuItem321_Click_2);
            // 
            // menuItem322
            // 
            this.menuItem322.Index = 4;
            this.menuItem322.MergeOrder = 60305;
            this.menuItem322.Text = "Biểu 04b - Tình hình y tế xã phường";
            this.menuItem322.Click += new System.EventHandler(this.menuItem322_Click);
            // 
            // menuItem323
            // 
            this.menuItem323.Index = 5;
            this.menuItem323.MergeOrder = 60306;
            this.menuItem323.Text = "Biểu 05 - Tình hình nhân lực y tế toàn tỉnh/thànhphố";
            this.menuItem323.Click += new System.EventHandler(this.menuItem323_Click_2);
            // 
            // menuItem324
            // 
            this.menuItem324.Index = 6;
            this.menuItem324.MergeOrder = 60307;
            this.menuItem324.Text = "Biểu 06 - Tình hình hoạt động BHYT";
            this.menuItem324.Click += new System.EventHandler(this.menuItem324_Click_2);
            // 
            // menuItem325
            // 
            this.menuItem325.Index = 7;
            this.menuItem325.MergeOrder = 60308;
            this.menuItem325.Text = "Biểu 07 - Tình hình sản xuất kinh doanh dược ";
            this.menuItem325.Click += new System.EventHandler(this.menuItem325_Click_2);
            // 
            // menuItem326
            // 
            this.menuItem326.Index = 8;
            this.menuItem326.MergeOrder = 60309;
            this.menuItem326.Text = "Biểu 08 - Tình hình đào tạo nhân lực y tế địa phương";
            this.menuItem326.Click += new System.EventHandler(this.menuItem326_Click_1);
            // 
            // menuItem328
            // 
            this.menuItem328.Index = 9;
            this.menuItem328.MergeOrder = 60310;
            this.menuItem328.Text = "Biểu 09 - Hoạt động chăm sóc bà mẹ";
            this.menuItem328.Click += new System.EventHandler(this.menuItem328_Click_1);
            // 
            // menuItem329
            // 
            this.menuItem329.Index = 10;
            this.menuItem329.MergeOrder = 60311;
            this.menuItem329.Text = "Biểu 10 - Tình hình mắc chết do tai biến sản khoa";
            this.menuItem329.Click += new System.EventHandler(this.menuItem329_Click_1);
            // 
            // menuItem330
            // 
            this.menuItem330.Index = 11;
            this.menuItem330.MergeOrder = 60312;
            this.menuItem330.Text = "Biểu 11 - Hoạt động khám chữa phụ khoa và nạo phá thai";
            this.menuItem330.Click += new System.EventHandler(this.menuItem330_Click_2);
            // 
            // menuItem331
            // 
            this.menuItem331.Index = 12;
            this.menuItem331.MergeOrder = 60313;
            this.menuItem331.Text = "Biểu 12 - Hoạt động cung cấp dịch vụ kế hoạch hóa gia đình";
            this.menuItem331.Click += new System.EventHandler(this.menuItem331_Click_1);
            // 
            // menuItem332
            // 
            this.menuItem332.Index = 13;
            this.menuItem332.MergeOrder = 60314;
            this.menuItem332.Text = "Biểu 13 - Tình hình sức khỏe trẻ em";
            this.menuItem332.Click += new System.EventHandler(this.menuItem332_Click_1);
            // 
            // menuItem333
            // 
            this.menuItem333.Index = 14;
            this.menuItem333.MergeOrder = 60315;
            this.menuItem333.Text = "Biểu 14 - Hoạt động tiêm chủng phòng 10 bệnh cho trẻ em";
            this.menuItem333.Click += new System.EventHandler(this.menuItem333_Click_1);
            // 
            // menuItem334
            // 
            this.menuItem334.Index = 15;
            this.menuItem334.MergeOrder = 60316;
            this.menuItem334.Text = "Biểu 15 - Tình hình mắc chết các bệnh có vắc xin phòng ngừa";
            this.menuItem334.Click += new System.EventHandler(this.menuItem334_Click_1);
            // 
            // menuItem335
            // 
            this.menuItem335.Index = 16;
            this.menuItem335.MergeOrder = 60317;
            this.menuItem335.Text = "Biểu 16.1 - Báo cáo hoạt động khám chữa bệnh";
            this.menuItem335.Click += new System.EventHandler(this.menuItem335_Click_1);
            // 
            // menuItem343
            // 
            this.menuItem343.Index = 17;
            this.menuItem343.MergeOrder = 60318;
            this.menuItem343.Text = "Biểu 16.2 - Hoạt động khám chữa bệnh (Tiếp)";
            this.menuItem343.Click += new System.EventHandler(this.menuItem343_Click_1);
            // 
            // menuItem391
            // 
            this.menuItem391.Index = 18;
            this.menuItem391.MergeOrder = 60319;
            this.menuItem391.Text = "Biểu 17 - Hoạt động phòng chống bệnh xã hội";
            this.menuItem391.Click += new System.EventHandler(this.menuItem391_Click);
            // 
            // menuItem394
            // 
            this.menuItem394.Index = 19;
            this.menuItem394.MergeOrder = 60320;
            this.menuItem394.Text = "Biểu 18 - Tình hình mắc chết bệnh truyền nhiễm gây dịch và bệnh quan trọng";
            this.menuItem394.Click += new System.EventHandler(this.menuItem394_Click);
            // 
            // menuItem395
            // 
            this.menuItem395.Index = 20;
            this.menuItem395.MergeOrder = 60321;
            this.menuItem395.Text = "Biểu 19 - Tình hình bệnh tật, tử vong tại bệnh viện theo ICD 10 - WHO";
            this.menuItem395.Click += new System.EventHandler(this.menuItem395_Click);
            // 
            // menuItem396
            // 
            this.menuItem396.Index = 21;
            this.menuItem396.MergeOrder = 60322;
            this.menuItem396.Text = "In trang bìa báo cáo";
            this.menuItem396.Click += new System.EventHandler(this.menuItem396_Click);
            // 
            // menuItem181
            // 
            this.menuItem181.Index = 3;
            this.menuItem181.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem191,
            this.menuItem192,
            this.menuItem193,
            this.menuItem194,
            this.menuItem195,
            this.menuItem196,
            this.menuItem97,
            this.menuItem199,
            this.menuItem197,
            this.menuItem198,
            this.menuItem200,
            this.menuItem8,
            this.menuItem250,
            this.menuItem256,
            this.menuItem50,
            this.m329,
            this.m330,
            this.menuItem349});
            this.menuItem181.MergeOrder = 916;
            this.menuItem181.Text = "Thống kê danh sách người bệnh";
            // 
            // menuItem191
            // 
            this.menuItem191.Index = 0;
            this.menuItem191.MergeOrder = 201;
            this.menuItem191.Text = "Hiện diện";
            this.menuItem191.Click += new System.EventHandler(this.menuItem101_Click);
            // 
            // menuItem192
            // 
            this.menuItem192.Index = 1;
            this.menuItem192.MergeOrder = 202;
            this.menuItem192.Text = "Nhập viện";
            this.menuItem192.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItem193
            // 
            this.menuItem193.Index = 2;
            this.menuItem193.MergeOrder = 203;
            this.menuItem193.Text = "Nhập khoa";
            this.menuItem193.Click += new System.EventHandler(this.menuItem32_Click);
            // 
            // menuItem194
            // 
            this.menuItem194.Index = 3;
            this.menuItem194.MergeOrder = 204;
            this.menuItem194.Text = "Xuất khoa";
            this.menuItem194.Click += new System.EventHandler(this.menuItem99_Click);
            // 
            // menuItem195
            // 
            this.menuItem195.Index = 4;
            this.menuItem195.MergeOrder = 205;
            this.menuItem195.Text = "Xuất viện";
            this.menuItem195.Click += new System.EventHandler(this.menuItem100_Click);
            // 
            // menuItem196
            // 
            this.menuItem196.Index = 5;
            this.menuItem196.MergeOrder = 206;
            this.menuItem196.Text = "Cơ quan y tế chuyển đến";
            this.menuItem196.Click += new System.EventHandler(this.menuItem196_Click);
            // 
            // menuItem97
            // 
            this.menuItem97.Index = 6;
            this.menuItem97.MergeOrder = 207;
            this.menuItem97.Text = "Chuyển viện";
            this.menuItem97.Click += new System.EventHandler(this.menuItem97_Click_1);
            // 
            // menuItem199
            // 
            this.menuItem199.Index = 7;
            this.menuItem199.MergeOrder = 208;
            this.menuItem199.Text = "Tử vong";
            this.menuItem199.Click += new System.EventHandler(this.menuItem170_Click_1);
            // 
            // menuItem197
            // 
            this.menuItem197.Index = 8;
            this.menuItem197.MergeOrder = 209;
            this.menuItem197.Text = "Trẻ sơ sinh";
            this.menuItem197.Click += new System.EventHandler(this.menuItem103_Click);
            // 
            // menuItem198
            // 
            this.menuItem198.Index = 9;
            this.menuItem198.MergeOrder = 210;
            this.menuItem198.Text = "Tai nạn thương tích";
            this.menuItem198.Click += new System.EventHandler(this.menuItem97_Click);
            // 
            // menuItem200
            // 
            this.menuItem200.Index = 10;
            this.menuItem200.MergeOrder = 211;
            this.menuItem200.Text = "Phỏng";
            this.menuItem200.Click += new System.EventHandler(this.menuItem200_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 11;
            this.menuItem8.MergeOrder = 212;
            this.menuItem8.Text = "Phẫu thuật - thủ thuật";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click_1);
            // 
            // menuItem250
            // 
            this.menuItem250.Index = 12;
            this.menuItem250.MergeOrder = 213;
            this.menuItem250.Text = "Nhập xuất viện";
            this.menuItem250.Click += new System.EventHandler(this.menuItem250_Click);
            // 
            // menuItem256
            // 
            this.menuItem256.Index = 13;
            this.menuItem256.MergeOrder = 214;
            this.menuItem256.Text = "Nhập xuất khoa";
            this.menuItem256.Click += new System.EventHandler(this.menuItem256_Click);
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 14;
            this.menuItem50.MergeOrder = 215;
            this.menuItem50.Text = "Nhập xuất khoa theo số lưu trữ";
            this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
            // 
            // m329
            // 
            this.m329.Index = 15;
            this.m329.MergeOrder = 329;
            this.m329.Text = "Sổ vào viện - ra viện - chuyển viện";
            this.m329.Click += new System.EventHandler(this.m329_Click);
            // 
            // m330
            // 
            this.m330.Index = 16;
            this.m330.MergeOrder = 330;
            this.m330.Text = "Sổ lưu trữ hồ sơ bệnh án";
            this.m330.Click += new System.EventHandler(this.m330_Click);
            // 
            // menuItem349
            // 
            this.menuItem349.Index = 17;
            this.menuItem349.MergeOrder = 60418;
            this.menuItem349.Text = "Danh sách tiêm chủng";
            this.menuItem349.Click += new System.EventHandler(this.menuItem349_Click);
            // 
            // menuItem182
            // 
            this.menuItem182.Index = 4;
            this.menuItem182.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem201,
            this.menuItem202});
            this.menuItem182.MergeOrder = 917;
            this.menuItem182.Text = "Truy vấn thông tin";
            // 
            // menuItem201
            // 
            this.menuItem201.Index = 0;
            this.menuItem201.MergeOrder = 216;
            this.menuItem201.Text = "Hồ sơ bệnh án";
            this.menuItem201.Click += new System.EventHandler(this.menuItem172_Click);
            // 
            // menuItem202
            // 
            this.menuItem202.Index = 1;
            this.menuItem202.MergeOrder = 217;
            this.menuItem202.Text = "Biểu thống kê";
            this.menuItem202.Click += new System.EventHandler(this.menuItem173_Click);
            // 
            // menuItem183
            // 
            this.menuItem183.Index = 5;
            this.menuItem183.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem203,
            this.menuItem204,
            this.m305});
            this.menuItem183.MergeOrder = 918;
            this.menuItem183.Text = "Bệnh nhiễm";
            // 
            // menuItem203
            // 
            this.menuItem203.Index = 0;
            this.menuItem203.MergeOrder = 218;
            this.menuItem203.Text = "Danh sách người bệnh";
            this.menuItem203.Click += new System.EventHandler(this.menuItem169_Click_1);
            // 
            // menuItem204
            // 
            this.menuItem204.Index = 1;
            this.menuItem204.MergeOrder = 219;
            this.menuItem204.Text = "Tổng hợp";
            this.menuItem204.Click += new System.EventHandler(this.menuItem175_Click);
            // 
            // m305
            // 
            this.m305.Index = 2;
            this.m305.MergeOrder = 305;
            this.m305.Text = "Danh sách theo loại";
            this.m305.Click += new System.EventHandler(this.m305_Click);
            // 
            // menuItem184
            // 
            this.menuItem184.Index = 6;
            this.menuItem184.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem205,
            this.menuItem206});
            this.menuItem184.MergeOrder = 919;
            this.menuItem184.Text = "Bệnh sốt xuất huyết";
            // 
            // menuItem205
            // 
            this.menuItem205.Index = 0;
            this.menuItem205.MergeOrder = 220;
            this.menuItem205.Text = "Danh sách người bệnh";
            this.menuItem205.Click += new System.EventHandler(this.menuItem205_Click);
            // 
            // menuItem206
            // 
            this.menuItem206.Index = 1;
            this.menuItem206.MergeOrder = 221;
            this.menuItem206.Text = "Tổng hợp";
            this.menuItem206.Click += new System.EventHandler(this.menuItem206_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 7;
            this.menuItem29.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem32,
            this.menuItem84});
            this.menuItem29.MergeOrder = 920;
            this.menuItem29.Text = "Bệnh viêm phổi";
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 0;
            this.menuItem32.MergeOrder = 222;
            this.menuItem32.Text = "Danh sách người bệnh";
            this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click_1);
            // 
            // menuItem84
            // 
            this.menuItem84.Index = 1;
            this.menuItem84.MergeOrder = 223;
            this.menuItem84.Text = "Tổng hợp";
            this.menuItem84.Click += new System.EventHandler(this.menuItem84_Click_1);
            // 
            // menuItem185
            // 
            this.menuItem185.Index = 8;
            this.menuItem185.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem207,
            this.menuItem208});
            this.menuItem185.MergeOrder = 921;
            this.menuItem185.Text = "Bệnh lây && các bệnh quan trọng";
            // 
            // menuItem207
            // 
            this.menuItem207.Index = 0;
            this.menuItem207.MergeOrder = 224;
            this.menuItem207.Text = "Danh sách bệnh nhân";
            this.menuItem207.Click += new System.EventHandler(this.menuItem207_Click);
            // 
            // menuItem208
            // 
            this.menuItem208.Index = 1;
            this.menuItem208.MergeOrder = 225;
            this.menuItem208.Text = "Tổng hợp";
            this.menuItem208.Click += new System.EventHandler(this.menuItem176_Click);
            // 
            // menuItem186
            // 
            this.menuItem186.Index = 9;
            this.menuItem186.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem209,
            this.menuItem210});
            this.menuItem186.MergeOrder = 922;
            this.menuItem186.Text = "ARI";
            // 
            // menuItem209
            // 
            this.menuItem209.Index = 0;
            this.menuItem209.MergeOrder = 226;
            this.menuItem209.Text = "Danh sách người bệnh";
            this.menuItem209.Click += new System.EventHandler(this.menuItem209_Click);
            // 
            // menuItem210
            // 
            this.menuItem210.Index = 1;
            this.menuItem210.MergeOrder = 227;
            this.menuItem210.Text = "Tổng hợp";
            this.menuItem210.Click += new System.EventHandler(this.menuItem210_Click);
            // 
            // menuItem187
            // 
            this.menuItem187.Index = 10;
            this.menuItem187.MergeOrder = 228;
            this.menuItem187.Text = "Tổng hợp tình hình người bệnh";
            this.menuItem187.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem188
            // 
            this.menuItem188.Index = 11;
            this.menuItem188.MergeOrder = 229;
            this.menuItem188.Text = "Thống kê điều trị nội trú";
            this.menuItem188.Click += new System.EventHandler(this.menuItem166_Click);
            // 
            // menuItem215
            // 
            this.menuItem215.Index = 12;
            this.menuItem215.MergeOrder = 230;
            this.menuItem215.Text = "Thống kê số liệu theo biểu đồ";
            this.menuItem215.Click += new System.EventHandler(this.menuItem161_Click_1);
            // 
            // menuItem189
            // 
            this.menuItem189.Index = 13;
            this.menuItem189.MergeOrder = 231;
            this.menuItem189.Text = "Tổng hợp theo mã ICD10";
            this.menuItem189.Click += new System.EventHandler(this.menuItem177_Click);
            // 
            // menuItem190
            // 
            this.menuItem190.Index = 14;
            this.menuItem190.MergeOrder = 232;
            this.menuItem190.Text = "Tổng hợp theo mã Phẫu thuật - thủ thuật";
            this.menuItem190.Click += new System.EventHandler(this.menuItem178_Click);
            // 
            // menuItem211
            // 
            this.menuItem211.Index = 15;
            this.menuItem211.MergeOrder = 233;
            this.menuItem211.Text = "Tổng hợp theo ngày điều trị";
            this.menuItem211.Click += new System.EventHandler(this.menuItem211_Click);
            // 
            // menuItem212
            // 
            this.menuItem212.Index = 16;
            this.menuItem212.MergeOrder = 234;
            this.menuItem212.Text = "Tổng hợp tình trạng ra viện";
            this.menuItem212.Click += new System.EventHandler(this.menuItem212_Click);
            // 
            // m339
            // 
            this.m339.Index = 17;
            this.m339.MergeOrder = 339;
            this.m339.Text = "Tổng hợp kết quả điều trị";
            this.m339.Click += new System.EventHandler(this.m339_Click);
            // 
            // menuItem213
            // 
            this.menuItem213.Index = 18;
            this.menuItem213.MergeOrder = 235;
            this.menuItem213.Text = "Tình hình mắc bệnh theo địa phương";
            this.menuItem213.Click += new System.EventHandler(this.menuItem213_Click);
            // 
            // menuItem214
            // 
            this.menuItem214.Index = 19;
            this.menuItem214.MergeOrder = 236;
            this.menuItem214.Text = "So sánh tình hình mắc bệnh theo năm";
            this.menuItem214.Click += new System.EventHandler(this.menuItem214_Click);
            // 
            // menuItem244
            // 
            this.menuItem244.Index = 20;
            this.menuItem244.MergeOrder = 237;
            this.menuItem244.Text = "Tình hình bệnh tật, tử vong tại khoa";
            this.menuItem244.Click += new System.EventHandler(this.menuItem244_Click);
            // 
            // menuItem249
            // 
            this.menuItem249.Index = 21;
            this.menuItem249.MergeOrder = 238;
            this.menuItem249.Text = "Hoạt động phẫu thuật, thủ thuật theo khoa";
            this.menuItem249.Click += new System.EventHandler(this.menuItem249_Click);
            // 
            // menuItem269
            // 
            this.menuItem269.Index = 22;
            this.menuItem269.MergeOrder = 239;
            this.menuItem269.Text = "Số bệnh án đã nhập kho";
            this.menuItem269.Click += new System.EventHandler(this.menuItem269_Click);
            // 
            // menuItem278
            // 
            this.menuItem278.Index = 23;
            this.menuItem278.MergeOrder = 240;
            this.menuItem278.Text = "Thống kê số liệu theo bản đồ";
            this.menuItem278.Click += new System.EventHandler(this.menuItem278_Click);
            // 
            // m327
            // 
            this.m327.Index = 24;
            this.m327.MergeOrder = 327;
            this.m327.Text = "Báo cáo tiền sử bệnh";
            this.m327.Click += new System.EventHandler(this.m327_Click);
            // 
            // m300
            // 
            this.m300.Index = 25;
            this.m300.MergeOrder = 300;
            this.m300.Text = "Báo cáo đặc thù";
            this.m300.Click += new System.EventHandler(this.m300_Click);
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 26;
            this.menuItem61.MergeOrder = 62700;
            this.menuItem61.Text = "Báo cáo tổng hợp";
            this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click_1);
            // 
            // menuItem397
            // 
            this.menuItem397.Index = 27;
            this.menuItem397.MergeOrder = 60323;
            this.menuItem397.Text = "Báo cáo phản ứng thuốc có hại";
            this.menuItem397.Click += new System.EventHandler(this.menuItem397_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem27,
            this.menuItem95,
            this.menuItem96,
            this.m325,
            this.m340,
            this.m328,
            this.menuItem_dmcn,
            this.m335,
            this.menuItem69,
            this.i315,
            this.mnuRight_Bv,
            this.menuItem31,
            this.m334,
            this.menuItem83,
            this.menuItem267,
            this.menuItem268,
            this.menuItem85,
            this.menuItem282,
            this.menuItem312,
            this.menuItem162,
            this.m336,
            this.menuItem179,
            this.menuItem338,
            this.menuItem51,
            this.menuItem413,
            this.menuItem327,
            this.menuItem405,
            this.menuItem165,
            this.m306,
            this.menuItem352,
            this.menuItem174,
            this.menuItem28,
            this.menuItem366,
            this.mnuNangchieudaikey,
            this.mnuChuyensolieu,
            this.menuItem59,
            this.menuItem60});
            this.menuItem4.MergeOrder = 923;
            this.menuItem4.Text = "&Tiện ích";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem42,
            this.menuItem43,
            this.menuItem44,
            this.menuItem47,
            this.menuItem48,
            this.menuItem49,
            this.menuItem45,
            this.menuItem53,
            this.menuItem54,
            this.m310,
            this.menuItem164,
            this.menuItem26,
            this.menuItem102,
            this.menuItem62,
            this.menuItem82,
            this.menuItem64,
            this.menuItem66,
            this.menuItem68,
            this.menuItem89,
            this.menuItem98,
            this.mnDmxutri,
            this.menuItem243,
            this.menuItem65,
            this.menuItem22,
            this.menuItem168,
            this.menuItem219,
            this.menuItem220,
            this.menuItem242,
            this.menuItem266,
            this.menuItem171,
            this.menuItem284,
            this.menuItem339,
            this.menuItem350,
            this.menuItem351,
            this.menuItem353,
            this.menuItem398,
            this.menuItem399,
            this.menuItem400,
            this.menuItem401,
            this.menuItem402,
            this.menuItem410});
            this.menuItem5.MergeOrder = 924;
            this.menuItem5.Text = "Danh mục";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 0;
            this.menuItem42.MergeOrder = 241;
            this.menuItem42.Text = "ICD10";
            this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 1;
            this.menuItem43.MergeOrder = 242;
            this.menuItem43.Text = "Phẩu thuật, thủ thuật";
            this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click);
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 2;
            this.menuItem44.MergeOrder = 243;
            this.menuItem44.Text = "Bệnh viện";
            this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 3;
            this.menuItem47.MergeOrder = 244;
            this.menuItem47.Text = "Tỉnh/Thành phố";
            this.menuItem47.Click += new System.EventHandler(this.menuItem47_Click);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 4;
            this.menuItem48.MergeOrder = 245;
            this.menuItem48.Text = "Quận/Huyện";
            this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 5;
            this.menuItem49.MergeOrder = 246;
            this.menuItem49.Text = "Phường xã";
            this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 6;
            this.menuItem45.MergeOrder = 247;
            this.menuItem45.Text = "Danh mục theo qui định Vụ Điều Trị";
            this.menuItem45.Click += new System.EventHandler(this.menuItem45_Click_1);
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 7;
            this.menuItem53.MergeOrder = 248;
            this.menuItem53.Text = "Biểu mẫu báo cáo";
            this.menuItem53.Click += new System.EventHandler(this.menuItem53_Click);
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 8;
            this.menuItem54.Text = "-";
            // 
            // m310
            // 
            this.m310.Index = 9;
            this.m310.MergeOrder = 310;
            this.m310.Text = "Khai báo ICD10";
            this.m310.Click += new System.EventHandler(this.menuItem61_Click);
            // 
            // menuItem164
            // 
            this.menuItem164.Index = 10;
            this.menuItem164.MergeOrder = 250;
            this.menuItem164.Text = "Khai báo phẫu thuật - thủ thuật";
            this.menuItem164.Click += new System.EventHandler(this.menuItem164_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 11;
            this.menuItem26.MergeOrder = 251;
            this.menuItem26.Text = "Khai báo cơ quan y tế chuyển đến";
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
            // 
            // menuItem102
            // 
            this.menuItem102.Index = 12;
            this.menuItem102.MergeOrder = 252;
            this.menuItem102.Text = "Khai báo nơi đăng ký KCB";
            this.menuItem102.Click += new System.EventHandler(this.menuItem102_Click_1);
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 13;
            this.menuItem62.MergeOrder = 253;
            this.menuItem62.Text = "Khai báo khoa";
            this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
            // 
            // menuItem82
            // 
            this.menuItem82.Index = 14;
            this.menuItem82.MergeOrder = 254;
            this.menuItem82.Text = "Khai báo phòng khám";
            this.menuItem82.Click += new System.EventHandler(this.menuItem82_Click_1);
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 15;
            this.menuItem64.MergeOrder = 255;
            this.menuItem64.Text = "Khai báo viết tắt";
            this.menuItem64.Click += new System.EventHandler(this.menuItem64_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 16;
            this.menuItem66.MergeOrder = 256;
            this.menuItem66.Text = "Khai báo phương pháp vô cảm";
            this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 17;
            this.menuItem68.MergeOrder = 257;
            this.menuItem68.Text = "Khai báo nhóm máu";
            this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
            // 
            // menuItem89
            // 
            this.menuItem89.Index = 18;
            this.menuItem89.MergeOrder = 258;
            this.menuItem89.Text = "Khai báo nghề nghiệp";
            this.menuItem89.Click += new System.EventHandler(this.menuItem89_Click);
            // 
            // menuItem98
            // 
            this.menuItem98.Index = 19;
            this.menuItem98.MergeOrder = 259;
            this.menuItem98.Text = "Khai báo bệnh án sử dụng";
            this.menuItem98.Click += new System.EventHandler(this.menuItem98_Click);
            // 
            // mnDmxutri
            // 
            this.mnDmxutri.Index = 20;
            this.mnDmxutri.MergeOrder = 260;
            this.mnDmxutri.Text = "Khai báo xử trí khám bệnh";
            this.mnDmxutri.Click += new System.EventHandler(this.menuItem217_Click);
            // 
            // menuItem243
            // 
            this.menuItem243.Index = 21;
            this.menuItem243.MergeOrder = 261;
            this.menuItem243.Text = "Khai báo đối tượng";
            this.menuItem243.Click += new System.EventHandler(this.menuItem243_Click);
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 22;
            this.menuItem65.MergeOrder = 262;
            this.menuItem65.Text = "Khai báo nhân viên";
            this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 23;
            this.menuItem22.MergeOrder = 263;
            this.menuItem22.Text = "Cơ sở y tế, Trạm y tế";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem168
            // 
            this.menuItem168.Index = 24;
            this.menuItem168.MergeOrder = 264;
            this.menuItem168.Text = "Cơ sở sản xuất kinh doanh";
            this.menuItem168.Click += new System.EventHandler(this.menuItem168_Click);
            // 
            // menuItem219
            // 
            this.menuItem219.Index = 25;
            this.menuItem219.MergeOrder = 265;
            this.menuItem219.Text = "Danh mục thuốc";
            this.menuItem219.Click += new System.EventHandler(this.menuItem219_Click);
            // 
            // menuItem220
            // 
            this.menuItem220.Index = 26;
            this.menuItem220.MergeOrder = 266;
            this.menuItem220.Text = "Danh mục cách dùng";
            this.menuItem220.Click += new System.EventHandler(this.menuItem220_Click);
            // 
            // menuItem242
            // 
            this.menuItem242.Index = 27;
            this.menuItem242.MergeOrder = 267;
            this.menuItem242.Text = "Danh mục ký giấy ra viện";
            this.menuItem242.Click += new System.EventHandler(this.menuItem242_Click);
            // 
            // menuItem266
            // 
            this.menuItem266.Index = 28;
            this.menuItem266.MergeOrder = 268;
            this.menuItem266.Text = "Khai báo phòng mỗ";
            this.menuItem266.Click += new System.EventHandler(this.menuItem266_Click);
            // 
            // menuItem171
            // 
            this.menuItem171.Index = 29;
            this.menuItem171.MergeOrder = 269;
            this.menuItem171.Text = "Khai báo đơn thuốc theo bác sỹ  && tên bệnh";
            this.menuItem171.Click += new System.EventHandler(this.menuItem171_Click);
            // 
            // menuItem284
            // 
            this.menuItem284.Index = 30;
            this.menuItem284.MergeOrder = 270;
            this.menuItem284.Text = "Danh mục thông tin sản khoa/sơ sinh";
            this.menuItem284.Click += new System.EventHandler(this.menuItem284_Click);
            // 
            // menuItem339
            // 
            this.menuItem339.Index = 31;
            this.menuItem339.MergeOrder = 271;
            this.menuItem339.Text = "Danh mục số thẻ bảo hiểm y tế";
            this.menuItem339.Click += new System.EventHandler(this.menuItem339_Click);
            // 
            // menuItem350
            // 
            this.menuItem350.Index = 32;
            this.menuItem350.MergeOrder = 2711;
            this.menuItem350.Text = "Danh mục phòng thực hiện cân lâm sàng";
            this.menuItem350.Click += new System.EventHandler(this.menuItem350_Click_1);
            // 
            // menuItem351
            // 
            this.menuItem351.Index = 33;
            this.menuItem351.MergeOrder = 70133;
            this.menuItem351.Text = "Danh mục lý do khám";
            this.menuItem351.Click += new System.EventHandler(this.menuItem351_Click_1);
            // 
            // menuItem353
            // 
            this.menuItem353.Index = 34;
            this.menuItem353.MergeOrder = 70134;
            this.menuItem353.Text = "Danh mục lý do đúng tuyến";
            this.menuItem353.Click += new System.EventHandler(this.menuItem353_Click_1);
            // 
            // menuItem398
            // 
            this.menuItem398.Index = 35;
            this.menuItem398.MergeOrder = 70135;
            this.menuItem398.Text = "Danh mục địa điểm";
            this.menuItem398.Click += new System.EventHandler(this.menuItem398_Click);
            // 
            // menuItem399
            // 
            this.menuItem399.Index = 36;
            this.menuItem399.MergeOrder = 70135;
            this.menuItem399.Text = "Danh mục bộ phận bị thương";
            this.menuItem399.Click += new System.EventHandler(this.menuItem399_Click);
            // 
            // menuItem400
            // 
            this.menuItem400.Index = 37;
            this.menuItem400.MergeOrder = 70136;
            this.menuItem400.Text = "Danh mục diễn biến sau TNTT";
            this.menuItem400.Click += new System.EventHandler(this.menuItem400_Click);
            // 
            // menuItem401
            // 
            this.menuItem401.Index = 38;
            this.menuItem401.MergeOrder = 70137;
            this.menuItem401.Text = "Danh mục nguyên nhân tai nạn";
            this.menuItem401.Click += new System.EventHandler(this.menuItem401_Click);
            // 
            // menuItem402
            // 
            this.menuItem402.Index = 39;
            this.menuItem402.MergeOrder = 70138;
            this.menuItem402.Text = "Danh mục xử trí sau tai nạn";
            this.menuItem402.Click += new System.EventHandler(this.menuItem402_Click);
            // 
            // menuItem410
            // 
            this.menuItem410.Index = 40;
            this.menuItem410.Text = "Danh mục bác sĩ giới thiệu";
            this.menuItem410.Click += new System.EventHandler(this.menuItem410_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 1;
            this.menuItem27.Text = "-";
            // 
            // menuItem95
            // 
            this.menuItem95.Index = 2;
            this.menuItem95.MergeOrder = 273;
            this.menuItem95.Text = "Kết xuất số liệu nộp Sở, Bộ Y tế";
            this.menuItem95.Click += new System.EventHandler(this.menuItem95_Click);
            // 
            // menuItem96
            // 
            this.menuItem96.Index = 3;
            this.menuItem96.Text = "-";
            // 
            // m325
            // 
            this.m325.Index = 4;
            this.m325.MergeOrder = 325;
            this.m325.Text = "Xem hồ sơ bệnh án";
            this.m325.Click += new System.EventHandler(this.m325_Click);
            // 
            // m340
            // 
            this.m340.Index = 5;
            this.m340.MergeOrder = 344;
            this.m340.Text = "Duyệt dịch vụ cận lâm sàng";
            this.m340.Click += new System.EventHandler(this.m340_Click);
            // 
            // m328
            // 
            this.m328.Index = 6;
            this.m328.MergeOrder = 328;
            this.m328.Text = "Thông tin SmartCard";
            this.m328.Click += new System.EventHandler(this.m328_Click);
            // 
            // menuItem_dmcn
            // 
            this.menuItem_dmcn.Index = 7;
            this.menuItem_dmcn.MergeOrder = 99999;
            this.menuItem_dmcn.Text = "Danh mục chi nhánh";
            this.menuItem_dmcn.Click += new System.EventHandler(this.menuItem_dmcn_Click);
            // 
            // m335
            // 
            this.m335.Index = 8;
            this.m335.MergeOrder = 335;
            this.m335.Text = "Hệ thống tin nhắn";
            this.m335.Click += new System.EventHandler(this.m335_Click);
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 9;
            this.menuItem69.MergeOrder = 274;
            this.menuItem69.Text = "Khai báo thông số hệ thống";
            this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click);
            // 
            // i315
            // 
            this.i315.Index = 10;
            this.i315.MergeOrder = 315;
            this.i315.Text = "Khai báo thông số ";
            this.i315.Click += new System.EventHandler(this.i315_Click);
            // 
            // mnuRight_Bv
            // 
            this.mnuRight_Bv.Index = 11;
            this.mnuRight_Bv.MergeOrder = 999;
            this.mnuRight_Bv.Text = "Phân quyền sử dụng theo bệnh viện sử dụng";
            this.mnuRight_Bv.Click += new System.EventHandler(this.mnuRight_Bv_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 12;
            this.menuItem31.MergeOrder = 275;
            this.menuItem31.Text = "Phân quyền sử dụng";
            this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
            // 
            // m334
            // 
            this.m334.Index = 13;
            this.m334.MergeOrder = 334;
            this.m334.Text = "Sửa mã thẻ && giá trị sử dụng";
            this.m334.Click += new System.EventHandler(this.menuItem28_Click_1);
            // 
            // menuItem83
            // 
            this.menuItem83.Index = 14;
            this.menuItem83.MergeOrder = 276;
            this.menuItem83.Text = "Sửa mã người bệnh";
            this.menuItem83.Click += new System.EventHandler(this.menuItem83_Click_1);
            // 
            // menuItem267
            // 
            this.menuItem267.Index = 15;
            this.menuItem267.MergeOrder = 277;
            this.menuItem267.Text = "Sửa thông tin hành chính người bệnh";
            this.menuItem267.Click += new System.EventHandler(this.menuItem267_Click);
            // 
            // menuItem268
            // 
            this.menuItem268.Index = 16;
            this.menuItem268.MergeOrder = 278;
            this.menuItem268.Text = "Sửa số liệu tỉnh/thành,quận/huyện,phường xã ...";
            this.menuItem268.Click += new System.EventHandler(this.menuItem268_Click);
            // 
            // menuItem85
            // 
            this.menuItem85.Index = 17;
            this.menuItem85.MergeOrder = 279;
            this.menuItem85.Text = "Xóa thông tin nhập sai từ hồ sơ bệnh án";
            this.menuItem85.Click += new System.EventHandler(this.menuItem85_Click_1);
            // 
            // menuItem282
            // 
            this.menuItem282.Index = 18;
            this.menuItem282.MergeOrder = 280;
            this.menuItem282.Text = "Hủy bỏ số liệu chuyển xuống viện phí";
            this.menuItem282.Click += new System.EventHandler(this.menuItem282_Click);
            // 
            // menuItem312
            // 
            this.menuItem312.Index = 19;
            this.menuItem312.MergeOrder = 281;
            this.menuItem312.Text = "Chỉnh sửa ngày nhập sai từ hồ sơ bệnh án";
            this.menuItem312.Click += new System.EventHandler(this.menuItem312_Click);
            // 
            // menuItem162
            // 
            this.menuItem162.Index = 20;
            this.menuItem162.MergeOrder = 282;
            this.menuItem162.Text = "Thay đổi mật khẩu";
            this.menuItem162.Click += new System.EventHandler(this.menuItem162_Click);
            // 
            // m336
            // 
            this.m336.Index = 21;
            this.m336.MergeOrder = 336;
            this.m336.Text = "Thay đổi mật khẩu bác sỹ";
            this.m336.Click += new System.EventHandler(this.m336_Click);
            // 
            // menuItem179
            // 
            this.menuItem179.Index = 22;
            this.menuItem179.MergeOrder = 283;
            this.menuItem179.Text = "Truy vấn thông tin theo người dùng";
            this.menuItem179.Click += new System.EventHandler(this.menuItem179_Click);
            // 
            // menuItem338
            // 
            this.menuItem338.Index = 23;
            this.menuItem338.MergeOrder = 284;
            this.menuItem338.Text = "Quản lý cơ sở dữ liệu";
            this.menuItem338.Click += new System.EventHandler(this.menuItem338_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 24;
            this.menuItem51.MergeOrder = 285;
            this.menuItem51.Text = "Sao lưu số liệu";
            this.menuItem51.Click += new System.EventHandler(this.menuItem51_Click);
            // 
            // menuItem413
            // 
            this.menuItem413.Index = 25;
            this.menuItem413.Text = "Update dữ liệu gốc";
            this.menuItem413.Click += new System.EventHandler(this.menuItem413_Click);
            // 
            // menuItem327
            // 
            this.menuItem327.Index = 26;
            this.menuItem327.MergeOrder = 286;
            this.menuItem327.Text = "Tạo lại số liệu tháng năm";
            this.menuItem327.Click += new System.EventHandler(this.menuItem327_Click_1);
            // 
            // menuItem405
            // 
            this.menuItem405.Index = 27;
            this.menuItem405.MergeOrder = 2861;
            this.menuItem405.Text = "Tạo cấu trúc dữ liệu tháng mới";
            this.menuItem405.Click += new System.EventHandler(this.menuItem405_Click);
            // 
            // menuItem165
            // 
            this.menuItem165.Index = 28;
            this.menuItem165.MergeOrder = 287;
            this.menuItem165.Text = "Nhật ký người dùng";
            this.menuItem165.Click += new System.EventHandler(this.menuItem165_Click);
            // 
            // m306
            // 
            this.m306.Index = 29;
            this.m306.MergeOrder = 306;
            this.m306.Text = "Chỉnh sửa ICD10";
            this.m306.Click += new System.EventHandler(this.menuItem366_Click);
            // 
            // menuItem352
            // 
            this.menuItem352.Index = 30;
            this.menuItem352.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem363,
            this.menuItem362,
            this.menuItem361,
            this.menuItem364,
            this.menuItem63,
            this.menuItem100,
            this.menuItem101,
            this.menuItem253,
            this.menuItem277,
            this.menuItem368,
            this.m312,
            this.m313,
            this.m314,
            this.m318,
            this.m319,
            this.m326,
            this.m333,
            this.m346,
            this.m347,
            this.menuItem354,
            this.menuItem371,
            this.menuItem387,
            this.menuItem372,
            this.menuItem373,
            this.menuItem375});
            this.menuItem352.MergeOrder = 925;
            this.menuItem352.Text = "Khác";
            // 
            // menuItem363
            // 
            this.menuItem363.Index = 0;
            this.menuItem363.MergeOrder = 288;
            this.menuItem363.Text = "Loại phòng";
            this.menuItem363.Click += new System.EventHandler(this.menuItem363_Click);
            // 
            // menuItem362
            // 
            this.menuItem362.Index = 1;
            this.menuItem362.MergeOrder = 289;
            this.menuItem362.Text = "Phòng";
            this.menuItem362.Click += new System.EventHandler(this.menuItem362_Click);
            // 
            // menuItem361
            // 
            this.menuItem361.Index = 2;
            this.menuItem361.MergeOrder = 290;
            this.menuItem361.Text = "Giường";
            this.menuItem361.Click += new System.EventHandler(this.menuItem361_Click);
            // 
            // menuItem364
            // 
            this.menuItem364.Index = 3;
            this.menuItem364.Text = "-";
            // 
            // menuItem63
            // 
            this.menuItem63.Index = 4;
            this.menuItem63.MergeOrder = 291;
            this.menuItem63.Text = "Kết xuất thông tin lỗi của hệ thống";
            this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click);
            // 
            // menuItem100
            // 
            this.menuItem100.Index = 5;
            this.menuItem100.MergeOrder = 292;
            this.menuItem100.Text = "Gửi thông tin qua mạng nội bộ";
            this.menuItem100.Click += new System.EventHandler(this.menuItem100_Click_1);
            // 
            // menuItem101
            // 
            this.menuItem101.Index = 6;
            this.menuItem101.MergeOrder = 293;
            this.menuItem101.Text = "Đăng ký các thư viện Windows";
            this.menuItem101.Click += new System.EventHandler(this.menuItem101_Click_1);
            // 
            // menuItem253
            // 
            this.menuItem253.Index = 7;
            this.menuItem253.MergeOrder = 294;
            this.menuItem253.Text = "Thông báo qua mạng nội bộ";
            this.menuItem253.Click += new System.EventHandler(this.menuItem253_Click);
            // 
            // menuItem277
            // 
            this.menuItem277.Index = 8;
            this.menuItem277.MergeOrder = 298;
            this.menuItem277.Text = "Cập nhật ICD10";
            this.menuItem277.Click += new System.EventHandler(this.menuItem277_Click);
            // 
            // menuItem368
            // 
            this.menuItem368.Index = 9;
            this.menuItem368.Text = "-";
            // 
            // m312
            // 
            this.m312.Index = 10;
            this.m312.MergeOrder = 312;
            this.m312.Text = "Phân loại triệu chứng lâm sàng";
            this.m312.Click += new System.EventHandler(this.m312_Click);
            // 
            // m313
            // 
            this.m313.Index = 11;
            this.m313.MergeOrder = 313;
            this.m313.Text = "Triệu chứng lâm sàng";
            this.m313.Click += new System.EventHandler(this.m313_Click);
            // 
            // m314
            // 
            this.m314.Index = 12;
            this.m314.MergeOrder = 314;
            this.m314.Text = "Danh mục";
            this.m314.Click += new System.EventHandler(this.m314_Click);
            // 
            // m318
            // 
            this.m318.Index = 13;
            this.m318.MergeOrder = 318;
            this.m318.Text = "Danh mục đơn vị đăng ký khám sức khỏe";
            this.m318.Click += new System.EventHandler(this.m318_Click);
            // 
            // m319
            // 
            this.m319.Index = 14;
            this.m319.MergeOrder = 319;
            this.m319.Text = "Giá trị mặc nhiên khám sức khỏe";
            this.m319.Click += new System.EventHandler(this.m319_Click);
            // 
            // m326
            // 
            this.m326.Index = 15;
            this.m326.MergeOrder = 326;
            this.m326.Text = "Danh mục theo dõi tiền sử bệnh";
            this.m326.Click += new System.EventHandler(this.m326_Click);
            // 
            // m333
            // 
            this.m333.Index = 16;
            this.m333.MergeOrder = 333;
            this.m333.Text = "Chuyển danh mục số thẻ bảo hiểm";
            this.m333.Click += new System.EventHandler(this.m333_Click);
            // 
            // m346
            // 
            this.m346.Index = 17;
            this.m346.MergeOrder = 346;
            this.m346.Text = "Danh mục bấm huyệt";
            this.m346.Click += new System.EventHandler(this.m346_Click);
            // 
            // m347
            // 
            this.m347.Index = 18;
            this.m347.MergeOrder = 347;
            this.m347.Text = "Lịch bác sỹ nghỉ";
            this.m347.Click += new System.EventHandler(this.m347_Click);
            // 
            // menuItem354
            // 
            this.menuItem354.Index = 19;
            this.menuItem354.MergeOrder = 72718;
            this.menuItem354.Text = "Dấu sinh tồn giá trị mặc định";
            this.menuItem354.Click += new System.EventHandler(this.menuItem354_Click_1);
            // 
            // menuItem371
            // 
            this.menuItem371.Index = 20;
            this.menuItem371.MergeOrder = 72719;
            this.menuItem371.Text = "Danh mục loại thẻ BHYT";
            this.menuItem371.Click += new System.EventHandler(this.menuItem371_Click);
            // 
            // menuItem387
            // 
            this.menuItem387.Index = 21;
            this.menuItem387.MergeOrder = 10407;
            this.menuItem387.Text = "Danh mục loại thẻ BHYT chính sách";
            this.menuItem387.Click += new System.EventHandler(this.menuItem387_Click);
            // 
            // menuItem372
            // 
            this.menuItem372.Index = 22;
            this.menuItem372.MergeOrder = 72720;
            this.menuItem372.Text = "Khai báo tỷ lệ giảm theo loại thẻ BHYT";
            this.menuItem372.Click += new System.EventHandler(this.menuItem372_Click);
            // 
            // menuItem373
            // 
            this.menuItem373.Index = 23;
            this.menuItem373.MergeOrder = 72721;
            this.menuItem373.Text = "Giá trị mặc nhiên bệnh án điện tử";
            this.menuItem373.Click += new System.EventHandler(this.menuItem373_Click);
            // 
            // menuItem375
            // 
            this.menuItem375.Index = 24;
            this.menuItem375.MergeOrder = 72722;
            this.menuItem375.Text = "Khai báo thời gian làm việc";
            this.menuItem375.Click += new System.EventHandler(this.menuItem375_Click);
            // 
            // menuItem174
            // 
            this.menuItem174.Index = 31;
            this.menuItem174.MergeOrder = 72700;
            this.menuItem174.Text = "Từ chối nhập viện";
            this.menuItem174.Click += new System.EventHandler(this.menuItem174_Click_2);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 32;
            this.menuItem28.MergeOrder = 62800;
            this.menuItem28.Text = "Xem lỗi phát sinh";
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click_4);
            // 
            // menuItem366
            // 
            this.menuItem366.Index = 33;
            this.menuItem366.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem369,
            this.menuItem370});
            this.menuItem366.MergeOrder = 62900;
            this.menuItem366.Text = "Thẻ ưu đãi";
            // 
            // menuItem369
            // 
            this.menuItem369.Index = 0;
            this.menuItem369.MergeOrder = 62901;
            this.menuItem369.Text = "Cấp thẻ ưu đãi";
            this.menuItem369.Click += new System.EventHandler(this.menuItem369_Click);
            // 
            // menuItem370
            // 
            this.menuItem370.Index = 1;
            this.menuItem370.MergeOrder = 62902;
            this.menuItem370.Text = "Danh mục loại thẻ ưu đãi";
            this.menuItem370.Click += new System.EventHandler(this.menuItem370_Click);
            // 
            // mnuNangchieudaikey
            // 
            this.mnuNangchieudaikey.Index = 34;
            this.mnuNangchieudaikey.MergeOrder = 630;
            this.mnuNangchieudaikey.Text = "Nâng cấp chiều dài key";
            this.mnuNangchieudaikey.Click += new System.EventHandler(this.mnuNangchieudaikey_Click);
            // 
            // mnuChuyensolieu
            // 
            this.mnuChuyensolieu.Index = 35;
            this.mnuChuyensolieu.MergeOrder = 28;
            this.mnuChuyensolieu.Text = "Chuyển số liệu sang chi nhánh khác";
            this.mnuChuyensolieu.Click += new System.EventHandler(this.mnuChuyensolieu_Click);
            // 
            // menuItem59
            // 
            this.menuItem59.Index = 36;
            this.menuItem59.Text = "-";
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 37;
            this.menuItem60.MergeOrder = 299;
            this.menuItem60.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem60.Text = "Log Off ...";
            this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 7;
            this.menuItem55.MdiList = true;
            this.menuItem55.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem56,
            this.menuItem57,
            this.menuItem58});
            this.menuItem55.Text = "&A. Cửa sổ";
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 0;
            this.menuItem56.Text = "&1. Hiện thị cửa sổ theo chiều dọc";
            this.menuItem56.Click += new System.EventHandler(this.menuItem56_Click);
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 1;
            this.menuItem57.Text = "&2. Hiện thị cửa sổ theo chiều ngang";
            this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
            // 
            // menuItem58
            // 
            this.menuItem58.Index = 2;
            this.menuItem58.Text = "&3. Đóng tất cả cửa sổ";
            this.menuItem58.Click += new System.EventHandler(this.menuItem58_Click);
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 8;
            this.menuItem36.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem37,
            this.menuItem38,
            this.menuItem39});
            this.menuItem36.Text = "&B. Hướng dẫn";
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 0;
            this.menuItem37.Text = "&1. Hướng dẫn sử dụng";
            this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 1;
            this.menuItem38.Text = "-";
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 2;
            this.menuItem39.Text = "&2. About";
            this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 9;
            this.mnuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.mnuExit.Text = "&C. Kết thúc";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(846, 0);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

		}
		#endregion

        
		private void frmMain_Load(object sender, System.EventArgs e)
		{
            
            int i = m.check_process("MEDISOFT"), iProcess = m.soprocess;
            if (i > iProcess)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số chương trình kích hoạt : " + i.ToString() + " nhiều hơn cho phép :" + iProcess.ToString()));
                Application.Exit();
            }
			Splasher.Show();
            Splasher.Status = "Connecting to PostgreSQL Database Server ";
            this.Text = this.Text + " - Version: " + ProductVersion;
            try
            {
                ds = m.get_data("select * from " + m.user + ".dlogin where id=0");
            }
            catch { MessageBox.Show(lan.Change_language_MessageText("Không kết nối được Server !"), LibMedi.AccessData.Msg); Application.Exit(); }
			System.Threading.Thread.Sleep(1000);//2350
			Splasher.Close();
            //18.10.2013
            try
            {
                if (!Directory.Exists("temp"))
                {
                    Directory.CreateDirectory("temp");
                }
                else
                {
                    foreach (string _file in Directory.GetFiles("temp"))
                        File.Delete(_file);
                }
            }
            catch { }
            if (__userid != "")
            {
                try
                {
                    string sql = "select * from " + m.user + ".dlogin where id=" + __userid + "";
                    ds = m.get_data(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        s_right = ds.Tables[0].Rows[0]["right_"].ToString();
                        s_makp = ds.Tables[0].Rows[0]["makp"].ToString();
                        s_userid = ds.Tables[0].Rows[0]["hoten"].ToString();
                        i_userid = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                        s_madoituong = ds.Tables[0].Rows[0]["madoituong"].ToString();
                        s_nhomkho = ds.Tables[0].Rows[0]["nhomkho"].ToString();
                        s_cls = ds.Tables[0].Rows[0]["cls"].ToString();
                        s_mabs = ds.Tables[0].Rows[0]["mabs"].ToString();
                        s_may = ds.Tables[0].Rows[0]["may"].ToString();
                        //Tu:20/05/2011
                        s_khudt = ds.Tables[0].Rows[0]["khu"].ToString();
                        i_chinhanh = int.Parse(ds.Tables[0].Rows[0]["chinhanh"].ToString());
                        //_machuyenkhoa = ds.Tables[0].Rows[0]["khamchuyenkhoa"].ToString();
                        b_admin = m.bAdmin(i_userid);

                    }
                }
                catch
                {
                }
            }
            //18.10.2013
            if (i_userid == 0)
            {
                frmLogin f = new frmLogin(m);
                f.ShowDialog();
                if (f.mExit)
                {
                    Application.Exit();
                    return;
                }
                if (f.mUserid != "")
                {
                    s_userid = f.mUserid;
                    s_right = f.mRight;
                    s_makp = f.mMakp;
                    i_userid = f.iUserid;
                    i_mabv = f.iMabv;
                    s_madoituong = f.mMadoituong;
                    s_nhomkho = f.mNhomkho;
                    s_cls = f.mCls;
                    s_mabs = f.mMabs;
                    s_may = f.mMay;
                    b_admin = m.bAdmin(i_userid);
                    //
                    if (m.bQuanly_theokhu) f_get_khudieutri();
                    //
                    //Tu:21/05/2011
                    i_chinhanh = f.i_chinhanh;
                    //end Tu
                }
                else Application.Exit();
            }
			b_sovaovien=m.bSovaovien;
			
            
            
            
            
            
            
            
            
            b_soluutru=m.bSoluutru;
			gan_right();
            //f_capnhap_length_id();//tang id len chieu dai 22 ky tu so
		}
        private void gan_right()
        {
            int n = 0, t = 0;
            bool bx = false;
            string[] arRight = s_right.Split('+');
            for (int i = 0; i < this.mainMenu1.MenuItems.Count - 3; i++)
            {
                bx = false;
                for (int j = 0; j < this.mainMenu1.MenuItems[i].MenuItems.Count; j++)
                {

                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems.Count == 0)
                    {
                        //if (j == 28) j = 28;
                        if (this.mainMenu1.MenuItems[i].MenuItems[j].Text != "-")
                        {
                            //
                            foreach (string s_tmp in arRight)
                            {
                                this.mainMenu1.MenuItems[i].MenuItems[j].Visible = this.mainMenu1.MenuItems[i].MenuItems[j].MergeOrder.ToString().PadLeft(3, '0') == s_tmp;
                                if (this.mainMenu1.MenuItems[i].MenuItems[j].Visible)
                                    break;
                            }
                            //Thuy 11.03.2013 menu a có index=301, menu b có index=50301==> tuy 301 ko phan quyen nhung khi đọc lên 50301+ thấy 301+ nên vẫn thấy menu 301
                            //this.mainMenu1.MenuItems[i].MenuItems[j].Visible = s_right.IndexOf(this.mainMenu1.MenuItems[i].MenuItems[j].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1;-->lỗi
                            if (!bx)
                                bx = this.mainMenu1.MenuItems[i].MenuItems[j].Visible;
                        }
                        else
                        {
                            this.mainMenu1.MenuItems[i].MenuItems[j].Visible = false;
                        }
                    }
                    else
                    {
                        n = 0;
                        for (int k = 0; k < this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems.Count; k++)
                        {
                            if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count == 0)
                            {
                                if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Text != "-")
                                {
                                    //
                                    foreach (string s_tmp in arRight)
                                    {
                                        this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MergeOrder.ToString().PadLeft(3, '0') == s_tmp;
                                        if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible)
                                            break;
                                    }
                                    //this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = s_right.IndexOf(this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1;->Lỗi
                                }
                                else this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = false;
                                n += (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible) ? 1 : 0;

                            }
                            else
                            {
                                t = 0;
                                for (int s = 0; s < this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count; s++)
                                {
                                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Text != "-")
                                    {
                                        //
                                        foreach (string s_tmp in arRight)
                                        {
                                            this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Visible = this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].MergeOrder.ToString().PadLeft(3, '0') == s_tmp;
                                            if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible)
                                                break;
                                        }
                                        //this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Visible = s_right.IndexOf(this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1; ->Lỗi
                                    }
                                    else this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Visible = false;
                                    t += (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Visible) ? 1 : 0;
                                }
                                this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = n != 0;

                            }
                        }
                        this.mainMenu1.MenuItems[i].MenuItems[j].Visible = n != 0;
                        if (!bx)
                            bx = (n != 0) ? true : false;
                    }
                    this.mainMenu1.MenuItems[i].Visible = bx;

                }
            }
            this.menuItem4.Visible = true;
            this.menuItem59.Visible = true;
            this.menuItem60.Text = "Log Off ";// +s_userid.ToString().Trim();
            this.menuItem60.Visible = true;
            this.menuItem63.Visible = true;
            this.menuItem101.Visible = true;
            this.menuItem253.Visible = true;
            if (m340.Visible && !m.bDuyetcls) m340.Visible = false;
            if (m.Matuyen(m.Mabv) != "4")
            {
                this.menuItem2.Visible = false;
                this.menuItem86.Visible = false;
            }
            if (this.menuItem163.Visible) this.menuItem163.Visible = m.Kiemtra_loaiba(3);
            if (this.menuItem24.Visible) this.menuItem24.Visible = m.Kiemtra_loaiba(3);
            if (this.menuItem25.Visible) this.menuItem25.Visible = m.Kiemtra_loaiba(2);
            this.i315.Text = "Khai báo thông số máy " + Environment.UserName.ToString();
            this.m336.Visible = s_mabs != "";
            if (m.bAdminHethong(i_userid)) menuItem28.Visible = true;
            if (m.bPhonggiuong == false)
            {
                menuItem365.Visible = false;
                menuItem345.Visible = false;
            }
            if (s_userid == LibMedi.AccessData.links_userid + LibMedi.AccessData.links_pass)
            {
                this.menuItem4.Visible = true;
                this.mnuRight_Bv.Visible = true;
                this.menuItem31.Visible = true;
                this.menuItem65.Visible = true;
                this.menuItem277.Visible = true;
                this.menuItem69.Visible = true;
                this.menuItem_dmcn.Visible = true;
                this.menuItem5.Visible = true;
                this.mnDmxutri.Visible = true;
                this.menuItem327.Visible = true;
                this.mnuNangchieudaikey.Visible = true;
                this.menuItem60.Text = "Log Off Toàn cầu";
            }
            else
            {
                this.mnuNangchieudaikey.Visible = false;
                this.menuItem277.Visible = false;
                this.menuItem_dmcn.Visible = false;
            
            
            
            
            }
        }
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
            if (MessageBox.Show (lan.Change_language_MessageText("Bạn có muốn kết thúc không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                if (m.bSaoluu && this.menuItem51.Enabled)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn sao lưu số liệu không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        frmThumuc f = new frmThumuc(m.get_data("select ten from " + m.user + ".thongso where id=9").Tables[0].Rows[0][0].ToString(), "Chọn thư mục sao lưu số liệu", 1);
                        f.ShowDialog(this);
                    }
                }
                Application.Exit();
            }
		}

		private void menuItem58_Click(object sender, System.EventArgs e)
		{
			Form[] charr= this.MdiChildren;  
			foreach (Form chform in charr) chform.Close();
		}

		private void menuItem56_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
		}

		private void menuItem57_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
		}

		private void menuItem39_Click(object sender, System.EventArgs e)
		{
            frmAbout f = new frmAbout("medisoft",f_get_menu());
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem69_Click(object sender, System.EventArgs e)
        {
            frmThongso f = new frmThongso(m, i_userid, s_userid == LibMedi.AccessData.links_userid + LibMedi.AccessData.links_pass);
            f.ShowDialog();
            b_soluutru = m.bSoluutru;
            b_sovaovien = m.bSovaovien;
            
        }

        private void menuItem60_Click(object sender, System.EventArgs e)
        {
            menuItem58_Click(sender, e);
            frmLogin f = new frmLogin(m);
            f.ShowDialog(this);
            if (f.mUserid != "")
            {
                s_userid = f.mUserid;
                s_right = f.mRight;
                s_makp = f.mMakp;
                i_userid = f.iUserid;
                i_mabv = f.iMabv;
                s_madoituong = f.mMadoituong;
                s_nhomkho = f.mNhomkho;
                s_cls = f.mCls;
                s_mabs = f.mMabs;
                s_may = f.mMay;
                b_admin = m.bAdmin(i_userid);
                //
                if (m.bQuanly_theokhu) f_get_khudieutri();
                //
                //Tu:21/05/2011
                i_chinhanh = f.i_chinhanh;
                //end Tu
            }
            else Application.Exit();
            gan_right();
        }

		private void menuItem34_Click(object sender, System.EventArgs e)
		{
            if (IsLoaded("frmNhapkhoa")) return;
            string makp = s_makp;
            if (makp == "")
            {
                frmChonkhoa f1 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh);
                f1.ShowDialog();
                makp = f1.m_makp;
            }
            else
            {
                string sql = "select * from " + m.user + ".btdkp_bv where loai=0 ";
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                DataTable dt = m.get_data(sql).Tables[0];
                if (dt.Rows.Count == 0) return;
                else if (dt.Rows.Count == 1) makp = dt.Rows[0]["makp"].ToString();
                else
                {
                    frmChonkhoa f2 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh );
                    f2.ShowDialog();
                    makp = f2.m_makp;
                }
            }
            if (makp == "") return;
            frmNhapkhoa f = new frmNhapkhoa(m, makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, i_khudt, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem41_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXuatvien")) return;
            frmXuatvien f = new frmXuatvien(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem70_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu01")) return;
            frmBieu01 f = new frmBieu01(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem44_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmTenvien f = new dllDanhmucMedisoft.frmTenvien(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem42_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", "", "", false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem43_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, "", "", false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem47_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdtt f = new dllDanhmucMedisoft.frmBtdtt(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem91_Click(object sender, System.EventArgs e)
        {
            frmTkvaovien f = new frmTkvaovien(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem92_Click(object sender, System.EventArgs e)
        {
            frmTkvaokhoa f = new frmTkvaokhoa(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem93_Click(object sender, System.EventArgs e)
        {
            frmTkrakhoa f = new frmTkrakhoa(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem94_Click(object sender, System.EventArgs e)
        {
            frmTkravien f = new frmTkravien(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem65_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmbs f = new dllDanhmucMedisoft.frmDmbs(m, s_userid, i_userid,i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem89_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdnn f = new dllDanhmucMedisoft.frmBtdnn(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem62_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdkp f = new dllDanhmucMedisoft.frmBtdkp(m, i_userid, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem64_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdvt f = new dllDanhmucMedisoft.frmBtdvt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem98_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmbenhan f = new dllDanhmucMedisoft.frmDmbenhan(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem96_Click(object sender, System.EventArgs e)
        {
            frmTkpttt f = new frmTkpttt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem25_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNgoaitru") || IsLoaded("frmHSBenhan_NTRHM") || IsLoaded("frmHSBenhan_NTTMH") || IsLoaded("frmHSBenhan_NGTMat") || IsLoaded("frmHSBenhan_NT")) return;
            int songaydtngoaitru = m.songaydtngoaitru, iNgoaitru_taikham = m.iBenhanngtr_taikham;
            string user = m.user, sql,ngayra,s="";
            if (s_makp != "") s = s_makp.Replace(",", "','");
            DataSet ds1;
            if (songaydtngoaitru != 0)
            {
                bool bHiendanhsach_vuotngoaitru = m.bHiendanhsach_vuotngoaitru;
                sql = "select c.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
                sql += " b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,";
                sql += "date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1) as ngaydt,";
                sql += "a.maql,a.mabs,a.chandoan,a.maicd,a.bienchung,a.taibien,a.giaiphau,a.soluutru";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn";
                sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp";
                sql += " where a.ttlucrv=0 and a.ngayrv is null";
                if (s != "") sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                sql += " and date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1)>" + songaydtngoaitru;
                sql += " order by a.makp,a.ngay desc";
                ds1 = new DataSet();
                ds1 = m.get_data(sql);
                if (!bHiendanhsach_vuotngoaitru)
                {
                    foreach (DataRow r in ds1.Tables[0].Rows)
                    {
                        ngayra = m.DateToString("dd/MM/yyyy HH:mm", m.StringToDateTime(r["ngay"].ToString()).AddDays(songaydtngoaitru - 1));
                        m.upd_benhanngtr(decimal.Parse(r["maql"].ToString()), ngayra,3,3,r["chandoan"].ToString(),r["maicd"].ToString(),r["mabs"].ToString(),int.Parse(r["bienchung"].ToString()),int.Parse(r["taibien"].ToString()),int.Parse(r["giaiphau"].ToString()),r["soluutru"].ToString());
                    }
                }
                else 
                {
                    frmHiendienngtr f1 = new frmHiendienngtr(m, s_makp, songaydtngoaitru, ds1);
                    f1.ShowDialog();
                }
            }
            if (iNgoaitru_taikham != 0)
            {
                sql = "select c.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
                sql += " b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,";
                sql += "date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1) as ngaydt,";
                sql += "a.maql,a.mabs,a.chandoan,a.maicd,a.bienchung,a.taibien,a.giaiphau,a.soluutru,b.nam";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn";
                sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp";
                sql += " where a.ttlucrv=0 and a.ngayrv is null";
                if (s != "") sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                sql += " and date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1)>" + iNgoaitru_taikham;
                sql += " order by a.makp,a.ngay desc";
                ds1 = new DataSet();
                ds1 = m.get_data(sql);
                DataTable tmp;
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.benhanpk ";
                    sql+=" where mabn='"+r["mabn"].ToString()+"' and mangtr=" + decimal.Parse(r["maql"].ToString());
                    sql += " and date(to_char(now(),'yyyymmdd'))-date(to_char(ngay,'yyyymmdd'))+to_number(1)>" + iNgoaitru_taikham;
                    tmp = m.get_data_nam_dec(r["nam"].ToString(),sql).Tables[0];
                    ngayra = m.DateToString("dd/MM/yyyy HH:mm", m.StringToDateTime((tmp.Rows.Count==0)?r["ngay"].ToString():tmp.Rows[0]["ngay"].ToString()).AddDays(iNgoaitru_taikham - 1));
                    m.upd_benhanngtr(decimal.Parse(r["maql"].ToString()), ngayra, 3, 3, r["chandoan"].ToString(), r["maicd"].ToString(), r["mabs"].ToString(), int.Parse(r["bienchung"].ToString()), int.Parse(r["taibien"].ToString()), int.Parse(r["giaiphau"].ToString()), r["soluutru"].ToString());
                }
            }
            if (m.bKhambenh_ba)
            {
                string makp_right = "";
                if (s_mabs.Trim() != "")
                    makp_right = m.get_data("select makp from " + m.user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0]["makp"].ToString();
                    //makp_right = m.get_data("select makp from " + m.user + ".dlogin where mabs='" + s_mabs.Trim() + "'").Tables[0].Rows[0]["makp"].ToString();
                int makp;
                if (makp_right != "") makp = makp_right.IndexOf(",");
                else makp = 1;
                frmChonkp f = new frmChonkp(m, makp_right, s_mabs,"",i_chinhanh);
                if (makp >= 1)
                {
                    f.ShowDialog();
                    if (f.s_makp == "") return;
                }
                if (f.i_maba == 21)//rhm
                {
                    frmHSBenhan_NTRHM f1 = new frmHSBenhan_NTRHM(m, f.s_makp, f.s_tenkp, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba, i_mabv,i_chinhanh);
                    f1.MdiParent = this;
                    f1.Show();
                }
                else if (f.i_maba == 22)//tmh
                {
                    frmHSBenhan_NTTMH f1 = new frmHSBenhan_NTTMH(m, f.s_makp, f.s_tenkp, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba, i_mabv,i_chinhanh);
                    f1.MdiParent = this;
                    f1.Show();
                }
                else if (f.i_maba == 23)//mat
                {
                    frmHSBenhan_NGTMat f1 = new frmHSBenhan_NGTMat(m, f.s_makp, f.s_tenkp, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba, i_mabv,i_chinhanh);
                    f1.MdiParent = this;
                    f1.Show();
                }
                else
                {
                    frmHSBenhan_NT f1 = new frmHSBenhan_NT(m, f.s_makp, f.s_tenkp, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba, i_mabv,i_chinhanh);
                    f1.MdiParent = this;
                    f1.Show();
                }
            }
            else
            {
                frmNgoaitru f = new frmNgoaitru(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_nhomkho, s_mabs, s_madoituong);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem29_Click(object sender, System.EventArgs e)
        {
            frmTkvaovien f = new frmTkvaovien(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem32_Click(object sender, System.EventArgs e)
        {
            frmTkvaokhoa f = new frmTkvaokhoa(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem99_Click(object sender, System.EventArgs e)
        {
            frmTkrakhoa f = new frmTkrakhoa(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem100_Click(object sender, System.EventArgs e)
        {
            frmTkravien f = new frmTkravien(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem101_Click(object sender, System.EventArgs e)
        {
            frmHiendien f = new frmHiendien(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem102_Click(object sender, System.EventArgs e)
        {
            frmTkpttt f = new frmTkpttt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem24_Click(object sender, System.EventArgs e)
        {
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                DataTable dt = m.get_data("select * from " + m.user + ".btdkp_bv where loai=1 and makp in ('" + s.Substring(0, s.Length - 3) + "')").Tables[0];
                if (dt.Rows.Count == 0) return;
            }
            if (IsLoaded("frmKhambenh") || IsLoaded("frmKhambenh_ba")) return;
            string _mabs = s_mabs;
            if (_mabs == "" && m.bBacsi_khambenh)
            {
                frmChonbs f1 = new frmChonbs(m);
                f1.ShowDialog();
                _mabs = f1.s_mabs;
                if (_mabs == "") return;
            }
            if (m.bKhambenh_ba)
            {
                //frmKhambenh_ba f1 = new frmKhambenh_ba(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, this.menuItem31.Visible);
                //f1.MdiParent = this;
                //f1.Show();
                //tu 190511
                string makp_right = "";
                if (s_mabs.Trim() != "")
                    makp_right = m.get_data("select makp from " + m.user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0]["makp"].ToString();
                    //makp_right = m.get_data("select makp from " + m.user + ".dlogin where mabs='" + s_mabs.Trim() + "'").Tables[0].Rows[0]["makp"].ToString();
                int makp;
                if (makp_right != "") makp = makp_right.IndexOf(",");
                else makp = 1;
                frmChonpk f = new frmChonpk(m, makp_right, s_mabs, "01",i_chinhanh);
                if (makp >= 1)
                {
                    f.ShowDialog();
                    if (f.s_makp == "") return;
                }
                //if (f.s_makp != "") s_makp = f.s_makp;
                DataTable dt1 = m.get_data("select makp,makpbo from " + m.user + ".btdkp_bv where makp='" + f.s_makp + "'").Tables[0];
                if (dt1.Rows[0]["makpbo"].ToString() == "23")//tmh,f.s_makp == "23" || 
                {
                    frmKhambenh_tmh f1 = new frmKhambenh_tmh(m, f.s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, bAdmin, i_loai,i_khudt,i_chinhanh);//
                    f1.MdiParent = this;
                    f1.Show();
                }
                else if (dt1.Rows[0]["makpbo"].ToString() == "25") //mat,f.s_makp == "25" || 
                {
                    frmKhambenh_mat f1 = new frmKhambenh_mat(m, f.s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, bAdmin, i_loai,i_khudt,i_chinhanh);//
                    f1.MdiParent = this;
                    f1.Show();
                }
                else if (dt1.Rows[0]["makpbo"].ToString() == "24") //rhm,f.s_makp == "24" || 
                {
                    //frmKhambenh_rhm_goc f1 = new frmKhambenh_rhm_goc(m, f.s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, bAdmin, i_loai, i_khudt, i_chinhanh);//
                    frmKhambenh_ba f1 = new frmKhambenh_ba(m, f.s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, bAdmin, i_loai, i_khudt, i_chinhanh);//
                    f1.MdiParent = this;
                    f1.Show();
                }
                else //ba chung
                {
                    frmKhambenh_ba f1 = new frmKhambenh_ba(m, f.s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, bAdmin, i_loai, i_khudt, i_chinhanh);//
                    f1.MdiParent = this;
                    f1.Show();
                }
                m.upd_user_active(i_userid, f.s_makp, _mabs, m.ngayhienhanh_server.Substring(0,10));
            }
            else
            {
                frmKhambenh f = new frmKhambenh(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_madoituong, _mabs, s_nhomkho, this.menuItem31.Visible,i_khudt);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem33_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNhanbenh")) return;
            frmNhanbenh f = new frmNhanbenh(m, s_makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, i_khudt,i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem40_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXuatkhoa")) return;
            string makp = s_makp;
            if (makp == "")
            {
                frmChonkhoa f1 = new frmChonkhoa(m, s_makp, i_khudt,i_chinhanh);
                f1.ShowDialog();
                makp = f1.m_makp;
            }
            else
            {
                string s = s_makp.Replace(",", "','");
                DataTable dt = m.get_data("select * from " + m.user + ".btdkp_bv where loai=0 and makp in ('" + s.Substring(0, s.Length - 3) + "')").Tables[0];
                if (dt.Rows.Count == 0) return;
                else if (dt.Rows.Count == 1) makp = dt.Rows[0]["makp"].ToString();
                else
                {
                    frmChonkhoa f2 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh);
                    f2.ShowDialog();
                    makp = f2.m_makp;
                }
            }
            if (makp == "") return;
            frmXuatkhoa f = new frmXuatkhoa(m, makp, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, i_khudt, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem74_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu02")) return;
            frmBieu02 f = new frmBieu02(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem75_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu031")) return;
            frmBieu031 f = new frmBieu031(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem77_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu04")) return;
            frmBieu04 f = new frmBieu04(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem78_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu05")) return;
            frmBieu05 f = new frmBieu05(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem79_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu06")) return;
            frmBieu06 f = new frmBieu06(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem80_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu07")) return;
            frmBieu07 f = new frmBieu07(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem81_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu08")) return;
            frmBieu08 f = new frmBieu08(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem82_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu091")) return;
            frmBieu091 f = new frmBieu091(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem83_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu092")) return;
            frmBieu092 f = new frmBieu092(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem88_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu11")) return;
            if (m.Mabv.Substring(0, 3) == "701")
            {
                frmBieu11_18 f1 = new frmBieu11_18(m, s_userid, i_userid, i_mabv);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                frmBieu11 f2 = new frmBieu11(m, s_userid, i_userid, i_mabv);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem84_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu101")) return;
            frmBieu101 f = new frmBieu101(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem85_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu1021")) return;
            frmBieu1021 f = new frmBieu1021(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem86_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu1022")) return;
            frmBieu1022 f = new frmBieu1022(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem87_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBieu103")) return;
            frmBieu103 f = new frmBieu103(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem51_Click(object sender, System.EventArgs e)
        {
            //frmThumuc f = new frmThumuc(m.get_data("select ten from " + m.user + ".thongso where id=9").Tables[0].Rows[0][0].ToString(), "Chọn thư mục sao lưu số liệu", 1);
            //f.MdiParent = this;
            //f.Show();
            string s_PathCur = System.Environment.CurrentDirectory;
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowNewFolderButton = true;
            fld.ShowDialog();
            System.Environment.CurrentDirectory = s_PathCur;
            backup f;
            string ip, post, owner, user, database, file, arg, path, tenfile, ngay = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            path = fld.SelectedPath + "//" + ngay + "//";
            file = @"pg_dump.exe";
            user = m.user;
            ip = m.IPServer;// m.Maincode("Ip");
            post = m.PortServer;// m.Maincode("Post");
            owner = m.User_database;// m.Maincode("UserID");
            database = m.DatabaseServer;// m.Maincode("Database");
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            tenfile = user;
            arg = " -i -h " + ip + " -p " + post + " -U " + owner + " -F c -o -v -f " + path + tenfile + ".backup -n " + tenfile + " " + database;
            f = new backup(file, arg, true);
            f.Launch();
            foreach (DataRow r in m.get_data("select * from " + user + ".table where bak=0").Tables[0].Rows)
            {
                tenfile = user + r["mmyy"].ToString();
                arg = " -i -h " + ip + " -p " + post + " -U " + owner + " -F c -o -v -f " + path + tenfile + ".backup -n " + tenfile + " " + database;
                f = new backup(file, arg, true);
                f.Launch();
            }

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m, lan.Change_language_MessageText("Tình hình cán bộ, công chức,viên chức"), false, "dm_01", 1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m, lan.Change_language_MessageText("Hoạt động khám bệnh"), true, "dm_02", 2);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động điều trị"), true, "dm_031", 3);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem9_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,lan.Change_language_MessageText("Hoạt động phẫu thuật, thủ thuật"), true, "dm_04", 4);
            f.MdiParent = this;
            f.Show();

        }

        private void menuItem20_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m, lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện"), true, "dm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem31_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataSet ads_menu = new DataSet();
                try
                {
                    ads_menu = m.get_data("select * from medibv.m_menuitem order by id");
                    int i = int.Parse(ads_menu.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    m.execute_data(" create table medibv.m_menuitem(id varchar(5),id_goc varchar(5),stt numeric(5) default 0,id_menu varchar(5),ten text  ,constraint pk_m_menuitem primary key(id)) WITH OIDS;");
                    ads_menu = m.get_data("select * from medibv.m_menuitem order by id");
                }
                if (ads_menu.Tables[0].Rows.Count <= 0)
                {
                    frmRight f = new frmRight(m, f_get_menu(),i_chinhanh);
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    frmRight f = new frmRight(m, i_chinhanh);
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch
            {
            }
        }
        private TreeNode f_get_menu()
        {
            TreeNode anode, anode1;
            anode = new TreeNode("Chức năng");
            anode.Tag = "menuChucnang";
            anode.Name = "menuChucnang";
            foreach (MenuItem mi in this.mainMenu1.MenuItems)
            {
                MenuItem mnuitem = (MenuItem)(mi);
                if (mnuitem == menuItem55 || mnuitem == menuItem36 || mnuitem == mnuExit) break;

                anode1 = new TreeNode(mnuitem.Text.Replace("&", ""));
                anode1.Tag = mnuitem.MergeOrder.ToString().PadLeft(3, '0');
                anode.Nodes.Add(anode1);
                if (mnuitem.MenuItems.Count > 0)
                {
                    f_Add_Node(anode1, mnuitem);
                }

            }
            anode.ExpandAll();
            return anode;
        }

        private void f_Add_Node(TreeNode v_node, MenuItem v_item)
        {
            TreeNode anode;
            foreach (MenuItem ait in v_item.MenuItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.MenuItem")
                {
                    MenuItem amenu = (MenuItem)(ait);
                    if (amenu.Text != "-" && amenu != mnuRight_Bv && amenu != menuItem_dmcn)//Tu them: amenu!=menuItem_dmcn(danh muc chi nhanh)
                    {
                        anode = new TreeNode(amenu.Text.Replace("&", ""));
                        anode.Tag = amenu.MergeOrder.ToString().PadLeft(3, '0');
                        anode.Name = amenu.Name.ToString();
                        v_node.Nodes.Add(anode);
                        if (amenu.MenuItems.Count > 0)
                        {
                            f_Add_Node(anode, amenu);
                        }
                    }
                }
            }
        }
        private void menuItem95_Click(object sender, System.EventArgs e)
        {
            frmNop f = new frmNop(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem48_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdquan f = new dllDanhmucMedisoft.frmBtdquan(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem49_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdpxa f = new dllDanhmucMedisoft.frmBtdpxa(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động sức khỏe sinh sản"), false, "dm_05", 5);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem11_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động cận lâm sàng"), false, "dm_06", 6);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem12_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Dược bệnh viện"), false, "dm_07", 7);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem13_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Trang thiết bị y tế"), false, "dm_08", 8);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động chỉ đạo tuyến"), false, "dm_091", 91);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem15_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động nghiên cứu khoa học"), false, "dm_092", 92);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem16_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Hoạt động tài chính"), false, "dm_101", 101);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem17_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Chi tiết về thu viện phí,Bảo hiểm"), false, "dm_1021", 1021);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem18_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Chi tiết về các khoản chi"), false, "dm_1022", 1022);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem19_Click(object sender, System.EventArgs e)
        {
            rptBieu f = new rptBieu(m,
lan.Change_language_MessageText("Các khoản không thu được"), false, "dm_103", 103);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem94_Click_1(object sender, System.EventArgs e)
        {
            frmTkdangky f = new frmTkdangky(m, i_userid, i_khudt, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem92_Click_1(object sender, System.EventArgs e)
        {
            frmTkvaont f = new frmTkvaont(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem76_Click(object sender, System.EventArgs e)
        {
            frmTkrant f = new frmTkrant(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem93_Click_1(object sender, System.EventArgs e)
        {
            frmHiendienngtr f = new frmHiendienngtr(m, s_makp,0,null);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem103_Click(object sender, System.EventArgs e)
        {
            frmTktresosinh f = new frmTktresosinh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem66_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmmete f = new dllDanhmucMedisoft.frmDmmete(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem68_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmnhommau f = new dllDanhmucMedisoft.frmDmnhommau(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem61_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmIcd10 f = new dllDanhmucMedisoft.frmIcd10(m, "icd10", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem23_Click(object sender, System.EventArgs e)
        {
            frmBiavdt f = new frmBiavdt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            frmThthbn f = new frmThthbn(m, s_makp, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem37_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"..\..\..\help\Medisoft THIS.chm");
            }
            catch
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy đường dẫn đến tập tin trợ giúp."), lan.Change_language_MessageText("Trợ giúp"));
            }
        }

        private void menuItem63_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmError f = new dllDanhmucMedisoft.frmError(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem97_Click(object sender, System.EventArgs e)
        {
            frmTktainantt f = new frmTktainantt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem22_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmCoso f = new dllDanhmucMedisoft.frmCoso(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem168_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmSxkd f = new dllDanhmucMedisoft.frmSxkd(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem2_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh01")) return;
            frmKh01 f = new frmKh01(m, s_userid, i_userid, i_mabv);
            //1dllBaocao_BYT.frmKh01 f = new dllBaocao_BYT.frmKh01(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem6_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh02")) return;
            frmKh02 f = new frmKh02(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem75_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh143")) return;
            frmKh143 f = new frmKh143(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem9_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh04")) return;
            frmKh04 f = new frmKh04(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem7_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh03")) return;
            frmKh03 f = new frmKh03(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem10_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh05")) return;
            frmKh05 f = new frmKh05(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem11_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh06")) return;
            frmKh06 f = new frmKh06(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem12_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh07")) return;
            frmKh07 f = new frmKh07(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem79_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh15")) return;
            frmKh15 f = new frmKh15(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem14_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh09")) return;
            frmKh09 f = new frmKh09(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem15_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh10")) return;
            frmKh10 f = new frmKh10(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem86_Click_1(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Dân số, đơn vị hành chính, trạm y tế xã"), false, "kh_dm_01", 1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem87_Click_1(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Thông tin về sinh tử"), false, "kh_dm_02", 2);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem88_Click_1(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình thu chi ngân sách của ngành y tế địa phương"), false, "kh_dm_03", 3);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem140_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình thu chi ngân sách của tuyến xã"), false, "kh_dm_04", 4);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem141_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình cơ sở y tế và giường bệnh"), false, "kh_dm_05", 5);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem142_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình nhân lực y tế của toàn huyện"), false, "kh_dm_06", 6);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem143_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình sản xuất kinh doanh dược của huyện"), false, "kh_dm_07", 7);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem145_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Chăm sóc sức khoẻ trẻ em"), false, "kh_dm_09", 9);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem146_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình chăm sóc sức khoẻ bà mẹ"), false, "kh_dm_10", 10);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem13_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh08")) return;
            frmKh08 f = new frmKh08(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem144_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Tình hình trang thiết bị y tế của địa phương"), false, "kh_dm_08", 8);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem147_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Thực hiện công tác kế hoạch hóa gia đình"), false, "kh_dm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem167_Click(object sender, System.EventArgs e)
        {
            frmBiavkh f = new frmBiavkh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem16_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh11")) return;
            frmKh11 f = new frmKh11(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem17_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh121")) return;
            frmKh121 f = new frmKh121(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem148_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 12.1//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_121", 121);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem149_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 12.2//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_122", 122);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem150_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 12.3//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_123", 123);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem18_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh122")) return;
            frmKh122 f = new frmKh122(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem19_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh123")) return;
            frmKh123 f = new frmKh123(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem151_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 13.1//Thực hiện công tác phòng bệnh"), false, "kh_dm_131", 131);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem152_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 13.2//Thực hiện công tác phòng bệnh"), false, "kh_dm_132", 132);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem153_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 13.3//Thực hiện công tác phòng bệnh"), false, "kh_dm_133", 133);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem154_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 14.1//Các bệnh lây và bệnh quan trọng"), false, "kh_dm_141", 141);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem155_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 14.2//Các bệnh lây và bệnh quan trọng"), false, "kh_dm_142", 142);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem156_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 14.3//Các bệnh lây và bệnh quan trọng"), false, "kh_dm_143", 143);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem157_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 14.4//Các bệnh lây và bệnh quan trọng"), false, "kh_dm_144", 144);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem20_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh131")) return;
            frmKh131 f = new frmKh131(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem21_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh132")) return;
            frmKh132 f = new frmKh132(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem23_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh0133")) return;
            frmKh133 f = new frmKh133(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem70_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh141")) return;
            frmKh141 f = new frmKh141(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem74_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh142")) return;
            frmKh142 f = new frmKh142(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem77_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh144")) return;
            frmKh144 f = new frmKh144(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem78_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh145")) return;
            frmKh145 f = new frmKh145(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem159_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện theo ICD10"), true, "dm_11", 15);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem158_Click(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Báo cáo thống kê tai nạn, thuơng tích"), true, "kh_dm_1451", 145);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem81_Click_1(object sender, System.EventArgs e)
        {
            rptBieukh f = new rptBieukh(m,
lan.Change_language_MessageText("Biểu 12.4//Công tác khám chữa bệnh và dịch vụ y tế"), false, "kh_dm_124", 124);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem80_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKh124")) return;
            frmKh124 f = new frmKh124(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem82_Click_1(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdpk f = new dllDanhmucMedisoft.frmBtdpk(m, i_userid, i_chinhanh );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem83_Click_1(object sender, System.EventArgs e)
        {
            frmSuamabn f = new frmSuamabn(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem85_Click_1(object sender, System.EventArgs e)
        {
            frmXoaba f = new frmXoaba(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem53_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmMaubc f = new dllDanhmucMedisoft.frmMaubc(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem161_Click_1(object sender, System.EventArgs e)
        {
            frmBieudo f = new frmBieudo(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem162_Click(object sender, System.EventArgs e)
        {
            try
            {
                string s_userid = m.get_data("select userid from " + m.user + ".dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
                string s_psw = m.get_data("select password_ from " + m.user + ".dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
                frmEditUser f = new frmEditUser(m, m.get_data("select * from " + m.user + ".dlogin"), i_userid, s_userid, s_psw, s_right, s_makp, s_madoituong, s_nhomkho, s_cls, s_mabs, s_may);
                f.MdiParent = this;
                f.Show();
            }
            catch { }
        }

        private void menuItem163_Click(object sender, System.EventArgs e)
        {
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                DataTable dt = m.get_data("select * from " + m.user + ".btdkp_bv where loai=1 and makp in ('" + s.Substring(0, s.Length - 3) + "')").Tables[0];
                if (dt.Rows.Count == 0) return;
            }
            if (IsLoaded("frmTiepdon") || IsLoaded("frmTiepdon_scard")) return;
            if (m.bIn_khambenh && m.bHienkyhieu)
            {
                frmSohieu f1 = new frmSohieu(m);
                f1.ShowDialog(this);
                if (f1.iKyhieu != 0 && f1.iLoai != 0)
                {
                    if (m.bSmartcard)
                    {
                        //frmTiepdon_scard fs1 = new frmTiepdon_scard(m, s_makp, s_userid, i_userid, f1.iKyhieu, f1.iLoai, s_madoituong, i_khudt);
                        //fs1.MdiParent = this;
                        //fs1.Show();
                    }
                    else
                    {
                        if (m.bTiepdonMoi)
                        {
                            frmTiepdon_new ft1 = new frmTiepdon_new(m, s_makp, s_userid, i_userid, f1.iKyhieu, f1.iLoai, s_madoituong, i_khudt,i_chinhanh);
                            ft1.MdiParent = this;
                            ft1.Show();
                        }
                        else
                        {
                            frmTiepdon ft1 = new frmTiepdon(m, s_makp, s_userid, i_userid, f1.iKyhieu, f1.iLoai, s_madoituong, i_khudt, i_chinhanh);
                            ft1.MdiParent = this;
                            ft1.chinhanhid = i_chinhanh;
                            ft1.Show();
                        }
                    }
                }
            }
            
            else
            {
                if (m.bSmartcard)
                {
                    //frmTiepdon_scard fs2 = new frmTiepdon_scard(m, s_makp, s_userid, i_userid, 0, 0, s_madoituong, i_khudt);
                    //fs2.MdiParent = this;
                    //fs2.Show();
                }
                else
                {
                    if (m.bTiepdonMoi)
                    {
                        frmTiepdon_new ft1 = new frmTiepdon_new(m, s_makp, s_userid, i_userid, 0, 0, s_madoituong, i_khudt,i_chinhanh);
                        ft1.MdiParent = this;
                        ft1.Show();
                    }
                    else
                    {
                        frmTiepdon f2 = new frmTiepdon(m, s_makp, s_userid, i_userid, 0, 0, s_madoituong, i_khudt, i_chinhanh);
                        f2.MdiParent = this;
                        f2.chinhanhid = i_chinhanh;
                        f2.Show();
                    }
                }
            }
        }

        private void menuItem164_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmKbpttt f = new dllDanhmucMedisoft.frmKbpttt(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem166_Click(object sender, System.EventArgs e)
        {
            frmTkdieutri f = new frmTkdieutri(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem172_Click(object sender, System.EventArgs e)
        {
            frmTruyvan f = new frmTruyvan(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem173_Click(object sender, System.EventArgs e)
        {
            frmTruyvantk f = new frmTruyvantk(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem174_Click(object sender, System.EventArgs e)
        {
            frmImpHL7 f = new frmImpHL7(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem169_Click_1(object sender, System.EventArgs e)
        {
            frmTknhiem f = new frmTknhiem(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem170_Click_1(object sender, System.EventArgs e)
        {
            frmTktuvong f = new frmTktuvong(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem175_Click(object sender, System.EventArgs e)
        {
            frmThnhiem f = new frmThnhiem(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem176_Click(object sender, System.EventArgs e)
        {
            frmThlay f = new frmThlay(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem177_Click(object sender, System.EventArgs e)
        {
            frmThicd10 f = new frmThicd10(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem178_Click(object sender, System.EventArgs e)
        {
            frmThpttt f = new frmThpttt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem179_Click(object sender, System.EventArgs e)
        {
            frmTVuser f = new frmTVuser(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem8_Click_1(object sender, System.EventArgs e)
        {
            frmTkpttt f = new frmTkpttt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem26_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDstt f = new dllDanhmucMedisoft.frmDstt(m, "dstt", lan.Change_language_MessageText("Cơ quan y tế chuyển đến"), i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem196_Click(object sender, System.EventArgs e)
        {
            frmTkchuyenden f = new frmTkchuyenden(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem97_Click_1(object sender, System.EventArgs e)
        {
            frmTkchuyenvien f = new frmTkchuyenvien(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem200_Click(object sender, System.EventArgs e)
        {
            frmTkphong f = new frmTkphong(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem205_Click(object sender, System.EventArgs e)
        {
            frmTksxh f = new frmTksxh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem206_Click(object sender, System.EventArgs e)
        {
            frmThsxh f = new frmThsxh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem32_Click_1(object sender, System.EventArgs e)
        {
            frmTkviemphoi f = new frmTkviemphoi(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem84_Click_1(object sender, System.EventArgs e)
        {
            frmThviemphoi f = new frmThviemphoi(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem207_Click(object sender, System.EventArgs e)
        {
            frmTklay f = new frmTklay(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem209_Click(object sender, System.EventArgs e)
        {
            frmTkari f = new frmTkari(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem210_Click(object sender, System.EventArgs e)
        {
            frmThari f = new frmThari(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem213_Click(object sender, System.EventArgs e)
        {
            frmTkdiaphuong f = new frmTkdiaphuong(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem214_Click(object sender, System.EventArgs e)
        {
            frmTknam f = new frmTknam(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem211_Click(object sender, System.EventArgs e)
        {
            frmTkngaydt f = new frmTkngaydt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem212_Click(object sender, System.EventArgs e)
        {
            frmTkttlucrv f = new frmTkttlucrv(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem99_Click_1(object sender, System.EventArgs e)
        {
            frmTkkhambenh f = new frmTkkhambenh(m, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private bool IsLoaded(string frm)
        {
            Form[] afrm = this.MdiChildren;
            foreach (Form f in afrm)
            {
                if (f.Name.Equals(frm)) { f.Activate(); return true; }
            }
            return false;
        }

        private void menuItem100_Click_1(object sender, System.EventArgs e)
        {
            m.writeXml("d_netsend", "ma", "");
            m.writeXml("d_netsend", "ten", "");
            NetSend f = new NetSend();
            f.ShowDialog(this);
        }

        private void menuItem101_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory().ToUpper();
                int pos = path.LastIndexOf("//MEDISOFT");
                if (pos != 0) path = path.Substring(0, pos) + "//Setup";
                string arg = " /qn /i \"" + path + "//zip.msi\"";
                backup e1 = new backup(@"msiexec", arg, false);
                e1.Launch();
                arg = "/qn /i \"" + path + "//Microsoft OLE DB Provider for Visual FoxPro.msi\"";
                backup e2 = new backup(@"msiexec", arg, false);
                e2.Launch();
                m.upd_thongso(101, "1", "1", "1");
            }
            catch { }
        }

        private void menuItem102_Click_1(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDstt f = new dllDanhmucMedisoft.frmDstt(m, "dmnoicapbhyt", lan.Change_language_MessageText("Danh mục đăng ký khám chữa bệnh"), i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem166_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDutru")) return;
            int loai = 1;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, false, s_nhomkho, i_khudt,this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmDutru f1 = new frmDutru(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, s_mabs,s_madoituong);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem216_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmYlenh") || IsLoaded("frmYlenh_cd")) return;
            if (m.bInylenh_cachdung)
            {
                frmYlenh_cd f1 = new frmYlenh_cd(m, s_makp, s_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                frmYlenh f2 = new frmYlenh(m, s_makp, s_nhomkho);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem170_Click_2(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantra")) return;
            int loai = 3;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 1, s_makp, false, s_nhomkho, i_khudt,i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHoantra f1 = new frmHoantra(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Hoàn trả " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem173_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantrathua")) return;
            int loai = 3;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, true, s_nhomkho, i_khudt,i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHoantrathua f1 = new frmHoantrathua(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Hoàn trả thừa theo khoa " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, false, m.iSudungthuoc, f.s_tenkp, f.s_phieu, f.i_somay,false);
                f1.MdiParent = this;
                f1.Show();
            }
        }
        private void menuItem217_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmXutrikb f = new dllDanhmucMedisoft.frmXutrikb(m,s_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem172_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHaophi")) return;
            int loai = 4;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, false, s_nhomkho, i_khudt,i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHaophi f1 = new frmHaophi(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù hao phí " + f.s_tennhom.Trim() + " theo khoa/phòng (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.iSudungthuoc, f.s_manguon, true, f.s_tenkp, f.s_phieu, f.i_somay);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem169_Click_2(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXtutruc")) return;
            int loai = 2;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, false, s_nhomkho, i_khudt,this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, "", f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, s_mabs,s_madoituong);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem218_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmInphieu")) return;
            frmInphieu f = new frmInphieu(s_makp, s_nhomkho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem219_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmthuoc f = new dllDanhmucMedisoft.frmDmthuoc(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem220_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmDmcachdung f = new dllDanhmucMedisoft.frmDmcachdung(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem222_Click(object sender, System.EventArgs e)
        {
            //if (m.bChidinh_thutienlien == false)
            //{
            dllvpkhoa_chidinh.frmChonthongsovp f = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp, i_khudt);
                f.ShowDialog(this);
                if (f.s_makp != "")
                {
                    dllvpkhoa_chidinh.frmVpkhoa f1 = new dllvpkhoa_chidinh.frmVpkhoa(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, f.i_buoi);
                    f1.MdiParent = this;
                    f1.Show();
                }
            //}
            //else
            //{
            //    dllvpkhoa_chidinh.frmChonthongsovp f = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp);
            //    f.ShowDialog(this);
            //    if (f.s_makp != "")
            //    {
            //        LibVienphi.AccessData v = new LibVienphi.AccessData();
            //        dllvpkhoa_chidinh.frmChidinh_n f1 = new dllvpkhoa_chidinh.frmChidinh_n(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, m.user + ".nhapkhoa", v.iNoitru, 1, b_admin,true);
            //        f1.MdiParent = this;
            //        f1.Show();
            //    }
            //}
        }

        private void menuItem228_Click(object sender, System.EventArgs e)
        {
            if (m.bKhambenh_ba)
            {
                frmHSBenhan_PL f1 = new frmHSBenhan_PL(m, "99", "Phòng lưu", 0, s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, 1, i_mabv, s_madoituong,i_chinhanh);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                frmPhongluu f = new frmPhongluu(m, s_userid, i_userid, i_mabv, b_sovaovien, b_soluutru, s_nhomkho, s_madoituong, i_khudt,i_chinhanh);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem230_Click(object sender, System.EventArgs e)
        {
            frmHiendienpl f = new frmHiendienpl(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem231_Click(object sender, System.EventArgs e)
        {
            frmTkvaopl f = new frmTkvaopl(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem232_Click(object sender, System.EventArgs e)
        {
            frmTkrapl f = new frmTkrapl(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem225_Click(object sender, System.EventArgs e)
        {
            //if (m.bThanhtoan_ndot && m.Mabv_so == 101204)
            //{
            //    frmRavien01 f1 = new frmRavien01(m, s_makp, 1);
            //    f1.MdiParent = this;
            //    f1.Show();
            //}
            //else
            //{
                frmRavien f2 = new frmRavien(m, s_makp, 1, s_userid, i_userid);
                f2.MdiParent = this;
                f2.Show();
           // }
        }

        private void menuItem226_Click(object sender, System.EventArgs e)
        {
            //if(m.Thongso())
            frmGiayravien f = new frmGiayravien(m, s_makp, i_userid,1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem236_Click(object sender, System.EventArgs e)
        {
            frmBctiepbenh f = new frmBctiepbenh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem237_Click(object sender, System.EventArgs e)
        {
            frmSlkhambenh f = new frmSlkhambenh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem239_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPttt")) return;
            //Thanh Cuong - 06/08/2012 - Kỹ thuật cao
            //frmPttt f = new frmPttt(m, "", "", "", "", "", "", "", "", "", "", "", "", i_userid, "", s_makp, s_madoituong, 0, 0, 0, 0, false);
            frmPttt f = new frmPttt(m, "", "", "", "", "", "", "", "", "", "", "", "", i_userid, "", s_makp, s_madoituong, 0, 0, 0, 0, false, s_nhomkho,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem241_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTuongtrinhpttt")) return;
            frmTuongtrinhpttt f = new frmTuongtrinhpttt(m, s_makp, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem242_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmKygiayrv f = new dllDanhmucMedisoft.frmKygiayrv(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem243_Click(object sender, System.EventArgs e)
            {
            dllDanhmucMedisoft.frmDoituong f = new dllDanhmucMedisoft.frmDoituong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem244_Click(object sender, System.EventArgs e)
        {
            Bieu11_khoa f = new Bieu11_khoa(m, "dm_11", s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem245_Click(object sender, System.EventArgs e)
        {
            rptDspttt f = new rptDspttt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem176_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHaophi")) return;
            int loai = 4;
            if (m.bDutru_taisan_tren_csdl_moi==false)
            {
                frmChonthongso f = new frmChonthongso(m, 2, loai, 0, s_makp, false, s_nhomkho, i_khudt,this.i_userid);//linh 16102012
                f.ShowDialog(this);
                if (f.s_makp != "")
                {
                    frmHaophi f1 = new frmHaophi(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù tài sản " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.iSudungthuoc, f.s_manguon, false, f.s_tenkp, f.s_phieu, f.i_somay);
                    f1.MdiParent = this;
                    f1.Show();
                }
            }
            else
            {
                LibTTB.AccessData ttb = new LibTTB.AccessData();
                DuTruKhoTTB.frmChonthongso f = new DuTruKhoTTB.frmChonthongso(ttb, 2,loai, 0, s_makp, false, s_nhomkho);
                f.ShowDialog(this);
                if (f.s_makp != "")
                {
                    DuTruKhoTTB.frmHaophi f1 = new DuTruKhoTTB.frmHaophi(ttb, f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù tài sản " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.iSudungthuoc, f.s_manguon, false, f.s_tenkp, f.s_phieu, f.i_somay);
                    f1.MdiParent = this;
                    f1.Show();
                }
            }
        }

        private void menuItem177_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantrataisan")) return;
            LibTTB.AccessData ttb= new LibTTB.AccessData();
            int loai = 3;
            DuTruKhoTTB.frmChonthongso f = new DuTruKhoTTB.frmChonthongso(ttb, 2, loai, 0, s_makp, false, s_nhomkho);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                DuTruKhoTTB.frmHoantrataisan f1 = new DuTruKhoTTB.frmHoantrataisan(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu hoàn trả tài sản " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, false, m.iSudungthuoc, f.s_manguon, f.s_tenkp, f.s_phieu, f.i_somay);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem249_Click(object sender, System.EventArgs e)
        {
            rptBieukhoa f = new rptBieukhoa(m,lan.Change_language_MessageText("Hoạt động phẫu thuật, thủ thuật"), "dm_04", s_makp, 3);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem250_Click(object sender, System.EventArgs e)
        {
            frmNhapxuat f = new frmNhapxuat(m, 1, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem251_Click(object sender, System.EventArgs e)
        {
            frmThthbn f = new frmThthbn(m, s_makp, 2);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem252_Click(object sender, System.EventArgs e)
        {
            frmThthbn f = new frmThthbn(m, LibMedi.AccessData.phongluu, 4);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem253_Click(object sender, System.EventArgs e)
        {
            string file = @"wordpad.exe";
            string fileToOpen = @m.Path_thongbao;//"..//..//..//doc//thongbao.rtf"
            backup f = new backup(file, fileToOpen, true);
            f.Launch();
        }

        private void menuItem256_Click(object sender, System.EventArgs e)
        {
            frmNhapxuatk f = new frmNhapxuatk(m, 1, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem255_Click(object sender, System.EventArgs e)
        {
            rptBieukhoa f = new rptBieukhoa(m, lan.Change_language_MessageText("Hoạt động phẫu thuật, thủ thuật"), "dm_04", s_makp, 2);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem254_Click(object sender, System.EventArgs e)
        {
            frmNhapxuat f = new frmNhapxuat(m, 2, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem238_Click(object sender, System.EventArgs e)
        {
            frmSuadoituong_ct f1 = new frmSuadoituong_ct(m, s_makp, 1);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem259_Click(object sender, System.EventArgs e)
        {
            frmSuadoituong_ct f1 = new frmSuadoituong_ct(m, s_makp, 3);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem261_Click(object sender, System.EventArgs e)
        {
            frmSuadoituong_ct f1 = new frmSuadoituong_ct(m, s_makp, 2);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem264_Click(object sender, System.EventArgs e)
        {
            frmSuadoituong_ct f1 = new frmSuadoituong_ct(m, s_makp, 4);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem258_Click(object sender, System.EventArgs e)
        {
            frmTtngtru f = new frmTtngtru(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem260_Click(object sender, System.EventArgs e)
        {
            frmRavien f = new frmRavien(m, s_makp, 2, s_userid, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem263_Click(object sender, System.EventArgs e)
        {
            frmRavien f = new frmRavien(m, s_makp, 4, s_userid, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem266_Click(object sender, System.EventArgs e)
        {
            dllDanhmucMedisoft.frmBtdpmo f = new dllDanhmucMedisoft.frmBtdpmo(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem267_Click(object sender, System.EventArgs e)
        {
            frmSuahc f = new frmSuahc(m, s_userid, i_userid, m.bSoluutru_nhapvien, "");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem268_Click(object sender, System.EventArgs e)
        {
            frmSuasolieu f = new frmSuasolieu(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem269_Click(object sender, System.EventArgs e)
        {
            frmSbanhapkho f = new frmSbanhapkho(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem272_Click(object sender, System.EventArgs e)
        {
            frmsuabhyt f = new frmsuabhyt(i_userid, false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem224_Click(object sender, System.EventArgs e)
        {
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            frmCongkhai f = new frmCongkhai(d, s_makp, this.menuItem31.Visible, 1, s_userid, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem273_Click(object sender, System.EventArgs e)
        {
            dllvpkhoa_chidinh.frmChonthongsovp f = new dllvpkhoa_chidinh.frmChonthongsovp(m, s_makp, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                LibVienphi.AccessData v = new LibVienphi.AccessData();
                dllvpkhoa_chidinh.frmChidinh_n f1 = new dllvpkhoa_chidinh.frmChidinh_n(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, m.user + ".nhapkhoa", v.iNoitru, 1, b_admin, false);
                f1.MdiParent = this;
                    f1.Show();
            }
        }

        private void menuItem246_Click(object sender, System.EventArgs e)
        {

        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {

        }

        private void menuItem234_Click(object sender, System.EventArgs e)
        {
            Desktop2PPC.FrmDesktop2PPC f = new Desktop2PPC.FrmDesktop2PPC();
            f.ShowDialog(this);
        }

        private void menuItem274_Click(object sender, System.EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid,1);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmChidinh_k f1 = new dllvpkhoa_chidinh.frmChidinh_k(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

		private void menuItem277_Click(object sender, System.EventArgs e)
		{
            menuItem58_Click(sender,e);
            dllDanhmucMedisoft.frmICD10_Ora f = new dllDanhmucMedisoft.frmICD10_Ora(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem278_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process mypro=System.Diagnostics.Process.Start("..//..//..//medisoft_map//bin//debug//medimap.exe");
		}

		private void menuItem280_Click(object sender, System.EventArgs e)
		{
            if (IsLoaded("frmDausinhton")) return;
            string makp=s_makp;
            if (makp=="")
            {
                frmChonkhoa f1 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh);
                f1.ShowDialog();
                makp=f1.m_makp;
            }
            else
            {
                string s = s_makp.Replace(",", "','");
                DataTable dt = m.get_data("select * from " + m.user + ".btdkp_bv where loai=0 and makp in ('" + s.Substring(0, s.Length - 3) + "')").Tables[0];
                if (dt.Rows.Count==0) return;
                else if (dt.Rows.Count==1) makp=dt.Rows[0]["makp"].ToString();
                else
                {
                    frmChonkhoa f2=new frmChonkhoa(m,s_makp, i_khudt, i_chinhanh );
                    f2.ShowDialog();
                    makp=f2.m_makp;
                }
            }
            if (makp=="") return;
            frmDausinhton f=new frmDausinhton(m,makp,i_userid);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem281_Click(object sender, System.EventArgs e)
		{
            frmSotienNgay f=new frmSotienNgay();
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem282_Click(object sender, System.EventArgs e)
		{
            frmHuyvp f=new frmHuyvp(m,s_makp,i_userid);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem67_Click_1(object sender, System.EventArgs e)
		{
            frmDonthuoc f=new frmDonthuoc(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem171_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDonthuoc_bacsy f = new dllDanhmucMedisoft.frmDonthuoc_bacsy(m);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem283_Click(object sender, System.EventArgs e)
		{
            frmThutien f=new frmThutien(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem45_Click_1(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDm f = new dllDanhmucMedisoft.frmDm(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem284_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDanhmuc f = new dllDanhmucMedisoft.frmDanhmuc(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem46_Click(object sender, System.EventArgs e)
		{
            frmInphieuxuat f=new frmInphieuxuat(s_makp,s_nhomkho,i_userid);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem50_Click(object sender, System.EventArgs e)
		{
            frmNXkhoa f=new frmNXkhoa(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem52_Click(object sender, System.EventArgs e)
		{
            frmTruyvan_kb f=new frmTruyvan_kb(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem285_Click(object sender, System.EventArgs e)
		{
            frmTruyvan_pt f=new frmTruyvan_pt(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem286_Click(object sender, System.EventArgs e)
		{
            frmbtpkham f=new frmbtpkham(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem292_Click(object sender, System.EventArgs e)
		{
            frmNhapcls f1=new frmNhapcls(m,s_makp,s_userid,i_userid,s_madoituong,s_cls);
            f1.MdiParent=this;
            f1.Show();
		}

		private void menuItem297_Click(object sender, System.EventArgs e)
		{
            frmCls_loai f = new frmCls_loai(m,this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem298_Click(object sender, System.EventArgs e)
		{
            frmCls_denghi f = new frmCls_denghi(m, s_cls, "cls_denghi", -1, lan.Change_language_MessageText("Đề nghị"), this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem299_Click(object sender, System.EventArgs e)
		{
            frmCls_noidung f = new frmCls_noidung(m, s_cls,this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();		
		}

		private void menuItem287_Click(object sender, System.EventArgs e)
		{
            frmThuoc_ts_pttt f=new frmThuoc_ts_pttt(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem289_Click(object sender, System.EventArgs e)
		{
            frmKhambenh2 f=new frmKhambenh2(m,s_makp,s_userid,i_userid,s_madoituong);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem290_Click(object sender, System.EventArgs e)
		{
            frmCls_denghi f = new frmCls_denghi(m, s_cls, "cls_ketqua", -4, 
lan.Change_language_MessageText("Kết quả"), this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem302_Click(object sender, System.EventArgs e)
		{
            frmSotienNgay f=new frmSotienNgay();
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem303_Click(object sender, System.EventArgs e)
		{
            frmThuoc_ts_pttt f=new frmThuoc_ts_pttt(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem304_Click(object sender, System.EventArgs e)
		{
            frmChiphiDT f=new frmChiphiDT(m,s_makp,s_madoituong);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem233_Click_1(object sender, System.EventArgs e)
		{
            frmCongno f=new frmCongno(m,s_makp,s_madoituong,i_userid,1);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem305_Click(object sender, System.EventArgs e)
		{
            frmSDThuoc f=new frmSDThuoc(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem281_Click_1(object sender, System.EventArgs e)
		{
            frmThuoc_mabn f=new frmThuoc_mabn(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem306_Click(object sender, System.EventArgs e)
		{
            if (IsLoaded("frmHaophicstt")) return;
            int loai=2;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, false, s_nhomkho, i_khudt,i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp!="")
            {
                frmHaophicstt f1=new frmHaophicstt(f.s_ngay,f.s_makho,f.s_makp,f.i_nhom,loai,f.i_phieu,f.i_macstt,i_userid,f.s_mmyy,f.l_duyet,"Phiếu xuất tủ trực "+f.s_tennhom.Trim()+" theo khoa/phòng ("+f.s_ngay.Trim()+", "+f.s_tenkp.Trim()+", "+f.s_phieu.Trim()+", "+s_userid.Trim()+")",LibMedi.AccessData.Msg,m.iSudungthuoc,f.s_manguon,f.s_tenkp,f.s_phieu,f.i_somay,f.i_makp);
                f1.MdiParent=this;
                f1.Show();
            }
		}

		private void menuItem307_Click(object sender, System.EventArgs e)
		{
            string mabv = "";
            try
            {
                string sqlts = "select ten from " + m.user + ".thongso where id =2";
                mabv = m.get_data(sqlts).Tables[0].Rows[0][0].ToString();
            }
            catch
            { }
            frmGiaycv f;
            if (mabv == "115.5.10")
                f = new frmGiaycv_quynhphu(m, s_makp, i_userid, "", 0);
            else
                f = new frmGiaycv(m, s_makp, i_userid, "", 0);
            f.MdiParent=this;
            f.Show();		
		}

		private void menuItem308_Click(object sender, System.EventArgs e)
		{
            frmDScdvp f=new frmDScdvp(m,s_makp,s_madoituong);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem309_Click(object sender, System.EventArgs e)
		{
            frmTHSDThuoc f=new frmTHSDThuoc(m,s_makp,s_nhomkho);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem310_Click(object sender, System.EventArgs e)
		{
            frmTtkcb f=new frmTtkcb(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem311_Click(object sender, System.EventArgs e)
		{
            frmThkcb f=new frmThkcb(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem312_Click(object sender, System.EventArgs e)
		{
            frmSuangay f=new frmSuangay(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem313_Click(object sender, System.EventArgs e)
		{
            frmTtkcbngtr f=new frmTtkcbngtr(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem314_Click(object sender, System.EventArgs e)
		{
            frmthkcbngtr f=new frmthkcbngtr(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem334_Click(object sender, System.EventArgs e)
		{
            frmCls_kehoach f = new frmCls_kehoach(m);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem293_Click(object sender, System.EventArgs e)
		{
            frmtkdscls f = new frmtkdscls(m, s_cls);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem294_Click(object sender, System.EventArgs e)
        {
            frmtkthcls f = new frmtkthcls(m, s_cls);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem335_Click(object sender, System.EventArgs e)
		{
            frmtkbscls f = new frmtkbscls(m);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem336_Click(object sender, System.EventArgs e)
		{
            frmbcthcls f = new frmbcthcls(m);
            f.MdiParent = this;
            f.Show();
		}

		private void menuItem337_Click(object sender, System.EventArgs e)
		{
            frmbtngtr f=new frmbtngtr(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem338_Click(object sender, System.EventArgs e)
		{
            frmCSDL f=new frmCSDL(m,i_userid);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem325_Click(object sender, System.EventArgs e)
		{
            frmLeDanhmuc f=new frmLeDanhmuc(m,-5,"le_loaibn",lan.Change_language_MessageText("Danh mục bệnh nhân"));
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem327_Click(object sender, System.EventArgs e)
		{
            frmLeDanhmuc f=new frmLeDanhmuc(m,-6,"le_sohoso",lan.Change_language_MessageText("Danh mục số hồ sơ"));
            f.MdiParent=this;
            f.Show();
		}

	    private void menuItem319_Click(object sender, System.EventArgs e)
		{
            frmtkdsle f=new frmtkdsle(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem321_Click(object sender, System.EventArgs e)
		{
            frmtkthle f=new frmtkthle(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem259_Click_1(object sender, System.EventArgs e)
		{
            frmSokham f=new frmSokham(m,s_makp);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem339_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDmbhyt f = new dllDanhmucMedisoft.frmDmbhyt(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem329_Click(object sender, System.EventArgs e)
		{
            frmLeDanhmuc f=new frmLeDanhmuc(m,-8,"kx_loaibn",lan.Change_language_MessageText("Danh mục nơi giới thiệu"));
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem330_Click(object sender, System.EventArgs e)
		{
            frmLeDanhmuc f=new frmLeDanhmuc(m,-9,"kx_chidinh",
lan.Change_language_MessageText("Danh mục chỉ định"));
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem331_Click(object sender, System.EventArgs e)
		{
            frmLeDanhmuc f=new frmLeDanhmuc(m,-10,"kx_xutri",lan.Change_language_MessageText("Danh mục xử trí"));
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem332_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmIcd10 f = new dllDanhmucMedisoft.frmIcd10(m, "kx_icd10", i_userid);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem323_Click(object sender, System.EventArgs e)
		{
            frmtkdskx f=new frmtkdskx(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem324_Click(object sender, System.EventArgs e)
		{
            frmtkthkx f=new frmtkthkx(m);
            f.MdiParent=this;
            f.Show();
		}

		private void menuItem333_Click(object sender, System.EventArgs e)
		{
            frmChuyenkham f=new frmChuyenkham(m,s_makp,i_userid, i_chinhanh );
            f.MdiParent=this;
            f.Show();
		}

        private void menuItem342_Click(object sender, EventArgs e)
        {
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            frmCongkhai f = new frmCongkhai(d, s_makp, this.menuItem31.Visible, 2,s_userid,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem165_Click(object sender, EventArgs e)
        {
            frmEvent f = new frmEvent(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem235_Click(object sender, EventArgs e)
        {
            frmDoichieu f = new frmDoichieu(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem275_Click(object sender, EventArgs e)
        {
            frmCDVPCLS f = new frmCDVPCLS(m, s_makp, 
lan.Change_language_MessageText("Danh sách được chỉ định"), "1=1");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem276_Click(object sender, EventArgs e)
        {
            frmCDVPCLS f = new frmCDVPCLS(m, s_makp, 
lan.Change_language_MessageText("Danh sách chỉ định chưa thực hiện"), " a.done=0");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem340_Click(object sender, EventArgs e)
        {
            frmCDVPCLS f = new frmCDVPCLS(m, s_makp, 
lan.Change_language_MessageText("Danh sách đã thu tiền chưa thực hiện"), " a.paid=1 and a.done=0");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem341_Click(object sender, EventArgs e)
        {
            frmCDVPCLS f = new frmCDVPCLS(m, s_makp, 
lan.Change_language_MessageText("Danh sách đã thực hiện"), " a.done=1");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem28_Click(object sender, EventArgs e)
        {
            frmtkthcls_n f = new frmtkthcls_n(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem30_Click(object sender, EventArgs e)
        {
            frmCls_denghi f = new frmCls_denghi(m, s_cls, "cls_thuoc", -20, lan.Change_language_MessageText("Thuốc"), this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();		
        }

        private void menuItem246_Click_1(object sender, EventArgs e)
        {
            frmCls_denghi f = new frmCls_denghi(m, s_cls, "cls_may", -21, lan.Change_language_MessageText("Máy"),this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem174_Click_1(object sender, EventArgs e)
        {
            frmCls_phanloai f = new frmCls_phanloai(m, s_cls, "cls_phanloai", -23, lan.Change_language_MessageText("Phân loại"), this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem240_Click_1(object sender, EventArgs e)
        {
            frmPhieucls f = new frmPhieucls(m, s_makp, s_userid, i_userid, s_madoituong, s_cls,s_may);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem283_Click_1(object sender, EventArgs e)
        {
            frmCls_denghi f = new frmCls_denghi(m, s_cls, "cls_vung", -24, 
lan.Change_language_MessageText("Ghi chú"), this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem287_Click_1(object sender, EventArgs e)
        {
            frmtkbsdoc f = new frmtkbsdoc(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem317_Click(object sender, EventArgs e)
        {
            frmtkclsds f = new frmtkclsds(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem316_Click(object sender, EventArgs e)
        {
            frmtkmay f = new frmtkmay(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem318_Click_2(object sender, EventArgs e)
        {
            frmtkdsctmri f = new frmtkdsctmri(m, s_cls, "rpt_dsctmri1.rpt", "a.ngay,e.ten,a.idcls",
lan.Change_language_MessageText("Thống kê danh sách theo ngày"));
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem319_Click_1(object sender, EventArgs e)
        {
            frmtkdsctmri f = new frmtkdsctmri(m, s_cls, "rpt_dsctmri2.rpt", "a.loai,a.idcls",
lan.Change_language_MessageText("Báo cáo tổng hợp theo vùng"));
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem323_Click_1(object sender, EventArgs e)
        {
            frmNhomvp f = new frmNhomvp(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem324_Click_1(object sender, EventArgs e)
        {
            frmLoaivp f = new frmLoaivp(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem325_Click_1(object sender, EventArgs e)
        {
            frmGiavp f = new frmGiavp(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem326_Click(object sender, EventArgs e)
        {
          //  frmChuyenkq f = new frmChuyenkq(m, s_cls);
            frmSuamabn_cls f = new frmSuamabn_cls(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem321_Click_1(object sender, EventArgs e)
        {
            //frmDoan f = new frmDoan(m, i_userid);
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem327_Click_1(object sender, EventArgs e)
        {
            frmTaouser f = new frmTaouser(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem343_Click(object sender, EventArgs e)
        {
            frmChondoan f = new frmChondoan(m);
            f.ShowDialog();
            if (f.l_doan != 0 && f.s_mmyy != "")
            {
                frmPhieuksk f1 = new frmPhieuksk(m, f.l_doan, f.s_mmyy,f.i_loai,f.s_ngay,i_userid,f.s_doan);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem328_Click(object sender, EventArgs e)
        {
            frmDsksk f = new frmDsksk(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem330_Click_1(object sender, EventArgs e)
        {
            frmPhieucd f = new frmPhieucd(m, s_makp, s_userid, i_userid, s_madoituong, s_cls, s_may);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem344_Click(object sender, EventArgs e)
        {
            frmPhieukq f = new frmPhieukq(m, s_makp, s_userid, i_userid, s_madoituong, s_cls, s_may);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem345_Click(object sender, EventArgs e)
        {
            frmtksocamay f = new frmtksocamay(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem346_Click(object sender, EventArgs e)
        {
            frmtksocavung f = new frmtksocavung(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem347_Click(object sender, EventArgs e)
        {
            frmCls_mau f = new frmCls_mau(m, s_cls, this.menuItem31.Visible);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem348_Click(object sender, EventArgs e)
        {
            frmdoichieuvp f = new frmdoichieuvp(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem350_Click(object sender, EventArgs e)
        {
            frmtvctmri f = new frmtvctmri(m, s_cls, "a.ngay,e.ten,a.idcls");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem351_Click(object sender, EventArgs e)
        {
            frmdoichieuvpth f = new frmdoichieuvpth(m, s_cls);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem353_Click(object sender, EventArgs e)
        {
            frmtkdsctmricd f = new frmtkdsctmricd(m, s_cls, "rpt_dsctmricd.rpt", "a.ngay,e.ten,a.idcls", 
lan.Change_language_MessageText("Thống kê danh sách theo bác sĩ chỉ định"));
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem354_Click(object sender, EventArgs e)
        {
            frmtkdsctmribv f = new frmtkdsctmribv(m, s_cls, "rpt_dsctmribv.rpt", "a.ngay,e.ten,a.idcls", 
lan.Change_language_MessageText("Thống kê danh sách theo bệnh viện chỉ định"));
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem357_Click(object sender, EventArgs e)
        {
            frmKhoacstt f = new frmKhoacstt(s_makp, m.nhom_duoc, 1, s_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem356_Click(object sender, EventArgs e)
        {
            frmChontutruc f = new frmChontutruc(s_makp, m.nhom_duoc, 1, s_nhomkho);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutructh f1 = new frmXemtutructh(f.i_nhom, f.i_makho, f.i_makp, f.mmyy, f.tenkho, f.tenkp, 1);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem359_Click(object sender, EventArgs e)
        {
            rptBcngay f = new rptBcngay(s_makp, m.nhom_duoc);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem358_Click(object sender, EventArgs e)
        {
            DuTruKhoTTB.frmChontutruc f = new DuTruKhoTTB.frmChontutruc(s_makp, m.nhom_duoc, 2, s_nhomkho);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                DuTruKhoTTB.frmXemtutructh f1 = new DuTruKhoTTB.frmXemtutructh(f.i_nhom, f.i_makho, f.i_makp, f.mmyy, f.tenkho, f.tenkp, 2);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem360_Click(object sender, EventArgs e)
        {
            frmIntoa f = new frmIntoa(m, s_makp,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem352_Click(object sender, EventArgs e)
        {

        }

        private void menuItem363_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmloaiphong f = new dllDanhmucMedisoft.frmDmloaiphong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem362_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmphong f = new dllDanhmucMedisoft.frmDmphong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem361_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmgiuong f = new dllDanhmucMedisoft.frmDmgiuong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem365_Click(object sender, EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid,1);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                frmChuyenphong f1 = new frmChuyenphong(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }			
        }

      

        private void m300_Click(object sender, EventArgs e)
        {
            ReportMedisoft.frmMain f = new ReportMedisoft.frmMain(s_userid, i_userid, s_makp, i_mabv, s_madoituong, s_nhomkho, s_cls, s_mabs);
            f.ShowDialog();
        }

        private void m303_Click(object sender, EventArgs e)
        {
            frmTimkiem f = new frmTimkiem(m);
            f.MdiParent = this;
            f.Show(); 
        }

        private void m304_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmDanhsachdutru")) return;
            frmDanhsachdutru f = new frmDanhsachdutru(s_makp.Trim(','));
            f.MdiParent = this;
            f.Show();
        }

        private void m305_Click(object sender, EventArgs e)
        {
            frmThnhiem_loai f = new frmThnhiem_loai(m);
            f.MdiParent = this;
            f.Show();
        }
        //linh them 2 file: dll: icd10.dll + icd10.xml
        private void menuItem366_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmChinhsuaicd")) return;
            icd10.frmChinhsuaicd f = new icd10.frmChinhsuaicd(s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void m307_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmBaoan")) return;
            frmChonbaoan f = new frmChonbaoan(m,s_makp);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmBaoan f1 = new frmBaoan(f.s_ngay, f.s_makp, f.i_phieu, i_userid, f.s_mmyy, f.l_duyet, "Phiếu báo ăn ngày (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, f.s_tenkp, f.s_phieu, s_mabs);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m308_Click(object sender, EventArgs e)
        {
            frmViewtd f = new frmViewtd(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void m309_Click(object sender, EventArgs e)
        {
            frmInbaoan f = new frmInbaoan(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void m312_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmLoaitrieuchung f = new dllDanhmucMedisoft.frmLoaitrieuchung(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m313_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmTrieuchung f = new dllDanhmucMedisoft.frmTrieuchung(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem300_Click(object sender, EventArgs e)
        {

        }

        private void m314_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmNhomnv f = new dllDanhmucMedisoft.frmNhomnv(m);
            f.MdiParent = this;
            f.Show();
        }

        private void i315_Click(object sender, EventArgs e)
        {
            frmThongsomay f = new frmThongsomay(m, i_userid);
            f.ShowDialog();
        }

        private void m316_Click(object sender, EventArgs e)
        {
            frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi();
            f.ShowDialog(this);
        }

        private void m317_Click(object sender, EventArgs e)
        {
            frmBienbankiemthaotuvong f = new frmBienbankiemthaotuvong(i_userid.ToString());
            f.MdiParent = this;
            f.Show();
        }

        private void m318_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmKskdoan f = new dllDanhmucMedisoft.frmKskdoan(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m319_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmLoaikham f = new dllDanhmucMedisoft.frmLoaikham(m, "m_loaikhamsk", "Giá trị mặc nhiên khám sức khỏe", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m320_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmLichmo")) return;
            string makp = s_makp, _tenkp = "";
            if (makp == "")
            {
                frmChonkhoa f1 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh);
                f1.ShowDialog();
                makp = f1.m_makp; _tenkp = f1.m_tenkp;
            }
            else
            {
                DataTable dt = m.get_data("select * from "+m.user+".btdkp_bv where loai=0 and makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ")").Tables[0];
                if (dt.Rows.Count == 0) return;
                else if (dt.Rows.Count == 1)
                {
                    makp = dt.Rows[0]["makp"].ToString();
                    _tenkp = dt.Rows[0]["tenkp"].ToString();
                }
                else
                {
                    frmChonkhoa f2 = new frmChonkhoa(m, s_makp, i_khudt, i_chinhanh);
                    f2.ShowDialog();
                    makp = f2.m_makp; _tenkp = f2.m_tenkp;
                }
            }
            if (makp == "") return;
            frmLichmo f = new frmLichmo(m, makp, _tenkp, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m321_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPttt")) return;
            frmPttt f = new frmPttt(m, "", "", "", "", "", "", "", "", "", "", "", "", i_userid, "", s_makp, s_madoituong, 0, 0, 0, 0,true);
            f.MdiParent = this;
            f.Show();
        }

        private void m322_Click(object sender, EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid,1);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                string s_mmyy = m.mmyy(f.s_ngay);
                int nhom = m.nhom_duoc;
                string sql = "select mmyy from "+m.user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                DataTable dt = m.get_data(sql).Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    s_mmyy = r["mmyy"].ToString();
                    if (m.get_data("select a.* from " + m.user + s_mmyy + ".d_tonkhoth a," + m.user + ".d_dmkho b where a.makho=b.id and b.nhom=" + nhom).Tables[0].Rows.Count > 0) break;
                }
                frmBaohiem f1 = new frmBaohiem(false, "", 7, s_mmyy, f.s_ngay, nhom, i_userid, "Đơn thuốc", 0, 0, "", "", "", f.s_tenkp, "", "", "",2, f.s_makp, "", "","", "", "",m.user+".bhyt", 1, "", true,s_madoituong,f.s_ngay,"",traituyen,"","","","",i_khudt,1);//Thuy 26.07.2012 Sửa tham so madoituong=2=đơn thuốc chỉ dùng cho đtuong thu phi
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m323_Click(object sender, EventArgs e)
        {
            frmPhieulinh_ng f = new frmPhieulinh_ng(m.nhom_duoc, "", s_makp, "", s_userid, "");
            f.MdiParent = this;
            f.Show();
        }

        private void m324_Click(object sender, EventArgs e)
        {
            frmPhieuxuat_ng f = new frmPhieuxuat_ng(m.nhom_duoc, "", s_makp, "");
            f.MdiParent = this;
            f.Show();
        }

        private void m325_Click(object sender, EventArgs e)
        {
            frmCanlamsan.frmXemCanLamSan_medi f = new frmCanlamsan.frmXemCanLamSan_medi("","","","");
            f.MdiParent = this;
            f.Show();
        }

        private void m326_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmtheodoi f = new dllDanhmucMedisoft.frmDmtheodoi(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m327_Click(object sender, EventArgs e)
        {
            frmRtieusu f = new frmRtieusu(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m328_Click(object sender, EventArgs e)
        {
            SmartCardWrite.frmWriteSmartCard f = new SmartCardWrite.frmWriteSmartCard();
            f.MdiParent = this;
            f.Show();
        }

        private void m329_Click(object sender, EventArgs e)
        {
            frmSoVV_RV_VC f = new frmSoVV_RV_VC();
            f.MdiParent = this;
            f.Show();
        }

        private void m330_Click(object sender, EventArgs e)
        {
            //txtSoBenhAn f = new txtSoBenhAn();
            //f.MdiParent = this;
            //f.Show();
        }

        private void m331_Click(object sender, EventArgs e)
        {
            frmSophongluu f = new frmSophongluu(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m333_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmthe f = new dllDanhmucMedisoft.frmDmthe(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem28_Click_1(object sender, EventArgs e)
        {
            frmsuabhyt f = new frmsuabhyt(i_userid,m.bAdmin(i_userid));
            f.MdiParent = this;
            f.Show();
        }

        private void m335_Click(object sender, EventArgs e)
        {
            SMS.ServerMain f = new SMS.ServerMain();
            f.ShowDialog();
        }

        private void m336_Click(object sender, EventArgs e)
        {
            frmPbacsy f = new frmPbacsy(m, s_mabs);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuRight_Bv_Click(object sender, EventArgs e)
        {
            frmRight_BV f = new frmRight_BV(m, f_get_menu());
            f.MdiParent = this;
            f.Show();
        }

        private void m337_Click(object sender, EventArgs e)
        {
            frmGiayravien f = new frmGiayravien(m, s_makp, i_userid, 4);
            f.MdiParent = this;
            f.Show();
        }

        private void m338_Click(object sender, EventArgs e)
        {
            frmCongno f = new frmCongno(m, s_makp, s_madoituong, i_userid, 2);
            f.MdiParent = this;
            f.Show();
        }


        private void m339_Click(object sender, System.EventArgs e)
        {
            frmTkketqua f = new frmTkketqua(m);
            f.MdiParent = this;
            f.Show();
        }

        private void m340_Click(object sender, EventArgs e)
        {
            frmDuyetcls f = new frmDuyetcls(m, s_makp, s_madoituong, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem28_Click_2(object sender, EventArgs e)
        {
            if (IsLoaded("frmHSBenhan")) return;
            frmChonkp f = new frmChonkp(m, s_makp, s_mabs);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                switch (f.i_maba)
                {
                    case 1:
                        frmHSBenhan_BNO f1 = new frmHSBenhan_BNO(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f1.MdiParent = this;
                        f1.Show();
                        break;
                    case 2:
                        frmHSBenhan_BNH f2 = new frmHSBenhan_BNH(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f2.MdiParent = this;
                        f2.Show();
                        break;
                    case 4:
                        frmHSBenhan_BPH f4 = new frmHSBenhan_BPH(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f4.MdiParent = this;
                        f4.Show();
                        break;
                    case 5:
                        frmHSBenhan_BSA f5 = new frmHSBenhan_BSA(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f5.MdiParent = this;
                        f5.Show();
                        break;
                    case 6:
                        frmHSBenhan_BSO f6 = new frmHSBenhan_BSO(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f6.MdiParent = this;
                        f6.Show();
                        break;
                    case 13:
                        frmHSBenhan_BUN f13 = new frmHSBenhan_BUN(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f13.MdiParent = this;
                        f13.Show();
                        break;
                    case 15:
                        frmHSBenhan_BTA f15 = new frmHSBenhan_BTA(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f15.MdiParent = this;
                        f15.Show();
                        break;
                    default:
                        frmHSBenhan f11 = new frmHSBenhan(m, f.s_makp, f.s_tenkp, f.i_phong, f.s_mabs, i_userid, s_nhomkho, s_userid, b_soluutru, b_sovaovien, bAdmin, i_loai, f.i_maba);
                        f11.MdiParent = this;
                        f11.Show();
                        break;
                }
            }
        }

        private void m341_Click(object sender, EventArgs e)
        {
            frmCongno f = new frmCongno(m,"", s_madoituong, i_userid, 4);
            f.MdiParent = this;
            f.Show();
        }

        private void m343_Click(object sender, EventArgs e)
        {
            frmSuadoituong_ct f1 = new frmSuadoituong_ct(m, s_makp, 3);
            f1.MdiParent = this;
            f1.Show();
        }

        private void m344_Click(object sender, EventArgs e)
        {
            frmSuadoituong_tu f = new frmSuadoituong_tu(m, s_makp, 1, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m345_Click(object sender, EventArgs e)
        {
            frmGiayxn f = new frmGiayxn(m, s_makp, i_userid, "", 0);
            f.MdiParent = this;
            f.Show();
        }

        private void m346_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmhuyet f = new dllDanhmucMedisoft.frmDmhuyet(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m347_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmBsnghi f = new dllDanhmucMedisoft.frmBsnghi(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m348_Click(object sender, EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid, 2);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmChidinh_k f1 = new dllvpkhoa_chidinh.frmChidinh_k(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m349_Click(object sender, EventArgs e)
        {
            frmGiayravien f = new frmGiayravien(m, s_makp, i_userid, 2);
            f.MdiParent = this;
            f.Show();
        }

        private void m350_Click(object sender, EventArgs e)
        {
            frmChoduyet f = new frmChoduyet(m.nhom_duoc);
            f.MdiParent = this;
            f.Show();
        }

        private void m351_Click(object sender, EventArgs e)
        {
            dllvpkhoa_chidinh.frmChonthongsotu f = new dllvpkhoa_chidinh.frmChonthongsotu(m, s_makp, i_userid, 1, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmTamung f1 = new dllvpkhoa_chidinh.frmTamung(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, 0, 2, bAdmin);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m353_Click(object sender, EventArgs e)
        {
            dllvpkhoa_chidinh.frmChonthongsotu f = new dllvpkhoa_chidinh.frmChonthongsotu(m, s_makp, i_userid, 0, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmTamung f1 = new dllvpkhoa_chidinh.frmTamung(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, 0, 1, bAdmin);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m352_Click(object sender, EventArgs e)
        {
            dllvpkhoa_chidinh.frmChonthongsotu f = new dllvpkhoa_chidinh.frmChonthongsotu(m, "99", i_userid, 4, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmTamung f1 = new dllvpkhoa_chidinh.frmTamung(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, 0, 4, bAdmin);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m354_Click(object sender, EventArgs e)
        {
            frmInchidinh f = new frmInchidinh(m, s_makp);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem28_Click_3(object sender, EventArgs e)
        {
            rptBieu f = new rptBieu(m, lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện"), true, "dm_11", 111);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem28_Click_4(object sender, EventArgs e)
        {
            string user = m.user;
            string mmyy=m.mmyy(m.ngayhienhanh_server.Substring(0,10));
            string xxx = user + mmyy;
            string asql = "select message,computer,tables,ngayud from " + user + ".error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + user + ".v_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + user + ".d_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + xxx + ".error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + xxx + ".v_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + xxx + ".d_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + xxx + ".xn_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            asql += "union all ";
            asql += "select message,computer,tables,ngayud from " + xxx + ".cdha_error where to_char(ngayud,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";


            frmTVuser f = new frmTVuser(m, asql);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem61_Click_1(object sender, EventArgs e)
        {
            DLLBCTonghop.frmQuanlybenhvien f = new DLLBCTonghop.frmQuanlybenhvien("bn_treemenu");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem174_Click_2(object sender, EventArgs e)
        {
            frmTuchoi f = new frmTuchoi(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem240_Click(object sender, EventArgs e)
        {
            dllvpkhoa_chidinh.frmChonthongsotu f = new dllvpkhoa_chidinh.frmChonthongsotu(m, s_makp, i_userid, 3, i_khudt);
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                dllvpkhoa_chidinh.frmTamung f1 = new dllvpkhoa_chidinh.frmTamung(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid, 1, 3, bAdmin);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem292_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh06")) return;
            //dllBaocao_BYT.frmKh06 f = new dllBaocao_BYT.frmKh06(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh08")) return;
            dllVuKeHoach.frmKh08 f = new dllVuKeHoach.frmKh08(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem271_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmKh01")) return;
            //dllBaocao_BYT.frmKh01 f = new dllBaocao_BYT.frmKh01(m, s_userid, i_userid, i_mabv);
            dllVuKeHoach.frmKh01 f = new dllVuKeHoach.frmKh01(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem283_Click_2(object sender, EventArgs e)
        {
            if (IsLoaded("frmKh02")) return;
            //dllBaocao_BYT.frmKh02 f = new dllBaocao_BYT.frmKh02(m, s_userid, i_userid, i_mabv);
            dllVuKeHoach.frmKh02 f = new dllVuKeHoach.frmKh02(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem287_Click_2(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh031")) return;
            //dllBaocao_BYT.frmKh031 f = new dllBaocao_BYT.frmKh031(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh03")) return;
            dllVuKeHoach.frmKh03 f = new dllVuKeHoach.frmKh03(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem288_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh032")) return;
            //dllBaocao_BYT.frmKh032 f = new dllBaocao_BYT.frmKh032(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh05")) return;
            dllVuKeHoach.frmKh05 f = new dllVuKeHoach.frmKh05(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem290_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh04")) return;
            ////dllBaocao_BYT.frmKh04 f = new dllBaocao_BYT.frmKh04(m, s_userid, i_userid, i_mabv);
            //dllVuKeHoach.frmKh04 f = new dllVuKeHoach.frmKh04(m, s_userid, i_userid, i_mabv);
            //f.MdiParent = this;
            //f.Show();
            dllVuKeHoach.frmKh032 f = new dllVuKeHoach.frmKh032(m, s_userid, i_userid,i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem291_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh05")) return;
            //dllBaocao_BYT.frmKh05 f = new dllBaocao_BYT.frmKh05(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh06")) return;
            dllVuKeHoach.frmKh06 f = new dllVuKeHoach.frmKh06(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem293_Click_1(object sender, EventArgs e)
        {
            if (IsLoaded("frmKh07")) return;
            //dllBaocao_BYT.frmKh07 f = new dllBaocao_BYT.frmKh07(m, s_userid, i_userid, i_mabv);
            dllVuKeHoach.frmKh07 f = new dllVuKeHoach.frmKh07(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem294_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh08")) return;
            //dllBaocao_BYT.frmKh08 f = new dllBaocao_BYT.frmKh08(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh123")) return;
            dllVuKeHoach.frmKh123 f = new dllVuKeHoach.frmKh123(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem295_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh09")) return;
            //dllBaocao_BYT.frmKh09 f = new dllBaocao_BYT.frmKh09(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh10")) return;
            dllVuKeHoach.frmKh10 f = new dllVuKeHoach.frmKh10(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem296_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh10")) return;
            //dllBaocao_BYT.frmKh10 f = new dllBaocao_BYT.frmKh10(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh124")) return;
            dllVuKeHoach.frmKh124 f = new dllVuKeHoach.frmKh124(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem297_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh11")) return;
            //dllBaocao_BYT.frmKh11 f = new dllBaocao_BYT.frmKh11(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh132")) return;
            dllVuKeHoach.frmKh132 f = new dllVuKeHoach.frmKh132(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem298_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh121")) return;
            //dllBaocao_BYT.frmKh121 f = new dllBaocao_BYT.frmKh121(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh11")) return;
            dllVuKeHoach.frmKh11 f = new dllVuKeHoach.frmKh11(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem299_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh122")) return;
            //dllBaocao_BYT.frmKh122 f = new dllBaocao_BYT.frmKh122(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh09")) return;
            dllVuKeHoach.frmKh09 f = new dllVuKeHoach.frmKh09(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem315_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh13")) return;
            //dllBaocao_BYT.frmKh13 f = new dllBaocao_BYT.frmKh13(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh133")) return;
            dllVuKeHoach.frmKh133 f = new dllVuKeHoach.frmKh133(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem316_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh141")) return;
            //dllBaocao_BYT.frmKh141 f = new dllBaocao_BYT.frmKh141(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh144")) return;
            dllVuKeHoach.frmKh144 f = new dllVuKeHoach.frmKh144(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem317_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh142")) return;
            //dllBaocao_BYT.frmKh142 f = new dllBaocao_BYT.frmKh142(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh121")) return;
            dllVuKeHoach.frmKh121 f = new dllVuKeHoach.frmKh121(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem318_Click(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, "Dân số, đơn vị hành chính, trạm y tế xã", false, "khdm_01", 1);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Dân số và đơn vị hành chính", false, "khdm_01", 1);//kh_dm_01
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem319_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, "Tình hình thu chi ngân sách y tế", false, "khdm_02", 2);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình sinh tử trong tỉnh", false, "kh_dm_02", 2);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem320_Click(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("Cơ sở và giường bệnh quận huyện"), false, "khdm_031", 3);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình thu, chi ngân sách ngành y tế địa phương", false, "kh_dm_03", 3);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem321_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, "Tình hình y tế xã - phường", false, "khdm_032", 32);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình cơ sở y tế và giường bệnh", false, "kh_dm_05", 5);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem322_Click(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, (" Tình hình nhân lực y tế toàn huyện"), false, "khdm_04", 4);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình y tế xã phường", false, "khdm_032", 32);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem323_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("Hoạt động chăm sóc bà mẹ"), false, "khdm_05", 5);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình nhân lực y tế toàn tỉnh/thànhphố", false, "khdm_06", 6);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem324_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("Tình hình mắc chết do tai biến sản khoa"), false, "khdm_06", 6);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình hoạt động BHYT", false, "khdm_08", 8);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem325_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("7.Bieu 07- Hoạt động khám chữa phụ khoa và nạo phá thai"), false, "khdm_07", 7);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình sản xuất kinh doanh dược", false, "khdm_07", 7);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem326_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("8.Bieu 08 - Hoạt động cung cấp dịch vụ kế hoạch hóa gia đình"), false, "khdm_08", 8);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình đào tạo nhân lực y tế địa phương", false, "khdm_123", 123);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem328_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("9. Bieu 09- Tình hình sức khỏe tre em"), false, "khdm_09", 9);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động chăm sóc bà mẹ", false, "khdm_10", 10);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem329_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("10. Bieu 10- Hoạt động tiêm chủn phòng 10 bệnh cho trẻ em"), false, "khdm_10", 10);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình mắc chết do tai biến sản khoa", false, "kh_dm_124", 124);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem330_Click_2(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("11.Bieu 11 Mắc chết các bệnh có vacxin phòng ngừa"), false, "khdm_11", 11);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động khám chữa phụ khoa và nạo phá thai", false, "khdm_132", 132);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem331_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("12.1 Bieu 12.1 Hoạt động khám chữa bệnh"), false, "khdm_121", 121);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động cung cấp dịch vụ kế hoạch hóa gia đình", false, "khdm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem332_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("12.2 Bieu 12.2 Hoạt động khám chữa bênh"), false, "khdm_122", 122);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình sức khỏe trẻ em", false, "khdm_09", 9);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem333_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("13.1 Bieu 13 Hoạt động phòng chống bệnh xã hội"), false, "khdm_13", 131);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động tiêm chủng phòng 10 bệnh cho trẻ em", false, "khdm_133", 133);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem334_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("14.1 Bieu 14.1 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_141", 141);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình mắc chết các bệnh có vắc xin phòng ngừa", false, "khdm_144", 144);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem335_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("14.2 Bieu 14.2 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_142", 142);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Báo cáo hoạt động khám chữa bệnh", false, "khdm_121", 121);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem336_Click_1(object sender, EventArgs e)
        {
            //if (IsLoaded("frmKh143")) return;
            //dllBaocao_BYT.frmKh143 f = new dllBaocao_BYT.frmKh143(m, s_userid, i_userid, i_mabv);
            if (IsLoaded("frmKh122")) return;
            dllVuKeHoach.frmKh122 f = new dllVuKeHoach.frmKh122(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem343_Click_1(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieukh f = new dllBaocao_BYT.rptBieukh(m, ("14.3 Bieu 14.3 Tình hình mắc chết bệnh truyền nhiễm gây dịch và  bệnh quan trọng"), false, "khdm_143", 143);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động khám chữa bệnh (Tiếp)", false, "khdm_122", 122);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem344_Click_1(object sender, EventArgs e)
        {            
            dllBaocao_BYT.frmTaosolieu f = new dllBaocao_BYT.frmTaosolieu(m);
            f.ShowDialog();
        }

        private void menuItem345_Click_1(object sender, EventArgs e)
        {
            frmChonkham f = new frmChonkham(m, s_makp, i_userid, 1);
            f.ShowDialog();
            if (f.s_makp != "")
            {
                frmThemphong f1 = new frmThemphong(m, f.s_ngay, f.s_makp, f.s_tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void f_get_khudieutri()
        {
            s_khudt = m.f_get_khudt(i_userid);
            string sql = " select * from " + m.user + ".dmkhudt ";
            if (s_khudt.Trim().Trim(',') != "") sql += " where id in(" + s_khudt.Trim().Trim(',') + ")";
            DataSet lds = m.get_data(sql);
            if (lds == null | lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count == 0) i_khudt = 0;            
            else if (lds.Tables[0].Rows.Count == 1)
            {
                i_khudt = int.Parse(lds.Tables[0].Rows[0]["id"].ToString());
            }
            else
            {
                frmChonkhudt f1 = new frmChonkhudt(lds.Tables[0]);
                f1.ShowDialog();
                i_khudt = f1.i_khudt;
            }
            
        }

        private void menuItem346_Click_1(object sender, EventArgs e)
        {
            if (IsLoaded("frmBieu11")) return;
            if (m.Mabv.Substring(0, 3) == "701")
            {
                dllBaocao_BYT.frmBieu11_18_1 f1 = new dllBaocao_BYT.frmBieu11_18_1(m, s_userid, i_userid, i_mabv);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                dllBaocao_BYT.frmBieu11_1 f2 = new dllBaocao_BYT.frmBieu11_1(m, s_userid, i_userid, i_mabv);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem347_Click_1(object sender, EventArgs e)
        {
            dllBaocao_BYT.rptBieu f = new dllBaocao_BYT.rptBieu(m, lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện"), true, "dm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void f_capnhap_length_id()
        {
            DataSet lds = new DataSet();
            string user = m.user, asql = "", s_mmyy = m.mmyy(m.Ngayhienhanh);
            string s_gio_modify = "30/04/2011 08:00";
            if (m.bQuanly_theokhu || m.bQuanly_Theo_Chinhanh)
            {
                asql = "select ngaygio from " + user + s_mmyy + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
                lds = m.get_data(asql);
                if (lds == null || lds.Tables.Count <= 0)
                {
                    asql = " drop table " + user + s_mmyy + ".datao ";
                    m.execute_data(asql);
                    asql = " create table " + user + s_mmyy + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                    m.execute_data(asql);
                }
                else if( lds.Tables[0].Rows.Count <= 0)
                {
                    asql = "insert into " + user + s_mmyy + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                    m.execute_data(asql);
                    m.f_tangid_medibv_mmyy(s_mmyy);
                }
            }
            s_gio_modify = "01/05/2011 08:00";
            asql = "select ngaygio from " + user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 )
            {
                asql = " drop table " + user + ".datao ";
                m.execute_data(asql);
                asql = " create table " + user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);

            }
            else if (lds.Tables[0].Rows.Count <= 0)
            {
                asql = "insert into " + user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                m.execute_data(asql);

                //
                //goi ham tang chieu dai id
                m.f_tangid_medibv();
            }
            //else if (lds.Tables[0].Rows.Count > 0) return;

            s_gio_modify = "21/06/2011 01:00";
            asql = "select ngaygio from " + user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " drop table " + user + ".datao ";
                m.execute_data(asql);
                asql = " create table " + user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);
            }
            else if (lds.Tables[0].Rows.Count <= 0)
            {
                asql = "insert into " + user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                m.execute_data(asql);


                //goi ham tang chieu dai id
                //m.f_tangmabn_10kytu();
            }

            s_gio_modify = "21/05/2011 08:00";
            asql = "select ngaygio from " + user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0 )
            {
                asql = " drop table " + user + ".datao ";
                m.execute_data(asql);
                asql = " create table " + user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);
            }
            else if (lds.Tables[0].Rows.Count <= 0)
            {
                asql = "insert into " + user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                m.execute_data(asql);

                
                //goi ham tang chieu dai id
                m.f_tangmabv_9kytu();
            }
            //else if (lds.Tables[0].Rows.Count > 0) return;
            //

            if (m.bQuanly_theokhu || m.bQuanly_Theo_Chinhanh )
            {
                s_gio_modify = "23/05/2011 08:00";
                asql = "select ngaygio from " + user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
                lds = m.get_data(asql);
                if (lds == null || lds.Tables.Count <= 0 )
                {
                    asql = " drop table " + user + ".datao ";
                    m.execute_data(asql);
                    asql = " create table " + user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                    m.execute_data(asql);
                    //
                }
                else if (lds.Tables[0].Rows.Count <= 0)
                {
                    asql = "insert into " + user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                    m.execute_data(asql);
                    //goi ham tang chieu dai id
                    m.f_tangmakp_3kytu();
                }
                else if (lds.Tables[0].Rows.Count > 0) return;
                
            }
        }

        private void menuItem348_Click_1(object sender, EventArgs e)
        {
            
        }

        private void menuItem349_Click(object sender, EventArgs e)
        {
            frmTktiemchung f = new frmTktiemchung(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem_dmcn_Click(object sender, EventArgs e)
        {
            frmdmchinhanh f = new frmdmchinhanh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem350_Click_1(object sender, EventArgs e)
        {
            frmdmphongthuchiencls f = new frmdmphongthuchiencls(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem351_Click_1(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmdmlydokham f = new dllDanhmucMedisoft.frmdmlydokham();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem353_Click_1(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmdmlydodungtuyen f = new dllDanhmucMedisoft.frmdmlydodungtuyen();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem354_Click_1(object sender, EventArgs e)
        {
            frmDmgiatribt f = new frmDmgiatribt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem369_Click(object sender, EventArgs e)
        {
            frmCapthe_uudai f = new frmCapthe_uudai(m,i_userid,i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem370_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmtheuudai f = new dllDanhmucMedisoft.frmDmtheuudai();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem371_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmdmloaithebhyt f = new dllDanhmucMedisoft.frmdmloaithebhyt();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem372_Click(object sender, EventArgs e)
        {
            frmTyleuudai_bhyt f = new frmTyleuudai_bhyt(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem373_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmLoaikham f = new dllDanhmucMedisoft.frmLoaikham(m, "m_loaikhambadt", "Giá trị mặc nhiên bệnh án điện tử", i_userid,true);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem374_Click(object sender, EventArgs e)
        {
            frmDuyetcv f = new frmDuyetcv(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem375_Click(object sender, EventArgs e)
        {
            frmKhaibaothoigian f = new frmKhaibaothoigian();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem378_Click(object sender, EventArgs e)
        {

            Medisoft_ksk.frmkhamsuckhoe_8 f = new Medisoft_ksk.frmkhamsuckhoe_8(m, s_makp, s_userid, i_userid, s_mabs, bAdmin, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem379_Click(object sender, EventArgs e)
        {
            frmGiaythuphanungthuoc f = new frmGiaythuphanungthuoc(m, "", "", "", "", false,i_userid,3);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem380_Click(object sender, EventArgs e)
        {
            tiemchung.frmtc f = new tiemchung.frmtc();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem381_Click(object sender, EventArgs e)
        {
            //tiemchung.frmPhieutiemchung f = new tiemchung.frmPhieutiemchung(m, "", "", "", "", false, i_userid, 3, i_chinhanh);
            //f.MdiParent = this;
            //f.Show();

            string makp_right = "";
            if (s_mabs.Trim() != "")
                makp_right = m.get_data("select makp from " + m.user + ".dlogin where id=" + i_userid + "").Tables[0].Rows[0]["makp"].ToString();
            int makp;
            if (makp_right != "") makp = makp_right.IndexOf(",");
            else makp = 1;
            frmChonpk f1 = new frmChonpk(m, makp_right, s_mabs, "01", i_chinhanh);
            if (makp >= 1)
            {
                f1.ShowDialog();
                if (f1.s_makp == "") return;
            }

            tiemchung.frmPhieutiemchung f = new tiemchung.frmPhieutiemchung(m, "", "", "", "", false, i_userid, 3, i_chinhanh, f1.s_makp);
            f.ShowInTaskbar = false;
            f.ShowDialog();
        }
        private void menuItem382_Click(object sender, EventArgs e)
        {
            frmTktiemchung f = new frmTktiemchung(m);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDutrututruc_Click(object sender, EventArgs e)
        {
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            frmChonkhodt f = new frmChonkhodt(d, m.nhom_duoc.ToString(), "");
            f.ShowDialog();
            if (f.i_makp != -1 && f.i_matutruc != -1)
            {
                frmDutrucstt dutru = new frmDutrucstt(d, f.s_ngay, f.i_makho, f.s_tenkho, f.i_manguon, f.i_nhom, f.s_mmyy, i_userid, f.i_makp, f.i_matutruc, f.s_tenkhoa);
                dutru.MdiParent = this;
                dutru.Show();
            }
        }

        private void mnuQuanlyVacxin_Click(object sender, EventArgs e)
        {
            tiemchung.frmSoquanlyVaccin f = new frmSoquanlyVaccin(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem384_Click(object sender, EventArgs e)
        {
            tiemchung.frmTheodoinhietdotulanh f = new frmTheodoinhietdotulanh(b_admin, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem384_Click_1(object sender, EventArgs e)
        {
            frmOutput f = new frmOutput(m, m.Ngayhienhanh);
            f.Show();
            f.ShowInTaskbar = false;
        }

        private void menuItem386_Click(object sender, EventArgs e)
        {
            tiemchung.frmBBHuyVaccin f = new tiemchung.frmBBHuyVaccin(m, i_userid, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem385_Click(object sender, EventArgs e)
        {
            tiemchung.frmSoquanlyTiem f = new tiemchung.frmSoquanlyTiem(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem387_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmdmloaithebhyt_chinhsach f = new dllDanhmucMedisoft.frmdmloaithebhyt_chinhsach();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem388_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoantrathua")) return;
            int loai = 3;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, true, s_nhomkho, i_khudt,this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHoantrathua f1 = new frmHoantrathua(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Hoàn trả thừa theo khoa " + f.s_tennhom.Trim() + " (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, false, m.iSudungthuoc, f.s_tenkp, f.s_phieu, f.i_somay,true);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuItem389_Click(object sender, EventArgs e)//gam 29/11/2011
        {
            if (IsLoaded("frmHaophi")) return;
            int loai = 4;
            frmChonthongso f = new frmChonthongso(m, 1, loai, 0, s_makp, false, s_nhomkho, i_khudt,this.i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmHaophi f1 = new frmHaophi(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù hao phí " + f.s_tennhom.Trim() + " theo khoa/phòng (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.iSudungthuoc, f.s_manguon, true, f.s_tenkp, f.s_phieu, f.i_somay);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem390_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmBieu11")) return;
            //if (m.Mabv.Substring(0, 3) == "701")
            //{
            //    dllBaocao_BYT.frmBieu11_18_1 f1 = new dllBaocao_BYT.frmBieu11_18_1(m, s_userid, i_userid, i_mabv);
            //    f1.MdiParent = this;
            //    f1.Show();
            //}
            //else
            //{
            //    dllBaocao_BYT.frmBieu11_1 f2 = new dllBaocao_BYT.frmBieu11_1(m, s_userid, i_userid, i_mabv);
            //    f2.MdiParent = this;
            //    f2.Show();
            //}
            if (IsLoaded("frmBieu11")) return;
            dllVuKeHoach.frmKh131 f = new dllVuKeHoach.frmKh131(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem391_Click(object sender, EventArgs e)
        {
            //dllBaocao_BYT.rptBieu f = new dllBaocao_BYT.rptBieu(m, lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện"), true, "dm_11", 11);
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Hoạt động phòng chống bệnh xã hội", false, "khdm_131", 131);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem392_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmKh141")) return;
            dllVuKeHoach.frmKh141 f = new dllVuKeHoach.frmKh141(m, s_userid, i_userid, i_mabv);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem393_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmBieu11")) return;
            if (m.Mabv.Substring(0, 3) == "701")
            {
                dllBaocao_BYT.frmBieu11_18_1 f1 = new dllBaocao_BYT.frmBieu11_18_1(m, s_userid, i_userid, i_mabv);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                dllBaocao_BYT.frmBieu11_1 f2 = new dllBaocao_BYT.frmBieu11_1(m, s_userid, i_userid, i_mabv);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem394_Click(object sender, EventArgs e)
        {
            dllVuKeHoach.rptBieukh f = new dllVuKeHoach.rptBieukh(m, "Tình hình mắc chết bệnh truyền nhiễm gây dịch và bệnh quan trọng", false, "khdm_141", 141);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem395_Click(object sender, EventArgs e)
        {
            dllBaocao_BYT.rptBieu f = new dllBaocao_BYT.rptBieu(m, lan.Change_language_MessageText("Tình hình bệnh tật, tử vong tại bệnh viện"), true, "dm_11", 11);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem396_Click(object sender, EventArgs e)
        {
            frmBiavkh f = new frmBiavkh(m);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem397_Click(object sender, EventArgs e)
        {
            frmPhanungthuoccohai f = new frmPhanungthuoccohai(m, "", "", "", i_userid, "", "", 0, 0, "", 0, 0, 0, 0);
            f.MdiParent = this;
            f.Show();
            //f.ShowDialog();
        }
        //Thuy 16.05.2012
        private void menuItem398_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmdiadiem f = new dllDanhmucMedisoft.frmDmdiadiem(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem399_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmbophanbithuong f = new dllDanhmucMedisoft.frmDmbophanbithuong(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem400_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmdienbien f = new dllDanhmucMedisoft.frmDmdienbien(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem401_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmnguyennhan f = new dllDanhmucMedisoft.frmDmnguyennhan(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem402_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmxutri f = new dllDanhmucMedisoft.frmDmxutri(m, i_userid);
            f.MdiParent = this;
            f.Show();
        }
        //Thuy 25.05.2012
        private void menuItem403_Click(object sender, EventArgs e)
        {
            LibDuoc.AccessData d = new LibDuoc.AccessData();
            frmCongkhai f = new frmCongkhai(d, s_makp, this.menuItem31.Visible, 4, s_userid, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuNangchieudaikey_Click(object sender, EventArgs e)
        {
            string s_sql = "select schema_name,view_name from sys.dba_views where lower(owner)='" + m.User_database.ToLower() + "' and lower(schema_name) like '" + m.user.ToLower() + "%'";
            foreach (DataRow r in m.get_data(s_sql).Tables[0].Rows)
            {
                m.execute("drop view " + r["schema_name"].ToString() + "." + r["view_name"].ToString());
            }
            m.modify_schema();
            MessageBox.Show("Tạo thành công");
        }
        //Thuy 22.06.2012
        private void mnuChuyensolieu_Click(object sender, EventArgs e)
        {
            dllvpkhoa_chidinh.frmChuyenDataksk f = new dllvpkhoa_chidinh.frmChuyenDataksk("");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem404_Click(object sender, EventArgs e)
        {
            frmChuyenpk_theochinhanh f = new frmChuyenpk_theochinhanh(m,s_makp,i_userid,i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem405_Click(object sender, EventArgs e)
        {
            frmTaouser f = new frmTaouser(m, i_userid);
            f.Taomoi = true;
            f.ShowDialog();
        }

        private void menuItem406_Click(object sender, EventArgs e)
        {
            LibVienphi.AccessData v = new LibVienphi.AccessData();
            dllvpkhoa_chidinh.Kiemsoatdv f1 = new dllvpkhoa_chidinh.Kiemsoatdv(m,"", s_makp,"", i_userid, v.iNoitru,1, b_admin);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem407_Click(object sender, EventArgs e)
        {
            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, s_makp + ",", false, s_nhomkho, i_khudt, i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, "", f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay,"", s_madoituong);
                f1.ShowDialog(this);
            }
        }

        private void menuItem408_Click(object sender, EventArgs e)
        {
            frmChonthongso f = new frmChonthongso(m, 1, 2, 0, s_makp + ",", false, s_nhomkho, i_khudt, i_userid);//linh 16102012
            f.ShowDialog(this);
            if (f.s_makp != "")
            {
                frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon,"", f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, "", s_madoituong);
                f1.ShowDialog(this);
            }		
        }

        private void menuItem409_Click(object sender, EventArgs e)
        {
            frmManHinhLCD frm = new frmManHinhLCD();
            frm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManHinhLCD_DSBN.IsClose = true;
            frmLCD_laocai.IsClose = true;
        }

        private void menuItem410_Click(object sender, EventArgs e)
        {
            dllDanhmucMedisoft.frmDmbsgioithieu frm = new dllDanhmucMedisoft.frmDmbsgioithieu(m, i_userid);
            frm.Show();
            frm.MdiParent = this;
        }

        private void menuItem73_Click(object sender, EventArgs e)
        {

        }

        private void menuItem411_Click(object sender, EventArgs e)
        {
            frmCapstt frm = new frmCapstt(m);
            frm.ShowDialog();
        }

        private void menuItem412_Click(object sender, EventArgs e)
        {
            string tmp_makp = s_makp.Trim().Trim(',');
            if (s_makp.Trim().Trim(',') == "" || s_makp.Trim().Trim(',').Length > 2)
            {
                frmChonpk f = new frmChonpk(m, s_makp, "", "", i_chinhanh);
                f.ShowDialog();
                if (f.s_makp == "") return;
                tmp_makp = f.s_makp;
            }
            frmXacnhan_Thuchien_dmkt f1 = new frmXacnhan_Thuchien_dmkt(tmp_makp, s_mabs, i_userid, m.ngayhienhanh_server.Substring(0, 10), bAdmin);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem413_Click(object sender, EventArgs e)
        {
            frmUpdateDuLieuGoc f = new frmUpdateDuLieuGoc(m, i_userid);
            f.Taomoi = true;
            f.ShowDialog();
        }

      
	}
}