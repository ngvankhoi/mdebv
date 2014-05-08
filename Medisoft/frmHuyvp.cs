using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmHuyvp : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox ngayra;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataTable dt=new DataTable();
		private AccessData m;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private decimal l_maql;
		private int i_userid;
		private string s_makp,sql,s_ngayvao,user,nam;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.DataGrid dataGrid1;
        private Label label9;
        private ComboBox dieutri;
        private CheckBox chkKhoiphucHSBA;
        private bool bQuanly_Theo_Chinhanh = false;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHuyvp(AccessData acc,string makp,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_makp=makp;
			i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHuyvp));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.ngayra = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label9 = new System.Windows.Forms.Label();
            this.dieutri = new System.Windows.Forms.ComboBox();
            this.chkKhoiphucHSBA = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(145, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(256, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(450, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(170, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(352, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Khoa xuất viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(612, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(549, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(190, 8);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(70, 21);
            this.mabn.TabIndex = 2;
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(301, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(157, 21);
            this.hoten.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(512, 8);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 6;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(237, 31);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(119, 21);
            this.ngayra.TabIndex = 12;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(466, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(152, 21);
            this.tenkp.TabIndex = 15;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(596, 8);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(187, 21);
            this.diachi.TabIndex = 8;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(658, 31);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(126, 21);
            this.sothe.TabIndex = 17;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(270, 536);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 20;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(340, 536);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 18;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(410, 536);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 19;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(480, 536);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 21;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(440, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 14;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(56, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(124, 21);
            this.ngayvao.TabIndex = 10;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 36);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(768, 494);
            this.dataGrid1.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(2, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Điều trị :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dieutri
            // 
            this.dieutri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.FormattingEnabled = true;
            this.dieutri.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú",
            "Phòng lưu"});
            this.dieutri.Location = new System.Drawing.Point(56, 8);
            this.dieutri.Name = "dieutri";
            this.dieutri.Size = new System.Drawing.Size(90, 21);
            this.dieutri.TabIndex = 0;
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dieutri_KeyDown);
            // 
            // chkKhoiphucHSBA
            // 
            this.chkKhoiphucHSBA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKhoiphucHSBA.AutoSize = true;
            this.chkKhoiphucHSBA.Location = new System.Drawing.Point(12, 536);
            this.chkKhoiphucHSBA.Name = "chkKhoiphucHSBA";
            this.chkKhoiphucHSBA.Size = new System.Drawing.Size(146, 17);
            this.chkKhoiphucHSBA.TabIndex = 24;
            this.chkKhoiphucHSBA.Text = "Hủy và phục hồi bệnh án";
            this.chkKhoiphucHSBA.UseVisualStyleBackColor = true;
            // 
            // frmHuyvp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkKhoiphucHSBA);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHuyvp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hủy bỏ số liệu chuyển xuống viện phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHuyvp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHuyvp_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			dsngay.ReadXml("..//..//..//xml//m_giayravien.xml");
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
			ds.ReadXml("..//..//..//xml//m_huyvp.xml");
			AddGridTableStyle();
			dataGrid1.DataSource=ds.Tables[0];
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            dieutri.SelectedIndex = 0;
            //chkKhoiphucHSBA.Visible = !(m.bThanhtoan_ndot || m.bThanhtoan_khoa);
            chkKhoiphucHSBA.Checked = m.bHuyvp_phuchoi && !(m.bThanhtoan_ndot || m.bThanhtoan_khoa);
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				SendKeys.Send("{Tab}");
				int i=0,songay=d.iNgaykiemke;
				string s_sothe="",s_denngay="",ngayserver=m.ngayhienhanh_server.Substring(0,10);
				hoten.Text="";l_maql=0;dsngay.Clear();
				mabn.Text=mabn.Text.Trim();
                nam = "";
				if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
				decimal o_maql;
                if (mabn.Text.Trim().Length != 8)
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
                }
                if (dieutri.SelectedIndex == 0)
                {
                    if (m.bThanhtoan_ndot || m.bThanhtoan_khoa)
                    {
                        sql = "select c.nam,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                        sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,";
                        sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,";
                        sql += "h.tenquan,i.tenpxa,' ' as soluutru,b.chandoan,b.maicd";
                        sql += ",to_char(a.ngay,'yyyymmdd hh24:mi') as ngayv";
                        sql += " from " + user + ".nhapkhoa a," + user + ".xuatkhoa b," + user + ".btdbn c," + user + ".btdkp_bv d," + user + ".btdnn_bv e, ";
                        sql += user + ".btddt f," + user + ".btdtt g," + user + ".btdquan h," + user + ".btdpxa i ";
                        sql += " where a.id=b.id(+) and a.mabn=c.mabn and a.makp=d.makp ";
                        sql += " and c.mann=e.mann and c.madantoc=f.madantoc ";
                        sql += " and c.matt=g.matt and c.maqu=h.maqu and c.maphuongxa=i.maphuongxa";
                        sql += " and a.mabn='" + mabn.Text + "' order by a.id desc";
                    }
                    else
                    {
                        sql = "select c.nam,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                        sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,";
                        sql += "b.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,";
                        sql += "h.tenquan,i.tenpxa,b.soluutru,b.chandoan,b.maicd";
                        sql += ",to_char(a.ngay,'yyyymmdd hh24:mi') as ngayv";
                        sql += " from " + user + ".benhandt a," + user + ".xuatvien b," + user + ".btdbn c," + user + ".btdkp_bv d," + user + ".btdnn_bv e, ";
                        sql += user + ".btddt f," + user + ".btdtt g," + user + ".btdquan h," + user + ".btdpxa i ";
                        sql += " where a.maql=b.maql(+) and a.mabn=c.mabn and b.makp=d.makp (+)";
                        sql += " and c.mann=e.mann and c.madantoc=f.madantoc ";
                        sql += " and c.matt=g.matt and c.maqu=h.maqu and c.maphuongxa=i.maphuongxa";
                        sql += " and a.mabn='" + mabn.Text + "' and a.tuchoi=0 order by a.maql desc";
                    }
                }
                else if (dieutri.SelectedIndex == 1)
                {
                    sql = "select c.nam,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                    sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,";
                    sql += "h.tenquan,i.tenpxa,a.soluutru,a.chandoanrv as chandoan,a.maicdrv as maicd";
                    sql += ",to_char(a.ngay,'yyyymmdd hh24:mi') as ngayv";
                    sql += " from " + user + ".benhanngtr a," + user + ".btdbn c," + user + ".btdkp_bv d," + user + ".btdnn_bv e, ";
                    sql += user + ".btddt f," + user + ".btdtt g," + user + ".btdquan h," + user + ".btdpxa i ";
                    sql += " where a.mabn=c.mabn and a.makp=d.makp ";
                    sql += " and c.mann=e.mann and c.madantoc=f.madantoc ";
                    sql += " and c.matt=g.matt and c.maqu=h.maqu and c.maphuongxa=i.maphuongxa";
                    if (!m.bThanhtoan_ndot) sql += " and a.ngayrv is not null ";
                    sql += " and a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
                else
                {
                    sql = "select c.nam,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                    sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,";
                    sql += "h.tenquan,i.tenpxa,a.soluutru,a.chandoanrv as chandoan,a.maicdrv as maicd";
                    sql += ",to_char(a.ngay,'yyyymmdd hh24:mi') as ngayv";
                    sql += " from xxx.benhancc a," + user + ".btdbn c," + user + ".btdkp_bv d," + user + ".btdnn_bv e, ";
                    sql += user + ".btddt f," + user + ".btdtt g," + user + ".btdquan h," + user + ".btdpxa i ";
                    sql += " where a.mabn=c.mabn and a.makp=d.makp ";
                    sql += " and c.mann=e.mann and c.madantoc=f.madantoc ";
                    sql += " and c.matt=g.matt and c.maqu=h.maqu and c.maphuongxa=i.maphuongxa";
                    sql += " and a.ngayrv is not null and a.mabn='" + mabn.Text + "' order by a.maql desc";
                    songay = 365;
                }                
				foreach(DataRow r in (dieutri.SelectedIndex<2)?m.get_data(sql).Tables[0].Select("true","ngayv desc"):d.get_data_mmyy(sql,ngayserver,ngayserver,songay).Tables[0].Select("true","ngayv desc"))
				{
					o_maql=decimal.Parse(r["maql"].ToString());
					foreach(DataRow r1 in m.get_data("select sothe,to_char(denngay,'dd/mm/yyyy') as denngay from "+user+".bhyt where maql="+o_maql).Tables[0].Rows)
					{
						s_sothe=r1["sothe"].ToString();
						break;
					}
					if (i==0)
					{
                        nam = r["nam"].ToString().Trim();
						hoten.Text=r["hoten"].ToString();
						namsinh.Text=r["namsinh"].ToString();
						s_ngayvao=r["ngayvao"].ToString();
                        ngayra.Text = (r["ngayra"].ToString() == "") ? m.Ngaygio_hienhanh : r["ngayra"].ToString();
						diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+" ,"+r["tenpxa"].ToString().Trim()+" ,"+r["tenquan"].ToString().Trim()+" ,"+r["tentt"].ToString().Trim();
						makp.Text=r["makp"].ToString();
						tenkp.Text=r["tenkp"].ToString();
						l_maql=o_maql;
						sothe.Text=s_sothe;
					}
					updrec(r["soluutru"].ToString(),mabn.Text,o_maql,hoten.Text,namsinh.Text,r["phai"].ToString(),r["ngayvao"].ToString(),
						r["ngayra"].ToString(),s_sothe,makp.Text,tenkp.Text,r["tennn"].ToString(),r["dantoc"].ToString(),
						r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+" ,"+r["tenpxa"].ToString().Trim()+" ,"+r["tenquan"].ToString().Trim()+" ,"+r["tentt"].ToString().Trim(),
						s_denngay,r["chandoan"].ToString(),r["maicd"].ToString());

					i++;
				}
				if (l_maql==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
					mabn.Focus();
				}
				else ngayvao.SelectedValue=s_ngayvao;
			}
		}

		private void updrec(string soluutru,string mabn,decimal maql,string hoten,string namsinh,string phai,
			string ngayvao,string ngayra,string sothe,string makp,string tenkp,string tennn,string dantoc,string diachi,
			string denngay,string chandoan,string maicd)
		{
			DataRow dr=dsngay.Tables[0].NewRow();
			dr["soluutru"]=soluutru;
			dr["mabn"]=mabn;
			dr["hoten"]=hoten;
			dr["namsinh"]=namsinh;
			dr["phai"]=(phai.Trim()=="0")?"Nam":"Nữ";
			dr["tennn"]=tennn;
			dr["dantoc"]=dantoc;
			dr["maql"]=maql;
			dr["ngayvao"]=ngayvao;
			dr["ngayra"]=ngayra;
			dr["makp"]=makp;
			dr["tenkp"]=tenkp;
			dr["sothe"]=sothe;
			dr["denngay"]=denngay;
			dr["diachi"]=diachi;
			dr["chandoan"]=chandoan;
			dr["maicd"]=maicd;
			dsngay.Tables[0].Rows.Add(dr);
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butHuy.Enabled=!ena;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngayra.Text="";
			tenkp.Text="";
			makp.Text="";
			sothe.Text="";
			diachi.Text="";
			l_maql=0;
			ena_but(true);
			mabn.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text!="")
			{
                sql = "select a.id,a.mabn,a.maql,a.idkhoa,a.makp,b.tenkp,to_char(a.ngayvao,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += "to_char(a.ngayra,'dd/mm/yyyy hh24:mi') as ngayra,a.sotien,a.tamung,a.bhyt,a.mien,a.done ";
                sql += " from xxx.v_thvpll a," + user + ".btdkp_bv b where a.makp=b.makp";
                sql += " and a.maql=" + l_maql;
                //if (dieutri.SelectedIndex == 0 && !(m.bThanhtoan_ndot || m.bThanhtoan_khoa)) sql += " and to_char(a.ngayvao,'dd/mm/yyyy hh24:mi')='" + ngayvao.Text + "'";
                ds = m.get_data_mmyy(sql,ngayvao.Text,ngayra.Text,true);
				dataGrid1.DataSource=ds.Tables[0];
			}
			ena_but(false);
            butHuy.Focus();
		}


		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			int irec=dataGrid1.CurrentCell.RowNumber;
            decimal _id = decimal.Parse(dataGrid1[irec, 8].ToString());
			if (dataGrid1[irec,0].ToString()=="1")
			{
				MessageBox.Show(lan.Change_language_MessageText("Viện phí đã cập nhật không cho phép hủy !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.bThanhtoan_khoa || m.bThanhtoan_ndot)
            {
                if (m.bHuyvp_phuchoi && dieutri.SelectedIndex == 0)
                {
                    if (m.get_data("select * from " + user + ".hiendien where nhapkhoa=1 and xuatkhoa=0 and maql=" + l_maql + " and makp not in (select makp from " + user + ".hiendien where id=" + _id + ")").Tables[0].Rows.Count > 0)
                    {

                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đang hiện diện khoa khác không cho phép xóa !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }
            }
			if (MessageBox.Show(lan.Change_language_MessageText("Bạn đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                string s_mmyy = m.mmyy(ngayra.Text);
                if (!m.bMmyy(s_mmyy)) s_mmyy = m.mmyy(m.ngayhienhanh_server.Substring(0, 10));
                string xxx = user + s_mmyy;

                int itable = m.tableid(s_mmyy, "v_thvpct");
                foreach (DataRow r in m.get_data("select id,makp,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,madoituong,mavp,dongia from " + xxx + ".v_thvpct where id=" + _id).Tables[0].Rows)
                {
                    m.upd_eve_tables(ngayra.Text, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngayra.Text, itable, i_userid, "del", m.fields(xxx + ".v_thvpct", "id=" + _id+" and makp='"+r["makp"].ToString()+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+r["ngay"].ToString()+"' and madoituong="+int.Parse(r["madoituong"].ToString())+" and mavp="+decimal.Parse(r["mavp"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString())));
                }
                itable = m.tableid(s_mmyy, "v_thvpll");
                m.upd_eve_tables(ngayra.Text, itable, i_userid, "del");
                m.upd_eve_upd_del(ngayra.Text, itable, i_userid, "del", m.fields(xxx + ".v_thvpll", "id=" + _id));
                if (dieutri.SelectedIndex == 2)
                    m.execute_data_mmyy("update xxx.v_chidinh set paid=0 where paid=1 and maql=" + l_maql, ngayvao.Text, ngayra.Text, true);
                if (m.bThanhtoan_ndot || m.bThanhtoan_khoa)
                {
                    m.execute_data_mmyy("delete from xxx.v_thvpct where id=" + _id, ngayvao.Text, ngayra.Text, true);
                    m.execute_data_mmyy("delete from xxx.v_thvpbhyt where id=" + _id, ngayvao.Text, ngayra.Text, true);
                    m.execute_data_mmyy("delete from xxx.v_thvpll where id=" + _id, ngayvao.Text, ngayra.Text, true);
                }
                else
                {
                    decimal l_id = 0, idgiuong = 0;
                    string s_idgiuong = "";
                    m.execute_data_mmyy("delete from xxx.v_thvpct where id=" + _id, ngayvao.Text, ngayra.Text, true);
                    m.execute_data_mmyy("delete from xxx.v_thvpbhyt where id=" + _id, ngayvao.Text, ngayra.Text, true);
                    m.execute_data_mmyy("delete from xxx.v_thvpll where id=" + _id, ngayvao.Text, ngayra.Text, true);
                    if (chkKhoiphucHSBA.Visible && chkKhoiphucHSBA.Checked)//m.bHuyvp_phuchoi &&
                    {
                        if (dieutri.SelectedIndex == 0)
                        {
                            //xuatvien
                            itable = m.tableid("", "xuatvien");
                            m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".xuatvien", "maql=" + l_maql));
                            m.upd_eve_tables(itable, i_userid, "del");
                            m.execute_data("delete from " + user + ".xuatvien where maql=" + l_maql);
                            //xuatkhoa
                            DataTable tmp = m.get_data("select a.id from " + user + ".nhapkhoa a," + user + ".xuatkhoa b where a.id=b.id and a.maql=" + l_maql + " and b.ttlucrk<>5").Tables[0];
                            if (tmp.Rows.Count > 0)
                            {
                                s_idgiuong = "";
                                l_id = decimal.Parse(tmp.Rows[0]["id"].ToString());
                                if (m.bPhonggiuong)
                                {
                                    foreach (DataRow r1 in m.get_data("select idgiuong, giuongthem from " + user + ".theodoigiuong where idkhoa=" + l_id + " and idgiuong<>0").Tables[0].Rows)
                                    {
                                        if(r1["giuongthem"].ToString()=="0")idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                        s_idgiuong += r1["idgiuong"].ToString() + ","; ;
                                    }
                                }
                                m.execute_data("delete from " + user + ".hiendien where maql=" + l_maql + " and nhapkhoa=0 and xuatkhoa=0");
                                foreach (DataRow r1 in m.get_data("select a.mabn,b.mavaovien,a.maql,a.makp,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.giuong,a.mabs,a.maicd,a.khoachuyen from " + user + ".nhapkhoa a," + user + ".benhandt b where a.maql=b.maql and a.id=" + l_id).Tables[0].Rows)
                                    m.upd_hiendien(l_id, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), r1["makp"].ToString(), r1["ngayvv"].ToString(), r1["ngay"].ToString(), r1["giuong"].ToString(), r1["mabs"].ToString(), r1["maicd"].ToString(), r1["khoachuyen"].ToString(), 1, 0);
                                if (idgiuong != 0)
                                {
                                    //Khuong 02/11/2011
                                    try
                                    {
                                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id in(" + s_idgiuong.Trim().Trim(',') + ")");//id=" + idgiuong);
                                    }
                                    catch (Exception exx)
                                    {
                                        MessageBox.Show(exx.Message);
                                        m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id in(" + s_idgiuong.Trim().Trim(',') + ")");
                                    }
                                    m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_id);
                                    sql = "select * from " + user + ".theodoigiuong where idkhoa=" + l_id;// +" and to_char(den,'dd/mm/yyyy')='" + ngayra.Text.Substring(0, 10) + "'";
                                    if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")";
                                    else sql += " and idgiuong=" + idgiuong;
                                    sql += " order by id desc";
                                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                    {
                                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + s_mmyy + ".v_vpkhoa where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + s_mmyy + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString())); //Khuong 29/11/2011 
                                    }
                                }
                                itable = m.tableid("", "xuatkhoa");
                                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".xuatkhoa", "id=" + l_id));
                                m.upd_eve_tables(itable, i_userid, "del");
                                m.execute_data("delete from " + user + ".xuatkhoa where id=" + l_id);
                            }
                        }
                        else if (dieutri.SelectedIndex == 1)
                        {
                            itable = m.tableid("", "benhanngtr");
                            m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".benhanngtr", "maql=" + l_maql));
                            m.upd_eve_tables(itable, i_userid, "del");
                            m.execute_data("update " + user + ".benhanngtr set ttlucrv=0,ngayrv=null where maql=" + l_maql);
                        }
                        else if (dieutri.SelectedIndex == 2)
                        {
                            string zzz = user + m.mmyy(ngayvao.Text);
                            itable = m.tableid(m.mmyy(ngayvao.Text), "benhancc");
                            m.upd_eve_upd_del(itable, i_userid, "del", m.fields(zzz + ".benhancc", "maql=" + l_maql));
                            m.upd_eve_tables(itable, i_userid, "del");
                            foreach (DataRow r in m.get_data("select * from " + zzz + ".benhancc where maql=" + l_maql).Tables[0].Rows)
                            {
                                if (m.bPhonggiuong)
                                {
                                    s_idgiuong = "";
                                    foreach (DataRow r1 in m.get_data("select idgiuong, giuongthem from " + user + ".theodoigiuong where maql=" + l_maql + " and idgiuong<>0").Tables[0].Rows)
                                    {
                                        if (r1["giuongthem"].ToString() == "0") idgiuong = decimal.Parse(r1["idgiuong"].ToString());
                                        s_idgiuong += r1["idgiuong"].ToString() + ",";
                                    }
                                }
                                if (idgiuong != 0)
                                {
                                    try
                                    {
                                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id in(" + s_idgiuong.Trim().Trim(',') + ")");//id=" + idgiuong);
                                    }
                                    catch (Exception exx)
                                    {
                                        MessageBox.Show(exx.Message);
                                        m.execute_data("update " + user + ".dmgiuong set soluong=0,tinhtrang=0 where id in(" + s_idgiuong.Trim().Trim(',') + ")");
                                    }
                                    sql = "select * from " + user + ".theodoigiuong where maql=" + l_maql + " and to_char(den,'dd/mm/yyyy')='" + ngayra.Text.Substring(0, 10) + "'";//idgiuong=" + idgiuong + " and 
                                    if (s_idgiuong.Trim().Trim(',') != "") sql += " and idgiuong in(" + s_idgiuong.Trim().Trim(',') + ")";
                                    else sql += " and idgiuong=" + idgiuong;
                                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                                    {
                                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + s_mmyy + ".v_vpkhoa where id=" + decimal.Parse(r1["id"].ToString()));
                                        m.execute_data("delete from " + user + s_mmyy + ".v_vpkhoa where idcha<>0 and idcha=" + decimal.Parse(r1["id"].ToString()));
                                    }
                                }                               
                            }
                            m.execute_data("update " + zzz + ".benhancc set ngayrv=null where maql=" + l_maql);
                        }
                    }
                }
				butLuu_Click(sender,e);
			}
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "done";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format="###,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "tamung";
			TextCol.HeaderText = "Tạm ứng";
			TextCol.Width = 100;
			TextCol.Format="###,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "bhyt";
			TextCol.HeaderText = "BHYT";
			TextCol.Width = 100;
			TextCol.Format="###,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "mien";
			TextCol.HeaderText = "Miễn";
			TextCol.Width = 100;
			TextCol.Format="###,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,0].ToString().Trim()=="1") return Color.Red;
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
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao)
			{
				if (ngayvao.Items.Count>0)
				{
					ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
					sothe.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
					makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
					tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
					l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
				}
			}
		}

        private void dieutri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

	}
}
