using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Paint;
using LibMedi;

namespace Medisoft
{
	public class frmBATMH : System.Windows.Forms.Form
    {
        #region Khai bao
        private Language lan = new Language();
        private System.Windows.Forms.Panel pa1;
		private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel pa2;
		private System.Windows.Forms.PictureBox pic2;
		private System.Windows.Forms.Panel pa3;
		private System.Windows.Forms.PictureBox pic3;
		private System.Windows.Forms.Panel pa4;
		private System.Windows.Forms.PictureBox pic4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox p1;
		private System.Windows.Forms.TextBox p2;
		private System.Windows.Forms.TextBox p4;
        private System.Windows.Forms.TextBox p3;
		private System.Windows.Forms.TextBox t5;
		private System.Windows.Forms.TextBox t4;
		private System.Windows.Forms.TextBox t3;
		private System.Windows.Forms.TextBox t2;
		private System.Windows.Forms.TextBox t1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox kham;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butBoqua;
		private MemoryStream memo;
		private FileStream fstr;
		private Bitmap map;
		private byte[] image,image1,image2,image3,image4;
		private AccessData m;
		private decimal l_maql;
		private bool bHinh=false;
		private DataTable dthinh=new DataTable();
		private string thumucpic,s_ngay,f1="",f2="",f3="",f4="",filebmp="benhan.bmp",xxx;
        private Print print = new Print();
		private System.Windows.Forms.ToolTip toolTip1;
        private TextBox p5;
		private System.ComponentModel.IContainer components;
        private TabPage tabPage3;
        private CheckBox chkXem;
        private CheckBox chkXML;
        private bool bbadt = false;
        #endregion

