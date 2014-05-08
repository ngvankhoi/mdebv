using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXemton.
	/// </summary>
	public class frmXemtonct : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_kho,i_nhom;
		private bool bGiaban;
        private string user;
		private string s_mmyy,sql,format_sotien,format_soluong,format_dongia;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.TextBox tim;
        private Button butLoc;
        private TextBox manguon;
        private TextBox manhom;
        private Label label2;
        private Label label1;
        private ComboBox cbnguon;
        private ComboBox cbnhom;
        private TextBox txtmakho;
        private Label label3;
        private ComboBox cbokho;
        private CheckBox chkTatcakho;
        private string s_makho = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemtonct(AccessData acc,int kho,string mmyy,string tenkho,bool b_giaban,int nhom, string _makho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_kho=kho;
			s_mmyy=mmyy;
			bGiaban=b_giaban;
			i_nhom=nhom;
            s_makho = _makho;
			this.Text="Tồn "+tenkho.Trim()+" chi tiết tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemtonct));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butLoc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.TextBox();
            this.manhom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbnguon = new System.Windows.Forms.ComboBox();
            this.cbnhom = new System.Windows.Forms.ComboBox();
            this.txtmakho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbokho = new System.Windows.Forms.ComboBox();
            this.chkTatcakho = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 30);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 486);
            this.dataGrid1.TabIndex = 0;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(400, 522);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.Image = global::Duoc.Properties.Resources.refresh;
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(323, 522);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(78, 25);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "&Refresh";
            this.butRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(449, 27);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(335, 20);
            this.tim.TabIndex = 5;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butLoc
            // 
            this.butLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLoc.Location = new System.Drawing.Point(750, 2);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(35, 23);
            this.butLoc.TabIndex = 26;
            this.butLoc.Text = "Lọc";
            this.butLoc.UseVisualStyleBackColor = true;
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // manguon
            // 
            this.manguon.Location = new System.Drawing.Point(51, 3);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(41, 20);
            this.manguon.TabIndex = 20;
            this.manguon.Validated += new System.EventHandler(this.manguon_Validated);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // manhom
            // 
            this.manhom.Location = new System.Drawing.Point(392, 3);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(56, 20);
            this.manhom.TabIndex = 22;
            this.manhom.Validated += new System.EventHandler(this.manhom_Validated);
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nhóm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nguốn";
            // 
            // cbnguon
            // 
            this.cbnguon.FormattingEnabled = true;
            this.cbnguon.Location = new System.Drawing.Point(93, 3);
            this.cbnguon.Name = "cbnguon";
            this.cbnguon.Size = new System.Drawing.Size(245, 21);
            this.cbnguon.TabIndex = 21;
            this.cbnguon.SelectedIndexChanged += new System.EventHandler(this.cbnguon_SelectedIndexChanged);
            this.cbnguon.Validated += new System.EventHandler(this.cbnguon_Validated);
            this.cbnguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // cbnhom
            // 
            this.cbnhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbnhom.FormattingEnabled = true;
            this.cbnhom.Location = new System.Drawing.Point(449, 3);
            this.cbnhom.Name = "cbnhom";
            this.cbnhom.Size = new System.Drawing.Size(300, 21);
            this.cbnhom.TabIndex = 23;
            this.cbnhom.SelectedIndexChanged += new System.EventHandler(this.cbnhom_SelectedIndexChanged);
            this.cbnhom.Validated += new System.EventHandler(this.cbnhom_Validated);
            this.cbnhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // txtmakho
            // 
            this.txtmakho.Location = new System.Drawing.Point(51, 26);
            this.txtmakho.Name = "txtmakho";
            this.txtmakho.Size = new System.Drawing.Size(41, 20);
            this.txtmakho.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Kho ";
            // 
            // cbokho
            // 
            this.cbokho.FormattingEnabled = true;
            this.cbokho.Location = new System.Drawing.Point(93, 26);
            this.cbokho.Name = "cbokho";
            this.cbokho.Size = new System.Drawing.Size(245, 21);
            this.cbokho.TabIndex = 28;
            this.cbokho.SelectedIndexChanged += new System.EventHandler(this.cbokho_SelectedIndexChanged);
            // 
            // chkTatcakho
            // 
            this.chkTatcakho.AutoSize = true;
            this.chkTatcakho.Location = new System.Drawing.Point(344, 30);
            this.chkTatcakho.Name = "chkTatcakho";
            this.chkTatcakho.Size = new System.Drawing.Size(78, 17);
            this.chkTatcakho.TabIndex = 30;
            this.chkTatcakho.Text = "Tất cả kho";
            this.chkTatcakho.UseVisualStyleBackColor = true;
            this.chkTatcakho.Click += new System.EventHandler(this.chkTatcakho_Click);
            this.chkTatcakho.CheckedChanged += new System.EventHandler(this.chkTatcakho_CheckedChanged);
            // 
            // frmXemtonct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkTatcakho);
            this.Controls.Add(this.txtmakho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbokho);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbnguon);
            this.Controls.Add(this.cbnhom);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemtonct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemtonct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemtonct_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
			format_sotien=d.format_sotien(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
            //
            //
            cbnhom.DataSource = d.get_data("select id, ten from " + user + ".d_dmnhom where nhom=" + i_nhom).Tables[0];
            cbnhom.DisplayMember = "TEN";
            cbnhom.ValueMember = "ID";
            //
            cbnguon.DataSource = d.get_data("select id, ten from " + user + ".d_dmnguon where nhom=" + i_nhom).Tables[0];
            cbnguon.DisplayMember = "TEN";
            cbnguon.ValueMember = "ID";
            //
            sql = "select id, ten from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
            if (s_makho.Trim().Trim(',') != "") sql += " and id in(" + s_makho.Trim().Trim(',') + ")";
            cbokho.DataSource = d.get_data(sql).Tables[0];
            cbokho.DisplayMember = "TEN";
            cbokho.ValueMember = "ID";
            cbokho.SelectedValue = i_kho;
            //
			load_grid("","");
			AddGridTableStyle();
		}

		private void load_grid(string d_manguon, string d_manhom)
		{
            sql = "select case when c.ten is null then '['||e.manguon||']' else c.ten end as tennguon,case when d.ten is null then '['||e.nhomcc||']' else d.ten end as tennhomcc,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,e.handung,nullif(e.losx,' ') as losx,a.tondau,a.tondau*e.giamua as sttondau,a.slnhap,a.slnhap*e.giamua as stnhap,a.slxuat,a.slxuat*e.giamua as stxuat,a.tondau+a.slnhap-a.slxuat as toncuoi,a.tondau*e.giamua+a.slnhap*e.giamua-a.slxuat*e.giamua as sttoncuoi,";
			if (bGiaban && !d.bGiaban_theodot(i_nhom)) sql+="b.giaban,";
			else sql+="e.giaban,";
			sql+="e.giamua, e.gianovat, f.ten as tenkho ";
            sql += " from " + user + s_mmyy + ".d_tonkhoct a inner join " + user + s_mmyy + ".d_theodoi e on a.stt=e.id inner join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmnguon c on e.manguon=c.id left join " + user + ".d_dmnx d on e.nhomcc=d.id ";
            sql += " inner join "+user+".d_dmkho f on a.makho=f.id ";
            sql += " where a.makho=" + i_kho;
            if (d_manguon.Trim() != "" && d_manguon.Trim() != "0") sql += " and e.manguon in(" + d_manguon.Trim().Trim(',') + ")";
            if (d_manhom.Trim() != "" && d_manhom.Trim() != "0") sql += " and b.manhom in(" + d_manhom.Trim().Trim(',') + ")";
            if (d.bNhaptruocxuat(i_nhom)) sql += " order by a.stt";
            else sql += " order by substring(e.handung,3,2),substring(e.handung,1,2),a.stt";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
		}

        private void load_grid(int d_makho, string d_manguon, string d_manhom)
        {
            sql = "select case when c.ten is null then '['||e.manguon||']' else c.ten end as tennguon,case when d.ten is null then '['||e.nhomcc||']' else d.ten end as tennhomcc,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,e.handung,nullif(e.losx,' ') as losx,a.tondau,a.tondau*e.giamua as sttondau,a.slnhap,a.slnhap*e.giamua as stnhap,a.slxuat,a.slxuat*e.giamua as stxuat,a.tondau+a.slnhap-a.slxuat as toncuoi,a.tondau*e.giamua+a.slnhap*e.giamua-a.slxuat*e.giamua as sttoncuoi,";
            if (bGiaban && !d.bGiaban_theodot(i_nhom)) sql += "b.giaban,";
            else sql += "e.giaban,";
            sql += "e.giamua, e.gianovat, f.ten as tenkho ";
            sql += " from " + user + s_mmyy + ".d_tonkhoct a inner join " + user + s_mmyy + ".d_theodoi e on a.stt=e.id inner join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmnguon c on e.manguon=c.id left join " + user + ".d_dmnx d on e.nhomcc=d.id ";
            sql += " inner join " + user + ".d_dmkho f on a.makho=f.id ";
            sql += " where 1=1 ";
            if (d_makho > 0) sql += " and a.makho=" + d_makho;
            else if (s_makho.Trim().Trim(',') != "") sql += " and a.makho in(" + s_makho.Trim().Trim(',') + ")";
            else sql += " and f.hide=0 ";
            if (d_manguon.Trim() != "" && d_manguon.Trim() != "0") sql += " and e.manguon in(" + d_manguon.Trim().Trim(',') + ")";
            if (d_manhom.Trim() != "" && d_manhom.Trim() != "0") sql += " and b.manhom in(" + d_manhom.Trim().Trim(',') + ")";
            if (d.bNhaptruocxuat(i_nhom)) sql += " order by a.stt";
            else sql += " order by substring(e.handung,3,2),substring(e.handung,1,2),a.stt";
            dt = d.get_data(sql).Tables[0];
            dataGrid1.DataSource = dt;
        }

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
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
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
            TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?90:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giamua";
			TextCol.HeaderText = "Đơn gía";
			TextCol.Width = 80;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tondau";
			TextCol.HeaderText = "Tồn đầu";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sttondau";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slnhap";
			TextCol.HeaderText = "Nhập";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stnhap";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "slxuat";
			TextCol.HeaderText = "Xuất";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stxuat";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "toncuoi";
			TextCol.HeaderText = "Tồn cuối";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sttoncuoi";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?70:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gianovat";
            TextCol.HeaderText = "Giá trước VAT";
            TextCol.Width = 70;
            TextCol.Format = "###,###,###,##0.###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenkho";
            TextCol.HeaderText = "Kho";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%' or tenhc like '%"+text.Trim()+"%' or ma like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
            if (d.bKhoaso(i_nhom, s_mmyy) == false) d.f_capnhat_tonkhoct(s_mmyy, i_nhom);
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoct where tondau=0 and slnhap=0 and slxuat=0");
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoth where tondau=0 and slnhap=0 and slxuat=0");
            d.upd_tonkho(s_mmyy,i_nhom,1);
			load_grid("","");
            try
            {
                if (tim.Text.Trim() != "Tìm kiếm") RefreshChildren(tim.Text);
            }
            catch { }
            Cursor = Cursors.Default;
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

        private void cbnhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbnhom) manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbnguon) manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0"; }
        }

        private void manguon_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnguon.SelectedValue = manguon.Text;
            }
            catch { }
        }

        private void manhom_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnhom.SelectedValue = manhom.Text;
            }
            catch { }
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }


        private void cbnhom_Validated(object sender, EventArgs e)
        {
            try
            {
                manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_Validated(object sender, EventArgs e)
        {
            try
            {
                manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0"; }
        }

        private void butLoc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (chkTatcakho.Checked)
            {
                load_grid(0, manguon.Text, manhom.Text);
            }
            else
            {
                if (cbokho.SelectedIndex >= 0)
                {
                    load_grid(cbokho.SelectedIndex < 0 ? 0 : int.Parse(cbokho.SelectedValue.ToString()), manguon.Text, manhom.Text);
                }
                else
                {
                    load_grid(manguon.Text, manhom.Text);
                }
            }
            try
            {
                if (tim.Text.Trim() != "Tìm kiếm") RefreshChildren(tim.Text);
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void cbokho_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void chkTatcakho_Click(object sender, EventArgs e)
        {

        }

        private void chkTatcakho_CheckedChanged(object sender, EventArgs e)
        {
            txtmakho.Enabled = cbokho.Enabled = chkTatcakho.Checked == false;
        }
	}
}
