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
	/// Summary description for frmSDThuoc.
	/// </summary>
	public class frmSDThuoc : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private string sql,s_makp,user;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private DataTable dtdmbd=new DataTable();
		private System.Windows.Forms.Button butExit;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private DataSet dstmp=new DataSet();
		private DataSet ds=new DataSet();
		private int i_mabd;
		private bool bClear=true;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.TextBox tenbd;
		private LibList.List listDMBD;
		private MaskedBox.MaskedBox dang;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSDThuoc(LibMedi.AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmSDThuoc( string _makp)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData(); s_makp = _makp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSDThuoc));
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butExit = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.mabd = new System.Windows.Forms.TextBox();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.listDMBD = new LibList.List();
            this.dang = new MaskedBox.MaskedBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(168, 5);
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
            this.tu.Location = new System.Drawing.Point(56, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(288, 5);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(144, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(248, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(428, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên thuốc :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(398, 496);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(94, 25);
            this.butExit.TabIndex = 13;
            this.butExit.Text = "&Kết thúc";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(310, 496);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(85, 25);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "&Tổng hợp";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(257, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 34);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(190, 11);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(79, 18);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Ra viện";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(78, 12);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(108, 18);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Đang điều trị";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(6, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(56, 18);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Cả hai";
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(12, 458);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(164, 16);
            this.lbl1.TabIndex = 19;
            this.lbl1.Text = "Số ca :";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Red;
            this.lbl2.Location = new System.Drawing.Point(12, 480);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(172, 16);
            this.lbl2.TabIndex = 20;
            this.lbl2.Text = "Số lượng :";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mabd
            // 
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(488, 5);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(48, 21);
            this.mabd.TabIndex = 7;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenbd
            // 
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(539, 5);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(195, 21);
            this.tenbd.TabIndex = 8;
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(576, 520);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 27;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // dang
            // 
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(736, 5);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(47, 21);
            this.dang.TabIndex = 28;
            // 
            // frmSDThuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSDThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người bệnh sử dụng 1 loại thuốc";
            this.Load += new System.EventHandler(this.frmSDThuoc_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSDThuoc_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSDThuoc_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";
			dtdmbd=d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(a.tenhc)||'/'||b.ten as tenhc,a.dang,a.id from "+user+".d_dmbd a left join "+user+".d_dmhang b on a.mahang=b.id where a.nhom="+m.nhom_duoc+" order by a.ten").Tables[0];
			listDMBD.DataSource=dtdmbd;
            sql = "select * from " + user + ".btdkp_bv";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " where makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by loai,makp";
            makp.DataSource = m.get_data(sql).Tables[0];
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			dstmp.ReadXml("..//..//..//xml//m_sdthuoc.xml");
			ds.ReadXml("..//..//..//xml//m_sdthuoc.xml");
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_grid()
		{
			if (makp.SelectedIndex!=-1)
			{
                /*
                 * user+".btdbn a,"+user+".benhandt b,"+user+".bhyt c,"+user+".nhapkhoa d,"+user+".xuatkhoa e,"+user+".btdkp_bv f
                 * 
                 * a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql and d.id=e.id(+) and d.makp=f.makp
                 * */
                sql ="select f.tenkp,a.mabn,a.hoten,b.maql,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
				sql+=" case when e.ngay is null then ' ' else to_char(e.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
				sql+=" to_char(now(),'dd/mm/yyyy') as den,nullif(e.maicd,d.maicd) as maicd,";
				sql+=" nullif(e.chandoan,d.chandoan) as chandoan,00000000000.00 as soluong";
				sql+=" from "+user+".btdbn a inner join "+user+".benhandt b on a.mabn=b.mabn left join "+user+".bhyt c on b.maql=c.maql inner join "+user+".nhapkhoa d on b.maql=d.maql left join "+user+".xuatkhoa e on d.id=e.id inner join "+user+".btdkp_bv f on d.makp=f.makp ";
				sql+=" where ";
				sql+=" b.loaiba=1 and d.makp='"+makp.SelectedValue.ToString()+"'";
				sql+=" and "+m.for_ngay("d.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			}
			else
			{
                /*
                 * user+".btdbn a,"+user+".benhandt b,"+user+".bhyt c,"+user+".xuatvien d,"+user+".btdkp_bv f
                 * 
                 * a.mabn=b.mabn and b.maql=c.maql(+) and b.maql=d.maql(+) and b.makp=f.makp
                 * */
                sql ="select f.tenkp,a.mabn,a.hoten,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
				sql+=" case when d.ngay is null then ' ' else to_char(d.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
				sql+=" to_char(now(),'dd/mm/yyyy') as den,nullif(d.maicd,b.maicd) as maicd,";
				sql+=" nullif(d.chandoan,b.chandoan) as chandoan,00000000000.00 as soluong";
                sql += " from " + user + ".btdbn a inner join " + user + ".benhandt b on a.mabn=b.mabn left join " + user + ".bhyt c on b.maql=c.maql left join " + user + ".xuatvien d on b.maql=d.maql inner join " + user + ".btdkp_bv f on b.makp=f.makp ";
				sql+=" where ";
				sql+=" b.loaiba=1 and "+m.for_ngay("b.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			}
			dstmp=m.get_data(sql);
			ds.Clear();
			if (rb2.Checked) ds.Merge(dstmp.Tables[0].Select("ngayra=' '","ngayvao"));
			else if (rb3.Checked) ds.Merge(dstmp.Tables[0].Select("ngayra<>' '","ngayvao"));
			else ds.Merge(dstmp.Tables[0].Select("true","ngayvao"));
			get_data();
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void get_data()
		{
			DataTable dtthuoc=d.get_soluong_thuoc(i_mabd,tu.Text,den.Text,(makp.SelectedIndex!=-1)?makp.SelectedValue.ToString():"").Tables[0];
			decimal d1=0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				foreach(DataRow r1 in dtthuoc.Select("mabn='"+r["mabn"].ToString()+"'"))
				{
					r["soluong"]=decimal.Parse(r["soluong"].ToString())+decimal.Parse(r1["soluong"].ToString());
					d1+=decimal.Parse(r["soluong"].ToString());
				}
			}
			d.delrec(ds.Tables[0],"soluong=0");
			ds.AcceptChanges();
			lbl1.Text="Số ca :"+ds.Tables[0].Rows.Count.ToString();
			lbl2.Text="Số lượng :"+d1.ToString("###,###,###,###.##");
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
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 100;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 55;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ và tên";
			TextCol.Width = 140;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,5);
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 150;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,6);
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "ICD 10";
			TextCol.Width = 40;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de,7);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="###,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (mabd.Text=="" || tenbd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập tên thuốc !"),LibMedi.AccessData.Msg);
				mabd.Focus();
				return;
			}
			DataRow r=m.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ !"),LibMedi.AccessData.Msg);
				mabd.Focus();
				return;
			}
			i_mabd=int.Parse(r["id"].ToString());
			Cursor=Cursors.WaitCursor;
			load_grid();
			Cursor=Cursors.Default;
		}

		private void frmSDThuoc_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)	mabd_Validated(null,null);
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				DataRow r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					dang.Text=r["dang"].ToString();
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				Filter_mabd(mabd.Text);
				listDMBD.BrowseToDmbd(mabd,tenbd,tenbd,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width+dang.Width+10,mabd.Height+5);
			}		
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				Filter_dmbd(tenbd.Text);
				listDMBD.BrowseToDmbd(tenbd,mabd,butOk,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+tenbd.Width+dang.Width+10,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				DataRow r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
				}
			}
			SendKeys.Send("{F4}");
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
			}
			catch{}
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
	}
}