        public frmBATMH(AccessData acc,decimal maql,string ngay)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;l_maql=maql;s_ngay=ngay;
		}
        public frmBATMH(AccessData acc, decimal maql, string ngay,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; l_maql = maql; s_ngay = ngay;
            bbadt = _badt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBATMH));
            this.pa1 = new System.Windows.Forms.Panel();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.t5 = new System.Windows.Forms.TextBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t1 = new System.Windows.Forms.TextBox();
            this.p5 = new System.Windows.Forms.TextBox();
            this.p4 = new System.Windows.Forms.TextBox();
            this.p3 = new System.Windows.Forms.TextBox();
            this.p2 = new System.Windows.Forms.TextBox();
            this.p1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pa2 = new System.Windows.Forms.Panel();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.kham = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pa4 = new System.Windows.Forms.Panel();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pa3 = new System.Windows.Forms.Panel();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pa1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pa2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pa4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            this.pa3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pa1
            // 
            this.pa1.AutoScroll = true;
            this.pa1.Controls.Add(this.pic1);
            this.pa1.Location = new System.Drawing.Point(0, 0);
            this.pa1.Name = "pa1";
            this.pa1.Size = new System.Drawing.Size(784, 181);
            this.pa1.TabIndex = 267;
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic1.Location = new System.Drawing.Point(0, 0);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(784, 180);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.toolTip1.SetToolTip(this.pic1, "Chỉnh sửa hình Double Click");
            this.pic1.DoubleClick += new System.EventHandler(this.pic1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 505);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.t5);
            this.tabPage1.Controls.Add(this.t4);
            this.tabPage1.Controls.Add(this.t3);
            this.tabPage1.Controls.Add(this.t2);
            this.tabPage1.Controls.Add(this.t1);
            this.tabPage1.Controls.Add(this.p5);
            this.tabPage1.Controls.Add(this.p4);
            this.tabPage1.Controls.Add(this.p3);
            this.tabPage1.Controls.Add(this.p2);
            this.tabPage1.Controls.Add(this.p1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pa2);
            this.tabPage1.Controls.Add(this.pa1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(784, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trang 1";
            // 
            // t5
            // 
            this.t5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t5.Location = new System.Drawing.Point(97, 302);
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(680, 21);
            this.t5.TabIndex = 9;
            this.t5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // t4
            // 
            this.t4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t4.Location = new System.Drawing.Point(441, 280);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(336, 21);
            this.t4.TabIndex = 7;
            this.t4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // t3
            // 
            this.t3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t3.Location = new System.Drawing.Point(441, 258);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(336, 21);
            this.t3.TabIndex = 5;
            this.t3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // t2
            // 
            this.t2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.Location = new System.Drawing.Point(441, 236);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(336, 21);
            this.t2.TabIndex = 3;
            this.t2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // t1
            // 
            this.t1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.Location = new System.Drawing.Point(441, 214);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(336, 21);
            this.t1.TabIndex = 1;
            this.t1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p5.Location = new System.Drawing.Point(283, 187);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(20, 21);
            this.p5.TabIndex = 8;
            this.p5.Visible = false;
            this.p5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p4.Location = new System.Drawing.Point(97, 280);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(338, 21);
            this.p4.TabIndex = 6;
            this.p4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p3.Location = new System.Drawing.Point(97, 258);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(338, 21);
            this.p3.TabIndex = 4;
            this.p3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2.Location = new System.Drawing.Point(97, 236);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(338, 21);
            this.p2.TabIndex = 2;
            this.p2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1.Location = new System.Drawing.Point(97, 214);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(338, 21);
            this.p1.TabIndex = 0;
            this.p1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(47, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 286;
            this.label8.Text = "Weber";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(43, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 285;
            this.label7.Text = "Rinne";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(13, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 284;
            this.label6.Text = "Schwabach";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(44, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 283;
            this.label5.Text = "Nói to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(30, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 282;
            this.label4.Text = "Nói thầm";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(593, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 281;
            this.label3.Text = "Tai (T)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(219, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 280;
            this.label2.Text = "Tai (P)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 269;
            this.label1.Text = "Đo sức nghe đơn giảm :";
            // 
            // pa2
            // 
            this.pa2.AutoScroll = true;
            this.pa2.Controls.Add(this.pic2);
            this.pa2.Location = new System.Drawing.Point(0, 351);
            this.pa2.Name = "pa2";
            this.pa2.Size = new System.Drawing.Size(784, 259);
            this.pa2.TabIndex = 268;
            // 
            // pic2
            // 
            this.pic2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic2.Location = new System.Drawing.Point(0, -24);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(784, 151);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.toolTip1.SetToolTip(this.pic2, "Chỉnh sửa hình Double Click");
            this.pic2.DoubleClick += new System.EventHandler(this.pic2_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.kham);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pa4);
            this.tabPage2.Controls.Add(this.pa3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(784, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trang 2";
            // 
            // kham
            // 
            this.kham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham.Location = new System.Drawing.Point(151, 585);
            this.kham.Name = "kham";
            this.kham.Size = new System.Drawing.Size(625, 21);
            this.kham.TabIndex = 0;
            this.kham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.p1_KeyDown);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(5, 587);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 16);
            this.label9.TabIndex = 270;
            this.label9.Text = "Khám tiền đình và thần kinh :";
            // 
            // pa4
            // 
            this.pa4.AutoScroll = true;
            this.pa4.Controls.Add(this.pic4);
            this.pa4.Location = new System.Drawing.Point(0, 240);
            this.pa4.Name = "pa4";
            this.pa4.Size = new System.Drawing.Size(784, 336);
            this.pa4.TabIndex = 269;
            // 
            // pic4
            // 
            this.pic4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic4.Location = new System.Drawing.Point(0, 0);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(784, 336);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 0;
            this.pic4.TabStop = false;
            this.toolTip1.SetToolTip(this.pic4, "Chỉnh sửa hình Double Click");
            this.pic4.DoubleClick += new System.EventHandler(this.pic4_DoubleClick);
            // 
            // pa3
            // 
            this.pa3.AutoScroll = true;
            this.pa3.Controls.Add(this.pic3);
            this.pa3.Location = new System.Drawing.Point(0, 0);
            this.pa3.Name = "pa3";
            this.pa3.Size = new System.Drawing.Size(784, 232);
            this.pa3.TabIndex = 268;
            // 
            // pic3
            // 
            this.pic3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pic3.Location = new System.Drawing.Point(0, 0);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(784, 232);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 0;
            this.pic3.TabStop = false;
            this.toolTip1.SetToolTip(this.pic3, "Chỉnh sửa hình Double Click");
            this.pic3.DoubleClick += new System.EventHandler(this.pic3_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.chkXem);
            this.tabPage3.Controls.Add(this.chkXML);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(784, 479);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tùy chọn";
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXem.Location = new System.Drawing.Point(28, 40);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 16);
            this.chkXem.TabIndex = 7;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.Location = new System.Drawing.Point(28, 18);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 6;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(300, 508);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 1;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(370, 508);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 2;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(440, 508);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 3;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // frmBATMH
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 542);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBATMH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bệnh án Tai Mũi Họng";
            this.Load += new System.EventHandler(this.frmBATMH_Load);
            this.pa1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pa2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pa4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            this.pa3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmBATMH_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);//579
            }
			chkXem.Checked=m.bPreview;
			thumucpic="..\\..\\..\\picture_ba";
			if (!Directory.Exists("..\\pict_ba")) Directory.CreateDirectory("..\\pict_ba");
			if (!Directory.Exists(thumucpic)) Directory.CreateDirectory(thumucpic);
			else
			{
				try
				{
					string [] files=Directory.GetFiles(thumucpic);
					for(int i=0;i<files.GetLength(0);i++) File.Delete(files[i].ToString());
				}
				catch{}
			}
			get_file(0);
			dthinh=m.get_data("select * from "+m.user+".ba_hinh where id<0 order by stt").Tables[0];
			xxx=m.user+m.mmyy(s_ngay);
			bool bFound=false;
			foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_tmh where maql="+l_maql).Tables[0].Rows)
			{
				image1 =new byte[0];
                if (r["image1"].ToString() != "")
                {
                    image1 = (byte[])(r["image1"]);
                    memo = new MemoryStream(image1);
                }
                try { map = new Bitmap(Image.FromStream(memo)); }
                catch { map = new Bitmap(@"bangtmh_01.bmp"); }
				picture(pic1,f1);
				//
				image2 =new byte[0];
                if (r["image2"].ToString() != "")
                {
                    image2 = (byte[])(r["image2"]);
                    memo = new MemoryStream(image2);
                }
                try { map = new Bitmap(Image.FromStream(memo)); }
                catch { map = new Bitmap(@"bangtmh_02.bmp"); }
				picture(pic2,f2);
				//
				image3 =new byte[0];
                if (r["image3"].ToString() != "")
                {
                    image3 = (byte[])(r["image3"]);
                    memo = new MemoryStream(image3);
                }
                try { map = new Bitmap(Image.FromStream(memo)); }
                catch { map = new Bitmap(@"hinh.bmp"); }
				picture(pic3,f3);
				//
				image4 =new byte[0];
                if (r["image4"].ToString() != "")
                {
                    image4 = (byte[])(r["image4"]);
                    memo = new MemoryStream(image4);
                }
                try { map = new Bitmap(Image.FromStream(memo)); }
                catch { map = new Bitmap(@"hinh.bmp"); }
				picture(pic4,f4);
				//
				kham.Text=r["kham"].ToString();
				bHinh=true;bFound=true;
				break;
			}
			if (!bFound)
			{
				bHinh=dthinh.Rows.Count>0;
				foreach(DataRow r in dthinh.Rows)
				{
                    switch (int.Parse(r["id"].ToString()))
                    {
                        case -1:
                            image1 = new byte[0];
                            if (r["hinh"].ToString() != "")
                            {
                                image1 = (byte[])(r["hinh"]);
                                memo = new MemoryStream(image1);
                            }
                            try { map = new Bitmap(Image.FromStream(memo)); }
                            catch { map = new Bitmap(@"bangtmh_01.bmp"); }
                            picture(pic1, f1);
                            break;
                        case -2:
                            image2 = new byte[0];
                            if (r["hinh"].ToString() != "")
                            {
                                image2 = (byte[])(r["hinh"]);
                                memo = new MemoryStream(image2);
                            }
                            try { map = new Bitmap(Image.FromStream(memo)); }
                            catch { map = new Bitmap(@"bangtmh_02.bmp"); }
                            picture(pic2, f2);
                            break;
                        case -3:
                            image3 = new byte[0];
                            if (r["hinh"].ToString() != "")
                            {
                                image3 = (byte[])(r["hinh"]);
                                memo = new MemoryStream(image3);
                            }
                            try { map = new Bitmap(Image.FromStream(memo)); }
                            catch { map = new Bitmap(@"hinh.bmp"); }
                            picture(pic3, f3);
                            break;
                        case -4:
                            image4 = new byte[0];
                            if (r["hinh"].ToString() != "")
                            {
                                image4 = (byte[])(r["hinh"]);
                                memo = new MemoryStream(image4);
                            }
                            try { map = new Bitmap(Image.FromStream(memo)); }
                            catch { map = new Bitmap(@"hinh.bmp"); }
                            picture(pic4, f4);
                            break;
                    }
				}
			}
			foreach(DataRow r in m.get_data("select * from "+xxx+".bavv_tmhct where maql="+l_maql).Tables[0].Rows)
			{
				switch (int.Parse(r["stt"].ToString()))
				{
					case 1:p1.Text=r["taip"].ToString();t1.Text=r["tait"].ToString();break;
					case 2:p2.Text=r["taip"].ToString();t2.Text=r["tait"].ToString();break;
					case 3:p3.Text=r["taip"].ToString();t3.Text=r["tait"].ToString();break;
					case 4:p4.Text=r["taip"].ToString();t4.Text=r["tait"].ToString();break;
					case 5:p5.Text=r["taip"].ToString();t5.Text=r["tait"].ToString();break;
				}
			}
		}

		private void edit_pic(PictureBox pic,int i)
		{
            string sDir = System.Environment.CurrentDirectory.ToString(), tenfile = "..\\pict_ba\\" + pic.Name.ToString() + ".bmp";
            try
            {
                if (File.Exists((i == 1) ? f1 : (i == 2) ? f2 : (i == 3) ? f3 : f4))
                {
                    frmPaint f = new frmPaint((i == 1) ? f1 : (i == 2) ? f2 : (i == 3) ? f3 : f4);
                    f.ShowDialog(this);
                    f.Save_image(tenfile);
                    fstr = new System.IO.FileStream(tenfile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    pic.Tag = image;
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                    pic.Update();
                    fstr.Close();
                    get_file(i);
                    File.Copy(tenfile, (i == 1) ? f1 : (i == 2) ? f2 : (i == 3) ? f3 : f4, true);
                }
            }
            catch { }
            System.Environment.CurrentDirectory = sDir;
		}

		private void pic1_DoubleClick(object sender, System.EventArgs e)
		{
			if (bHinh) edit_pic(pic1,1);
		}

		private void pic2_DoubleClick(object sender, System.EventArgs e)
		{
			if (bHinh) edit_pic(pic2,2);
		}

		private void pic3_DoubleClick(object sender, System.EventArgs e)
		{
			if (bHinh) edit_pic(pic3,3);
		}

		private void pic4_DoubleClick(object sender, System.EventArgs e)
		{
			if (bHinh) edit_pic(pic4,4);
		}
		private void get_file(int i)
		{
			if (i==0)
			{
				f1=thumucpic+"\\1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
				f2=thumucpic+"\\2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
				f3=thumucpic+"\\3"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
				f4=thumucpic+"\\4"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			}
			else if (i==1) f1=thumucpic+"\\1"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			else if (i==2) f2=thumucpic+"\\2"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			else if (i==3) f3=thumucpic+"\\3"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
			else f4=thumucpic+"\\4"+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Millisecond.ToString().PadLeft(2,'0')+".bmp";
		}

		private void emp_hinh()
		{
			pic1.Tag=filebmp;
			fstr=new System.IO.FileStream(pic1.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic1.Image=(Bitmap)map;
			image1=new byte[fstr.Length];
			fstr.Read(image1,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic1.Tag=image1;
			System.IO.File.Copy(filebmp,f1,true);
			//
			pic2.Tag=filebmp;
			fstr=new System.IO.FileStream(pic2.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic2.Image=(Bitmap)map;
			image2=new byte[fstr.Length];
			fstr.Read(image2,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic2.Tag=image2;
			System.IO.File.Copy(filebmp,f2,true);
			//
			pic3.Tag=filebmp;
			fstr=new System.IO.FileStream(pic3.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic3.Image=(Bitmap)map;
			image3=new byte[fstr.Length];
			fstr.Read(image3,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic3.Tag=image3;
			System.IO.File.Copy(filebmp,f3,true);
			//
			pic4.Tag=filebmp;
			fstr=new System.IO.FileStream(pic4.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic4.Image=(Bitmap)map;
			image4=new byte[fstr.Length];
			fstr.Read(image4,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic4.Tag=image4;
			System.IO.File.Copy(filebmp,f4,true);
		}

		private void picture(PictureBox pic,string tenfile)
		{
			pic.Image=(Bitmap)map;
			pic.Tag=image;
			map.Save(tenfile);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			m.upd_bavv_tmh(s_ngay,l_maql,"","","",kham.Text);
			//hinh
			if (bHinh)
			{
				fstr=new System.IO.FileStream(f1,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image1=new byte[fstr.Length];
				fstr.Read(image1,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				//
				fstr=new System.IO.FileStream(f2,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image2=new byte[fstr.Length];
				fstr.Read(image2,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				//
				fstr=new System.IO.FileStream(f3,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image3=new byte[fstr.Length];
				fstr.Read(image3,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				//
				fstr=new System.IO.FileStream(f4,System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image4=new byte[fstr.Length];
				fstr.Read(image4,0,System.Convert.ToInt32(fstr.Length));
				fstr.Close();
				m.upd_bavv_tmh(s_ngay,l_maql,image1,image2,image3,image4);
			}
			//
			m.upd_bavv_tmhct(s_ngay,l_maql,1,p1.Text,t1.Text);
			m.upd_bavv_tmhct(s_ngay,l_maql,2,p2.Text,t2.Text);
			m.upd_bavv_tmhct(s_ngay,l_maql,3,p3.Text,t3.Text);
			m.upd_bavv_tmhct(s_ngay,l_maql,4,p4.Text,t4.Text);
			m.upd_bavv_tmhct(s_ngay,l_maql,5,p5.Text,t5.Text);
			butIn.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
		}

		private void p1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql="select a.*,b.stt,b.taip,b.tait from "+xxx+".bavv_tmh a,"+xxx+".bavv_tmhct b where a.maql=b.maql and a.maql="+l_maql+" order by b.stt";
			DataSet ds=m.get_data(sql);			
			if (ds.Tables[0].Rows.Count>0)
			{
				if (chkXML.Checked)
				{
					if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
					ds.WriteXml("..\\xml\\batmh.xml",XmlWriteMode.WriteSchema);
				}
				if (chkXem.Checked)
				{
                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds, "", "rptBaTMH.rpt");
					f.ShowDialog();
				}
				else print.Printer(m,ds,"rptBaTMH.rpt","",1,1);
			}
		}
	}
}
