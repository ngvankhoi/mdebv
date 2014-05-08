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
	/// Summary description for frmTkvaovien.
	/// </summary>
	public class frmThnhiem : System.Windows.Forms.Form
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
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox makp;
		private DataSet ds=new DataSet();
		private DataSet dssl=new DataSet();
		private DataSet dsdt=new DataSet();
		private DataSet dsnoitru=new DataSet();
		private DataSet dsngtru=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataColumn dc;
		private AccessData m;
		private bool bClear=true;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.ToolTip toolTip1;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.ComboBox solieu;
		private System.Windows.Forms.ComboBox ve;
		private System.Windows.Forms.CheckBox butBieudo;
		private WebTel.Drawing.Chart.ucChart ucChart1;
		private System.Windows.Forms.Panel panel1;
		private Label lbl1;
		private System.ComponentModel.IContainer components;
        private string s_user = "";
        public frmThnhiem(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThnhiem));
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
            this.ve = new System.Windows.Forms.ComboBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.solieu = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.butBieudo = new System.Windows.Forms.CheckBox();
            this.ucChart1 = new WebTel.Drawing.Chart.ucChart();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(123, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(441, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Biểu đồ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(680, 36);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(104, 21);
            this.madantoc.TabIndex = 7;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(332, 36);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(276, 21);
            this.mann.TabIndex = 6;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(332, 60);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(198, 21);
            this.maqu.TabIndex = 9;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(71, 60);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(185, 21);
            this.matt.TabIndex = 8;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(608, 60);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(176, 21);
            this.maphuongxa.TabIndex = 10;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(528, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Phường/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(255, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(15, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(255, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Nghề nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(624, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(-7, 36);
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
            this.makp.Location = new System.Drawing.Point(71, 36);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(185, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(608, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Độ tuổi :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(271, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 62;
            this.label19.Text = "Số liệu :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ve
            // 
            this.ve.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ve.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ve.Location = new System.Drawing.Point(504, 12);
            this.ve.Name = "ve";
            this.ve.Size = new System.Drawing.Size(128, 21);
            this.ve.TabIndex = 3;
            this.ve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ve_KeyDown);
            // 
            // dotuoi
            // 
            this.dotuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(680, 12);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(104, 21);
            this.dotuoi.TabIndex = 4;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // solieu
            // 
            this.solieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solieu.Location = new System.Drawing.Point(332, 12);
            this.solieu.Name = "solieu";
            this.solieu.Size = new System.Drawing.Size(116, 21);
            this.solieu.TabIndex = 2;
            this.solieu.SelectedIndexChanged += new System.EventHandler(this.solieu_SelectedIndexChanged);
            this.solieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 72);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 408);
            this.dataGrid1.TabIndex = 23;
            // 
            // butTim
            // 
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(220, 488);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(82, 25);
            this.butTim.TabIndex = 11;
            this.butTim.Text = " &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(302, 488);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(82, 25);
            this.butIn.TabIndex = 12;
            this.butIn.Text = " &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(478, 488);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(92, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(8, 488);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(176, 23);
            this.lbl.TabIndex = 64;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(193, 12);
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
            this.tu.Location = new System.Drawing.Point(71, 12);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // butBieudo
            // 
            this.butBieudo.Appearance = System.Windows.Forms.Appearance.Button;
            this.butBieudo.BackColor = System.Drawing.Color.Transparent;
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(384, 488);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(94, 25);
            this.butBieudo.TabIndex = 13;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.butBieudo.UseVisualStyleBackColor = false;
            this.butBieudo.CheckedChanged += new System.EventHandler(this.butBieudo_CheckedChanged);
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
            this.ucChart1.Location = new System.Drawing.Point(8, 89);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(768, 395);
            this.ucChart1.TabIndex = 68;
            this.ucChart1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Location = new System.Drawing.Point(707, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 393);
            this.panel1.TabIndex = 69;
            this.panel1.Visible = false;
            // 
            // frmThnhiem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucChart1);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.ve);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.den);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.solieu);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThnhiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp bệnh nhiễm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThnhiem_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkravien_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThnhiem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmThnhiem_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			
			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
            mann.DataSource = m.get_data("select * from " + s_user + ".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + s_user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + s_user + ".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();
			
			dsnoitru.ReadXml("..//..//..//xml//ve_noitru.xml");
			dsngtru.ReadXml("..//..//..//xml//ve_ngtru.xml");
			dssl.ReadXml("..//..//..//xml//th_nhiem.xml");
			dsdt.ReadXml("..//..//..//xml//dotuoi.xml");
			dsxml.ReadXml("..//..//..//xml//bcnhiem.xml");
			solieu.DisplayMember="ten";
			solieu.ValueMember="sql";
			solieu.DataSource=dssl.Tables[0];
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dotuoi.DataSource=dsdt.Tables[0];
			ve.DisplayMember="ten";
			ve.ValueMember="ma";
			ve.DataSource=dsnoitru.Tables[0];
            ds = m.get_data("select * from " + s_user + ".capid where ma=0");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
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
			maphuongxa.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + s_user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + s_user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
			}
			catch{}
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
            if (den.Text == "") den.Text = tu.Text;
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
			Cursor=Cursors.WaitCursor;
			string sql=solieu.SelectedValue.ToString();
            string stime = "'" + m.f_ngay + "'";
            if (tu.Text != "")
                sql += (!m.bNgayrv(sql)) ? " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")" : " and " + m.for_ngay("a.ngayrv", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (mann.SelectedIndex!=-1)
				sql+=" and c.mann='"+mann.SelectedValue.ToString()+"'";
			if (madantoc.SelectedIndex!=-1)
				sql+=" and c.madantoc='"+madantoc.SelectedValue.ToString()+"'";
			if (matt.SelectedIndex!=-1)
				sql+=" and c.matt='"+matt.SelectedValue.ToString()+"'";
			if (maqu.SelectedIndex!=-1)
				sql+=" and c.maqu='"+maqu.SelectedValue.ToString()+"'";
			if (maphuongxa.SelectedIndex!=-1)
				sql+=" and c.maphuongxa='"+maphuongxa.SelectedValue.ToString()+"'";
			if (makp.SelectedIndex!=-1)
				if (solieu.SelectedIndex==5)
					sql+=" and d.makp='"+makp.SelectedValue.ToString()+"'";
				else
					sql+=" and a.makp='"+makp.SelectedValue.ToString()+"'";
            if (dotuoi.SelectedIndex != -1)
            {
                //string m_dotuoi = dotuoi.SelectedValue.ToString();
                //if (m_dotuoi.IndexOf(">") != -1)
                //    sql += " and to_number(to_char(now(),'yyyy'),'0000')-to_number(c.namsinh,'0000')>" + int.Parse(m_dotuoi.Substring(1));
                //else
                //{
                //    int i1 = int.Parse(m_dotuoi.Substring(0, m_dotuoi.IndexOf("-")));
                //    int i2 = int.Parse(m_dotuoi.Substring(m_dotuoi.IndexOf("-") + 1));
                //    sql += " and to_number(to_char(now(),'yyyy'),'0000')-to_number(c.namsinh,'0000') between " + i1 + " and " + i2;
                //}
                string s_dotuoi = dotuoi.SelectedValue.ToString();                
                if (s_dotuoi.Trim() == "<1TH")
                {
                    sql += " and c.ngaysinh is not null and extract(day from(to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')-to_date(to_char(c.ngaysinh,'dd/mm/yyyy'),'dd/mm/yyyy'))) < 31 ";//DUOI 1 THANG
                }
                else if (s_dotuoi.Trim() == "<1T")
                {
                    sql += " and c.ngaysinh is not null and extract(day from(to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')-to_date(to_char(c.ngaysinh,'dd/mm/yyyy'),'dd/mm/yyyy'))) between 31 and 365 ";//DUOI 1 TUOI
                }
                else if (s_dotuoi.IndexOf(">") != -1)
                    sql += " and to_number(to_char(a.ngay,'yyyy'),'0000')-to_number(c.namsinh,'0000')>" + int.Parse(s_dotuoi.Substring(1));
                else
                {
                    int i1 = int.Parse(s_dotuoi.Substring(0, s_dotuoi.IndexOf("-")));
                    int i2 = int.Parse(s_dotuoi.Substring(s_dotuoi.IndexOf("-") + 1));
                    sql += " and to_number(to_char(a.ngay,'yyyy'),'0000')-to_number(c.namsinh,'0000') between " + i1 + " and " + i2;
                }
            }
			DataRow r=m.getrowbyid(dssl.Tables[0],"ten='"+solieu.Text+"'");
			if (r!=null)
			{
				if (!m.bBenhkhac) sql+=" and "+r["cont"].ToString();
				sql+=" group by "+r["stt"].ToString()+" order by "+r["stt"].ToString();
			}
            sql = m.replace(sql);
            ds = (sql.IndexOf("xxx") < 0) ? m.get_data(sql) : (tu.Text.Length == 10) ? m.get_data_mmyy(sql, tu.Text, den.Text, false) : m.get_data_yy(DateTime.Now.Year.ToString(), sql);
            ds = m.get_sum(ds, new string[] { "stt" }, new string[] { "c01", "c02", "c03", "c04", "c05", "c06", "c07", "c08", "c09", "c10", "c11", "c12", "c13", "c14", "c15", "c16", "c17", "c18" });
            
            dc=new DataColumn();
			dc.ColumnName="nhom";
			dc.DataType=Type.GetType("System.String");
			ds.Tables[0].Columns.Add(dc);
			foreach(DataRow r1 in ds.Tables[0].Rows)
			{
				r=m.getrowbyid(dsxml.Tables[0],"stt='"+r1["stt"].ToString()+"'");
				if (r!=null)
				{
					r1["nhom"]=r["nhom"].ToString();
					r1["stt"]=r["ten"].ToString();
				}
			}
            
			dataGrid1.DataSource=ds.Tables[0];
			lbl.Text="TỔNG SỐ : "+ds.Tables[0].Rows.Count.ToString();
			Cursor=Cursors.Default;
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
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Nhóm";
			TextCol.Width = 220;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c01";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c02";
			TextCol.HeaderText = "<2Tháng";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c03";
			TextCol.HeaderText = "2Th-1T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c04";
			TextCol.HeaderText = "1-5T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c05";
			TextCol.HeaderText = "5-15T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c06";
			TextCol.HeaderText = ">=15T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c07";
			TextCol.HeaderText = "TV:<2Th";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c08";
			TextCol.HeaderText = "TV:2Th-1T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c09";
			TextCol.HeaderText = "TV:1-5T";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c10";
			TextCol.HeaderText = "Tổng TV";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c11";
			TextCol.HeaderText = "Tử <24 giờ";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c12";
			TextCol.HeaderText = "Ra viện";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c13";
			TextCol.HeaderText = "Xin về";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c14";
			TextCol.HeaderText = "Bỏ về";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c15";
			TextCol.HeaderText = "Đưa về";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c16";
			TextCol.HeaderText = "Ch khoa";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "c17";
			TextCol.HeaderText = "Ch viện";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
				}
				string tuden=(tu.Text=="")?"":" Từ ngày "+tu.Text+" đến "+den.Text;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,solieu.Text.ToUpper()+" "+tuden,"rptThnhiem.rpt");
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

		private void frmTkravien_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmThnhiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
				if (solieu.SelectedIndex==0)
				{
                    makp.DataSource = m.get_data("select * from " + s_user + ".btdkp_bv where loai=1 order by makp").Tables[0];
					ve.DataSource=dsngtru.Tables[0];
				}
				else
				{
                    makp.DataSource = m.get_data("select * from " + s_user + ".btdkp_bv where loai=0 order by makp").Tables[0];
					ve.DataSource=dsnoitru.Tables[0];
				}
				makp.SelectedIndex=-1;
			}
			catch{}
		}

		private void ve_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butBieudo_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				tu.Focus();
				return;
			}
			ucChart1.Visible=butBieudo.Checked;
			panel1.Visible=ucChart1.Visible;
			if (panel1.Visible)
			{
				panel1.BringToFront();
				ucChart1.Chart.ChartType = ChartTypes.Bar;
				ucChart1.Chart.Series.Items.Clear();
				ucChart1.Chart.CategoryX.Items.Clear();
				panel1.Controls.Clear();
				try
				{
					string stt;
					ucChart1.Chart.CategoryX.Items.Add(new ChartCategory(ve.Text.ToUpper(),0));
					int i=0;
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						if (r[ve.SelectedValue.ToString()].ToString()!="0")
						{
							stt=r["stt"].ToString();
							float [] f={float.Parse(r[ve.SelectedValue.ToString()].ToString())};
							ucChart1.Chart.Series.Items.Add(new ChartSerie(m.getColor(i),Color.Black,f));
							title(stt,stt.Substring(0,stt.IndexOf(":")),i,i*26+8,decimal.Parse(r[ve.SelectedValue.ToString()].ToString()));//40
							i++;
						}
					}
					ucChart1.Refresh();		
				}
				catch{}
			}
		}

		private void title(string ten,string so,int ind,int y,decimal solieu)
		{
			toolTip1=new ToolTip();
			lbl1=new Label();
			lbl1.Text=so;
			lbl1.Location = new Point(5,y);//736
			lbl1.Size = new Size(50, 23);
			lbl1.TextAlign = ContentAlignment.MiddleCenter;
			lbl1.BackColor=m.getColor(ind);
			toolTip1.SetToolTip(lbl1,ten.Trim()+"("+solieu.ToString().Trim()+")");
			toolTip1.Active=true;
			this.panel1.Controls.Add(lbl1);
			lbl1.BringToFront();
		}
	}
}
