using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;
namespace Duoc
{
	/// <summary>
	/// Summary description for frmThongso.
	/// </summary>
	public class frmCauhinh : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.CheckBox c02;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox c07;
		private MaskedTextBox.MaskedTextBox c08;
		private MaskedTextBox.MaskedTextBox c09;
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet dstt=new DataSet();
		private DataSet dsmua=new DataSet();
        private DataSet dstyle = new DataSet();
        private DataSet dstylevattu = new DataSet();
        private DataTable dtnin = new DataTable();
        private DataTable dtkho = new DataTable();
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.CheckBox c04;
		private System.Windows.Forms.CheckBox c05;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown c10;
		private System.Windows.Forms.CheckBox c11;
		private System.Windows.Forms.CheckBox c12;
		private System.Windows.Forms.CheckBox c13;
		private string s_mmyy,user,s_161,s_173;
		private int i_nhom,i_userid,i_c128,i_c135;
		private System.Windows.Forms.CheckBox c14;
		private MaskedTextBox.MaskedTextBox c15;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox c16;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox c20;
		private System.Windows.Forms.CheckBox c19;
		private System.Windows.Forms.CheckBox c17;
		private System.Windows.Forms.CheckBox c18;
		private System.Windows.Forms.CheckBox c21;
		private System.Windows.Forms.NumericUpDown c22;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox c23;
		private System.Windows.Forms.CheckBox c24;
		private System.Windows.Forms.CheckBox c25;
		private System.Windows.Forms.Label label8;
		private MaskedTextBox.MaskedTextBox ma13;
		private MaskedTextBox.MaskedTextBox ma16;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox c26;
		private System.Windows.Forms.CheckBox c27;
		private System.Windows.Forms.CheckBox c28;
		private System.Windows.Forms.CheckBox c29;
		private System.Windows.Forms.CheckBox c30;
		private System.Windows.Forms.CheckBox c31;
		private MaskedTextBox.MaskedTextBox c32;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button butHinh;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private MaskedTextBox.MaskedTextBox kho;
		private MaskedTextBox.MaskedTextBox hinh;
		private System.Windows.Forms.CheckBox c33;
		private System.Windows.Forms.CheckBox c34;
		private System.Windows.Forms.CheckBox c36;
		private System.Windows.Forms.CheckBox c35;
		private System.Windows.Forms.CheckBox c37;
		private System.Windows.Forms.CheckBox c38;
		private System.Windows.Forms.CheckBox c39;
		private System.Windows.Forms.CheckBox c40;
		private System.Windows.Forms.CheckBox c41;
		private System.Windows.Forms.CheckBox c42;
		private System.Windows.Forms.CheckBox c43;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.NumericUpDown c44;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox c45;
		private System.Windows.Forms.CheckBox c46;
		private System.Windows.Forms.Label label19;
		private MaskedTextBox.MaskedTextBox c48;
		private MaskedTextBox.MaskedTextBox c49;
		private MaskedTextBox.MaskedTextBox c50;
		private MaskedTextBox.MaskedTextBox c51;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private MaskedTextBox.MaskedTextBox c52;
		private MaskedTextBox.MaskedTextBox c53;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox c55;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.NumericUpDown c57;
		private System.Windows.Forms.NumericUpDown c58;
		private System.Windows.Forms.NumericUpDown c59;
		private System.Windows.Forms.CheckBox c60;
		private System.Windows.Forms.CheckBox c61;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.CheckBox c63;
		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label18;
		private MaskedTextBox.MaskedTextBox c47;
		private System.Windows.Forms.Label label24;
		private MaskedTextBox.MaskedTextBox c56;
		private System.Windows.Forms.CheckBox c62;
		private System.Windows.Forms.CheckBox c54;
		private System.Windows.Forms.CheckBox c64;
		private System.Windows.Forms.CheckBox c65;
		private System.Windows.Forms.CheckBox c66;
		private System.Windows.Forms.CheckBox c67;
		private System.Windows.Forms.CheckBox c68;
		private System.Windows.Forms.CheckBox c69;
		private System.Windows.Forms.CheckBox c70;
		private System.Windows.Forms.CheckBox c71;
		private System.Windows.Forms.CheckBox c72;
		private System.Windows.Forms.CheckBox c73;
		private System.Windows.Forms.CheckBox c74;
		private System.Windows.Forms.CheckBox c75;
		private System.Windows.Forms.CheckBox c76;
		private System.Windows.Forms.CheckBox c77;
		private System.Windows.Forms.CheckBox c78;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.NumericUpDown c79;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.CheckBox c80;
		private System.Windows.Forms.CheckBox c81;
		private System.Windows.Forms.CheckBox c82;
		private System.Windows.Forms.Label label33;
		private MaskedTextBox.MaskedTextBox c83;
		private MaskedTextBox.MaskedTextBox c84;
		private System.Windows.Forms.CheckBox c85;
		private System.Windows.Forms.CheckBox c86;
		private System.Windows.Forms.CheckBox c87;
		private System.Windows.Forms.CheckBox c88;
		private System.Windows.Forms.CheckBox c89;
		private System.Windows.Forms.CheckBox c90;
		private System.Windows.Forms.CheckBox c91;
		private System.Windows.Forms.CheckBox c92;
		private System.Windows.Forms.CheckBox c93;
		private System.Windows.Forms.CheckBox c94;
		private System.Windows.Forms.CheckBox c95;
		private System.Windows.Forms.CheckBox c96;
		private System.Windows.Forms.CheckBox c97;
		private System.Windows.Forms.CheckBox c98;
		private System.Windows.Forms.NumericUpDown c99;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.CheckBox c100;
		private System.Windows.Forms.CheckBox c101;
		private System.Windows.Forms.CheckBox c102;
		private System.Windows.Forms.CheckBox c103;
		private System.Windows.Forms.CheckBox c104;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.NumericUpDown c105;
		private System.Windows.Forms.CheckBox c106;
		private System.Windows.Forms.CheckBox c107;
		private System.Windows.Forms.CheckBox c108;
		private System.Windows.Forms.NumericUpDown c109;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.CheckBox c110;
		private System.Windows.Forms.CheckBox c111;
		private System.Windows.Forms.Label label40;
		private MaskedTextBox.MaskedTextBox c112;
		private System.Windows.Forms.CheckBox c113;
		private System.Windows.Forms.CheckBox c114;
		private System.Windows.Forms.CheckBox c115;
		private System.Windows.Forms.CheckBox c116;
		private System.Windows.Forms.CheckBox c117;
		private System.Windows.Forms.CheckBox c119;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label41;
		private MaskedTextBox.MaskedTextBox c120;
		private MaskedTextBox.MaskedTextBox c121;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.CheckBox c122;
		private System.Windows.Forms.CheckBox c123;
		private System.Windows.Forms.CheckBox c124;
		private System.Windows.Forms.CheckBox c125;
		private System.Windows.Forms.CheckBox c126;
		private System.Windows.Forms.ComboBox c127;
		private System.Windows.Forms.ComboBox c128;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
        private ComboBox c134;
        private ComboBox c133;
        private ComboBox c132;
        private TabPage tabPage4;
        private CheckBox c131;
        private CheckBox c130;
        private CheckBox c129;
        private ComboBox c135;
        private Label label46;
        private CheckBox c136;
        private CheckBox c137;
        private CheckBox c138;
        private CheckBox c139;
        private CheckBox c140;
        private NumericUpDown c141;
        private Label label50;
        private CheckBox c142;
        private CheckBox c143;
        private CheckBox c144;
        private CheckBox c145;
        private CheckBox c146;
        private CheckBox c147;
        private CheckBox c148;
        private CheckBox c149;
        private TextBox c150;
        private Label label47;
        private NumericUpDown c151;
        private Label label48;
        private CheckBox c152;
        private CheckBox c153;
        private CheckBox c154;
        private CheckBox c155;
        private CheckBox c156;
        private CheckBox c157;
        private CheckBox c158;
        private CheckBox c160;
        private CheckBox c159;
        private CheckedListBox c161;
        private Label label49;
        private NumericUpDown c162;
        private Label label51;
        private CheckBox c163;
        private NumericUpDown c164;
        private Label label52;
        private CheckBox c165;
        private DataGrid dataGrid3;
        private CheckBox c166;
        private CheckBox c167;
        private PictureBox p167;
        private Button b167;
        private Label label53;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private CheckBox c168;
        private CheckBox c169;
        private CheckBox c170;
        private CheckBox c171;
        private CheckedListBox c173;
        private CheckBox c172;
        private CheckBox c174;
        private MaskedTextBox.MaskedTextBox c175;
        private Label label54;
        private CheckBox c176;
        private Label label55;
        private Label label56;
        private NumericUpDown c177;
        private CheckBox c178;
        private CheckBox c1001;
        private CheckBox c1002;
        private CheckBox c1003;
        private CheckBox c1004;
        private CheckBox c1005;
        private CheckBox c1006;
        private CheckBox c1008;
        private CheckBox c1007;
        private TabPage tabPage5;
        private CheckBox c1009;
        private CheckBox c1010;
        private CheckBox c1011;
        private CheckBox c601;
        private CheckBox c602;
        private CheckBox c1012;
        private CheckBox c1014;
        private CheckBox c1015;
        private CheckBox c1016;
        private CheckBox c2000;
        private ToolTip toolTip1;
        private Label label58;
        private MaskedTextBox.MaskedTextBox c217;
        private MaskedTextBox.MaskedTextBox c216;
        private Label label57;
        private CheckBox c179;
        private CheckBox c1031;
        private CheckBox c1032;
        private CheckBox c1017;
        private DataGrid dataGrid4;
        private CheckBox c603;
        private CheckBox c5011;
        private IContainer components;

