using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmviewpx.
	/// </summary>
	public class frmxempx : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		//
		string s_mmyy="",s_makho="", s_ngay="";
		int i_nhom=0,i_userid=0;		
		LibDuoc.AccessData d=new LibDuoc.AccessData();
		DataSet ds_phieu, dsct;		
		DataTable dtdmbd=new DataTable();
		bool blnfirst=true;
		//
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.ComboBox nhomin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkngay;
		private MaskedBox.MaskedBox ngaysp;
		private System.Windows.Forms.TextBox no;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox co;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox nguoigiao;
		private System.Windows.Forms.CheckBox chktt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmxempx(string mmyy,string makho, int nhom,int userid, string ngay )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			s_mmyy=mmyy;
			s_makho=makho;
			i_nhom=nhom;
			i_userid=userid;
			s_ngay=ngay;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.nhomin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkngay = new System.Windows.Forms.CheckBox();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.no = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.co = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butRef = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nguoigiao = new System.Windows.Forms.TextBox();
            this.chktt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 40);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(264, 440);
            this.dataGrid1.TabIndex = 101;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
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
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(272, 40);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(512, 440);
            this.dataGrid2.TabIndex = 102;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(237, 8);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(267, 21);
            this.tenkp.TabIndex = 2;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(184, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 104;
            this.label9.Text = "Khoa";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(442, 488);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(372, 488);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // nhomin
            // 
            this.nhomin.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomin.Location = new System.Drawing.Point(544, 8);
            this.nhomin.Name = "nhomin";
            this.nhomin.Size = new System.Drawing.Size(240, 21);
            this.nhomin.TabIndex = 3;
            this.nhomin.SelectedIndexChanged += new System.EventHandler(this.nhomin_SelectedIndexChanged);
            this.nhomin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(488, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 108;
            this.label1.Text = "Loại";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkngay
            // 
            this.chkngay.Checked = true;
            this.chkngay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkngay.Location = new System.Drawing.Point(8, 8);
            this.chkngay.Name = "chkngay";
            this.chkngay.Size = new System.Drawing.Size(104, 24);
            this.chkngay.TabIndex = 0;
            this.chkngay.Text = "Xem theo ngày";
            this.chkngay.Click += new System.EventHandler(this.chkngay_Click);
            this.chkngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(112, 8);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(72, 21);
            this.ngaysp.TabIndex = 1;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // no
            // 
            this.no.Location = new System.Drawing.Point(544, 32);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(80, 20);
            this.no.TabIndex = 6;
            this.no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(496, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 114;
            this.label2.Text = "Nợ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // co
            // 
            this.co.Location = new System.Drawing.Point(656, 32);
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(128, 20);
            this.co.TabIndex = 7;
            this.co.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(608, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 116;
            this.label3.Text = "Có";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butRef
            // 
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(302, 488);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(70, 25);
            this.butRef.TabIndex = 9;
            this.butRef.Text = "&Liệt kê";
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(134, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 119;
            this.label4.Text = "Người nhận";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nguoigiao
            // 
            this.nguoigiao.Location = new System.Drawing.Point(237, 32);
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(267, 20);
            this.nguoigiao.TabIndex = 5;
            this.nguoigiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // chktt
            // 
            this.chktt.Location = new System.Drawing.Point(8, 32);
            this.chktt.Name = "chktt";
            this.chktt.Size = new System.Drawing.Size(152, 24);
            this.chktt.TabIndex = 4;
            this.chktt.Text = "Xem phiếu xuất trực tiếp";
            this.chktt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkngay_KeyDown);
            // 
            // frmxempx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.chktt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.co);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.no);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.chkngay);
            this.Controls.Add(this.nhomin);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGrid2);
            this.Name = "frmxempx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem phiếu xuất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmxempx_MouseMove);
            this.Load += new System.EventHandler(this.frmxempx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}
		private void load_d_dm()
		{
			string sql="select * from d_duockp order by stt";
			tenkp.DisplayMember="TEN";
			tenkp.ValueMember="ID";
			tenkp.DataSource=d.get_data(sql).Tables[0];			
			//
			//dtdmbd=d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong ten,trim(b.ten)||'/'||c.ten hang,a.dang,a.tenhc,a.id,a.giaban,b.ten tenhang,c.ten tennuoc from d_dmbd a,d_dmhang b,d_dmnuoc c where a.mahang=b.id and a.manuoc=c.id and a.nhom="+i_nhom+" order by a.ten").Tables[0];
			dtdmbd=d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong ten,trim(b.ten)||'/'||c.ten hang,a.dang,a.tenhc,a.id,a.giaban,b.ten tenhang,c.ten tennuoc, d.ma stk from d_dmbd a,d_dmhang b,d_dmnuoc c,d_dmnhomkt d where a.mahang=b.id and a.manuoc=c.id and a.sotk=d.id(+) and a.nhom="+i_nhom+" order by a.ten").Tables[0].Copy();			
			//
			no.Tag="";
			co.Tag="";
		}

		private void frmxempx_Load(object sender, System.EventArgs e)
		{
			ngaysp.Text=s_ngay;
			load_d_dm();
			load_nhomin();
			load_sophieuxuat(0,0);
			load_xuat_ct(i_nhom,0,0,0,0,"","","",0);			
			AddGridTableStyle1();
			AddGridTableStyle2();
		}
		private void load_sophieuxuat(int i_makp, int i_nhomin)
		{
			string s_user=d.user;
			string sql="select rownum as idphieu, b.ten tenkp, c.ten tenphieu, e.ten nhomin, g.ten tenkho,to_char(a.ngay,'dd/mm/yyyy') ngayin, a.* ";
			sql+=" from d_sophieu a, "+s_user+".d_duockp b, "+s_user+".d_loaiphieu c, "+s_user+".d_nhomin e, "+s_user+".d_dmkho g ";
			sql+=" where a.makp=b.id and a.phieu=c.id and a.loaiin=e.id and a.makho=g.id ";
			sql+=" and a.mmyy='"+s_mmyy+"'";
			if(i_makp>0)sql+=" and a.makp="+i_makp;
			if(i_nhomin>0)sql+=" and a.loaiin="+i_nhomin;
			if(chkngay.Checked)sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngaysp.Text+"'";
			sql+=" order by a.ngay, a.so ";
			ds_phieu=d.get_data(sql);
			dataGrid1.DataSource=ds_phieu.Tables[0];
		}

		private void load_sophieuxuat_tt(int i_makp)
		{
			string s_user=d.user;
			string sql="select distinct a.id idphieu, b.ten tenkp, c.ten tenphieu, b.ten nhomin, to_char(a.ngay,'dd/mm/yyyy') ngayin, a.mabn so,ct.makho,'' manguon, '' madoituong,4 loaiin, a.loai, a.phieu, a.ngay, a.makp ";
			sql+=" from d_xuatsdll a, d_xuatsdct ct, "+s_user+".d_duockp b, "+s_user+".d_loaiphieu c ";
			sql+=" where a.id=ct.id and a.makp=b.id and a.phieu=c.id and maql=0";
			sql+=" and a.mmyy='"+s_mmyy+"'";
			if(i_makp>0)sql+=" and a.makp="+i_makp;			
			if(chkngay.Checked)sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngaysp.Text+"'";
			sql+=" order by a.ngay ";
			ds_phieu=d.get_data(sql);
			dataGrid1.DataSource=ds_phieu.Tables[0];
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds_phieu.Tables[0].TableName;
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
			TextCol.MappingName = "idphieu";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngayin";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 68;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomin";
			TextCol.HeaderText = "Nhóm thuốc";
			TextCol.Width = 130;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenphieu";
			TextCol.HeaderText = "";//"Phiếu";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "so";
			TextCol.HeaderText = "Số";
			TextCol.Width =30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
		}

		private void AddGridTableStyle2()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
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
			TextCol.MappingName = "stt_t";
			TextCol.HeaderText = "STT";
			TextCol.Width = 25;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã BD";
			TextCol.Width = 48;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên biệt dược";
			TextCol.Width = 165;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Tên hoạt chất";
			TextCol.Width = 90;
			TextCol.NullText=String.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 35;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "SL";
			TextCol.Width =30;
			TextCol.Format="#,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Thành tiền";
			TextCol.Width =80;
			TextCol.Format="#,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
			
			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==tenkp)
			{
				int i_makho=(tenkp.SelectedIndex<0)?0:int.Parse(tenkp.SelectedValue.ToString());
				int i_nhomin=(nhomin.SelectedIndex<0)?0:int.Parse(nhomin.SelectedValue.ToString());
				load_sophieuxuat(i_makho,i_nhomin);
			}
		}
		private void load_nhomin()
		{
			string sql="select * from d_nhomin where nhom="+i_nhom+" order by stt";
			nhomin.DisplayMember="TEN";
			nhomin.ValueMember="ID";
			nhomin.DataSource=d.get_data(sql).Tables[0];
			nhomin.SelectedIndex=-1;
		}

		private void nhomin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==nhomin)
			{
				int i_makho=(tenkp.SelectedIndex<0)?0:int.Parse(tenkp.SelectedValue.ToString());
				int i_nhomin=(nhomin.SelectedIndex<0)?0:int.Parse(nhomin.SelectedValue.ToString());
				load_sophieuxuat(i_makho,i_nhomin);
			}
		}
		private void load_xuat_ct(int i_nhom, int i_loai,int i_phieu,int i_makp,int i_makho,string s_madt,string s_manguon, string s_ngay, int i_nhomin)
		{
			string tenfile=(i_loai==2)?"d_thucbucstt":"d_thucxuat";
			string s_user=d.user;
			string sql="select rownum as stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,f.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,round(a.sotien/a.soluong,3) dongia,a.sotien,a.giaban,a.makho,a.manguon,a.nhomcc,'xx/xx/xxxx' ngay,0 sttduyet,0 tutruc,";
			sql+=" b.manhom idnhom, i.stt, i.ten tennhom, b.mahang, g.ten tenhang,b.manuoc, j.ten tennuoc,  ";
			sql+=(s_madt!="" && tenfile=="d_thucxuat")?" e.doituong,a.madoituong,":"' ' doituong, 0 madoituong,";
			if(d.bNoiNgoai_Hang(i_nhom) || d.bNoiNgoai_Nuoc(i_nhom))
			{
				sql+=" g.loai idnn, ";
				if (d.bNoiNgoai_Hang(i_nhom)) sql+=" h.ten noingoai ";
				else sql+=" m.ten noingoai ";
				sql+=" from d_xuatsdll ll, "+tenfile+" a,"+s_user+".d_dmbd b,"+s_user+".d_dmnguon c,"+s_user+".d_nhomcc d,"+s_user+".d_dmkho f, "+s_user+".d_dmhang g, "+s_user+".d_nhomhang h, "+s_user+".d_dmnhom i, "+s_user+".d_dmnuoc j,"+s_user+".d_nhomnuoc m";
				if (s_madt!="" && tenfile=="d_thucxuat")sql+=", "+s_user+".d_doituong e";
				sql+=" where ll.id=a.id and a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=f.id ";
				sql+=" and b.manhom=i.id and b.mahang=g.id and g.loai=h.id and b.manuoc=j.id and j.loai=m.id";			
				sql+=" and to_char(ll.ngay,'dd/mm/yyyy')='"+s_ngay+"' and ll.mmyy='"+s_mmyy+"'";
				sql+=" and a.makho="+i_makho+" and i.nhomin="+i_nhomin+" and ll.nhom="+i_nhom+" and ll.loai="+i_loai+" and ll.phieu="+i_phieu+" and ll.makp="+i_makp;
				if (s_madt!="" && tenfile=="d_thucxuat") sql+=" and a.madoituong=e.madoituong and a.madoituong in ("+s_madt.Substring(0,s_madt.Length-1)+")";
				if (s_manguon!="") sql+=" and a.manguon in ("+s_manguon.Substring(0,s_manguon.Length-1)+")";
			}
			else
			{
				sql+=" b.maloai idnn, h.ten noingoai ";
				sql+=" from d_xuatsdll ll,"+tenfile+" a,"+s_user+".d_dmbd b,"+s_user+".d_dmnguon c,"+s_user+".d_nhomcc d,"+s_user+".d_dmkho f, "+s_user+".d_dmhang g, "+s_user+".d_dmloai h, "+s_user+".d_dmnhom i, "+s_user+".d_dmnuoc j ";
				if (s_madt!="" && tenfile=="d_thucxuat")sql+=", "+s_user+".d_doituong e";
				sql+=" where ll.id=a.id and a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=f.id ";
				sql+=" and b.manhom=i.id and b.mahang=g.id and b.maloai=h.id and b.manuoc=j.id ";			
				sql+=" and to_char(ll.ngay,'dd/mm/yyyy')='"+s_ngay+"' and ll.mmyy='"+s_mmyy+"'";
				sql+=" and a.makho="+i_makho+" and i.nhomin="+i_nhomin+" and ll.nhom="+i_nhom+" and ll.loai="+i_loai+" and ll.phieu="+i_phieu+" and ll.makp="+i_makp;
				if (s_madt!="" && tenfile=="d_thucxuat") sql+=" and a.madoituong=e.madoituong and a.madoituong in ("+s_madt.Substring(0,s_madt.Length-1)+")";
				if (s_manguon!="") sql+=" and a.manguon in ("+s_manguon.Substring(0,s_manguon.Length-1)+")";
			}
			sql+=" order by rownum";
			//
			dsct=d.get_data(sql);
			dataGrid2.DataSource=dsct.Tables[0];
			//
			co.Text=Load_sotk(dsct.Tables[0]);
			co.Tag=(dsct.Tables[0].Rows.Count>0)?(dsct.Tables[0].Rows[0]["tenkho"].ToString()):"";
			//
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}
		private void ref_text()
		{
			int i=dataGrid1.CurrentCell.RowNumber;
			DataRow r=d.getrowbyid(ds_phieu.Tables[0],"idphieu="+dataGrid1[i,0].ToString());
			if(r!=null)
			{
				decimal l_id=decimal.Parse(r["idphieu"].ToString());
				int i_loai=int.Parse(r["loai"].ToString());
				int i_phieu=int.Parse(r["phieu"].ToString());
				no.Tag=r["so"].ToString()+" ("+s_mmyy.Substring(0,2)+"/"+s_mmyy.Substring(2,2)+")";
				int i_makp=int.Parse(r["makp"].ToString());// (tenkp.SelectedIndex>0)?int.Parse(tenkp.SelectedValue.ToString()):0;
				tenkp.SelectedValue=r["makp"].ToString();
				int i_makho=int.Parse(r["makho"].ToString());
				string s_madt=r["madoituong"].ToString();
				string s_manguon=r["manguon"].ToString();
				string s_ngay=r["ngayin"].ToString();
				int i_nhomin=int.Parse(r["loaiin"].ToString());
				if(chktt.Checked==false)
					load_xuat_ct(i_nhom,i_loai,i_phieu,i_makp,i_makho,s_madt,s_manguon,s_ngay,i_nhomin);				
				else
					load_in_phieuxuat(l_id);
			}
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			//
			int i_makho=(tenkp.SelectedIndex<0)?0:int.Parse(tenkp.SelectedValue.ToString());
			int i_nhomin=(nhomin.SelectedIndex<0)?0:int.Parse(nhomin.SelectedValue.ToString());
			load_sophieuxuat(i_makho,i_nhomin);
			//
		}

		private void chkngay_Click(object sender, System.EventArgs e)
		{
			ngaysp.Enabled=chkngay.Checked;
		}		
		private void butRef_Click(object sender, System.EventArgs e)
		{
			
			int i_makho=(tenkp.SelectedIndex<0)?0:int.Parse(tenkp.SelectedValue.ToString());
			int i_nhomin=(nhomin.SelectedIndex<0)?0:int.Parse(nhomin.SelectedValue.ToString());
			if(chktt.Checked==false)
			{
				load_sophieuxuat(i_makho,i_nhomin);
			}
			else
				load_sophieuxuat_tt (i_makho);
		}

		private void frmxempx_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(blnfirst)
			{
				tenkp.SelectedIndex=-1;
				nhomin.SelectedIndex=-1;
				blnfirst=false;
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables.Count==0) return;
			if (dsct.Tables[0].Rows.Count==0) return;
			//tongcong(dtct);
			string s_tenkho=co.Tag.ToString(),lydo="Sử dụng";			
			string s_sophieu=no.Tag.ToString();
			frmReport f=new frmReport(d,dsct.Tables[0],i_userid,"d_phieuxuat.rpt",s_sophieu,ngaysp.Text,no.Text,co.Text,tenkp.Text,lydo,s_tenkho,"","","");
			f.ShowDialog();			
		}
		private string Load_sotk(DataTable ldt)
		{
			string s_exp="";
			string s_tk="";
			foreach(DataRow r in ldt.Rows)
			{
				s_exp="id="+r["mabd"].ToString();
				DataRow r1=d.getrowbyid(dtdmbd,s_exp);
				if(r1!=null)
				{
					if(s_tk=="")
						s_tk=r1["stk"].ToString();
					else
					{
						if(s_tk.IndexOf(r1["stk"].ToString(),0)<0)
							s_tk=s_tk+", "+r1["stk"].ToString();
					}
				}
			}
			return s_tk;
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
			int i_makp=(tenkp.SelectedIndex<0)?0:int.Parse(tenkp.SelectedValue.ToString());
			load_sophieuxuat_tt(i_makp);
		}
		private void load_in_phieuxuat(decimal l_id)
		{
			string s_user=d.user;
			string sql="select a.stt,a.sttt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,f.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,round(a.sotien/a.soluong,3) dongia,a.sotien,a.giaban,a.madoituong,a.makho,a.manguon,a.nhomcc,'xx/xx/xxxx' ngay,a.sttduyet,0 tutruc,";
			sql+=" b.manhom idnhom, i.stt, i.ten tennhom, b.mahang, g.ten tenhang,b.manuoc, j.ten tennuoc,  ";
			sql+=" b.maloai idnn, h.ten noingoai ";
			sql+=" from d_xuatsdct a,"+s_user+".d_dmbd b,"+s_user+".d_dmnguon c,"+s_user+".d_nhomcc d,"+s_user+".d_doituong e,"+s_user+".d_dmkho f, "+s_user+".d_dmhang g, "+s_user+".d_dmloai h, "+s_user+".d_dmnhom i, "+s_user+".d_dmnuoc j ";
			sql+=" where a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.madoituong=e.madoituong and a.makho=f.id and a.id="+l_id;
			sql+=" and b.manhom=i.id and b.mahang=g.id and b.maloai=h.id and b.manuoc=j.id ";			
			sql+=" order by a.stt";
			dataGrid2.DataSource=null;
			dsct=d.get_data(sql);
			dataGrid2.DataSource=dsct.Tables[0];
			//
			//
			co.Text=Load_sotk(dsct.Tables[0]);
			co.Tag=(dsct.Tables[0].Rows.Count>0)?(dsct.Tables[0].Rows[0]["tenkho"].ToString()):"";
			//
		}

		private void chkngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)				
			{
				SendKeys.Send("{Tab}");
			}
		}

	}
}
