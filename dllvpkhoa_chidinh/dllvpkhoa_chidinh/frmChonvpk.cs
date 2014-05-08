using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;
using LibDuoc;

namespace dllvpkhoa_chidinh
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmChonvpk : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox mavp;
		private System.Windows.Forms.Button butLietke;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private string user,s_mabn,s_hoten,s_tuoi,s_ngay,s_makp,s_tenkp,sql,s_dvt,s_table,s_loaivp="",s_mucvp="";
		private int i_madoituong,i_tong=-1,i_done,i_paid,i_row=0,i_userid,iChidinh,i_buoi,v1,v2;
		private decimal l_maql,l_idkhoa,l_id,l_mavaovien;
		private decimal d_soluong,d_dongia,d_vattu;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox sothe;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonvpk(LibMedi.AccessData acc,string mabn,string hoten,string tuoi,string ngay,string makp,string tenkp,int madoituong,decimal mavaovien,decimal maql,decimal idkhoa,int userid,string table,int buoi,string thebhyt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			v=new LibVienphi.AccessData();i_buoi=buoi;
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; l_mavaovien = mavaovien;
			i_madoituong=madoituong;l_maql=maql;l_idkhoa=idkhoa;i_userid=userid;sothe.Text=thebhyt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonvpk));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.TextBox();
            this.butLietke = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(56, 8);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(108, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(156, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(340, 8);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 21);
            this.tuoi.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(645, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 256);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(632, 272);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(572, 394);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 8;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 296);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(96, 21);
            this.madoituong.TabIndex = 0;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(156, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(208, 296);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(448, 21);
            this.ten.TabIndex = 1;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(643, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số lượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(710, 296);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(56, 21);
            this.soluong.TabIndex = 2;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(371, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Khoa/phòng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(460, 8);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(140, 21);
            this.tenkp.TabIndex = 16;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(104, 224);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(24, 21);
            this.mavp.TabIndex = 17;
            // 
            // butLietke
            // 
            this.butLietke.Image = ((System.Drawing.Image)(resources.GetObject("butLietke.Image")));
            this.butLietke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLietke.Location = new System.Drawing.Point(139, 328);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(70, 25);
            this.butLietke.TabIndex = 5;
            this.butLietke.Text = "Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(209, 328);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 6;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(279, 328);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(349, 328);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(419, 328);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(489, 328);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 8;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(559, 328);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(600, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 74;
            this.label8.Text = "Số thẻ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(645, 8);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 21);
            this.sothe.TabIndex = 73;
            // 
            // frmChonvpk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(770, 423);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLietke);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mavp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonvpk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viện phí tại khoa";
            this.Load += new System.EventHandler(this.frmChonvpk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChonvpk_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			v1=4;v2=2;
			string vitri=d.thetunguyen_vitri_ora(m.nhom_duoc);
			if (vitri.Length==3)
			{
				v1=int.Parse(vitri.Substring(0,1))-1;v2=int.Parse(vitri.Substring(2,1));
			}
			iChidinh=m.iChidinh;
			dtkp=m.get_data("select * from "+user+".btdkp_bv where makp='"+s_makp+"'").Tables[0];
			if (dtkp.Rows.Count==1)
			{
				s_loaivp=dtkp.Rows[0]["loaivp"].ToString().Trim();
				s_mucvp=dtkp.Rows[0]["mucvp"].ToString().Trim();
				if (s_loaivp!="") s_loaivp=s_loaivp.Substring(0,s_loaivp.Length-1);
				if (s_mucvp!="") s_mucvp=s_mucvp.Substring(0,s_mucvp.Length-1);
			}
            sql = "select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.locthe from " + user + ".v_giavp a," + user + ".v_loaivp b ";
			sql+="where a.id_loai=b.id ";
			if (s_loaivp!="") sql+=" and a.id_loai in ("+s_loaivp+")";
			if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp+")";
			sql+=" order by b.stt,a.stt";
			dt=m.get_data(sql).Tables[0];
			list.DisplayMember="TEN";
			list.ValueMember="ID";
			list.DataSource=dt;

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;
			tenkp.Text=s_tenkp;
			if (iChidinh!=4) load_treeView();
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
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khoa/phòng";
			TextCol1.Width = 95;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 58;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Dịch vụ";
			TextCol1.Width = 230;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "dvt";
			TextCol1.HeaderText = "ĐVT";
			TextCol1.Width = 30;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "soluong";
			TextCol1.HeaderText = "Số lượng";
			TextCol1.Width = 50;
			TextCol1.Format="### ###.00";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "makp";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "madoituong";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 9);
			TextCol1.MappingName = "mavp";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 10);
			TextCol1.MappingName = "dongia";
			TextCol1.HeaderText = "Đơn gía";
			TextCol1.Width = 65;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 11);
			TextCol1.MappingName = "paid";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 12);
			TextCol1.MappingName = "done";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 13);
			TextCol1.MappingName = "maql";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 14);
			TextCol1.MappingName = "idkhoa";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 15);
			TextCol1.MappingName = "vattu";
			TextCol1.HeaderText = "Vật tư";
			TextCol1.Width = 65;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			if (this.dataGrid1[row,11].ToString().Trim()=="1" || this.dataGrid1[row,12].ToString().Trim()=="1")
			{
				c=Color.Red;
				i_tong=row;
			}
			if (row==i_tong) c=Color.Red;
			return c;
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
		private void load_grid()
		{
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,0 as paid,a.done,a.maql,a.idkhoa,a.vattu,0 as tinhtrang,0 as thuchien,b.ma ";
			sql+=" from "+user+m.mmyy(s_ngay)+".v_vpkhoa a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d ";
			sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
			sql+=" and a.mabn='"+s_mabn+"'";
			sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			if (l_maql!=0) sql+=" and a.maql="+l_maql;
			if (l_idkhoa!=0) sql+=" and a.idkhoa="+l_idkhoa;
			sql+=" and a.buoi="+i_buoi;
			sql+=" order by a.ngay";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}
		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter(ten.Text);
				list.BrowseToDanhmuc(ten,mavp,soluong,0);
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,###.00");
			}
			catch{soluong.Text="1";}
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				madoituong.SelectedValue=dataGrid1[i_row,8].ToString();
				mavp.Text=dataGrid1[i_row,9].ToString();
				ten.Text=dataGrid1[i_row,4].ToString();
				s_dvt=dataGrid1[i_row,5].ToString();
				d_dongia=decimal.Parse(dataGrid1[i_row,10].ToString());
				d_vattu=decimal.Parse(dataGrid1[i_row,15].ToString());
				i_paid=int.Parse(dataGrid1[i_row,11].ToString());
				i_done=int.Parse(dataGrid1[i_row,12].ToString());
				d_soluong=decimal.Parse(dataGrid1[i_row,6].ToString());
				soluong.Text=d_soluong.ToString("###,###.00");
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				sql="ten like '%"+ten.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1" && sothe.Text.Trim().Length>v1+v2)
				{
					sql+=" and bhyt<>0";
                    sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%')";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			madoituong.Enabled=ena;
			ten.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLietke.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			//dataGrid1.ReadOnly=!ena;
			if (ena && l_id==0)
			{
				ten.Text="";
				soluong.Text="1";
				s_dvt="";i_paid=0;i_done=0;
			}
			else butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=0;
			ena_object(true);
			madoituong.SelectedValue=i_madoituong.ToString();
			madoituong.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,11].ToString()=="1" || dataGrid1[i_row,12].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !"),LibMedi.AccessData.Msg);
					return;
				}
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
			}
			catch{l_id=0;}
			ena_object(true);
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				madoituong.Focus();
				return false;
			}
			if (ten.Text=="" || mavp.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (soluong.Text=="")
			{
				soluong.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            int itable = m.tableid(m.mmyy(s_ngay), "v_vpkhoa");
            if (l_id == 0)
            {
                l_id = v.get_id_vpkhoa;
                m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            }
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + mavp.Text + "^" + soluong.Text + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + i_buoi.ToString());
            }              
			if (!v.upd_vpkhoa(l_id,s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(mavp.Text),decimal.Parse(soluong.Text),d_dongia,d_vattu,i_userid,i_buoi))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin viện phí !"),LibMedi.AccessData.Msg);
				return;
			}
			m.updrec_chidinh(ds.Tables[0],l_id,s_ngay,s_makp,s_tenkp,int.Parse(madoituong.SelectedValue.ToString()),madoituong.Text,int.Parse(mavp.Text),ten.Text,s_dvt,decimal.Parse(soluong.Text),d_dongia,d_vattu,i_paid,i_done,0,0,"");
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,11].ToString()=="1" || dataGrid1[i_row,12].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
                    int itable = m.tableid(m.mmyy(s_ngay), "v_vpkhoa");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user+m.mmyy(s_ngay) + ".v_vpkhoa", "id=" + l_id));
					m.execute_data("delete from "+user+m.mmyy(s_ngay)+".v_vpkhoa where id="+l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
					ref_text();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLietke_Click(object sender, System.EventArgs e)
		{
            int itable = m.tableid(m.mmyy(s_ngay), "v_vpkhoa");
            frmChonchidinh f = new frmChonchidinh(m, s_mabn, i_madoituong, s_loaivp, s_mucvp, v.iNoitru, sothe.Text, v1, v2, true,0);
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
				madoituong.SelectedValue=i_madoituong.ToString();
				foreach(DataRow r in f.dt.Rows)
				{
					l_id=v.get_id_vpkhoa;                  
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
					v.upd_vpkhoa(l_id,s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,i_madoituong,int.Parse(r["mavp"].ToString()),1,decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["vattu"].ToString()),i_userid,i_buoi);
					m.updrec_chidinh(ds.Tables[0],l_id,s_ngay,s_makp,s_tenkp,i_madoituong,madoituong.Text,int.Parse(r["mavp"].ToString()),r["ten"].ToString(),r["dvt"].ToString(),1,decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["vattu"].ToString()),0,0,0,0,"");
				}
			}
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
			TreeNode node;
			sql="select distinct b.ngay,a.maql,";
            if (l_idkhoa != 0) sql += " a.id as idkhoa ";
            else sql += " 0 as idkhoa ";
            sql+=" from "+s_table+" a,xxx.v_vpkhoa b where ";
            if (l_idkhoa != 0) sql += " a.id=b.idkhoa";
            else sql += " a.maql=b.maql";
			if (iChidinh==1) sql+=" and a.mabn='"+s_mabn+"'";
			else if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
			else if (iChidinh==3 && l_idkhoa!=0) sql+=" and a.id='"+l_idkhoa+"'";
			sql+=" order by b.ngay desc";
			dtngay=m.get_data_mmyy(sql,s_ngay,s_ngay,true).Tables[0];
			foreach(DataRow r in dtngay.Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString())));
				sql="select b.ten from xxx.v_vpkhoa a,"+user+".v_giavp b where a.mavp=b.id";
				sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString()))+"'";
                if (l_idkhoa != 0) sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                else sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
				foreach(DataRow r1 in m.get_data_mmyy(sql,s_ngay,s_ngay,true).Tables[0].Rows)
					node.Nodes.Add(r1["ten"].ToString());
				r["ngay"]=m.StringToDate(m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngay"].ToString())));
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				try
				{
					DataRow r=m.getrowbyid(dt,"id="+int.Parse(mavp.Text));
					if (r!=null)
					{
						s_dvt=r["dvt"].ToString();
						ten.Text=r["ten"].ToString();
						if (m.bNuocngoai(s_mabn))
						{
							d_dongia=decimal.Parse(r["gia_nn"].ToString())*m.dTygia;
							d_vattu=decimal.Parse(r["vattu_nn"].ToString())*m.dTygia;
						}
						else
						{
							string gia=m.field_gia(madoituong.SelectedValue.ToString());
							string giavt="vattu_"+gia.Substring(4).Trim();
							d_dongia=decimal.Parse(r[gia].ToString());d_vattu=decimal.Parse(r[giavt].ToString());
						}
					}
				}
				catch{s_dvt="";d_dongia=0;d_vattu=0;}
			}
		}
	}
}