		public frmCauhinh(LibDuoc.AccessData acc,string mmyy,int nhom,int userid,bool giaban,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			s_mmyy=mmyy;
			i_nhom=nhom;
			i_userid=userid;
			c14.Enabled=giaban || d.bGiaban_nguon(i_nhom);
			c13.Text="Khoá số liệu tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
			c13.Enabled=admin;
            
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauhinh));
            this.c02 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c07 = new MaskedTextBox.MaskedTextBox();
            this.c08 = new MaskedTextBox.MaskedTextBox();
            this.c09 = new MaskedTextBox.MaskedTextBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.c04 = new System.Windows.Forms.CheckBox();
            this.c05 = new System.Windows.Forms.CheckBox();
            this.c10 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.c11 = new System.Windows.Forms.CheckBox();
            this.c12 = new System.Windows.Forms.CheckBox();
            this.c13 = new System.Windows.Forms.CheckBox();
            this.c14 = new System.Windows.Forms.CheckBox();
            this.c15 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c16 = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c20 = new System.Windows.Forms.CheckBox();
            this.c19 = new System.Windows.Forms.CheckBox();
            this.c17 = new System.Windows.Forms.CheckBox();
            this.c18 = new System.Windows.Forms.CheckBox();
            this.c21 = new System.Windows.Forms.CheckBox();
            this.c22 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c23 = new System.Windows.Forms.CheckBox();
            this.c24 = new System.Windows.Forms.CheckBox();
            this.c25 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ma13 = new MaskedTextBox.MaskedTextBox();
            this.ma16 = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.c26 = new System.Windows.Forms.CheckBox();
            this.c27 = new System.Windows.Forms.CheckBox();
            this.c28 = new System.Windows.Forms.CheckBox();
            this.c29 = new System.Windows.Forms.CheckBox();
            this.c30 = new System.Windows.Forms.CheckBox();
            this.c31 = new System.Windows.Forms.CheckBox();
            this.c32 = new MaskedTextBox.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.butHinh = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.kho = new MaskedTextBox.MaskedTextBox();
            this.hinh = new MaskedTextBox.MaskedTextBox();
            this.c33 = new System.Windows.Forms.CheckBox();
            this.c34 = new System.Windows.Forms.CheckBox();
            this.c36 = new System.Windows.Forms.CheckBox();
            this.c35 = new System.Windows.Forms.CheckBox();
            this.c37 = new System.Windows.Forms.CheckBox();
            this.c38 = new System.Windows.Forms.CheckBox();
            this.c39 = new System.Windows.Forms.CheckBox();
            this.c40 = new System.Windows.Forms.CheckBox();
            this.c41 = new System.Windows.Forms.CheckBox();
            this.c42 = new System.Windows.Forms.CheckBox();
            this.c43 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.c44 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.c45 = new System.Windows.Forms.CheckBox();
            this.c46 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.c48 = new MaskedTextBox.MaskedTextBox();
            this.c49 = new MaskedTextBox.MaskedTextBox();
            this.c50 = new MaskedTextBox.MaskedTextBox();
            this.c51 = new MaskedTextBox.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.c52 = new MaskedTextBox.MaskedTextBox();
            this.c53 = new MaskedTextBox.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.c55 = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.c57 = new System.Windows.Forms.NumericUpDown();
            this.c58 = new System.Windows.Forms.NumericUpDown();
            this.c59 = new System.Windows.Forms.NumericUpDown();
            this.c60 = new System.Windows.Forms.CheckBox();
            this.c61 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.c63 = new System.Windows.Forms.CheckBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.c134 = new System.Windows.Forms.ComboBox();
            this.c133 = new System.Windows.Forms.ComboBox();
            this.c132 = new System.Windows.Forms.ComboBox();
            this.c72 = new System.Windows.Forms.CheckBox();
            this.c116 = new System.Windows.Forms.CheckBox();
            this.c106 = new System.Windows.Forms.CheckBox();
            this.c101 = new System.Windows.Forms.CheckBox();
            this.c100 = new System.Windows.Forms.CheckBox();
            this.c97 = new System.Windows.Forms.CheckBox();
            this.c96 = new System.Windows.Forms.CheckBox();
            this.c95 = new System.Windows.Forms.CheckBox();
            this.c94 = new System.Windows.Forms.CheckBox();
            this.c76 = new System.Windows.Forms.CheckBox();
            this.c75 = new System.Windows.Forms.CheckBox();
            this.c74 = new System.Windows.Forms.CheckBox();
            this.c73 = new System.Windows.Forms.CheckBox();
            this.c71 = new System.Windows.Forms.CheckBox();
            this.c70 = new System.Windows.Forms.CheckBox();
            this.c68 = new System.Windows.Forms.CheckBox();
            this.c67 = new System.Windows.Forms.CheckBox();
            this.c66 = new System.Windows.Forms.CheckBox();
            this.c65 = new System.Windows.Forms.CheckBox();
            this.c62 = new System.Windows.Forms.CheckBox();
            this.c158 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.c179 = new System.Windows.Forms.CheckBox();
            this.c169 = new System.Windows.Forms.CheckBox();
            this.c160 = new System.Windows.Forms.CheckBox();
            this.c159 = new System.Windows.Forms.CheckBox();
            this.c152 = new System.Windows.Forms.CheckBox();
            this.c139 = new System.Windows.Forms.CheckBox();
            this.c137 = new System.Windows.Forms.CheckBox();
            this.c88 = new System.Windows.Forms.CheckBox();
            this.label45 = new System.Windows.Forms.Label();
            this.c128 = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.c110 = new System.Windows.Forms.CheckBox();
            this.c126 = new System.Windows.Forms.CheckBox();
            this.c123 = new System.Windows.Forms.CheckBox();
            this.c125 = new System.Windows.Forms.CheckBox();
            this.c124 = new System.Windows.Forms.CheckBox();
            this.c122 = new System.Windows.Forms.CheckBox();
            this.c117 = new System.Windows.Forms.CheckBox();
            this.c115 = new System.Windows.Forms.CheckBox();
            this.c114 = new System.Windows.Forms.CheckBox();
            this.c113 = new System.Windows.Forms.CheckBox();
            this.c111 = new System.Windows.Forms.CheckBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.c109 = new System.Windows.Forms.NumericUpDown();
            this.c108 = new System.Windows.Forms.CheckBox();
            this.c107 = new System.Windows.Forms.CheckBox();
            this.c105 = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.c104 = new System.Windows.Forms.CheckBox();
            this.c103 = new System.Windows.Forms.CheckBox();
            this.c102 = new System.Windows.Forms.CheckBox();
            this.c99 = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.c98 = new System.Windows.Forms.CheckBox();
            this.c93 = new System.Windows.Forms.CheckBox();
            this.c92 = new System.Windows.Forms.CheckBox();
            this.c91 = new System.Windows.Forms.CheckBox();
            this.c90 = new System.Windows.Forms.CheckBox();
            this.c89 = new System.Windows.Forms.CheckBox();
            this.c86 = new System.Windows.Forms.CheckBox();
            this.c85 = new System.Windows.Forms.CheckBox();
            this.c82 = new System.Windows.Forms.CheckBox();
            this.c81 = new System.Windows.Forms.CheckBox();
            this.c80 = new System.Windows.Forms.CheckBox();
            this.c78 = new System.Windows.Forms.CheckBox();
            this.c69 = new System.Windows.Forms.CheckBox();
            this.c64 = new System.Windows.Forms.CheckBox();
            this.c54 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.c2000 = new System.Windows.Forms.CheckBox();
            this.c1008 = new System.Windows.Forms.CheckBox();
            this.c1007 = new System.Windows.Forms.CheckBox();
            this.c1006 = new System.Windows.Forms.CheckBox();
            this.label56 = new System.Windows.Forms.Label();
            this.c177 = new System.Windows.Forms.NumericUpDown();
            this.c173 = new System.Windows.Forms.CheckedListBox();
            this.c171 = new System.Windows.Forms.CheckBox();
            this.c170 = new System.Windows.Forms.CheckBox();
            this.c168 = new System.Windows.Forms.CheckBox();
            this.c162 = new System.Windows.Forms.NumericUpDown();
            this.c166 = new System.Windows.Forms.CheckBox();
            this.c165 = new System.Windows.Forms.CheckBox();
            this.c150 = new System.Windows.Forms.TextBox();
            this.c164 = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.c119 = new System.Windows.Forms.CheckBox();
            this.c163 = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.c161 = new System.Windows.Forms.CheckedListBox();
            this.c157 = new System.Windows.Forms.CheckBox();
            this.c156 = new System.Windows.Forms.CheckBox();
            this.c155 = new System.Windows.Forms.CheckBox();
            this.c154 = new System.Windows.Forms.CheckBox();
            this.c151 = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.c149 = new System.Windows.Forms.CheckBox();
            this.c148 = new System.Windows.Forms.CheckBox();
            this.c147 = new System.Windows.Forms.CheckBox();
            this.c146 = new System.Windows.Forms.CheckBox();
            this.c145 = new System.Windows.Forms.CheckBox();
            this.c144 = new System.Windows.Forms.CheckBox();
            this.c143 = new System.Windows.Forms.CheckBox();
            this.c142 = new System.Windows.Forms.CheckBox();
            this.c141 = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.c140 = new System.Windows.Forms.CheckBox();
            this.c138 = new System.Windows.Forms.CheckBox();
            this.c136 = new System.Windows.Forms.CheckBox();
            this.c135 = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.c131 = new System.Windows.Forms.CheckBox();
            this.c130 = new System.Windows.Forms.CheckBox();
            this.c129 = new System.Windows.Forms.CheckBox();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.c153 = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.c603 = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.c217 = new MaskedTextBox.MaskedTextBox();
            this.c216 = new MaskedTextBox.MaskedTextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.c1014 = new System.Windows.Forms.CheckBox();
            this.c1012 = new System.Windows.Forms.CheckBox();
            this.c1005 = new System.Windows.Forms.CheckBox();
            this.c1004 = new System.Windows.Forms.CheckBox();
            this.c1003 = new System.Windows.Forms.CheckBox();
            this.c1002 = new System.Windows.Forms.CheckBox();
            this.c1001 = new System.Windows.Forms.CheckBox();
            this.c178 = new System.Windows.Forms.CheckBox();
            this.c176 = new System.Windows.Forms.CheckBox();
            this.c175 = new MaskedTextBox.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.c174 = new System.Windows.Forms.CheckBox();
            this.c172 = new System.Windows.Forms.CheckBox();
            this.c127 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.c121 = new MaskedTextBox.MaskedTextBox();
            this.c120 = new MaskedTextBox.MaskedTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.c56 = new MaskedTextBox.MaskedTextBox();
            this.c47 = new MaskedTextBox.MaskedTextBox();
            this.c112 = new MaskedTextBox.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.c84 = new MaskedTextBox.MaskedTextBox();
            this.c83 = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.c79 = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.c1017 = new System.Windows.Forms.CheckBox();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.c1032 = new System.Windows.Forms.CheckBox();
            this.c1031 = new System.Windows.Forms.CheckBox();
            this.c1016 = new System.Windows.Forms.CheckBox();
            this.c1015 = new System.Windows.Forms.CheckBox();
            this.c602 = new System.Windows.Forms.CheckBox();
            this.c601 = new System.Windows.Forms.CheckBox();
            this.c1011 = new System.Windows.Forms.CheckBox();
            this.c1010 = new System.Windows.Forms.CheckBox();
            this.c1009 = new System.Windows.Forms.CheckBox();
            this.b167 = new System.Windows.Forms.Button();
            this.p167 = new System.Windows.Forms.PictureBox();
            this.label53 = new System.Windows.Forms.Label();
            this.c167 = new System.Windows.Forms.CheckBox();
            this.c77 = new System.Windows.Forms.CheckBox();
            this.c87 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.c5011 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.c10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c59)).BeginInit();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c99)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c177)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c164)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c151)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c141)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p167)).BeginInit();
            this.SuspendLayout();
            // 
            // c02
            // 
            this.c02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c02.Location = new System.Drawing.Point(19, 32);
            this.c02.Name = "c02";
            this.c02.Size = new System.Drawing.Size(136, 20);
            this.c02.TabIndex = 2;
            this.c02.Text = "A1. Mã số tự động";
            this.c02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(499, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ban giám đốc :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(470, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phụ trách bộ phận :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(499, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Người lập biểu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c07
            // 
            this.c07.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c07.Location = new System.Drawing.Point(587, 32);
            this.c07.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c07.Name = "c07";
            this.c07.Size = new System.Drawing.Size(171, 21);
            this.c07.TabIndex = 13;
            // 
            // c08
            // 
            this.c08.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c08.Location = new System.Drawing.Point(587, 80);
            this.c08.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c08.Name = "c08";
            this.c08.Size = new System.Drawing.Size(171, 21);
            this.c08.TabIndex = 15;
            // 
            // c09
            // 
            this.c09.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c09.Location = new System.Drawing.Point(587, 104);
            this.c09.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c09.Name = "c09";
            this.c09.Size = new System.Drawing.Size(171, 21);
            this.c09.TabIndex = 16;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(353, 422);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(74, 25);
            this.butOK.TabIndex = 56;
            this.butOK.Text = "&Cập nhật";
            this.butOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(428, 422);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 57;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // c04
            // 
            this.c04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c04.Location = new System.Drawing.Point(8, 10);
            this.c04.Name = "c04";
            this.c04.Size = new System.Drawing.Size(136, 20);
            this.c04.TabIndex = 5;
            this.c04.Text = "B1. Nhập đơn giá";
            this.c04.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c05
            // 
            this.c05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c05.Location = new System.Drawing.Point(270, 137);
            this.c05.Name = "c05";
            this.c05.Size = new System.Drawing.Size(136, 20);
            this.c05.TabIndex = 6;
            this.c05.Text = "A26. Xem trước khi in";
            this.c05.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c10
            // 
            this.c10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c10.Location = new System.Drawing.Point(688, 176);
            this.c10.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(48, 21);
            this.c10.TabIndex = 19;
            this.c10.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.c10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(736, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "ngày";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(484, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "A37. Ngày làm việc so với ngày hệ thống :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c11
            // 
            this.c11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(19, 85);
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(260, 20);
            this.c11.TabIndex = 21;
            this.c11.Text = "A5. Nhập dược bệnh viện trong khai báo dMục";
            this.c11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(19, 103);
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(250, 21);
            this.c12.TabIndex = 22;
            this.c12.Text = "A6. Nhập nhóm kế toán trong khai báo dMục";
            this.c12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c13
            // 
            this.c13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c13.Location = new System.Drawing.Point(292, 8);
            this.c13.Name = "c13";
            this.c13.Size = new System.Drawing.Size(224, 20);
            this.c13.TabIndex = 41;
            this.c13.Text = "B20. Đã khóa số liệu";
            this.c13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c14
            // 
            this.c14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c14.Location = new System.Drawing.Point(536, 114);
            this.c14.Name = "c14";
            this.c14.Size = new System.Drawing.Size(242, 21);
            this.c14.TabIndex = 42;
            this.c14.Text = "B45. Giá bán phải lớn hơn hoặc bằng giá mua";
            this.c14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c15
            // 
            this.c15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c15.Location = new System.Drawing.Point(587, 56);
            this.c15.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c15.Name = "c15";
            this.c15.Size = new System.Drawing.Size(171, 21);
            this.c15.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(510, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Kế toán kho :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c16
            // 
            this.c16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c16.Location = new System.Drawing.Point(587, 152);
            this.c16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c16.Name = "c16";
            this.c16.Size = new System.Drawing.Size(171, 21);
            this.c16.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(510, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Thủ kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c20
            // 
            this.c20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c20.Location = new System.Drawing.Point(536, 62);
            this.c20.Name = "c20";
            this.c20.Size = new System.Drawing.Size(216, 20);
            this.c20.TabIndex = 46;
            this.c20.Text = "B42. Quản lý lô sn xuất";
            this.c20.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c19
            // 
            this.c19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c19.Location = new System.Drawing.Point(536, 43);
            this.c19.Name = "c19";
            this.c19.Size = new System.Drawing.Size(176, 21);
            this.c19.TabIndex = 45;
            this.c19.Text = "B41. Quản lý hạn dùng";
            this.c19.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c17
            // 
            this.c17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c17.Location = new System.Drawing.Point(536, 8);
            this.c17.Name = "c17";
            this.c17.Size = new System.Drawing.Size(176, 21);
            this.c17.TabIndex = 43;
            this.c17.Text = "B39. Quản lý nguồn hàng";
            this.c17.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c18
            // 
            this.c18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c18.Location = new System.Drawing.Point(536, 26);
            this.c18.Name = "c18";
            this.c18.Size = new System.Drawing.Size(184, 21);
            this.c18.TabIndex = 44;
            this.c18.Text = "B40. Quản lý nhà cung cấp";
            this.c18.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c21
            // 
            this.c21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c21.Location = new System.Drawing.Point(270, 156);
            this.c21.Name = "c21";
            this.c21.Size = new System.Drawing.Size(168, 21);
            this.c21.TabIndex = 7;
            this.c21.Text = "A27. Hiện thông số trước in";
            this.c21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c22
            // 
            this.c22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c22.Location = new System.Drawing.Point(688, 200);
            this.c22.Name = "c22";
            this.c22.Size = new System.Drawing.Size(48, 21);
            this.c22.TabIndex = 20;
            this.c22.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.c22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(736, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 19);
            this.label6.TabIndex = 31;
            this.label6.Text = "ngày";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(484, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "A38. Số ngày hoàn trả so với ngày lãnh là:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c23
            // 
            this.c23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c23.Location = new System.Drawing.Point(19, 66);
            this.c23.Name = "c23";
            this.c23.Size = new System.Drawing.Size(148, 20);
            this.c23.TabIndex = 3;
            this.c23.Text = "A4. Nhập tên hoạt chất";
            this.c23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c24
            // 
            this.c24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c24.Location = new System.Drawing.Point(19, 244);
            this.c24.Name = "c24";
            this.c24.Size = new System.Drawing.Size(237, 21);
            this.c24.TabIndex = 27;
            this.c24.Text = "A14. Nhập họ tên trong xuất ngoại trú";
            this.c24.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c25
            // 
            this.c25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c25.Location = new System.Drawing.Point(19, 262);
            this.c25.Name = "c25";
            this.c25.Size = new System.Drawing.Size(237, 21);
            this.c25.TabIndex = 28;
            this.c25.Text = "A15. Nhập năm sinh trong xuất ngoại trú";
            this.c25.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Bảo hiểm cùng chi trả";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ma13
            // 
            this.ma13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma13.Location = new System.Drawing.Point(169, 32);
            this.ma13.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma13.Name = "ma13";
            this.ma13.Size = new System.Drawing.Size(370, 21);
            this.ma13.TabIndex = 48;
            // 
            // ma16
            // 
            this.ma16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma16.Location = new System.Drawing.Point(-55, 342);
            this.ma16.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma16.Name = "ma16";
            this.ma16.Size = new System.Drawing.Size(93, 21);
            this.ma16.TabIndex = 52;
            this.ma16.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "Số thẻ 15 ký tự, Chi trả 80 % :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 23);
            this.label12.TabIndex = 37;
            this.label12.Text = "Số thẻ 18 ký tự, Chi trả 80 % :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c26
            // 
            this.c26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c26.Location = new System.Drawing.Point(147, 35);
            this.c26.Name = "c26";
            this.c26.Size = new System.Drawing.Size(107, 16);
            this.c26.TabIndex = 40;
            this.c26.Text = "A2. Nhập mã số";
            this.c26.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c27
            // 
            this.c27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c27.Location = new System.Drawing.Point(19, 155);
            this.c27.Name = "c27";
            this.c27.Size = new System.Drawing.Size(229, 22);
            this.c27.TabIndex = 23;
            this.c27.Text = "A9. Nhập số thẻ trong bảo hiểm";
            // 
            // c28
            // 
            this.c28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c28.Location = new System.Drawing.Point(270, 82);
            this.c28.Name = "c28";
            this.c28.Size = new System.Drawing.Size(190, 20);
            this.c28.TabIndex = 8;
            this.c28.Text = "A23. Lọc ngày trong phiếu lĩnh";
            this.c28.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c29
            // 
            this.c29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c29.Location = new System.Drawing.Point(270, 100);
            this.c29.Name = "c29";
            this.c29.Size = new System.Drawing.Size(201, 20);
            this.c29.TabIndex = 9;
            this.c29.Text = "A24. Lọc ngày trong phiếu hoàn trả";
            this.c29.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c30
            // 
            this.c30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c30.Location = new System.Drawing.Point(270, 32);
            this.c30.Name = "c30";
            this.c30.Size = new System.Drawing.Size(200, 20);
            this.c30.TabIndex = 10;
            this.c30.Text = "A20. Lọc ngày trong xuất bảo hiểm";
            this.c30.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c31
            // 
            this.c31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c31.Location = new System.Drawing.Point(270, 49);
            this.c31.Name = "c31";
            this.c31.Size = new System.Drawing.Size(201, 20);
            this.c31.TabIndex = 11;
            this.c31.Text = "A21. Lọc ngày trong xuất ngoại trú";
            this.c31.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c32
            // 
            this.c32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c32.Location = new System.Drawing.Point(587, 128);
            this.c32.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c32.Name = "c32";
            this.c32.Size = new System.Drawing.Size(171, 21);
            this.c32.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(483, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 23);
            this.label13.TabIndex = 38;
            this.label13.Text = "Phụ trách  kế toán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butHinh
            // 
            this.butHinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHinh.Location = new System.Drawing.Point(760, 8);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(22, 21);
            this.butHinh.TabIndex = 35;
            this.butHinh.Text = "...";
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-26, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 23);
            this.label14.TabIndex = 40;
            this.label14.Text = "Tiêu đề :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(302, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 23);
            this.label15.TabIndex = 41;
            this.label15.Text = "Hình :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 8);
            this.kho.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(251, 21);
            this.kho.TabIndex = 0;
            // 
            // hinh
            // 
            this.hinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hinh.Enabled = false;
            this.hinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hinh.Location = new System.Drawing.Point(342, 8);
            this.hinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hinh.Name = "hinh";
            this.hinh.Size = new System.Drawing.Size(416, 21);
            this.hinh.TabIndex = 1;
            // 
            // c33
            // 
            this.c33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c33.Location = new System.Drawing.Point(292, 157);
            this.c33.Name = "c33";
            this.c33.Size = new System.Drawing.Size(238, 21);
            this.c33.TabIndex = 33;
            this.c33.Text = "B28. Dự trù mua (Xem tổng tồn tháng trước)";
            this.c33.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c34
            // 
            this.c34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c34.Location = new System.Drawing.Point(19, 174);
            this.c34.Name = "c34";
            this.c34.Size = new System.Drawing.Size(229, 21);
            this.c34.TabIndex = 24;
            this.c34.Text = "A10. Nhập phòng khám trong bảo hiểm";
            this.c34.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c36
            // 
            this.c36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c36.Location = new System.Drawing.Point(19, 192);
            this.c36.Name = "c36";
            this.c36.Size = new System.Drawing.Size(217, 20);
            this.c36.TabIndex = 25;
            this.c36.Text = "A11. Nhập chẩn đoán trong bảo hiểm";
            this.c36.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c35
            // 
            this.c35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c35.Location = new System.Drawing.Point(19, 209);
            this.c35.Name = "c35";
            this.c35.Size = new System.Drawing.Size(198, 21);
            this.c35.TabIndex = 34;
            this.c35.Text = "A12. Nhập bác sĩ trong bảo hiểm";
            this.c35.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c37
            // 
            this.c37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c37.Location = new System.Drawing.Point(270, 66);
            this.c37.Name = "c37";
            this.c37.Size = new System.Drawing.Size(190, 21);
            this.c37.TabIndex = 12;
            this.c37.Text = "A22. Lọc ngày trong xuất tủ trực";
            this.c37.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c38
            // 
            this.c38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c38.Location = new System.Drawing.Point(19, 319);
            this.c38.Name = "c38";
            this.c38.Size = new System.Drawing.Size(229, 21);
            this.c38.TabIndex = 35;
            this.c38.Text = "A18. Nhập khoa/phòng xuất ngoại trú";
            this.c38.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c39
            // 
            this.c39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c39.Location = new System.Drawing.Point(19, 280);
            this.c39.Name = "c39";
            this.c39.Size = new System.Drawing.Size(217, 21);
            this.c39.TabIndex = 36;
            this.c39.Text = "A16. Nhập bác sỹ trong xuất ngoại trú";
            this.c39.CheckedChanged += new System.EventHandler(this.c39_CheckedChanged);
            this.c39.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c40
            // 
            this.c40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c40.Location = new System.Drawing.Point(19, 226);
            this.c40.Name = "c40";
            this.c40.Size = new System.Drawing.Size(250, 21);
            this.c40.TabIndex = 26;
            this.c40.Text = "A13. Nhập mã người bệnh trong xuất ngoại trú";
            // 
            // c41
            // 
            this.c41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c41.Location = new System.Drawing.Point(270, 119);
            this.c41.Name = "c41";
            this.c41.Size = new System.Drawing.Size(232, 20);
            this.c41.TabIndex = 37;
            this.c41.Text = "A25. Lọc theo người dùng trong duyệt";
            this.c41.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c42
            // 
            this.c42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c42.Location = new System.Drawing.Point(19, 121);
            this.c42.Name = "c42";
            this.c42.Size = new System.Drawing.Size(250, 20);
            this.c42.TabIndex = 38;
            this.c42.Text = "A7. In cột số lượng yêu cầu trong phiếu lĩnh";
            this.c42.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c43
            // 
            this.c43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c43.Location = new System.Drawing.Point(292, 26);
            this.c43.Name = "c43";
            this.c43.Size = new System.Drawing.Size(202, 20);
            this.c43.TabIndex = 39;
            this.c43.Text = "B21. Chỉnh sửa số lượng trong duyệt";
            this.c43.CheckedChanged += new System.EventHandler(this.c43_CheckedChanged);
            this.c43.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(4, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 17);
            this.label16.TabIndex = 45;
            this.label16.Text = "B7. Khoảng cách ngày in phiếu ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c44
            // 
            this.c44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c44.Location = new System.Drawing.Point(166, 123);
            this.c44.Name = "c44";
            this.c44.Size = new System.Drawing.Size(43, 21);
            this.c44.TabIndex = 47;
            this.c44.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c44.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(214, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 19);
            this.label17.TabIndex = 47;
            this.label17.Text = "ngày";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c45
            // 
            this.c45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c45.Location = new System.Drawing.Point(8, 27);
            this.c45.Name = "c45";
            this.c45.Size = new System.Drawing.Size(248, 20);
            this.c45.TabIndex = 32;
            this.c45.Text = "B2. Nhập số lượng qui đổi trong phiếu nhập";
            this.c45.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c46
            // 
            this.c46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c46.Location = new System.Drawing.Point(8, 45);
            this.c46.Name = "c46";
            this.c46.Size = new System.Drawing.Size(257, 21);
            this.c46.TabIndex = 29;
            this.c46.Text = "B3. Chọn quyển sổ trong viện phí bảo hiểm";
            this.c46.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(235, 421);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 23);
            this.label19.TabIndex = 52;
            this.label19.Text = "Ngoại trú chi trả";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Visible = false;
            // 
            // c48
            // 
            this.c48.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c48.Location = new System.Drawing.Point(329, 430);
            this.c48.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c48.Name = "c48";
            this.c48.Size = new System.Drawing.Size(94, 21);
            this.c48.TabIndex = 49;
            this.c48.Visible = false;
            // 
            // c49
            // 
            this.c49.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c49.Location = new System.Drawing.Point(169, 56);
            this.c49.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c49.Name = "c49";
            this.c49.Size = new System.Drawing.Size(495, 21);
            this.c49.TabIndex = 53;
            // 
            // c50
            // 
            this.c50.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c50.Location = new System.Drawing.Point(682, 32);
            this.c50.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c50.Name = "c50";
            this.c50.Size = new System.Drawing.Size(57, 21);
            this.c50.TabIndex = 50;
            this.c50.Text = "20000";
            this.c50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c51
            // 
            this.c51.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c51.Location = new System.Drawing.Point(682, 56);
            this.c51.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c51.Name = "c51";
            this.c51.Size = new System.Drawing.Size(57, 21);
            this.c51.TabIndex = 55;
            this.c51.Text = "20000";
            this.c51.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(680, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 23);
            this.label20.TabIndex = 57;
            this.label20.Text = "Số tiền";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(666, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 23);
            this.label21.TabIndex = 58;
            this.label21.Text = ">";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(666, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 23);
            this.label22.TabIndex = 59;
            this.label22.Text = ">";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c52
            // 
            this.c52.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c52.Location = new System.Drawing.Point(741, 32);
            this.c52.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c52.Name = "c52";
            this.c52.Size = new System.Drawing.Size(39, 21);
            this.c52.TabIndex = 51;
            this.c52.Text = "5,1";
            this.c52.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c52.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c53
            // 
            this.c53.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c53.Location = new System.Drawing.Point(741, 56);
            this.c53.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c53.Name = "c53";
            this.c53.Size = new System.Drawing.Size(39, 21);
            this.c53.TabIndex = 56;
            this.c53.Text = "5,2";
            this.c53.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c53.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(744, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 62;
            this.label23.Text = "Vị trí";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c55
            // 
            this.c55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c55.Location = new System.Drawing.Point(536, 250);
            this.c55.Name = "c55";
            this.c55.Size = new System.Drawing.Size(242, 21);
            this.c55.TabIndex = 65;
            this.c55.Text = "B53. Thuốc Nội-Ngoại dựa theo Hảng SX";
            this.c55.CheckedChanged += new System.EventHandler(this.c55_CheckedChanged);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(150, 105);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 17);
            this.label28.TabIndex = 80;
            this.label28.Text = "số lẻ";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(48, 169);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 17);
            this.label27.TabIndex = 79;
            this.label27.Text = "Thành tiền :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(56, 103);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 17);
            this.label25.TabIndex = 76;
            this.label25.Text = "Số lượng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(48, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 17);
            this.label26.TabIndex = 78;
            this.label26.Text = "Đơn giá :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c57
            // 
            this.c57.Location = new System.Drawing.Point(112, 103);
            this.c57.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.c57.Name = "c57";
            this.c57.Size = new System.Drawing.Size(32, 20);
            this.c57.TabIndex = 83;
            // 
            // c58
            // 
            this.c58.Location = new System.Drawing.Point(112, 125);
            this.c58.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.c58.Name = "c58";
            this.c58.Size = new System.Drawing.Size(32, 20);
            this.c58.TabIndex = 84;
            // 
            // c59
            // 
            this.c59.Location = new System.Drawing.Point(112, 169);
            this.c59.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.c59.Name = "c59";
            this.c59.Size = new System.Drawing.Size(32, 20);
            this.c59.TabIndex = 85;
            // 
            // c60
            // 
            this.c60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c60.Location = new System.Drawing.Point(8, 82);
            this.c60.Name = "c60";
            this.c60.Size = new System.Drawing.Size(248, 21);
            this.c60.TabIndex = 86;
            this.c60.Text = "B5. Cho phép nhập tủ trực trong phiếu lĩnh";
            this.c60.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c61
            // 
            this.c61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c61.Location = new System.Drawing.Point(8, 63);
            this.c61.Name = "c61";
            this.c61.Size = new System.Drawing.Size(222, 21);
            this.c61.TabIndex = 87;
            this.c61.Text = "B4. Cho phép nhập tủ trực trong hao phí";
            this.c61.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(150, 127);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 17);
            this.label29.TabIndex = 89;
            this.label29.Text = "số lẻ";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(150, 169);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(34, 17);
            this.label30.TabIndex = 90;
            this.label30.Text = "số lẻ";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c63
            // 
            this.c63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c63.Location = new System.Drawing.Point(292, 62);
            this.c63.Name = "c63";
            this.c63.Size = new System.Drawing.Size(148, 21);
            this.c63.TabIndex = 91;
            this.c63.Text = "B23. Cấp phát tròn số ";
            this.c63.CheckedChanged += new System.EventHandler(this.c63_CheckedChanged);
            this.c63.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage4);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Controls.Add(this.tabPage5);
            this.tab.Location = new System.Drawing.Point(0, 6);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(803, 412);
            this.tab.TabIndex = 92;
            this.tab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tab_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.c26);
            this.tabPage1.Controls.Add(this.c134);
            this.tabPage1.Controls.Add(this.c133);
            this.tabPage1.Controls.Add(this.c132);
            this.tabPage1.Controls.Add(this.c72);
            this.tabPage1.Controls.Add(this.c116);
            this.tabPage1.Controls.Add(this.c106);
            this.tabPage1.Controls.Add(this.c29);
            this.tabPage1.Controls.Add(this.c28);
            this.tabPage1.Controls.Add(this.c101);
            this.tabPage1.Controls.Add(this.c100);
            this.tabPage1.Controls.Add(this.c97);
            this.tabPage1.Controls.Add(this.c96);
            this.tabPage1.Controls.Add(this.c95);
            this.tabPage1.Controls.Add(this.c94);
            this.tabPage1.Controls.Add(this.c76);
            this.tabPage1.Controls.Add(this.c75);
            this.tabPage1.Controls.Add(this.c74);
            this.tabPage1.Controls.Add(this.c73);
            this.tabPage1.Controls.Add(this.c71);
            this.tabPage1.Controls.Add(this.c70);
            this.tabPage1.Controls.Add(this.c68);
            this.tabPage1.Controls.Add(this.c67);
            this.tabPage1.Controls.Add(this.c66);
            this.tabPage1.Controls.Add(this.c65);
            this.tabPage1.Controls.Add(this.c62);
            this.tabPage1.Controls.Add(this.c22);
            this.tabPage1.Controls.Add(this.c10);
            this.tabPage1.Controls.Add(this.hinh);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.butHinh);
            this.tabPage1.Controls.Add(this.c02);
            this.tabPage1.Controls.Add(this.c23);
            this.tabPage1.Controls.Add(this.c05);
            this.tabPage1.Controls.Add(this.c21);
            this.tabPage1.Controls.Add(this.c11);
            this.tabPage1.Controls.Add(this.c12);
            this.tabPage1.Controls.Add(this.c30);
            this.tabPage1.Controls.Add(this.c31);
            this.tabPage1.Controls.Add(this.c37);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.c07);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.c32);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.c08);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.c09);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.c15);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.c16);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.c27);
            this.tabPage1.Controls.Add(this.c34);
            this.tabPage1.Controls.Add(this.c36);
            this.tabPage1.Controls.Add(this.c40);
            this.tabPage1.Controls.Add(this.c24);
            this.tabPage1.Controls.Add(this.c25);
            this.tabPage1.Controls.Add(this.c41);
            this.tabPage1.Controls.Add(this.c42);
            this.tabPage1.Controls.Add(this.c35);
            this.tabPage1.Controls.Add(this.c38);
            this.tabPage1.Controls.Add(this.c39);
            this.tabPage1.Controls.Add(this.c158);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(795, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // c134
            // 
            this.c134.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c134.Location = new System.Drawing.Point(376, 266);
            this.c134.Name = "c134";
            this.c134.Size = new System.Drawing.Size(139, 21);
            this.c134.TabIndex = 141;
            // 
            // c133
            // 
            this.c133.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c133.Location = new System.Drawing.Point(376, 243);
            this.c133.Name = "c133";
            this.c133.Size = new System.Drawing.Size(139, 21);
            this.c133.TabIndex = 140;
            // 
            // c132
            // 
            this.c132.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c132.Location = new System.Drawing.Point(376, 220);
            this.c132.Name = "c132";
            this.c132.Size = new System.Drawing.Size(139, 21);
            this.c132.TabIndex = 139;
            // 
            // c72
            // 
            this.c72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c72.Location = new System.Drawing.Point(474, 339);
            this.c72.Name = "c72";
            this.c72.Size = new System.Drawing.Size(325, 20);
            this.c72.TabIndex = 96;
            this.c72.Text = "A45. Nhóm PLĩnh theo khai báo trong vật tư,S.phẩm,H.hóa";
            this.c72.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c116
            // 
            this.c116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c116.Location = new System.Drawing.Point(19, 51);
            this.c116.Name = "c116";
            this.c116.Size = new System.Drawing.Size(237, 16);
            this.c116.TabIndex = 120;
            this.c116.Text = "A3. Nhập nhà cung cấp trong danh mục";
            // 
            // c106
            // 
            this.c106.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c106.Location = new System.Drawing.Point(19, 299);
            this.c106.Name = "c106";
            this.c106.Size = new System.Drawing.Size(229, 21);
            this.c106.TabIndex = 119;
            this.c106.Text = "A17. Bắt buộc phải nhập bác sỹ";
            this.c106.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c101
            // 
            this.c101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c101.Location = new System.Drawing.Point(542, 322);
            this.c101.Name = "c101";
            this.c101.Size = new System.Drawing.Size(232, 21);
            this.c101.TabIndex = 118;
            this.c101.Text = "A44. Xếp thứ tự theo mã số";
            this.c101.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c100
            // 
            this.c100.Location = new System.Drawing.Point(270, 338);
            this.c100.Name = "c100";
            this.c100.Size = new System.Drawing.Size(210, 21);
            this.c100.TabIndex = 117;
            this.c100.Text = "A36. Chi tiết đối tượng trong phiếu lĩnh";
            this.c100.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c97
            // 
            this.c97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c97.Location = new System.Drawing.Point(542, 305);
            this.c97.Name = "c97";
            this.c97.Size = new System.Drawing.Size(232, 21);
            this.c97.TabIndex = 116;
            this.c97.Text = "A43. Nhập định khoản trong phiếu nhập";
            // 
            // c96
            // 
            this.c96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c96.Location = new System.Drawing.Point(542, 288);
            this.c96.Name = "c96";
            this.c96.Size = new System.Drawing.Size(240, 21);
            this.c96.TabIndex = 115;
            this.c96.Text = "A42. Nhập người giao hàng trong phiếu nhập";
            // 
            // c95
            // 
            this.c95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c95.Location = new System.Drawing.Point(542, 271);
            this.c95.Name = "c95";
            this.c95.Size = new System.Drawing.Size(228, 21);
            this.c95.TabIndex = 114;
            this.c95.Text = "A41. Nhập biên bản kê trong phiếu nhập";
            // 
            // c94
            // 
            this.c94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c94.Location = new System.Drawing.Point(19, 336);
            this.c94.Name = "c94";
            this.c94.Size = new System.Drawing.Size(242, 21);
            this.c94.TabIndex = 113;
            this.c94.Text = "A19. Nhập chẩn đoán trong xuất ngoại trú";
            this.c94.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c76
            // 
            this.c76.Location = new System.Drawing.Point(542, 256);
            this.c76.Name = "c76";
            this.c76.Size = new System.Drawing.Size(208, 19);
            this.c76.TabIndex = 112;
            this.c76.Text = "A40. In y lệnh kèm theo cách dùng";
            this.c76.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c75
            // 
            this.c75.Location = new System.Drawing.Point(542, 239);
            this.c75.Name = "c75";
            this.c75.Size = new System.Drawing.Size(224, 19);
            this.c75.TabIndex = 111;
            this.c75.Text = "A39. Cho phép lọc phiếu trong lúc duyệt";
            this.c75.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c74
            // 
            this.c74.Location = new System.Drawing.Point(542, 222);
            this.c74.Name = "c74";
            this.c74.Size = new System.Drawing.Size(218, 19);
            this.c74.TabIndex = 110;
            this.c74.Text = "A38. In phiếu lĩnh chiều ngang";
            this.c74.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c73
            // 
            this.c73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c73.Location = new System.Drawing.Point(270, 322);
            this.c73.Name = "c73";
            this.c73.Size = new System.Drawing.Size(261, 20);
            this.c73.TabIndex = 97;
            this.c73.Text = "A35. Số liệu chuyển kho in riêng nhập xuất tồn";
            this.c73.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c71
            // 
            this.c71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c71.Location = new System.Drawing.Point(270, 306);
            this.c71.Name = "c71";
            this.c71.Size = new System.Drawing.Size(261, 20);
            this.c71.TabIndex = 95;
            this.c71.Text = "A34. Chọn kho trong phiếu xuất ngoại trú";
            this.c71.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c70
            // 
            this.c70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c70.Location = new System.Drawing.Point(270, 289);
            this.c70.Name = "c70";
            this.c70.Size = new System.Drawing.Size(261, 20);
            this.c70.TabIndex = 94;
            this.c70.Text = "A33. Lọc theo người nhập trong phiếu bảo hiểm";
            this.c70.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c68
            // 
            this.c68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c68.Location = new System.Drawing.Point(270, 266);
            this.c68.Name = "c68";
            this.c68.Size = new System.Drawing.Size(210, 20);
            this.c68.TabIndex = 93;
            this.c68.Text = "A32. Họ tên trong phiếu lĩnh (Độc A-B)";
            this.c68.CheckedChanged += new System.EventHandler(this.c68_CheckedChanged);
            this.c68.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c67
            // 
            this.c67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c67.Location = new System.Drawing.Point(270, 244);
            this.c67.Name = "c67";
            this.c67.Size = new System.Drawing.Size(228, 20);
            this.c67.TabIndex = 92;
            this.c67.Text = "A31. Họ tên trong phiếu lĩnh (Hướng tâm thần)";
            this.c67.CheckedChanged += new System.EventHandler(this.c67_CheckedChanged);
            this.c67.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c66
            // 
            this.c66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c66.Location = new System.Drawing.Point(270, 226);
            this.c66.Name = "c66";
            this.c66.Size = new System.Drawing.Size(210, 20);
            this.c66.TabIndex = 91;
            this.c66.Text = "A30. Họ tên trong phiếu lĩnh (Gây nghiện)";
            this.c66.CheckedChanged += new System.EventHandler(this.c66_CheckedChanged);
            this.c66.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c65
            // 
            this.c65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c65.Location = new System.Drawing.Point(270, 176);
            this.c65.Name = "c65";
            this.c65.Size = new System.Drawing.Size(190, 20);
            this.c65.TabIndex = 90;
            this.c65.Text = "A28. In đơn giá trong phiếu lĩnh";
            this.c65.CheckedChanged += new System.EventHandler(this.c65_CheckedChanged);
            this.c65.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c62
            // 
            this.c62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c62.Location = new System.Drawing.Point(19, 141);
            this.c62.Name = "c62";
            this.c62.Size = new System.Drawing.Size(250, 16);
            this.c62.TabIndex = 89;
            this.c62.Text = "A8. Nhập mã người bệnh  trong bảo hiểm";
            // 
            // c158
            // 
            this.c158.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c158.Location = new System.Drawing.Point(270, 196);
            this.c158.Name = "c158";
            this.c158.Size = new System.Drawing.Size(222, 20);
            this.c158.TabIndex = 142;
            this.c158.Text = "A29. In đơn giá, lô, date trong phiếu lĩnh";
            this.c158.CheckedChanged += new System.EventHandler(this.c158_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.c179);
            this.tabPage2.Controls.Add(this.c169);
            this.tabPage2.Controls.Add(this.c160);
            this.tabPage2.Controls.Add(this.c159);
            this.tabPage2.Controls.Add(this.c152);
            this.tabPage2.Controls.Add(this.c139);
            this.tabPage2.Controls.Add(this.c137);
            this.tabPage2.Controls.Add(this.c88);
            this.tabPage2.Controls.Add(this.label45);
            this.tabPage2.Controls.Add(this.c128);
            this.tabPage2.Controls.Add(this.label44);
            this.tabPage2.Controls.Add(this.c110);
            this.tabPage2.Controls.Add(this.c19);
            this.tabPage2.Controls.Add(this.c18);
            this.tabPage2.Controls.Add(this.c126);
            this.tabPage2.Controls.Add(this.c123);
            this.tabPage2.Controls.Add(this.c55);
            this.tabPage2.Controls.Add(this.c125);
            this.tabPage2.Controls.Add(this.c124);
            this.tabPage2.Controls.Add(this.c122);
            this.tabPage2.Controls.Add(this.c117);
            this.tabPage2.Controls.Add(this.c115);
            this.tabPage2.Controls.Add(this.c114);
            this.tabPage2.Controls.Add(this.c113);
            this.tabPage2.Controls.Add(this.c111);
            this.tabPage2.Controls.Add(this.label39);
            this.tabPage2.Controls.Add(this.label38);
            this.tabPage2.Controls.Add(this.c109);
            this.tabPage2.Controls.Add(this.c108);
            this.tabPage2.Controls.Add(this.c107);
            this.tabPage2.Controls.Add(this.c105);
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.label37);
            this.tabPage2.Controls.Add(this.c104);
            this.tabPage2.Controls.Add(this.c103);
            this.tabPage2.Controls.Add(this.c102);
            this.tabPage2.Controls.Add(this.c99);
            this.tabPage2.Controls.Add(this.label35);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.c98);
            this.tabPage2.Controls.Add(this.c93);
            this.tabPage2.Controls.Add(this.c92);
            this.tabPage2.Controls.Add(this.c91);
            this.tabPage2.Controls.Add(this.c90);
            this.tabPage2.Controls.Add(this.c89);
            this.tabPage2.Controls.Add(this.c86);
            this.tabPage2.Controls.Add(this.c85);
            this.tabPage2.Controls.Add(this.c82);
            this.tabPage2.Controls.Add(this.c81);
            this.tabPage2.Controls.Add(this.c80);
            this.tabPage2.Controls.Add(this.c78);
            this.tabPage2.Controls.Add(this.c69);
            this.tabPage2.Controls.Add(this.c64);
            this.tabPage2.Controls.Add(this.c54);
            this.tabPage2.Controls.Add(this.c44);
            this.tabPage2.Controls.Add(this.c04);
            this.tabPage2.Controls.Add(this.c45);
            this.tabPage2.Controls.Add(this.c46);
            this.tabPage2.Controls.Add(this.c61);
            this.tabPage2.Controls.Add(this.c60);
            this.tabPage2.Controls.Add(this.c63);
            this.tabPage2.Controls.Add(this.c43);
            this.tabPage2.Controls.Add(this.c33);
            this.tabPage2.Controls.Add(this.c13);
            this.tabPage2.Controls.Add(this.c14);
            this.tabPage2.Controls.Add(this.c17);
            this.tabPage2.Controls.Add(this.c20);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(795, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // c179
            // 
            this.c179.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c179.Location = new System.Drawing.Point(805, 10);
            this.c179.Name = "c179";
            this.c179.Size = new System.Drawing.Size(242, 21);
            this.c179.TabIndex = 205;
            this.c179.Text = "B59. Số phiếu nhập tự động theo user";
            // 
            // c169
            // 
            this.c169.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c169.Location = new System.Drawing.Point(292, 118);
            this.c169.Name = "c169";
            this.c169.Size = new System.Drawing.Size(202, 21);
            this.c169.TabIndex = 204;
            this.c169.Text = "B26. Treo phần lẻ duyệt riêng";
            // 
            // c160
            // 
            this.c160.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c160.Location = new System.Drawing.Point(536, 96);
            this.c160.Name = "c160";
            this.c160.Size = new System.Drawing.Size(226, 21);
            this.c160.TabIndex = 146;
            this.c160.Text = "B44. Xuất theo hạn dùng";
            this.c160.CheckedChanged += new System.EventHandler(this.c160_CheckedChanged);
            // 
            // c159
            // 
            this.c159.Checked = true;
            this.c159.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c159.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c159.Location = new System.Drawing.Point(536, 79);
            this.c159.Name = "c159";
            this.c159.Size = new System.Drawing.Size(226, 21);
            this.c159.TabIndex = 145;
            this.c159.Text = "B43. Xuất theo nhập trước xuất trước";
            this.c159.CheckedChanged += new System.EventHandler(this.c159_CheckedChanged);
            // 
            // c152
            // 
            this.c152.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c152.Location = new System.Drawing.Point(292, 245);
            this.c152.Name = "c152";
            this.c152.Size = new System.Drawing.Size(232, 21);
            this.c152.TabIndex = 122;
            this.c152.Text = "B33. Số hiệu khai báo trong viện phí";
            // 
            // c139
            // 
            this.c139.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c139.Location = new System.Drawing.Point(536, 342);
            this.c139.Name = "c139";
            this.c139.Size = new System.Drawing.Size(242, 21);
            this.c139.TabIndex = 144;
            this.c139.Text = "B58. Số phiếu nhập tự động theo ngày";
            // 
            // c137
            // 
            this.c137.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c137.Location = new System.Drawing.Point(292, 341);
            this.c137.Name = "c137";
            this.c137.Size = new System.Drawing.Size(148, 22);
            this.c137.TabIndex = 140;
            this.c137.Text = "B38. Theo kho";
            // 
            // c88
            // 
            this.c88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c88.Location = new System.Drawing.Point(536, 130);
            this.c88.Name = "c88";
            this.c88.Size = new System.Drawing.Size(184, 20);
            this.c88.TabIndex = 103;
            this.c88.Text = "B46. Theo dõi kinh phí sử dụng";
            this.c88.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(753, 305);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 21);
            this.label45.TabIndex = 139;
            this.label45.Text = "riêng";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c128
            // 
            this.c128.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c128.Location = new System.Drawing.Point(635, 305);
            this.c128.Name = "c128";
            this.c128.Size = new System.Drawing.Size(117, 21);
            this.c128.TabIndex = 137;
            this.c128.SelectedIndexChanged += new System.EventHandler(this.c128_SelectedIndexChanged);
            this.c128.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(513, 303);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(137, 23);
            this.label44.TabIndex = 138;
            this.label44.Text = "B56. Toa BHYT in nhóm";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c110
            // 
            this.c110.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c110.Location = new System.Drawing.Point(536, 325);
            this.c110.Name = "c110";
            this.c110.Size = new System.Drawing.Size(168, 21);
            this.c110.TabIndex = 125;
            this.c110.Text = "B57. Lọc ký tự từ trái sang phải";
            // 
            // c126
            // 
            this.c126.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c126.Location = new System.Drawing.Point(292, 301);
            this.c126.Name = "c126";
            this.c126.Size = new System.Drawing.Size(232, 21);
            this.c126.TabIndex = 136;
            this.c126.Text = "B36. Xuất bán lấy giá bán theo đợt nhập";
            // 
            // c123
            // 
            this.c123.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c123.Location = new System.Drawing.Point(536, 267);
            this.c123.Name = "c123";
            this.c123.Size = new System.Drawing.Size(226, 21);
            this.c123.TabIndex = 133;
            this.c123.Text = "B54. Thuốc Nội-Ngoại dựa theo Nước SX";
            this.c123.CheckedChanged += new System.EventHandler(this.c123_CheckedChanged);
            // 
            // c125
            // 
            this.c125.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c125.Location = new System.Drawing.Point(292, 99);
            this.c125.Name = "c125";
            this.c125.Size = new System.Drawing.Size(228, 21);
            this.c125.TabIndex = 135;
            this.c125.Text = "B25. Bù cơ số tủ trực tròn số (treo phần lẻ)";
            // 
            // c124
            // 
            this.c124.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c124.Location = new System.Drawing.Point(292, 283);
            this.c124.Name = "c124";
            this.c124.Size = new System.Drawing.Size(228, 21);
            this.c124.TabIndex = 134;
            this.c124.Text = "B35. In cách dùng trong phiếu xuất bán";
            // 
            // c122
            // 
            this.c122.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c122.Location = new System.Drawing.Point(536, 235);
            this.c122.Name = "c122";
            this.c122.Size = new System.Drawing.Size(265, 17);
            this.c122.TabIndex = 132;
            this.c122.Text = "B52. Cập nhật tồn kho tổng hợp trước khi cấp thuốc";
            // 
            // c117
            // 
            this.c117.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c117.Location = new System.Drawing.Point(536, 199);
            this.c117.Name = "c117";
            this.c117.Size = new System.Drawing.Size(242, 21);
            this.c117.TabIndex = 130;
            this.c117.Text = "B50. Toa BHYT in theo nhóm viện phí";
            // 
            // c115
            // 
            this.c115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c115.Location = new System.Drawing.Point(536, 183);
            this.c115.Name = "c115";
            this.c115.Size = new System.Drawing.Size(223, 20);
            this.c115.TabIndex = 129;
            this.c115.Text = "B49. Xuất ngoại trú in phiếu lĩnh";
            // 
            // c114
            // 
            this.c114.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c114.Location = new System.Drawing.Point(536, 165);
            this.c114.Name = "c114";
            this.c114.Size = new System.Drawing.Size(242, 21);
            this.c114.TabIndex = 128;
            this.c114.Text = "B48. Biên bản kiểm kê theo mẫu số C14-H";
            // 
            // c113
            // 
            this.c113.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c113.Location = new System.Drawing.Point(536, 147);
            this.c113.Name = "c113";
            this.c113.Size = new System.Drawing.Size(184, 20);
            this.c113.TabIndex = 127;
            this.c113.Text = "B47. Thẻ kho cộng dồn theo ngày";
            // 
            // c111
            // 
            this.c111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c111.Location = new System.Drawing.Point(536, 285);
            this.c111.Name = "c111";
            this.c111.Size = new System.Drawing.Size(263, 21);
            this.c111.TabIndex = 126;
            this.c111.Text = "B55. Tự động gửi tin nhắn khi dự trù/duyệt xong";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(1, 191);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(148, 17);
            this.label39.TabIndex = 124;
            this.label39.Text = "B10. Số lần in trong xuất bán";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(214, 192);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(32, 19);
            this.label38.TabIndex = 123;
            this.label38.Text = "lần";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c109
            // 
            this.c109.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c109.Location = new System.Drawing.Point(166, 189);
            this.c109.Name = "c109";
            this.c109.Size = new System.Drawing.Size(43, 21);
            this.c109.TabIndex = 122;
            this.c109.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // c108
            // 
            this.c108.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c108.Location = new System.Drawing.Point(292, 228);
            this.c108.Name = "c108";
            this.c108.Size = new System.Drawing.Size(202, 21);
            this.c108.TabIndex = 121;
            this.c108.Text = "B32. Xuất bán có biên lai tài chính";
            this.c108.CheckedChanged += new System.EventHandler(this.c108_CheckedChanged);
            this.c108.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c107
            // 
            this.c107.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c107.Location = new System.Drawing.Point(292, 320);
            this.c107.Name = "c107";
            this.c107.Size = new System.Drawing.Size(232, 21);
            this.c107.TabIndex = 120;
            this.c107.Text = "B37. Số phiếu nhập tăng tự động ";
            this.c107.CheckedChanged += new System.EventHandler(this.c107_CheckedChanged);
            this.c107.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c105
            // 
            this.c105.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c105.Location = new System.Drawing.Point(166, 167);
            this.c105.Name = "c105";
            this.c105.Size = new System.Drawing.Size(43, 21);
            this.c105.TabIndex = 117;
            this.c105.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c105.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(4, 167);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(163, 17);
            this.label36.TabIndex = 119;
            this.label36.Text = "B9. Khoảng cách ngày kiểm kê :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(214, 168);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 19);
            this.label37.TabIndex = 118;
            this.label37.Text = "ngày";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c104
            // 
            this.c104.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c104.Location = new System.Drawing.Point(292, 263);
            this.c104.Name = "c104";
            this.c104.Size = new System.Drawing.Size(238, 21);
            this.c104.TabIndex = 116;
            this.c104.Text = "B34. Nhập mã số, tên chung trong xuất bán";
            this.c104.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c103
            // 
            this.c103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c103.Location = new System.Drawing.Point(292, 213);
            this.c103.Name = "c103";
            this.c103.Size = new System.Drawing.Size(232, 15);
            this.c103.TabIndex = 115;
            this.c103.Text = "B31. Cho phép không cần in phiếu xuất bán";
            this.c103.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c102
            // 
            this.c102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c102.Location = new System.Drawing.Point(536, 217);
            this.c102.Name = "c102";
            this.c102.Size = new System.Drawing.Size(198, 21);
            this.c102.TabIndex = 114;
            this.c102.Text = "B51. In điền chi phí điều trị trẻ em";
            this.c102.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c99
            // 
            this.c99.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c99.Location = new System.Drawing.Point(166, 145);
            this.c99.Name = "c99";
            this.c99.Size = new System.Drawing.Size(43, 21);
            this.c99.TabIndex = 111;
            this.c99.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c99.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(4, 142);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(166, 17);
            this.label35.TabIndex = 113;
            this.label35.Text = "B8. Số ngày toa thuốc bảo hiểm";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(214, 145);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(32, 19);
            this.label34.TabIndex = 112;
            this.label34.Text = "ngày";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c98
            // 
            this.c98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c98.Location = new System.Drawing.Point(292, 192);
            this.c98.Name = "c98";
            this.c98.Size = new System.Drawing.Size(202, 21);
            this.c98.TabIndex = 110;
            this.c98.Text = "B30. In đơn giá mua trong thẻ kho";
            this.c98.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c93
            // 
            this.c93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c93.Location = new System.Drawing.Point(8, 348);
            this.c93.Name = "c93";
            this.c93.Size = new System.Drawing.Size(257, 21);
            this.c93.TabIndex = 108;
            this.c93.Text = "B19. In hãng/nước trong phiếu nhập && xuất";
            this.c93.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c92
            // 
            this.c92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c92.Location = new System.Drawing.Point(8, 101);
            this.c92.Name = "c92";
            this.c92.Size = new System.Drawing.Size(257, 21);
            this.c92.TabIndex = 107;
            this.c92.Text = "B6. Cho phép nhập số lượng không trừ cơ số";
            this.c92.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c91
            // 
            this.c91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c91.Location = new System.Drawing.Point(8, 331);
            this.c91.Name = "c91";
            this.c91.Size = new System.Drawing.Size(257, 21);
            this.c91.TabIndex = 106;
            this.c91.Text = "B18. Chứng từ nhập trong thẻ kho lấy số phiếu";
            // 
            // c90
            // 
            this.c90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c90.Location = new System.Drawing.Point(8, 313);
            this.c90.Name = "c90";
            this.c90.Size = new System.Drawing.Size(257, 21);
            this.c90.TabIndex = 105;
            this.c90.Text = "B17. Thống kê xuất bán theo người nhập";
            this.c90.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c89
            // 
            this.c89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c89.Location = new System.Drawing.Point(8, 296);
            this.c89.Name = "c89";
            this.c89.Size = new System.Drawing.Size(232, 21);
            this.c89.TabIndex = 104;
            this.c89.Text = "B16. Phiếu nhập theo thứ tự số phiếu";
            this.c89.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c86
            // 
            this.c86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c86.Location = new System.Drawing.Point(8, 279);
            this.c86.Name = "c86";
            this.c86.Size = new System.Drawing.Size(296, 21);
            this.c86.TabIndex = 101;
            this.c86.Text = "B15. Chẩn đoán trong đơn thuốc phải có trong ICD10";
            this.c86.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c85
            // 
            this.c85.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c85.Location = new System.Drawing.Point(8, 261);
            this.c85.Name = "c85";
            this.c85.Size = new System.Drawing.Size(296, 21);
            this.c85.TabIndex = 100;
            this.c85.Text = "B14.Thông báo khi nhập đThuốc lần thứ 2 trong ngày";
            this.c85.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c82
            // 
            this.c82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c82.Location = new System.Drawing.Point(8, 244);
            this.c82.Name = "c82";
            this.c82.Size = new System.Drawing.Size(184, 21);
            this.c82.TabIndex = 99;
            this.c82.Text = "B13. Công khám vào đơn BHYT";
            this.c82.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c81
            // 
            this.c81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c81.Location = new System.Drawing.Point(8, 228);
            this.c81.Name = "c81";
            this.c81.Size = new System.Drawing.Size(248, 21);
            this.c81.TabIndex = 98;
            this.c81.Text = "B12. In nhóm trong phiếu nhập && xuất";
            this.c81.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c80
            // 
            this.c80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c80.Location = new System.Drawing.Point(8, 211);
            this.c80.Name = "c80";
            this.c80.Size = new System.Drawing.Size(257, 21);
            this.c80.TabIndex = 97;
            this.c80.Text = "B11. Kiểm tra người bệnh khi cấp phát && thu hồi ";
            this.c80.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c78
            // 
            this.c78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c78.Location = new System.Drawing.Point(292, 43);
            this.c78.Name = "c78";
            this.c78.Size = new System.Drawing.Size(248, 20);
            this.c78.TabIndex = 96;
            this.c78.Text = "B22. Slượng thực không được lớn hơn yêu cầu";
            this.c78.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c69
            // 
            this.c69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c69.Location = new System.Drawing.Point(292, 80);
            this.c69.Name = "c69";
            this.c69.Size = new System.Drawing.Size(232, 21);
            this.c69.TabIndex = 94;
            this.c69.Text = "B24. Cấp phát tròn số (Cộng dồn đối tượng)";
            this.c69.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c64
            // 
            this.c64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c64.Location = new System.Drawing.Point(292, 176);
            this.c64.Name = "c64";
            this.c64.Size = new System.Drawing.Size(240, 21);
            this.c64.TabIndex = 93;
            this.c64.Text = "B29. Dự trù phiếu xuất kho (số liệu trong kho)";
            this.c64.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c54
            // 
            this.c54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c54.Location = new System.Drawing.Point(292, 137);
            this.c54.Name = "c54";
            this.c54.Size = new System.Drawing.Size(202, 22);
            this.c54.TabIndex = 92;
            this.c54.Text = "B27. Bù cơ số tủ trực cùng nguồn";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.c2000);
            this.tabPage4.Controls.Add(this.c1008);
            this.tabPage4.Controls.Add(this.c1007);
            this.tabPage4.Controls.Add(this.c1006);
            this.tabPage4.Controls.Add(this.label56);
            this.tabPage4.Controls.Add(this.c177);
            this.tabPage4.Controls.Add(this.c173);
            this.tabPage4.Controls.Add(this.c171);
            this.tabPage4.Controls.Add(this.c170);
            this.tabPage4.Controls.Add(this.c168);
            this.tabPage4.Controls.Add(this.c162);
            this.tabPage4.Controls.Add(this.c166);
            this.tabPage4.Controls.Add(this.c165);
            this.tabPage4.Controls.Add(this.c150);
            this.tabPage4.Controls.Add(this.c164);
            this.tabPage4.Controls.Add(this.label52);
            this.tabPage4.Controls.Add(this.c119);
            this.tabPage4.Controls.Add(this.c163);
            this.tabPage4.Controls.Add(this.label51);
            this.tabPage4.Controls.Add(this.label49);
            this.tabPage4.Controls.Add(this.c161);
            this.tabPage4.Controls.Add(this.c157);
            this.tabPage4.Controls.Add(this.c156);
            this.tabPage4.Controls.Add(this.c155);
            this.tabPage4.Controls.Add(this.c154);
            this.tabPage4.Controls.Add(this.c151);
            this.tabPage4.Controls.Add(this.label48);
            this.tabPage4.Controls.Add(this.label47);
            this.tabPage4.Controls.Add(this.c149);
            this.tabPage4.Controls.Add(this.c148);
            this.tabPage4.Controls.Add(this.c147);
            this.tabPage4.Controls.Add(this.c146);
            this.tabPage4.Controls.Add(this.c145);
            this.tabPage4.Controls.Add(this.c144);
            this.tabPage4.Controls.Add(this.c143);
            this.tabPage4.Controls.Add(this.c142);
            this.tabPage4.Controls.Add(this.c141);
            this.tabPage4.Controls.Add(this.label50);
            this.tabPage4.Controls.Add(this.c140);
            this.tabPage4.Controls.Add(this.c138);
            this.tabPage4.Controls.Add(this.c136);
            this.tabPage4.Controls.Add(this.c135);
            this.tabPage4.Controls.Add(this.label46);
            this.tabPage4.Controls.Add(this.c131);
            this.tabPage4.Controls.Add(this.c130);
            this.tabPage4.Controls.Add(this.c129);
            this.tabPage4.Controls.Add(this.dataGrid3);
            this.tabPage4.Controls.Add(this.c153);
            this.tabPage4.Controls.Add(this.label55);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(795, 386);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "3";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // c2000
            // 
            this.c2000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2000.Location = new System.Drawing.Point(529, 283);
            this.c2000.Name = "c2000";
            this.c2000.Size = new System.Drawing.Size(259, 20);
            this.c2000.TabIndex = 213;
            this.c2000.Text = "C43. Danh mục lưu server trung tâm";
            this.toolTip1.SetToolTip(this.c2000, "Thông số này chỉ dùng khi bệnh viện có server trung tâm dùng để lưu dữ liệu ");
            // 
            // c1008
            // 
            this.c1008.Checked = true;
            this.c1008.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1008.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1008.Location = new System.Drawing.Point(529, 264);
            this.c1008.Name = "c1008";
            this.c1008.Size = new System.Drawing.Size(259, 20);
            this.c1008.TabIndex = 212;
            this.c1008.Text = "C44. Khóa Phân loại";
            // 
            // c1007
            // 
            this.c1007.Checked = true;
            this.c1007.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1007.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1007.Location = new System.Drawing.Point(529, 246);
            this.c1007.Name = "c1007";
            this.c1007.Size = new System.Drawing.Size(259, 20);
            this.c1007.TabIndex = 211;
            this.c1007.Text = "C43. Khóa nhóm bộ (dược bệnh viện)";
            // 
            // c1006
            // 
            this.c1006.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1006.Location = new System.Drawing.Point(529, 228);
            this.c1006.Name = "c1006";
            this.c1006.Size = new System.Drawing.Size(259, 20);
            this.c1006.TabIndex = 210;
            this.c1006.Text = "C42. Chỉnh sửa số lượng trong duyệt kho cấp";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(724, 207);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(23, 19);
            this.label56.TabIndex = 208;
            this.label56.Text = "lần";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c177
            // 
            this.c177.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c177.Location = new System.Drawing.Point(680, 207);
            this.c177.Name = "c177";
            this.c177.Size = new System.Drawing.Size(43, 21);
            this.c177.TabIndex = 207;
            this.c177.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // c173
            // 
            this.c173.CheckOnClick = true;
            this.c173.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c173.FormattingEnabled = true;
            this.c173.Location = new System.Drawing.Point(505, 134);
            this.c173.Name = "c173";
            this.c173.Size = new System.Drawing.Size(273, 68);
            this.c173.TabIndex = 206;
            this.c173.SelectedValueChanged += new System.EventHandler(this.c173_SelectedValueChanged);
            // 
            // c171
            // 
            this.c171.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c171.Location = new System.Drawing.Point(7, 343);
            this.c171.Name = "c171";
            this.c171.Size = new System.Drawing.Size(516, 21);
            this.c171.TabIndex = 205;
            this.c171.Text = "C17. Người bệnh chỉ định vào khám , chưa vào phòng khám không hiện thị trong danh" +
                " sách chờ duyệt";
            // 
            // c170
            // 
            this.c170.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c170.Location = new System.Drawing.Point(504, 97);
            this.c170.Name = "c170";
            this.c170.Size = new System.Drawing.Size(318, 21);
            this.c170.TabIndex = 204;
            this.c170.Text = "C30.Thu hồi phiều bù kiểm tra tồn tủ trực";
            // 
            // c168
            // 
            this.c168.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c168.Location = new System.Drawing.Point(504, 80);
            this.c168.Name = "c168";
            this.c168.Size = new System.Drawing.Size(318, 21);
            this.c168.TabIndex = 203;
            this.c168.Text = "C29. In chi phí ngoại trú tách riêng chẩn đoán && bSỹ";
            // 
            // c162
            // 
            this.c162.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c162.Location = new System.Drawing.Point(679, 4);
            this.c162.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.c162.Name = "c162";
            this.c162.Size = new System.Drawing.Size(40, 21);
            this.c162.TabIndex = 191;
            this.c162.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // c166
            // 
            this.c166.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c166.Location = new System.Drawing.Point(504, 62);
            this.c166.Name = "c166";
            this.c166.Size = new System.Drawing.Size(318, 21);
            this.c166.TabIndex = 198;
            this.c166.Text = "C28.Tự động gửi tin nhắn âm thanh khi dự trù/duyệt";
            // 
            // c165
            // 
            this.c165.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c165.Location = new System.Drawing.Point(299, 190);
            this.c165.Name = "c165";
            this.c165.Size = new System.Drawing.Size(265, 20);
            this.c165.TabIndex = 196;
            this.c165.Text = "C24.Tỷ lệ giá bán lẻ dựa vào Giá mua";
            this.c165.CheckedChanged += new System.EventHandler(this.c165_CheckedChanged);
            // 
            // c150
            // 
            this.c150.Location = new System.Drawing.Point(87, 283);
            this.c150.Name = "c150";
            this.c150.Size = new System.Drawing.Size(194, 20);
            this.c150.TabIndex = 182;
            // 
            // c164
            // 
            this.c164.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c164.Location = new System.Drawing.Point(711, 41);
            this.c164.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.c164.Name = "c164";
            this.c164.Size = new System.Drawing.Size(42, 21);
            this.c164.TabIndex = 195;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(501, 42);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(344, 17);
            this.label52.TabIndex = 194;
            this.label52.Text = "C27. Khoảng cách duyệt đThuốc ngoại trú                ngày .";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c119
            // 
            this.c119.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c119.Location = new System.Drawing.Point(504, 115);
            this.c119.Name = "c119";
            this.c119.Size = new System.Drawing.Size(223, 21);
            this.c119.TabIndex = 131;
            this.c119.Text = "C40. Trừ số lượng tồn ảo khi dự trù";
            this.c119.CheckedChanged += new System.EventHandler(this.c119_CheckedChanged);
            // 
            // c163
            // 
            this.c163.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c163.Location = new System.Drawing.Point(504, 23);
            this.c163.Name = "c163";
            this.c163.Size = new System.Drawing.Size(272, 21);
            this.c163.TabIndex = 193;
            this.c163.Text = "C26. Hoàn trả bán lấy lại thông tin xuất bán";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(501, 5);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(344, 17);
            this.label51.TabIndex = 192;
            this.label51.Text = "C25. Thông báo thuốc hết hạn dùng               tháng tới .";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(296, 78);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(136, 23);
            this.label49.TabIndex = 190;
            this.label49.Text = "C22. Dự trù mua năm";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c161
            // 
            this.c161.CheckOnClick = true;
            this.c161.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c161.FormattingEnabled = true;
            this.c161.Location = new System.Drawing.Point(299, 101);
            this.c161.Name = "c161";
            this.c161.Size = new System.Drawing.Size(190, 68);
            this.c161.TabIndex = 189;
            // 
            // c157
            // 
            this.c157.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c157.Location = new System.Drawing.Point(299, 60);
            this.c157.Name = "c157";
            this.c157.Size = new System.Drawing.Size(215, 21);
            this.c157.TabIndex = 188;
            this.c157.Text = "C21. Hiện thị số tiền phiếu duyệt cấp";
            // 
            // c156
            // 
            this.c156.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c156.Location = new System.Drawing.Point(298, 41);
            this.c156.Name = "c156";
            this.c156.Size = new System.Drawing.Size(197, 21);
            this.c156.TabIndex = 187;
            this.c156.Text = "C20. Chuyển khám tính công khám";
            // 
            // c155
            // 
            this.c155.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c155.Location = new System.Drawing.Point(7, 264);
            this.c155.Name = "c155";
            this.c155.Size = new System.Drawing.Size(274, 21);
            this.c155.TabIndex = 186;
            this.c155.Text = "C15. Duyệt thuốc BHYT khi kết thúc khám bệnh";
            // 
            // c154
            // 
            this.c154.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c154.Location = new System.Drawing.Point(298, 1);
            this.c154.Name = "c154";
            this.c154.Size = new System.Drawing.Size(190, 21);
            this.c154.TabIndex = 121;
            this.c154.Text = "C18. Số phiếu xuất tăng tự động ";
            // 
            // c151
            // 
            this.c151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c151.Location = new System.Drawing.Point(87, 304);
            this.c151.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.c151.Name = "c151";
            this.c151.Size = new System.Drawing.Size(36, 21);
            this.c151.TabIndex = 184;
            this.c151.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 302);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(61, 17);
            this.label48.TabIndex = 183;
            this.label48.Text = "Số bản in :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(8, 285);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(73, 13);
            this.label47.TabIndex = 181;
            this.label47.Text = "Số tài khoản :";
            // 
            // c149
            // 
            this.c149.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c149.Location = new System.Drawing.Point(298, 21);
            this.c149.Name = "c149";
            this.c149.Size = new System.Drawing.Size(197, 21);
            this.c149.TabIndex = 180;
            this.c149.Text = "C19. Nhập tỷ lệ giảm giá ";
            this.c149.CheckedChanged += new System.EventHandler(this.c149_CheckedChanged);
            // 
            // c148
            // 
            this.c148.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c148.Location = new System.Drawing.Point(299, 172);
            this.c148.Name = "c148";
            this.c148.Size = new System.Drawing.Size(215, 21);
            this.c148.TabIndex = 179;
            this.c148.Text = "C23. Giá bán khai báo theo danh mục";
            this.c148.CheckedChanged += new System.EventHandler(this.c148_CheckedChanged);
            // 
            // c147
            // 
            this.c147.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c147.Location = new System.Drawing.Point(7, 247);
            this.c147.Name = "c147";
            this.c147.Size = new System.Drawing.Size(216, 21);
            this.c147.TabIndex = 178;
            this.c147.Text = "C14. In ngày y lệnh trong phiếu lĩnh";
            // 
            // c146
            // 
            this.c146.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c146.Location = new System.Drawing.Point(7, 230);
            this.c146.Name = "c146";
            this.c146.Size = new System.Drawing.Size(228, 20);
            this.c146.TabIndex = 177;
            this.c146.Text = "C13. Tính công khám trong phòng lưu";
            // 
            // c145
            // 
            this.c145.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c145.Location = new System.Drawing.Point(7, 213);
            this.c145.Name = "c145";
            this.c145.Size = new System.Drawing.Size(252, 20);
            this.c145.TabIndex = 176;
            this.c145.Text = "C12. In chi phí khám bệnh lấy thuốc tủ trực";
            // 
            // c144
            // 
            this.c144.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c144.Location = new System.Drawing.Point(7, 193);
            this.c144.Name = "c144";
            this.c144.Size = new System.Drawing.Size(266, 21);
            this.c144.TabIndex = 175;
            this.c144.Text = "C11. In phiếu xuất / bù theo cơ số tủ trực";
            // 
            // c143
            // 
            this.c143.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c143.Location = new System.Drawing.Point(7, 176);
            this.c143.Name = "c143";
            this.c143.Size = new System.Drawing.Size(216, 21);
            this.c143.TabIndex = 174;
            this.c143.Text = "C10. Giá bán nội trú <> ngoại trú";
            // 
            // c142
            // 
            this.c142.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c142.Location = new System.Drawing.Point(7, 159);
            this.c142.Name = "c142";
            this.c142.Size = new System.Drawing.Size(312, 21);
            this.c142.TabIndex = 173;
            this.c142.Text = "C9. Chọn đối tượng theo mặt hàng trong dMục hàng hóa";
            // 
            // c141
            // 
            this.c141.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c141.Location = new System.Drawing.Point(257, 141);
            this.c141.Name = "c141";
            this.c141.Size = new System.Drawing.Size(36, 21);
            this.c141.TabIndex = 171;
            this.c141.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(3, 141);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(344, 17);
            this.label50.TabIndex = 172;
            this.label50.Text = "C8. Số chương trình kích hoạt tối đa trên mỗi máy là :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c140
            // 
            this.c140.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c140.Location = new System.Drawing.Point(7, 118);
            this.c140.Name = "c140";
            this.c140.Size = new System.Drawing.Size(239, 21);
            this.c140.TabIndex = 143;
            this.c140.Text = "C7. Nhập chiết khấu trong phiếu nhập";
            // 
            // c138
            // 
            this.c138.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c138.Location = new System.Drawing.Point(7, 99);
            this.c138.Name = "c138";
            this.c138.Size = new System.Drawing.Size(239, 21);
            this.c138.TabIndex = 142;
            this.c138.Text = "C6. In phiếu nhiều ngày (chọn ngày+phiếu)";
            // 
            // c136
            // 
            this.c136.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c136.Location = new System.Drawing.Point(7, 82);
            this.c136.Name = "c136";
            this.c136.Size = new System.Drawing.Size(252, 21);
            this.c136.TabIndex = 141;
            this.c136.Text = "C5. Kiểm tra tồn kho trước khi duyệt (-----)";
            // 
            // c135
            // 
            this.c135.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c135.Location = new System.Drawing.Point(152, 60);
            this.c135.Name = "c135";
            this.c135.Size = new System.Drawing.Size(141, 21);
            this.c135.TabIndex = 139;
            this.c135.SelectedIndexChanged += new System.EventHandler(this.c135_SelectedIndexChanged);
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(4, 57);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(172, 23);
            this.label46.TabIndex = 140;
            this.label46.Text = "C4. Theo dõi tồn kho tối thiểu :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c131
            // 
            this.c131.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c131.Location = new System.Drawing.Point(7, 40);
            this.c131.Name = "c131";
            this.c131.Size = new System.Drawing.Size(228, 21);
            this.c131.TabIndex = 128;
            this.c131.Text = "C3. Cho phép chỉnh sửa khi duyệt đơn thuốc";
            // 
            // c130
            // 
            this.c130.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c130.Location = new System.Drawing.Point(7, 22);
            this.c130.Name = "c130";
            this.c130.Size = new System.Drawing.Size(189, 21);
            this.c130.TabIndex = 127;
            this.c130.Text = "C2. Số phiếu đánh theo năm";
            // 
            // c129
            // 
            this.c129.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c129.Location = new System.Drawing.Point(7, 6);
            this.c129.Name = "c129";
            this.c129.Size = new System.Drawing.Size(189, 21);
            this.c129.TabIndex = 126;
            this.c129.Text = "C1. Chọn loại phiếu khi xuất kho";
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
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(298, 191);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 10;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(225, 150);
            this.dataGrid3.TabIndex = 197;
            // 
            // c153
            // 
            this.c153.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c153.Location = new System.Drawing.Point(7, 326);
            this.c153.Name = "c153";
            this.c153.Size = new System.Drawing.Size(298, 21);
            this.c153.TabIndex = 185;
            this.c153.Text = "C16. Tự động tính lại tồn kho khi chuyển sang tháng mới";
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(509, 209);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(169, 17);
            this.label55.TabIndex = 209;
            this.label55.Text = "C41. Số lần in phiếu lĩnh tối đa";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.c603);
            this.tabPage3.Controls.Add(this.label58);
            this.tabPage3.Controls.Add(this.c217);
            this.tabPage3.Controls.Add(this.c216);
            this.tabPage3.Controls.Add(this.label57);
            this.tabPage3.Controls.Add(this.dataGrid2);
            this.tabPage3.Controls.Add(this.c1014);
            this.tabPage3.Controls.Add(this.c1012);
            this.tabPage3.Controls.Add(this.c1005);
            this.tabPage3.Controls.Add(this.c1004);
            this.tabPage3.Controls.Add(this.c1003);
            this.tabPage3.Controls.Add(this.c1002);
            this.tabPage3.Controls.Add(this.c1001);
            this.tabPage3.Controls.Add(this.c178);
            this.tabPage3.Controls.Add(this.ma13);
            this.tabPage3.Controls.Add(this.c176);
            this.tabPage3.Controls.Add(this.c49);
            this.tabPage3.Controls.Add(this.c175);
            this.tabPage3.Controls.Add(this.label54);
            this.tabPage3.Controls.Add(this.c174);
            this.tabPage3.Controls.Add(this.c172);
            this.tabPage3.Controls.Add(this.c127);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.c121);
            this.tabPage3.Controls.Add(this.c120);
            this.tabPage3.Controls.Add(this.label41);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Controls.Add(this.c56);
            this.tabPage3.Controls.Add(this.c47);
            this.tabPage3.Controls.Add(this.c112);
            this.tabPage3.Controls.Add(this.label40);
            this.tabPage3.Controls.Add(this.c84);
            this.tabPage3.Controls.Add(this.c83);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.c79);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.c57);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.c58);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.label27);
            this.tabPage3.Controls.Add(this.c59);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.ma16);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.c50);
            this.tabPage3.Controls.Add(this.c52);
            this.tabPage3.Controls.Add(this.c51);
            this.tabPage3.Controls.Add(this.c53);
            this.tabPage3.Controls.Add(this.dataGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(795, 386);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "4";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // c603
            // 
            this.c603.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c603.Location = new System.Drawing.Point(15, 364);
            this.c603.Name = "c603";
            this.c603.Size = new System.Drawing.Size(393, 17);
            this.c603.TabIndex = 230;
            this.c603.Text = "D10. Đối tương BHYT phải qua viện phí mới hiện danh sách chờ phát thuốc";
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(408, 173);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 23);
            this.label58.TabIndex = 229;
            this.label58.Text = "Vị trí";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c217
            // 
            this.c217.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c217.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c217.Location = new System.Drawing.Point(440, 173);
            this.c217.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c217.Name = "c217";
            this.c217.Size = new System.Drawing.Size(39, 21);
            this.c217.TabIndex = 228;
            this.c217.Text = "16,5";
            this.c217.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c216
            // 
            this.c216.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c216.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c216.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c216.Location = new System.Drawing.Point(284, 173);
            this.c216.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c216.Name = "c216";
            this.c216.Size = new System.Drawing.Size(104, 21);
            this.c216.TabIndex = 227;
            this.c216.Text = "01003";
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(187, 174);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(96, 17);
            this.label57.TabIndex = 226;
            this.label57.Text = "Mã nơi ĐKKB:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid2.CaptionText = "Thứ tự dự trù mua";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(560, 219);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(220, 144);
            this.dataGrid2.TabIndex = 132;
            // 
            // c1014
            // 
            this.c1014.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1014.Location = new System.Drawing.Point(307, 329);
            this.c1014.Name = "c1014";
            this.c1014.Size = new System.Drawing.Size(264, 21);
            this.c1014.TabIndex = 225;
            this.c1014.Tag = "tab4";
            this.c1014.Text = "D8.2. Hoặc tính từ ngày tạo số liệu";
            this.c1014.CheckedChanged += new System.EventHandler(this.c1014_CheckedChanged);
            // 
            // c1012
            // 
            this.c1012.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1012.Location = new System.Drawing.Point(307, 309);
            this.c1012.Name = "c1012";
            this.c1012.Size = new System.Drawing.Size(239, 21);
            this.c1012.TabIndex = 224;
            this.c1012.Tag = "tab4, cot 2";
            this.c1012.Text = "D7.1. Hoặc tính từ ngày tạo số liệu tháng 01";
            this.c1012.CheckedChanged += new System.EventHandler(this.c1012_CheckedChanged);
            // 
            // c1005
            // 
            this.c1005.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1005.Location = new System.Drawing.Point(15, 345);
            this.c1005.Name = "c1005";
            this.c1005.Size = new System.Drawing.Size(328, 21);
            this.c1005.TabIndex = 221;
            this.c1005.Text = "D9. Người duyệt mới được phép thu hồi";
            // 
            // c1004
            // 
            this.c1004.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1004.Location = new System.Drawing.Point(15, 328);
            this.c1004.Name = "c1004";
            this.c1004.Size = new System.Drawing.Size(328, 21);
            this.c1004.TabIndex = 220;
            this.c1004.Text = "D8. Số phiếu mẫu 38 tăng theo tháng, tính từ ngày 01";
            this.c1004.CheckedChanged += new System.EventHandler(this.c1004_CheckedChanged);
            // 
            // c1003
            // 
            this.c1003.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1003.Location = new System.Drawing.Point(15, 310);
            this.c1003.Name = "c1003";
            this.c1003.Size = new System.Drawing.Size(328, 21);
            this.c1003.TabIndex = 219;
            this.c1003.Text = "D7. Số phiếu mẫu 38 tăng theo năm, tính từ ngày 01/01.";
            this.c1003.CheckedChanged += new System.EventHandler(this.c1003_CheckedChanged);
            // 
            // c1002
            // 
            this.c1002.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1002.Location = new System.Drawing.Point(15, 289);
            this.c1002.Name = "c1002";
            this.c1002.Size = new System.Drawing.Size(328, 21);
            this.c1002.TabIndex = 218;
            this.c1002.Text = "D6. Xuất khác cho phép chọn đợt để xuất";
            // 
            // c1001
            // 
            this.c1001.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1001.Location = new System.Drawing.Point(15, 269);
            this.c1001.Name = "c1001";
            this.c1001.Size = new System.Drawing.Size(328, 21);
            this.c1001.TabIndex = 217;
            this.c1001.Text = "D5. Khi dự trù, xuất không kiểm tra số lượng xuất tháng sau";
            // 
            // c178
            // 
            this.c178.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c178.Location = new System.Drawing.Point(15, 250);
            this.c178.Name = "c178";
            this.c178.Size = new System.Drawing.Size(328, 21);
            this.c178.TabIndex = 216;
            this.c178.Text = "D4. Chi trả công nợ nhà cung cấp nhiều đợt trên một hóa đơn";
            // 
            // c176
            // 
            this.c176.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c176.Location = new System.Drawing.Point(15, 231);
            this.c176.Name = "c176";
            this.c176.Size = new System.Drawing.Size(373, 21);
            this.c176.TabIndex = 210;
            this.c176.Text = "D3. Khai báo BHYT chi trả trong danh mục chỉ có Admin mới chỉnh sửa";
            // 
            // c175
            // 
            this.c175.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c175.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c175.Location = new System.Drawing.Point(575, 32);
            this.c175.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c175.Name = "c175";
            this.c175.Size = new System.Drawing.Size(89, 21);
            this.c175.TabIndex = 54;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(536, 30);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(39, 23);
            this.label54.TabIndex = 209;
            this.label54.Text = "95 % :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c174
            // 
            this.c174.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c174.Location = new System.Drawing.Point(15, 211);
            this.c174.Name = "c174";
            this.c174.Size = new System.Drawing.Size(328, 21);
            this.c174.TabIndex = 208;
            this.c174.Text = "D2. Xuất bán sang viện phí thu tiền";
            // 
            // c172
            // 
            this.c172.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c172.Location = new System.Drawing.Point(15, 192);
            this.c172.Name = "c172";
            this.c172.Size = new System.Drawing.Size(328, 20);
            this.c172.TabIndex = 207;
            this.c172.Text = "D1. BHYT cùng chi trả đóng tiền mới hiện danh sách phát thuốc";
            // 
            // c127
            // 
            this.c127.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c127.Location = new System.Drawing.Point(169, 80);
            this.c127.Name = "c127";
            this.c127.Size = new System.Drawing.Size(383, 21);
            this.c127.TabIndex = 138;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(179, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 17);
            this.label24.TabIndex = 93;
            this.label24.Text = "Thư mục báo cáo :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(187, 154);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(96, 17);
            this.label43.TabIndex = 137;
            this.label43.Text = "CPVC :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(408, 151);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 23);
            this.label42.TabIndex = 136;
            this.label42.Text = "Vị trí";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c121
            // 
            this.c121.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c121.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c121.Location = new System.Drawing.Point(440, 151);
            this.c121.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c121.Name = "c121";
            this.c121.Size = new System.Drawing.Size(39, 21);
            this.c121.TabIndex = 135;
            this.c121.Text = "5,2";
            this.c121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c121.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c120
            // 
            this.c120.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c120.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c120.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c120.Location = new System.Drawing.Point(284, 151);
            this.c120.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c120.Name = "c120";
            this.c120.Size = new System.Drawing.Size(104, 21);
            this.c120.TabIndex = 134;
            this.c120.Text = "SS,TT,RR";
            this.c120.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(408, 128);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(32, 23);
            this.label41.TabIndex = 133;
            this.label41.Text = "Vị trí";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c56
            // 
            this.c56.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c56.Location = new System.Drawing.Point(284, 103);
            this.c56.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c56.Name = "c56";
            this.c56.Size = new System.Drawing.Size(104, 21);
            this.c56.TabIndex = 94;
            this.c56.Text = "report";
            // 
            // c47
            // 
            this.c47.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c47.Location = new System.Drawing.Point(112, 80);
            this.c47.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c47.Name = "c47";
            this.c47.Size = new System.Drawing.Size(56, 21);
            this.c47.TabIndex = 92;
            this.c47.Text = "3000";
            this.c47.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c112
            // 
            this.c112.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c112.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c112.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c112.Location = new System.Drawing.Point(440, 103);
            this.c112.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c112.Name = "c112";
            this.c112.Size = new System.Drawing.Size(112, 21);
            this.c112.TabIndex = 102;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(384, 106);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 16);
            this.label40.TabIndex = 101;
            this.label40.Text = "Domain :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c84
            // 
            this.c84.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c84.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c84.Location = new System.Drawing.Point(440, 127);
            this.c84.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c84.Name = "c84";
            this.c84.Size = new System.Drawing.Size(39, 21);
            this.c84.TabIndex = 100;
            this.c84.Text = "3,2";
            this.c84.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c84.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c83
            // 
            this.c83.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c83.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.c83.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c83.Location = new System.Drawing.Point(284, 127);
            this.c83.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c83.Name = "c83";
            this.c83.Size = new System.Drawing.Size(104, 21);
            this.c83.TabIndex = 99;
            this.c83.Text = "50";
            this.c83.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(187, 128);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 17);
            this.label33.TabIndex = 98;
            this.label33.Text = "Số thẻ trong tỉnh :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(56, 147);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 17);
            this.label31.TabIndex = 95;
            this.label31.Text = "Giá bán :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c79
            // 
            this.c79.Location = new System.Drawing.Point(112, 147);
            this.c79.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.c79.Name = "c79";
            this.c79.Size = new System.Drawing.Size(32, 20);
            this.c79.TabIndex = 96;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(150, 147);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 17);
            this.label32.TabIndex = 97;
            this.label32.Text = "số lẻ";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(-8, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 17);
            this.label18.TabIndex = 91;
            this.label18.Text = "Công khám bảo hiểm :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.CaptionText = "Thứ tự phiếu lĩnh";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(560, 82);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(220, 142);
            this.dataGrid1.TabIndex = 109;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.c5011);
            this.tabPage5.Controls.Add(this.c1017);
            this.tabPage5.Controls.Add(this.dataGrid4);
            this.tabPage5.Controls.Add(this.c1032);
            this.tabPage5.Controls.Add(this.c1031);
            this.tabPage5.Controls.Add(this.c1016);
            this.tabPage5.Controls.Add(this.c1015);
            this.tabPage5.Controls.Add(this.c602);
            this.tabPage5.Controls.Add(this.c601);
            this.tabPage5.Controls.Add(this.c1011);
            this.tabPage5.Controls.Add(this.c1010);
            this.tabPage5.Controls.Add(this.c1009);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(795, 386);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // c1017
            // 
            this.c1017.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1017.Location = new System.Drawing.Point(8, 167);
            this.c1017.Name = "c1017";
            this.c1017.Size = new System.Drawing.Size(337, 20);
            this.c1017.TabIndex = 227;
            this.c1017.Text = "E10.Tỷ lệ giá bán lẻ vật tư dựa vào đơn giá mua (C24.1)";
            this.c1017.CheckedChanged += new System.EventHandler(this.c1017_CheckedChanged);
            // 
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(7, 168);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.ReadOnly = true;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(225, 150);
            this.dataGrid4.TabIndex = 228;
            // 
            // c1032
            // 
            this.c1032.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1032.Location = new System.Drawing.Point(8, 149);
            this.c1032.Name = "c1032";
            this.c1032.Size = new System.Drawing.Size(387, 20);
            this.c1032.TabIndex = 225;
            this.c1032.Text = "E9. Chỉ Admin mới được phép hủy phiếu nhập kho";
            // 
            // c1031
            // 
            this.c1031.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1031.Location = new System.Drawing.Point(8, 132);
            this.c1031.Name = "c1031";
            this.c1031.Size = new System.Drawing.Size(387, 20);
            this.c1031.TabIndex = 224;
            this.c1031.Text = "E8. không cho duyệt toa khi Bệnh được xử trí hẹn";
            // 
            // c1016
            // 
            this.c1016.Checked = true;
            this.c1016.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1016.Location = new System.Drawing.Point(8, 115);
            this.c1016.Name = "c1016";
            this.c1016.Size = new System.Drawing.Size(281, 19);
            this.c1016.TabIndex = 223;
            this.c1016.Text = "E7 . Cho phép lọc phiếu bù trong lúc duyệt (A39)";
            // 
            // c1015
            // 
            this.c1015.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1015.Location = new System.Drawing.Point(8, 97);
            this.c1015.Name = "c1015";
            this.c1015.Size = new System.Drawing.Size(297, 21);
            this.c1015.TabIndex = 222;
            this.c1015.Text = "E6. Xuất bán dùng mã vạch (xuất đúng theo STTT)";
            // 
            // c602
            // 
            this.c602.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c602.Location = new System.Drawing.Point(8, 80);
            this.c602.Name = "c602";
            this.c602.Size = new System.Drawing.Size(261, 21);
            this.c602.TabIndex = 221;
            this.c602.Text = "E5. Xuất bán cho phép sửa số lượng trên lưới";
            // 
            // c601
            // 
            this.c601.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c601.Location = new System.Drawing.Point(8, 61);
            this.c601.Name = "c601";
            this.c601.Size = new System.Drawing.Size(281, 21);
            this.c601.TabIndex = 220;
            this.c601.Text = "E4. Cho phép user thường hủy toa xuất bán";
            // 
            // c1011
            // 
            this.c1011.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1011.Location = new System.Drawing.Point(8, 41);
            this.c1011.Name = "c1011";
            this.c1011.Size = new System.Drawing.Size(387, 20);
            this.c1011.TabIndex = 5;
            this.c1011.Text = "E3. Dược bệnh viện: chỉ tính trên số lượng xuất";
            // 
            // c1010
            // 
            this.c1010.Checked = true;
            this.c1010.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1010.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1010.Location = new System.Drawing.Point(8, 21);
            this.c1010.Name = "c1010";
            this.c1010.Size = new System.Drawing.Size(387, 20);
            this.c1010.TabIndex = 4;
            this.c1010.Text = "E2. Nhập kho (số tiền) thuế VAT nhập chung cho cả hóa đơn";
            // 
            // c1009
            // 
            this.c1009.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1009.Location = new System.Drawing.Point(8, 3);
            this.c1009.Name = "c1009";
            this.c1009.Size = new System.Drawing.Size(411, 20);
            this.c1009.TabIndex = 3;
            this.c1009.Text = "E1. In chi phí (mẫu 38) không in chênh lệch tiền thuốc (do thu trước khi duyệt)";
            // 
            // b167
            // 
            this.b167.Location = new System.Drawing.Point(531, 440);
            this.b167.Name = "b167";
            this.b167.Size = new System.Drawing.Size(75, 23);
            this.b167.TabIndex = 202;
            this.b167.Text = "Chọn chữ ký";
            this.b167.UseVisualStyleBackColor = true;
            this.b167.Visible = false;
            this.b167.Click += new System.EventHandler(this.b167_Click);
            // 
            // p167
            // 
            this.p167.Location = new System.Drawing.Point(640, 424);
            this.p167.Name = "p167";
            this.p167.Size = new System.Drawing.Size(142, 50);
            this.p167.TabIndex = 200;
            this.p167.TabStop = false;
            this.p167.Visible = false;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(505, 424);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(151, 17);
            this.label53.TabIndex = 201;
            this.label53.Text = "Chữ ký phụ trách bộ phận ";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label53.Visible = false;
            // 
            // c167
            // 
            this.c167.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c167.Location = new System.Drawing.Point(508, 404);
            this.c167.Name = "c167";
            this.c167.Size = new System.Drawing.Size(318, 21);
            this.c167.TabIndex = 199;
            this.c167.Text = "Chữ ký trưởng khoa && trưởng khoa điều trị trong phiếu";
            this.c167.Visible = false;
            this.c167.CheckedChanged += new System.EventHandler(this.c167_CheckedChanged);
            // 
            // c77
            // 
            this.c77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c77.Location = new System.Drawing.Point(56, 442);
            this.c77.Name = "c77";
            this.c77.Size = new System.Drawing.Size(144, 21);
            this.c77.TabIndex = 95;
            this.c77.Text = "Báo cáo chi tiết theo đợt";
            this.c77.Visible = false;
            this.c77.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c87
            // 
            this.c87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c87.Location = new System.Drawing.Point(56, 424);
            this.c87.Name = "c87";
            this.c87.Size = new System.Drawing.Size(184, 21);
            this.c87.TabIndex = 102;
            this.c87.Text = "Đơn thuốc bảo hiểm lấy số tiền";
            this.c87.Visible = false;
            this.c87.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c02_KeyDown);
            // 
            // c5011
            // 
            this.c5011.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c5011.Location = new System.Drawing.Point(8, 324);
            this.c5011.Name = "c5011";
            this.c5011.Size = new System.Drawing.Size(337, 20);
            this.c5011.TabIndex = 229;
            this.c5011.Text = "E11. User thường không được phép xuất excel";
            // 
            // frmCauhinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 469);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.b167);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.p167);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.c167);
            this.Controls.Add(this.c77);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.c48);
            this.Controls.Add(this.c87);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCauhinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình thông số hệ thống";
            this.Load += new System.EventHandler(this.frmCauhinh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCauhinh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.c10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c59)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c99)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c177)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c164)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c151)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c141)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p167)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCauhinh_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            //c2000.Checked = d.bDanhmuc_luu_server;
            load_tooltip();
            string sql = "select * from " + m.user + ".d_thongso where id>1000  ";
            DataSet lds = d.get_data(sql);
            if (lds.Tables[0].Rows.Count <= 0)
            {
                sql = "alter table " + m.user + ".d_thongso ALTER id TYPE numeric(7)";
                d.execute_data(sql);
            }
            if (d.get_data("select * from " + user + ".d_thongso where nhom=" + i_nhom + " and id=175").Tables[0].Rows.Count == 0)
            {
                d.upd_thongso(i_nhom, 175, "95", "");
                d.execute_data("insert into "+user+".thongso(id,loai,ten) values (-50,'','')");
            }
			d.ins_thongso(i_nhom,179);
            if (d.get_data("select * from "+user+".d_thongso where nhom="+i_nhom+" and id=160 and ten='1'").Tables[0].Rows.Count==0)
                d.upd_thongso(i_nhom, 159, "nhap t-xuat t","1");
            if (d.get_data("select * from " + user + ".d_thongso where nhom=" + i_nhom + " and id=170").Tables[0].Rows.Count == 0)
                d.upd_thongso(i_nhom, 170, "thuhoi tu truc", "1");
            c132.DisplayMember = "TEN";
            c132.ValueMember = "ID";
            c132.DataSource = d.get_data("select * from "+user+".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];

            dtnin = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];
            c161.DataSource = dtnin;
            c161.DisplayMember = "TEN";
            c161.ValueMember = "ID";

            c133.DisplayMember = "TEN";
            c133.ValueMember = "ID";
            c133.DataSource = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];

            c134.DisplayMember = "TEN";
            c134.ValueMember = "ID";
            c134.DataSource = d.get_data("select * from " + user + ".d_nhomin where nhom=" + i_nhom + " order by stt").Tables[0];

            c135.DisplayMember = "TEN";
            c135.ValueMember = "ID";
            c135.DataSource = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom + " order by stt").Tables[0];

            dtkho = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom + " order by stt").Tables[0];
            c173.DataSource = dtkho;
            c173.DisplayMember = "TEN";
            c173.ValueMember = "ID";
            

			c128.DisplayMember="TEN";
			c128.ValueMember="MA";
			c128.DataSource=d.get_data("select * from "+user+".v_nhomvp order by stt").Tables[0];
			c127.DisplayMember="TEN";
			c127.ValueMember="ID";
            c127.DataSource = d.get_data("select * from " + user + ".v_giavp order by stt").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_thongso.xml");
			dstt.ReadXml("..\\..\\..\\xml\\d_sttphieulinh.xml");
			dsmua.ReadXml("..\\..\\..\\xml\\d_sttmua.xml");
			dataGrid1.DataSource=dstt.Tables[0];
			AddGridTableStyle();
			dataGrid1.ReadOnly=false;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 

			dataGrid2.DataSource=dsmua.Tables[0];
			AddGridTableStyle2();
			dataGrid2.ReadOnly=false;
			CurrencyManager cm2 = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember];  
			DataView dv2 = (DataView) cm2.List; 
			dv2.AllowNew = false;

            dstyle = m.get_data("select * from " + user + ".dmtyleban where nhomkho=" + i_nhom + " and vattuyte=0 order by tu,den");
            dataGrid3.DataSource = dstyle.Tables[0];
            AddGridTableStyle3();
            dataGrid3.ReadOnly = false;
            CurrencyManager cm3 = (CurrencyManager)BindingContext[dataGrid3.DataSource, dataGrid3.DataMember];
            DataView dv3 = (DataView)cm3.List;
            dv3.AllowNew = true;

            dstylevattu = m.get_data("select * from " + user + ".dmtyleban where nhomkho=" + i_nhom + " and vattuyte=1 order by tu,den");
            dataGrid4.DataSource = dstylevattu.Tables[0];
            AddGridTableStyle4();
            dataGrid4.ReadOnly = false;
            CurrencyManager cm4 = (CurrencyManager)BindingContext[dataGrid4.DataSource, dataGrid4.DataMember];
            DataView dv4 = (DataView)cm4.List;
            dv4.AllowNew = true; 

            i_c135 = d.iKhotoithieu(i_nhom);
            foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where nhom=" + i_nhom + " order by id").Tables[0].Rows)
			{
				switch (int.Parse(r["id"].ToString()))
				{
					case 2: c02.Checked=(d.Thongso("c02")=="1")?true:false;
						break;
					case 4: c04.Checked=r["ten"].ToString().Trim()=="1";
						break;
					case 5: c05.Checked=(d.Thongso("c05")=="1")?true:false;
						break;
					case 7: c07.Text=r["ten"].ToString();
						break;
					case 8: c08.Text=r["ten"].ToString();
						break;
					case 9: c09.Text=r["ten"].ToString();
						break;
					case 10: c10.Value=decimal.Parse(d.Thongso("c10"));
						break;
					case 11: c11.Checked=(d.Thongso("c11")=="1")?true:false;
						break;
					case 12: c12.Checked=(d.Thongso("c12")=="1")?true:false;
						break;
					case 14: c14.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 15: c15.Text=r["ten"].ToString();
						break;
					case 16: c16.Text=r["ten"].ToString();
						break;
					case 17: c17.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 18: c18.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 19: c19.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 20: c20.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 21: c21.Checked=(d.Thongso("c21")=="1")?true:false;
						break;
					case 22: c22.Value=decimal.Parse(d.Thongso("c22"));
						break;
					case 23: c23.Checked=(d.Thongso("c23")=="1")?true:false;
						break;
					case 24: c24.Checked=(d.Thongso("c24")=="1")?true:false;
						break;
					case 25: c25.Checked=(d.Thongso("c25")=="1")?true:false;
						break;
					case 26: c26.Checked=(d.Thongso("c26")=="1")?true:false;
						break;
					case 27: c27.Checked=(d.Thongso("c27")=="1")?true:false;
						break;
					case 28: c28.Checked=(d.Thongso("c28")=="1")?true:false;
						break;
					case 29: c29.Checked=(d.Thongso("c29")=="1")?true:false;
						break;
					case 30: c30.Checked=(d.Thongso("c30")=="1")?true:false;
						break;
					case 31: c31.Checked=(d.Thongso("c31")=="1")?true:false;
						break;
					case 32: c32.Text=r["ten"].ToString();
						break;
					case 33: c33.Checked=(r["ten"].ToString().Trim()=="1")?true:false;
						break;
					case 34: c34.Checked=(d.Thongso("c34")=="1")?true:false;
						break;
					case 35: c35.Checked=(d.Thongso("c35")=="1")?true:false;
						break;
					case 36: c36.Checked=(d.Thongso("c36")=="1")?true:false;
						break;
					case 37: c37.Checked=(d.Thongso("c37")=="1")?true:false;
						break;
					case 38: c38.Checked=(d.Thongso("c38")=="1")?true:false;
						break;
					case 39: c39.Checked=(d.Thongso("c39")=="1")?true:false;
						break;
					case 40: c40.Checked=(d.Thongso("c40")=="1")?true:false;
						break;
					case 41: c41.Checked=(d.Thongso("c41")=="1")?true:false;
						break;
					case 42: c42.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 43: c43.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 44: c44.Value=decimal.Parse(r["ten"].ToString());
						break;
					case 45: c45.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 46: c46.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 47: c47.Text=r["ten"].ToString();
						break;
					case 48: c48.Text=r["ten"].ToString();
						break;
					case 49: c49.Text=r["ten"].ToString();
						break;
					case 50: c50.Text=r["ten"].ToString();
						break;
					case 51: c51.Text=r["ten"].ToString();
						break;
					case 52: c52.Text=r["ten"].ToString();
						break;
					case 53: c53.Text=r["ten"].ToString();
						break;
					case 54: c54.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					//binh
					case 55: c55.Checked=(r["ten"].ToString().Trim()=="1");//thuoc noi ngoai: phan loai theo Hang SX
						break;
					case 56: c56.Text=r["ten"].ToString();//ten thu muc report
						break;
					case 57: c57.Text=r["ten"].ToString();//ten thu muc report
						break;
					case 58: c58.Text=r["ten"].ToString();//ten thu muc report
						break;
					case 59: c59.Text=r["ten"].ToString();//ten thu muc report
						break;
					case 60: c60.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 61: c61.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 62: c62.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 63: c63.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 64: c64.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 65: c65.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 66: c66.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 67: c67.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 68: c68.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 69: c69.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 70: c70.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 71: c71.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 72: c72.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 73: c73.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 74: c74.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 75: c75.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 76: c76.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 77: c77.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 78: c78.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 79: c79.Text=r["ten"].ToString();
						break;
					case 80: c80.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 81: c81.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 82: c82.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 83: c83.Text=r["ten"].ToString();
						break;
					case 84: c84.Text=r["ten"].ToString();
						break;
					case 85: c85.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 86: c86.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 87: c87.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 88: c88.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 89: c89.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 90: c90.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 91: c91.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 92: c92.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 93: c93.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 94: c94.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 95: c95.Checked=d.Thongso("c95")=="1";
						break;
					case 96: c96.Checked=d.Thongso("c96")=="1";
						break;
					case 97: c97.Checked=d.Thongso("c97")=="1";
						break;
					case 98: c98.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 99: c99.Value=decimal.Parse(r["ten"].ToString());
						break;
					case 100: c100.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 101: c101.Checked=d.Thongso("c101")=="1";
						break;
					case 102: c102.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 103: c103.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 104: c104.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 105: c105.Value=decimal.Parse(r["ten"].ToString());
						break;
					case 106: c106.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 107: c107.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 108: c108.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 109: c109.Value=decimal.Parse(r["ten"].ToString());
						break;
					case 110: c110.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 111: c111.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 112: c112.Text=r["ten"].ToString().Trim();
						break;
					case 113: c113.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 114: c114.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 115: c115.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 116: c116.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 117: c117.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 119: c119.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 120: c120.Text=r["ten"].ToString();
						break;
					case 121: c121.Text=r["ten"].ToString();
						break;
					case 122: c122.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 123: c123.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 124: c124.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 125: c125.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 126: c126.Checked=(r["ten"].ToString().Trim()=="1");
						break;
					case 127: c127.SelectedValue=r["ten"].ToString();
						break;
					case 128: c128.SelectedValue=r["ten"].ToString();
						break;
                    case 129: c129.Checked = (r["ten"].ToString().Trim() == "1");
                        break;
                    case 130: c130.Checked = (r["ten"].ToString().Trim() == "1");
                        break;
                    case 131: c131.Checked = (r["ten"].ToString().Trim() == "1");
                        break;
                    case 132: c132.SelectedValue = r["ten"].ToString();
                        break;
                    case 133: c133.SelectedValue = r["ten"].ToString();
                        break;
                    case 134: c134.SelectedValue = r["ten"].ToString();
                        break;
                    case 135: c135.SelectedValue = r["ten"].ToString();
                        break;
                    case 136: c136.Checked = r["ten"].ToString().Trim()=="1";
                        break;
                    case 137: c137.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 138: c138.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 139: c139.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 140: c140.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 141: c141.Value = decimal.Parse(r["ten"].ToString());
                        break;
                    case 142: c142.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 143: c143.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 144: c144.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 145: c145.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 146: c146.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 147: c147.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 148: c148.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 149: c149.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 150: c150.Text = r["ten"].ToString();
                        break;
                    case 151: c151.Value=Math.Max(1,decimal.Parse(r["ten"].ToString()));
                        break;
                    case 152: c152.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 153: c153.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 154: c154.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 155: c155.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 156: c156.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 157: c157.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 158: c158.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 159: c159.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 160: c160.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 161: s_161 = r["ten"].ToString().Trim();
                        break;
                    case 162: c162.Value = decimal.Parse(r["ten"].ToString());
                        break;
                    case 163: c163.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 164: c164.Value = decimal.Parse(r["ten"].ToString());
                        break;
                    case 165: c165.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 166: c166.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    /*case 167: c167.Checked = r["ten"].ToString().Trim() == "1";
                        try
                        {
                            image = new byte[0];
                            image = (byte[])(r["image"]);
                            memo = new MemoryStream(image);
                            map = new Bitmap(Image.FromStream(memo));
                            p167.Image = (Bitmap)map;
                            p167.Tag = image;
                        }
                        catch
                        {
                            p167.Tag = "0000.bmp";
                            fstr = new System.IO.FileStream(p167.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            map = new Bitmap(Image.FromStream(fstr));
                            p167.Image = (Bitmap)map;
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            p167.Tag = image;
                        }
                        break;*/
                    case 168: c168.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 169: c169.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 170: c170.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 171: c171.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 172: c172.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 173: s_173 = r["ten"].ToString();
                        break;
                    case 174: c174.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 175: c175.Text= r["ten"].ToString().Trim();
                        break;
                    case 176: c176.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 177: c177.Value = decimal.Parse(r["ten"].ToString());
                        break;
                    case 178: c178.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 179: c179.Checked = r["ten"].ToString().Trim() == "1";//Thuy 26.10.2012
                        break;
                    case 1001: c1001.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1002: c1002.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1003: c1003.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1004: c1004.Checked = r["ten"].ToString().Trim() == "1";                                            
                        break;
                    case 1005: c1005.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1006: c1006.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1007: c1007.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1008: c1008.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1009: c1009.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1010: c1010.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1011: c1011.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1012: c1012.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    
                    case 1014: c1014.Checked = r["ten"].ToString().Trim() == "1";
                        break;

                    case 1015: c1015.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 601: c601.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 602: c602.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 603: c603.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1016: c1016.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1031: c1031.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1032: c1032.Checked = r["ten"].ToString().Trim() == "1";
                        break;
                    case 1017: c1017.Checked = r["ten"].ToString().Trim() == "1";
                        break;

                    case 5011: c5011.Checked = (r["ten"].ToString().Trim() == "1");
                        break;
				}
			}
			if (c105.Value==0) c105.Value=7;
			c69.Enabled=c63.Checked;
			c78.Enabled=c43.Checked;
            b167.Enabled = c167.Checked;
            c132.Enabled = c66.Checked;
            c133.Enabled = c67.Checked;
            c134.Enabled = c68.Checked;
            c137.Enabled = c107.Checked;
            c139.Enabled = c107.Checked;
            c150.Enabled = c149.Checked;
            c152.Enabled = c108.Checked;
            c173.Enabled = c119.Checked;
            dataGrid3.Enabled = c165.Checked;
            dataGrid4.Enabled = c1017.Checked;
			if (c52.Text=="0") c52.Text=d.ma13_vitri.ToString();
			if (c53.Text=="0") c53.Text=d.ma16_vitri.ToString();
			c13.Checked=d.bKhoaso(i_nhom,s_mmyy);
			if (c13.Checked) c13.ForeColor=Color.Red;
			if (!c14.Enabled) c14.Checked=false;
            ma13.Text = d.get_data("select ten from " + user + ".thongso where id=49").Tables[0].Rows[0][0].ToString();
            ma16.Text = d.get_data("select ten from " + user + ".thongso where id=50").Tables[0].Rows[0][0].ToString();
            try
            {
                c216.Text = d.get_data("select ten from " + user + ".d_thongso where id=216").Tables[0].Rows[0][0].ToString();//gam 20/03/2012
                c217.Text = d.get_data("select ten from " + user + ".d_thongso where id=217").Tables[0].Rows[0][0].ToString();//gam 20/03/2012
            }
            catch { }
			kho.Text=d.Thongso("kho").Trim();
			hinh.Text=d.Thongso("hinh").Trim();
			butHinh.Enabled=hinh.Text.ToString()=="";
			if (c83.Text=="0") c83.Text="50";
			if (c84.Text=="0") c84.Text="3,2";
            for (int i = 0; i < c161.Items.Count; i++)
                if (s_161.IndexOf(dtnin.Rows[i]["id"].ToString().PadLeft(3,'0')) != -1) c161.SetItemCheckState(i, CheckState.Checked);
                else c161.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < c173.Items.Count; i++)
                if (s_173.IndexOf(dtkho.Rows[i]["id"].ToString().PadLeft(3,'0') + ",") != -1) c173.SetItemCheckState(i, CheckState.Checked);
                else c173.SetItemCheckState(i, CheckState.Unchecked);
            foreach (System.Windows.Forms.Control t in this.tab.Controls)
            {
                foreach (System.Windows.Forms.Control c in t.Controls)
                {
                    try
                    {
                        CheckBox chk = (CheckBox)c;
                        if (chk.Checked) chk.ForeColor = Color.Red;
                    }
                    catch { }
                }
            }
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
			//if (!c40.Checked) c24.Checked=true;
            /*
            int itable = d.tableid("", "d_thongso");
            foreach (DataRow r in d.get_data("select * from " + user + ".d_thongso where nhom=" + i_nhom + " order by id").Tables[0].Rows)
            {
                d.upd_eve_tables(itable, i_userid, "upd");
                d.upd_eve_upd_del(itable, i_userid, "upd", d.fields(user + ".d_thongso", "nhom=" + i_nhom + " and id=" + decimal.Parse(r["id"].ToString())));
            }
             * */
			dstt.WriteXml("..\\..\\..\\xml\\d_sttphieulinh.xml",XmlWriteMode.WriteSchema);
			dsmua.WriteXml("..\\..\\..\\xml\\d_sttmua.xml",XmlWriteMode.WriteSchema);
			m.upd_thongso(49,"ten",ma13.Text);
			m.upd_thongso(50,"ten",c49.Text);
            m.upd_thongso(-50, "ten", c175.Text);
			d.upd_thongso(i_nhom,4,"don gia",(c04.Checked)?"1":"0");
			d.upd_thongso(i_nhom,14,"gia ban",(c14.Checked)?"1":"0");
			d.upd_thongso(i_nhom,33,"du tru mua",(c33.Checked)?"1":"0");
			d.upd_thongso(i_nhom,42,"in phieu",(c42.Checked)?"1":"0");
			d.upd_thongso(i_nhom,43,"duyet",(c43.Checked)?"1":"0");
			d.upd_thongso(i_nhom,17,"nguon",(c17.Checked)?"1":"0");
			d.upd_thongso(i_nhom,18,"nhom cc",(c18.Checked)?"1":"0");
			d.upd_thongso(i_nhom,19,"date",(c19.Checked)?"1":"0");
			d.upd_thongso(i_nhom,20,"losx",(c20.Checked)?"1":"0");
			d.upd_thongso(i_nhom,44,"ngay in phieu",c44.Value.ToString());
			d.upd_thongso(i_nhom,45,"qui doi",(c45.Checked)?"1":"0");
			d.upd_thongso(i_nhom,46,"quyenso",(c46.Checked)?"1":"0");
			d.upd_thongso(i_nhom,54,"bu cstt",(c54.Checked)?"1":"0");
			d.upd_thongso(i_nhom,47,"cong kham",c47.Text.ToString());
			d.upd_thongso(i_nhom,48,"ma 13-ngtru",c48.Text.ToString());
			d.upd_thongso(i_nhom,49,"ma 16-ngtru",c49.Text.ToString());
			d.upd_thongso(i_nhom,50,"ma 13-sotien",c50.Text.ToString());
			d.upd_thongso(i_nhom,51,"ma 16-sotien",c51.Text.ToString());
			d.upd_thongso(i_nhom,52,"ma 16-vitri",c52.Text.ToString());
			d.upd_thongso(i_nhom,53,"ma 16-vitri",c53.Text.ToString());
			d.upd_thongso(i_nhom,60,"cstt->linh",(c60.Checked)?"1":"0");
			d.upd_thongso(i_nhom,61,"cstt->hao phi",(c61.Checked)?"1":"0");
			d.upd_thongso(i_nhom,62,"mabn->bhyt",(c62.Checked)?"1":"0");
			d.upd_thongso(i_nhom,63,"cap phat",(c63.Checked)?"1":"0");
			d.upd_thongso(i_nhom,64,"du tru cap",(c64.Checked)?"1":"0");
			d.upd_thongso(i_nhom,65,"don gia",(c65.Checked)?"1":"0");
			d.upd_thongso(i_nhom,66,"gay nghien",(c66.Checked)?"1":"0");
			d.upd_thongso(i_nhom,67,"htt",(c67.Checked)?"1":"0");
			d.upd_thongso(i_nhom,68,"doc AB",(c68.Checked)?"1":"0");
			if (c69.Enabled) d.upd_thongso(i_nhom,69,"cap phat tron(dt)",(c69.Checked)?"1":"0");
			if (c78.Enabled) d.upd_thongso(i_nhom,78,"sl thuc-yeu cau",(c78.Checked)?"1":"0");
			d.upd_thongso(i_nhom,70,"bhyt",(c70.Checked)?"1":"0");
			d.upd_thongso(i_nhom,71,"ngoai tru",(c71.Checked)?"1":"0");
			d.upd_thongso(i_nhom,72,"nhom in",(c72.Checked)?"1":"0");
			d.upd_thongso(i_nhom,73,"chuyen kho",(c73.Checked)?"1":"0");
			d.upd_thongso(i_nhom,74,"in ngang",(c74.Checked)?"1":"0");
			d.upd_thongso(i_nhom,75,"loc phieu duyet",(c75.Checked)?"1":"0");
			d.upd_thongso(i_nhom,76,"y lenh cach dung",(c76.Checked)?"1":"0");
			d.upd_thongso(i_nhom,77,"bao cao chi tiet",(c77.Checked)?"1":"0");
			d.upd_thongso(i_nhom,80,"kiem tra cap phat & thu hoi",(c80.Checked)?"1":"0");
			d.upd_thongso(i_nhom,81,"nhom phieu nhap/xuat",(c81.Checked)?"1":"0");
			d.upd_thongso(i_nhom,82,"cong kham BHYT",(c82.Checked)?"1":"0");
			d.upd_thongso(i_nhom,85,"thong bao BHYT",(c85.Checked)?"1":"0");
			d.upd_thongso(i_nhom,86,"chan doan BHYT",(c86.Checked)?"1":"0");
			d.upd_thongso(i_nhom,87,"so tien BHYT",(c87.Checked)?"1":"0");
			d.upd_thongso(i_nhom,88,"kinh phi su sung",(c88.Checked)?"1":"0");
			d.upd_thongso(i_nhom,89,"thu tu phieu nhap",(c89.Checked)?"1":"0");
			d.upd_thongso(i_nhom,90,"xuat ban theo nguoi nhap",(c90.Checked)?"1":"0");
			d.upd_thongso(i_nhom,91,"the kho so phieu",(c91.Checked)?"1":"0");
			d.upd_thongso(i_nhom,92,"tru co so",(c92.Checked)?"1":"0");
			d.upd_thongso(i_nhom,93,"hang/nuoc phieu nhap/xuat",(c93.Checked)?"1":"0");
			d.upd_thongso(i_nhom,94,"chan doan trong xuat ban",(c94.Checked)?"1":"0");
            d.upd_thongso(i_nhom,98,"don gia the kho",(c98.Checked)?"1":"0");
			d.upd_thongso(i_nhom,99,"ngay toa thuoc bhyt",c99.Value.ToString());
			d.upd_thongso(i_nhom,100,"chi tiet doi tuong->phieu linh",(c100.Checked)?"1":"0");
			d.upd_thongso(i_nhom,102,"in chi phi dieu tri tre em",(c102.Checked)?"1":"0");
			d.upd_thongso(i_nhom,103,"phieu xuat ban",(c103.Checked)?"1":"0");
			d.upd_thongso(i_nhom,104,"ma so & ten",(c104.Checked)?"1":"0");
            //
            d.upd_thongso(i_nhom, 601, "ma so & ten", (c601.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 602, "Ban sua tren luoi", (c602.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 603, "Phai thu tien truoc khi phat", (c603.Checked) ? "1" : "0");
            //
            d.execute_data("delete from " + user + ".d_thongso where id in (105,83,84,120,121)");
            foreach (DataRow r in d.get_data("select id from " + user + ".d_dmnhomkho order by id").Tables[0].Rows)
			{
				d.upd_thongso(int.Parse(r["id"].ToString()),105,"ngay kiem ke",c105.Value.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),83,"the trong tinh",c83.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),84,"vitri the tinh",c84.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),120,"tu nguyen",c120.Text.ToString());
				d.upd_thongso(int.Parse(r["id"].ToString()),121,"vitri the tinh",c121.Text.ToString());
			}
			d.upd_thongso(i_nhom,106,"bb bac sy xuat ban",(c106.Checked)?"1":"0");
			d.upd_thongso(i_nhom,107,"so phieu tu dong",(c107.Checked)?"1":"0");
			d.upd_thongso(i_nhom,108,"bien lai nha thuoc",(c108.Checked)?"1":"0");
			d.upd_thongso(i_nhom,109,"so lan in",c109.Value.ToString());
			d.upd_thongso(i_nhom,110,"loc ky tu trai->phai",(c110.Checked)?"1":"0");
			d.upd_thongso(i_nhom,111,"tin nhan",(c111.Checked)?"1":"0");
			d.upd_thongso(i_nhom,112,"domain",c112.Text);
			d.upd_thongso(i_nhom,113,"the kho cong don",(c113.Checked)?"1":"0");
			d.upd_thongso(i_nhom,114,"mau so c14",(c114.Checked)?"1":"0");
			d.upd_thongso(i_nhom,115,"ngoai tru phieu linh",(c115.Checked)?"1":"0");
			d.upd_thongso(i_nhom,116,"nha cung cap",(c116.Checked)?"1":"0");
			d.upd_thongso(i_nhom,117,"bhyt theo nhom",(c117.Checked)?"1":"0");
			d.upd_thongso(i_nhom,119,"tru ao",(c119.Checked)?"1":"0");
			d.upd_thongso(i_nhom,122,"cap nhat ton kho bhyt",(c122.Checked)?"1":"0");
			d.upd_thongso(i_nhom,123,"noi ngoai - nuoc",(c123.Checked)?"1":"0");
			d.upd_thongso(i_nhom,124,"cach dung xuat ban",(c124.Checked)?"1":"0");
			d.upd_thongso(i_nhom,125,"bcstt tron so",(c125.Checked)?"1":"0");
			d.upd_thongso(i_nhom,126,"gia ban theo dot",(c126.Checked)?"1":"0");
			d.upd_thongso(i_nhom,127,"id cong kham",(c127.SelectedIndex!=-1)?c127.SelectedValue.ToString():"0");
			d.upd_thongso(i_nhom,128,"nhom bhyt in rieng",(c128.SelectedIndex!=-1)?c128.SelectedValue.ToString():"0");
            d.upd_thongso(i_nhom, 129, "chon loai phieu->p.xuat", (c129.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 130, "danh so phieu theo nam", (c130.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 131, "chi sua don thuoc", (c131.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 132, "doc", (c132.SelectedIndex != -1 && c66.Checked) ? c132.SelectedValue.ToString() : "0");
            d.upd_thongso(i_nhom, 133, "doc", (c133.SelectedIndex != -1 && c67.Checked) ? c133.SelectedValue.ToString() : "0");
            d.upd_thongso(i_nhom, 134, "doc", (c134.SelectedIndex != -1 && c68.Checked) ? c134.SelectedValue.ToString() : "0");
            d.upd_thongso(i_nhom, 135, "ton toi thieu", (c135.SelectedIndex != -1) ? c135.SelectedValue.ToString() : "0");
            d.upd_thongso(i_nhom, 136, "kiem tra ton kho", (c136.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 137, "theo kho", (c137.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 138, "ngay+phieu", (c138.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 139, "nhap+ngay", (c139.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 140, "chiet khau", (c140.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 141, "so program",c141.Value.ToString());
            d.upd_thongso(i_nhom, 142, "chiet khau", (c142.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 143, "gia ban noi tru<>ngoai tru", (c143.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 144, "in theo cstt", (c144.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 145, "in cstt->cpkb", (c145.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 146, "congkham->pl", (c146.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 147, "ylenh->phieu linh", (c147.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 148, "giaban->danhmuc", (c148.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 149, "giam gia", (c149.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 150, "tk giam gia", c150.Text);
            d.upd_thongso(i_nhom, 151, "so ban in", c151.Value.ToString());
            d.upd_thongso(i_nhom, 152, "sohieu", (c152.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 153, "auto tonkho", (c153.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 154, "xuat auto", (c154.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 155, "duyet bhyt", (c155.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 156, "chuyen kham-tinh cong", (c156.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 157, "sotien-duyetcap", (c157.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 158, "dongia,losx,date->p.linh", (c158.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 159, "nhap t-xuat t", (c159.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 160, "date", (c160.Checked) ? "1" : "0");

            s_161 = "";
            for (int j = 0; j < c161.Items.Count; j++)
                if (c161.GetItemChecked(j)) s_161 += dtnin.Rows[j]["id"].ToString().PadLeft(3, '0') + ",";
            d.upd_thongso(i_nhom,161,"dutru nam",(s_161 != "") ? s_161.Substring(0, s_161.Length - 1) : "");
            d.upd_thongso(i_nhom, 162, "date", c162.Value.ToString());
            d.upd_thongso(i_nhom, 163, "hoantraban", (c163.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 164, "date duyet", c164.Value.ToString());
            d.upd_thongso(i_nhom, 165, "tylegiaban", (c165.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1017, "tylegiabanvattu", (c1017.Checked) ? "1" : "0");
            d.execute_data("delete from " + user + ".dmtyleban where nhomkho="+i_nhom);
            foreach (DataRow r in dstyle.Tables[0].Select("tu not is null and den not is null and tyle not is null", "tu,den"))
            {
                d.upd_dmtyleban(decimal.Parse(r["tu"].ToString()), decimal.Parse(r["den"].ToString()), decimal.Parse(r["tyle"].ToString()), i_userid,i_nhom);
            }

            foreach (DataRow r in dstylevattu.Tables[0].Select("tu not is null and den not is null and tyle not is null", "tu,den"))
            {
                d.upd_dmtyleban(decimal.Parse(r["tu"].ToString()), decimal.Parse(r["den"].ToString()), decimal.Parse(r["tyle"].ToString()), i_userid, i_nhom,1);
            }

            d.upd_thongso(i_nhom, 166, "tin nhan sound", (c166.Checked) ? "1" : "0");
            /*
            d.upd_thongso(i_nhom, 167, "chu ky", (c167.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom,167,(byte[])(p167.Tag));
            */
            d.upd_thongso(i_nhom, 168, "tin nhan sound", (c168.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 169, "treo phan le duyet rieng", (c169.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 170, "thu hoi phieu xuat tu truc", (c170.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 171, "chua pk,danh sach cho duyet", (c171.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 172, "bhyt 20 phat thuoc", (c172.Checked) ? "1" : "0");
            s_173 = "";
            for (int i = 0; i < c173.Items.Count; i++)
                if (c173.GetItemChecked(i)) s_173 += dtkho.Rows[i]["id"].ToString().PadLeft(3,'0') + ",";
            d.upd_thongso(i_nhom, 173, "kho tru ao", s_173);
            d.upd_thongso(i_nhom, 174, "xuat ban->vien phi", (c174.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 175, "95", c175.Text);
            d.upd_thongso(i_nhom, 176, "bhyt->admin", (c176.Checked) ? "1" : "0");
            //
            d.upd_thongso(i_nhom, 177, "so lan in phieuu linh", c177.Value.ToString());//so lan in toi da phieu linh
            //
            d.upd_thongso(i_nhom, 178, "chi tra n lan", (c178.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 179, "nhap+user", (c179.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1001, "khong kiem tra SL xuat thang sau", (c1001.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1002, "xuat khac cho phep chon dot xuat", (c1002.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1003, "so phieu in mau 38 tang theo nam", (c1003.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1004, "so phieu in mau 38 tang theo tháng", (c1004.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1005, "Nguoi duyet la nguoi thu hoi", (c1005.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1006, "sua so luong khi duyet kho cap", (c1006.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1007, "Khoa nhom bo", (c1007.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1008, "KHoa phan loai", (c1008.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1009, "Mau 38 khong ii CL thuoc", (c1009.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1010, "Nhap khoa ST - VAT", (c1010.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1011, "DuocBV_dua vao xuat", (c1011.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1012, "DuocBV_dua vao xuat", (c1012.Checked) ? "1" : "0");
            
            d.upd_thongso(i_nhom, 1014, "DuocBV_dua vao xuat", (c1014.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1015, "Xuat kho theo tuy chon", (c1015.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1016, "Loc phieu bu khi duyet", (c1016.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1031, "khong cho duyet toa khi bn hen", (c1031.Checked) ? "1" : "0");
            d.upd_thongso(i_nhom, 1032, "Admin moi co quyen huy phieu nhap kho", (c1032.Checked) ? "1" : "0");

            d.upd_thongso(i_nhom, 216, "Ma noi dang ky kham chua benh", c216.Text);//gam 20/03/2012
            d.upd_thongso(i_nhom, 217, "Vi tri ma noi dang ky kham chua benh",c217.Text);//gam 20/03/2012
           
            //
            d.upd_thongso(i_nhom, 5011, "Cam xuat excel", (c5011.Checked) ? "1" : "0");
            //
			d.execute_data("update "+user+".d_thongso set ten='"+c52.Text.ToString()+"' where id=52");
			d.execute_data("update "+user+".d_thongso set ten='"+c53.Text.ToString()+"' where id=53");
			d.upd_thongso(i_nhom,79,"So le - Don gia",(c79.Text=="")?"2":c79.Text);//Lay so le trong gia ban
			d.upd_thongso(i_nhom,7,"",c07.Text.Trim());
			d.upd_thongso(i_nhom,8,"",c08.Text.Trim());
			d.upd_thongso(i_nhom,9,"",c09.Text.Trim());
			d.upd_thongso(i_nhom,15,"",c15.Text.Trim());
			d.upd_thongso(i_nhom,16,"",c16.Text.Trim());
			d.upd_thongso(i_nhom,32,"",c32.Text.Trim());
			ds.Tables[0].Rows[0]["c02"]=(c02.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c05"]=(c05.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c10"]=c10.Value.ToString();
			ds.Tables[0].Rows[0]["c11"]=(c11.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c12"]=(c12.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c14"]=(c14.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c17"]=(c17.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c18"]=(c18.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c19"]=(c19.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c20"]=(c20.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c21"]=(c21.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c22"]=c22.Value.ToString();
			ds.Tables[0].Rows[0]["c23"]=(c23.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c24"]=(c24.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c25"]=(c25.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c26"]=(c26.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c27"]=(c27.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c28"]=(c28.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c29"]=(c29.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c30"]=(c30.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c31"]=(c31.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c07"]=c07.Text.Trim();
			ds.Tables[0].Rows[0]["c08"]=c08.Text.Trim();
			ds.Tables[0].Rows[0]["c09"]=c09.Text.Trim();
			ds.Tables[0].Rows[0]["c15"]=c15.Text.Trim();
			ds.Tables[0].Rows[0]["c16"]=c16.Text.Trim();
			ds.Tables[0].Rows[0]["c32"]=c32.Text.Trim();
			ds.Tables[0].Rows[0]["c33"]=(c33.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c34"]=(c34.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c35"]=(c35.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c36"]=(c36.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c37"]=(c37.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c38"]=(c38.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c39"]=(c39.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c40"]=(c40.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c41"]=(c41.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c42"]=(c42.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c95"]=(c95.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c96"]=(c96.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c97"]=(c97.Checked)?"1":"0";
			ds.Tables[0].Rows[0]["c101"]=(c101.Checked)?"1":"0";
            
			d.writeXml("d_thongso","kho",kho.Text.Trim());
			ds.Tables[0].Rows[0]["hinh"]=hinh.Text.Trim();
			//binh
			d.upd_thongso(i_nhom,55,"Thuoc NOI-NGOAI",(c55.Checked)?"1":"0");//phan biet thuoc noi, ngoai theo hang san xuat
			d.upd_thongso(i_nhom,56,"Thu muc report",(c56.Text=="")?"report":c56.Text);//phan biet thuoc noi, ngoai theo hang san xuat
			d.upd_thongso(i_nhom,57,"So le - So luong",(c57.Text=="")?"2":c57.Text);//Lay so le trong so luong
			d.upd_thongso(i_nhom,58,"So le - Don gia",(c58.Text=="")?"2":c58.Text);//Lay so le trong don gia
			d.upd_thongso(i_nhom,59,"So le - T.Tien",(c59.Text=="")?"2":c59.Text);//lay so lr trong thanh tien
			//
			ds.WriteXml("..\\..\\..\\xml\\d_thongso.xml");
			if (c13.Checked) d.upd_khoaso(i_nhom,s_mmyy,i_userid);
            else if (d.bKhoaso(i_nhom, s_mmyy)) d.execute_data("delete from " + user + ".d_khoaso where nhom=" + i_nhom + " and mmyy='" + s_mmyy + "'");
            
			butKetthuc.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void c02_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butHinh_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Title = "Chọn hình hệ thống";
			of.Filter = "Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
			of.RestoreDirectory=true;
			of.InitialDirectory = "..\\..\\..\\Picture";
			if (of.ShowDialog() == DialogResult.OK)	 hinh.Text=of.FileName;
		}

		private void c63_CheckedChanged(object sender, System.EventArgs e)
		{
			c69.Enabled=c63.Checked;
			if (!c63.Checked) c69.Checked=false;
		}

		private void c43_CheckedChanged(object sender, System.EventArgs e)
		{
			c78.Enabled=c43.Checked;
			if (!c43.Checked) c78.Checked=false;
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
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
			ts.MappingName = dstt.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "Thứ tự";
			TextCol1.Width = 40;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 145;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		private void c39_CheckedChanged(object sender, System.EventArgs e)
		{
			c106.Enabled=c39.Checked;
			if (!c39.Checked) c106.Checked=false;
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

		private void AddGridTableStyle2()
		{
			DataGridColoredTextBoxColumn TextCol1;
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
			ts.MappingName = dsmua.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "Thứ tự";
			TextCol1.Width = 40;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 145;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid2.TableStyles.Add(ts);
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
            ts.MappingName = dstyle.Tables[0].TableName;
            ts.AllowSorting = false;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tu";
            TextCol1.HeaderText = "Từ";
            TextCol1.Width = 80;
            TextCol1.Format = "###,###,###,##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "den";
            TextCol1.HeaderText = "Đến";
            TextCol1.Width = 80;
            TextCol1.Format = "###,###,###,##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "tyle";
            TextCol1.HeaderText = "%";
            TextCol1.Width = 30;
            TextCol1.Format = "##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid3.TableStyles.Add(ts);
        }
        private void AddGridTableStyle4()
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
            ts.MappingName = dstylevattu.Tables[0].TableName;
            ts.AllowSorting = false;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tu";
            TextCol1.HeaderText = "Từ";
            TextCol1.Width = 80;
            TextCol1.Format = "###,###,###,##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid4.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "den";
            TextCol1.HeaderText = "Đến";
            TextCol1.Width = 80;
            TextCol1.Format = "###,###,###,##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid4.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "tyle";
            TextCol1.HeaderText = "%";
            TextCol1.Width = 30;
            TextCol1.Format = "##0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid4.TableStyles.Add(ts);
        }

		private void c55_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c55.Checked) c123.Checked=false;
		}

		private void c123_CheckedChanged(object sender, System.EventArgs e)
		{
			if (c123.Checked) c55.Checked=false;
		}

		private void c128_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==c128 && c128.SelectedIndex!=-1) i_c128=int.Parse(c128.SelectedValue.ToString());
		}

		private void tab_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (i_c128==0) c128.SelectedIndex=-1;
            if (i_c135 == 0) c135.SelectedIndex = -1;
		}
        private void c66_CheckedChanged(object sender, System.EventArgs e)
        {
            c132.Enabled = c66.Checked;
        }

        private void c67_CheckedChanged(object sender, System.EventArgs e)
        {
            c133.Enabled = c67.Checked;
        }

        private void c68_CheckedChanged(object sender, System.EventArgs e)
        {
            c134.Enabled = c68.Checked;
        }

        private void c135_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c135 && c135.SelectedIndex != -1) i_c135 = int.Parse(c135.SelectedValue.ToString());
        }

        private void c107_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c107)
            {
                c137.Enabled = c107.Checked;
                c139.Enabled = c107.Checked;
            }
        }

        private void c149_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c149) c150.Enabled = c149.Checked;
        }

        private void c108_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c108) c152.Enabled = c108.Checked;
        }

        private void c65_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c65 && c65.Checked && c158.Checked) c158.Checked = false;

        }

        private void c158_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c158 && c158.Checked && c65.Checked) c65.Checked = false;
        }

        private void c159_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c159) c160.Checked = !c159.Checked;
        }

        private void c160_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c160) c159.Checked = !c160.Checked;
        }

        private void c165_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c165)
            {
                dataGrid3.Enabled = c165.Checked;
                if (c165.Checked) c148.Checked = false;
            }
        }

        private void c148_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c148 && c148.Checked) c165.Checked = false;
        }

        private void c167_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c167) b167.Enabled = c167.Checked;
        }

        private void b167_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Chọn chữ ký";
            of.Filter = "Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
            of.RestoreDirectory = true;
            of.InitialDirectory = "..\\..\\..\\chuky";
            if (of.ShowDialog() == DialogResult.OK)
            {
                p167.Tag = of.FileName;
                fstr = new System.IO.FileStream(p167.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                p167.Tag = image;
                map = new Bitmap(Image.FromStream(fstr));
                p167.Image = (Bitmap)map;
                fstr.Close();
            }
            System.Environment.CurrentDirectory = sDir;
        }

        private void c119_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c119) c173.Enabled = c119.Checked;
        }

        private void c173_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c173)
            {
                s_173 = "";
                for (int i = 0; i < c173.Items.Count; i++)
                    if (c173.GetItemChecked(i)) s_173 += dtkho.Rows[i]["id"].ToString().PadLeft(3,'0') + ",";
            }	
        }
        private void load_tooltip()
        {
            ToolTip tip = new ToolTip();
            DataSet dstooltip = new DataSet();
            if (!System.IO.File.Exists(@"..\..\..\xml\tooltip_cauhinh.xml"))
            {
                dstooltip = m.get_data("select '' control_name,'' text,'' vie,'' eng from dual").Clone();
                dstooltip.WriteXml(@"..\..\..\xml\tooltip_cauhinh.xml", XmlWriteMode.WriteSchema);
            }
            dstooltip.ReadXml(@"..\..\..\xml\tooltip_cauhinh.xml", XmlReadMode.ReadSchema);
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
            dstooltip.WriteXml(@"..\..\..\xml\tooltip_cauhinh.xml", XmlWriteMode.WriteSchema);
        }
        #region Capnhatthongso
        private void capnhat_control()
        {
            string s_control = "", s_text = "", s_loai = "";
            
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
                    m.upd_m_thongso_tim("d_thongso_tim", s_control, s_text, s_loai);
                }
            }
        }
        private void capnhat_control(Control ctls)
        {
            string s_control = "", s_text = "", s_loai = "", s_parent="";
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
                    m.upd_m_thongso_tim("d_thongso_tim", s_control, s_text, s_parent + " - " + s_loai);
                }
            }
        }

        #endregion    

        private void frmCauhinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Cursor = Cursors.WaitCursor;
                capnhat_control();
                Cursor = Cursors.Default;
            }
        }

        private void c1003_CheckedChanged(object sender, EventArgs e)
        {
            if (c1003.Checked)
            {
                c1004.Checked = false;
                c1012.Checked = false;
            }
        }

        private void c1004_CheckedChanged(object sender, EventArgs e)
        {
            if (c1004.Checked)
            {
                c1003.Checked = false;
                c1012.Checked = false;
                c1014.Checked = false;
            }
        }

        private void c1012_CheckedChanged(object sender, EventArgs e)
        {            
            if (c1012.Checked)
            {
                c1003.Checked = false;
                c1004.Checked = false;
                c1014.Checked = false;
            }
        }

        private void c1014_CheckedChanged(object sender, EventArgs e)
        {
            
            if (c1014.Checked)
            {
                c1003.Checked = false;
                c1004.Checked = false;
                c1012.Checked = false;
            }
        }

        private void c1017_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == c1017)
            {
                dataGrid4.Enabled = c1017.Checked;
            }
        }
    
    }
}
