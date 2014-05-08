using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
using System.IO;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmTtngtru : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butExit;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string sql,s_ngayvao,nam,user,s_mabs,s_sothe;
		private decimal l_maql,l_mavaovien,lTraituyen;
        private int i_madoituong, iMavp_congkham,iTraituyen;
        private decimal Congkham = 0;
		private dichso.numbertotext doiso=new dichso.numbertotext();
		private DataSet dsxmlin=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataTable dtvpin=new DataTable();
		private DataTable dtbd=new DataTable();
        private DataTable dtdt = new DataTable();
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox maicd;
        private bool bCongkham, bChuky, bGiaban,bGiaban_noi_ngtru;
        private decimal Bhyt_7cn = 0;
        private FileStream fstr;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private dllReportM.Print print = new dllReportM.Print();
        private CheckBox chkXem;
        private CheckBox chkXML;
        private DataTable dtdtd = new DataTable();
        private Panel panel1;
        private RadioButton radCahai;
        private RadioButton radDatt;
        private RadioButton radChuaTT;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTtngtru(LibMedi.AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTtngtru));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new System.Windows.Forms.TextBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radChuaTT = new System.Windows.Forms.RadioButton();
            this.radDatt = new System.Windows.Forms.RadioButton();
            this.radCahai = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(114, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(322, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(179, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Khoa :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-30, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(156, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(65, 8);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(68, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 9);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 3;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(384, 9);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 5;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(240, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(184, 21);
            this.tenkp.TabIndex = 10;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(216, 54);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(208, 21);
            this.diachi.TabIndex = 14;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(65, 54);
            this.sothe.MaxLength = 16;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(111, 21);
            this.sothe.TabIndex = 12;
            // 
            // butTiep
            // 
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(203, 157);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 16;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butIn
            // 
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(276, 157);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExit
            // 
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(350, 157);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 17;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(216, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(22, 21);
            this.makp.TabIndex = 9;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(65, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 7;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-30, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Chẩn đoán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nơi ĐKKCB :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(65, 77);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(359, 21);
            this.tenbv.TabIndex = 20;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(65, 100);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(310, 21);
            this.chandoan.TabIndex = 21;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(376, 100);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(48, 21);
            this.maicd.TabIndex = 22;
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(5, 165);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 23;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(5, 182);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 24;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radCahai);
            this.panel1.Controls.Add(this.radDatt);
            this.panel1.Controls.Add(this.radChuaTT);
            this.panel1.Location = new System.Drawing.Point(65, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 24);
            this.panel1.TabIndex = 25;
            // 
            // radChuaTT
            // 
            this.radChuaTT.AutoSize = true;
            this.radChuaTT.Checked = true;
            this.radChuaTT.Location = new System.Drawing.Point(3, 4);
            this.radChuaTT.Name = "radChuaTT";
            this.radChuaTT.Size = new System.Drawing.Size(104, 17);
            this.radChuaTT.TabIndex = 0;
            this.radChuaTT.TabStop = true;
            this.radChuaTT.Text = "Chưa thanh toán";
            this.radChuaTT.UseVisualStyleBackColor = true;
            // 
            // radDatt
            // 
            this.radDatt.AutoSize = true;
            this.radDatt.Location = new System.Drawing.Point(127, 4);
            this.radDatt.Name = "radDatt";
            this.radDatt.Size = new System.Drawing.Size(93, 17);
            this.radDatt.TabIndex = 1;
            this.radDatt.Text = "Đã thanh toán";
            this.radDatt.UseVisualStyleBackColor = true;
            // 
            // radCahai
            // 
            this.radCahai.AutoSize = true;
            this.radCahai.Location = new System.Drawing.Point(251, 4);
            this.radCahai.Name = "radCahai";
            this.radCahai.Size = new System.Drawing.Size(55, 17);
            this.radCahai.TabIndex = 2;
            this.radCahai.Text = "Cả hai";
            this.radCahai.UseVisualStyleBackColor = true;
            // 
            // frmTtngtru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 207);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTtngtru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu thanh toán ngoại trú";
            this.Load += new System.EventHandler(this.frmTtngtru_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTtngtru_Load(object sender, System.EventArgs e)
		{
            user = m.user; lTraituyen = (m.bTraituyen) ? m.lTraituyen_phongkham : 0;
            iTraituyen = (m.bTraituyen) ? m.iTraituyen_bhyt : 0;
            int i_nhom = m.nhom_duoc;
            bGiaban = int.Parse(d.get_data("select nhom from " + user + ".d_dmnhomkho where id=" + i_nhom).Tables[0].Rows[0][0].ToString()) == 1;
            bGiaban_noi_ngtru=d.bGiaban_noi_ngtru(i_nhom);
            iMavp_congkham = d.iMavp_congkham(i_nhom);
            bCongkham = m.bInchiphi_congkham;
            Congkham = d.Congkham(m.nhom_duoc);
            bChuky = m.bChuky;
            chkXem.Checked = m.bPreview;
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a").Tables[0];
            dtdtd = m.get_data("select * from " + user + ".d_doituong").Tables[0];

			sql="select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom, a.kythuat, a.kcct, a.bhyt";
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
			sql+=" where a.id_loai=b.id and b.id_nhom=c.ma";
			dtvpin=m.get_data(sql).Tables[0];

			sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
			sql+="a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom, a.kythuat, a.kcct, a.bhyt";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d";
			sql+=" where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
			dtbd=m.get_data(sql).Tables[0];

			dsxmlin.ReadXml("..//..//..//xml//m_inravien.xml");
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add(dc);
            dc = new DataColumn("Imagetk", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add(dc);
            dc = new DataColumn("Imageuser", typeof(byte[]));
            dsxmlin.Tables[0].Columns.Add(dc);
            dsxmlin.Tables[0].Columns.Add("mabs");
            dsxmlin.Tables[0].Columns.Add("tenbs");
            dsxmlin.Tables[0].Columns.Add("makprv");
            dsxmlin.Tables[0].Columns.Add("tenuser");
            dsxmlin.Tables[0].Columns.Add("cholam");
            dsxmlin.Tables[0].Columns.Add("madt", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("haophi", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("idttrv", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxmlin.Tables[0].Columns.Add("loaikythuat", typeof(string));

			dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("cholam");
            dsngay.Tables[0].Columns.Add("traituyen", typeof(decimal));
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];

            
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;string s_giuong="",s_sothe="",s_denngay="",s_tenbv="";decimal o_maql;
			hoten.Text="";l_maql=0;dsngay.Clear();i_madoituong=1;
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			nam=m.get_mabn_nam(mabn.Text);
			sql="select c.hoten,c.namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
            sql+= "to_char(a.ngay,'yyyymmdd hh24:mi') as yyyymmdd,";
			sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
			sql+="to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayra,a.makp,";
			sql+="d.tenkp,a.chandoan,a.maicd,";
			sql+="e.tentt,f.tenquan,g.tenpxa,1 as ketqua,";
			sql+="a.ttlucrv,'' as soluutru,a.madoituong,i.doituong,a.mabs,j.hoten as tenbs,c.cholam ";
            sql += "from xxx.benhanpk a," + user + ".btdbn c," + user + ".btdkp_bv d," + user + ".btdtt e," + user + ".btdquan f," + user + ".btdpxa g," + user + ".doituong i ,"+user+".dmbs j ";
			sql+="where a.mabn=c.mabn and a.makp=d.makp and c.matt=e.matt and c.maqu=f.maqu and a.mabs=j.ma ";
			sql+="and c.maphuongxa=g.maphuongxa and a.madoituong=i.madoituong and a.mabn='"+mabn.Text+"'";
			sql+="order by a.maql desc";
            s_ngayvao = m.ngayhienhanh_server.Substring(0, 10);
			DataTable tmp;
			if (nam!="") tmp=m.get_data_nam(nam,sql).Tables[0];
			else tmp=m.get_data_mmyy(sql,s_ngayvao,s_ngayvao,true).Tables[0];
            int traituyen = 0;
			foreach(DataRow r in tmp.Select("true","yyyymmdd desc"))
			{
				if (i==0)
				{
					i_madoituong=int.Parse(r["madoituong"].ToString());
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					chandoan.Text=r["chandoan"].ToString();
                    s_mabs = r["mabs"].ToString();
					maicd.Text=r["maicd"].ToString();
					foreach(DataRow r1 in m.get_data("select a.sothe,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv,a.traituyen from "+user+d.mmyy(s_ngayvao)+".bhyt a left join "+user+".dmnoicapbhyt b on a.mabv=b.mabv where a.maql="+l_maql).Tables[0].Rows)
					{
						s_sothe=r1["sothe"].ToString();s_denngay=r1["denngay"].ToString();
						s_tenbv=r1["tenbv"].ToString();
                        tenbv.Text = s_tenbv; traituyen = int.Parse(r1["traituyen"].ToString());
						break;
					}
                    sothe.Text = s_sothe;
				}
				o_maql=decimal.Parse(r["maql"].ToString());
				s_giuong=r["giuong"].ToString().Trim();
				m.updrec_ravien(dsngay,mabn.Text,decimal.Parse(r["mavaovien"].ToString()),o_maql,decimal.Parse(r["id"].ToString()),
					hoten.Text,r["mabs"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					int.Parse(r["madoituong"].ToString()),r["doituong"].ToString(),s_sothe,s_denngay,m.get_noigioithieu(s_ngayvao,o_maql),s_tenbv,s_giuong,r["makp"].ToString(),r["tenkp"].ToString(),r["ngayvao"].ToString(),r["ngayra"].ToString(),
					r["chandoan"].ToString(),r["maicd"].ToString(),m.get_nguoinha(m.mmyy(s_ngayvao),mabn.Text,o_maql),2,
                    m.phuongphapdieutri(r["makp"].ToString()),m.ketquadieutri(int.Parse(r["ketqua"].ToString()),int.Parse(r["ttlucrv"].ToString())),r["soluutru"].ToString(),r["mabs"].ToString(),r["tenbs"].ToString(),r["cholam"].ToString(),traituyen);

				i++;
			}
			ngayvao.SelectedValue=s_ngayvao;
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			tenkp.Text="";
			makp.Text="";
			sothe.Text="";
			diachi.Text="";
			chandoan.Text="";
			maicd.Text="";
			tenbv.Text="";
			l_maql=0;
			mabn.Focus();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            int i_ThanhToan = 0;
            i_ThanhToan = (radChuaTT.Checked) ? 0 : (radDatt.Checked) ? 1 : 2;
            //
			if (mabn.Text=="" || ngayvao.SelectedIndex==-1) return;
            dsxmlin.Clear();
            string s_mabn=mabn.Text,s_doituong="",s_noicap = "",denngay="",s_chandoan = "", s_maicd = "", s_tenkp = "", s_tenbs = "", yyy = user + m.mmyy(ngayvao.Text),maso="";
            int sokham = 0,traituyen=0;
            decimal l_matd = l_mavaovien;
            sql = "select a.maql,a.chandoan,a.maicd,b.tenkp,c.hoten as tenbs,d.doituong from " + yyy + ".benhanpk a ";
            sql+=" inner join " + user + ".btdkp_bv b on a.makp=b.makp ";
            sql+=" left join " + user + ".dmbs c on a.mabs=c.ma ";
            sql += " left join " + user + ".doituong d on a.madoituong=d.madoituong ";
            sql+=" where a.mavaovien=" + l_matd + " order by a.maql";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                maso += r["maql"].ToString() + ",";
                sokham += 1;
                s_maicd += r["maicd"].ToString().Trim() + ";";
                s_chandoan += r["chandoan"].ToString().Trim() + ";";
                s_tenkp += r["tenkp"].ToString().Trim() + ";";
                s_tenbs += r["tenbs"].ToString() + ";";
                foreach (DataRow r1 in m.get_data("select chandoan,maicd from " + yyy + ".cdkemtheo where maql=" + decimal.Parse(r["maql"].ToString()) + " order by stt").Tables[0].Rows)
                {
                    s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                    s_maicd += r1["maicd"].ToString().Trim() + ";";
                }
                s_doituong = r["doituong"].ToString();
            }
            int iTuoi = (namsinh.Text != "") ? DateTime.Now.Year - int.Parse(namsinh.Text) : 0;
            DataSet ds1;
            sql = "select 1 as id,a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            sql += "case when i.loai=0 then t.giamua else t.giaban end as dongia,";
            sql += "case when i.loai=0 then t.giamua else t.giaban end*a.soluong as sotien,";
            sql += "a.cachdung,0 as makho,0 as manguon,0 as nhomcc,f.makp,h.tenkp,f.maphu as madoituong ";
            sql += " from xxx.bhytthuoc a," + user + ".d_dmbd b,xxx.bhytkb f,xxx.d_theodoi t," + user + ".btdkp_bv h,"+user+".d_doituong i";
            sql += " where a.sttt=t.id and f.id=a.id and a.mabd=b.id and f.makp=h.makp and f.maphu=i.madoituong";
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;
            //
            if (i_ThanhToan == 0) sql += " and f.sobienlai=0 ";
            else if(i_ThanhToan == 1) sql += " and f.sobienlai<>0 ";
            else sql += "";
            //
            ds1 = m.get_data_mmyy(sql, ngayvao.Text, ngayvao.Text, true);
            //
            sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
            if (bGiaban)
            {
                if (bGiaban_noi_ngtru) sql += "t.giaban2 as dongia,t.giaban2*a.soluong as sotien,";
                else sql += "a.giaban as dongia,a.giaban*a.soluong as sotien,";
            }
            else
            {
                //sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";//quang
                //binh230908
                sql += "case when i.loai=0 then t.giamua else t.giaban end as dongia,";
                sql += "case when i.loai=0 then t.giamua else t.giaban end*a.soluong as sotien,";
                //
            }
            sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,g.makp,g.ten as tenkp,a.madoituong ";
            sql += " from xxx.d_thucxuat a," + user + ".d_dmbd b,xxx.d_xuatsdll f,xxx.d_theodoi t," + user + ".d_duockp g";
            sql += ", "+ user + ".d_doituong i";// binh230908
            sql += " where f.id=a.id and a.sttt=t.id and a.mabd=b.id and f.makhoa=g.id ";
            sql += " and a.madoituong=i.madoituong";//binh230908
            sql += " and f.mabn='" + s_mabn + "' and f.mavaovien=" + l_matd;//and to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";
            sql += " and f.loai=2 ";//order by f.id,a.stt";
            //    
            ds1.Merge(d.get_thuoc(ngayvao.Text, ngayvao.Text, sql));
            //
            //thuoc mua ngoai
            if (i_ThanhToan == 1 || i_ThanhToan == 2)
            {
                sql = "select 1 as id,a.stt,1 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bGiaban)
                {
                    sql += " a.giaban as dongia,a.giaban*a.soluong as sotien,";
                }
                else
                {
                    //sql += "t.giamua as dongia,t.giamua*a.soluong as sotien,";//quang
                    //binh230908
                    sql += " t.giaban as dongia,";
                    sql += " t.giaban*a.soluong as sotien,";
                    //
                }
                sql += "' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,g.makp,g.ten as tenkp,to_number('2') as madoituong ";
                sql += " from xxx.d_ngtruct  a," + user + ".d_dmbd b,xxx.d_ngtrull f,xxx.d_theodoi t," + user + ".d_duockp g";
                sql += " where f.id=a.id and a.sttt=t.id and a.mabd=b.id and f.makp=g.id(+) ";
                sql += " and f.mabn='" + s_mabn + "' and f.maql=" + l_maql;//and to_char(f.ngay,'dd/mm/yyyy')='" + ngayvv.Text + "'";            
                //
                ds1.Merge(d.get_thuoc(ngayvao.Text, ngayvao.Text, sql));
            }
            //
            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,a.makp,h.tenkp,a.madoituong ";
            sql += " from " + yyy + ".v_chidinh a," + user + ".v_giavp b," + user + ".btdkp_bv h where a.mavp=b.id and a.makp=h.makp ";
            sql += " and a.mabn='" + s_mabn + "' and a.mavaovien=" + l_matd;
            //sql += " and a.paid=0";
            //
            if (i_ThanhToan == 0) sql += " and a.paid=0 ";
            else if (i_ThanhToan == 1) sql += " and a.paid<>0 and a.idttrv<>0 ";
            else sql += " and (a.paid=0 or (a.paid=1 and a.idttrv<>0))";
            //
            ds1.Merge(m.get_data(sql));

            sql = "select 2 as id,b.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,c.makp,h.tenkp,c.maphu as madoituong ";
            sql += " from xxx.bhytcls a," + user + ".v_giavp b," + user + ".btdkp_bv h,xxx.bhytkb c";
            sql += " where c.id=a.id and a.mavp=b.id and c.makp=h.makp ";
            sql += " and c.mabn='" + s_mabn + "' and c.mavaovien=" + l_matd;
            //
            if (i_ThanhToan == 0) sql += " and c.sobienlai=0 ";
            else if (i_ThanhToan == 1) sql += " and c.sobienlai<>0 ";
            else sql += "";
            //
            ds1.Merge(m.get_data_mmyy(sql, ngayvao.Text, ngayvao.Text, true));

            DataSet dstmp = ds1.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "id,stt"));
            dsxmlin.Clear();
            DataRow r2,r3;
            if (sothe.Text != "")
            {
                foreach (DataRow r in m.get_data("select to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv,a.traituyen from " + yyy + ".bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.sothe='" + sothe.Text + "' and a.maql="+l_maql).Tables[0].Rows)
                {
                    s_noicap = r["tenbv"].ToString();
                    denngay = r["denngay"].ToString();
                    traituyen = int.Parse(r["traituyen"].ToString());
                    break;
                }
            }
            string dichso = "", s_ghichu = "";
            decimal bntra = 0, bhyttra = 0, mien = 0, tcsotien = 0, tcsotien_bhyt = 0;
            bool bMien = false;

            sql = "select a.ghichu,b.traituyen from xxx.d_thuocbhytll a,xxx.bhytkb b";
            sql += " where a.id=b.id and a.ghichu<>''";
            sql += " and b.mabn='" + s_mabn + "' and b.mavaovien=" + l_matd;
            sql += " order by a.maql";
            foreach (DataRow r in m.get_data_mmyy(sql, ngayvao.Text, ngayvao.Text, true).Tables[0].Rows)
            {
                s_ghichu += r["ghichu"].ToString().Trim() + ";";
                traituyen=int.Parse(r["traituyen"].ToString());
            }

            r2 = m.getrowbyid(dtdt, "mien=1 and madoituong=" + i_madoituong);
            bMien = r2 != null;
            foreach (DataRow r in dstmp.Tables[0].Rows)
            {
                tcsotien += decimal.Parse(r["sotien"].ToString());
                if (r["madoituong"].ToString() == "1") tcsotien_bhyt += decimal.Parse(r["sotien"].ToString());
            }
            if (i_madoituong == 1) bhyttra = tcsotien;
            else if (bMien) mien = tcsotien;
            else bntra = tcsotien;
            tcsotien += ((bCongkham) ? Congkham * sokham : 0);
            dichso = doiso.doithapphan(Convert.ToInt64(tcsotien).ToString());
            string s1 = m.get_tamung(mabn.Text, l_matd, ngayvao.Text.Substring(0,10),i_madoituong);
            decimal tamung = decimal.Parse(s1.Substring(0, s1.IndexOf("^")));
            string stamung = s1.Substring(s1.IndexOf("^") + 1),_doituong=s_doituong;
            if (dstmp.Tables[0].Rows.Count == 0)
            {
                m.updrec_ravien(dsxmlin, s_mabn, s_mabn, l_maql, 2, hoten.Text, namsinh.Text,dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phai"].ToString(),dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["diachi"].ToString(),i_madoituong,
                s_doituong, sothe.Text, 0, denngay, dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noigioithieu"].ToString(),s_noicap,dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["giuong"].ToString(),makp.Text,tenkp.Text, ngayvao.Text, s_ghichu, s_chandoan, s_maicd,
                0, "", 0, "", 0, "", "", 0, 0, bhyttra, 0, (bCongkham) ? Congkham : 0,dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["nguoinha"].ToString(), 1, 0, sokham, s_tenbs, 0, false,0,"","",makp.Text,"",i_madoituong,0,0,0,traituyen,int.Parse("-1"),"");
            }
            else
            {
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    if (r["id"].ToString() == "2")
                        r2 = m.getrowbyid(dtvpin, "id=" + int.Parse(r["mabd"].ToString()));
                    else
                        r2 = m.getrowbyid(dtbd, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r3=m.getrowbyid(dtdtd,"madoituong="+int.Parse(r["madoituong"].ToString()));
                        _doituong=(r3!=null)?r3["doituong"].ToString():s_doituong;
                        m.updrec_ravien(dsxmlin, r["sttt"].ToString(), s_mabn, l_maql, decimal.Parse(r["sttt"].ToString()) + decimal.Parse(r["id"].ToString()), hoten.Text, namsinh.Text, dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phai"].ToString(), dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["diachi"].ToString(),int.Parse(r["madoituong"].ToString()),
                            _doituong, sothe.Text, 0, denngay, dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noigioithieu"].ToString(), s_noicap, dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["giuong"].ToString(), r["makp"].ToString(), r["tenkp"].ToString(), ngayvao.Text, s_ghichu, s_chandoan, s_maicd,
                            int.Parse(r2["sttnhom"].ToString()), r2["nhom"].ToString(), int.Parse(r2["sttloai"].ToString()), r["cachdung"].ToString(),
                            int.Parse(r["mabd"].ToString()), r["ten"].ToString(), r["dang"].ToString(),
                            decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["sotien"].ToString()),
                            bhyttra, tamung, (bCongkham) ? Congkham : 0, dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["nguoinha"].ToString(), 1, 0, sokham, s_tenbs, decimal.Parse(r["dongia"].ToString()), true, 0, "", "", makp.Text, "", int.Parse(r["madoituong"].ToString()), decimal.Parse(r["dongia"].ToString()), 0, decimal.Parse(r["sotien"].ToString()), traituyen, int.Parse(r2["kythuat"].ToString()),"");
                    }
                }
            }
            DateTime dt = d.StringToDate(ngayvao.Text.Substring(0, 10));
            string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
            Bhyt_7cn = (m.getLetet(ngayvao.Text) || ddd == "Sat" || ddd == "Sun") ? m.Bhyt_7cn : 0;
            int maphu = (i_madoituong == 1 && sothe.Text != "") ? d.get_maphu_ngtru(sothe.Text, tcsotien_bhyt, m.nhom_duoc) : 0, chitra = 0;
            try
            {
                dsxmlin.Tables[0].Columns.Add("tlchitra", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
            foreach (DataRow r in dsxmlin.Tables[0].Rows)
            {
                chitra = 0;
                if (r["madoituong"].ToString() == "1") //if (i_madoituong == 1)
                {
                    chitra = 100;
                    if (i_madoituong == 1 && sothe.Text != "" && int.Parse(r["traituyen"].ToString()) != 0 && iTraituyen != 0)
                    {
                        chitra = iTraituyen;
                        r["bhyttra"] = tcsotien * chitra / 100;
                        r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                    }
                    else if (i_madoituong == 1 && r["madoituong"].ToString() == "1" && sothe.Text != "" && Bhyt_7cn != 0 && tcsotien > Bhyt_7cn)
                    {
                        r["bhyttra"] = Bhyt_7cn;
                        r["bntra"] = tcsotien - Bhyt_7cn;
                    }
                    else
                    {
                        if (maphu != 0)
                        {
                            chitra = (maphu == 1) ? 80 : 95;
                            r["bhyttra"] = tcsotien * chitra / 100;
                            r["bntra"] = tcsotien - (tcsotien * chitra / 100);
                        }
                        else
                        {
                            r["bhyttra"] = tcsotien;
                            r["bntra"] = 0;
                        }
                        if (lTraituyen != 0 && decimal.Parse(r["bhyttra"].ToString()) > lTraituyen && int.Parse(r["traituyen"].ToString()) != 0)
                        {
                            r["bhyttra"] = lTraituyen;
                            r["bntra"] = tcsotien - lTraituyen;
                        }
                    }
                }
                else if (m.mien_doituong(int.Parse(r["madoituong"].ToString()) , dtdt)) //mien
                {
                    r["mien"] = tcsotien; r["bntra"] = r["bhyttra"] = 0;
                }
                else
                {
                    r["bhyttra"] = 0;
                    r["bntra"] = tcsotien;
                }
                r["dichso"] = dichso;
                r["sbltamung"] = stamung;
                r["tlchitra"] = chitra;
            }

            if (bChuky)
            {
                if (File.Exists("..//..//..//chuky//" + s_mabs + ".bmp"))
                {
                    fstr = new FileStream("..//..//..//chuky//" + s_mabs + ".bmp", FileMode.Open, FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Close();
                    foreach (DataRow r in dsxmlin.Tables[0].Rows) r["Image"] = image;
                }
            }
            if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
            dsxmlin.WriteXml("..//xml//ravien.xml", XmlWriteMode.WriteSchema);
            if (dsxmlin.Tables[0].Rows.Count > 0)
            {
                if (chkXem.Checked)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxmlin, s_tenkp, "rpt_chiphi_kp.rpt");
                    f.ShowDialog();
                    f.Close();
                    f.Dispose();
                }
                else print.Printer(m, dsxmlin, "rpt_chiphi_kp.rpt", s_tenkp, 1);
            }
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == ngayvao)
            {
                try
                {
                    if (ngayvao.Items.Count > 0)
                    {
                        sothe.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
                        makp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
                        tenkp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
                        tenbv.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noicap"].ToString();
                        chandoan.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString();
                        maicd.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maicd"].ToString();
                        l_maql = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                        l_mavaovien = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mavaovien"].ToString());
                        s_mabs = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mabs"].ToString();

                        i_madoituong = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString());
                    }
                }
                catch { }

            }
		}
	}
}
