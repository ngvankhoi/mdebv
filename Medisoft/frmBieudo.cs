using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WebTel.Drawing.Chart;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmBieudo : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private WebTel.Drawing.Chart.ucChart ucChart1;
		private Label lbl;
		private System.Windows.Forms.ComboBox style;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private AccessData m;
		private System.Windows.Forms.Button butBieudo;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox maphuongxa;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox nhantu;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox dentu;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox xutri;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox ketqua;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private MaskedTextBox.MaskedTextBox maicd;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox chktuoi;
		private System.Windows.Forms.CheckBox chkmaicd;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.ComboBox vebieudo;
		private System.Windows.Forms.Label label20;
		private MaskedTextBox.MaskedTextBox mapt;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ComboBox vocam;
		private System.Windows.Forms.ComboBox taibien;
		private System.Windows.Forms.ComboBox tinhhinh;
		private System.Windows.Forms.ComboBox tuvong;
		private System.Windows.Forms.ComboBox loaipt;
		private System.Windows.Forms.Label label26;
		private bool bClear=true;
		private DataTable dt=new DataTable();
		private DataTable tmp=new DataTable();
		private DataTable tmpve=new DataTable();
		private DataTable dttuoi=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private string sql;
		private MaskedTextBox.MaskedTextBox tuoi;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolTip toolTip2;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.ComponentModel.IContainer components;

		public frmBieudo(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBieudo));
            this.ucChart1 = new WebTel.Drawing.Chart.ucChart();
            this.butBieudo = new System.Windows.Forms.Button();
            this.style = new System.Windows.Forms.ComboBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nhantu = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dentu = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.xutri = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ketqua = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tuoi = new MaskedTextBox.MaskedTextBox();
            this.chktuoi = new System.Windows.Forms.CheckBox();
            this.chkmaicd = new System.Windows.Forms.CheckBox();
            this.vebieudo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.mapt = new MaskedTextBox.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.vocam = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.taibien = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tinhhinh = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tuvong = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.SuspendLayout();
            // 
            // ucChart1
            // 
            // Layout is suspended for performance reasons.
            this.ucChart1.Chart.SuspendLayout();
            this.ucChart1.Chart.CategoryX.Font = null;
            this.ucChart1.Chart.CategoryX.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.CategoryY.Font = null;
            this.ucChart1.Chart.CategoryY.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.ChartBackColor = System.Drawing.SystemColors.Info;
            this.ucChart1.Chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart1.Chart.MarginBackColor = System.Drawing.Color.White;
            this.ucChart1.Chart.ResumeLayout();
            this.ucChart1.Location = new System.Drawing.Point(224, -24);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(568, 584);
            this.ucChart1.TabIndex = 28;
            // 
            // butBieudo
            // 
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(12, 492);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(102, 25);
            this.butBieudo.TabIndex = 27;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.Click += new System.EventHandler(this.butBieudo_Click);
            // 
            // style
            // 
            this.style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.style.Items.AddRange(new object[] {
            "Bar",
            "BarStacked",
            "Bar100Pct",
            "Line",
            "LineStacked",
            "Line100Pct",
            "Pie",
            "Area",
            "AreaStacked",
            "Area100Pct"});
            this.style.Location = new System.Drawing.Point(280, 4);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(504, 21);
            this.style.TabIndex = 30;
            this.style.SelectedIndexChanged += new System.EventHandler(this.style_SelectedIndexChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(116, 492);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(102, 25);
            this.butKetthuc.TabIndex = 31;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "&Biểu đồ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(124, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-2, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số liệu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solieu
            // 
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(60, 26);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(160, 21);
            this.solieu.TabIndex = 2;
            this.solieu.SelectedIndexChanged += new System.EventHandler(this.solieu_SelectedIndexChanged);
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-4, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tỉnh/TP :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-4, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Q/Huyện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-6, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "P.xã :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(60, 48);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(160, 21);
            this.matt.TabIndex = 3;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maqu
            // 
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(60, 70);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(160, 21);
            this.maqu.TabIndex = 4;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(60, 92);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(160, 21);
            this.maphuongxa.TabIndex = 5;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // mann
            // 
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(60, 136);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(160, 21);
            this.mann.TabIndex = 9;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-4, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "N. nghề :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(60, 158);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(160, 21);
            this.madantoc.TabIndex = 10;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-4, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Dân tộc :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(60, 180);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(160, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-1, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 21;
            this.label10.Text = "Đối tượng :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(60, 202);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(160, 21);
            this.makp.TabIndex = 12;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-17, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Kh/Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhantu
            // 
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(60, 224);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(160, 21);
            this.nhantu.TabIndex = 13;
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-17, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 26;
            this.label12.Text = "Nhận từ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dentu
            // 
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(60, 246);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(160, 21);
            this.dentu.TabIndex = 14;
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-12, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Nơi G thiệu :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xutri
            // 
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(60, 268);
            this.xutri.Name = "xutri";
            this.xutri.Size = new System.Drawing.Size(160, 21);
            this.xutri.TabIndex = 15;
            this.xutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xutri_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(-19, 268);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 23);
            this.label14.TabIndex = 30;
            this.label14.Text = "Xử trí :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(60, 114);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(72, 21);
            this.phai.TabIndex = 6;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(-20, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 32;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ketqua
            // 
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(60, 290);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(160, 21);
            this.ketqua.TabIndex = 16;
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(-17, 290);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 23);
            this.label16.TabIndex = 34;
            this.label16.Text = "Kết quả :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhtrang
            // 
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Location = new System.Drawing.Point(60, 312);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(160, 21);
            this.tinhtrang.TabIndex = 17;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(-17, 311);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 36;
            this.label17.Text = "Tình trạng :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(5, 334);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 37;
            this.label18.Text = "Mã ICD :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(60, 334);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(48, 21);
            this.maicd.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(127, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 23);
            this.label19.TabIndex = 7;
            this.label19.Text = "Tuổi :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(170, 114);
            this.tuoi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(32, 21);
            this.tuoi.TabIndex = 7;
            // 
            // chktuoi
            // 
            this.chktuoi.Location = new System.Drawing.Point(205, 113);
            this.chktuoi.Name = "chktuoi";
            this.chktuoi.Size = new System.Drawing.Size(16, 24);
            this.chktuoi.TabIndex = 8;
            this.toolTip2.SetToolTip(this.chktuoi, "Cập nhật thống kê theo độ tuổi ");
            this.chktuoi.CheckStateChanged += new System.EventHandler(this.chktuoi_CheckStateChanged);
            this.chktuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chktuoi_KeyDown);
            // 
            // chkmaicd
            // 
            this.chkmaicd.Location = new System.Drawing.Point(111, 333);
            this.chkmaicd.Name = "chkmaicd";
            this.chkmaicd.Size = new System.Drawing.Size(16, 24);
            this.chkmaicd.TabIndex = 19;
            this.toolTip2.SetToolTip(this.chkmaicd, "Chọn thống kê theo danh sách ICD10");
            this.chkmaicd.CheckStateChanged += new System.EventHandler(this.chkmaicd_CheckStateChanged);
            this.chkmaicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkmaicd_KeyDown);
            // 
            // vebieudo
            // 
            this.vebieudo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vebieudo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vebieudo.Location = new System.Drawing.Point(60, 466);
            this.vebieudo.Name = "vebieudo";
            this.vebieudo.Size = new System.Drawing.Size(160, 21);
            this.vebieudo.TabIndex = 26;
            this.vebieudo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vebieudo_KeyDown);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(-2, 463);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 43;
            this.label20.Text = "Vẽ theo :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(168, 334);
            this.mapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(52, 21);
            this.mapt.TabIndex = 20;
            this.mapt.Validated += new System.EventHandler(this.mapt_Validated);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(127, 333);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 23);
            this.label21.TabIndex = 45;
            this.label21.Text = "PTTT :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vocam
            // 
            this.vocam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vocam.Location = new System.Drawing.Point(60, 378);
            this.vocam.Name = "vocam";
            this.vocam.Size = new System.Drawing.Size(160, 21);
            this.vocam.TabIndex = 22;
            this.vocam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vocam_KeyDown);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(-33, 378);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 23);
            this.label22.TabIndex = 48;
            this.label22.Text = "PP Vô cảm :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(60, 400);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(160, 21);
            this.taibien.TabIndex = 23;
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taibien_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(-2, 399);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 50;
            this.label23.Text = "Tai biến :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhhinh
            // 
            this.tinhhinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhhinh.Location = new System.Drawing.Point(60, 444);
            this.tinhhinh.Name = "tinhhinh";
            this.tinhhinh.Size = new System.Drawing.Size(160, 21);
            this.tinhhinh.TabIndex = 25;
            this.tinhhinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhhinh_KeyDown);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(-11, 443);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 52;
            this.label24.Text = "Tình hình PT :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuvong
            // 
            this.tuvong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuvong.Location = new System.Drawing.Point(60, 422);
            this.tuvong.Name = "tuvong";
            this.tuvong.Size = new System.Drawing.Size(160, 21);
            this.tuvong.TabIndex = 24;
            this.tuvong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuvong_KeyDown);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(-28, 422);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 23);
            this.label25.TabIndex = 54;
            this.label25.Text = "Tử vong PT :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaipt
            // 
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(60, 356);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(160, 21);
            this.loaipt.TabIndex = 21;
            this.loaipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaipt_KeyDown);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(-13, 355);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 23);
            this.label26.TabIndex = 56;
            this.label26.Text = "Loại PTTT :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Location = new System.Drawing.Point(736, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 471);
            this.panel1.TabIndex = 57;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(156, 3);
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
            this.tu.Location = new System.Drawing.Point(60, 3);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // frmBieudo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.vocam);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tinhhinh);
            this.Controls.Add(this.tuvong);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.vebieudo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkmaicd);
            this.Controls.Add(this.chktuoi);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dentu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nhantu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.style);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.ucChart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBieudo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê số liệu theo biểu đồ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBieudo_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmBieudo_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 

		private void butBieudo_Click(object sender, System.EventArgs e)
		{
			ucChart1.Chart.Series.Items.Clear();
			ucChart1.Chart.CategoryX.Items.Clear();
			panel1.Controls.Clear();
			try
			{
				if (vebieudo.SelectedValue.ToString()!="CANNANG")
				{
					DataRow dr=m.getrowbyid(tmpve,"loai='"+vebieudo.Text+"'");
					sql=dr[3].ToString();
					tmp=m.get_data(sql).Tables[0];
				}
				laysolieu();
				ucChart1.Chart.CategoryX.Items.Add(new ChartCategory(vebieudo.Text.ToUpper(),0));
				int i=0;
				foreach(DataRow r in dt.Rows)
				{
					float [] f={float.Parse(r["so"].ToString())};
					ucChart1.Chart.Series.Items.Add(new ChartSerie(m.getColor(i),Color.Black,f));
					title(r["ten"].ToString(),r["so"].ToString(),i,i*26+8);//40
					i++;
				}
				ucChart1.Refresh();		
			}
			catch{}
		}
		
		private void title(string ten,string so,int ind,int y)
		{
			toolTip1=new ToolTip();
			lbl=new Label();
			lbl.Text=(vebieudo.SelectedIndex==0 || vebieudo.SelectedIndex==7)?ten:so;
			lbl.Location = new Point(5,y);//736
			lbl.Size = new Size(50, 23);
			lbl.TextAlign = ContentAlignment.MiddleCenter;
			lbl.BackColor=m.getColor(ind);
			if (vebieudo.SelectedValue.ToString()!="CANNANG")
			{
				DataRow r=m.getrowbyid(tmp,"ma='"+ten+"'");
				if (r!=null)
					toolTip1.SetToolTip(lbl,r[1].ToString().Trim()+"("+so+")");
				else
					toolTip1.SetToolTip(lbl,
lan.Change_language_MessageText("Không có trong danh mục ICD10 (")+so+")");
			}
			else toolTip1.SetToolTip(lbl,ten.Trim()+"("+so+")");
			toolTip1.Active=true;
			this.panel1.Controls.Add(lbl);
			lbl.BringToFront();
		}

		private void style_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (style.SelectedIndex)
			{
                case 0 : ucChart1.Chart.ChartType = ChartTypes.Bar;
					break;
				case 1 : ucChart1.Chart.ChartType = ChartTypes.AreaStacked;
					break;
				case 2 : ucChart1.Chart.ChartType = ChartTypes.Bar100Pct;
					break;
				case 3 : ucChart1.Chart.ChartType = ChartTypes.Line;
					break;
				case 4 : ucChart1.Chart.ChartType = ChartTypes.LineStacked;
					break;
				case 5 : ucChart1.Chart.ChartType = ChartTypes.Line100Pct;
					break;
				case 6 : ucChart1.Chart.ChartType = ChartTypes.Pie;
					break;
				case 7 : ucChart1.Chart.ChartType = ChartTypes.Area;
					break;
				case 8 : ucChart1.Chart.ChartType = ChartTypes.AreaStacked;
					break;
				case 9 : ucChart1.Chart.ChartType = ChartTypes.Area100Pct;
					break;
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmBieudo_Load(object sender, System.EventArgs e)
		{
			xutri.DisplayMember="TEN";
			xutri.ValueMember="MA";
			xutri.DataSource=m.get_data("select * from "+m.user+".xutrikb").Tables[0];

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
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + m.user + ".doituong order by madoituong").Tables[0];

			nhantu.DisplayMember="TEN";
			nhantu.ValueMember="MA";
            nhantu.DataSource = m.get_data("select * from " + m.user + ".nhantu order by ma").Tables[0];

			dentu.DisplayMember="TEN";
			dentu.ValueMember="MA";
            dentu.DataSource = m.get_data("select * from " + m.user + ".dentu order by ma").Tables[0];

			ketqua.DisplayMember="TEN";
			ketqua.ValueMember="MA";
            ketqua.DataSource = m.get_data("select * from " + m.user + ".ketqua order by ma").Tables[0];

			tinhtrang.DisplayMember="TEN";
			tinhtrang.ValueMember="MA";

			vocam.DisplayMember="TEN";
			vocam.ValueMember="MA";
            vocam.DataSource = m.get_data("select * from " + m.user + ".dmmete order by ma").Tables[0];

			loaipt.DisplayMember="TEN";
			loaipt.ValueMember="MA";
            loaipt.DataSource = m.get_data("select * from " + m.user + ".loaipttt order by ma").Tables[0];

			taibien.DisplayMember="TEN";
			taibien.ValueMember="MA";
            taibien.DataSource = m.get_data("select * from " + m.user + ".taibienpt order by ma").Tables[0];

			tinhhinh.DisplayMember="TEN";
			tinhhinh.ValueMember="MA";
            tinhhinh.DataSource = m.get_data("select * from " + m.user + ".tinhhinhpt order by ma").Tables[0];
			
			tuvong.DisplayMember="TEN";
			tuvong.ValueMember="MA";
            tuvong.DataSource = m.get_data("select * from " + m.user + ".tuvongpt order by ma").Tables[0];

			dsxml.ReadXml("..//..//..//xml//dmsolieu.xml");
			solieu.DisplayMember="LOAI";
			solieu.ValueMember="SQL";
			solieu.DataSource=dsxml.Tables[0];

			vebieudo.DisplayMember="LOAI";
			vebieudo.ValueMember="FIELDS";

			style.SelectedIndex=0;
			vebieudo.SelectedIndex=0;
			solieu.SelectedIndex=0;
            dt = m.get_data("select * from " + m.user + ".dmvebieudo").Tables[0];
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}

		private void frmBieudo_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
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
			ketqua.SelectedIndex=-1;
			tinhtrang.SelectedIndex=-1;
			vocam.SelectedIndex=-1;
			tinhhinh.SelectedIndex=-1;
			loaipt.SelectedIndex=-1;
			taibien.SelectedIndex=-1;
			tuvong.SelectedIndex=-1;
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chktuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void xutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chkmaicd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}	

		private void loaipt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void vocam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void taibien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tinhhinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void vebieudo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_quan();
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_pxa();
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
			}
			catch{}
		}

		private void mapt_Validated(object sender, System.EventArgs e)
		{
			if (mapt.Text!="")
			{
                dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, mapt.Text, "", true);
				f.ShowDialog();
				if (f.m_mapt!="") mapt.Text=f.m_mapt;
			}		
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

		private void solieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			emp_text();
			xutri.Enabled=solieu.SelectedIndex==0;
            sql = "select * from " + m.user + ".btdkp_bv where ";
			if (xutri.Enabled) sql+=" loai=1 ";
			else sql+=" loai=0";
			sql+=" order by makp";
			makp.DataSource=m.get_data(sql).Tables[0];
			makp.SelectedIndex=-1;
			ketqua.Enabled=(solieu.SelectedIndex==4 || solieu.SelectedIndex==5 || solieu.SelectedIndex==1);
			tinhtrang.Enabled=ketqua.Enabled;
			mapt.Enabled=solieu.SelectedIndex==6;
			tinhhinh.Enabled=mapt.Enabled;
			taibien.Enabled=mapt.Enabled;
			tuvong.Enabled=mapt.Enabled;
			loaipt.Enabled=mapt.Enabled;
			vocam.Enabled=mapt.Enabled;
			maicd.Enabled=!mapt.Enabled;
			if (mapt.Enabled) nhantu.Enabled=false;
			nhantu.Enabled=solieu.SelectedIndex<4;
			dentu.Enabled=nhantu.Enabled;
            sql = "select * from " + m.user + ".ttxk";
			if (solieu.SelectedIndex==5) sql+=" where rakhoa=0";
			sql+=" order by ma";
			tinhtrang.DataSource=m.get_data(sql).Tables[0];
			tinhtrang.SelectedIndex=-1;
			sql="select * from "+m.user+".dmbieudo";
			if (solieu.SelectedIndex==0)
				sql+=" where stt not in (12,13,15,16,17,18,19,20,21,22)";
			else if (solieu.SelectedIndex==6)
				sql+=" where stt not in (10,11,12,13,14,20,21,22)";
			else if (solieu.SelectedIndex==2 || solieu.SelectedIndex==3)
				sql+=" where stt not in (12,13,14,15,16,17,18,19,20,21,22)";
			else if (solieu.SelectedIndex==4 || solieu.SelectedIndex==5)
				sql+=" where stt not in (10,11,14,15,16,17,18,19,20,21,22)";
			else if (solieu.SelectedIndex==7)
				sql+=" where stt not in (12,13,14,15,16,17,18,19)";
			else sql+=" where stt not in (14,15,16,17,18,19,20,21,22)";
			sql+=" order by stt";
			tmpve=m.get_data(sql.Replace("medibv",m.user)).Tables[0];
			vebieudo.DataSource=tmpve;
		}

		private void laysolieu()
		{
			sql=solieu.SelectedValue.ToString();
            sql = sql.Replace("medibvmmyy", "xxx");
            sql = sql.Replace("medibv", m.user);
			if (tu.Text!="")
				if (solieu.SelectedIndex==4)
					sql+=" and "+m.for_ngay("d.ngay","'"+m.f_ngay+"'")+" between to_date('"+tu.Text+"','"+m.f_ngay+"') and to_date('"+den.Text+"','"+m.f_ngay+"')";
				else if (solieu.SelectedIndex==5)
                    sql += " and " + m.for_ngay("c.ngay", "'" + m.f_ngay + "'") + " between to_date('" + tu.Text + "','" + m.f_ngay + "') and to_date('" + den.Text + "','" + m.f_ngay + "')";
				else
                    sql += " and " + m.for_ngay("b.ngay", "'" + m.f_ngay + "'") + " between to_date('" + tu.Text + "','" + m.f_ngay + "') and to_date('" + den.Text + "','" + m.f_ngay + "')";
			if (phai.SelectedIndex!=-1)
				if (solieu.SelectedIndex==7)
					sql+=" and c.phai="+phai.SelectedIndex;
				else
					sql+=" and a.phai="+phai.SelectedIndex;
			if (mann.SelectedIndex!=-1)
				sql+=" and a.mann='"+mann.SelectedValue.ToString()+"'";
			if (madantoc.SelectedIndex!=-1)
				sql+=" and a.madantoc='"+madantoc.SelectedValue.ToString()+"'";
			if (matt.SelectedIndex!=-1)
				sql+=" and a.matt='"+matt.SelectedValue.ToString()+"'";
			if (maqu.SelectedIndex!=-1)
				sql+=" and a.maqu='"+maqu.SelectedValue.ToString()+"'";
			if (maphuongxa.SelectedIndex!=-1)
				sql+=" and a.maphuongxa='"+maphuongxa.SelectedValue.ToString()+"'";
			if (makp.SelectedIndex!=-1)
			{
				if (solieu.SelectedIndex==4 || solieu.SelectedIndex==5)
					sql+=" and c.makp='"+makp.SelectedValue.ToString()+"'";
				else
					sql+=" and b.makp='"+makp.SelectedValue.ToString()+"'";
			}
			if (maicd.Text!="")
			{
				if (solieu.SelectedIndex==4 || solieu.SelectedIndex==5)
					sql+=" and c.maicd='"+maicd.Text+"'";
				else
					sql+=" and b.maicd='"+maicd.Text+"'";
			}
			if (madoituong.SelectedIndex!=-1)
				sql+=" and madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			if (dentu.SelectedIndex!=-1)
				sql+=" and dentu="+int.Parse(dentu.SelectedValue.ToString());
			if (nhantu.SelectedIndex!=-1)
				sql+=" and nhantu="+int.Parse(nhantu.SelectedValue.ToString());
			if (xutri.SelectedIndex!=-1)
                sql+=" and ttlucrv="+int.Parse(xutri.SelectedValue.ToString());
			if (ketqua.SelectedIndex!=-1)
				sql+=" and ketqua="+int.Parse(ketqua.SelectedValue.ToString());
			if (tinhtrang.SelectedIndex!=-1)
			{
				if (solieu.SelectedIndex==4)
					sql+=" and ttlucrk="+int.Parse(tinhtrang.SelectedValue.ToString());					
				else
					sql+=" and ttlucrv="+int.Parse(tinhtrang.SelectedValue.ToString());
			}
			if (tuoi.Text!="")
				sql+=" and to_number(to_date(now(),'yyyy'))-to_number(a.namsinh)<="+tuoi.Text;
			if (mapt.Text!="")
				sql+=" and mapt='"+mapt.Text+"'";
			if (loaipt.SelectedIndex!=-1)
				sql+=" and loaipt="+int.Parse(loaipt.SelectedValue.ToString());
			if (tinhhinh.SelectedIndex!=-1)
				sql+=" and tinhhinh="+int.Parse(tinhhinh.SelectedValue.ToString());
			if (vocam.SelectedIndex!=-1)
				sql+=" and phuongphap="+int.Parse(vocam.SelectedValue.ToString());
			if (taibien.SelectedIndex!=-1)
				sql+=" and taibien="+int.Parse(taibien.SelectedValue.ToString());
			if (tuvong.SelectedIndex!=-1)
				sql+=" and tuvong="+int.Parse(tuvong.SelectedValue.ToString());
			if (chkmaicd.Checked)
			{
				if (solieu.SelectedIndex==4)
					sql+=" and d.maicd in (select ma from "+m.user+".dmicd10)";
				else if (solieu.SelectedIndex==5)
                    sql += " and c.maicd in (select ma from " + m.user + ".dmicd10)";
				else
                    sql += " and b.maicd in (select ma from " + m.user + ".dmicd10)";
			}
			dt.Clear();
            if (sql.IndexOf("xxx") >= 0)
                ds = m.get_data_mmyy(sql, tu.Text, den.Text, false);
            else
			    ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				return;
			}
			string ma="";
            dttuoi = m.get_data("select * from " + m.user + ".dmtuoi").Tables[0];
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				if (vebieudo.SelectedIndex==1)
				{
					foreach(DataRow r1 in dttuoi.Rows)
					{
						if (int.Parse(r1["den"].ToString())!=0)
						{
							if (int.Parse(r["tuoi"].ToString())>=int.Parse(r1["tu"].ToString()) && int.Parse(r["tuoi"].ToString())<=int.Parse(r1["den"].ToString()))
							{
								ma=r1["ma"].ToString();
								break;
							}
						}
						else 
						{
							if (int.Parse(r["tuoi"].ToString())>=int.Parse(r1["tu"].ToString()))
							{
								ma=r1["ma"].ToString();
								break;
							}
						}
					}
				}
				else ma=r[vebieudo.SelectedValue.ToString()].ToString();
				m.u_bieudo(dt,ma,ma,1);
			}
		}

		private void chkmaicd_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (chkmaicd.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmmaicd f=new frmDmmaicd(m);
					f.ShowDialog();
				}
				vebieudo.SelectedIndex=0;
			}
		}

		private void chktuoi_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (chktuoi.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn cập nhật lại độ tuổi không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmtuoi f=new frmDmtuoi(m);
					f.ShowDialog();
				}
				vebieudo.SelectedIndex=1;
			}
		}
	}
}
