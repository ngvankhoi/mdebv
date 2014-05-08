using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmCongno.
	/// </summary>
	public class frmCongno : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.DataGrid dataGrid1;
		private string sql,s_makp,s_madoituong,user,s_thuoc = "";
        private int iNhomvpthuoc,nhom,i_userid,i_loaiba;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m;
		private System.Windows.Forms.Button butExit;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private DataSet dstmp=new DataSet();
		private DataSet ds=new DataSet();
        private DataSet ds1 = new DataSet();
        private DataSet dsxml = new DataSet();
        private DataSet dsxmlth = new DataSet();
        private DataTable dtkp = new DataTable();
        private DataTable dtvp = new DataTable();
        private DataTable dtbd = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataSet dsss = new DataSet();
        private bool bClear = true, bVienphi_phongluu;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Label lbl3;
        private Button butIn;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private Label lbl;
        private Label label5;
        private TextBox mabn;
        private TextBox hoten;
        private Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCongno(LibMedi.AccessData acc,string _makp,string _madoituong,int _userid,int _loaiba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; s_madoituong = _madoituong; i_userid = _userid; i_loaiba = _loaiba;
            if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmCongno( string _makp, string _madoituong)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); i_loaiba = 1;
            m = new LibMedi.AccessData(); s_makp = _makp; s_madoituong = _madoituong;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongno));
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butExit = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(165, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(53, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(133, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(285, 5);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(118, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(245, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(398, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(461, 5);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(111, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(12, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(768, 445);
            this.dataGrid1.TabIndex = 14;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(437, 496);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 13;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(293, 496);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(74, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "&Tổng hợp";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(272, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 34);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(183, 11);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(81, 18);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Ra viện";
            // 
            // rb2
            // 
            this.rb2.Checked = true;
            this.rb2.Location = new System.Drawing.Point(79, 11);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(98, 18);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Đang điều trị";
            // 
            // rb1
            // 
            this.rb1.Location = new System.Drawing.Point(8, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 18);
            this.rb1.TabIndex = 0;
            this.rb1.Text = "Cả hai";
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(12, 460);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(212, 16);
            this.lbl1.TabIndex = 16;
            this.lbl1.Text = "Số ca :";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Red;
            this.lbl2.Location = new System.Drawing.Point(12, 476);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(212, 16);
            this.lbl2.TabIndex = 17;
            this.lbl2.Text = "Tổng chi phí :";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.Red;
            this.lbl3.Location = new System.Drawing.Point(12, 492);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(212, 16);
            this.lbl3.TabIndex = 18;
            this.lbl3.Text = "Trung bình :";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(367, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 19;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(710, 460);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 255;
            this.pic.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(272, 221);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(296, 40);
            this.lbl.TabIndex = 256;
            this.lbl.Text = "...";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(573, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 23);
            this.label5.TabIndex = 257;
            this.label5.Text = "Mã BN :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(619, 5);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(60, 21);
            this.mabn.TabIndex = 8;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(681, 5);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(109, 21);
            this.hoten.TabIndex = 259;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 16);
            this.label6.TabIndex = 260;
            this.label6.Text = "Tổng tạm ứng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCongno
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.lbl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCongno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongno_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmCongno_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCongno_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            pic.Visible = m.bHinh;
            user = m.user;
            nhom = m.nhom_duoc;
            iNhomvpthuoc = m.iNhomvpthuoc;
            groupBox1.Visible = i_loaiba == 1;
            foreach (DataRow r in m.get_data("select * from "+user+".v_nhomvp where ma=" + iNhomvpthuoc).Tables[0].Rows)
                s_thuoc = r["ten"].ToString().Trim();
            bVienphi_phongluu = m.bCapcuu_noitru;
            dtkp = m.get_data("select * from "+user+".d_duockp").Tables[0];
            sql = "select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
            sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom,a.bhyt,a.tenhc,trim(a.ten)||' '||trim(a.hamluong) as tenbd,a.gia_bh ";
            sql += ", a.kythuat,d.ma as manhomvp";//binh 230908
            if (m.bChenhlech_thuoc_dannhmuc) sql += ",a.chenhlech ";
            sql += ", a.kcct, a.kythuat, a.bhyt as bhyt_tt, a.sothe ";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d";
            sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
            dtbd = m.get_data(sql).Tables[0];
            sql = "select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom,a.bhyt";
            sql += ",a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.gia_cs,a.vattu_cs,a.chenhlech ";
            sql += ", a.kythuat,c.ma as manhomvp";//binh 230908
            sql += ", a.kcct, a.kythuat, a.bhyt_tt, a.sothe";
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
            sql += " where a.id_loai=b.id and b.id_nhom=c.ma ";
            dtvp = m.get_data(sql).Tables[0];
			sql="select * from "+user+".doituong where (mien=0 or madoituong=1)";
			if (s_madoituong!="") sql+=" and madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
            madoituong.DataSource = m.get_data(sql).Tables[0];
            madoituong.DisplayMember = "DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            string s = s_makp.Replace(",", "','");
            if (i_loaiba == 2)
            {
                sql = "select makp,tenkp from " + m.user + ".btdkp_bv where makp<>'01' and (maba like '%20%'";
                sql += " or maba like '%21%'";
                sql += " or maba like '%22%'";
                sql += " or maba like '%23%')";
                if (s_makp != "") sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                sql += " order by loai,makp";
            }
            else if (i_loaiba == 4) sql = "select makp,tenkp from " + m.user + ".btdkp_bv where loai=4";
            else
            {
                sql = "select * from " + user + ".btdkp_bv where loai=0";
                if (s_makp != "") sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
                sql += " order by loai,makp";
            }
			makp.DataSource=m.get_data(sql).Tables[0];
			dstmp.ReadXml("..//..//..//xml//m_chiphidt.xml");
			ds.ReadXml("..//..//..//xml//m_chiphidt.xml");
            ds.Tables[0].Columns.Add("bhyttra", typeof(decimal)).DefaultValue = 0;
            ds.Tables[0].Columns.Add("bntra", typeof(decimal)).DefaultValue = 0;
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            ds1.ReadXml("..//..//..//xml//m_ravien.xml");
            ds1.Tables[0].Columns.Add("chon", typeof(bool));
            ds1.Tables[0].Columns.Add("mabs");
            ds1.Tables[0].Columns.Add("tenbs");
            ds1.Tables[0].Columns.Add("makprv");
            ds1.Tables[0].Columns.Add("cholam");
            ds1.Tables[0].Columns.Add("gianovat", typeof(decimal));
            ds1.Tables[0].Columns.Add("idttrv", typeof(string));
            ds1.Tables[0].Columns.Add("sotientra", typeof(decimal));
            ds1.Tables[0].Columns.Add("traituyen", typeof(decimal));
            ds1.Tables[0].Columns.Add("kythuat", typeof(decimal));
            ds1.Tables[0].Columns.Add("loaikythuat", typeof(string));
            ds1.Tables[0].Columns.Add("quyenso_tt", typeof(string));
            ds1.Tables[0].Columns.Add("sobienlai_tt", typeof(string));

            dsxmlth.ReadXml("..//..//..//xml//v_bienlaidoc.xml");
            dsxml.ReadXml("..//..//..//xml//m_inravien.xml");
            try
            {
                dsxml.Tables[0].Columns.Add("mabsct",typeof(string));//gam 10/03/2012
            }
            catch { }
            dsxml.Tables[0].Columns.Add("Image", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("mabs");
            dsxml.Tables[0].Columns.Add("tenbs");
            dsxml.Tables[0].Columns.Add("makprv");
            dsxml.Tables[0].Columns.Add("cholam");
            dsxml.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("idttrv", typeof(string));
            dsxml.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxml.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsxml.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("loaikythuat", typeof(string));
            dsxml.Tables[0].Columns.Add("quyenso_tt", typeof(string));
            dsxml.Tables[0].Columns.Add("sobienlai_tt", typeof(string));
            try { dsxml.Tables[0].Columns.Add("ID_KTCAO", typeof(decimal)); }
            catch { }
            try { dsxml.Tables[0].Columns.Add("ID_VPKHOA", typeof(decimal)); }
            catch { }

            dsss.ReadXml("..//..//..//xml//m_ravienss.xml");
            dsss.Tables[0].Columns.Add("chon", typeof(bool));
            dsss.Tables[0].Columns.Add("mabs");
            dsss.Tables[0].Columns.Add("tenbs");
            dsss.Tables[0].Columns.Add("makprv");
            dsss.Tables[0].Columns.Add("cholam");
            dsss.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsss.Tables[0].Columns.Add("idttrv", typeof(string));
            dsss.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsss.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsss.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsss.Tables[0].Columns.Add("loaikythuat", typeof(string));
            dsss.Tables[0].Columns.Add("quyenso_tt", typeof(string));
            dsss.Tables[0].Columns.Add("sobienlai_tt", typeof(string));

            dtdt = m.get_data("select * from "+user+".doituong").Tables[0]; 
		}

		private void load_grid()
		{
            if (i_loaiba == 2)
            {
                sql = "select 0 as id,a.mabn,a.hoten,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += " case when b.ngayrv is null then ' ' else to_char(b.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql += " to_char(now(),'dd/mm/yyyy') as den,";
                sql += " 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien,";
                sql += " 00000000000.00 as tamung,00000000000.00 as conlai,f.mien,f.doituong,c.sothe";
                sql += " from " + user + ".btdbn a inner join " + user + ".benhanngtr b ";
                sql += " on a.mabn=b.mabn left join " + user + ".bhyt c ";
                sql += " on b.maql=c.maql inner join " + user + ".doituong f on b.madoituong=f.madoituong ";
                sql += " where (c.sudung is null or c.sudung=1)";
                sql += " and b.ttlucrv=0 and b.ngayrv is null";
                if (makp.SelectedIndex != -1) sql += " and b.makp='" + makp.SelectedValue.ToString() + "'";
                if (madoituong.SelectedIndex != -1) sql += " and b.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                if (mabn.Text != "" && hoten.Text != "") sql += " and a.mabn='" + mabn.Text + "'";
                sql += " order by b.makp,b.ngay desc";
                dstmp = m.get_data(sql);
            }
            else if (i_loaiba == 4)
            {
                sql = "select 0 as id,a.mabn,a.hoten,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += " case when b.ngayrv is null then ' ' else to_char(b.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql += " to_char(now(),'dd/mm/yyyy') as den,";
                sql += " 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien,";
                sql += " 00000000000.00 as tamung,00000000000.00 as conlai,f.mien,f.doituong,c.sothe";
                sql += " from " + user + ".btdbn a inner join xxx.benhancc b ";
                sql += " on a.mabn=b.mabn left join xxx.bhyt c ";
                sql += " on b.maql=c.maql inner join " + user + ".doituong f on b.madoituong=f.madoituong ";
                sql += " where (c.sudung is null or c.sudung=1)";
                sql += " and (b.ngayrv is null or to_date(to_char(b.ngayrv,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy'))";
                if (makp.SelectedIndex != -1) sql += " and b.makp='" + makp.SelectedValue.ToString() + "'";
                if (madoituong.SelectedIndex != -1) sql += " and b.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                if (mabn.Text != "" && hoten.Text != "") sql += " and a.mabn='" + mabn.Text + "'";
                sql += " order by b.makp,b.ngay desc";
                string s_nam = DateTime.Now.Year.ToString();
                string s_namtruoc = Convert.ToString(DateTime.Now.Year - 1);
                dstmp = m.get_data_yy(s_namtruoc, sql);
                dstmp.Merge(m.get_data_yy(s_nam, sql));
            }
            else
            {
                if (rb2.Checked)
                {
                    sql = "select d.id,a.mabn,a.hoten,b.maql,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += " case when e.ngay is null then ' ' else to_char(e.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += " to_char(now(),'dd/mm/yyyy') as den,";
                    sql += " 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien,";
                    sql += " 00000000000.00 as tamung,00000000000.00 as conlai,f.mien,f.doituong,c.sothe";
                    sql += " from " + user + ".btdbn a inner join " + user + ".benhandt b ";
                    sql += " on a.mabn=b.mabn left join " + user + ".bhyt c ";
                    sql += " on b.maql=c.maql inner join " + user + ".nhapkhoa d ";
                    sql += " on b.maql=d.maql left join " + user + ".xuatkhoa e ";
                    sql += " on d.id=e.id inner join " + user + ".doituong f on b.madoituong=f.madoituong ";
                    if (rb2.Checked) sql += " inner join " + user + ".hiendien g on d.id=g.id ";
                    sql += " where (c.sudung is null or c.sudung=1)";
                    if (makp.SelectedIndex != -1) sql += "  and d.makp='" + makp.SelectedValue.ToString() + "'";
                    if (madoituong.SelectedIndex != -1) sql += " and b.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                    if (rb2.Checked) sql += " and g.nhapkhoa=1 and g.xuatkhoa=0";
                    else
                    {
                        sql += " and " + m.for_ngay("d.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') ";
                        sql += " and to_date('" + den.Text + "','dd/mm/yyyy')";
                    }
                    if (mabn.Text != "" && hoten.Text != "") sql += " and a.mabn='" + mabn.Text + "'";
                    sql += " order by g.makp,g.ngay desc";
                }
                else
                {
                    sql = "select 0 as id,a.mabn,a.hoten,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += " case when d.ngay is null then ' ' else to_char(d.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += " to_char(now(),'dd/mm/yyyy') as den,";
                    sql += " 00000000000.00 as thuoc,00000000000.00 as vienphi,00000000000.00 as sotien,";
                    sql += " 00000000000.00 as tamung,00000000000.00 as conlai,f.mien,f.doituong,c.sothe";
                    sql += " from " + user + ".btdbn a inner join " + user + ".benhandt b ";
                    sql += " on a.mabn=b.mabn left join " + user + ".bhyt c on b.maql=c.maql ";
                    sql += " left join " + user + ".xuatvien d on b.maql=d.maql inner join " + user + ".doituong f ";
                    sql += " on b.madoituong=f.madoituong ";
                    sql += " where (c.sudung is null or c.sudung=1)";
                    if (madoituong.SelectedIndex != -1) sql += " and b.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                    sql += " and b.loaiba=1 and " + m.for_ngay("b.ngay", "'dd/mm/yyyy'") + " between ";
                    sql += " to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
                    if (mabn.Text != "" && hoten.Text != "") sql += " and a.mabn='" + mabn.Text + "'";
                    sql += " order by b.makp,b.ngay desc";
                }
                dstmp =m.get_data(sql);
            }			
			ds.Clear();
            ds = dstmp.Copy();
            //
            ds.Tables[0].Columns.Add("bhyttra", typeof(decimal)).DefaultValue = 0;
            ds.Tables[0].Columns.Add("bntra", typeof(decimal)).DefaultValue = 0;
            //
			get_data();
			dataGrid1.DataSource=ds.Tables[0];
            lbl1.Text = "Số ca :" + ds.Tables[0].Rows.Count.ToString();
		}

        private void get_data()
        {
            decimal d1 = 0, d2 = 0, d3 = 0, d4 = 0, tamung = 0, th = 0, vp = 0, th20 = 0, vp20 = 20, st = 0, bhyttra_th = 0, bhyttra_v = 0;
            lbl.Text = "";
            lbl.Visible = true;
            DataRow r6;
            int maphu = 0;
            int _madt = -1;
            decimal tcp_bhyt = 0, tcp_bntra=0;
            bool bBHYT_Traituyen_tinh_Tyle_khac=m.bBHYT_Traituyen_tinh_Tyle_khac;
            foreach (DataRow r in ds.Tables[0].Select("true"))//mabn='08999992'
            {
                lbl.Text = r["mabn"].ToString();
                lbl.Refresh();
                ins(r["mabn"].ToString(), decimal.Parse(r["id"].ToString()), decimal.Parse(r["maql"].ToString()), r["sothe"].ToString(),"","","","");
                _madt = 0; tamung = th = vp = th20 = vp20 = bhyttra_th = bhyttra_v = tcp_bntra = 0;
                if (dsxml.Tables[0].Rows.Count == 0)
                {
                    tamung = m.get_tamung(mabn.Text, decimal.Parse(r["maql"].ToString()), tu.Text, den.Text, makp.SelectedValue == null ? "" : makp.SelectedValue.ToString(), madoituong.SelectedValue==null?0:int.Parse(madoituong.SelectedValue.ToString()));
                }
                else
                {
                    foreach (DataRow r1 in dsxml.Tables[0].Select("mabn='" + r["mabn"].ToString() + "' and tamung<>0", "madoituong"))
                    {
                        if (int.Parse(r1["madoituong"].ToString()) != _madt)
                        {
                            tamung += decimal.Parse(r1["tamung"].ToString());
                            _madt = int.Parse(r1["madoituong"].ToString());
                        }
                    }
                }
                maphu = (r["sothe"].ToString().Trim() != "") ? d.get_maphu_noitru(r["sothe"].ToString(), nhom) : 0;
                int ityle = (maphu == 1) ? 80 : (maphu == 2) ? 95 : 100;
                bool bTraituyen = false;
                decimal d_dichvu_khongcungchitra = 0;
                DataRow r_giavp;
                foreach (DataRow r1 in dsxml.Tables[0].Select("mabn='" + r["mabn"].ToString() + "'", "sttnhom,bntra desc"))
                {
                    st = decimal.Parse(r1["sotien"].ToString());
                    r6 = m.getrowbyid(dtdt, "madoituong=" + int.Parse(r1["madoituong"].ToString()) + " and madoituong<>1 and mien=0");
                    if (r6 != null)
                    {
                        if (r1["nhom"].ToString().Trim() == s_thuoc) th += st;
                        else vp += st;
                        tcp_bntra += st;
                    }
                    else if (int.Parse(r1["madoituong"].ToString()) == 1)
                    {
                        if (r1["traituyen"].ToString() != "0" && r1["traituyen"].ToString().Trim() != "")
                        {
                            ityle = int.Parse(r1["tltraituyen"].ToString());
                            bTraituyen = true;
                            if (bBHYT_Traituyen_tinh_Tyle_khac)
                            {
                                r_giavp = m.getrowbyid(dtvp, "id=" + r1["ma"].ToString());
                                if (r_giavp != null && decimal.Parse(r_giavp["bhyt"].ToString()) > decimal.Parse(r_giavp["bhyt_tt"].ToString()))
                                {
                                    //gam 24/10/2011 bv vạn phúc tính công nợ bệnh nhân trái tuyến sai số liệu
                                    //d_dichvu_khongcungchitra = st;
                                    d_dichvu_khongcungchitra = 0;
                                    try
                                    {
                                        ityle = int.Parse(r_giavp["bhyt_tt"].ToString());
                                    }
                                    catch { }
                                    //end gam
                                }

                            }
                        }
                        else
                        {
                            tcp_bhyt += decimal.Parse(r1["sotien"].ToString());
                        }
                        if (maphu != 0)
                        {
                            if (r1["nhom"].ToString().Trim() == s_thuoc)
                            {
                                th += st;
                                decimal bntra = (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100);
                                decimal bhyttra = ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                                th20 = th20 + (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100);//th20 = th20 + st - (st * ityle / 100);
                                bhyttra_th += ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                            }
                            else
                            {
                                vp += st;
                                decimal bntra = (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100);
                                decimal bhyttra = ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                                vp20 = vp20 + (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100); //vp20 = vp20 + st - (st * ityle / 100);
                                bhyttra_v += ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                            }
                        }
                        else if(maphu == 0)
                        {
                            if (r1["nhom"].ToString().Trim() == s_thuoc)
                            {
                                th += st;
                                th20 = th20 + (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100);//th20 = th20 + st - (st * ityle / 100);
                                bhyttra_th += ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                            }
                            else
                            {
                                vp += st;
                                vp20 = vp20 + (st - d_dichvu_khongcungchitra) - ((st - d_dichvu_khongcungchitra) * ityle / 100); //vp20 = vp20 + st - (st * ityle / 100);
                                bhyttra_v += ((st - d_dichvu_khongcungchitra) * ityle / 100) + d_dichvu_khongcungchitra;
                            }
                        }
                    }
                }
                if (bTraituyen==false && m.bNoitru_bhyt_khambenh && tcp_bhyt < d.ma13_st(m.nhom_duoc))
                {
                    bhyttra_th += th20;
                    bhyttra_v += vp20;
                    th20 = vp20 = 0;
                }
                r["tamung"] = tamung;
                r["thuoc"] = th;// +th20;
                r["vienphi"] = vp;// +vp20;
                r["sotien"] = th + vp;// +th20 + vp20;
                r["bhyttra"] = bhyttra_th + bhyttra_v;
                r["bntra"] = tcp_bntra+ vp20+th20;
                r["conlai"] = decimal.Parse(r["bntra"].ToString()) - decimal.Parse(r["tamung"].ToString());
                d2 += decimal.Parse(r["sotien"].ToString());
                d4 += decimal.Parse(r["tamung"].ToString());
            }
            lbl.Visible = false;
            dstmp.Clear();
            dstmp.Merge(ds.Tables[0].Select("tamung+thuoc+vienphi>0"));
            d1 = dstmp.Tables[0].Rows.Count;
            d3 = (d1 == 0) ? 0 : d2 / d1;
            lbl1.Text = "Số ca :" + d1.ToString();
            lbl2.Text = "Tổng chi phí :" + d2.ToString("###,###,###,###.##");
            lbl3.Text = "Trung bình :" + d3.ToString("###,###,###,###.##");
            label6.Text = "Tổng tạm ứng :" + d4.ToString("###,###,###,###.##");
        }

        private void ins(string mabn, decimal id, decimal maql, string sothe, string denngay, string ngay1, string ngay2, string ngay3)
        {
            string s = "", makp = "";
            DataRow dr;
            ds1.Clear();
            dsxml.Clear();
            DataTable tmp = new DataTable();
            if (i_loaiba == 1)
            {
                if (id == 0)
                {
                    sql = "select a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,b.makp,";
                    sql += "a.madoituong,c.sothe,coalesce(c.traituyen,0) as traituyen from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                    sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
                    sql += " where a.mabn='" + mabn + "' and a.maql=" + maql;
                }
                else
                {
                    sql = "select h.maql,h.mavaovien,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,a.makp,";
                    sql += "h.madoituong,c.sothe,coalesce(c.traituyen,0) as traituyen from " + user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id ";
                    sql += " inner join " + user + ".benhandt h on a.maql=h.maql ";
                    sql += " left join " + user + ".bhyt c on a.maql=c.maql ";
                    sql += " where a.mabn='" + mabn + "' and a.maql=" + maql + " and a.id=" + id;
                }
                tmp=m.get_data(sql).Tables[0];
            }
            else if (i_loaiba == 4)
            {
                sql = "select h.maql,h.mavaovien,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when h.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(h.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,h.makp,";
                sql += "h.madoituong,c.sothe,coalesce(c.traituyen,0) as traituyen from  xxx.benhancc h  ";
                sql += " left join xxx.bhyt c on h.maql=c.maql ";
                sql += " where h.mabn='" + mabn + "' and h.maql=" + maql;
                string s_nam = DateTime.Now.Year.ToString();
                string s_namtruoc = Convert.ToString(DateTime.Now.Year - 1);
                string sql1 = "select mmyy from " + user + ".table where substr(mmyy,3,2)='" + s_namtruoc.Substring(2, 2) + "' order by mmyy";
                if (m.get_data(sql1).Tables[0].Rows.Count > 0)  tmp = m.get_data_yy(s_namtruoc, sql).Tables[0];
                if (tmp == null) tmp = m.get_data_yy(s_nam, sql).Tables[0];
                else tmp.Merge(m.get_data_yy(s_nam, sql).Tables[0]);
            }
            else
            {
                sql = "select h.maql,h.mavaovien,to_char(h.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,case when h.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(h.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,h.makp,";
                sql += "h.madoituong,c.sothe,coalesce(c.traituyen,0) as traituyen from  " + user + ".benhanngtr h  ";
                sql += " left join " + user + ".bhyt c on h.maql=c.maql ";
                sql += " where h.mabn='" + mabn + "' and h.maql=" + maql;
                tmp = m.get_data(sql).Tables[0];
            }
            string maso="";
            foreach (DataRow r in tmp.Rows)
            {
                maso = maql.ToString() + "," + decimal.Parse(r["mavaovien"].ToString()) + ",";
                if (i_loaiba == 1)
                {
                    maso += m.get_maql_Capcuu_noitru(r["ngayvao"].ToString().Substring(0, 10), decimal.Parse(r["mavaovien"].ToString()));
                    maso += m.get_maql_Capve_noitru(r["ngayvao"].ToString().Substring(0, 10), decimal.Parse(r["mavaovien"].ToString()));
                }
                else if (i_loaiba == 2) maso += m.get_maql_ngoaitru(r["ngayvao"].ToString().Substring(0, 10),r["ngayra"].ToString().Substring(0,10),decimal.Parse(r["maql"].ToString()));
                makp = r["makp"].ToString();
                s = m.get_doituong(mabn, maql, id, r["ngayvao"].ToString(), r["ngayra"].ToString(), "", dtkp, 2, bVienphi_phongluu,i_loaiba,(m.bChiphikp_noingoai)?decimal.Parse(r["mavaovien"].ToString()):0);//(id!=0)?r["makp"].ToString():""
                if (s == "") s = r["madoituong"].ToString() + ",";
                foreach (DataRow r1 in dtdt.Rows)
                    if (s.IndexOf(r1["madoituong"].ToString().Trim() + ",") != -1)
                    {
                        dr = ds1.Tables[0].NewRow();
                        dr["madoituongvao"] = r["madoituong"].ToString();
                        dr["mabn"] = mabn;
                        dr["ngayvao"] = r["ngayvao"].ToString();
                        dr["ngayra"] = r["ngayra"].ToString();
                        dr["madoituong"] = r1["madoituong"].ToString();
                        dr["doituong"] = r1["doituong"].ToString();
                        dr["hinhthuc"] = 0;
                        dr["phuongphap"] = 0;
                        dr["ketqua"] = 0;
                        dr["sothe"] = r["sothe"].ToString();
                        dr["maphu"] = 0;
                        dr["makp"] = r["makp"].ToString();
                        dr["maql"] = maql;
                        dr["idkhoa"] = 0;
                        dr["denngay"] = denngay;
                        dr["done"] = 2;
                        dr["chon"] = true;
                        dr["tresosinh"] = 0;
                        dr["khu"] = 0;
                        /*
                        dr["ngay1"] = ngay1;
                        dr["ngay2"] = ngay2;
                        dr["ngay3"] = ngay3;
                         * */
                        dr["maso"] = maso;
                        dr["traituyen"] = r["traituyen"].ToString();
                        ds1.Tables[0].Rows.Add(dr);
                    }
                break;
            }
            dsxml = m.get_ttravien_ct(dsxml, ds1.Tables[0].Select("chon=true", "mabn"), dsss.Tables[0].Select("chon=true", "mame,mabn"), dtkp, dtbd, dtvp, "", bVienphi_phongluu,i_loaiba,false,"",i_userid,false);
        }
		private void AddGridTableStyle()
		{
			DataGridTableStyle ts1=new DataGridTableStyle();
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts1.MappingName = ds.Tables[0].TableName;
			ts1.AlternatingBackColor = Color.Beige;
			ts1.BackColor = Color.GhostWhite;
			ts1.ForeColor = Color.MidnightBlue;
			ts1.GridLineColor = Color.RoyalBlue;
			ts1.HeaderBackColor = Color.MidnightBlue;
			ts1.HeaderForeColor = Color.Lavender;
			ts1.SelectionBackColor = Color.Teal;
			ts1.SelectionForeColor = Color.PaleGreen;
			ts1.ReadOnly=false;
			ts1.RowHeaderWidth=5;

			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 55;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ và tên";
			TextCol.Width = 135;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,4);
			TextCol.MappingName = "tamung";
			TextCol.HeaderText = "Tạm ứng";
			TextCol.Width = 70;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,5);
			TextCol.MappingName = "thuoc";
			TextCol.HeaderText = "Thuốc";
			TextCol.Width = 70;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,6);
			TextCol.MappingName = "vienphi";
			TextCol.HeaderText = "Viện phí";
			TextCol.Width = 70;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,7);
			TextCol.MappingName = "sotien";
            TextCol.HeaderText = "Tổng Chi phí";
			TextCol.Width = 70;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "bhyttra";
            TextCol.HeaderText = "BHYT Trả";
            TextCol.Width = 70;
            TextCol.Format = "###,###,###.##";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts1.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts1);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "bntra";
            TextCol.HeaderText = "BN Trả";
            TextCol.Width = 70;
            TextCol.Format = "###,###,###.##";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts1.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,8);
			TextCol.MappingName = "conlai";
			TextCol.HeaderText = "Thiếu(+)/Thừa(-)";
			TextCol.Width = 70;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (decimal.Parse(this.dataGrid1[row,10].ToString().Trim())<0) return Color.Red;
			else return Color.Black;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			load_grid();
			Cursor=Cursors.Default;
		}

		private void frmCongno_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

        private void butIn_Click(object sender, EventArgs e)
        {
            if (dstmp.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                dstmp.WriteXml("..\\..\\dataxml\\congno.xml", XmlWriteMode.WriteSchema);
                dllReportM.frmReport f = new dllReportM.frmReport(m, dstmp.Tables[0], "rptcongno.rpt", (rb2.Checked) ? "" : (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, (madoituong.SelectedIndex != -1) ? madoituong.Text : "", "", "", "", "", "", "", "", "");
                f.ShowDialog();
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!pic.Visible) return;
            try
            {
                String mabn = dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString();
                foreach (DataRow r in d.get_data("select * from " + d.user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                {
                    try
                    {
                        image = new byte[0];
                        image = (byte[])(r["image"]);
                        memo = new MemoryStream(image);
                        map = new Bitmap(Image.FromStream(memo));
                        pic.Image = (Bitmap)map;
                    }
                    catch
                    {
                        pic.Tag = "0000.bmp";
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = (Bitmap)map;
                    }
                    break;
                }
            }
            catch { }
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            if (mabn.Text != "")
            {
                if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			    if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
                hoten.Text="";
                foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+mabn.Text+"'").Tables[0].Rows)
                    hoten.Text=r["hoten"].ToString();
                if (hoten.Text=="")
                    MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);                    
            }
            else hoten.Text="";
        }
	}
}