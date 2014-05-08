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
	public class frmVpkhoa_th : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox soluong;
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
		private LibDuoc.AccessData d;
		private string user,xxx,s_mabn,s_ngay,sql,s_dvt,s_loaivp,s_mucvp,s_title,s_makp,s_sothe="";
		private int i_madoituong,i_done,i_paid,i_row=0,i_userid,i_vienphi,i_makp,i_buoi,v1,v2,o_madoituong;
		private decimal l_maql=0,l_idkhoa=0,l_mavaovien=0,l_id;
		private decimal d_soluong,d_dongia,d_vattu;
        private bool bMadoituong, bTTngay, bAdminHethong;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtll=new DataTable();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmVpkhoa_th(LibMedi.AccessData acc,string ngay,string mabn,decimal mavaovien,decimal maql,decimal idkhoa,int kp,string makp,int userid,int madoituong,int buoi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			v=new LibVienphi.AccessData();
			d=new LibDuoc.AccessData();
			s_ngay=ngay;s_mabn=mabn;o_madoituong=madoituong;
            l_maql = maql; l_idkhoa = idkhoa; s_makp = makp; l_mavaovien = mavaovien;
			i_userid=userid;i_makp=kp;i_buoi=buoi;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVpkhoa_th));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.mavp = new System.Windows.Forms.TextBox();
            this.butLietke = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(9, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(648, 312);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(541, 410);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 20;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-8, 301);
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
            this.madoituong.Location = new System.Drawing.Point(56, 301);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(80, 21);
            this.madoituong.TabIndex = 0;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(126, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(184, 301);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(352, 21);
            this.ten.TabIndex = 1;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(527, 301);
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
            this.soluong.Location = new System.Drawing.Point(592, 301);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(64, 21);
            this.soluong.TabIndex = 2;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
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
            this.butLietke.Location = new System.Drawing.Point(99, 333);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(70, 25);
            this.butLietke.TabIndex = 9;
            this.butLietke.Text = "Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(169, 333);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 5;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(239, 333);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 6;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(309, 333);
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
            this.butBoqua.Location = new System.Drawing.Point(379, 333);
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
            this.butHuy.Location = new System.Drawing.Point(449, 333);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 7;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(519, 333);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmVpkhoa_th
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(666, 439);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLietke);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.mavp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVpkhoa_th";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viện phí tại khoa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVpkhoa_th_KeyDown);
            this.Load += new System.EventHandler(this.frmVpkhoa_th_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmVpkhoa_th_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            xxx = user + m.mmyy(s_ngay);
            if (!m.bMmyy(m.mmyy(s_ngay))) m.tao_schema(m.mmyy(s_ngay), i_userid);
			if (o_madoituong==1)
				foreach(DataRow r in m.get_data("select sothe from "+user+".bhyt where maql="+l_maql).Tables[0].Rows) s_sothe=r["sothe"].ToString();
			v1=4;v2=2;
			string vitri=d.thetunguyen_vitri_ora(m.nhom_duoc);
			if (vitri.Length==3)
			{
				v1=int.Parse(vitri.Substring(0,1))-1;v2=int.Parse(vitri.Substring(2,1));
			}
			bTTngay=(m.bChieu_sang && i_buoi==0)?d.get_ttngay(s_ngay,s_makp):false;
			bMadoituong=m.bSuadt_thuoc_vp;
			s_title=this.Text;
			i_vienphi=m.iVienphi;
            dtkp = m.get_data("select * from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0];
			if (dtkp.Rows.Count==1)
			{
				s_loaivp=dtkp.Rows[0]["loaivp"].ToString().Trim();
				s_mucvp=dtkp.Rows[0]["mucvp"].ToString().Trim();
				if (s_loaivp!="") s_loaivp=s_loaivp.Substring(0,s_loaivp.Length-1);
				if (s_mucvp!="") s_mucvp=s_mucvp.Substring(0,s_mucvp.Length-1);
			}
            bAdminHethong = m.bAdminHethong(i_userid);
            sql = "select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.locthe,a.gia_cs,a.vattu_cs from " + user + ".v_giavp a," + user + ".v_loaivp b ";
			sql+="where a.id_loai=b.id and a.hide=0";
			if (s_loaivp!="") sql+=" and a.id_loai in ("+s_loaivp+")";
			if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp+")";
			sql+=" and (a.loaibn=0 or a.loaibn="+v.iNoitru+")";
			sql+=" order by b.stt,a.stt";
			dt=m.get_data(sql).Tables[0];
			list.DisplayMember="TEN";
			list.ValueMember="ID";
			list.DataSource=dt;

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			madoituong.SelectedValue=o_madoituong.ToString();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
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
			TextCol1.Width = 0;
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
			TextCol1.Width = 295;
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
			TextCol1.Width = 60;
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
			TextCol1.Width = 60;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 16);
			TextCol1.MappingName = "readonly";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,11].ToString().Trim()=="1" || this.dataGrid1[row,12].ToString().Trim()=="1" || this.dataGrid1[row,16].ToString()=="1")
                return Color.Red;
			else
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
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,0 as paid,a.done,a.maql,a.idkhoa,a.vattu,0 as tinhtrang,0 as thuchien,b.ma,a.readonly";
			sql+=" from "+xxx+".v_vpkhoa a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d ";
			sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
			sql+=" and a.mabn='"+s_mabn+"' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" and a.makp='"+s_makp+"' and a.maql="+l_maql;
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
				if (int.Parse(madoituong.SelectedValue.ToString())!=o_madoituong)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
						madoituong.SelectedValue=o_madoituong.ToString();
				}
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
				l_maql=decimal.Parse(dataGrid1[i_row,13].ToString());
				l_idkhoa=decimal.Parse(dataGrid1[i_row,14].ToString());
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
				if (madoituong.SelectedValue.ToString()=="1")
				{
					sql+=" and bhyt<>0";
                    if (s_sothe.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + s_sothe.Trim().Substring(v1, v2) + "%')";
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
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (ena && l_id==0)
			{
				ten.Text="";
				s_dvt="";i_paid=0;i_done=0;
				soluong.Text="1";
			}
			else butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			l_id=0;
			ena_object(true);
			if (madoituong.Enabled) madoituong.Focus();
			else ten.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,11].ToString()=="1" || dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,16].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !"),LibMedi.AccessData.Msg);
					return;
				}
				l_id=decimal.Parse(dataGrid1[i_row,0].ToString());
			}
			catch{l_id=0;}
			ena_object(true);			
			ref_text();			
			if (madoituong.Enabled) madoituong.Focus();
			else soluong.Focus();
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				if (!madoituong.Enabled) madoituong.Enabled=true;
				madoituong.Focus();
				return false;
			}
			if (soluong.Text=="" && soluong.Enabled)
			{
				soluong.Focus();
				return false;
			}
			if (d.get_paid(s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã thanh toán !"),LibMedi.AccessData.Msg);
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (ten.Text!="" && mavp.Text!="")
			{
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
    				foreach(DataRow r in v.get_data("select * from "+xxx+".v_vpkhoa where id="+l_id).Tables[0].Rows)
                        d.upd_theodoicongno(d.delete, r["mabn"].ToString(), decimal.Parse(r["mavaovien"].ToString()), decimal.Parse(r["maql"].ToString()), decimal.Parse(r["idkhoa"].ToString()), int.Parse(r["madoituong"].ToString()), decimal.Parse(r["soluong"].ToString()) * (decimal.Parse(r["dongia"].ToString()) + decimal.Parse(r["vattu"].ToString())), "vienphi");
				}

				if (!v.upd_vpkhoa(l_id,s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(mavp.Text),decimal.Parse(soluong.Text),d_dongia,d_vattu,i_userid,i_buoi))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin viện phí !"),LibMedi.AccessData.Msg);
					return;
				}
				d.upd_theodoicongno(d.insert,s_mabn,l_mavaovien,l_maql,l_idkhoa,int.Parse(madoituong.SelectedValue.ToString()),decimal.Parse(soluong.Text)*(d_dongia+d_vattu),"vienphi");
				m.updrec_chidinh(ds.Tables[0],l_id,s_ngay,s_makp,"",int.Parse(madoituong.SelectedValue.ToString()),madoituong.Text,int.Parse(mavp.Text),ten.Text,s_dvt,decimal.Parse(soluong.Text),d_dongia,d_vattu,i_paid,i_done,0,0,"");
			}
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
				if (d.get_paid(s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã thanh toán !"),LibMedi.AccessData.Msg);
					return;
				}
				i_row=dataGrid1.CurrentCell.RowNumber;
                if (!bAdminHethong && dataGrid1[i_row, 11].ToString() == "1" || dataGrid1[i_row, 12].ToString() == "1" || dataGrid1[i_row, 16].ToString() == "1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    int itable = m.tableid(m.mmyy(s_ngay), "v_vpkhoa");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".v_vpkhoa", "id=" + l_id));
					d.upd_theodoicongno(d.delete,s_mabn,l_mavaovien,l_maql,l_idkhoa,int.Parse(madoituong.SelectedValue.ToString()),decimal.Parse(soluong.Text)*(d_dongia+d_vattu),"vienphi");
					m.execute_data("delete from "+xxx+".v_vpkhoa where id="+l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
					ds.AcceptChanges();
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
			if (!kiemtra()) return;
			if (d.get_paid(s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã thanh toán !"),LibMedi.AccessData.Msg);
				return;
			}
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			i_madoituong=d.get_madoituong(l_maql);
			frmChonchidinh f=new frmChonchidinh(m,s_mabn,i_madoituong,s_loaivp,s_mucvp,v.iNoitru,s_sothe,v1,v2,true,l_mavaovien);
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
				madoituong.SelectedValue=i_madoituong.ToString();
                madoituong.Update();
				foreach(DataRow r in f.dt.Rows)
				{
					l_id=v.get_id_vpkhoa;
					v.upd_vpkhoa(l_id,s_mabn,l_mavaovien,l_maql,l_idkhoa,s_ngay,s_makp,i_madoituong,int.Parse(r["mavp"].ToString()),1,decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["vattu"].ToString()),i_userid,i_buoi);
					d.upd_theodoicongno(d.insert,s_mabn,l_mavaovien,l_maql,l_idkhoa,i_madoituong,decimal.Parse(r["dongia"].ToString())+decimal.Parse(r["vattu"].ToString()),"vienphi");
					m.updrec_chidinh(ds.Tables[0],l_id,s_ngay,s_makp,"",i_madoituong,madoituong.Text,int.Parse(r["mavp"].ToString()),r["ten"].ToString(),r["dvt"].ToString(),1,decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["vattu"].ToString()),0,0,0,0,"");
				}
			}
			ref_text();
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
                        //if (m.bNuocngoai(s_mabn))
                        //{
                        //    d_dongia=decimal.Parse(r["gia_nn"].ToString())*m.dTygia;
                        //    d_vattu=decimal.Parse(r["vattu_nn"].ToString())*m.dTygia;
                        //}
                        //else
                        //{
                        //    string gia=m.field_gia(madoituong.SelectedValue.ToString());
                        //    string giavt="vattu_"+gia.Substring(4).Trim();
                        //    d_dongia=decimal.Parse(r[gia].ToString());
                        //    d_vattu=decimal.Parse(r[giavt].ToString());
                        //}
                        string gia = m.field_gia(madoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
					}
				}
				catch{s_dvt="";d_dongia=0;d_vattu=0;}
			}
		}

		private void frmVpkhoa_th_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F6) butLietke_Click(sender,e);
		}

        private void madoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == madoituong && mavp.Text != "")
            {
                DataRow r = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                if (r != null)
                {
                    s_dvt = r["dvt"].ToString();
                    ten.Text = r["ten"].ToString();
                    //if (m.bNuocngoai(s_mabn))
                    //{
                    //    d_dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                    //    d_vattu = decimal.Parse(r["vattu_nn"].ToString()) * m.dTygia;
                    //}
                    //else
                    //{
                    //    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    //    string giavt = "vattu_" + gia.Substring(4).Trim();
                    //    d_dongia = decimal.Parse(r[gia].ToString());
                    //    d_vattu = decimal.Parse(r[giavt].ToString());
                    //}
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }
            }
        }
	}
}
