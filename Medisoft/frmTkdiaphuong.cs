using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmTkvaovien.
	/// </summary>
	public class frmTkdiaphuong : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox makp;
		private System.Data.DataTable dt;
		private DataSet dsdt=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dssl=new DataSet();
		private DataSet dsbc=new DataSet();
		private DataSet dstmp=new DataSet();
		private System.Data.DataTable dticd=new System.Data.DataTable();
		private DataSet ds=new DataSet();
		private DataColumn dc;
		private AccessData m;
		private bool bClear=true;
		private System.Windows.Forms.ToolTip toolTip1;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.ComboBox ttlucrv;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckedListBox listBox1;
		private System.ComponentModel.IContainer components;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;

		public frmTkdiaphuong(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkdiaphuong));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.label12 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.butTim = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.ttlucrv = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(168, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(10, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(72, 83);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(80, 21);
            this.madantoc.TabIndex = 5;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(72, 131);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(232, 21);
            this.mann.TabIndex = 8;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(72, 179);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(232, 21);
            this.maqu.TabIndex = 10;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(72, 155);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(232, 21);
            this.matt.TabIndex = 9;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(72, 227);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(232, 21);
            this.maphuongxa.TabIndex = 13;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(-6, 227);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Báo cáo theo :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(-6, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(16, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(-6, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Nghề nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(17, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(-6, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 57;
            this.label12.Text = "Khoa/Phòng :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(72, 107);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(232, 21);
            this.makp.TabIndex = 7;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(142, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Độ tuổi :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(10, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 62;
            this.label19.Text = "Số liệu :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(72, 59);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(80, 21);
            this.phai.TabIndex = 3;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // dotuoi
            // 
            this.dotuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(216, 59);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(88, 21);
            this.dotuoi.TabIndex = 4;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // solieu
            // 
            this.solieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(72, 35);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(232, 21);
            this.solieu.TabIndex = 2;
            this.solieu.SelectedIndexChanged += new System.EventHandler(this.solieu_SelectedIndexChanged);
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // butTim
            // 
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(216, 272);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(91, 25);
            this.butTim.TabIndex = 14;
            this.butTim.Text = "&In";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(310, 272);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(89, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(240, 12);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(72, 12);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // ttlucrv
            // 
            this.ttlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ttlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlucrv.Location = new System.Drawing.Point(216, 83);
            this.ttlucrv.Name = "ttlucrv";
            this.ttlucrv.Size = new System.Drawing.Size(88, 21);
            this.ttlucrv.TabIndex = 6;
            this.ttlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ttlucrv_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(152, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 66;
            this.label3.Text = "Tình trạng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd
            // 
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(72, 203);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(56, 21);
            this.maicd.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(18, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 68;
            this.label4.Text = "Mã ICD :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(130, 202);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 24);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Danh sách ICD10";
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.Location = new System.Drawing.Point(312, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(296, 244);
            this.listBox1.TabIndex = 70;
            // 
            // frmTkdiaphuong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 317);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.ttlucrv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.den);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkdiaphuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình mắc bệnh theo địa phương";
            this.Load += new System.EventHandler(this.frmTkdiaphuong_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkravien_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTkdiaphuong_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkdiaphuong_Load(object sender, System.EventArgs e)
		{
            dticd = m.get_data("select cicd10,vviet from " + m.user + ".icd10 order by cicd10").Tables[0];
			dstmp.ReadXml("..//..//..//xml//t_tmp.xml");
			dsxml.ReadXml("..//..//..//xml//t_icd10.xml");
			dsdt.ReadXml("..//..//..//xml//dotuoi.xml");
			dssl.ReadXml("..//..//..//xml//t_diaphuong.xml");
			dsbc.ReadXml("..//..//..//xml//bcdiaphuong.xml");
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dotuoi.DataSource=dsdt.Tables[0];

            listBox1.DataSource = dsxml.Tables[0];
            listBox1.DisplayMember = "ten";
			listBox1.ValueMember="cont";

			solieu.DisplayMember="ma";
			solieu.ValueMember="ten";
			solieu.DataSource=dssl.Tables[0];

			maphuongxa.DisplayMember="ma";
			maphuongxa.ValueMember="ten";
			maphuongxa.DataSource=dsbc.Tables[0];

			solieu.SelectedIndex=0;
			maphuongxa.SelectedIndex=0;

			ttlucrv.DisplayMember="TEN";
			ttlucrv.ValueMember="MA";
			ttlucrv.DataSource=m.get_data("select * from "+m.user+".ttxk order by ma").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			
			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
            mann.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + m.user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + m.user + ".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			load_quan();
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}

		private void emp_text()
		{
			makp.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			madantoc.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
			ttlucrv.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
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

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="")
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
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

		private void butTim_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (maphuongxa.SelectedIndex==2 && maqu.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),AccessData.Msg);
					if (matt.SelectedIndex==-1) matt.Focus();
					else maqu.Focus();
					return;
				}
				string cont="",sql=maphuongxa.SelectedValue.ToString()+" "+solieu.SelectedValue.ToString();
                sql = sql.Replace("medibvmmyy", "xxx");
                sql = sql.Replace("medibv", m.user);
				DataRow r;
				for(int i=0;i<listBox1.Items.Count;i++)
				{
					if (listBox1.GetItemChecked(i))
					{
						r=m.getrowbyid(dsxml.Tables[0],"ma='"+i.ToString().PadLeft(2,'0')+"'");
						cont+=(cont!="")?" or ":"";
						cont+=r["cont"].ToString();
					}
				}
				if (tu.Text!="")
                    sql += " and " + m.for_ngay("a.ngay", "'" + m.f_ngay + "'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
				if (phai.SelectedIndex!=-1)
					sql+=" and b.phai="+phai.SelectedIndex;
				if (mann.SelectedIndex!=-1)
					sql+=" and b.mann='"+mann.SelectedValue.ToString()+"'";
				if (madantoc.SelectedIndex!=-1)
					sql+=" and b.madantoc='"+madantoc.SelectedValue.ToString()+"'";
				if (matt.SelectedIndex!=-1)
					sql+=" and b.matt='"+matt.SelectedValue.ToString()+"'";
				if (maqu.SelectedIndex!=-1)
					sql+=" and b.maqu='"+maqu.SelectedValue.ToString()+"'";
				if (makp.SelectedIndex!=-1)
					sql+=" and a.makp='"+makp.SelectedValue.ToString()+"'";
				if (dotuoi.SelectedIndex!=-1)
					sql+=" and to_number(to_char(now(),'yyyy'))-to_number(b.namsinh) "+dotuoi.SelectedValue.ToString();
				if (ttlucrv.SelectedIndex!=-1 && ttlucrv.Enabled)
					sql+=" and a.ttlucrv="+int.Parse(ttlucrv.SelectedValue.ToString());
				if (maicd.Text!="")	sql+=" and a.maicd='"+maicd.Text+"'";
                if (checkBox1.Checked) sql += " and a.maicd in (select ma from " + m.user + ".dmicd10)";
				if (cont!="") sql+=" and ("+cont+")";
				r=m.getrowbyid(dsbc.Tables[0],"ma='"+maphuongxa.Text+"'");
				sql+=" group by "+r["stt"].ToString()+" order by "+r["stt"].ToString();
                if(sql.IndexOf("xxx")>=0)
                    ds = m.get_data_mmyy(sql,tu.Text,den.Text,false);
                else
				    ds=m.get_data(sql);
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
				}
				dt=new System.Data.DataTable();
				tao_table(r["sql"].ToString().Replace("medibv",m.user),r["ord"].ToString());
				gan_data();
				imp_excel();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void tao_table(string sql,string ord)
		{
			if (maphuongxa.SelectedIndex==1 && matt.SelectedIndex==-1)
				sql+=" where matt='"+m.Mabv.Substring(0,3)+"'";
			else if (maphuongxa.SelectedIndex==2 && maqu.SelectedIndex!=-1)
				sql+=" where maqu='"+maqu.SelectedValue.ToString()+"'";
			else if (maphuongxa.SelectedIndex==1 && matt.SelectedIndex!=-1)
				sql+=" where matt='"+matt.SelectedValue.ToString()+"'";
			sql+=" "+ord;
			DataRow r1,r2;
			dstmp.Clear();
			dc=new DataColumn();
			dc.ColumnName="maicd";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="ten";
			dc.DataType=Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="tongcong";
			dc.DataType=Type.GetType("System.Decimal");
			dt.Columns.Add(dc);
			if (maphuongxa.SelectedIndex!=0)
			{
				dc=new DataColumn();
				dc.ColumnName="tongso";
				dc.DataType=Type.GetType("System.Decimal");
				dt.Columns.Add(dc);
			}
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=m.getrowbyid(dstmp.Tables[0],"ma='"+r["ma"].ToString()+"'");
				if (r1==null)
				{
					r2 = dstmp.Tables[0].NewRow();
					r2[0]=r["ma"].ToString();
					r2[1]=r["ten"].ToString();
					dstmp.Tables[0].Rows.Add(r2);
				}
				dc=new DataColumn();
				dc.ColumnName="C_"+r["ma"].ToString();
				dc.DataType=Type.GetType("System.Decimal");
				dt.Columns.Add(dc);
			}
		}

		private void gan_data()
		{
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				for(int i=4;i<dt.Columns.Count;i++)
				{
					if (r["ma"].ToString()==dt.Columns[i].ToString().Substring(2))
					{
						m.updrec(dt,r["maicd"].ToString(),maphuongxa.SelectedIndex==0,i,decimal.Parse(r["so"].ToString()));
						break;
					}
				}
				m.updrec(dt,r["maicd"].ToString(),maphuongxa.SelectedIndex==0,2,decimal.Parse(r["so"].ToString()));
			}
			DataRow r1;
			foreach(DataRow r in dt.Rows)
			{
				r1=m.getrowbyid(dticd,"cicd10='"+r["maicd"].ToString()+"'");
				if (r1!=null) r["ten"]=r1["vviet"].ToString().Trim();
				else r["ten"]="xxx";
			}
			m.delrec(dt,"ten='xxx'");
		}

		private void imp_excel()
		{
			oxl=new Excel.Application();
			oxl.Visible=true;
			owb=(Excel._Workbook)(oxl.Workbooks.Add(Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			int i,j,be=4,k,cot=dt.Columns.Count,dong=dt.Rows.Count;
			string ten,tit=(maphuongxa.SelectedIndex==1)?"TỈNH":"QUẬN";
			k=(maphuongxa.SelectedIndex==0)?2:3;
			DataRow r;
			for(i=0;i<cot;i++)
			{
				ten=dt.Columns[i].ColumnName.ToString();
				if (i>k)
				{
					r=m.getrowbyid(dstmp.Tables[0],"ma='"+ten.Substring(2)+"'");
					if (r!=null) ten=r["ten"].ToString().Trim();
				}
				else
				{
					switch (i)
					{
						case 0: ten="MÃ ICD";
							break;
						case 1: ten="TÊN BỆNH";
							break;
						case 2: ten="TỔNG CỘNG";
							break;
						case 3: ten="TS TRONG "+tit;
							break;
					}
				}
				osheet.Cells[3,i+1]=ten;
			}
			for(i=0;i<dong;i++)
			{
				for(j=0;j<cot;j++)
				{
					osheet.Cells[i+be,j+1]=dt.Rows[i][j].ToString();
				}
			}
			osheet.get_Range(m.getIndex(0)+"3",m.getIndex(cot-1)+(dong+be-1)).Borders.LineStyle=Excel.XlLineStyle.xlContinuous;osheet.get_Range(m.getIndex(2)+"3",m.getIndex(cot)+"3").Orientation=90;
			orange=osheet.get_Range(m.getIndex(0)+"3",m.getIndex(1)+"3");
			orange.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange.HorizontalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange=osheet.get_Range(m.getIndex(0)+"3",m.getIndex(cot)+"3");
			orange.EntireColumn.AutoFit();
			orange.Font.Bold=true;
			dong+=be;
			osheet.get_Range(m.getIndex(2)+dong.ToString(),m.getIndex(cot)+dong.ToString()).Font.Bold=true;
			osheet.Cells[1,2]=this.Text.Trim().ToUpper();
			if (tu.Text!="" && den.Text!="") osheet.Cells[2,2]="Từ ngày : "+tu.Text+" đến : "+den.Text;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_quan();
		}

		private void frmTkravien_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTkdiaphuong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dotuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void solieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (solieu.SelectedIndex<=1)
                    makp.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv where loai=1 order by makp").Tables[0];
				else
                    makp.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv order by makp").Tables[0];
				makp.SelectedIndex=-1;
				ttlucrv.Enabled=solieu.SelectedIndex==0 || solieu.SelectedIndex==2;
			}
			catch{}
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (maqu.SelectedIndex==-1 && matt.SelectedIndex==-1) maphuongxa.SelectedIndex=0;
        	else if (maqu.SelectedIndex==-1) maphuongxa.SelectedIndex=1;
			else maphuongxa.SelectedIndex=2;
		}

		private void checkBox1_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (checkBox1.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmmaicd f=new frmDmmaicd(m);
					f.ShowDialog();
				}
			}
		}

		private void ttlucrv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}
	}
}
