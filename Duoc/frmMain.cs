using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Duoc
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private LibMedi.AccessData m;
        private string user, s_userid = "", s_right = "", s_mmyy, s_ngay, s_makho, s_makp, s_manhom, s_loaint, s_loaikhac, s_nhomkho = "", s_khudt = "";
        private int i_userid = 0, i_nhomkho, i_loaikho, i_khudt = 0, i_chinhanh = 0;
		private bool b_giaban,b_admin,b_thuhoi;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
        private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem33;
        private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem45;
        private System.Windows.Forms.MenuItem menuItem46;
        private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem menuItem59;
		private System.Windows.Forms.MenuItem menuItem60;
		private System.Windows.Forms.MenuItem menuItem61;
		private System.Windows.Forms.MenuItem menuItem62;
		private System.Windows.Forms.MenuItem menuItem64;
		private System.Windows.Forms.MenuItem menuItem65;
		private System.Windows.Forms.MenuItem menuItem66;
		private System.Windows.Forms.MenuItem menuItem67;
		private System.Windows.Forms.MenuItem menuItem73;
		private System.Windows.Forms.MenuItem menuItem74;
		private System.Windows.Forms.MenuItem menuItem75;
		private System.Windows.Forms.MenuItem menuItem76;
		private System.Windows.Forms.MenuItem menuItem77;
		private System.Windows.Forms.MenuItem menuItem78;
		private System.Windows.Forms.MenuItem menuItem79;
		private System.Windows.Forms.MenuItem menuItem80;
		private System.Windows.Forms.MenuItem menuItem81;
		private System.Windows.Forms.MenuItem menuItem82;
        private System.Windows.Forms.MenuItem menuItem83;
		private System.Windows.Forms.MenuItem menuItem85;
        private System.Windows.Forms.MenuItem menuItem86;
		private System.Windows.Forms.MenuItem menuItem89;
		private System.Windows.Forms.MenuItem menuItem90;
		private System.Windows.Forms.MenuItem menuItem91;
        private System.Windows.Forms.MenuItem menuItem92;
        private System.Windows.Forms.MenuItem menuItem102;
		private System.Windows.Forms.MenuItem menuItem104;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem105;
		private System.Windows.Forms.MenuItem menuItem106;
        private System.Windows.Forms.MenuItem menuItem107;
		private System.Windows.Forms.MenuItem menuItem63;
		private System.Windows.Forms.MenuItem menuItem58;
        private System.Windows.Forms.MenuItem menuItem68;
		private System.Windows.Forms.MenuItem menuItem109;
        private System.Windows.Forms.MenuItem menuItem110;
		private System.Windows.Forms.MenuItem menuItem112;
		private System.Windows.Forms.MenuItem menuItem115;
		private System.Windows.Forms.MenuItem menuItem116;
		private System.Windows.Forms.MenuItem menuItem118;
        private System.Windows.Forms.MenuItem menuItem119;
		private System.Windows.Forms.MenuItem menuItem121;
		private System.Windows.Forms.MenuItem menuItem122;
		private System.Windows.Forms.MenuItem menuItem123;
		private System.Windows.Forms.MenuItem menuItem124;
        private System.Windows.Forms.MenuItem menuItem126;
		private System.Windows.Forms.MenuItem menuItem130;
		private System.Windows.Forms.MenuItem menuItem132;
        private System.Windows.Forms.MenuItem menuItem135;
		private System.Windows.Forms.MenuItem menuItem138;
		private System.Windows.Forms.MenuItem menuItem139;
		private System.Windows.Forms.MenuItem menuItem140;
		private System.Windows.Forms.MenuItem menuItem142;
		private System.Windows.Forms.MenuItem menuItem146;
		private System.Windows.Forms.MenuItem menuItem147;
		private System.Windows.Forms.MenuItem menuItem149;
		private System.Windows.Forms.MenuItem menuItem150;
		private System.Windows.Forms.MenuItem menuItem151;
		private System.Windows.Forms.MenuItem menuItem152;
		private System.Windows.Forms.MenuItem menuItem153;
        private System.Windows.Forms.MenuItem menuItem156;
		private System.Windows.Forms.MenuItem menuItem158;
		private System.Windows.Forms.MenuItem menuItem154;
        private System.Windows.Forms.MenuItem menuItem155;
		private System.Windows.Forms.MenuItem menuItem166;
		private System.Windows.Forms.MenuItem menuItem167;
		private System.Windows.Forms.MenuItem menuItem168;
		private System.Windows.Forms.MenuItem menuItem170;
		private System.Windows.Forms.MenuItem menuItem171;
		private System.Windows.Forms.MenuItem menuItem172;
		private System.Windows.Forms.MenuItem menuItem173;
		private System.Windows.Forms.MenuItem menuItem174;
		private System.Windows.Forms.MenuItem menuItem175;
		private System.Windows.Forms.MenuItem menuItem176;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem127;
		private System.Windows.Forms.MenuItem menuItem129;
        private System.Windows.Forms.MenuItem menuItem143;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem133;
		private System.Windows.Forms.MenuItem menuItem134;
		private System.Windows.Forms.MenuItem menuItem148;
		private System.Windows.Forms.MenuItem menuItem178;
		private System.Windows.Forms.MenuItem menuItem117;
		private System.Windows.Forms.MenuItem menuItem144;
		private System.Windows.Forms.MenuItem menuItem145;
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
		private System.Windows.Forms.MenuItem menuItem69;
		private System.Windows.Forms.MenuItem menuItem70;
		private System.Windows.Forms.MenuItem menuItem72;
		private System.Windows.Forms.MenuItem menuItem95;
		private System.Windows.Forms.MenuItem menuItem96;
		private System.Windows.Forms.MenuItem menuItem97;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem93;
		private System.Windows.Forms.MenuItem menuItem71;
		private System.Windows.Forms.MenuItem menuItem94;
		private System.Windows.Forms.MenuItem menuItem98;
		private System.Windows.Forms.MenuItem menuItem99;
		private System.Windows.Forms.MenuItem menuItem100;
		private System.Windows.Forms.MenuItem menuItem125;
		private System.Windows.Forms.MenuItem menuItem131;
		private System.Windows.Forms.MenuItem menuItem141;
		private System.Windows.Forms.MenuItem menuItem161;
		private System.Windows.Forms.MenuItem menuItem162;
		private System.Windows.Forms.MenuItem menuItem163;
		private System.Windows.Forms.MenuItem menuItem164;
		private System.Windows.Forms.MenuItem menuItem180;
        private System.Windows.Forms.MenuItem menuItem190;
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
		private System.Windows.Forms.MenuItem menuItem215;
		private System.Windows.Forms.MenuItem menuItem214;
		private System.Windows.Forms.MenuItem menuItem216;
		private System.Windows.Forms.MenuItem menuItem217;
		private System.Windows.Forms.MenuItem menuItem218;
		private System.Windows.Forms.MenuItem menuItem219;
		private System.Windows.Forms.MenuItem menuItem220;
		private System.Windows.Forms.MenuItem menuItem221;
		private System.Windows.Forms.MenuItem menuItem222;
        private System.Windows.Forms.MenuItem menuItem223;
		private System.Windows.Forms.MenuItem menuItem225;
		private System.Windows.Forms.MenuItem menuItem113;
		private System.Windows.Forms.MenuItem menuItem159;
		private System.Windows.Forms.MenuItem menuItem114;
		private System.Windows.Forms.MenuItem menuItem160;
		private System.Windows.Forms.MenuItem menuItem169;
		private System.Windows.Forms.MenuItem menuItem226;
		private System.Windows.Forms.MenuItem menuItem227;
        private System.Windows.Forms.MenuItem menuItem228;
        private MenuItem menuItem136;
        private MenuItem menuItem229;
        private MenuItem menuItem230;
        private MenuItem menuItem231;
        private MenuItem menuItem232;
        private MenuItem menuItem233;
        private MenuItem menuItem234;
        private MenuItem menuItem47;
        private MenuItem menuItem48;
        private MenuItem menuItem49;
        private MenuItem menuItem50;
        private MenuItem menuItem52;
        private MenuItem menuItem55;
        private MenuItem menuItem56;
        private MenuItem menuItem84;
        private MenuItem menuItem108;
        private MenuItem menuItem120;
        private MenuItem menuItem137;
        private MenuItem menuItem157;
        private MenuItem menuItem165;
        private MenuItem menuItem177;
        private MenuItem m188;
        private MenuItem m189;
        private MenuItem m190;
        private MenuItem m191;
        private MenuItem m192;
        private MenuItem m193;
        private MenuItem m194;
        private MenuItem m195;
        private MenuItem mnuRight_Bv;
        private MenuItem m197;
        private MenuItem m198;
        private MenuItem m199;
        private MenuItem m200;
        private MenuItem m201;
        private MenuItem m202;
        private MenuItem m203;
        private MenuItem m204;
        private MenuItem m205;
        private MenuItem m206;
        private MenuItem m207;
        private MenuItem menuItem21;
        private MenuItem menuItem32;
        private MenuItem menuItem35;
        private MenuItem menuItem53;
        private MenuItem menuItem88;
        private MenuItem menuItem103;
        private MenuItem menuItem111;
        private MenuItem menuItem191;
        private MenuItem menuItem224;
        private MenuItem menuItem235;
        private MenuItem menuItem236;
        private MenuItem menuItem237;
        private MenuItem mnuPhatthuoc;
        private MenuItem menuItem87;
        private MenuItem m208;
        private MenuItem menuItem101;
        private MenuItem menuItem128;
        private MenuItem menuItem238;
        private MenuItem menuItem239;
        private IContainer components;
        private string __userid = "";
        private string __ngaylv = "";
        private string __ngaysl = "";

        public frmMain(string v_userid, string v_ngaylv, string v_ngaysl)
        {
            __userid = v_userid;
            __ngaylv = v_ngaylv;
            __ngaysl = v_ngaysl;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			if (System.IO.File.Exists(d.Thongso("hinh").Trim()))
				this.BackgroundImage=Image.FromFile(d.Thongso("hinh").Trim());
            this.Text = d.Msg;// +" 2007";
			this.menuItem17.Text = "&2. About "+d.Msg;
            lan.Read_MainMenu_to_Xml(this.Name.ToString() + "mainMenu1", this.mainMenu1);
            lan.Change_mainmenu_to_English(this.Name.ToString() + "mainMenu1", this.mainMenu1);
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
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem82 = new System.Windows.Forms.MenuItem();
            this.m191 = new System.Windows.Forms.MenuItem();
            this.menuItem199 = new System.Windows.Forms.MenuItem();
            this.menuItem198 = new System.Windows.Forms.MenuItem();
            this.menuItem200 = new System.Windows.Forms.MenuItem();
            this.menuItem135 = new System.Windows.Forms.MenuItem();
            this.menuItem147 = new System.Windows.Forms.MenuItem();
            this.menuItem98 = new System.Windows.Forms.MenuItem();
            this.menuItem128 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.menuItem80 = new System.Windows.Forms.MenuItem();
            this.menuItem87 = new System.Windows.Forms.MenuItem();
            this.menuItem73 = new System.Windows.Forms.MenuItem();
            this.menuItem77 = new System.Windows.Forms.MenuItem();
            this.menuItem76 = new System.Windows.Forms.MenuItem();
            this.menuItem153 = new System.Windows.Forms.MenuItem();
            this.menuItem126 = new System.Windows.Forms.MenuItem();
            this.menuItem74 = new System.Windows.Forms.MenuItem();
            this.menuItem75 = new System.Windows.Forms.MenuItem();
            this.menuItem78 = new System.Windows.Forms.MenuItem();
            this.menuItem177 = new System.Windows.Forms.MenuItem();
            this.menuItem79 = new System.Windows.Forms.MenuItem();
            this.menuItem168 = new System.Windows.Forms.MenuItem();
            this.menuItem170 = new System.Windows.Forms.MenuItem();
            this.menuItem171 = new System.Windows.Forms.MenuItem();
            this.menuItem172 = new System.Windows.Forms.MenuItem();
            this.m203 = new System.Windows.Forms.MenuItem();
            this.m208 = new System.Windows.Forms.MenuItem();
            this.menuItem173 = new System.Windows.Forms.MenuItem();
            this.menuItem174 = new System.Windows.Forms.MenuItem();
            this.menuItem175 = new System.Windows.Forms.MenuItem();
            this.menuItem176 = new System.Windows.Forms.MenuItem();
            this.m204 = new System.Windows.Forms.MenuItem();
            this.menuItem136 = new System.Windows.Forms.MenuItem();
            this.menuItem229 = new System.Windows.Forms.MenuItem();
            this.menuItem230 = new System.Windows.Forms.MenuItem();
            this.menuItem231 = new System.Windows.Forms.MenuItem();
            this.m205 = new System.Windows.Forms.MenuItem();
            this.menuItem112 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem109 = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem165 = new System.Windows.Forms.MenuItem();
            this.menuItem205 = new System.Windows.Forms.MenuItem();
            this.menuItem92 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.menuItem95 = new System.Windows.Forms.MenuItem();
            this.menuItem96 = new System.Windows.Forms.MenuItem();
            this.menuItem97 = new System.Windows.Forms.MenuItem();
            this.menuItem237 = new System.Windows.Forms.MenuItem();
            this.menuItem115 = new System.Windows.Forms.MenuItem();
            this.menuItem238 = new System.Windows.Forms.MenuItem();
            this.menuItem116 = new System.Windows.Forms.MenuItem();
            this.mnuPhatthuoc = new System.Windows.Forms.MenuItem();
            this.menuItem118 = new System.Windows.Forms.MenuItem();
            this.menuItem142 = new System.Windows.Forms.MenuItem();
            this.menuItem167 = new System.Windows.Forms.MenuItem();
            this.menuItem166 = new System.Windows.Forms.MenuItem();
            this.menuItem111 = new System.Windows.Forms.MenuItem();
            this.menuItem191 = new System.Windows.Forms.MenuItem();
            this.menuItem224 = new System.Windows.Forms.MenuItem();
            this.menuItem235 = new System.Windows.Forms.MenuItem();
            this.menuItem236 = new System.Windows.Forms.MenuItem();
            this.menuItem239 = new System.Windows.Forms.MenuItem();
            this.menuItem81 = new System.Windows.Forms.MenuItem();
            this.menuItem83 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.menuItem207 = new System.Windows.Forms.MenuItem();
            this.m188 = new System.Windows.Forms.MenuItem();
            this.m193 = new System.Windows.Forms.MenuItem();
            this.menuItem88 = new System.Windows.Forms.MenuItem();
            this.menuItem139 = new System.Windows.Forms.MenuItem();
            this.menuItem204 = new System.Windows.Forms.MenuItem();
            this.m201 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem105 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem99 = new System.Windows.Forms.MenuItem();
            this.menuItem100 = new System.Windows.Forms.MenuItem();
            this.menuItem192 = new System.Windows.Forms.MenuItem();
            this.menuItem197 = new System.Windows.Forms.MenuItem();
            this.menuItem156 = new System.Windows.Forms.MenuItem();
            this.menuItem202 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem58 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem119 = new System.Windows.Forms.MenuItem();
            this.menuItem151 = new System.Windows.Forms.MenuItem();
            this.menuItem152 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem149 = new System.Windows.Forms.MenuItem();
            this.menuItem160 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.menuItem214 = new System.Windows.Forms.MenuItem();
            this.menuItem216 = new System.Windows.Forms.MenuItem();
            this.menuItem130 = new System.Windows.Forms.MenuItem();
            this.menuItem132 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem59 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem106 = new System.Windows.Forms.MenuItem();
            this.menuItem121 = new System.Windows.Forms.MenuItem();
            this.menuItem227 = new System.Windows.Forms.MenuItem();
            this.menuItem208 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.m194 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem129 = new System.Windows.Forms.MenuItem();
            this.menuItem143 = new System.Windows.Forms.MenuItem();
            this.menuItem221 = new System.Windows.Forms.MenuItem();
            this.menuItem94 = new System.Windows.Forms.MenuItem();
            this.menuItem164 = new System.Windows.Forms.MenuItem();
            this.menuItem209 = new System.Windows.Forms.MenuItem();
            this.menuItem210 = new System.Windows.Forms.MenuItem();
            this.menuItem169 = new System.Windows.Forms.MenuItem();
            this.menuItem226 = new System.Windows.Forms.MenuItem();
            this.menuItem127 = new System.Windows.Forms.MenuItem();
            this.menuItem141 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem117 = new System.Windows.Forms.MenuItem();
            this.menuItem161 = new System.Windows.Forms.MenuItem();
            this.menuItem211 = new System.Windows.Forms.MenuItem();
            this.menuItem212 = new System.Windows.Forms.MenuItem();
            this.menuItem213 = new System.Windows.Forms.MenuItem();
            this.menuItem215 = new System.Windows.Forms.MenuItem();
            this.menuItem232 = new System.Windows.Forms.MenuItem();
            this.menuItem233 = new System.Windows.Forms.MenuItem();
            this.menuItem234 = new System.Windows.Forms.MenuItem();
            this.menuItem218 = new System.Windows.Forms.MenuItem();
            this.menuItem219 = new System.Windows.Forms.MenuItem();
            this.menuItem220 = new System.Windows.Forms.MenuItem();
            this.menuItem133 = new System.Windows.Forms.MenuItem();
            this.menuItem134 = new System.Windows.Forms.MenuItem();
            this.menuItem148 = new System.Windows.Forms.MenuItem();
            this.menuItem178 = new System.Windows.Forms.MenuItem();
            this.menuItem125 = new System.Windows.Forms.MenuItem();
            this.menuItem131 = new System.Windows.Forms.MenuItem();
            this.menuItem163 = new System.Windows.Forms.MenuItem();
            this.menuItem180 = new System.Windows.Forms.MenuItem();
            this.menuItem190 = new System.Windows.Forms.MenuItem();
            this.menuItem201 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.m195 = new System.Windows.Forms.MenuItem();
            this.menuItem108 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem84 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem217 = new System.Windows.Forms.MenuItem();
            this.menuItem162 = new System.Windows.Forms.MenuItem();
            this.menuItem120 = new System.Windows.Forms.MenuItem();
            this.menuItem123 = new System.Windows.Forms.MenuItem();
            this.menuItem196 = new System.Windows.Forms.MenuItem();
            this.menuItem124 = new System.Windows.Forms.MenuItem();
            this.menuItem206 = new System.Windows.Forms.MenuItem();
            this.menuItem203 = new System.Windows.Forms.MenuItem();
            this.menuItem222 = new System.Windows.Forms.MenuItem();
            this.menuItem158 = new System.Windows.Forms.MenuItem();
            this.menuItem223 = new System.Windows.Forms.MenuItem();
            this.m200 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem89 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem63 = new System.Windows.Forms.MenuItem();
            this.menuItem107 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem90 = new System.Windows.Forms.MenuItem();
            this.menuItem91 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem138 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem122 = new System.Windows.Forms.MenuItem();
            this.menuItem155 = new System.Windows.Forms.MenuItem();
            this.menuItem193 = new System.Windows.Forms.MenuItem();
            this.menuItem194 = new System.Windows.Forms.MenuItem();
            this.menuItem195 = new System.Windows.Forms.MenuItem();
            this.m192 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem103 = new System.Windows.Forms.MenuItem();
            this.menuItem144 = new System.Windows.Forms.MenuItem();
            this.menuItem145 = new System.Windows.Forms.MenuItem();
            this.menuItem179 = new System.Windows.Forms.MenuItem();
            this.menuItem93 = new System.Windows.Forms.MenuItem();
            this.menuItem181 = new System.Windows.Forms.MenuItem();
            this.menuItem184 = new System.Windows.Forms.MenuItem();
            this.menuItem185 = new System.Windows.Forms.MenuItem();
            this.menuItem114 = new System.Windows.Forms.MenuItem();
            this.menuItem186 = new System.Windows.Forms.MenuItem();
            this.menuItem182 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem187 = new System.Windows.Forms.MenuItem();
            this.menuItem188 = new System.Windows.Forms.MenuItem();
            this.menuItem189 = new System.Windows.Forms.MenuItem();
            this.menuItem183 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem86 = new System.Windows.Forms.MenuItem();
            this.menuItem154 = new System.Windows.Forms.MenuItem();
            this.menuItem140 = new System.Windows.Forms.MenuItem();
            this.m197 = new System.Windows.Forms.MenuItem();
            this.menuItem85 = new System.Windows.Forms.MenuItem();
            this.menuItem225 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.mnuRight_Bv = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem102 = new System.Windows.Forms.MenuItem();
            this.menuItem104 = new System.Windows.Forms.MenuItem();
            this.menuItem110 = new System.Windows.Forms.MenuItem();
            this.menuItem146 = new System.Windows.Forms.MenuItem();
            this.menuItem150 = new System.Windows.Forms.MenuItem();
            this.menuItem113 = new System.Windows.Forms.MenuItem();
            this.menuItem159 = new System.Windows.Forms.MenuItem();
            this.menuItem228 = new System.Windows.Forms.MenuItem();
            this.menuItem137 = new System.Windows.Forms.MenuItem();
            this.menuItem157 = new System.Windows.Forms.MenuItem();
            this.m189 = new System.Windows.Forms.MenuItem();
            this.m190 = new System.Windows.Forms.MenuItem();
            this.menuItem101 = new System.Windows.Forms.MenuItem();
            this.m198 = new System.Windows.Forms.MenuItem();
            this.m202 = new System.Windows.Forms.MenuItem();
            this.m199 = new System.Windows.Forms.MenuItem();
            this.m206 = new System.Windows.Forms.MenuItem();
            this.m207 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem81,
            this.menuItem7,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem82,
            this.m191,
            this.menuItem199,
            this.menuItem198,
            this.menuItem200,
            this.menuItem135,
            this.menuItem147,
            this.menuItem98,
            this.menuItem128});
            this.menuItem1.MergeOrder = 900;
            this.menuItem1.Text = "&Nhập kho";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "1. Phiếu nhập kho";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem82
            // 
            this.menuItem82.Index = 1;
            this.menuItem82.MergeOrder = 1;
            this.menuItem82.Text = "2. Phiếu tái nhập kho";
            this.menuItem82.Click += new System.EventHandler(this.menuItem82_Click);
            // 
            // m191
            // 
            this.m191.Index = 2;
            this.m191.MergeOrder = 191;
            this.m191.Text = "3. Phiếu khoa hoàn trả";
            this.m191.Click += new System.EventHandler(this.m191_Click);
            // 
            // menuItem199
            // 
            this.menuItem199.Index = 3;
            this.menuItem199.Text = "-";
            // 
            // menuItem198
            // 
            this.menuItem198.Index = 4;
            this.menuItem198.MergeOrder = 2;
            this.menuItem198.Text = "4. Phiếu nhập kho (số lượng)";
            this.menuItem198.Click += new System.EventHandler(this.menuItem198_Click);
            // 
            // menuItem200
            // 
            this.menuItem200.Index = 5;
            this.menuItem200.MergeOrder = 3;
            this.menuItem200.Text = "5. Phiếu nhập kho (số tiền)";
            this.menuItem200.Click += new System.EventHandler(this.menuItem200_Click);
            // 
            // menuItem135
            // 
            this.menuItem135.Index = 6;
            this.menuItem135.Text = "-";
            // 
            // menuItem147
            // 
            this.menuItem147.Index = 7;
            this.menuItem147.MergeOrder = 4;
            this.menuItem147.Text = "6. Công nợ";
            this.menuItem147.Click += new System.EventHandler(this.menuItem147_Click);
            // 
            // menuItem98
            // 
            this.menuItem98.Index = 8;
            this.menuItem98.MergeOrder = 5;
            this.menuItem98.Text = "7. Phiếu đề nghị thanh toán";
            this.menuItem98.Click += new System.EventHandler(this.menuItem98_Click_1);
            // 
            // menuItem128
            // 
            this.menuItem128.Index = 9;
            this.menuItem128.MergeOrder = 10800;
            this.menuItem128.Text = "8. Phiếu nhập kho từ chi nhánh khác";
            this.menuItem128.Click += new System.EventHandler(this.menuItem128_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem37,
            this.menuItem80,
            this.menuItem87,
            this.menuItem73,
            this.menuItem77,
            this.menuItem76,
            this.menuItem153,
            this.menuItem126,
            this.menuItem74,
            this.menuItem75,
            this.menuItem78,
            this.menuItem177,
            this.menuItem79,
            this.menuItem168,
            this.menuItem173,
            this.menuItem136,
            this.menuItem112,
            this.menuItem38,
            this.menuItem39,
            this.menuItem109,
            this.menuItem41,
            this.menuItem42,
            this.menuItem165,
            this.menuItem205,
            this.menuItem92,
            this.menuItem72,
            this.menuItem115,
            this.menuItem238,
            this.menuItem118,
            this.menuItem142,
            this.menuItem167,
            this.menuItem166,
            this.menuItem111,
            this.menuItem191,
            this.menuItem224,
            this.menuItem235,
            this.menuItem236,
            this.menuItem239});
            this.menuItem2.MergeOrder = 901;
            this.menuItem2.Text = "&Xuất kho";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 0;
            this.menuItem37.MergeOrder = 6;
            this.menuItem37.Text = "1. Phiếu xuất chuyển kho";
            this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
            // 
            // menuItem80
            // 
            this.menuItem80.Index = 1;
            this.menuItem80.MergeOrder = 7;
            this.menuItem80.Text = "2.1 Duyệt cấp theo kho dự trù";
            this.menuItem80.Click += new System.EventHandler(this.menuItem80_Click);
            // 
            // menuItem87
            // 
            this.menuItem87.Index = 2;
            this.menuItem87.MergeOrder = 395;
            this.menuItem87.Text = "2.2 Duyệt dự trù kho của các khoa";
            this.menuItem87.Click += new System.EventHandler(this.menuItem87_Click);
            // 
            // menuItem73
            // 
            this.menuItem73.Index = 3;
            this.menuItem73.Text = "-";
            // 
            // menuItem77
            // 
            this.menuItem77.Index = 4;
            this.menuItem77.MergeOrder = 8;
            this.menuItem77.Text = "3. Duyệt cấp theo người bệnh";
            this.menuItem77.Click += new System.EventHandler(this.menuItem77_Click);
            // 
            // menuItem76
            // 
            this.menuItem76.Index = 5;
            this.menuItem76.MergeOrder = 9;
            this.menuItem76.Text = "4. Duyệt bù cơ số tủ trực theo người bệnh";
            this.menuItem76.Click += new System.EventHandler(this.menuItem76_Click);
            // 
            // menuItem153
            // 
            this.menuItem153.Index = 6;
            this.menuItem153.MergeOrder = 10;
            this.menuItem153.Text = "5. Duyệt bù cơ số tủ trực theo người bệnh (cộng dồn số lượng)";
            this.menuItem153.Click += new System.EventHandler(this.menuItem153_Click);
            // 
            // menuItem126
            // 
            this.menuItem126.Index = 7;
            this.menuItem126.MergeOrder = 11;
            this.menuItem126.Text = "6. Duyệt bù cơ số tủ trực theo hao phí";
            this.menuItem126.Click += new System.EventHandler(this.menuItem126_Click);
            // 
            // menuItem74
            // 
            this.menuItem74.Index = 8;
            this.menuItem74.MergeOrder = 13;
            this.menuItem74.Text = "7. Duyệt cấp hao phí theo khoa/phòng";
            this.menuItem74.Click += new System.EventHandler(this.menuItem74_Click);
            // 
            // menuItem75
            // 
            this.menuItem75.Index = 9;
            this.menuItem75.MergeOrder = 12;
            this.menuItem75.Text = "9. Duyệt hoàn trả theo người bệnh";
            this.menuItem75.Click += new System.EventHandler(this.menuItem75_Click);
            // 
            // menuItem78
            // 
            this.menuItem78.Index = 10;
            this.menuItem78.MergeOrder = 14;
            this.menuItem78.Text = "10. Duyệt hoàn trả thừa trong khoa/phòng";
            this.menuItem78.Click += new System.EventHandler(this.menuItem78_Click);
            // 
            // menuItem177
            // 
            this.menuItem177.Index = 11;
            this.menuItem177.MergeOrder = 15;
            this.menuItem177.Text = "11. Đánh dấu những phiếu đã phát thuốc";
            this.menuItem177.Click += new System.EventHandler(this.menuItem177_Click);
            // 
            // menuItem79
            // 
            this.menuItem79.Index = 12;
            this.menuItem79.Text = "-";
            // 
            // menuItem168
            // 
            this.menuItem168.Index = 13;
            this.menuItem168.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem170,
            this.menuItem171,
            this.menuItem172,
            this.m203,
            this.m208});
            this.menuItem168.MergeOrder = 902;
            this.menuItem168.Text = "12. Bảo hiểm";
            this.menuItem168.Click += new System.EventHandler(this.menuItem168_Click);
            // 
            // menuItem170
            // 
            this.menuItem170.Index = 0;
            this.menuItem170.MergeOrder = 16;
            this.menuItem170.Text = "12.1. Phiếu xuất";
            this.menuItem170.Click += new System.EventHandler(this.menuItem170_Click);
            // 
            // menuItem171
            // 
            this.menuItem171.Index = 1;
            this.menuItem171.MergeOrder = 17;
            this.menuItem171.Text = "12.2. Phát thuốc";
            this.menuItem171.Click += new System.EventHandler(this.menuItem171_Click);
            // 
            // menuItem172
            // 
            this.menuItem172.Index = 2;
            this.menuItem172.MergeOrder = 18;
            this.menuItem172.Text = "12.3. Viện phí";
            this.menuItem172.Click += new System.EventHandler(this.menuItem172_Click);
            // 
            // m203
            // 
            this.m203.Index = 3;
            this.m203.MergeOrder = 203;
            this.m203.Text = "12.4. Xem phiếu";
            this.m203.Click += new System.EventHandler(this.m203_Click);
            // 
            // m208
            // 
            this.m208.Index = 4;
            this.m208.MergeOrder = 492;
            this.m208.Text = "12.5 Hoàn tất viện phí cho bệnh nhân bỏ về";
            this.m208.Click += new System.EventHandler(this.m208_Click);
            // 
            // menuItem173
            // 
            this.menuItem173.Index = 14;
            this.menuItem173.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem174,
            this.menuItem175,
            this.menuItem176,
            this.m204});
            this.menuItem173.MergeOrder = 903;
            this.menuItem173.Text = "13. Không bảo hiểm (Phòng khám)";
            // 
            // menuItem174
            // 
            this.menuItem174.Index = 0;
            this.menuItem174.MergeOrder = 19;
            this.menuItem174.Text = "13.1. Phiếu xuất";
            this.menuItem174.Click += new System.EventHandler(this.menuItem174_Click);
            // 
            // menuItem175
            // 
            this.menuItem175.Index = 1;
            this.menuItem175.MergeOrder = 20;
            this.menuItem175.Text = "13.2. Phát thuốc";
            this.menuItem175.Click += new System.EventHandler(this.menuItem175_Click);
            // 
            // menuItem176
            // 
            this.menuItem176.Index = 2;
            this.menuItem176.MergeOrder = 21;
            this.menuItem176.Text = "13.3. Viện phí";
            this.menuItem176.Click += new System.EventHandler(this.menuItem176_Click);
            // 
            // m204
            // 
            this.m204.Index = 3;
            this.m204.MergeOrder = 204;
            this.m204.Text = "13.4. Xem phiếu";
            this.m204.Click += new System.EventHandler(this.m204_Click);
            // 
            // menuItem136
            // 
            this.menuItem136.Index = 15;
            this.menuItem136.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem229,
            this.menuItem230,
            this.menuItem231,
            this.m205});
            this.menuItem136.MergeOrder = 904;
            this.menuItem136.Text = "14. Điều trị ngoại trú";
            this.menuItem136.Click += new System.EventHandler(this.menuItem136_Click);
            // 
            // menuItem229
            // 
            this.menuItem229.Index = 0;
            this.menuItem229.MergeOrder = 22;
            this.menuItem229.Text = "14.1. Phiếu xuất";
            this.menuItem229.Click += new System.EventHandler(this.menuItem229_Click);
            // 
            // menuItem230
            // 
            this.menuItem230.Index = 1;
            this.menuItem230.MergeOrder = 23;
            this.menuItem230.Text = "14.2. Phát thuốc";
            this.menuItem230.Click += new System.EventHandler(this.menuItem230_Click);
            // 
            // menuItem231
            // 
            this.menuItem231.Index = 2;
            this.menuItem231.MergeOrder = 24;
            this.menuItem231.Text = "14.3. Viện phí";
            this.menuItem231.Click += new System.EventHandler(this.menuItem231_Click);
            // 
            // m205
            // 
            this.m205.Index = 3;
            this.m205.MergeOrder = 205;
            this.m205.Text = "14.4. Xem phiếu";
            this.m205.Click += new System.EventHandler(this.m205_Click);
            // 
            // menuItem112
            // 
            this.menuItem112.Index = 16;
            this.menuItem112.Text = "-";
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 17;
            this.menuItem38.MergeOrder = 25;
            this.menuItem38.Text = "15. Phiếu lĩnh";
            this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 18;
            this.menuItem39.MergeOrder = 26;
            this.menuItem39.Text = "16. Phiếu hoàn trả";
            this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
            // 
            // menuItem109
            // 
            this.menuItem109.Index = 19;
            this.menuItem109.MergeOrder = 27;
            this.menuItem109.Text = "17. Phiếu xuất tủ trực";
            this.menuItem109.Click += new System.EventHandler(this.menuItem109_Click);
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 20;
            this.menuItem41.MergeOrder = 28;
            this.menuItem41.Text = "18. Phiếu xuất ngoại trú";
            this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 21;
            this.menuItem42.MergeOrder = 29;
            this.menuItem42.Text = "19. Phiếu xuất khác";
            this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
            // 
            // menuItem165
            // 
            this.menuItem165.Index = 22;
            this.menuItem165.MergeOrder = 30;
            this.menuItem165.Text = "20. Phiếu xuất hoàn trả nhà cung cấp";
            this.menuItem165.Click += new System.EventHandler(this.menuItem165_Click);
            // 
            // menuItem205
            // 
            this.menuItem205.Index = 23;
            this.menuItem205.MergeOrder = 31;
            this.menuItem205.Text = "21. Phiếu xuất Implants";
            this.menuItem205.Click += new System.EventHandler(this.menuItem205_Click);
            // 
            // menuItem92
            // 
            this.menuItem92.Index = 24;
            this.menuItem92.Text = "-";
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 25;
            this.menuItem72.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem95,
            this.menuItem96,
            this.menuItem97,
            this.menuItem237});
            this.menuItem72.MergeOrder = 905;
            this.menuItem72.Text = "22. Cơ số tủ trực";
            // 
            // menuItem95
            // 
            this.menuItem95.Index = 0;
            this.menuItem95.MergeOrder = 32;
            this.menuItem95.Text = "22.1. Bổ sung";
            this.menuItem95.Click += new System.EventHandler(this.menuItem95_Click_1);
            // 
            // menuItem96
            // 
            this.menuItem96.Index = 1;
            this.menuItem96.MergeOrder = 33;
            this.menuItem96.Text = "22.2. Hoàn trả";
            this.menuItem96.Click += new System.EventHandler(this.menuItem96_Click_1);
            // 
            // menuItem97
            // 
            this.menuItem97.Index = 2;
            this.menuItem97.MergeOrder = 34;
            this.menuItem97.Text = "22.3. Thu hồi";
            this.menuItem97.Click += new System.EventHandler(this.menuItem97_Click);
            // 
            // menuItem237
            // 
            this.menuItem237.Index = 3;
            this.menuItem237.MergeOrder = 341;
            this.menuItem237.Text = "22.4. Xuất chuyển tủ trực";
            this.menuItem237.Click += new System.EventHandler(this.menuItem237_Click);
            // 
            // menuItem115
            // 
            this.menuItem115.Index = 26;
            this.menuItem115.Text = "-";
            // 
            // menuItem238
            // 
            this.menuItem238.Index = 27;
            this.menuItem238.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem116,
            this.mnuPhatthuoc});
            this.menuItem238.MergeOrder = 123;
            this.menuItem238.Text = "23. Xuất bán nhà thuốc";
            this.menuItem238.Click += new System.EventHandler(this.menuItem238_Click_1);
            // 
            // menuItem116
            // 
            this.menuItem116.Index = 0;
            this.menuItem116.MergeOrder = 35;
            this.menuItem116.Text = "23.1 Phiếu xuất bán";
            this.menuItem116.Click += new System.EventHandler(this.menuItem116_Click);
            // 
            // mnuPhatthuoc
            // 
            this.mnuPhatthuoc.Index = 1;
            this.mnuPhatthuoc.MergeOrder = 394;
            this.mnuPhatthuoc.Text = "23.2 Phát thuốc";
            this.mnuPhatthuoc.Click += new System.EventHandler(this.mnuPhatthuoc_Click);
            // 
            // menuItem118
            // 
            this.menuItem118.Index = 28;
            this.menuItem118.MergeOrder = 36;
            this.menuItem118.Text = "24. Phiếu trả thuốc";
            this.menuItem118.Click += new System.EventHandler(this.menuItem118_Click);
            // 
            // menuItem142
            // 
            this.menuItem142.Index = 29;
            this.menuItem142.MergeOrder = 37;
            this.menuItem142.Text = "26. Phiếu xuất chuyển nguồn";
            this.menuItem142.Click += new System.EventHandler(this.menuItem142_Click);
            // 
            // menuItem167
            // 
            this.menuItem167.Index = 30;
            this.menuItem167.MergeOrder = 38;
            this.menuItem167.Text = "27. Phiếu quyết toán vay";
            this.menuItem167.Click += new System.EventHandler(this.menuItem167_Click);
            // 
            // menuItem166
            // 
            this.menuItem166.Index = 31;
            this.menuItem166.MergeOrder = 39;
            this.menuItem166.Text = "28. Phiếu xuất vay";
            this.menuItem166.Click += new System.EventHandler(this.menuItem166_Click);
            // 
            // menuItem111
            // 
            this.menuItem111.Index = 32;
            this.menuItem111.MergeOrder = 2040;
            this.menuItem111.Text = "29. Phiếu xuất chuyển kho qua chi nhánh khác";
            this.menuItem111.Click += new System.EventHandler(this.menuItem111_Click);
            // 
            // menuItem191
            // 
            this.menuItem191.Index = 33;
            this.menuItem191.MergeOrder = 2041;
            this.menuItem191.Text = "30. Phiếu nhập từ kho chi nhánh";
            this.menuItem191.Click += new System.EventHandler(this.menuItem191_Click);
            // 
            // menuItem224
            // 
            this.menuItem224.Index = 34;
            this.menuItem224.MergeOrder = 391;
            this.menuItem224.Text = "31. Tổng hợp các phiếu dự trù từ các chi nhánh";
            this.menuItem224.Click += new System.EventHandler(this.menuItem224_Click_1);
            // 
            // menuItem235
            // 
            this.menuItem235.Index = 35;
            this.menuItem235.MergeOrder = 392;
            this.menuItem235.Text = "32. Lập kế hoạch mua hàng gợi ý";
            this.menuItem235.Click += new System.EventHandler(this.menuItem235_Click);
            // 
            // menuItem236
            // 
            this.menuItem236.Index = 36;
            this.menuItem236.MergeOrder = 393;
            this.menuItem236.Text = "33. Lập kế hoạch mua hàng thực tế";
            this.menuItem236.Click += new System.EventHandler(this.menuItem236_Click);
            // 
            // menuItem239
            // 
            this.menuItem239.Index = 37;
            this.menuItem239.MergeOrder = 23400;
            this.menuItem239.Text = "34. Duyệt toa thuốc chương trình";
            this.menuItem239.Click += new System.EventHandler(this.menuItem239_Click_1);
            // 
            // menuItem81
            // 
            this.menuItem81.Index = 2;
            this.menuItem81.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem83,
            this.menuItem53,
            this.menuItem207,
            this.m188,
            this.m193,
            this.menuItem88,
            this.menuItem139,
            this.menuItem204,
            this.m201});
            this.menuItem81.MergeOrder = 906;
            this.menuItem81.Text = "&Dự trù";
            this.menuItem81.Click += new System.EventHandler(this.menuItem81_Click);
            // 
            // menuItem83
            // 
            this.menuItem83.Index = 0;
            this.menuItem83.MergeOrder = 40;
            this.menuItem83.Text = "Phiếu dự trù kho cấp";
            this.menuItem83.Click += new System.EventHandler(this.menuItem83_Click);
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 1;
            this.menuItem53.MergeOrder = 3002;
            this.menuItem53.Text = "Dự trù thuốc theo ngày";
            this.menuItem53.Click += new System.EventHandler(this.menuItem53_Click);
            // 
            // menuItem207
            // 
            this.menuItem207.Index = 2;
            this.menuItem207.MergeOrder = 41;
            this.menuItem207.Text = "Bảng dự trù thuốc tháng";
            this.menuItem207.Click += new System.EventHandler(this.menuItem207_Click);
            // 
            // m188
            // 
            this.m188.Index = 3;
            this.m188.MergeOrder = 188;
            this.m188.Text = "Bảng dự trù theo kho";
            this.m188.Click += new System.EventHandler(this.m188_Click);
            // 
            // m193
            // 
            this.m193.Index = 4;
            this.m193.MergeOrder = 193;
            this.m193.Text = "Bảng dự trù theo năm";
            this.m193.Click += new System.EventHandler(this.m193_Click);
            // 
            // menuItem88
            // 
            this.menuItem88.Index = 5;
            this.menuItem88.MergeOrder = 925;
            this.menuItem88.Text = "Duyệt dự trù mua thuốc";
            this.menuItem88.Click += new System.EventHandler(this.menuItem88_Click);
            // 
            // menuItem139
            // 
            this.menuItem139.Index = 6;
            this.menuItem139.MergeOrder = 42;
            this.menuItem139.Text = "Kinh phí mua sắm trong năm";
            this.menuItem139.Click += new System.EventHandler(this.menuItem139_Click);
            // 
            // menuItem204
            // 
            this.menuItem204.Index = 7;
            this.menuItem204.MergeOrder = 43;
            this.menuItem204.Text = "Bảng tổng hợp dự trù";
            this.menuItem204.Click += new System.EventHandler(this.menuItem204_Click);
            // 
            // m201
            // 
            this.m201.Index = 8;
            this.m201.MergeOrder = 201;
            this.m201.Text = "Danh mục thuốc trúng thầu";
            this.m201.Click += new System.EventHandler(this.m201_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem45,
            this.menuItem46,
            this.menuItem60,
            this.menuItem40,
            this.menuItem127,
            this.menuItem232,
            this.menuItem218,
            this.menuItem133,
            this.menuItem108,
            this.menuItem120});
            this.menuItem7.MergeOrder = 907;
            this.menuItem7.Text = "&Báo cáo";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 0;
            this.menuItem45.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem105,
            this.menuItem51,
            this.menuItem99,
            this.menuItem100,
            this.menuItem192,
            this.menuItem197,
            this.menuItem156,
            this.menuItem202});
            this.menuItem45.MergeOrder = 908;
            this.menuItem45.Text = "Tổng hợp";
            // 
            // menuItem105
            // 
            this.menuItem105.Index = 0;
            this.menuItem105.MergeOrder = 44;
            this.menuItem105.Text = "Phiếu nhập kho";
            this.menuItem105.Click += new System.EventHandler(this.menuItem105_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 1;
            this.menuItem51.MergeOrder = 45;
            this.menuItem51.Text = "Chi tiết vật liệu, dụng cụ, sản phẩm, hàng hóa";
            this.menuItem51.Click += new System.EventHandler(this.menuItem51_Click);
            // 
            // menuItem99
            // 
            this.menuItem99.Index = 2;
            this.menuItem99.MergeOrder = 46;
            this.menuItem99.Text = "Bảng nhập thuốc vật tư y tế";
            this.menuItem99.Click += new System.EventHandler(this.menuItem99_Click_1);
            // 
            // menuItem100
            // 
            this.menuItem100.Index = 3;
            this.menuItem100.MergeOrder = 47;
            this.menuItem100.Text = "Bảng xuất thuốc vật tư y tế";
            this.menuItem100.Click += new System.EventHandler(this.menuItem100_Click);
            // 
            // menuItem192
            // 
            this.menuItem192.Index = 4;
            this.menuItem192.MergeOrder = 48;
            this.menuItem192.Text = "Nhập - xuất - tồn theo nhóm báo cáo";
            this.menuItem192.Click += new System.EventHandler(this.menuItem192_Click);
            // 
            // menuItem197
            // 
            this.menuItem197.Index = 5;
            this.menuItem197.MergeOrder = 49;
            this.menuItem197.Text = "Nhập - xuất - tồn theo nhóm dược bệnh viện";
            this.menuItem197.Click += new System.EventHandler(this.menuItem197_Click);
            // 
            // menuItem156
            // 
            this.menuItem156.Index = 6;
            this.menuItem156.MergeOrder = 50;
            this.menuItem156.Text = "Xuất kho tổng hợp theo ngày";
            this.menuItem156.Click += new System.EventHandler(this.menuItem156_Click);
            // 
            // menuItem202
            // 
            this.menuItem202.Index = 7;
            this.menuItem202.MergeOrder = 51;
            this.menuItem202.Text = "Thống kê nhập xuất kho theo ngày";
            this.menuItem202.Click += new System.EventHandler(this.menuItem202_Click);
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 1;
            this.menuItem46.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem58,
            this.menuItem68,
            this.menuItem119,
            this.menuItem151,
            this.menuItem152,
            this.menuItem47,
            this.menuItem48,
            this.menuItem49,
            this.menuItem149,
            this.menuItem160,
            this.menuItem50,
            this.menuItem214,
            this.menuItem216,
            this.menuItem130,
            this.menuItem132,
            this.menuItem57,
            this.menuItem59,
            this.menuItem32});
            this.menuItem46.MergeOrder = 909;
            this.menuItem46.Text = "Báo cáo";
            // 
            // menuItem58
            // 
            this.menuItem58.Index = 0;
            this.menuItem58.MergeOrder = 52;
            this.menuItem58.Text = "Nhập từ kho trung tâm";
            this.menuItem58.Click += new System.EventHandler(this.menuItem58_Click);
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 1;
            this.menuItem68.MergeOrder = 53;
            this.menuItem68.Text = "Sử dụng theo ngày";
            this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
            // 
            // menuItem119
            // 
            this.menuItem119.Index = 2;
            this.menuItem119.MergeOrder = 54;
            this.menuItem119.Text = "Tồn kho";
            this.menuItem119.Click += new System.EventHandler(this.menuItem119_Click);
            // 
            // menuItem151
            // 
            this.menuItem151.Index = 3;
            this.menuItem151.MergeOrder = 55;
            this.menuItem151.Text = "Xuất kho từ tháng ... đến tháng";
            this.menuItem151.Click += new System.EventHandler(this.menuItem151_Click);
            // 
            // menuItem152
            // 
            this.menuItem152.Index = 4;
            this.menuItem152.MergeOrder = 56;
            this.menuItem152.Text = "Xuất kho (chi tiết)";
            this.menuItem152.Click += new System.EventHandler(this.menuItem152_Click);
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 5;
            this.menuItem47.MergeOrder = 57;
            this.menuItem47.Text = "Nhập kho từng tháng";
            this.menuItem47.Click += new System.EventHandler(this.menuItem47_Click);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 6;
            this.menuItem48.MergeOrder = 58;
            this.menuItem48.Text = "Xuất kho từng tháng";
            this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 7;
            this.menuItem49.MergeOrder = 59;
            this.menuItem49.Text = "Xuất kho theo ngày chi tiết ngoại trú,nội trú";
            this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
            // 
            // menuItem149
            // 
            this.menuItem149.Index = 8;
            this.menuItem149.MergeOrder = 60;
            this.menuItem149.Text = "Nhập xuất tồn";
            this.menuItem149.Click += new System.EventHandler(this.menuItem149_Click);
            // 
            // menuItem160
            // 
            this.menuItem160.Index = 9;
            this.menuItem160.MergeOrder = 62;
            this.menuItem160.Text = "Báo cáo nhập xuất tồn chi tiết các kho";
            this.menuItem160.Click += new System.EventHandler(this.menuItem160_Click_1);
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 10;
            this.menuItem50.MergeOrder = 61;
            this.menuItem50.Text = "Nhập xuất tồn toàn viện (Excel)";
            this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
            // 
            // menuItem214
            // 
            this.menuItem214.Index = 11;
            this.menuItem214.MergeOrder = 63;
            this.menuItem214.Text = "Báo cáo nhập xuất tồn kho";
            this.menuItem214.Click += new System.EventHandler(this.menuItem214_Click);
            // 
            // menuItem216
            // 
            this.menuItem216.Index = 12;
            this.menuItem216.MergeOrder = 64;
            this.menuItem216.Text = "Báo cáo tiền thuốc sử dụng";
            this.menuItem216.Click += new System.EventHandler(this.menuItem216_Click);
            // 
            // menuItem130
            // 
            this.menuItem130.Index = 13;
            this.menuItem130.MergeOrder = 65;
            this.menuItem130.Text = "Biến động giá thuốc";
            this.menuItem130.Click += new System.EventHandler(this.menuItem130_Click);
            // 
            // menuItem132
            // 
            this.menuItem132.Index = 14;
            this.menuItem132.MergeOrder = 66;
            this.menuItem132.Text = "Thuốc gần hết hạn dùng";
            this.menuItem132.Click += new System.EventHandler(this.menuItem132_Click);
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 15;
            this.menuItem57.MergeOrder = 67;
            this.menuItem57.Text = "Thực hiện kế hoạch công tác";
            this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
            // 
            // menuItem59
            // 
            this.menuItem59.Index = 16;
            this.menuItem59.MergeOrder = 68;
            this.menuItem59.Text = "Dược bệnh viện";
            this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 17;
            this.menuItem32.MergeOrder = 40118;
            this.menuItem32.Text = "Nhập xuất tồn kho theo ngày";
            this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 2;
            this.menuItem60.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem106,
            this.menuItem121,
            this.menuItem227,
            this.menuItem208,
            this.menuItem61,
            this.menuItem71,
            this.menuItem62,
            this.menuItem52,
            this.menuItem64,
            this.m194});
            this.menuItem60.MergeOrder = 910;
            this.menuItem60.Text = "Biên bản";
            // 
            // menuItem106
            // 
            this.menuItem106.Index = 0;
            this.menuItem106.MergeOrder = 69;
            this.menuItem106.Text = "Kiểm nhập vật tư, sản phẩm, hàng hóa kiêm phiếu nhập kho";
            this.menuItem106.Click += new System.EventHandler(this.menuItem106_Click);
            // 
            // menuItem121
            // 
            this.menuItem121.Index = 1;
            this.menuItem121.MergeOrder = 70;
            this.menuItem121.Text = "Kiểm nhập";
            this.menuItem121.Click += new System.EventHandler(this.menuItem121_Click);
            // 
            // menuItem227
            // 
            this.menuItem227.Index = 2;
            this.menuItem227.MergeOrder = 71;
            this.menuItem227.Text = "Bảng kê hóa đơn mua hàng";
            this.menuItem227.Click += new System.EventHandler(this.menuItem227_Click);
            // 
            // menuItem208
            // 
            this.menuItem208.Index = 3;
            this.menuItem208.MergeOrder = 72;
            this.menuItem208.Text = "Kiểm nhập lọc theo số hóa đơn";
            this.menuItem208.Click += new System.EventHandler(this.menuItem208_Click);
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 4;
            this.menuItem61.MergeOrder = 73;
            this.menuItem61.Text = "Kiểm kê vật tư, sản phẩm, hàng hoá";
            this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 5;
            this.menuItem71.MergeOrder = 74;
            this.menuItem71.Text = "Kiểm kê vật tư, sản phẩm, hàng hoá (nhóm)";
            this.menuItem71.Click += new System.EventHandler(this.menuItem71_Click_2);
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 6;
            this.menuItem62.MergeOrder = 75;
            this.menuItem62.Text = "Thanh lý, hủy";
            this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 7;
            this.menuItem52.MergeOrder = 76;
            this.menuItem52.Text = "Biên bản kiểm kê TSCĐ && Dụng cụ";
            this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 8;
            this.menuItem64.MergeOrder = 77;
            this.menuItem64.Text = "Phiếu kiểm kê kho";
            this.menuItem64.Click += new System.EventHandler(this.menuItem64_Click);
            // 
            // m194
            // 
            this.m194.Index = 9;
            this.m194.MergeOrder = 194;
            this.m194.Text = "Nhập biên bản kiểm kê";
            this.m194.Click += new System.EventHandler(this.m194_Click);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 3;
            this.menuItem40.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem129,
            this.menuItem143,
            this.menuItem221,
            this.menuItem94,
            this.menuItem164,
            this.menuItem209,
            this.menuItem210,
            this.menuItem169,
            this.menuItem226});
            this.menuItem40.MergeOrder = 911;
            this.menuItem40.Text = "Bảo hiểm";
            // 
            // menuItem129
            // 
            this.menuItem129.Index = 0;
            this.menuItem129.MergeOrder = 78;
            this.menuItem129.Text = "Đơn thuốc";
            this.menuItem129.Click += new System.EventHandler(this.menuItem129_Click_1);
            // 
            // menuItem143
            // 
            this.menuItem143.Index = 1;
            this.menuItem143.MergeOrder = 79;
            this.menuItem143.Text = "Báo cáo tổng hợp chi phí KCB";
            this.menuItem143.Click += new System.EventHandler(this.menuItem143_Click);
            // 
            // menuItem221
            // 
            this.menuItem221.Index = 2;
            this.menuItem221.MergeOrder = 80;
            this.menuItem221.Text = "Báo cáo tổng hợp chi phí KCB theo đơn";
            this.menuItem221.Click += new System.EventHandler(this.menuItem221_Click);
            // 
            // menuItem94
            // 
            this.menuItem94.Index = 3;
            this.menuItem94.MergeOrder = 81;
            this.menuItem94.Text = "Tổng hợp số lượt khám bệnh";
            this.menuItem94.Click += new System.EventHandler(this.menuItem94_Click_1);
            // 
            // menuItem164
            // 
            this.menuItem164.Index = 4;
            this.menuItem164.MergeOrder = 82;
            this.menuItem164.Text = "Báo cáo nhập xuất tồn";
            this.menuItem164.Click += new System.EventHandler(this.menuItem164_Click_1);
            // 
            // menuItem209
            // 
            this.menuItem209.Index = 5;
            this.menuItem209.MergeOrder = 83;
            this.menuItem209.Text = "Tổng hợp xuất kho";
            this.menuItem209.Click += new System.EventHandler(this.menuItem209_Click);
            // 
            // menuItem210
            // 
            this.menuItem210.Index = 6;
            this.menuItem210.MergeOrder = 84;
            this.menuItem210.Text = "In phiếu xuất kho";
            this.menuItem210.Click += new System.EventHandler(this.menuItem210_Click);
            // 
            // menuItem169
            // 
            this.menuItem169.Index = 7;
            this.menuItem169.MergeOrder = 85;
            this.menuItem169.Text = "Bảng thanh toán chi phí KCB (nhóm BHYT)";
            this.menuItem169.Click += new System.EventHandler(this.menuItem169_Click);
            // 
            // menuItem226
            // 
            this.menuItem226.Index = 8;
            this.menuItem226.MergeOrder = 86;
            this.menuItem226.Text = "Bảng tổng hợp chi phí KCB (nhóm BHYT)";
            this.menuItem226.Click += new System.EventHandler(this.menuItem226_Click);
            // 
            // menuItem127
            // 
            this.menuItem127.Index = 4;
            this.menuItem127.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem141,
            this.menuItem54,
            this.menuItem117,
            this.menuItem161,
            this.menuItem211,
            this.menuItem212,
            this.menuItem213,
            this.menuItem215});
            this.menuItem127.MergeOrder = 912;
            this.menuItem127.Text = "Không bảo hiểm (Ngoại trú)";
            // 
            // menuItem141
            // 
            this.menuItem141.Index = 0;
            this.menuItem141.MergeOrder = 87;
            this.menuItem141.Text = "Đơn thuốc";
            this.menuItem141.Click += new System.EventHandler(this.menuItem141_Click);
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 1;
            this.menuItem54.MergeOrder = 88;
            this.menuItem54.Text = "Đơn thuốc trẻ em < 6 tuổi";
            this.menuItem54.Click += new System.EventHandler(this.menuItem54_Click_1);
            // 
            // menuItem117
            // 
            this.menuItem117.Index = 2;
            this.menuItem117.MergeOrder = 89;
            this.menuItem117.Text = "Báo cáo tổng hợp chi phí KCB";
            this.menuItem117.Click += new System.EventHandler(this.menuItem117_Click_1);
            // 
            // menuItem161
            // 
            this.menuItem161.Index = 3;
            this.menuItem161.MergeOrder = 90;
            this.menuItem161.Text = "Tổng hợp số lượt khám bệnh";
            this.menuItem161.Click += new System.EventHandler(this.menuItem161_Click);
            // 
            // menuItem211
            // 
            this.menuItem211.Index = 4;
            this.menuItem211.MergeOrder = 91;
            this.menuItem211.Text = "Tổng hợp xuất kho theo đơn";
            this.menuItem211.Click += new System.EventHandler(this.menuItem211_Click);
            // 
            // menuItem212
            // 
            this.menuItem212.Index = 5;
            this.menuItem212.MergeOrder = 92;
            this.menuItem212.Text = "In phiếu xuất kho theo đơn";
            this.menuItem212.Click += new System.EventHandler(this.menuItem212_Click);
            // 
            // menuItem213
            // 
            this.menuItem213.Index = 6;
            this.menuItem213.MergeOrder = 93;
            this.menuItem213.Text = "Tổng hợp xuất kho ";
            this.menuItem213.Click += new System.EventHandler(this.menuItem213_Click);
            // 
            // menuItem215
            // 
            this.menuItem215.Index = 7;
            this.menuItem215.MergeOrder = 94;
            this.menuItem215.Text = "In phiếu xuất kho";
            this.menuItem215.Click += new System.EventHandler(this.menuItem215_Click);
            // 
            // menuItem232
            // 
            this.menuItem232.Index = 5;
            this.menuItem232.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem233,
            this.menuItem234});
            this.menuItem232.MergeOrder = 913;
            this.menuItem232.Text = "Điều trị ngoại trú";
            // 
            // menuItem233
            // 
            this.menuItem233.Index = 0;
            this.menuItem233.MergeOrder = 95;
            this.menuItem233.Text = "Tổng hợp xuất kho";
            this.menuItem233.Click += new System.EventHandler(this.menuItem233_Click);
            // 
            // menuItem234
            // 
            this.menuItem234.Index = 1;
            this.menuItem234.MergeOrder = 96;
            this.menuItem234.Text = "In phiếu xuất kho";
            this.menuItem234.Click += new System.EventHandler(this.menuItem234_Click);
            // 
            // menuItem218
            // 
            this.menuItem218.Index = 6;
            this.menuItem218.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem219,
            this.menuItem220});
            this.menuItem218.MergeOrder = 914;
            this.menuItem218.Text = "Khác";
            // 
            // menuItem219
            // 
            this.menuItem219.Index = 0;
            this.menuItem219.MergeOrder = 97;
            this.menuItem219.Text = "Tổng hợp xuất kho";
            this.menuItem219.Click += new System.EventHandler(this.menuItem219_Click);
            // 
            // menuItem220
            // 
            this.menuItem220.Index = 1;
            this.menuItem220.MergeOrder = 98;
            this.menuItem220.Text = "In phiếu xuất kho";
            this.menuItem220.Click += new System.EventHandler(this.menuItem220_Click);
            // 
            // menuItem133
            // 
            this.menuItem133.Index = 7;
            this.menuItem133.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem134,
            this.menuItem148,
            this.menuItem178,
            this.menuItem125,
            this.menuItem131,
            this.menuItem163,
            this.menuItem180,
            this.menuItem190,
            this.menuItem201,
            this.menuItem55,
            this.menuItem56,
            this.m195});
            this.menuItem133.MergeOrder = 915;
            this.menuItem133.Text = "Nhà thuốc";
            // 
            // menuItem134
            // 
            this.menuItem134.Index = 0;
            this.menuItem134.MergeOrder = 99;
            this.menuItem134.Text = "Toa thuốc bán lẻ";
            this.menuItem134.Click += new System.EventHandler(this.menuItem134_Click_1);
            // 
            // menuItem148
            // 
            this.menuItem148.Index = 1;
            this.menuItem148.MergeOrder = 100;
            this.menuItem148.Text = "Nhập xuất tồn";
            this.menuItem148.Click += new System.EventHandler(this.menuItem148_Click_2);
            // 
            // menuItem178
            // 
            this.menuItem178.Index = 2;
            this.menuItem178.MergeOrder = 101;
            this.menuItem178.Text = "Thu tiền thuốc";
            this.menuItem178.Click += new System.EventHandler(this.menuItem178_Click);
            // 
            // menuItem125
            // 
            this.menuItem125.Index = 3;
            this.menuItem125.MergeOrder = 102;
            this.menuItem125.Text = "Doanh số theo bác sỹ";
            this.menuItem125.Click += new System.EventHandler(this.menuItem125_Click_1);
            // 
            // menuItem131
            // 
            this.menuItem131.Index = 4;
            this.menuItem131.MergeOrder = 103;
            this.menuItem131.Text = "Biên bản kiểm kê";
            this.menuItem131.Click += new System.EventHandler(this.menuItem131_Click_1);
            // 
            // menuItem163
            // 
            this.menuItem163.Index = 5;
            this.menuItem163.MergeOrder = 104;
            this.menuItem163.Text = "Nhập xuất tồn chi tiết";
            this.menuItem163.Click += new System.EventHandler(this.menuItem163_Click_1);
            // 
            // menuItem180
            // 
            this.menuItem180.Index = 6;
            this.menuItem180.MergeOrder = 105;
            this.menuItem180.Text = "Tổng hợp lãi gộp";
            this.menuItem180.Click += new System.EventHandler(this.menuItem180_Click_1);
            // 
            // menuItem190
            // 
            this.menuItem190.Index = 7;
            this.menuItem190.MergeOrder = 106;
            this.menuItem190.Text = "Thống kê thuốc theo bác sỹ";
            this.menuItem190.Click += new System.EventHandler(this.menuItem190_Click);
            // 
            // menuItem201
            // 
            this.menuItem201.Index = 8;
            this.menuItem201.MergeOrder = 107;
            this.menuItem201.Text = "Bảng kê xuất bán hàng";
            this.menuItem201.Click += new System.EventHandler(this.menuItem201_Click);
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 9;
            this.menuItem55.MergeOrder = 108;
            this.menuItem55.Text = "Theo dõi giá thuốc";
            this.menuItem55.Click += new System.EventHandler(this.menuItem55_Click);
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 10;
            this.menuItem56.MergeOrder = 109;
            this.menuItem56.Text = "In phiếu xuất kho";
            this.menuItem56.Click += new System.EventHandler(this.menuItem56_Click_1);
            // 
            // m195
            // 
            this.m195.Index = 11;
            this.m195.MergeOrder = 195;
            this.m195.Text = "In phiếu lĩnh / hoàn trả";
            this.m195.Click += new System.EventHandler(this.m195_Click);
            // 
            // menuItem108
            // 
            this.menuItem108.Index = 8;
            this.menuItem108.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem65,
            this.menuItem84,
            this.menuItem66,
            this.menuItem67,
            this.menuItem217,
            this.menuItem162});
            this.menuItem108.MergeOrder = 916;
            this.menuItem108.Text = "Sổ chi tiết - thẻ kho";
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 0;
            this.menuItem65.MergeOrder = 110;
            this.menuItem65.Text = "Sổ chi tiết vật tư, sản phẩm, hàng hóa";
            this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
            // 
            // menuItem84
            // 
            this.menuItem84.Index = 1;
            this.menuItem84.MergeOrder = 111;
            this.menuItem84.Text = "Sổ theo dõi tài sản cố định và dụng cụ";
            this.menuItem84.Click += new System.EventHandler(this.menuItem84_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 2;
            this.menuItem66.MergeOrder = 112;
            this.menuItem66.Text = "Sổ kho";
            this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 3;
            this.menuItem67.MergeOrder = 113;
            this.menuItem67.Text = "Thẻ kho";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click);
            // 
            // menuItem217
            // 
            this.menuItem217.Index = 4;
            this.menuItem217.MergeOrder = 114;
            this.menuItem217.Text = "Thẻ kho theo cơ số tủ trực";
            this.menuItem217.Click += new System.EventHandler(this.menuItem217_Click);
            // 
            // menuItem162
            // 
            this.menuItem162.Index = 5;
            this.menuItem162.MergeOrder = 115;
            this.menuItem162.Text = "Chi tiết xuất kho theo mặt hàng";
            this.menuItem162.Click += new System.EventHandler(this.menuItem162_Click_1);
            // 
            // menuItem120
            // 
            this.menuItem120.Index = 9;
            this.menuItem120.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem123,
            this.menuItem196,
            this.menuItem124,
            this.menuItem206,
            this.menuItem203,
            this.menuItem222,
            this.menuItem158,
            this.menuItem223,
            this.m200,
            this.menuItem35});
            this.menuItem120.MergeOrder = 917;
            this.menuItem120.Text = "Khoa phòng";
            // 
            // menuItem123
            // 
            this.menuItem123.Index = 0;
            this.menuItem123.MergeOrder = 116;
            this.menuItem123.Text = "Phiếu tổng hợp y lệnh";
            this.menuItem123.Click += new System.EventHandler(this.menuItem123_Click);
            // 
            // menuItem196
            // 
            this.menuItem196.Index = 1;
            this.menuItem196.MergeOrder = 117;
            this.menuItem196.Text = "In đơn thuốc";
            this.menuItem196.Click += new System.EventHandler(this.menuItem196_Click);
            // 
            // menuItem124
            // 
            this.menuItem124.Index = 2;
            this.menuItem124.MergeOrder = 118;
            this.menuItem124.Text = "In phiếu xuất kho";
            this.menuItem124.Click += new System.EventHandler(this.menuItem124_Click);
            // 
            // menuItem206
            // 
            this.menuItem206.Index = 3;
            this.menuItem206.MergeOrder = 119;
            this.menuItem206.Text = "In phiếu xuất kho phòng mỗ";
            this.menuItem206.Click += new System.EventHandler(this.menuItem206_Click);
            // 
            // menuItem203
            // 
            this.menuItem203.Index = 4;
            this.menuItem203.MergeOrder = 120;
            this.menuItem203.Text = "Tổng hợp phiếu xuất theo khoa";
            this.menuItem203.Click += new System.EventHandler(this.menuItem203_Click);
            // 
            // menuItem222
            // 
            this.menuItem222.Index = 5;
            this.menuItem222.MergeOrder = 121;
            this.menuItem222.Text = "Báo cáo cơ số tủ trực các khoa";
            this.menuItem222.Click += new System.EventHandler(this.menuItem222_Click);
            // 
            // menuItem158
            // 
            this.menuItem158.Index = 6;
            this.menuItem158.MergeOrder = 122;
            this.menuItem158.Text = "Báo cáo nhập xuất tồn khoa";
            this.menuItem158.Click += new System.EventHandler(this.menuItem158_Click);
            // 
            // menuItem223
            // 
            this.menuItem223.Index = 7;
            this.menuItem223.MergeOrder = 123;
            this.menuItem223.Text = "Sử dụng nội trú từ ngày ... đến ngày";
            this.menuItem223.Click += new System.EventHandler(this.menuItem223_Click);
            // 
            // m200
            // 
            this.m200.Index = 8;
            this.m200.MergeOrder = 200;
            this.m200.Text = "Kiểm kê vật tư, sản phẩm, hàng hóa";
            this.m200.Click += new System.EventHandler(this.m200_Click);
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 9;
            this.menuItem35.MergeOrder = 41010;
            this.menuItem35.Text = "Danh sách các phiếu đã thu hồi";
            this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click_1);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem144,
            this.menuItem181,
            this.menuItem182,
            this.menuItem183,
            this.menuItem86,
            this.menuItem154,
            this.menuItem140,
            this.m197,
            this.menuItem85,
            this.menuItem225,
            this.menuItem22,
            this.mnuRight_Bv,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25,
            this.menuItem102,
            this.menuItem104,
            this.menuItem110,
            this.menuItem146,
            this.menuItem150,
            this.menuItem113,
            this.menuItem159,
            this.menuItem228,
            this.menuItem137,
            this.menuItem157,
            this.m189,
            this.m190,
            this.menuItem101,
            this.m198,
            this.m202,
            this.m199,
            this.m206,
            this.m207,
            this.menuItem26,
            this.menuItem27});
            this.menuItem3.MergeOrder = 918;
            this.menuItem3.Text = "&Tiện ích";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem89,
            this.menuItem20,
            this.menuItem19,
            this.menuItem11,
            this.menuItem18,
            this.menuItem33,
            this.menuItem44,
            this.menuItem63,
            this.menuItem107,
            this.menuItem31,
            this.menuItem90,
            this.menuItem91,
            this.menuItem28,
            this.menuItem29,
            this.menuItem30,
            this.menuItem138,
            this.menuItem34,
            this.menuItem36,
            this.menuItem122,
            this.menuItem155,
            this.menuItem193,
            this.menuItem194,
            this.menuItem195,
            this.m192,
            this.menuItem21,
            this.menuItem103});
            this.menuItem9.MergeOrder = 919;
            this.menuItem9.Text = "Danh mục";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.MergeOrder = 124;
            this.menuItem10.Text = "Vật tư, sản phẩm, hàng hóa";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem89
            // 
            this.menuItem89.Index = 1;
            this.menuItem89.MergeOrder = 125;
            this.menuItem89.Text = "Hoạt chất";
            this.menuItem89.Click += new System.EventHandler(this.menuItem89_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.MergeOrder = 126;
            this.menuItem20.Text = "Nước sản xuất";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 3;
            this.menuItem19.MergeOrder = 127;
            this.menuItem19.Text = "Hãng sản xuất";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.MergeOrder = 128;
            this.menuItem11.Text = "Nhóm";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 5;
            this.menuItem18.MergeOrder = 129;
            this.menuItem18.Text = "Phân loại";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 6;
            this.menuItem33.MergeOrder = 130;
            this.menuItem33.Text = "Nhà cung cấp";
            this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 7;
            this.menuItem44.MergeOrder = 131;
            this.menuItem44.Text = "Danh mục hoàn trả, ngoại trú, khác,...";
            this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
            // 
            // menuItem63
            // 
            this.menuItem63.Index = 8;
            this.menuItem63.MergeOrder = 135;
            this.menuItem63.Text = "Nhóm báo cáo công tác dược";
            this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click_1);
            // 
            // menuItem107
            // 
            this.menuItem107.Index = 9;
            this.menuItem107.MergeOrder = 136;
            this.menuItem107.Text = "Nhóm báo cáo bệnh viện";
            this.menuItem107.Click += new System.EventHandler(this.menuItem107_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 10;
            this.menuItem31.MergeOrder = 138;
            this.menuItem31.Text = "Nhóm kế toán";
            this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
            // 
            // menuItem90
            // 
            this.menuItem90.Index = 11;
            this.menuItem90.MergeOrder = 139;
            this.menuItem90.Text = "Nhóm phiếu";
            this.menuItem90.Click += new System.EventHandler(this.menuItem90_Click);
            // 
            // menuItem91
            // 
            this.menuItem91.Index = 12;
            this.menuItem91.MergeOrder = 151;
            this.menuItem91.Text = "Loại phiếu";
            this.menuItem91.Click += new System.EventHandler(this.menuItem91_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 13;
            this.menuItem28.MergeOrder = 140;
            this.menuItem28.Text = "Nhóm kho";
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 14;
            this.menuItem29.MergeOrder = 141;
            this.menuItem29.Text = "Kho";
            this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 15;
            this.menuItem30.MergeOrder = 142;
            this.menuItem30.Text = "Nguồn";
            this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
            // 
            // menuItem138
            // 
            this.menuItem138.Index = 16;
            this.menuItem138.MergeOrder = 143;
            this.menuItem138.Text = "Nhóm khoa/phòng";
            this.menuItem138.Click += new System.EventHandler(this.menuItem138_Click);
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 17;
            this.menuItem34.MergeOrder = 144;
            this.menuItem34.Text = "Khoa/phòng";
            this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 18;
            this.menuItem36.MergeOrder = 148;
            this.menuItem36.Text = "Bảo hiểm chi trả";
            this.menuItem36.Click += new System.EventHandler(this.menuItem36_Click);
            // 
            // menuItem122
            // 
            this.menuItem122.Index = 19;
            this.menuItem122.MergeOrder = 149;
            this.menuItem122.Text = "Đối tượng";
            this.menuItem122.Click += new System.EventHandler(this.menuItem122_Click);
            // 
            // menuItem155
            // 
            this.menuItem155.Index = 20;
            this.menuItem155.MergeOrder = 153;
            this.menuItem155.Text = "Danh mục đối tượng vay";
            this.menuItem155.Click += new System.EventHandler(this.menuItem155_Click_1);
            // 
            // menuItem193
            // 
            this.menuItem193.Index = 21;
            this.menuItem193.MergeOrder = 154;
            this.menuItem193.Text = "Danh mục bác sỹ";
            this.menuItem193.Click += new System.EventHandler(this.menuItem193_Click);
            // 
            // menuItem194
            // 
            this.menuItem194.Index = 22;
            this.menuItem194.MergeOrder = 155;
            this.menuItem194.Text = "Danh mục cách dùng";
            this.menuItem194.Click += new System.EventHandler(this.menuItem194_Click);
            // 
            // menuItem195
            // 
            this.menuItem195.Index = 23;
            this.menuItem195.MergeOrder = 156;
            this.menuItem195.Text = "Danh mục đường dùng";
            this.menuItem195.Click += new System.EventHandler(this.menuItem195_Click);
            // 
            // m192
            // 
            this.m192.Index = 24;
            this.m192.MergeOrder = 192;
            this.m192.Text = "Khai báo gói thuốc vật tư y tế";
            this.m192.Click += new System.EventHandler(this.m192_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 25;
            this.menuItem21.MergeOrder = 50126;
            this.menuItem21.Text = "Danh muc mặt hàng không cho nhập mới";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem103
            // 
            this.menuItem103.Index = 26;
            this.menuItem103.MergeOrder = 50127;
            this.menuItem103.Text = "Danh mục thuốc theo Bộ Y Tế";
            this.menuItem103.Click += new System.EventHandler(this.menuItem103_Click);
            // 
            // menuItem144
            // 
            this.menuItem144.Index = 1;
            this.menuItem144.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem145,
            this.menuItem179,
            this.menuItem93});
            this.menuItem144.MergeOrder = 920;
            this.menuItem144.Text = "Khai báo tồn đầu";
            // 
            // menuItem145
            // 
            this.menuItem145.Index = 0;
            this.menuItem145.MergeOrder = 157;
            this.menuItem145.Text = "Kho";
            this.menuItem145.Click += new System.EventHandler(this.menuItem145_Click_1);
            // 
            // menuItem179
            // 
            this.menuItem179.Index = 1;
            this.menuItem179.MergeOrder = 158;
            this.menuItem179.Text = "Tủ trực";
            this.menuItem179.Click += new System.EventHandler(this.menuItem179_Click);
            // 
            // menuItem93
            // 
            this.menuItem93.Index = 2;
            this.menuItem93.MergeOrder = 159;
            this.menuItem93.Text = "Vay";
            this.menuItem93.Click += new System.EventHandler(this.menuItem93_Click_1);
            // 
            // menuItem181
            // 
            this.menuItem181.Index = 2;
            this.menuItem181.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem184,
            this.menuItem185,
            this.menuItem114,
            this.menuItem186});
            this.menuItem181.MergeOrder = 921;
            this.menuItem181.Text = "Kho";
            // 
            // menuItem184
            // 
            this.menuItem184.Index = 0;
            this.menuItem184.MergeOrder = 160;
            this.menuItem184.Text = "Chi tiết";
            this.menuItem184.Click += new System.EventHandler(this.menuItem184_Click);
            // 
            // menuItem185
            // 
            this.menuItem185.Index = 1;
            this.menuItem185.MergeOrder = 161;
            this.menuItem185.Text = "Tổng hợp";
            this.menuItem185.Click += new System.EventHandler(this.menuItem185_Click);
            // 
            // menuItem114
            // 
            this.menuItem114.Index = 2;
            this.menuItem114.MergeOrder = 162;
            this.menuItem114.Text = "Tổng hợp các kho";
            this.menuItem114.Click += new System.EventHandler(this.menuItem114_Click_1);
            // 
            // menuItem186
            // 
            this.menuItem186.Index = 3;
            this.menuItem186.MergeOrder = 163;
            this.menuItem186.Text = "Kiểm tra tồn đầu";
            this.menuItem186.Click += new System.EventHandler(this.menuItem186_Click);
            // 
            // menuItem182
            // 
            this.menuItem182.Index = 3;
            this.menuItem182.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem43,
            this.menuItem187,
            this.menuItem188,
            this.menuItem189});
            this.menuItem182.MergeOrder = 922;
            this.menuItem182.Text = "Tủ trực";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 0;
            this.menuItem43.MergeOrder = 164;
            this.menuItem43.Text = "Cơ số";
            this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click_1);
            // 
            // menuItem187
            // 
            this.menuItem187.Index = 1;
            this.menuItem187.MergeOrder = 165;
            this.menuItem187.Text = "Chi tiết";
            this.menuItem187.Click += new System.EventHandler(this.menuItem187_Click);
            // 
            // menuItem188
            // 
            this.menuItem188.Index = 2;
            this.menuItem188.MergeOrder = 166;
            this.menuItem188.Text = "Tổng hợp";
            this.menuItem188.Click += new System.EventHandler(this.menuItem188_Click);
            // 
            // menuItem189
            // 
            this.menuItem189.Index = 3;
            this.menuItem189.MergeOrder = 167;
            this.menuItem189.Text = "Kiểm tra tồn đầu";
            this.menuItem189.Click += new System.EventHandler(this.menuItem189_Click);
            // 
            // menuItem183
            // 
            this.menuItem183.Index = 4;
            this.menuItem183.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem69,
            this.menuItem70});
            this.menuItem183.MergeOrder = 923;
            this.menuItem183.Text = "Vay";
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 0;
            this.menuItem69.MergeOrder = 168;
            this.menuItem69.Text = "Chi tiết";
            this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click_1);
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 1;
            this.menuItem70.MergeOrder = 169;
            this.menuItem70.Text = "Tổng hợp";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click_1);
            // 
            // menuItem86
            // 
            this.menuItem86.Index = 5;
            this.menuItem86.Text = "-";
            // 
            // menuItem154
            // 
            this.menuItem154.Index = 6;
            this.menuItem154.MergeOrder = 170;
            this.menuItem154.Text = "Cập nhật các loại giá";
            this.menuItem154.Click += new System.EventHandler(this.menuItem154_Click);
            // 
            // menuItem140
            // 
            this.menuItem140.Index = 7;
            this.menuItem140.MergeOrder = 171;
            this.menuItem140.Text = "Kiểm tra số liệu tồn kho";
            this.menuItem140.Click += new System.EventHandler(this.menuItem140_Click);
            // 
            // m197
            // 
            this.m197.Index = 8;
            this.m197.MergeOrder = 197;
            this.m197.Text = "Cập nhật ngày kho phát lẻ nghỉ";
            this.m197.Click += new System.EventHandler(this.m197_Click);
            // 
            // menuItem85
            // 
            this.menuItem85.Index = 9;
            this.menuItem85.Text = "-";
            // 
            // menuItem225
            // 
            this.menuItem225.Index = 10;
            this.menuItem225.MergeOrder = 172;
            this.menuItem225.Text = "Cấu hình thông số hệ thống";
            this.menuItem225.Click += new System.EventHandler(this.menuItem225_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 11;
            this.menuItem22.MergeOrder = 173;
            this.menuItem22.Text = "Khai báo thông số hệ thống";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // mnuRight_Bv
            // 
            this.mnuRight_Bv.Index = 12;
            this.mnuRight_Bv.MergeOrder = 924;
            this.mnuRight_Bv.Text = "Phân quyền sử dụng theo bệnh viện sử dụng";
            this.mnuRight_Bv.Click += new System.EventHandler(this.mnuRight_Bv_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 13;
            this.menuItem23.MergeOrder = 174;
            this.menuItem23.Text = "Phân quyền sử dụng";
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 14;
            this.menuItem24.MergeOrder = 175;
            this.menuItem24.Text = "Thay đổi mật khẩu";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 15;
            this.menuItem25.MergeOrder = 176;
            this.menuItem25.Text = "Sao lưu số liệu";
            this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItem102
            // 
            this.menuItem102.Index = 16;
            this.menuItem102.MergeOrder = 177;
            this.menuItem102.Text = "Truy vấn theo câu lệnh SQL";
            this.menuItem102.Click += new System.EventHandler(this.menuItem102_Click);
            // 
            // menuItem104
            // 
            this.menuItem104.Index = 17;
            this.menuItem104.MergeOrder = 178;
            this.menuItem104.Text = "Đổi ngày";
            this.menuItem104.Click += new System.EventHandler(this.menuItem104_Click);
            // 
            // menuItem110
            // 
            this.menuItem110.Index = 18;
            this.menuItem110.MergeOrder = 179;
            this.menuItem110.Text = "Gửi thông tin qua mạng nội bộ";
            this.menuItem110.Click += new System.EventHandler(this.menuItem110_Click_1);
            // 
            // menuItem146
            // 
            this.menuItem146.Index = 19;
            this.menuItem146.MergeOrder = 180;
            this.menuItem146.Text = "Thông báo qua mạng nội bộ";
            this.menuItem146.Click += new System.EventHandler(this.menuItem146_Click);
            // 
            // menuItem150
            // 
            this.menuItem150.Index = 20;
            this.menuItem150.MergeOrder = 181;
            this.menuItem150.Text = "Kiểm tra số liệu của khoa";
            this.menuItem150.Click += new System.EventHandler(this.menuItem150_Click);
            // 
            // menuItem113
            // 
            this.menuItem113.Index = 21;
            this.menuItem113.MergeOrder = 182;
            this.menuItem113.Text = "Danh sách dự trù,duyệt,in phiếu xuất";
            this.menuItem113.Click += new System.EventHandler(this.menuItem113_Click_1);
            // 
            // menuItem159
            // 
            this.menuItem159.Index = 22;
            this.menuItem159.MergeOrder = 183;
            this.menuItem159.Text = "Truy vấn thông tin";
            this.menuItem159.Click += new System.EventHandler(this.menuItem159_Click);
            // 
            // menuItem228
            // 
            this.menuItem228.Index = 23;
            this.menuItem228.MergeOrder = 184;
            this.menuItem228.Text = "Chỉnh sửa số tiền trong phiếu nhập";
            this.menuItem228.Click += new System.EventHandler(this.menuItem228_Click);
            // 
            // menuItem137
            // 
            this.menuItem137.Index = 24;
            this.menuItem137.MergeOrder = 185;
            this.menuItem137.Text = "Tạo lại số liệu tháng năm";
            this.menuItem137.Click += new System.EventHandler(this.menuItem137_Click);
            // 
            // menuItem157
            // 
            this.menuItem157.Index = 25;
            this.menuItem157.MergeOrder = 186;
            this.menuItem157.Text = "Nhật ký người dùng";
            this.menuItem157.Click += new System.EventHandler(this.menuItem157_Click);
            // 
            // m189
            // 
            this.m189.Index = 26;
            this.m189.MergeOrder = 189;
            this.m189.Text = "Cập nhật số lượng tồn treo";
            this.m189.Click += new System.EventHandler(this.m189_Click);
            // 
            // m190
            // 
            this.m190.Index = 27;
            this.m190.MergeOrder = 190;
            this.m190.Text = "Hủy duyệt treo theo máy";
            this.m190.Click += new System.EventHandler(this.m190_Click);
            // 
            // menuItem101
            // 
            this.menuItem101.Index = 28;
            this.menuItem101.MergeOrder = 932;
            this.menuItem101.Text = "Hủy lấy số liệu theo máy";
            this.menuItem101.Click += new System.EventHandler(this.menuItem101_Click_1);
            // 
            // m198
            // 
            this.m198.Index = 29;
            this.m198.MergeOrder = 198;
            this.m198.Text = "Xem phiếu nhập kho";
            this.m198.Click += new System.EventHandler(this.m198_Click);
            // 
            // m202
            // 
            this.m202.Index = 30;
            this.m202.MergeOrder = 202;
            this.m202.Text = "Xem phiếu xuất chuyển kho";
            this.m202.Click += new System.EventHandler(this.m202_Click);
            // 
            // m199
            // 
            this.m199.Index = 31;
            this.m199.MergeOrder = 199;
            this.m199.Text = "Xem phiếu lĩnh";
            this.m199.Click += new System.EventHandler(this.m199_Click);
            // 
            // m206
            // 
            this.m206.Index = 32;
            this.m206.MergeOrder = 206;
            this.m206.Text = "Xem phiếu hoàn trả";
            this.m206.Click += new System.EventHandler(this.m206_Click);
            // 
            // m207
            // 
            this.m207.Index = 33;
            this.m207.MergeOrder = 207;
            this.m207.Text = "Xem phiếu xuất khác";
            this.m207.Click += new System.EventHandler(this.m207_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 34;
            this.menuItem26.Text = "-";
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 35;
            this.menuItem27.MergeOrder = 187;
            this.menuItem27.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem27.Text = "Log Off";
            this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.MdiList = true;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem13,
            this.menuItem14});
            this.menuItem4.Text = "&A. Cửa sổ";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 0;
            this.menuItem12.Text = "&1. Hiện cửa sổ theo chiều dọc";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Text = "&2. Hiện cửa sổ theo chiều ngang";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.Text = "&3. Đóng tất cả các cửa sổ";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem16,
            this.menuItem17});
            this.menuItem5.Text = "&B. Hướng dẫn";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "&1. Hướng dẫn sử dụng";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 1;
            this.menuItem16.Text = "-";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Text = "&2. About";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 7;
            this.menuItem6.Text = "&C. Kết thúc";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 380);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kho  .NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

		}
		#endregion


		private bool IsLoaded(string frm)
		{
			Form[] afrm=this.MdiChildren;
			foreach(Form f in afrm)
			{
				if(f.Name.Equals(frm)){f.Activate();return true;}
			}
			return false;
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show ("Bạn có muốn kết thúc không ?",this.Text,MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
			{
                d.set_current();
				Application.Exit();
			}
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			Form[] charr= this.MdiChildren;  
			foreach (Form chform in charr) chform.Close();
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{

		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			
            
            Splasher.Show();
            Splasher.Status = "Connecting to PostgreSQL Database Server";
            user = d.user;
			ds=d.get_data("select * from "+user+".d_dlogin where id=0");
			//Application.DoEvents();
			System.Threading.Thread.Sleep(1000);//2350
			Splasher.Close();
            this.Text = this.Text + " - Version: " + ProductVersion;
            if (d.i_Chinhanh_hientai > 0) this.Text += " - CN" + d.i_Chinhanh_hientai;//binh 290312
            i_userid = -1;
            if (__userid != "")
            {
                try
                {
                    string sql = "select a.*,b.ten as tennhom from " + user + ".d_dlogin a," + user + ".d_dmnhomkho b where a.nhomkho=b.id and b.loai=1 ";
                    sql += " and a.id=" + __userid + "";
                    //MessageBox.Show(sql);
                    ds = d.get_data(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        s_userid = ds.Tables[0].Rows[0]["hoten"].ToString(); //f.mUserid;
                        s_right = ds.Tables[0].Rows[0]["right_"].ToString(); //f.mRight;
                        i_userid = int.Parse(ds.Tables[0].Rows[0]["id"].ToString()); //f.iUserid;
                        i_nhomkho = int.Parse(ds.Tables[0].Rows[0]["nhomkho"].ToString()); //f.iNhomkho;
                        i_loaikho = d.get_loai(i_nhomkho);
                        s_makho = ds.Tables[0].Rows[0]["makho"].ToString(); //f.mMakho;
                        s_mmyy = __ngaysl.Split('/')[1] + __ngaysl.Split('/')[2].Substring(2); //f.mMmyy;
                        s_ngay = __ngaylv;//f.mNgay;
                        s_makp = ds.Tables[0].Rows[0]["makp"].ToString(); //f.mMakp;
                        s_manhom = ds.Tables[0].Rows[0]["manhom"].ToString(); //f.mManhom;
                        b_admin = int.Parse(ds.Tables[0].Rows[0]["admin"].ToString()) == 1; //f.bAdmin;
                        b_thuhoi = int.Parse(ds.Tables[0].Rows[0]["thuhoi"].ToString()) == 1; //f.bThuhoi;
                        s_loaint = ds.Tables[0].Rows[0]["loaint"].ToString(); //f.mLoaint; 
                        s_loaikhac = ds.Tables[0].Rows[0]["loaikhac"].ToString(); //f.mLoaikhac;
                        //d.writeXml("d_thongso", "kho", (f.mTennhom == "") ? "Dược" : f.mTennhom);
                        d.writeXml("d_thongso", "kho", (ds.Tables[0].Rows[0]["tennhom"].ToString() == "") ? "Dược" : ds.Tables[0].Rows[0]["tennhom"].ToString());

                        s_nhomkho = ds.Tables[0].Rows[0]["tennhom"].ToString(); //f.mTennhom;

                        DataSet dsxml = new DataSet();
                        dsxml.ReadXml("..\\..\\..\\xml\\d_nhomkholog.xml");
                        dsxml.Tables[0].Rows[0]["nhomkho"] = i_nhomkho.ToString();
                        dsxml.WriteXml("..\\..\\..\\xml\\d_nhomkholog.xml", XmlWriteMode.WriteSchema);

                        //
                        f_get_khudieutri();
                        //i_chinhanh = f.i_chinhanh;
                        try
                        {
                            i_chinhanh = int.Parse(ds.Tables[0].Rows[0]["chinhanh"].ToString());
                        }
                        catch
                        {
                            i_chinhanh = 0;
                        }

                        //
                        //if (this.menuItem27.Text != "Log Off ") this.Text = f.mTennhom + " - " + s_ngay + " - " + s_userid.Trim() + "- " + lan.Change_language_MessageText("Tháng") + " " + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                        if (this.menuItem27.Text != "Log Off ") this.Text = s_nhomkho + " - " + s_ngay + " - " + s_userid.Trim() + "- " + lan.Change_language_MessageText("Tháng") + " " + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                        this.menuItem17.Text = "&2. About " + d.Msg;
                        this.Text = this.Text + " - Version: " + ProductVersion;
                        if (i_nhomkho != 0) b_giaban = int.Parse(d.get_data("select nhom from " + user + ".d_dmnhomkho where id=" + i_nhomkho).Tables[0].Rows[0][0].ToString()) == 1;
                        if (!b_giaban) b_giaban = d.bGiaban_nguon(i_nhomkho);
                        int sothangdate = d.sothangdate(i_nhomkho);
                        if (b_admin && sothangdate != 0)
                        {
                            DateTime dt = d.StringToDate("01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2)).AddMonths(sothangdate);
                            string mmyy = dt.Month.ToString().PadLeft(2, '0') + dt.Year.ToString().PadLeft(4, '0').Substring(2);
                            try
                            {
                                ds = d.get_7(i_nhomkho, s_mmyy, mmyy, "", s_makho);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    frmTruyvandate f1 = new frmTruyvandate(mmyy, ds);
                                    f1.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        //int soluonggiaodong = d.soluonggiaodong(i_nhomkho); ;
                        //if (b_admin && soluonggiaodong != 0)
                        //{
                        //    DateTime dt = d.StringToDate("01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2)).AddMonths(soluonggiaodong);
                        //    string mmyy = dt.Month.ToString().PadLeft(2, '0') + dt.Year.ToString().PadLeft(4, '0').Substring(2);
                        //    try
                        //    {
                        //        ds = d.get_tontoithieu(s_mmyy, s_makho, soluonggiaodong);
                        //        if (ds.Tables[0].Rows.Count > 0)
                        //        {
                        //            frmTruyvantontoithieu f2 = new frmTruyvantontoithieu(mmyy, ds);
                        //            f2.ShowDialog();
                        //        }
                        //    }
                        //    catch { }
                        //}

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (i_userid == -1)
            {
                s_right = "";
                frmLogin f = new frmLogin(d);
                f.ShowDialog(this);
                if (f.mExit)
                {
                    Application.Exit();
                    return;
                }

                if (f.mUserid != "")
                {
                    s_userid = f.mUserid;
                    s_right = f.mRight;
                    i_userid = f.iUserid;
                    i_nhomkho = f.iNhomkho;
                    i_loaikho = d.get_loai(i_nhomkho);
                    s_makho = f.mMakho;
                    s_mmyy = f.mMmyy;
                    s_ngay = f.mNgay;
                    s_makp = f.mMakp;
                    s_manhom = f.mManhom;
                    b_admin = f.bAdmin;
                    b_thuhoi = f.bThuhoi;
                    s_loaint = f.mLoaint; s_loaikhac = f.mLoaikhac;
                    d.writeXml("d_thongso", "kho", (f.mTennhom == "") ? "Dược" : f.mTennhom);
                    s_nhomkho = f.mTennhom;

                    //
                    f_get_khudieutri();
                    i_chinhanh = f.i_chinhanh;
                    //
                    if (this.menuItem27.Text != "Log Off ") this.Text = f.mTennhom + " - " + s_ngay + " - " + s_userid.Trim() + "- " + lan.Change_language_MessageText("Tháng") + " " + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                    this.menuItem17.Text = "&2. About " + d.Msg;
                    this.Text = this.Text + " - CS" + i_chinhanh + " - Version: " + ProductVersion;
                    if (i_nhomkho != 0) b_giaban = int.Parse(d.get_data("select nhom from " + user + ".d_dmnhomkho where id=" + i_nhomkho).Tables[0].Rows[0][0].ToString()) == 1;
                    if (!b_giaban) b_giaban = d.bGiaban_nguon(i_nhomkho);
                    int sothangdate = d.sothangdate(i_nhomkho);
                    if (sothangdate != 0)
                    {
                        DateTime dt = d.StringToDate("01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2)).AddMonths(sothangdate);
                        string mmyy = dt.Month.ToString().PadLeft(2, '0') + dt.Year.ToString().PadLeft(4, '0').Substring(2);
                        try
                        {
                            ds = d.get_7(i_nhomkho, s_mmyy, mmyy, "", s_makho);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                frmTruyvandate f1 = new frmTruyvandate(mmyy, ds);
                                f1.ShowDialog();
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }
			gan_right();
            // hien them
            //if (d.bDanhmuc_luu_server)
            //{
            //    d.ChuyenCauNoiQuaServerTrungtam(true);
            //    this.Text = this.Text + " - Bạn đang kết nối tới server trung tâm";
            //}
            // end hien
		}
        private void gan_right()
        {
            s_right = "+" + s_right.Trim().Trim('+') + "+";
            int n = 0, t = 0;
            bool bx = false;
            for (int i = 0; i < this.mainMenu1.MenuItems.Count - 3; i++)
            {
                bx = false;

                for (int j = 0; j < this.mainMenu1.MenuItems[i].MenuItems.Count; j++)
                {

                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems.Count == 0)
                    {
                        if (this.mainMenu1.MenuItems[i].MenuItems[j].Text != "-")
                        {
                            this.mainMenu1.MenuItems[i].MenuItems[j].Visible = s_right.IndexOf("+" + this.mainMenu1.MenuItems[i].MenuItems[j].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1;
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
                                    this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = s_right.IndexOf("+" + this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1;
                                else this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible = false;
                                n += (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].Visible) ? 1 : 0;

                            }
                            else
                            {
                                t = 0;
                                for (int s = 0; s < this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems.Count; s++)
                                {
                                    if (this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Text != "-")
                                        this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].Visible = s_right.IndexOf("+" + this.mainMenu1.MenuItems[i].MenuItems[j].MenuItems[k].MenuItems[s].MergeOrder.ToString().PadLeft(3, '0') + "+") != -1;
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

            #region loaikho
            this.menuItem41.Enabled = i_loaikho == 1;
            this.menuItem95.Enabled = i_loaikho == 1;
            this.menuItem74.Enabled = i_loaikho == 1;
            this.menuItem75.Enabled = i_loaikho == 1;
            this.menuItem76.Enabled = i_loaikho == 1;
            this.menuItem77.Enabled = i_loaikho == 1;
            this.menuItem78.Enabled = i_loaikho == 1;
            this.menuItem96.Enabled = i_loaikho == 1;
            this.menuItem97.Enabled = i_loaikho == 1;
            this.menuItem116.Enabled = i_loaikho == 1;
            this.menuItem118.Enabled = i_loaikho == 1;
            this.menuItem126.Enabled = i_loaikho == 1;
            this.menuItem171.Enabled = i_loaikho == 1;
            this.menuItem172.Enabled = i_loaikho == 1;
            this.menuItem173.Enabled = i_loaikho == 1;
            this.menuItem174.Enabled = i_loaikho == 1;
            this.menuItem175.Enabled = i_loaikho == 1;
            this.menuItem176.Enabled = i_loaikho == 1;
            #endregion
            this.menuItem26.Visible = true;
            this.menuItem27.Text = "Log Off " + s_userid.ToString().Trim();
            this.menuItem27.Visible = true;
            this.menuItem104.Visible = true;
            //this.menuItem110.Visible=true;
            this.menuItem146.Visible = true;
            this.menuItem113.Visible = true;
            if (this.menuItem142.Visible) this.menuItem142.Visible = d.bQuanlynguon(i_nhomkho);
            if (s_userid == LibDuoc.AccessData.links_userid + LibDuoc.AccessData.links_pass)
            {
                this.menuItem3.Visible = true;
                this.mnuRight_Bv.Visible = true;
                this.menuItem23.Visible = true;
                this.menuItem150.Visible = true;
                this.menuItem102.Visible = true;
                this.menuItem9.Visible = true;
                this.menuItem28.Visible = true;
                this.menuItem27.Text = "Log Off " + LibDuoc.AccessData.links_userid.ToString();
                this.Text = d.Msg;
            }
            if (this.menuItem37.Visible) this.menuItem37.Visible = d.get_data("select * from " + user + ".d_dmkho where nhom=" + i_nhomkho).Tables[0].Rows.Count > 1;
            if (this.menuItem225.Visible && !b_admin) this.menuItem225.Visible = false;
            if (this.menuItem228.Visible && !b_admin) this.menuItem228.Visible = false;
            #region quan ly kho
            if (d.Mabv_so == 101102)
            {
                this.menuItem205.Visible = false;
                this.menuItem115.Visible = false;
                this.menuItem116.Visible = false;
                this.menuItem118.Visible = false;
                //this.menuItem128.Visible = false;
                this.menuItem142.Visible = false;
                this.menuItem166.Visible = false;
                this.menuItem167.Visible = false;
                this.menuItem133.Visible = false;
                this.menuItem123.Visible = false;
                this.menuItem206.Visible = false;
                this.menuItem196.Visible = false;
                this.menuItem183.Visible = false;
                this.menuItem93.Visible = false;
                this.menuItem154.Visible = false;
                this.menuItem113.Visible = false;
                this.menuItem150.Visible = false;
                this.menuItem73.Visible = false;
                this.menuItem79.Visible = false;
                this.menuItem135.Visible = false;
                this.menuItem200.Visible = false;
                this.menuItem199.Visible = false;
                this.menuItem198.Visible = false;
                this.menuItem77.Visible = false;
                this.menuItem76.Visible = false;
                this.menuItem153.Visible = false;
                this.menuItem126.Visible = false;
                this.menuItem75.Visible = false;
                this.menuItem74.Visible = false;
                this.menuItem78.Visible = false;
                this.menuItem171.Visible = false;
                this.menuItem172.Visible = false;
                this.menuItem175.Visible = false;
                this.menuItem176.Visible = false;
                this.menuItem155.Visible = false;
            }
            #endregion
        }

		

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
            frmAbout f = new frmAbout("duoc",f_get_menu(),i_nhomkho,s_mmyy);
            f.MdiParent = this;
            f.Show();		
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
            try
            {
                DataSet ads_menu = new DataSet();
                try
                {
                    ads_menu = d.get_data("select * from " + user + ".d_menuitem order by id");
                    int i = int.Parse(ads_menu.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    d.execute_data(" create table " + user + ".d_menuitem(id varchar(5),id_goc varchar(5),stt numeric(5) default 0,id_menu varchar(5),ten text  ,constraint pk_d_menuitem primary key(id)) WITH OIDS;");
                    ads_menu = d.get_data("select * from " + user + ".d_menuitem order by id");
                }
                if (ads_menu.Tables[0].Rows.Count <= 0)
                {
                    if (IsLoaded("frmRight")) return;
                    frmRight f = new frmRight(d, i_nhomkho, s_userid, f_get_menu());
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    if (IsLoaded("frmRight")) return;
                    frmRight f = new frmRight(d, i_nhomkho, s_userid);
                    f.MdiParent = this;
                    f.Show();
                }
            }
            catch
            { }

			
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
                if (mnuitem == menuItem4 || mnuitem == menuItem5 || mnuitem == menuItem6) break;

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
                    if (amenu.Text != "-" && amenu != mnuRight_Bv)
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
		private void menuItem24_Click(object sender, System.EventArgs e)
		{
            try
            {
                string s_userid = d.get_data("select userid from " + user + ".d_dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
                string s_psw = d.get_data("select password_ from " + user + ".d_dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
                frmUser f = new frmUser(d, d.get_data("select * from " + user + ".d_dlogin"), i_userid, s_userid, s_psw, s_right, i_nhomkho, s_makho, s_makp, false, s_manhom, s_userid, s_loaint, s_loaikhac);
                f.ShowDialog(this);
            }
            catch { }
		}

		private void menuItem27_Click(object sender, System.EventArgs e)
		{
			menuItem14_Click(null,null);
			frmLogin f=new frmLogin(d);
			f.ShowDialog(this);
            if (f.mUserid != "")
            {
                s_userid = f.mUserid;
                s_right = f.mRight;
                i_userid = f.iUserid;
                i_nhomkho = f.iNhomkho;
                i_loaikho = d.get_loai(i_nhomkho);
                s_makho = f.mMakho;
                s_makp = f.mMakp;
                s_manhom = f.mManhom;
                s_mmyy = f.mMmyy;
                s_ngay = f.mNgay;
                b_admin = f.bAdmin;
                b_thuhoi = f.bThuhoi;
                s_loaint = f.mLoaint; s_loaikhac = f.mLoaikhac;
                d.writeXml("d_thongso", "kho", (f.mTennhom == "") ? "Dược" : f.mTennhom);
                s_nhomkho = f.mTennhom;
                
                //
                f_get_khudieutri();
                i_chinhanh = f.i_chinhanh;
                //
                if (this.menuItem27.Text != "Log Off ") this.Text = f.mTennhom + " - " + s_ngay + " - " + s_userid.Trim() + " - Tháng " + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                this.menuItem17.Text = "&2. About " + d.Msg;
                if (i_nhomkho != 0) b_giaban = int.Parse(d.get_data("select nhom from " + user + ".d_dmnhomkho where id=" + i_nhomkho).Tables[0].Rows[0][0].ToString()) == 1;
                if (!b_giaban) b_giaban = d.bGiaban_nguon(i_nhomkho);
                d.upd_thongso_xml(i_nhomkho);
            }
            else
            {
                Application.Exit();
                return;
            }
			gan_right();
		}

		private void menuItem25_Click(object sender, System.EventArgs e)
		{
            if (IsLoaded("frmThumuc")) return;
            frmThumuc f = new frmThumuc(d.get_data("select ten from " + user + ".d_thongso where id=3").Tables[0].Rows[0][0].ToString(), "Chọn thư mục sao lưu số liệu", 1, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem22_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmThongso")) return;
            frmThongso f = new frmThongso(d, s_mmyy, i_nhomkho, i_userid, b_giaban, b_admin);
            f.ShowDialog();
        }

        private void menuItem28_Click(object sender, System.EventArgs e)
        {
            frmDmnhomkho f = new frmDmnhomkho(d, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem29_Click(object sender, System.EventArgs e)
        {
            frmDmkho f = new frmDmkho(d, i_nhomkho, s_mmyy, i_userid,i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem11_Click(object sender, System.EventArgs e)
        {
            frmDmnhom f = new frmDmnhom(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem18_Click(object sender, System.EventArgs e)
        {
            frmDmloai f = new frmDmloai(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem20_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmnuoc")) return;
            frmDmnuoc f = new frmDmnuoc(d, i_nhomkho, b_admin);
            f.MdiParent = this;
            f.Show();
        }

  
        private void menuItem30_Click(object sender, System.EventArgs e)
        {
            frmDmnguon f = new frmDmnguon(d, i_nhomkho, s_mmyy, i_userid);
            f.MdiParent = this;
            f.Show();
        }

         private void menuItem34_Click(object sender, System.EventArgs e)
        {
            frmDuockp f = new frmDuockp(d, "d_duockp", "Danh mục khoa/phòng", i_nhomkho, s_mmyy, i_userid, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem33_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmnx")) return;
            frmDmnx f = new frmDmnx(d, i_nhomkho, s_mmyy, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem31_Click(object sender, System.EventArgs e)
        {
            frmDmnhomkt f = new frmDmnhomkt(d, i_nhomkho, "d_dmnhomkt", "Danh mục nhóm kế toán", i_userid, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem19_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmhang")) return;
            frmDmhang f = new frmDmhang(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem36_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmbhyt")) return;
            frmDmbhyt f = new frmDmbhyt(d);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem89_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmhoatchat")) return;
            frmDmhoatchat f = new frmDmhoatchat(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDmbd")) return;
            frmDmbd f = new frmDmbd(d, i_nhomkho, i_loaikho, s_mmyy, b_giaban, b_admin, s_manhom, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem90_Click(object sender, System.EventArgs e)
        {
            frmDmphieu f = new frmDmphieu(d, i_nhomkho, s_makho, "d_dmphieu", "Danh mục nhóm phiếu");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem91_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmLoaiphieu")) return;
            frmLoaiphieu f = new frmLoaiphieu(d, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            m = new LibMedi.AccessData();
            //if (m.bQuanly_Theo_Chinhanh)
            //{
            //    if (IsLoaded("frmNhap_hepa")) return;
            //    //frmNhap_hepa f = new frmNhap_hepa(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, b_admin, s_manhom, i_khudt);
            //    frmNhap_hepa f = new frmNhap_hepa(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, b_admin, s_manhom, i_khudt,i_chinhanh);
            //    f.MdiParent = this;
            //    f.Show();
            //}
            //else
            //{
                if (IsLoaded("frmNhap")) return;
                frmNhap f = new frmNhap(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, b_admin, s_manhom, i_khudt);
                f.MdiParent = this;
                f.Show();
            //}
        }

        private void menuItem82_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNhap")) return;
            frmNhap f = new frmNhap(d, "T", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu tái nhập kho", b_giaban, b_admin, s_manhom,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem37_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXchuyenkho")) return;
            frmXchuyenkho f = new frmXchuyenkho(d, "CK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất chuyển kho", b_giaban, b_admin, false,s_userid,false,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem95_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtonct")) return;
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmKbtonct f1 = new frmKbtonct(d, f.mmyy, i_nhomkho, f.i_makho, f.tenkho, b_giaban, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem70_Click(object sender, System.EventArgs e)
        {
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtonct f1 = new frmXemtonct(d, f.i_makho, f.mmyy, f.tenkho, b_giaban, i_nhomkho,s_makho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem98_Click(object sender, System.EventArgs e)
        {
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtonth f1 = new frmXemtonth(d, f.i_makho, f.mmyy, f.tenkho, i_nhomkho, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem42_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXkhac")) return;
            if (d.bXuatkhac_chochondotxuat(i_nhomkho) == false)
            {
                frmXkhac f = new frmXkhac(d, "XK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất khác", b_giaban, b_admin, s_loaikhac, s_userid, false);
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                if (IsLoaded("frmXhtncc")) return;
                frmXhtncc f1 = new frmXhtncc(d, "XK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất khác", b_giaban, b_admin,true);
                f1.MdiParent = this;
                f1.Show();
            }

        }

        private void menuItem38_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPhieulanh")) return;
            frmPhieulanh f = new frmPhieulanh(d, (i_loaikho == 2) ? 4 : 1, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu lĩnh theo khoa/phòng", b_giaban, i_loaikho, b_admin,false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem39_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPhieuhoantra")) return;
            frmPhieuhoantra f = new frmPhieuhoantra(d, 3, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makp, "Phiếu hoàn trả theo khoa/phòng", b_giaban, i_loaikho, b_admin,false,s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem102_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTVuser")) return;
            frmTVuser f = new frmTVuser(d);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem41_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNgoaitru")) return;
            int i_loai = 6, i_quayban = 0;
            string ngay = s_ngay, s_kho = "";
            bool bChon = false;
            if (d.bKho_ngoaitru(i_nhomkho))
            {
                s_kho = d.get_dmkho(i_loai).Trim();
                s_kho = (s_kho == "") ? "" : s_kho.Substring(0, s_kho.Length - 1);
                frmChonkhoxb f1 = new frmChonkhoxb(d, i_nhomkho, s_makho, s_kho + ",", s_mmyy, s_ngay, "Loại", false, s_loaint);
                f1.ShowDialog(this);
                if (f1.mmyy != "")
                {
                    int i_makho = f1.i_makho;
                    s_kho = i_makho.ToString().Trim() + ",";
                    i_quayban = f1.i_quaythu;
                    ngay = f1.s_ngay;
                }
                else s_kho = "";
                bChon = true;
            }
            else s_kho = s_makho;
            if (bChon && s_kho == "") return;
            frmNgoaitru f = new frmNgoaitru(d, 6, s_mmyy, ngay, i_nhomkho, i_userid, s_kho, s_makp, "Phiếu xuất ngoại trú", b_giaban, b_admin, i_quayban, s_loaint);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem69_Click(object sender, System.EventArgs e)
        {
            frmMultikho f = new frmMultikho(d, i_nhomkho, s_makho, s_mmyy, i_userid);
            f.ShowDialog(this);
        }

        private void menuItem104_Click(object sender, System.EventArgs e)
        {
            menuItem14_Click(null, null);
            frmDoingay f = new frmDoingay(d, s_mmyy, i_nhomkho, i_userid);
            f.ShowDialog();
            if (f.mMmyy != "")
            {
                s_mmyy = f.mMmyy; s_ngay = f.mNgay;
                if (this.menuItem27.Text != "Log Off ") this.Text = s_nhomkho + " - " + s_ngay + " - " + s_userid.Trim() + " - Tháng " + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
            }
        }

        private void menuItem40_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBaohiem")) return;
            frmBaohiem f = new frmBaohiem(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất bảo hiểm", b_admin, 1, 3, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem44_Click(object sender, System.EventArgs e)
        {
            frmDanhmuc f = new frmDanhmuc(d, i_nhomkho, i_userid, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem106_Click(object sender, System.EventArgs e)
        {
            rptBbknhap f = new rptBbknhap(d, i_nhomkho, s_makho, "d_bbknhap.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem61_Click(object sender, System.EventArgs e)
        {
            rptBbkiemke f = new rptBbkiemke(d, i_nhomkho, s_makho, s_mmyy, false, false, "d_tonkhoct", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem105_Click(object sender, System.EventArgs e)
        {
            rptThpnhap f = new rptThpnhap(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem51_Click(object sender, System.EventArgs e)
        {
            rptTh_chitiet f = new rptTh_chitiet(d, i_nhomkho, s_mmyy, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem65_Click(object sender, System.EventArgs e)
        {
            rptSochitiet f = new rptSochitiet(d, i_nhomkho, s_makho, s_mmyy, b_giaban, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem64_Click(object sender, System.EventArgs e)
        {
            rptKiemkekho f = new rptKiemkekho(d, i_nhomkho, s_makho, s_mmyy, "d_kiemkekho.rpt", "Phiếu kiểm kê kho", i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem107_Click(object sender, System.EventArgs e)
        {
            frmNhombc f = new frmNhombc(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem63_Click(object sender, System.EventArgs e)
        {

        }

        private void menuItem66_Click(object sender, System.EventArgs e)
        {
            rptThekho f = new rptThekho(d, i_nhomkho, s_makho, s_mmyy, "d_sokho.rpt", "Số kho", b_giaban,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem67_Click(object sender, System.EventArgs e)
        {
            rptThekho f = new rptThekho(d, i_nhomkho, s_makho, s_mmyy, (d.bThekho_congdon(i_nhomkho)) ? "d_thekho_ngay.rpt" : "d_thekho.rpt", "Thẻ kho", b_giaban,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem62_Click(object sender, System.EventArgs e)
        {
            rptBbthanhly f = new rptBbthanhly(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem56_Click(object sender, System.EventArgs e)
        {
            rptDaphat f = new rptDaphat(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem63_Click_1(object sender, System.EventArgs e)
        {
            frmNhomctd f = new frmNhomctd(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem58_Click(object sender, System.EventArgs e)
        {
            rptDanhap f = new rptDanhap(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem59_Click(object sender, System.EventArgs e)
        {
            frmDuocbv f = new frmDuocbv(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem57_Click(object sender, System.EventArgs e)
        {
            rptCtduoc f = new rptCtduoc(d, i_nhomkho, s_makho,i_userid );
            f.MdiParent = this;
            f.Show();
        }


        private void menuItem68_Click(object sender, System.EventArgs e)
        {
            rptBcngay f = new rptBcngay(d, i_nhomkho, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem96_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtutrucct")) return;
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmKbtutrucct f1 = new frmKbtutrucct(d, f.mmyy, f.i_makp, i_nhomkho, f.i_makho, f.tenkho, b_giaban, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem110_Click_1(object sender, System.EventArgs e)
        {
            d.writeXml("d_netsend", "ma", "");
            d.writeXml("d_netsend", "ten", "");
            NetSend f = new NetSend();
            f.ShowDialog(this);
        }

        private void menuItem93_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTangcstt")) return;
            frmTangcstt f = new frmTangcstt(d, "BS", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất tăng cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem72_Click(object sender, System.EventArgs e)
        {
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutrucct f1 = new frmXemtutrucct(d, f.i_makho, f.i_makp, f.mmyy, f.tenkho, b_giaban, i_nhomkho, f.tenkp, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem99_Click(object sender, System.EventArgs e)
        {
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutructh f1 = new frmXemtutructh(d, f.i_makho, f.i_makp, f.mmyy, f.tenkho, i_nhomkho, f.tenkp,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem71_Click(object sender, System.EventArgs e)
        {
            frmMultikhoa f = new frmMultikhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy, i_userid);
            f.ShowDialog(this);
        }

        private void menuItem94_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantracstt")) return;
            frmHoantracstt f = new frmHoantracstt(d, "HT", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất hoàn trả cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem43_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantracstt")) return;
            frmHoantracstt f = new frmHoantracstt(d, "TH", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất thu hồi cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem109_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXuatcstt")) return;
            frmXuatcstt f = new frmXuatcstt(d, 2, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất tủ trực", b_giaban, b_admin, i_loaikho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem77_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDutru")) return;
            frmDutru f = new frmDutru(d, i_nhomkho, s_ngay, 1, i_userid, s_userid, s_makp, s_mmyy, s_makho, b_giaban, b_thuhoi,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem116_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmXuatban")) return;
            int i_loai = 7, i_quayban = 0;
            string tenquay = "", tenkho = "", ngay = s_ngay, s_kho = d.get_dmkho(i_loai).Trim();
            s_kho = (s_kho == "") ? "" : s_kho.Substring(0, s_kho.Length - 1);
            frmChonkhoxb f = new frmChonkhoxb(d, i_nhomkho, s_makho, s_kho + ",", s_mmyy, s_ngay, "Quầy", true, s_loaint);
            f.ShowDialog(this);
            if (f.mmyy != "")
            {
                int i_makho = f.i_makho;
                tenkho = f.tenkho; tenquay = f.tenquay;
                s_kho = i_makho.ToString().Trim() + ",";
                i_quayban = f.i_quaythu;
                ngay = f.s_ngay;
            }
            else s_kho = "";
            int fs_admin = 2;
            bool flag = false;//Thuy 29.02.2012
            int user_vdlogin = -1;//Thuy 29.02.2012
            if (s_kho != "")
            {
                string sohieu = ""; int i_kyhieu = 0;
                if (d.bBienlai_sohieu(i_nhomkho))
                {
                    frmSohieu fs = new frmSohieu();
                    fs.ShowDialog();
                    if (fs.iKyhieu != 0)
                    {
                        fs_admin = fs.iAdmin;
                        sohieu = d.Thongso("v_thongso", "c01");
                        i_kyhieu = fs.iKyhieu;
                        flag = true;//Thuy 29.02.2012
                        user_vdlogin = fs.iuserid;//Thuy 29.02.2012
                    }
                    else
                    {
                        return;//Thuy 24.02.2012
                    }
                }


                frmXuatban f2 = new frmXuatban(d, i_loai, s_mmyy, ngay, i_nhomkho, i_userid, s_kho, s_makp, "Phiếu xuất bán", b_giaban, s_userid, b_admin, i_quayban, tenkho, tenquay, b_thuhoi, sohieu, i_kyhieu);//Thuy 29.02.2012
                //Thuy 29.02.2012
                if (flag)
                {
                    f2.Userid_vp = user_vdlogin;
                }
                //Thuy 24.02.2012
                if (fs_admin == 1)
                {
                    f2.Quantri = true;
                }
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem75_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantra")) return;
            frmHoantra f = new frmHoantra(d, i_nhomkho, s_ngay, 3, i_userid, s_userid, s_makp, s_mmyy, s_makho, b_giaban, b_thuhoi, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem118_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTrathuoc")) return;
            int i_loai = 7, i_quayban = 0;
            string ngay = s_ngay, s_kho = d.get_dmkho(i_loai).Trim();
            s_kho = (s_kho == "") ? "" : s_kho.Substring(0, s_kho.Length - 1);
            frmChonkhoxb f1 = new frmChonkhoxb(d, i_nhomkho, s_makho, s_kho + ",", s_mmyy, s_ngay, "Quầy", true, s_loaint);
            f1.ShowDialog(this);
            if (f1.mmyy != "")
            {
                int i_makho = f1.i_makho; i_quayban = f1.i_quaythu;
                s_kho = i_makho.ToString() + ","; ngay = f1.s_ngay;
            }
            else s_kho = "";
            if (s_kho != "")
            {
                frmTrathuoc f = new frmTrathuoc(d, "N", s_mmyy, ngay, i_nhomkho, i_userid, s_kho, "Phiếu trả thuốc", b_giaban, b_admin, s_userid, i_quayban, s_loaint, b_thuhoi);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem119_Click(object sender, System.EventArgs e)
        {
            rptKiemkekho f = new rptKiemkekho(d, i_nhomkho, s_makho, s_mmyy, "d_bctonkho.rpt", "Danh sách tồn kho",i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem121_Click(object sender, System.EventArgs e)
        {
            rptBbknhap f = new rptBbknhap(d, i_nhomkho, s_makho, "d_bbknhap_ct.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem122_Click(object sender, System.EventArgs e)
        {
            frmDoituong f = new frmDoituong(d, "d_doituong", i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem74_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHaophi")) return;
            frmHaophi f = new frmHaophi(d, i_nhomkho, s_ngay, 4, i_userid, "Duyệt dù trù hao phí thuốc, vật tư y tế theo khoa/phòng (" + s_userid.Trim() + ")", s_makp, s_mmyy, s_makho, b_giaban, 1, b_thuhoi, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem123_Click(object sender, System.EventArgs e)
        {
            if (d.bYlenh_cachdung(i_nhomkho))
            {
                frmYlenh_cd f1 = new frmYlenh_cd(i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                frmYlenh f2 = new frmYlenh(i_nhomkho);
                f2.MdiParent = this;
                f2.Show();
            }
        }

        private void menuItem124_Click(object sender, System.EventArgs e)
        {
            frmInphieuxuat f1 = new frmInphieuxuat(i_nhomkho, s_makho, s_mmyy, i_userid);
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem125_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmCosotutruc")) return;
            frmChon1khoa f = new frmChon1khoa(d, i_nhomkho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmCosotutruc f1 = new frmCosotutruc(d, f.mmyy, f.i_makp, i_nhomkho, f.tenkp,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem76_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmButruc")) return;
            frmButruc f = new frmButruc(d, i_nhomkho, s_ngay, 2, i_userid, s_userid, s_makp, s_mmyy, s_makho, b_giaban, false, b_thuhoi, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem126_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBuhaophi")) return;
            frmBuhaophi f = new frmBuhaophi(d, i_nhomkho, s_ngay, 2, i_userid, s_userid, s_makp, s_mmyy, s_makho, b_giaban, b_thuhoi, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem127_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPhatbhyt")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                if (d.bQuanly_xuatban_theomavach(i_nhomkho))
                {
                    frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 1, 3, i_userid, s_makho, b_thuhoi);
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    frmPhatbhyt f = new frmPhatbhyt(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 1, 3, i_userid, s_makho, b_thuhoi);
                    f.MdiParent = this;
                    f.Show();
                }
            }
        }

        private void menuItem129_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí bảo hiểm", b_admin, 1, 3, s_userid, b_thuhoi, false, i_khudt,false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem78_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantrathua")) return;
            string s_kho = "";
            foreach (DataRow r in d.get_data("select * from " + user + ".d_dmkho where thua=1 and nhom=" + i_nhomkho).Tables[0].Rows) s_kho += r["id"].ToString().Trim() + ",";
            if (s_kho != "")
            {
                frmHoantrathua f = new frmHoantrathua(d, i_nhomkho, s_ngay, 3, i_userid, "Duyệt hoàn trả thừa theo khoa (" + s_userid.Trim() + ")", s_makp, s_mmyy, s_kho, b_giaban, 1, b_thuhoi, s_userid, i_khudt);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem114_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHaophi")) return;
            frmHaophi f = new frmHaophi(d, i_nhomkho, s_ngay, 4, i_userid, "Duyệt cấp tài sản (" + s_userid.Trim() + ")", s_makp, s_mmyy, s_makho, b_giaban, 2, b_thuhoi, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem113_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantrathua")) return;
            frmHoantrathua f = new frmHoantrathua(d, i_nhomkho, s_ngay, 3, i_userid, "Duyệt hoàn trả tài sản (" + s_userid.Trim() + ")", s_makp, s_mmyy, s_makho, b_giaban, 2, b_thuhoi, s_userid, i_khudt );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem130_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBiendong")) return;
            frmBiendong f = new frmBiendong(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

  
        private void menuItem131_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmIndmbd")) return;
            frmIndmbd f = new frmIndmbd(i_nhomkho, s_makho, s_mmyy,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem132_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmhandung")) return;
            frmhandung f = new frmhandung(i_nhomkho, s_makho, s_mmyy, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem140_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKiemtra")) return;
            menuItem14_Click(sender, e);
            frmKiemtra f = new frmKiemtra(d, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem142_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmChuyennguon")) return;
            frmChuyennguon f = new frmChuyennguon(d, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất chuyển nguồn", b_giaban, b_admin);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem144_Click(object sender, System.EventArgs e)
        {
            frmtoabanle f = new frmtoabanle(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem117_Click(object sender, System.EventArgs e)
        {
            frmThutien f = new frmThutien(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem145_Click(object sender, System.EventArgs e)
        {
            frmNxt_nhathuoc f = new frmNxt_nhathuoc(d, i_nhomkho, s_mmyy, s_makho,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem138_Click(object sender, System.EventArgs e)
        {
            frmNhomkhoa f = new frmNhomkhoa(d);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem139_Click(object sender, System.EventArgs e)
        {
            frmKinhphi f = new frmKinhphi(d, i_nhomkho, s_mmyy.Substring(2, 2));
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem146_Click(object sender, System.EventArgs e)
        {
            LibMedi.AccessData m = new LibMedi.AccessData();
            string file = @"wordpad.exe";
            string fileToOpen = @m.Path_thongbao;//"..\\..\\..\\doc\\thongbao.rtf";
            backup f = new backup(file, fileToOpen, true);
            f.Launch();
        }

        private void menuItem147_Click(object sender, System.EventArgs e)
        {
            frmCongno f = new frmCongno(d, s_mmyy, i_nhomkho, i_userid, s_ngay,s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem148_Click(object sender, System.EventArgs e)
        {
            frmxempx f = new frmxempx(s_mmyy, s_makho, i_nhomkho, i_userid, s_ngay);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem83_Click(object sender, System.EventArgs e)
        {
            //Kiem tra xem co nhieu chi nhanh khong?
            bool bCungChiNhanh = true;
            int i_IDChinhanhXuat = 0;
            if (bNhieuchinhanh())
            {
                frmChonChinhanh ff = new frmChonChinhanh();
                ff.ShowDialog();
                bCungChiNhanh = ff.bCungchinhanh;
                i_IDChinhanhXuat = ff.i_ChiNhanhXuat;
            }
            //
            frmDutrucap f = new frmDutrucap(d, "CK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu dự trù cấp", b_admin, bCungChiNhanh, i_IDChinhanhXuat);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem80_Click(object sender, System.EventArgs e)
        {
            bool bCungChiNhanh = true;
            int i_IDChinhanhXuat = 0;
            if (bNhieuchinhanh())
            {
                frmChonChinhanh ff = new frmChonChinhanh();
                ff.ShowDialog();
                bCungChiNhanh = ff.bCungchinhanh;
                i_IDChinhanhXuat = ff.i_ChiNhanhXuat;
            }
            //
            string s_LoaiXuat = (bCungChiNhanh) ? "CK" : "XC";
            if (bCungChiNhanh)
            {
                //if (IsLoaded("frmXchuyenkho")) return;
                frmXchuyenkho f = new frmXchuyenkho(d, "CK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất chuyển kho", b_giaban, b_admin, true, s_userid, false, i_khudt);
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                if (IsLoaded("frmXLuanchuyenCN")) return;
                if (d.bXuatkhac_chochondotxuat(i_nhomkho) == false)
                {
                    frmXLuanchuyenCN f = new frmXLuanchuyenCN(d, "XC", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất luân chuyển cho chi nhánh.", b_giaban, b_admin, s_loaikhac, s_userid, false, i_chinhanh, true);
                    f.IDChiNhanhNhan = i_IDChinhanhXuat;
                    f.MdiParent = this;
                    f.Show();
                }
            }
        }

        private void menuItem149_Click(object sender, System.EventArgs e)
        {
            rptNxt_CK_thang f = new rptNxt_CK_thang(d, i_nhomkho, s_makho, s_mmyy, "d_bcnxt_ck.rpt", false, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem150_Click(object sender, System.EventArgs e)
        {
            frmKiemtrakhoa f = new frmKiemtrakhoa(d, i_nhomkho,s_ngay);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem151_Click(object sender, System.EventArgs e)
        {
            rptXuatkho f = new rptXuatkho(d, i_nhomkho, s_makho, s_mmyy, "d_dasudung.rpt",i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem152_Click(object sender, System.EventArgs e)
        {
            rptXuat_CT f = new rptXuat_CT(d, i_nhomkho, s_makho, s_mmyy, "rptXuat_ct.rpt");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem148_Click_1(object sender, System.EventArgs e)
        {
            rpttreemd6t f = new rpttreemd6t(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem153_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmButruc")) return;
            frmButruc f = new frmButruc(d, i_nhomkho, s_ngay, 2, i_userid, s_userid, s_makp, s_mmyy, s_makho, b_giaban, true, b_thuhoi, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem155_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmdsduyet")) return;
            frmdsduyet f = new frmdsduyet(s_ngay);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem156_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmxkngay")) return;
            frmxkngay f = new frmxkngay(d, i_nhomkho, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem158_Click(object sender, System.EventArgs e)
        {
            frmNxt_khoa f = new frmNxt_khoa(d, i_nhomkho, s_mmyy, s_makho,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem160_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDSdutru_duyet")) return;
            frmDSdutru_duyet f = new frmDSdutru_duyet(d, s_makp, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem154_Click(object sender, System.EventArgs e)
        {
            frmDmbdgia f = new frmDmbdgia(d, i_nhomkho, s_mmyy, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem155_Click_1(object sender, System.EventArgs e)
        {
            frmDmvay f = new frmDmvay(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem162_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtonvayct")) return;
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmKbtonvayct f1 = new frmKbtonvayct(d, f.i_makp, i_nhomkho, f.i_makho, f.tenkho, b_giaban, s_mmyy,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem163_Click(object sender, System.EventArgs e)
        {
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmXemtonvayct f1 = new frmXemtonvayct(d, f.i_makho, f.i_makp, f.tenkho, b_giaban, i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem164_Click(object sender, System.EventArgs e)
        {
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmXemtonvayth f1 = new frmXemtonvayth(d, f.i_makho, f.i_makp, f.tenkho, i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem166_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmVay")) return;
            frmVay f = new frmVay(d, "VA", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất vay", b_giaban, b_admin);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem167_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmQuyettoanvay")) return;
            frmQuyettoanvay f = new frmQuyettoanvay(d, "QT", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất vay", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem170_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBaohiem")) return;
            frmBaohiem f = new frmBaohiem(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất bảo hiểm", b_admin, 1, 3, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem171_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPhat_bhyt")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                if (d.bQuanly_xuatban_theomavach(i_nhomkho))
                {
                    frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 1, 3, i_userid, s_makho, b_thuhoi);
                    f.Name = "frmPhat_bhyt";
                    f.PhatKhongNgoaiTru = true;
                    f.PhatCaNgoaitru = false;
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    frmPhatbhyt f = new frmPhatbhyt(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 1, 3, i_userid, s_makho, b_thuhoi);
                    f.Name = "frmPhat_bhyt";
                    f.MdiParent = this;
                    f.Show();
                }
            }
        }

        private void menuItem172_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí bảo hiểm", b_admin, 1, 3, s_userid,b_thuhoi,false,i_khudt,false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem174_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmBaohiem")) return;
            frmBaohiem f = new frmBaohiem(d, 6, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất ngoại trú", b_admin, 0, 3, s_userid,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem175_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmPhat_khongBHYT")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 0, 3, i_userid, s_makho,b_thuhoi);
                f.Name = "frmPhat_khongBHYT";
                f.PhatKhongNgoaiTru = true;
                f.PhatCaNgoaitru = false;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem176_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 6, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí Không BHYT", b_admin, 0, 3, s_userid,b_thuhoi,false,i_khudt,false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem143_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("rptChiphi")) return;
            rptChiphi f = new rptChiphi(d, i_nhomkho, s_makho, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem129_Click_1(object sender, System.EventArgs e)
        {
            rptBhyt f = new rptBhyt(d, i_nhomkho, s_makho, 1,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem54_Click_1(object sender, System.EventArgs e)
        {
            rpttreemd6t f = new rpttreemd6t(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem134_Click_1(object sender, System.EventArgs e)
        {
            frmtoabanle f = new frmtoabanle(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem148_Click_2(object sender, System.EventArgs e)
        {
            frmNxt_nhathuoc f = new frmNxt_nhathuoc(d, i_nhomkho, s_mmyy, s_makho,i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem178_Click(object sender, System.EventArgs e)
        {
            frmThutien f = new frmThutien(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem145_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtonct")) return;
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmKbtonct f1 = new frmKbtonct(d, f.mmyy, i_nhomkho, f.i_makho, f.tenkho, b_giaban, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem179_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtutrucct")) return;
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmKbtutrucct f1 = new frmKbtutrucct(d, f.mmyy, f.i_makp, i_nhomkho, f.i_makho, f.tenkho, b_giaban, i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem180_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmCosotutruc")) return;
            frmChon1khoa f = new frmChon1khoa(d, i_nhomkho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmCosotutruc f1 = new frmCosotutruc(d, f.mmyy, f.i_makp, i_nhomkho, f.tenkp,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem184_Click(object sender, System.EventArgs e)
        {
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtonct f1 = new frmXemtonct(d, f.i_makho, f.mmyy, f.tenkho, b_giaban, i_nhomkho,s_makho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem185_Click(object sender, System.EventArgs e)
        {
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtonth f1 = new frmXemtonth(d, f.i_makho, f.mmyy, f.tenkho, i_nhomkho,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem186_Click(object sender, System.EventArgs e)
        {
            frmMultikho f = new frmMultikho(d, i_nhomkho, s_makho, s_mmyy, i_userid);
            f.ShowDialog(this);
        }

        private void menuItem187_Click(object sender, System.EventArgs e)
        {
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy,true );
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutrucct f1 = new frmXemtutrucct(d, f.i_makho, f.i_makp, f.mmyy, f.tenkho, b_giaban, i_nhomkho, f.tenkp,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem188_Click(object sender, System.EventArgs e)
        {
            frmChonkhoa f = new frmChonkhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy,true );
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtutructh f1 = new frmXemtutructh(d, f.i_makho, f.i_makp, f.mmyy, f.tenkho, i_nhomkho, f.tenkp,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem189_Click(object sender, System.EventArgs e)
        {
            frmMultikhoa f = new frmMultikhoa(d, i_nhomkho, s_makho, s_makp, s_mmyy, i_userid);
            f.ShowDialog(this);
        }

        private void menuItem69_Click_1(object sender, System.EventArgs e)
        {
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmXemtonvayct f1 = new frmXemtonvayct(d, f.i_makho, f.i_makp, f.tenkho, b_giaban, i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem70_Click_1(object sender, System.EventArgs e)
        {
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmXemtonvayth f1 = new frmXemtonvayth(d, f.i_makho, f.i_makp, f.tenkho, i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem71_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtonvayct")) return;
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmKbtonvayct f1 = new frmKbtonvayct(d, f.i_makp, i_nhomkho, f.i_makho, f.tenkho, b_giaban, s_mmyy,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem95_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTangcstt")) return;
            frmTangcstt f = new frmTangcstt(d, "BS", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất tăng cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem96_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantracstt")) return;
            frmHoantracstt f = new frmHoantracstt(d, "HT", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất hoàn trả cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem97_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmHoantracstt")) return;
            frmHoantracstt f = new frmHoantracstt(d, "TH", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất thu hồi cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem117_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("rptChiphi")) return;
            rptChiphi f = new rptChiphi(d, i_nhomkho, s_makho, 0);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem43_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmCosotutruc")) return;
            frmChon1khoa f = new frmChon1khoa(d, i_nhomkho, s_makp, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmCosotutruc f1 = new frmCosotutruc(d, f.mmyy, f.i_makp, i_nhomkho, f.tenkp,i_userid );
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem93_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmKbtonvayct")) return;
            frmChonvay f = new frmChonvay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.i_makho != -1)
            {
                frmKbtonvayct f1 = new frmKbtonvayct(d, f.i_makp, i_nhomkho, f.i_makho, f.tenkho, b_giaban, s_mmyy,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem71_Click_2(object sender, System.EventArgs e)
        {
            rptBbkiemke f = new rptBbkiemke(d, i_nhomkho, s_makho, s_mmyy, true, false,"d_tonkhoct",i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem94_Click_1(object sender, System.EventArgs e)
        {
            rptSolankham f = new rptSolankham(d, i_nhomkho, s_makho, 1, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem98_Click_1(object sender, System.EventArgs e)
        {
            frmDenghict f = new frmDenghict(d, i_nhomkho, "", "", "",i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem99_Click_1(object sender, System.EventArgs e)
        {
            rptNhap_th f = new rptNhap_th(d, i_nhomkho, s_makho, 1, "Bảng nhập thuốc vật tư y tế tổng hợp", "d_nhapxuat_th.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem100_Click(object sender, System.EventArgs e)
        {
            rptNhap_th f = new rptNhap_th(d, i_nhomkho, s_makho, 2, "Bảng xuất thuốc vật tư y tế tổng hợp", "d_nhapxuat_th.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem125_Click_1(object sender, System.EventArgs e)
        {
            frmDSBacsi f = new frmDSBacsi(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem161_Click(object sender, System.EventArgs e)
        {
            rptSolankham f = new rptSolankham(d, i_nhomkho, s_makho, 0, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem141_Click(object sender, System.EventArgs e)
        {
            rptBhyt f = new rptBhyt(d, i_nhomkho, s_makho, 0,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem131_Click_1(object sender, System.EventArgs e)
        {
            rptBbkiemke f = new rptBbkiemke(d, i_nhomkho, s_makho, s_mmyy, true, true,"d_tonkhoct",i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem162_Click_1(object sender, System.EventArgs e)
        {
            rptTkmabd f = new rptTkmabd(d, i_nhomkho, s_makho, s_mmyy, "d_tkmabd.rpt", "Thống kê xuất chi tiết theo mặt hàng", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem163_Click_1(object sender, System.EventArgs e)
        {
            rptNxt_CK_ngay f = new rptNxt_CK_ngay(d, i_nhomkho, s_makho, s_mmyy, "d_bcnxt_ck_gban.rpt", true,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem164_Click_1(object sender, System.EventArgs e)
        {
            rptNxt_bh f = new rptNxt_bh(d, i_nhomkho, s_makho, s_mmyy, "d_bcnxt_bh.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem180_Click_1(object sender, System.EventArgs e)
        {
            rptLaigop f = new rptLaigop(d, i_nhomkho, s_makho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem190_Click(object sender, System.EventArgs e)
        {
            frmThuoc_bacsy f = new frmThuoc_bacsy(d, i_nhomkho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem192_Click(object sender, System.EventArgs e)
        {
            rptNxt_nhombc f = new rptNxt_nhombc(d, i_nhomkho, s_makho, s_mmyy, 1, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem193_Click(object sender, System.EventArgs e)
        {
            frmDmbs f = new frmDmbs(s_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem194_Click(object sender, System.EventArgs e)
        {
            frmDmduongdung f = new frmDmduongdung(d, "d_dmcachdung", "Danh mục cách dùng");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem195_Click(object sender, System.EventArgs e)
        {
            frmDmduongdung f = new frmDmduongdung(d, "d_dmduongdung", "Danh mục đường dùng");
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem196_Click(object sender, System.EventArgs e)
        {
            frmDonthuoc f = new frmDonthuoc(d, i_nhomkho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem197_Click(object sender, System.EventArgs e)
        {
            rptNxt_nhombc f = new rptNxt_nhombc(d, i_nhomkho, s_makho, s_mmyy, 2, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem198_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNhap_soluong")) return;
            frmNhap_soluong f = new frmNhap_soluong(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_admin, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem200_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmNhap_sotien")) return;
            frmNhap_sotien f = new frmNhap_sotien(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, b_admin,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem201_Click(object sender, System.EventArgs e)
        {
            rptBanhang f = new rptBanhang(d, i_nhomkho, s_makho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem202_Click(object sender, System.EventArgs e)
        {
            frmNxt_ngay f = new frmNxt_ngay(d, i_nhomkho, s_mmyy, s_makho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem203_Click(object sender, System.EventArgs e)
        {
            frmThkhoa f = new frmThkhoa(d, i_nhomkho, s_makho, s_makp,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem204_Click(object sender, System.EventArgs e)
        {
            frmThdutru f = new frmThdutru(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem205_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmImplants")) return;
            frmImplants f = new frmImplants(d, "XK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất Implants", b_giaban, b_admin, s_loaikhac,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem206_Click(object sender, System.EventArgs e)
        {
            rptNhap_th f = new rptNhap_th(d, i_nhomkho, s_makho, 2, "In phiếu xuất kho", "d_phieuxuat.rpt", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem207_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDutrukho")) return;
            frmChonnguon f = new frmChonnguon(d, i_nhomkho,s_makho);
            f.ShowDialog();
            if (f.tennguon != "~")
            {
                frmDutruthang f1 = new frmDutruthang(d, i_nhomkho, s_mmyy, s_manhom, f.i_manguon, f.tennguon, f.iLanthu,f.s_makho,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem208_Click(object sender, System.EventArgs e)
        {
            rptBbknhap_hd f = new rptBbknhap_hd(d, i_nhomkho, s_makho, "d_Bbknhap_hd.rpt", "", "", "", "", 0, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem209_Click(object sender, System.EventArgs e)
        {
            frmThkhoa_bhyt f = new frmThkhoa_bhyt(d, i_nhomkho, s_makho, 1, 5,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem211_Click(object sender, System.EventArgs e)
        {
            frmThkhoa_bhyt f = new frmThkhoa_bhyt(d, i_nhomkho, s_makho, 0, 6,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem212_Click(object sender, System.EventArgs e)
        {
            frmPhieuxuat_bhyt f = new frmPhieuxuat_bhyt(d, i_nhomkho, s_makho, 0, 6,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem210_Click(object sender, System.EventArgs e)
        {
            frmPhieuxuat_bhyt f = new frmPhieuxuat_bhyt(d, i_nhomkho, s_makho, 1, 5,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem213_Click(object sender, System.EventArgs e)
        {
            frmThkhoa_ng f = new frmThkhoa_ng(d, i_nhomkho, s_makho, s_makp, s_loaint,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem215_Click(object sender, System.EventArgs e)
        {
            frmPhieuxuat_ng f = new frmPhieuxuat_ng(d, i_nhomkho, s_makho, s_makp, s_loaint,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem214_Click(object sender, System.EventArgs e)
        {
            frmNxt_kho f = new frmNxt_kho(d, i_nhomkho, s_mmyy, s_makho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem216_Click(object sender, System.EventArgs e)
        {
            rptBCTienthuoc f = new rptBCTienthuoc(d, i_nhomkho,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem217_Click(object sender, System.EventArgs e)
        {
            rptThekhocstt f = new rptThekhocstt(d, i_nhomkho, s_makho, s_mmyy, (d.bThekho_congdon(i_nhomkho)) ? "d_thekhocstt_ngay.rpt" : "d_thekhocstt.rpt", "Thẻ kho", s_makp,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem219_Click(object sender, System.EventArgs e)
        {
            frmThkhac f = new frmThkhac(d, i_nhomkho, s_makho, s_loaikhac,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem220_Click(object sender, System.EventArgs e)
        {
            frmPhieuxuat_kh f = new frmPhieuxuat_kh(d, i_nhomkho, s_makho, s_loaikhac,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem221_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("rptChiphidon")) return;
            rptChiphidon f = new rptChiphidon(d, i_nhomkho, s_makho, 1);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem222_Click(object sender, System.EventArgs e)
        {
            frmBaocaocstt f = new frmBaocaocstt(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem223_Click(object sender, System.EventArgs e)
        {
            frmSDnoitru f = new frmSDnoitru(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem224_Click(object sender, System.EventArgs e)
        {
            frmTSDnoitru f = new frmTSDnoitru(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem225_Click(object sender, System.EventArgs e)
        {
            menuItem14_Click(sender, e);
            frmCauhinh f = new frmCauhinh(d, s_mmyy, i_nhomkho, i_userid, b_giaban, b_admin);
            f.ShowDialog();
        }

        private void menuItem113_Click_1(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmDSdutru_duyet")) return;
            frmDSdutru_duyet f = new frmDSdutru_duyet(d, s_makp, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }


        private void menuItem159_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmTruyvan")) return;
            frmTruyvan f = new frmTruyvan(d, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem114_Click_1(object sender, System.EventArgs e)
        {
            frmMmyy f = new frmMmyy(d, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmXemtonthck f1 = new frmXemtonthck(d, f.mmyy, i_nhomkho);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void menuItem160_Click_1(object sender, System.EventArgs e)
        {
            rptNXTChitiet_ck f = new rptNXTChitiet_ck(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem169_Click(object sender, System.EventArgs e)
        {
            frmTtkcbngtr f = new frmTtkcbngtr(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem226_Click(object sender, System.EventArgs e)
        {
            frmthkcbngtr f = new frmthkcbngtr(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem227_Click(object sender, System.EventArgs e)
        {
            rptBkhoadon f = new rptBkhoadon(d, i_nhomkho, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem228_Click(object sender, System.EventArgs e)
        {
            if (IsLoaded("frmSuaNhap")) return;
            frmSuaNhap f = new frmSuaNhap(d, "", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, b_admin);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem229_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmBaohiem")) return;
            frmBaohiem f = new frmBaohiem(d, 8, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất điều trị ngoại trú", b_admin, 0, 2, s_userid, i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem230_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPhat_ngoaitru")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 0, 2, i_userid, s_makho,b_thuhoi);
                f.Name = "frmPhat_ngoaitru";
                f.PhatCaNgoaitru = false;
                f.PhatKhongNgoaiTru = true;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem231_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 8, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí điều trị ngoại trú", b_admin, 0, 2, s_userid,b_thuhoi,false, i_khudt,false);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem47_Click(object sender, EventArgs e)
        {
            rptNhap_mm f = new rptNhap_mm(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem48_Click(object sender, EventArgs e)
        {
            rptXuat_mm f = new rptXuat_mm(d, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem49_Click(object sender, EventArgs e)
        {
            rptXuat_khoa f = new rptXuat_khoa(d, i_nhomkho, s_mmyy, s_makho, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem50_Click(object sender, EventArgs e)
        {
            rptNXT_tv f = new rptNXT_tv(d, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem52_Click(object sender, EventArgs e)
        {
            rptBbkiemkec53 f = new rptBbkiemkec53(d, i_nhomkho, s_makho, s_mmyy, s_makp, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem84_Click(object sender, EventArgs e)
        {
            rptSoTSCD f = new rptSoTSCD(d, i_nhomkho, s_makho, s_mmyy, s_makp, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem55_Click(object sender, EventArgs e)
        {
            frmTheodoigia f = new frmTheodoigia(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem56_Click_1(object sender, EventArgs e)
        {
            frmPhieuxuat_ng f = new frmPhieuxuat_ng(d, i_nhomkho, s_makho, s_makp, s_loaint,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem233_Click(object sender, EventArgs e)
        {
            frmThkhoa_bhyt f = new frmThkhoa_bhyt(d, i_nhomkho, s_makho, 0, 8,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem234_Click(object sender, EventArgs e)
        {
            frmPhieuxuat_bhyt f = new frmPhieuxuat_bhyt(d, i_nhomkho, s_makho, 0, 8,i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem137_Click(object sender, EventArgs e)
        {
            frmTaouser f = new frmTaouser(i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem157_Click(object sender, EventArgs e)
        {
            frmEvent f = new frmEvent();
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem165_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXhtncc")) return;
            frmXhtncc f = new frmXhtncc(d, "XK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất hoàn trả nhà cung cấp", b_giaban, b_admin, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem177_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPhatkho")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                frmPhatkho f = new frmPhatkho(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, s_makho);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void m188_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmDutrukho")) return;
            frmChonkhong f = new frmChonkhong(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmDutrukho f1 = new frmDutrukho(d, f.i_makho, f.mmyy, f.tenkho, i_nhomkho, s_manhom, f.i_manguon, f.tennguon, f.i_lanthu, f.i_manhom,f.i_loaiphieu,f.tu.Value.ToString(),f.den.Value.ToString(),f.mm.Value.ToString(),int.Parse(f.cmbQui.Text),i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m189_Click(object sender, EventArgs e)
        {
            frmTontreo f = new frmTontreo(d, i_nhomkho, s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void m190_Click(object sender, EventArgs e)
        {
            d.execute_data("delete from " + d.user + ".d_dangduyet");
            MessageBox.Show(lan.Change_language_MessageText("Đã hủy !"), d.Msg);
        }

        private void m191_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmNhap")) return;
            frmNhap f = new frmNhap(d, "K", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu khoa hoàn trả", b_giaban, b_admin, s_manhom,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void m192_Click(object sender, EventArgs e)
        {
            frmDonthuoc_bacsy f = new frmDonthuoc_bacsy(d, i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void m193_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmDutrukho")) return;
            frmChonkhong f = new frmChonkhong(d, i_nhomkho, s_makho, "20" + s_mmyy.Substring(2));
            f.ShowDialog();
            if (f.mmyy != "")
            {
                //frmDutrukho f1 = new frmDutrukho(d, f.i_makho, "20" + f.mmyy.Substring(2), f.tenkho, i_nhomkho, s_manhom, f.i_manguon, f.tennguon, f.i_lanthu, f.i_manhom);
                frmDutrukho f1 = new frmDutrukho(d, f.i_makho, "20" + f.mmyy.Substring(2), f.tenkho, i_nhomkho, s_manhom, f.i_manguon, 
                    f.tennguon, f.i_lanthu, f.i_manhom,f.i_loaiphieu,f.tu.Text,f.den.Text,f.mm.Value.ToString(),f.cmbQui.SelectedIndex,i_userid);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m194_Click(object sender, EventArgs e)
        {
            frmChonkho f = new frmChonkho(d, i_nhomkho, s_makho, s_mmyy);
            f.ShowDialog();
            if (f.mmyy != "")
            {
                frmBbkk f1 = new frmBbkk(d, f.i_makho, f.mmyy, f.tenkho, i_nhomkho, i_userid, s_ngay);
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void m195_Click(object sender, EventArgs e)
        {
            frmPhieulinh_ng f = new frmPhieulinh_ng(d, i_nhomkho, s_makho, s_makp, s_loaint, s_userid, s_mmyy, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void m196_Click(object sender, EventArgs e)
        {
            frmDmbdgiabh f = new frmDmbdgiabh(d, i_nhomkho, s_mmyy, i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void mnuRight_Bv_Click(object sender, EventArgs e)
        {
            frmRight_BV f = new frmRight_BV(d, f_get_menu(),i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void m197_Click(object sender, EventArgs e)
        {
            frmKhonghi f = new frmKhonghi(d, i_nhomkho, i_userid,s_mmyy);
            f.MdiParent = this;
            f.Show();
        }

        private void m198_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXemnhap")) return;
            frmXemnhap f = new frmXemnhap(d, "M", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho", b_giaban, true, s_manhom);//b_admin
            f.MdiParent = this;
            f.Show();            
        }

        private void m199_Click(object sender, EventArgs e)
        {
            /*if (IsLoaded("frmXphieulanh")) return;
            frmXphieulanh f = new frmXphieulanh(d, (i_loaikho == 2) ? 4 : 1, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu lĩnh theo khoa/phòng", b_giaban, i_loaikho, true);
            f.MdiParent = this;
            f.Show();*/
            if (IsLoaded("frmPhieulanh")) return;
            frmPhieulanh f = new frmPhieulanh(d, (i_loaikho == 2) ? 4 : 1, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu lĩnh theo khoa/phòng", b_giaban, i_loaikho, b_admin,true);
            f.MdiParent = this;
            f.Show();
        }

        private void m200_Click(object sender, EventArgs e)
        {
            rptBbkiemke f = new rptBbkiemke(d, i_nhomkho, s_makho, s_mmyy, false, false, "d_tutrucct", i_userid);
            f.MdiParent = this;
            f.Show();
        }

        private void m201_Click(object sender, EventArgs e)
        {
            frmTrungthau f = new frmTrungthau(d, s_ngay, i_nhomkho, i_userid, b_admin);
            f.MdiParent = this;
            f.Show();
        }

        private void m202_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXchuyenkho")) return;
            frmXchuyenkho f = new frmXchuyenkho(d, "CK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất chuyển kho", b_giaban, b_admin, false, s_userid, true,i_khudt);
            f.MdiParent = this;
            f.Show();
        }

        private void m203_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí bảo hiểm", b_admin, 1, 3, s_userid, b_thuhoi, true,i_khudt,false);
            f.MdiParent = this;
            f.Show();
        }

        private void m204_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 6, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí ngoại trú", b_admin, 0, 3, s_userid, b_thuhoi,true, i_khudt ,false);
            f.MdiParent = this;
            f.Show();
        }

        private void m205_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 8, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí điều trị ngoại trú", b_admin, 0, 2, s_userid, b_thuhoi, true, i_khudt ,false);
            f.MdiParent = this;
            f.Show();
        }

        private void m206_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPhieuhoantra")) return;
            frmPhieuhoantra f = new frmPhieuhoantra(d, 3, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makp, "Phiếu hoàn trả theo khoa/phòng", b_giaban, i_loaikho, b_admin,true,s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void m207_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXkhac")) return;
            frmXkhac f = new frmXkhac(d, "XK", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất khác", b_giaban, b_admin, s_loaikhac, s_userid,true);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {
            frmdmbd_kgnhapmoi f = new frmdmbd_kgnhapmoi(d,i_nhomkho);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem32_Click(object sender, EventArgs e)
        {
            rptNxt_CK_ngay f = new rptNxt_CK_ngay(d, i_nhomkho, s_makho, s_mmyy, "d_bcnxt_ck_ngay.rpt", false, i_userid );
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem35_Click(object sender, EventArgs e)
        {
            //frmChuyenDuocbenhvien f = new frmChuyenDuocbenhvien();
            //f.MdiParent = this;
            //f.Show();
        }

        private void menuItem35_Click_1(object sender, EventArgs e)
        {
            frmdsdathuhoi f = new frmdsdathuhoi(d,s_makp, i_nhomkho, s_mmyy, s_makho);
            f.MdiParent = this;
            f.Show();
        }

        private void f_get_khudieutri()
        {
            s_khudt = d.f_get_khudt(i_userid);
            string sql = " select * from " + d.user + ".dmkhudt ";
            if (s_khudt.Trim().Trim(',') != "") sql += " where id in(" + s_khudt.Trim().Trim(',') + ")";
            DataSet lds = d.get_data(sql);
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

        private void f_capnhap_length_id()
        {
            DataSet lds = new DataSet();
            string user = d.user, asql = "";
            string s_gio_modify = "30/04/2011 08:00";
            LibMedi.AccessData m = new LibMedi.AccessData();

            asql = "select ngaygio from " + user + s_mmyy + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " drop table " + user + s_mmyy + ".datao ";
                m.execute_data(asql);
                asql = " create table " + user + s_mmyy + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);

                asql = "insert into " + user + s_mmyy + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
                m.execute_data(asql);

                m.f_tangid_medibv_mmyy(s_mmyy);
            }
            asql = "select ngaygio from " + user + ".datao where to_char(ngaygio,'dd/mm/yyyy hh24:mi')='" + s_gio_modify + "'";
            lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = " drop table " + user + ".datao ";
                m.execute_data(asql);
                asql = " create table " + user + ".datao (ngaygio timestamp, constraint pk_datao primary key (ngaygio) USING INDEX TABLESPACE medi_index)  WITH OIDS ";
                m.execute_data(asql);
            }
            else if (lds.Tables[0].Rows.Count > 0) return;
            asql = "insert into " + user + ".datao (ngaygio) values (to_date('" + s_gio_modify + "','dd/mm/yyyy hh24:mi'))";
            m.execute_data(asql);
            //goi ham tang chieu dai id
            m.f_tangid_medibv();
        }

        private void menuItem53_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmDutrungay")) return;
            //frmChondutrungay f = new frmChondutrungay(d, i_nhomkho, s_makho);
            frmChonkhodt f = new frmChonkhodt(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.tennguon != "~")
            {
                //frmDutrungay f1 = new frmDutrungay(d ,i_nhomkho, f.MMYY, s_manhom, f.i_manguon, f.tennguon, f.iLanthu, f.s_makho,f.m_ngay,0,i_userid);
                frmDutruThuocKho ff = new frmDutruThuocKho(d, f.m_ngay.ToString("dd/MM/yyyy"), f.s_makho, f.s_tenkho, f.i_manguon, i_nhomkho, f.s_mmyy, f.m_ngay, i_userid, i_chinhanh);
                ff.MdiParent = this;
                ff.Show();
                ff.WindowState = FormWindowState.Maximized;
            }
        }

        private void menuItem88_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmDutrungay")) return;
            //frmChondutrungay f = new frmChondutrungay(d, i_nhomkho, s_makho);
            //f.ShowDialog();
            //if (f.tennguon != "~")
            //{
            //    frmDutrungay f1 = new frmDutrungay(d, i_nhomkho, f.MMYY, s_manhom, f.i_manguon, f.tennguon, f.iLanthu, f.s_makho, f.m_ngay, 1, i_userid);
            //    f1.MdiParent = this;
            //    f1.Show();
            //    f.WindowState = FormWindowState.Maximized;
            //}
            //
            if (IsLoaded("frmDuyetdutrukho")) return;
            frmDuyetdutrukho f = new frmDuyetdutrukho(d, i_userid, s_ngay,i_chinhanh);
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuItem101_Click(object sender, EventArgs e)
        {
            //if (IsLoaded("frmDutrungay")) return;
            frmChondutrungay f = new frmChondutrungay(d, i_nhomkho, s_makho);
            f.ShowDialog();
            if (f.tennguon != "~")
            {
                frmDutrungay f1 = new frmDutrungay(d, i_nhomkho, f.MMYY, s_manhom, f.i_manguon, f.tennguon, f.iLanthu, f.s_makho, f.m_ngay, 2, i_userid);
                f1.MdiParent = this;
                f1.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }

        private void menuItem103_Click(object sender, EventArgs e)
        {
            frmDmthuocBYT f1 = new frmDmthuocBYT();
            f1.MdiParent = this;
            f1.Show();
        }

        private void menuItem111_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmXLuanchuyenCN")) return;
            frmXLuanchuyenCN f = new frmXLuanchuyenCN(d, "XC", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu xuất luân chuyển cho chi nhánh.", b_giaban, b_admin, s_loaikhac, s_userid, false, i_chinhanh, false);
            f.MdiParent = this;
            f.Show();
        }
        private void menuItem191_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmNhanthuoctutrungtam")) return;
            frmNhanthuoctutrungtam f = new frmNhanthuoctutrungtam(d, "NC", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho từ trung tâm chuyển cho chi nhánh.", b_admin, s_manhom, i_khudt, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem224_Click_1(object sender, EventArgs e)
        {
            if (IsLoaded("frmTonghopdutru")) return;
            frmTonghopdutru f1 = new frmTonghopdutru(i_chinhanh, i_userid);
            f1.MdiParent = this;
            f1.Show();
            f1.WindowState = FormWindowState.Maximized;
        }

        private void menuItem235_Click(object sender, EventArgs e)
        {
            frmLapkehoachmua f1 = new frmLapkehoachmua(i_chinhanh, i_userid, true, "Lập kế hoạch mua hàng gợi ý");
            f1.MdiParent = this;
            f1.Show();
            f1.WindowState = FormWindowState.Maximized;
        }

        private void menuItem236_Click(object sender, EventArgs e)
        {
            frmLapkehoachmua f1 = new frmLapkehoachmua(i_chinhanh, i_userid, false, "Lập kế hoạch mua hàng thực tế");
            f1.MdiParent = this;
            f1.Show();
            f1.WindowState = FormWindowState.Maximized;
        }

        private void menuItem237_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmChuyencstt")) return;
            frmChuyencstt f = new frmChuyencstt(d, "TT", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, s_makp, "Phiếu xuất chuyển cơ số tủ trực", b_giaban);
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void mnuPhatthuoc_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPhatthuoc_all")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 1, 3, i_userid, s_makho, b_thuhoi);
                f.Name = "frmPhatthuoc_all";
                f.PhatCaNgoaitru = true;
                f.PhatKhongNgoaiTru = false;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem87_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmDuyetdutrucstt")) return;
            frmDuyetdutrucstt f = new frmDuyetdutrucstt(d, s_ngay, s_makho, s_makp, i_userid, i_nhomkho.ToString());
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void m208_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 5, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí bảo hiểm", b_admin, 1, 3, s_userid, b_thuhoi, false, i_khudt,true);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem101_Click_1(object sender, EventArgs e)
        {
            if (IsLoaded("frmHuydanglaysolieu")) return;
            frmHuydanglaysolieu f = new frmHuydanglaysolieu(b_admin);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem128_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmNhanthuoctutrungtam")) return;
            frmNhanthuoctutrungtam f = new frmNhanthuoctutrungtam(d, "NC", s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Phiếu nhập kho từ trung tâm chuyển cho chi nhánh.", b_admin, s_manhom, i_khudt, i_chinhanh);
            f.MdiParent = this;
            f.Show();
        }

        private void menuItem168_Click(object sender, EventArgs e)
        {

        }

        private void menuItem239_Click(object sender, EventArgs e)
        {
            
        }

        private void menuItem238_Click(object sender, EventArgs e)
        {
            if (IsLoaded("frmPhat_khongBHYT")) return;
            frmChonngay f1 = new frmChonngay(d, s_ngay);
            f1.ShowDialog(this);
            if (f1.s_tu != "" && f1.s_den != "")
            {
                frmPhatbhyt_mavach f = new frmPhatbhyt_mavach(d, i_nhomkho, f1.s_tu, f1.s_den, s_mmyy, 0, 3, i_userid, s_makho, b_thuhoi);
                f.Name = "frmPhat_khongBHYT";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void menuItem239_Click_1(object sender, EventArgs e)
        {
            if (IsLoaded("frmHoadonbhyt")) return;
            frmHoadonbhyt f = new frmHoadonbhyt(d, 9, s_mmyy, s_ngay, i_nhomkho, i_userid, s_makho, "Viện phí ngoại trú", b_admin, 0, 3, s_userid, b_thuhoi, false, i_khudt, false);
            f.MdiParent = this;
            f.Show();
        }

        private bool bNhieuchinhanh()
        {
            bool bln = false;
            string asql = "select * from medibv.dmchinhanh where id>0";
            DataSet lds = d.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                bln = false;
            }
            else
            {
                bln = lds.Tables[0].Rows.Count > 0;
            }

            return bln;
        }

        private void menuItem136_Click(object sender, EventArgs e)
        {

        }

        private void menuItem238_Click_1(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void menuItem81_Click(object sender, EventArgs e)
        {

        }

        private void menuItem240_Click(object sender, EventArgs e)
        {

        }
	}
}
